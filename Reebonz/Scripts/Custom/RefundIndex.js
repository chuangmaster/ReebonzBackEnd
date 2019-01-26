function OrderDetail() {
    this.sku = '';
    this.amount = 0;
    this.price = 0;
    this.orderDetailTemp = '';
}
var app = new Vue({
    el: '#app',
    data: {
        transationID: '',
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
        shipmentDate: formatDate(new Date())
    },
    mounted: function () {

    },
    methods: {
        searchTransationID: function () {
            $.ajax({
                url: '/api/v1/Order/' + this.transationID,
                success: function (result, textStatus, jqXHR) {
                    var self = this;
                    if (result.Data !== null) {
                        self.orderDetails = result.Data;
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
            orderDetail.refundAmount = `${self.tempOrderDetailSKU}_0`;
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
                TransationID: self.transationID,
                OrderDetails: self.orderDetails
            };
            $("#addOrderRefundModal").modal("show");
            //$.ajax({
            //    url: '/api/v1/Order',
            //    method: 'post',
            //    data: obj,
            //    success: function (result, textStatus, jqXHR) {
            //        var self = this;
            //        if (result.Data !== null) {
            //            self.orderDetails = result.Data;
            //        } else {

            //        }
            //    },
            //    error: function () {

            //    }
            //});
        },
        addOrderRefund: function () {
            //u
            var obj = {
                TransationID: '',
                CaseNum: '',
                Memo: '',
                SenderName: '',
                SenderAddr: '',
                SenderPhone: '',
                AskDate: new Date(),
                ShipmentDate: new Date(),
            };
            $.ajax({
                url: '',
                method: 'post',
                data: obj,
                success: function () {

                },
                error: function () {

                }

            });

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