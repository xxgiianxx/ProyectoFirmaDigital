
var sDatos = '';

$(document).ready(function () {
    $("#dataTable").dataTable({
        "bPaginate": true,
        "bFilter": false,
        "bInfo": false,
        "paging": false,
        "ordering": false,
        "info": false,
        "bJQueryUI": true,
        "iDisplayLength": 1000,
        "bDestroy": true
    });

    $("#dtFechaInicio").val(fnFechaActualYMD());
    $("#dtFechafin").val(fnFechaActualYMD());

    fnFirmasDisponibles();
    fnFirmasUsadasDoc();





});
function fnFechaActualYMD() {
    var f = new Date();
    let iMes = f.getMonth() + 1;
    let sMes = "00";
    sMes = iMes + "";
    if (iMes < 10) {
        sMes = "0" + iMes;
    }

    let iDia = f.getDate();
    let sDia = "00";
    sDia = iDia + "";
    if (iDia < 10) {
        sDia = "0" + iDia;
    }
    iIdTarea = 0;
    return f.getFullYear() + "-" + sMes + "-" + sDia;

}

$(document).on('change', '#dtFechaInicio', function () {
    $("#dtFechafin").val($(this).val());
    document.getElementById("dtFechafin").setAttribute('min', $(this).val());
});

$(document).on('click', '#btnFiltrar', function () {

    var vFechaInicio = $('#dtFechaInicio').val();
    var vFechafin = $('#dtFechafin').val();

    if (vFechaInicio == '' || vFechaInicio == null || vFechafin == '' || vFechafin == null) {
        bootbox.alert('Seleccione Una Fecha de Inicio y Fin');
        return false;
    }

    var vdiferencia = monthDiff(new Date(vFechaInicio), new Date(vFechafin));
    if (vdiferencia > 3) {
        $("#dtTablaDocumentosFirmados").html("");
        bootbox.alert('La consulta No Puede ser Mayor a 3 Meses');

        return false;
    } else {
        fnFirmasUsadas(vFechaInicio, vFechafin);
    }

  
});
function monthDiff(d1, d2) {
    var months;
    months = (d2.getFullYear() - d1.getFullYear()) * 12; months -= d1.getMonth() + 1;
    months += d2.getMonth(); return months <= 0 ? 0 : months;
}


function fnFirmasDisponibles() {
    $.ajax({
        type: 'POST',
        url: 'Documento.aspx/fnFirmasDisponibles',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                $('#idDisponibles').html(data.d.sValor1);
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "login.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });

}

function fnFirmasUsadasDoc() {
    $.ajax({
        type: 'POST',
        url: 'Documento.aspx/fnFirmasUsadas',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                $('#idUsuadas').html(data.d.sValor1);
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "login.aspx";
                });
            } else {
                bootbox.alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }

    });

}
function fnFirmasUsadas(sFechaInicio, sFechaFin) {
    var vParametro = "{'sFechaInicio':'" + sFechaInicio + "','sFechaFin':'" + sFechaFin + "'}";
    $.ajax({
        type: 'POST',
        url: 'DocumentosFirmados.aspx/fnListaDocumentosFirmadosReporte',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: vParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnArmaTablaDetalle(data.d.sValor1);
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "login.aspx";
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
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[3] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[4] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[5] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-center">' + fila[9] + '</td>';
                Tbody += '<td class="text-center"><a href="#" onclick="fnExisteDocumentoPrincipal(\'' + fila[7] + '|' + fila[1] + '|' + fila[8] + '\'); return false;" class="btn"><img src="img/PDF.png" style="width:60%;"></a></td>';
                Tbody += '<td class="text-center"><a href="#" onclick="fnExisteDocumentoPrincipal(\'' + fila[10] + '|' + fila[1] + '|' + fila[8] + '\'); return false;" class="btn"><img src="img/PDF.png" style="width:60%;"></a></td>';
                //Tbody += '<td class="text-center"><a href="#" onclick="fnEnviarDocumentov2(\'' + fila[10] + '|' + fila[1] + '|' + fila[8] + '\'); return false;" class="btn"><img src="img/PDF.png" style="width:60%;"></a></td>';<i class="fas fa-paper-plane"></i>
                Tbody += '<td class="text-center"><a href="#" class="btn btn-sm btn-primary" onclick="fnEnviarDocumentov2(\'' + fila[10] + '|' + fila[1] + '|' + fila[8] + '\'); return false;"><i class="fas fa-paper-plane fa-sm text-white-50"></i></a></td> ';

                Tbody += '</tr>';
                h++;
            }

            $("#dtTablaDocumentosFirmados").html(Tbody);
        } else {
            $("#dtTablaDocumentosFirmados").html("<tr><td colspan='6'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
        }
    } else {
        $("#dtTablaDocumentosFirmados").html("<tr><td colspan='6'><b>NO SE ENCONTRARON RESULTADOS</b></td></tr>");
    }
}

function fnEnviarDocumentov2(sParametro) {
    sDatos = '';
    sDatos = sParametro;
    $('#EnvioCorreo').modal('show');

}

$(document).on('click', '#btEnviar', function () {

    var vCorreo = $('#txtCorreo').val();
    var vDescripcion = $('#Descripcion').val();

    if (vCorreo == '' || vDescripcion == '') {
        bootbox.alert('Complete Los Campos');
        return false;
    } else {
        emailRegex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
        if (emailRegex.test(vCorreo) == false) {
            bootbox.alert('Digite el correo Correctamente!');
            return false;
        } else {
            fnEnviarDocumento(sDatos, vCorreo, vDescripcion);

        }

    }


});


function fnEnviarDocumento(sParametro,sCorreo,sDescripcion) {
    var splits = sParametro.split('|');
    var vsplit = splits[0].split('//documentos//firmados//');
    var sParam = "{'sRutaDocumento':'" + splits[0] + "','sNombreDocumento':'" + vsplit[1] + "','sTipoArchivo':'" + splits[2] + "','sCorreo':'" + sCorreo + "','sDescripcion':'" + sDescripcion+"'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoDoc.aspx/fnEnviarDocumento',
        data: sParam,
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.d.iTipoResultado == "1") {
                $('#EnvioCorreo').modal('hide');
                bootbox.alert('Documento Enviado')
                $('#txtCorreo').val('');
                $('#Descripcion').val('');
                
            } else if (data.d.iTipoResultado == 99) {
                bootbox.alert(data.d.sMensajeError, function () {
                    window.location = "login.aspx";
                });
            } else {
                alert(data.d.sMensajeError);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }
    });

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