$(window).on('load', function () {
    $("#txtRutaDocumentoNuevo").click(function () {
        $('#idCargaDocumentoNuevo').val('');
        $('#txtRutaDocumentoNuevo').val('');
        $('#hdfRutaDocumento').val('');
        fnVisualizaCajaImagenNewVersion();
    });

});


$(document).ready(function () {
    //$('#dataTable').DataTable({
    //    //"searching": false,
    //    "paging": false,
    //    /"info": false
    //});
    fnListaTrabajadores();
    fnListaDocumento();
});

function fnVisualizaCajaImagenNewVersion() {
    var el = document.getElementById("idCargaDocumentoNuevo");
    if (el) {
        el.click();
    }
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


document.getElementById('idCargaDocumentoNuevo').addEventListener("change", function () {
    fnUpdater("idCargaDocumentoNuevo", "Documentos", "hdfRutaDocumento", "txtRutaDocumentoNuevo");
});

function fnUpdater(sControl, sCarpeta, sControlHidden, sControltxt) {
    var fileUpload = $("#" + sControl).get(0);
    let files = fileUpload.files;
    //var files = document.getElementById("fluArchivo").files;    
    var data = new FormData();
    var vNombreDocumento = files[0].name.split('.');

    data.append(files[0].name, files[0]);
    var filesize = files[0].size;

    if (vNombreDocumento.length > 2) {
        bootbox.alert('No se Permite Puntos(.) En El Archivo a Cargar');
        return false;
    }


    if (filesize == 0) {
        bootbox.alert('El Archivo No Tiene Contenido');
        return false;
    }

    if (filesize > 10000000) {
        bootbox.alert('el archivo excede del tamaño máximo permitido');
        return false;
    }

    data.append("Carpeta", sCarpeta);
    $.ajax({
        url: "FileLoad.ashx",
        type: "POST",
        data: data,
        contentType: false,
        processData: false,
        success: function (result) {

            $("#" + sControlHidden).val(result.split('|')[1]);
            $("#" + sControltxt).val(result.split('|')[1]);
        },
        error: function (err) {
            //mensaje de Error
            bootbox.alert("Ocurrió un error inesperado.");
        }
    });



}

$(document).on('click', '#btnNuevo', function () {
    $('#txtNombreDocumento').val();
    $('#txtDescripcion').val();
    $('#cmdTrabajador').val('');
    $('#cmdTrabajador').change();
    $('#txtRutaDocumentoNuevo').val('');
    $('#RegistroDocumento').modal('show');
    $('#idTitulo').html('Registro Documento');
    return false;
});

$(document).on('click','#btnRegistrar',function(){
    fnRegistraDocumento();
    return false;
});


function fnRegistraDocumento() {
    var vNombreDocumento = $('#txtNombreDocumento').val();
    var vDescripcion = $('#txtDescripcion').val();
    var vTrabajador = $('#cmdTrabajador').val();
    var vNomDoc = $('#txtRutaDocumentoNuevo').val();
   
    if (vTrabajador == null) {
        vTrabajador = '';
    }

    if (vNombreDocumento == '' || vDescripcion == '' || vTrabajador == '' || vNomDoc=='') {
        bootbox.alert('Complete Los Campos');
        return false;
    } else {
        var vFormato = comprueba_extension(vNomDoc);

        bootbox.confirm({
            message: "Esta Seguro de Cargar el Documento",
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
                    fnConfirmaSubida(vNombreDocumento, vDescripcion, vTrabajador, vNomDoc, vFormato);
                }
            }
        });



    }




}
function comprueba_extension(archivo) {
    extensiones_permitidas = new Array(".gif", ".jpg", ".doc", ".pdf", ".xlsx", ".xls", ".docx", ".ppt", ".pptx", ".txt", ".vsd", ".vsdx");

    mierror = "";
    if (!archivo) {
        mierror = "No has seleccionado ningún archivo";
    } else {
        extension = (archivo.substring(archivo.lastIndexOf("."))).toLowerCase();
        permitida = false;
        for (var i = 0; i < extensiones_permitidas.length; i++) {
            if (extensiones_permitidas[i] == extension) {
                permitida = true;
                break;
            }
        }
        if (!permitida) {
            mierror = "Comprueba la extensión de los archivos a subir. \nSólo se pueden subir archivos con extensiones: " + extensiones_permitidas.join();
        } else {
            return extension.replace('.', '');// replace(extension, '.', '');
        }
    }

    //si estoy aqui es que no se ha podido submitir
    alert(mierror);
    return extension;
}
function fnConfirmaSubida(vNombreDocumento, vDescripcion, vTrabajador, vNomDoc,vformato) {

    var sParametro = "{'sNombreDocumento':'" + vNombreDocumento + "','sDescripcion':'" + vDescripcion + "','iTrabajador':'" + vTrabajador + "','sNomDoc':'" + vNomDoc + "','sFormato':'" + vformato+"'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoDoc.aspx/fnGuardaDocumento',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: sParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                $('#RegistroDocumento').modal('hide');
                bootbox.alert('Documento Cargado Correctamente');
                fnListaDocumento();

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

function fnListaTrabajadores() {
    $.ajax({
        type: 'POST',
        url: 'MantenimientoDoc.aspx/fnListaTrabajadores',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                fnArmaCombo("cmdTrabajador",data.d.sValor1);
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


function fnListaDocumento() {
    $.ajax({
        type: 'POST',
        url: 'MantenimientoDoc.aspx/fnListaDocumento',
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

function fnEliminaDocumento(sParametro) {
    var vsplit = sParametro.split('|');
    bootbox.confirm({
        message: "Esta Seguro de Eliminar el documento Seleccionado?",
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
                fnEliminaConfirma(vsplit[0], vsplit[1]);
            }
        }
    });

}
function fnEliminaConfirma(sCodigo, sRuta) {
    var sParam = "{'sCodigo':'" + sCodigo + "','sRuta':'" + sRuta+"'}";
    $.ajax({
        type: 'POST',
        url: 'MantenimientoDoc.aspx/fnEliminaDocumento',
        data: sParam,
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == "1") {
                bootbox.alert('Documento Eliminado correctamente');
                fnListaDocumento();


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
                //Tbody += '<td style="font-size:12px;" class="text-left">' + fila[3] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[4] + '</td>';
                Tbody += '<td style="font-size:12px;" class="text-left">' + fila[5] + '</td>';
                //if (fila[6] == 'P') {
                //    Tbody += '<td style="font-size:12px;" class="text-left">' + 'Pendiente'+ '</td>';
                //} else {
                //    Tbody += '<td style="font-size:12px;" class="text-left">' + 'Firmado' + '</td>';
                //}
                Tbody += '<td class="text-center"><a href="#" onclick="fnExisteDocumentoPrincipal(\'' + fila[7] + '|' + fila[1] + '|' + fila[8] + '\'); return false;" class="btn"><img src="img/PDF.png" style="width: 80%;"></a></td>';

                Tbody += '<td class="text-center"><a href="#"  onclick="fnEliminaDocumento(\'' + fila[0] + '|' + fila[7] + '\'); return false;" class="btn btn-danger btn-circle btn-sm" ><span style="position:static;" class="fas fa-trash"></span></a> </td>';
                Tbody += '</tr>';
                h++;
            }

            $("#dtTablaDocumento").html(Tbody);
        } else {
            $("#dtTablaDocumento").html("");
        }
    } else {
        $("#dtTablaDocumento").html("");
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



