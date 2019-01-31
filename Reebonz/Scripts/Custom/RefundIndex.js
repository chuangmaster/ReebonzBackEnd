function OrderDetail() {
    this.sku = '';
    this.amount = 0;
    this.price = 0;
    this.orderDetailTemp = '';
}
var app = new Vue({
    el: '#app',
    data: {
        orderID: '',
        transactionID: '',
        orderDetails: [],
        tempOrderDetailSKU: '',
        tempOrderDetailPrice: 0,
        tempOrderDetailAmount: 0,
        caseNum: '',
        memo: '',
        senderName: '',
        senderAddr: '',
        senderPhone: '',
        askDate: formatDate(new Date()),
        shipmentDate: formatDate(new Date()),
        wantRefundForView: []
    },
    mounted: function () {

    },
    methods: {
        searchTransactionID: function () {
            var self = this;
            if (self.transactionID === '') {
                alert('請輸入訂單編號!');
                return;
            }
            $.ajax({
                url: '/api/v1/Order/' + self.transactionID,
                success: function (result, textStatus, jqXHR) {
                    if (result.Data !== null) {
                        self.orderID = result.Data.id;
                        self.transactionID = result.Data.transactionID;
                        self.orderDetails = result.Data.orderDetails;
                        self.orderDetails.forEach(function (item) {
                            item.orderDetailTemp = `${item.sku}_0`;
                        });
                        $('#searchOrderModal').modal('hide');
                        $('#addOrderRefundModal').modal('show');
                    } else {
                        $('#addOrderDetailModal').modal('show');
                    }
                },
                error: function () {
                    alert('error');
                }
            });
        },
        addOrderDetail: function () {
            var self = this;
            var errorMessage = self.validOrderDetail(self.orderDetails, self.tempOrderDetailSKU, self.tempOrderDetailPrice, self.tempOrderDetailAmount);
            if (errorMessage != '') {
                alert(errorMessage);
                return;
            }
            var orderDetail = new OrderDetail();
            orderDetail.price = parseInt(self.tempOrderDetailPrice);
            orderDetail.amount = parseInt(self.tempOrderDetailAmount);
            orderDetail.sku = self.tempOrderDetailSKU;
            orderDetail.orderDetailTemp = `${self.tempOrderDetailSKU}_0`;
            var isExist = false;
            self.orderDetails.forEach(function (item) {
                if (orderDetail.sku === item.sku) {
                    item.price = orderDetail.price;
                    item.amount += orderDetail.amount;
                    isExist = true;
                }
            });

            if (isExist === false) {
                self.orderDetails.push(orderDetail);
            }

        },
        editOrderDetail: function (orderDetail) {
            var self = this;
            self.tempOrderDetailSKU = orderDetail.sku;
            self.tempOrderDetailPrice = orderDetail.price;
            self.tempOrderDetailAmount = orderDetail.amount;
        },
        removeOrderDetail: function (index) {
            var self = this;
            var orderDetail = self.orderDetails[index];
            if (orderDetail !== null) {
                self.orderDetails.splice(index, 1);
            }

        },
        addOrder: function () {
            var self = this;
            if (self.orderDetails.length <= 0) {
                alert('訂單內容不允許空白');
                return;
            }
            var obj = {
                TransactionID: self.transactionID,
                OrderDetails: self.orderDetails
            };
            $.ajax({
                url: '/api/v1/Order',
                method: 'post',
                data: obj,
                success: function (result, textStatus, jqXHR) {
                    var self = this;
                    if (result.Data !== null) {
                        self.orderDetails.forEach(function (od) {
                            self.wantRefundForView.push({
                                sku: od.orderDetailTemp.split('_')[0],
                                price: od.price,
                                amount: od.orderDetailTemp.split('_')[1]
                            });
                        });
                        $("#addOrderDetailModal").modal("hide");
                        $("#addOrderRefundModal").modal("show");

                    } else {
                        alert(result.Message);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseJSON.Message);
                }
            });
        },
        showRefundInfoModal: function () {
            var self = this;
            self.wantRefundForView = [];
            self.orderDetails.forEach(function (od) {
                if (parseInt(od.orderDetailTemp.split('_')[1]) > 0) {
                    self.wantRefundForView.push({
                        sku: od.orderDetailTemp.split('_')[0],
                        price: od.price,
                        amount: od.orderDetailTemp.split('_')[1]
                    });
                }
            });
            var biggerThanOne = self.wantRefundForView.filter(function (item) {
                if (item.amount > 0) {
                    return item;
                }
            });
            if (biggerThanOne.length > 0) {

                $("#addOrderRefundModal").modal("hide");
                $("#addRefundInfoModal").modal("show");
            } else {
                alert('退貨數量不合理');
            }

        },
        addOrderRefund: function () {
            var self = this;
            var errorText = '';
            if (self.senderAddr === '') {
                errorText += '需要有取件地址';
            }
            if (self.senderName === '') {
                errorText += '需要有取件人名稱';
            }
            if (self.senderPhone === '') {
                errorText += '需要有取件人電話';
            }


            if (errorText === '') {
                var confirmMessage = '請確認退貨資料:\r\n';
                confirmMessage += `訂單編號:${self.transactionID}\r\n`;

                var wantRefund = [];
                self.wantRefundForView.forEach(function (item) {
                    wantRefund.push({
                        SKU: item.sku,
                        Price: item.price,
                        Amount: item.amount
                    });
                    confirmMessage += `${item.sku}-${item.amount}件-單筆退款金額NT${item.price}\r\n`;
                });
                confirmMessage += `取件人名稱:${self.senderName}\r\n`;
                confirmMessage += `取件地址:${self.senderAddr}\r\n`;
                confirmMessage += `取件人電話:${self.senderPhone}\r\n`;
                confirmMessage += `取件時間:${formatDate(new Date(self.askDate))}\r\n`;
                confirmMessage += `通知時間:${formatDate(new Date(self.shipmentDate))}\r\n`;
                confirmMessage += `備註:${self.memo}\r\n`;
                confirmMessage += `CaseNum:${self.caseNum}\r\n`;

                var y = confirm(confirmMessage);
                if (y) {
                    var obj = {
                        OrderID: self.orderID,
                        TransactionID: self.transactionID,
                        CaseNum: self.caseNum,
                        Memo: self.memo,
                        SenderName: self.senderName,
                        SenderAddr: self.senderAddr,
                        SenderPhone: self.senderPhone,
                        AskDate: formatDate(new Date(self.askDate)),
                        ShipmentDate: formatDate(new Date(self.shipmentDate)),
                        RefundDetails: wantRefund
                    };

                    $.ajax({
                        url: '/api/v1/refund',
                        method: 'post',
                        data: obj,
                        success: function (result) {
                            if (result.Message !== '') {
                                alert(result.Message);
                                location.reload();
                            }
                        },
                        error: function (jsXHR) {
                            alert(jsXHR.responseJSON.Message);
                        }
                    });
                }
            } else {
                alert(errorText);
            }
        },
        validOrderDetail: function (orderDetails, sku, price, amount) {
            var errorMessage = '';
            if (price === '')
                price = 0;
            if (amount === '')
                amount = 0;
            if (sku === '') {
                errorMessage += 'sku不合法\n';
            }
            var detail = orderDetails.filter(function (item) {
                if (item.sku === sku)
                    return item;
            });
            if (detail.length > 0) {
                if (detail[0].amount + parseInt(amount) <= 0) {
                    errorMessage += '數量必須大於0\n';
                }
            } else {
                if (parseInt(price) <= 0) {
                    errorMessage += '價格必須大於0\n';
                }
                if (parseInt(amount) <= 0) {
                    errorMessage += '數量必須大於0\n';
                }
            }
            return errorMessage;
        }
    }

});