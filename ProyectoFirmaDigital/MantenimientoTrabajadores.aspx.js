let sCodigoPlan = '';
$(document).ready(function () {
    fnListaTrabajadores();
    $('.Editar').css('display', 'none');
    $('.Registrar').css('display', '');
     fnListaRoles();
});

$(document).on('click', '#btnNuevo', function () {
    $('#idTitulo').html('Registrar Trabajador');
    $('#txtNombreTrabajador').val('');
    $('#txtAPaterno').val('');
    $('#txtAMaterno').val('');
    $('#txtDNI').val('');
    $('#txtUsuario').val('');
    $('#txtClave').val('');
    $('#txtTelefono').val('');
    $('#cmbRol').val('');
    $('#cmbRol').change();


    $('.Editar').css('display', 'none');
    $('.Registrar').css('display', '');
    $('#RegistroPlan').modal('show');


});

$(document).on('click', '#btnRegistrar', function () {
    fnRegistraTrabajador();
    return false;
});

function fnListaRoles() {
    $.ajax({
        type: 'POST',
        url: 'MantenimientoTrabajadores.aspx/fnListaroles',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnArmaCombo("cmbRol",data.d.sValor1);
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../login.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });

}
function fnArmaCombo(html, sDatos) {
    var sDepartamento = sDatos.split('¬');
    if (sDepartamento != "") {
        var sCombo = '';
        for (var i = 0; i < sDepartamento.length; i++) {
            var fila = sDepartamento[i].split('|');
            sCombo += '<option value="' + fila[0] + '">';
            sCombo += fila[1] + '</option>';

        }

        $("#" + html).html(sCombo);
        $("#" + html).val('');
    }

}
function fnRegistraTrabajador() {
    var vNombre = $('#txtNombreTrabajador').val();
    var vApellidoPaterno = $('#txtAPaterno').val();
    var vApellidoMaterno = $('#txtAMaterno').val();
    var vDni = $('#txtDNI').val();
    var vUsuario = $('#txtUsuario').val();
    var vClave = $('#txtClave').val();
    var vTelefono = $('#txtTelefono').val();
    var vRol = $('#cmbRol').val();
    if (vRol == null) {
        vRol = '';
    }

    if (vNombre == '' || vApellidoPaterno == '' || vApellidoMaterno == '' || vDni == '' || vUsuario == '' || vClave == '' || vTelefono == '' || vRol=='') {
        bootbox.alert('Complete Todos Los Campos');
        return false;
    } else {
        fnRegistra(vNombre, vApellidoPaterno, vApellidoMaterno, vDni, vUsuario, vClave, vTelefono, vRol);
    }


}

function fnRegistra(vNombre, vApellidoPaterno, vApellidoMaterno, vDni, vUsuario, vClave, vTelefono, vRol) {
    var vParametro = "{'vNombre':'" + vNombre + "','vApellidoPaterno':'" + vApellidoPaterno + "','vApellidoMaterno':'" + vApellidoMaterno + "','vDni':'" + vDni + "','vUsuario':'" + vUsuario + "','vClave':'" + vClave + "','vTelefono':'" + vTelefono + "','vRol':'" + vRol+"'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoTrabajadores.aspx/fnRegistraTrabajador',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: vParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnListaTrabajadores();
                bootbox.alert('Trabajador Registrado Correctamente');
                $('#RegistroPlan').modal('hide');
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../login.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });

}

function fnEliminar(iIdPlan) {
    var vParametro = "{'iIdTrabajador':'" + iIdPlan + "'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoTrabajadores.aspx/fnEliminaTrabajador',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: vParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnListaTrabajadores();
                bootbox.alert('Trabajador Eliminado Correctamente');
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../login.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });

}

