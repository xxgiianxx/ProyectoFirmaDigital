﻿$(document).ready(function () {

    fnListaEmpresa();

});

function fnListaEmpresa() {
    $.ajax({
        type: 'POST',
        url: 'MantenimientoEmpresas.aspx/fnListaEmpresas',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnArmaTablaDetalle(data.d.sValor1);
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../Default.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });

}
function fnEditaEmpresa(sParametro) {


}
function fnEliminaEmpresa(sParametro) {


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
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[1] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[2] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[3] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[4] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[5] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[6] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[7] + '</td>';
                Tbody += '<td class="text-center"><a href="#"  onclick="fnEditaEmpresa(\'' + fila[0] + '\'); return false;" class="btn btn-primary btn-circle btn-sm" ><span style="position:static;" class="fas fa-pencil-alt"></span></a> </td>';
                Tbody += '<td class="text-center"><a href="#"  onclick="fnEliminaEmpresa(\'' + fila[0] + '\'); return false;" class="btn btn-danger btn-circle btn-sm" ><span style="position:static;" class="fas fa-trash"></span></a> </td>';
                Tbody += '</tr>';
                h++;
            }

            $("#dtTablaEmpresa").html(Tbody);
        } else {
            $("#dtTablaEmpresa").html("<tr><td colspan='6'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
        }
    } else {
        $("#dtTablaEmpresa").html("<tr><td colspan='6'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
    }
}