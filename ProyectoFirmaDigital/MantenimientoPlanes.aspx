<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MantenimientoPlanes.aspx.cs" Inherits="ProyectoFirmaDigital.MantenimientoPlanes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                  <div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Mantenimiento Planes</h6>
                        </div>
                        <div class="card-body">
                             <a href="#" class="btn btn-success btn-icon-split" id="btnNuevo">
                                  <span class="icon text-white-50">
                                    <i class="fas fa-plus"></i>
                                     </span>
                                   <span class="text">Nuevo</span>
                              </a>
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th style="font-size:12px;" class="text-center" >Descripcion</th>
                                            <th style="font-size:12px;" class="text-center">Cantidad</th>
                                            <th style="font-size:12px;" class="text-center">Precio</th>
<%--                                            <th style="font-size:12px;" class="text-center">Estado</th>--%>
                                            <th style="font-size:12px;width:1%;"class="text-center" colspan="2"> Accion</th>
                                        </tr>
                                    </thead>
                                    <tbody id="dtTablaPlanes">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>






        <div class="modal fade" id="RegistroPlan" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel"><span id="idTitulo"></span></h5>
                </div>
                <div class="modal-body">
<%--                    <div class="container">
                    <div class="row">
                     <div class="input-group flex-nowrap">  
                         <span class="input-group-text" id="txtDescripcion">Descripcion</span>
                          <input type="text" class="form-control bg-light border-1" placeholder="Descripcion" aria-label="Descripcion"aria-describedby="basic-addon1">
                      </div>
<%--                    </div>--%>

                    <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Descripcion</span>
                            </div>
                            <input type="text" class="form-control" aria-label="Descripcion" placeholder="Descripcion" required id="txtDescripcion" maxlength="50"/>
                        </div>

                        </div>

                    </div>
                    <div class="row">
                      <div class="col">
                          <div class="input-group mb-3">
                              <div class="input-group-prepend">
                                  <span class="input-group-text" >Cantidad</span>
                             </div>
                            <input type="number" class="form-control" required  id="txtCantidad" >
                      </div>
                   </div>
               <div class="col">
    <div class="input-group mb-3">
  <div class="input-group-prepend">
    <span class="input-group-text" id="basic-addon2">Precio</span>
  </div>
  <input type="number" class="form-control" required id="txtPrecio">
</div>
  </div>
</div>


                    

                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary Registrar" id="btnRegistrar">Registrar</a>
                     <a class="btn btn-primary Editar" id="btnModificar">Modificar</a>

                </div>
            </div>
        </div>
    </div>

    <script src="MantenimientoPlanes.aspx.js"></script>


</asp:Content>
