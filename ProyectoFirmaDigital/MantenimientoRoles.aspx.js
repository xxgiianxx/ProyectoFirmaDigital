let sCodigoPlan = '';
$(document).ready(function () {

    fnListaRoles();
    $('.Editar').css('display', 'none');
    $('.Registrar').css('display', '');

});

$(document).on('click', '#btnNuevo', function () {
    $('#idTitulo').html('Registrar Plan');
    $('#txtDescripcion').val('');
    $('#txtCantidad').val('');
    $('#txtPrecio').val('');
    $('.Editar').css('display', 'none');
    $('.Registrar').css('display', '');
    $('#RegistroPlan').modal('show');
});

$(document).on('click', '#btnRegistrar', function () {
    fnRegistrarPlan();
    return false;
});

function fnRegistrarPlan() {
    var vDescripcion = $('#txtDescripcion').val();
    var vCantidad = $('#txtCantidad').val();
    var vPrecio = $('#txtPrecio').val();

    if (vDescripcion == '' || vCantidad == '' || vPrecio == '') {
        bootbox.alert('Complete Todos Los Campos');
        return false;
    } else {
        fnRegistra(vDescripcion, vCantidad, vPrecio);
    }


}

function fnRegistra(vDescripcion, vCantidad, vPrecio) {
    var vParametro = "{'sDescripcion':'" + vDescripcion + "','iCantidad':'" + vCantidad + "','dPrecio':'" + vPrecio + "'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoPlanes.aspx/fnRegistraPlanes',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: vParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnListaPlanes();
                bootbox.alert('Plan Registrado Correctamente');
                $('#RegistroPlan').modal('hide');
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

function fnEliminar(iIdPlan) {
    var vParametro = "{'iIdPlan':'" + iIdPlan + "'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoPlanes.aspx/fnEliminaPlan',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: vParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnListaPlanes();
                bootbox.alert('Plan Eliminado Correctamente');
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

function fnListaRoles() {
    $.ajax({
        type: 'POST',
        url: 'MantenimientoRoles.aspx/fnListaPlanes',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnArmaTablaDetalle(data.d.sValor1);
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
function fnEditarRol(sParametro) {
    var vsplit = sParametro.split('|');
    sCodigoPlan = vsplit[0];

    $('#txtDescripcion').val(vsplit[1]);
    $('#txtCantidad').val(vsplit[2]);
    $('#txtPrecio').val(vsplit[3]);
    $('#idTitulo').html('Editar Plan');
    $('.Editar').css('display', '');
    $('.Registrar').css('display', 'none');
    $('#RegistroPlan').modal('show');


}

$(document).on('click', '#btnModificar', function () {

    var vDescripcion = $('#txtDescripcion').val();
    var vCantidad = $('#txtCantidad').val();
    var vPrecio = $('#txtPrecio').val();

    if (vDescripcion == '' || vCantidad == '' || vPrecio == '') {
        bootbox.alert('Complete Todos Los Campos');
    } else {
        fnActualizaPlan(sCodigoPlan, vDescripcion, vCantidad, vPrecio);
    }

    return false;

});

function fnActualizaPlan(iIdPlan, vDescripcion, vCantidad, vPrecio) {

    var vParametro = "{'iIdPlan':'" + iIdPlan + "','sDescripcion':'" + vDescripcion + "','iCantidad':'" + vCantidad + "','dPrecio':'" + vPrecio + "'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoPlanes.aspx/fnActualizaPlan',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: vParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnListaPlanes();
                bootbox.alert('Rol Actualizado Correctamente');
                $('#RegistroPlan').modal('hide');
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


function fnEliminarRol(sCodigo) {


    fnEliminar(sCodigo);
    return false;
}




function fnArmaTablaDetalle(sData) {
    if (sData != "") {
        var Info = sData.split('*');
        var Tbody = '';
        var h = 0;
        if (Info != "") {
            for (var i = 0; i < Info.length; i++) {
                var fila = Info[i].split('|');
                Tbody += "<tr >";
                Tbody += '<td style="font-size:12px;" class="text-left" >' + fila[0] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[1]) + '</td>';
                Tbody += '<td class="text-center"><a href="#"  onclick="fnEditarRol(\'' + fila[0] + '|' + fila[1]  + '\'); return false;" class="btn btn-primary btn-circle btn-sm" ><span style="position:static;" class="fas fa-pencil-alt"></span></a> </td>';
                Tbody += '<td class="text-center"><a href="#"  onclick="fnEliminarRol(\'' + fila[0] + '\'); return false;" class="btn btn-danger btn-circle btn-sm" ><span style="position:static;" class="fas fa-trash"></span></a> </td>';
                Tbody += '</tr>';
                h++;
            }

            $("#dtTablaRoles").html(Tbody);
        } else {
            $("#dtTablaRoles").html("<tr><td colspan='1'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
        }
    } else {
        $("#dtTablaRoles").html("<tr><td colspan='1'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
    }
}