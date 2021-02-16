let sDataPlanes = '';
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
            html += ' <a href="#" class="btn btn-sm btn-primary" onclick="fnCompraPlan(\'' + vspli[0] + '\'); return false;"><i class="fas fa-money-check-alt fa-sm text-white-50"></i>&nbsp;Comprar</a> ';
            html += ' </div> ';
            html += ' </div> ';
            html += ' </div> ';
            html += ' </div> ';
            html += ' </div> ';
            html += ' </div> ';


            //  < div class="col-xl-2 col-md-6 mb-4" >
            //        <div class="card border-left-primary shadow h-100 py-2">
            //            <div class="card-body">
            //                <div class="row no-gutters align-items-center">
            //                    <div class="col mr-1">
            //                        <div class="text-xs font-weight-bold text-primary text-uppercase mb-3 text-center"> Plan</div>
            //                        <div class="h5 mb-2 font-weight-bold text-gray-800 text-center "  >100</div>
            //                        <div class="h5 mb-1 font-weight-bold text-gray-800 text-center">S/.250</div>
            //                        <div class="h5 mb-0 font-weight-bold text-gray-800 text-center">
            //                            <a href="#" class="btn btn-sm btn-primary"><i class="fas fa-money-check-alt fa-sm text-white-50"></i>&nbsp;Comprar</a>
            //                        </div>
            //                    </div>
            //                </div>
            //            </div>
            //        </div>
            //</div > 

        }

        $('#Plan').html(html);



    } else {

    $('#Plan').html('<h1>No Existen Planes Registrados</h1>');

    }

}