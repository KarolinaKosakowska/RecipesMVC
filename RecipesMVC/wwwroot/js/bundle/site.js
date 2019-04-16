let _id = 0;
let _controller = ''

function showPopup(id, controller) {
    _id = id;
    _controller = controller;
    $('#popup').removeClass('hidden')
    $('#popupShadow').removeClass('hidden')
}
function hidePopup() {
    _id = 0;
    _controller = '';
    $('#popup').addClass('hidden')
    $('#popupShadow').addClass('hidden')

}
function deleteRow() {
    if (_id != 0 && _controller != '')
    {
        $.ajax({
            type: "Delete",
            url: '/' + _controler +'/DeleteRow',
            data: {
                id: _id
            },
            success: function (result) {
                if (result == 'OK') {
                    $('#row_' + String(_id)).remove();
                    hidePopup()
                    alert('Usunięto.');
                }
                else {
                    hidePopup()
                    alert(result);
                }
            },
            error: function (e) {
                alert('Nie udało się usunąć.');
                hidePopup()
            }
        });
    }
}
