$(function () {
    var orderId = 0;
    var lineItemIds = [];
    var addOrderItemTemplate = '<input type="text" value="" /> <button id="addOrderItem">Add Order Item</button>';
    var hiddenOrderIdTemplate = '<input type="hidden" />';
    var addOrderDiv = $('#addOrderDiv');
    $('#addOrder').click(function () {
        // initialize order id and line item id
        var hidden = $(hiddenOrderIdTemplate);
        hidden.val(orderId);
        lineItemIds[orderId] = 0;

        var addOrderItemNameTemplate = '<div><input type="text" value="" name="orderdetails[' +
            orderId
            + '].name"/></div>';

        var orderName = $('#orderName');
        var addOrderItemName = $(addOrderItemNameTemplate);
        addOrderItemName.find('input').val(orderName.val());
        addOrderItemName.append(hidden);
        addOrderDiv.append(addOrderItemName);
        var addOrderItem = $(addOrderItemTemplate);
        addOrderItem.siblings('button').attr('Id', "addOrderItem" + orderId);
        var id = "#addOrderItem" + orderId;
        addOrderDiv.append(addOrderItem);
        $(id).click(addNewOrderItem);
        lineItemIds[orderId] = 0;
        orderId++;
        return false;
    });

    function addNewOrderItem() {
        var orderId = ($(this).prev().prev().children('input[type="hidden"]').val());
        var orderLineItem = '<input type="text" name="'
            + 'orderDetails['
            + orderId
            + '].lineItem['
            + lineItemIds[orderId]
            + '].Description"'
            + ' value="'
            + $(this).prev().val()
            + '" />';
        $(this).prev().prev().append(orderLineItem);
        lineItemIds[orderId]++;
        return false;
    }
});