var app = new Vue({
    el: '#app',
    data: {
        transationID: ''
    },
    methods: {
        searchTransationID: function () {
            alert('!');
            $.ajax({
                url: '/api/v1/Order/' + this.transationID,
                success: function (data, xhrObj, ) {
                    alert('success');
                },
                error: function () {
                    alert('error');
                }
            });
        },
        test: function () {

        }
    }

});