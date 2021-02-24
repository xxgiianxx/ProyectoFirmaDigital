$(document).ready(function () {


$(this).on('click', '#btnIngresar',function() {
    fnIngresar();
    return false;

});


});
function fnIngresar() {

    var vUsuario = $('#txtUsuario').val();
    var vClave = $('#txtClave').val();
    if (vUsuario == '' || vClave == '') {

        bootbox.alert('Complete Los Campos');
        return false;
    } else {
        AjaxValida(vUsuario, vClave);

    }
}

function AjaxValida(sUsuario, vClave) {
    var vParametro = "{'sUsuario':'" + sUsuario + "','sClave':'" + vClave + "'}";
    $.ajax({
        type: 'POST',
        url: 'Login.aspx/fnValida',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: vParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                var vsplit = (data.d.sValor1).split('|');
                if (vsplit[0] == '1') {
                    window.location = "../Acceso.aspx";//admin acceso
                } else {
                    if (vsplit[1] == 2) {//Gestor
                       
                     window.location = "../MenuPrincipalCliente.aspx";
                    } else {
                       window.location = "../HomeFirmante.aspx";//firmante
                    }
                }

            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../Login.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });


}