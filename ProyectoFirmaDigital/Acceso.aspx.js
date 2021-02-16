//$(document).load(function () {
//    fnValidaAcceso();


//});




//function fnValidaAcceso() {

//    $.ajax({
//        type: 'POST',
//        url: 'Accesso.aspx/fnListaPlanes',
//        contentType: 'application/json; utf-8',
//        dataType: 'json',
//        data: vParametro,
//        async: false,
//        success: function (data) {
//            if (data.d.iTipoResultado == 1) {
//                fnValidaLogin(data.d.sValor1);
//            } else if (data.d.iTipoResultado == 99) {
//                bootbox.alert(data.d.sMensajeError, function () {
//                    window.location = "Login.aspx";
//                });
//            } else {
//                bootbox.alert(data.d.sMensajeError);
//            }
//        },
//        error: function (jqXHR, textStatus, errorThrown) {
//        }

//    });

//}

//function fnValidaLogin(sIdRol) {

//    if (sIdRol == '1') {
//        $('.Admin').css('display', '');
//    } else {
//        $('.Admin').css('display', 'none');
//    }


//}