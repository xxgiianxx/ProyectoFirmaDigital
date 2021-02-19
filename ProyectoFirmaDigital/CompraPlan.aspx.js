let sDataPlanes = '';
let sCantidadComprada = '';
$(document).ready(function () {
    fnListaPlanes();

    fnArmaEstructuraPlan();
});


function fnListaPlanes() {
    $.ajax({
        type: 'POST',
        url: '../MantenimientoPlanes.aspx/fnListaPlanes',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                sDataPlanes=data.d.sValor1;
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

function fnCompraPlan(sParametros) {
    var vsplit = sParametros.split('|');
    sCantidadComprada = vsplit[2];
    $('#txtTotalPagar').val(vsplit[1]);
    $('#MetodoPago').modal('show');

}

function fnActualizaSaldoFirma(iCantidad) {
    var sParametro = "{'iCantidad':'" + iCantidad+"'}";
    $.ajax({
        type: 'POST',
        url: 'CompraPlan.aspx/fnActualizaPlan',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        data: sParametro,
        async: false,
        success: function (data) {
            if (data.d.iTipoResultado == 1) {
                bootbox.alert('Compra Exitosa');
                $('#txtDisponible').html(iCantidad);
                $('#MetodoPago').modal('hide');
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

$(document).on('click', '#btnConfirmarCompra', function () {



    bootbox.confirm({
        message: "Esta Seguro de Realizar La Compra Del Plan Seleccionado?<br> <span style='color:red;'> Una vez procesado el pago, no se realizarán reembolsos. </span> ",
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
                fnRegistraCompraplan();
            } else {
                $('#MetodoPago').modal('hide');
                bootbox.alert("Compra Cancelada");
            }
        }
    });



});


function fnRegistraCompraplan() {

    fnActualizaSaldoFirma(sCantidadComprada);



}





function fnArmaEstructuraPlan() {
    if (sDataPlanes != '') {

        var vsplit = sDataPlanes.split('*');
        var html = '';
        for (var x = 0; x < vsplit.length; x++) {
            var vspli = vsplit[x].split('|');

            html+= ' <div class="col-xl-2 col-md-6 mb-4" >';
            html += ' <div class="card border-left-primary shadow h-100 py-2">';
            html += ' <div class="card-body"> ';
            html += ' <div class="row no-gutters align-items-center"> ';
            html += ' <div class="col mr-1"> ';
            html += ' <div class="text-xs font-weight-bold text-primary text-uppercase mb-3 text-center">' + vspli[1] +'</div> ';
            html += ' <div class="h5 mb-2 font-weight-bold text-gray-800 text-center "  >' + vspli[2] +'</div> ';
            html += ' <div class="h5 mb-1 font-weight-bold text-gray-800 text-center">'+ 'S/.'+ vspli[3]+'</div> ';
            html += ' <div class="h5 mb-0 font-weight-bold text-gray-800 text-center"> ';
            html += ' <a href="#" class="btn btn-sm btn-primary" onclick="fnCompraPlan(\'' + vspli[0] + '|' + vspli[3] + '|' + vspli[2] + '\'); return false;"><i class="fas fa-money-check-alt fa-sm text-white-50"></i>&nbsp;Comprar</a> ';
            html += ' </div> ';
            html += ' </div> ';
            html += ' </div> ';
            html += ' </div> ';
            html += ' </div> ';
            html += ' </div> ';

        }

        $('#Plan').html(html);



    } else {

    $('#Plan').html('<h1>No Existen Planes Registrados</h1>');

    }


 

}