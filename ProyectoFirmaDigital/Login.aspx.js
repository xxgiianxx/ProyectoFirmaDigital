
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
                //bootbox.alert('Bienvenido');
                window.location = "../Acceso.aspx";
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../Acceso.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });


}