function fnListaTrabajadores() {
    $.ajax({
        type: 'POST',
        url: 'MantenimientoTrabajadores.aspx/fnListaTrabajadores',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnArmaTablaDetalle(data.d.sValor1);
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../login.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });

}
function fnEditaTrabajador(sParametro) {
    var vsplit = sParametro.split('|');
    sCodigoPlan = vsplit[0];
    $('#txtNombreTrabajador').val(vsplit[1]);
    $('#txtAPaterno').val(vsplit[2]);
    $('#txtAMaterno').val(vsplit[3]);
    $('#txtDNI').val(vsplit[4]);
    $('#txtUsuario').val(vsplit[5]);
    $('#txtClave').val(vsplit[6]);
    $('#txtTelefono').val(vsplit[7]);
    $('#cmbRol').val(vsplit[8]);
    $('#cmbRol').change();



    $('#idTitulo').html('Modificar Trabajador');
    $('.Editar').css('display', '');
    $('.Registrar').css('display', 'none');
    $('#RegistroPlan').modal('show');



}

$(document).on('click', '#btnModificar', function () {

    var vNombre = $('#txtNombreTrabajador').val();
    var vApellidoPaterno = $('#txtAPaterno').val();
    var vApellidoMaterno = $('#txtAMaterno').val();
    var vDni = $('#txtDNI').val();
    var vUsuario = $('#txtUsuario').val();
    var vClave = $('#txtClave').val();
    var vTelefono = $('#txtTelefono').val();
    var vRol = $('#cmbRol').val();

    if (vNombre == '' || vApellidoPaterno == '' || vApellidoMaterno == '' || vDni == '' || vUsuario == '' || vClave == '' || vTelefono == '' || vRol == '') {
        bootbox.alert('Complete Todos Los Campos');
    } else {
        fnActualizaTrabajador(sCodigoPlan, vNombre, vApellidoPaterno, vApellidoMaterno, vDni, vUsuario, vClave, vTelefono, vRol);
    }

    return false;

});

function fnActualizaTrabajador(iIdTrabajador, vNombre, vApellidoPaterno, vApellidoMaterno, vDni, vUsuario, vClave, vTelefono, vRol) {

    var vParametro = "{'iIdTrabajador':'" + iIdTrabajador+"','vNombre':'" + vNombre + "','vApellidoPaterno':'" + vApellidoPaterno + "','vApellidoMaterno':'" + vApellidoMaterno + "','vDni':'" + vDni + "','vUsuario':'" + vUsuario + "','vClave':'" + vClave + "','vTelefono':'" + vTelefono + "','vRol':'" + vRol + "'}";

    $.ajax({
        type: 'POST',
        url: 'MantenimientoTrabajadores.aspx/fnActualizaTrabajador',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: vParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnListaTrabajadores();
                bootbox.alert('Trabajador Modificado Correctamente');
                $('#RegistroPlan').modal('hide');
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../login.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });

}


function fnEliminaPlan(sCodigo) {


    fnEliminar(sCodigo);
    return false;
}

function fnArmaTablaDetalle(sData) {
    if (sData != "") {
        var Info = sData.split('¬');
        var Tbody = '';
        var h = 0;
        if (Info != "") {
            for (var i = 0; i < Info.length; i++) {
                var fila = Info[i].split('|');
                Tbody += "<tr >";
                Tbody += '<td style="font-size:12px;" class="text-left" >' + fila[0] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left" >' + fila[1] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[2] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[3] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[4] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[5] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[6] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[7] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[9] + '</td>';
                Tbody += '<td class="text-center"><a href="#"  onclick="fnEditaTrabajador(\'' + fila[0] + '|' + fila[1] + '|' + fila[2] + '|' + fila[3] + '|' + fila[4] +'|' + fila[5] + '|' + fila[6] + '|' + fila[7] + '|' + fila[8] +'\'); return false;" class="btn btn-primary btn-circle btn-sm" ><span style="position:static;" class="fas fa-pencil-alt"></span></a> </td>';
                Tbody += '<td class="text-center"><a href="#"  onclick="fnEliminaPlan(\'' + fila[0] + '\'); return false;" class="btn btn-danger btn-circle btn-sm" ><span style="position:static;" class="fas fa-trash"></span></a> </td>';
                Tbody += '</tr>';
                h++;
            }

            $("#dtTablaTrabajadores").html(Tbody);
        } else {
            $("#dtTablaTrabajadores").html("<tr><td colspan='6'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
        }
    } else {
        $("#dtTablaTrabajadores").html("<tr><td colspan='6'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
    }
}