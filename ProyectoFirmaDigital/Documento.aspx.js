$(document).ready(function () {
    fnListaDocumento();
});


function fnListaDocumento() {
    $.ajax({
        type: 'POST',
        url: 'Documento.aspx/fnListaDocumento',
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


function fnArmaTablaDetalle(sData) {
    if (sData != "") {
        var Info = sData.split('*');
        var Tbody = '';
        var h = 0;
        if (Info != "") {
            for (var i = 0; i < Info.length; i++) {
                var fila = Info[i].split('|');
                Tbody += "<tr >";
                //Tbody += '<td style="font-size:12px;" class="text-left" >' + fila[0] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[1] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[2] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[3] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[4] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[5] + '</td>';
                if (fila[6] == 'P') {
                    Tbody += '<td style="font-size:12px;" class="text-left">' + 'Pendiente' + '</td>';
                } else {
                    Tbody += '<td style="font-size:12px;" class="text-left">' + 'Firmado' + '</td>';
                }
                Tbody += '<td class="text-center"><a href="#" onclick="fnExisteDocumentoPrincipal(\'' + fila[7] + '|' + fila[1] + '|' + fila[8] + '\'); return false;" class="btn"><img src="img/PDF.png" style="width: 80%;"></a></td>';

                Tbody += '<td class="text-center"><a href="#"  onclick="fnEliminaDocumento(\'' + fila[0] + '|' + fila[7] + '\'); return false;" class="btn btn-danger btn-circle btn-sm" ><span style="position:static;" class="fas fa-trash"></span></a> </td>';
                Tbody += '</tr>';
                h++;
            }

            $("#dtTablaDocumento").html(Tbody);
        } else {
            $("#dtTablaDocumento").html("<tr><td colspan='4'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
        }
    } else {
        $("#dtTablaDocumento").html("<tr><td colspan='4'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
    }
}
