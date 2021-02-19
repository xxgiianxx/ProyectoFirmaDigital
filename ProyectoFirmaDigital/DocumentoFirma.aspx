<%@ Page Title="" Language="C#" MasterPageFile="~/HomeCliente.Master" AutoEventWireup="true" CodeBehind="DocumentoFirma.aspx.cs" Inherits="ProyectoFirmaDigital.DocumentoFirma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                  <div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Mantenimiento Empresas</h6>
                        </div>
                        <div class="card-body">
                        <!--
                         <a href="#" class="btn btn-success btn-icon-split" id="btnNuevo">
                                  <span class="icon text-white-50">
                                    <i class="fas fa-plus"></i>
                                     </span>
                                   <span class="text">Nuevo</span>
                          </a>
                          -->
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th style="font-size:12px;" class="text-center">Descripción </th>
                                            <th style="font-size:12px;" class="text-center">Personal Firma</th>
                                            <th style="font-size:12px;" class="text-center">Personal Carga</th>
                                            <th style="font-size:12px;" class="text-center">Fecha Firma</th>
                                        </tr>
                                    </thead>
                                    <tbody id="dtTablaEmpresa">

                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>

                </div>

    <div class="modal fade" id="MetodoPago" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Compra Online</h5>
                </div>
                <div class="modal-body">
                 <div class="row">
                      <div class="col">
                       <div class="input-group">
                         <div class="input-group-prepend">
                          <span class="input-group-text">Nombre Titular</span>
                           </div>
                              <input type="text" class="form-control" required  id="txtTitular" >
                         </div>
                       </div>
                  </div> 
                  <div class="row">
                      <div class="col">
                       <div class="input-group">
                         <div class="input-group-prepend">
                          <span class="input-group-text">Destinatario</span>
                           </div>
                              <input type="text" class="form-control" required  id="txtDestinatario" >
                         </div>
                       </div>
                  </div>
                <div class="row">
                      <div class="col">
                       <div class="input-group">
                         <div class="input-group-prepend">
                          <span class="input-group-text">Descripción</span>
                           </div>
                              <input type="text" class="form-control" required  id="txtDescripcion" >
                         </div>
                       </div>
                  </div>    


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary Registrar" id="btnEnviarDocumento">Enviar</a>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
