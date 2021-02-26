let sCodigoDocumento = '';
let sRutaDocumento = '';
let sNombreDocumento = '';
let sFormatoDocumento = '';


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

function fnFirmar(sParametros) {
    sCodigoDocumento = '';
    sRutaDocumento = '';
    sNombreDocumento = '';
    sFormatoDocumento = '';
    var vsplit = sParametros.split('|');
    sCodigoDocumento = vsplit[0];
    sRutaDocumento = vsplit[1];
    sNombreDocumento = vsplit[2];
    sFormatoDocumento = vsplit[3];

    bootbox.confirm({
        message: "Esta Seguro de Firmar el Documento Seleccionado?",
        buttons: {

            confirm: {
                label: '<i class="glyphicon glyphicon-ok"></i> Si',
                className: 'btn-success'
            },
            cancel: {
                label: '<i class="glyphicon glyphicon-remove"></i> No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                fnSincronizaFirma();
            } 
        }
    });





}

function fnSincronizaFirma() {

    var timerId, percent;

    // reset progress bar
    percent = 0;
    $('#load').css('width', '0px');
    $('#load').addClass('progress-bar-striped active');
    var pleaseWait = $('#pleaseWaitDialog');

    showPleaseWait = function () {
        pleaseWait.modal('show');
    };

    hidePleaseWait = function () {
        pleaseWait.modal('hide');
    };

    showPleaseWait();
    fnFirmarDoc();
    timerId = setInterval(function () {

        // increment progress bar
        percent += 1;
        $('#load').css('width', percent + '%');
        $('#load').html(percent + '%');

      
        // complete
        if (percent >= 100) {
            clearInterval(timerId);
            $('#load').removeClass('progress-bar-striped active');
            $('#load').html('payment complete');
            // do more ...
            $("#pleaseWaitDialog").modal('hide');
        }

    }, 200);
}

function fnFirmarDoc() {
    var vsplit = sRutaDocumento.split('//documentos//cargados//');
    var vParametro = "{'sCodigo':'" + sCodigoDocumento + "','sRuta':'" + sRutaDocumento + "','sNombre':'" + vsplit[1] + "','sFormato':'" + sFormatoDocumento+"'}";
    $.ajax({
        type: 'POST',
        url: 'Documento.aspx/fnFirmaDocumento',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        //async: false,
        data: vParametro,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                $('#pleaseWaitDialog').modal('hide');
                bootbox.alert('Documento Firmado');
                fnListaDocumento();

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
                //Tbody += '<td style="font-size:12px;" class="text-left">' + fila[5] + '</td>';
                //if (fila[6] == 'P') {
                //    Tbody += '<td style="font-size:12px;" class="text-left">' + 'Pendiente' + '</td>';
                //} else {
                //    Tbody += '<td style="font-size:12px;" class="text-left">' + 'Firmado' + '</td>';
                //}
                Tbody += '<td class="text-center"><a href="#" onclick="fnExisteDocumentoPrincipal(\'' + fila[7] + '|' + fila[1] + '|' + fila[8] + '\'); return false;" class="btn"><img src="img/PDF.png" style="width:50%;"></a></td>';

                Tbody += '<td class="text-center"><a href="#"  onclick="fnFirmar(\'' + fila[0] + '|' + fila[7] + '|' + fila[1] + '|' + fila[8] + '\'); return false;" class="btn btn-primary btn-circle btn-sm" ><span style="position:static;" <i class="fas fa-file-signature"></i>></span></a> </td>';
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

function fnExisteDocumentoPrincipal(sParametro) {
    var sData;
    var splits = sParametro.split('|');
    var sParam = "{'sRutaDocumento':'" + splits[0] + "','sNombreDocumento':'" + splits[1] + "','sTipoArchivo':'" + splits[2] + "'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoDoc.aspx/fnExisteDocumentoPrincipal',
        data: sParam,
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == "1") {
                sData = data.d.sValor1;
                if (sData !== "") {

                    downloadPDF(sData, splits[1], splits[2]);
                } else {
                    bootbox.alert("<b>Documento no existe!</b>");
                }
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "../Default.aspx";
                });
            } else {
                alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }
    });
    //return sData;
}
function downloadPDF(pdf, sNombre, sTipo) {
    const linkSource = `data:application/${sTipo};base64,${pdf}`;
    const downloadLink = document.createElement("a");
    const fileName = sNombre + "." + sTipo;
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
}