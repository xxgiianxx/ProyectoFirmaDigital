<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MantenimientoEmpresas.aspx.cs" Inherits="ProyectoFirmaDigital.MantenimientoEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

              <div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Mantenimiento Empresas</h6>
                        </div>
                        <div class="card-body">
                            <div class="row">
                             <div class="col">
                               <div class="btn-group">
                                <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                  Estado
                                </button>
                            <div class="dropdown-menu" id="cmbEstado">
                           <a class="dropdown-item" onclick="fnSoloActivos(); return false;">Activo</a>
                           <a class="dropdown-item" onclick="fnSoloInactivos(); return false;">Inactivo</a>
                       </div>
                      </div>

                   </div>
</div>
<%--                         <a href="#" class="btn btn-success btn-icon-split" id="btnNuevo">
                                  <span class="icon text-white-50">
                                    <i class="fas fa-plus"></i>
                                     </span>
                                   <span class="text">Nuevo</span>
                              </a>--%>
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th style="font-size:12px;" class="text-center">Razon Social </th>
                                            <th style="font-size:12px;" class="text-center">Ruc</th>
<%--                                            <th style="font-size:12px;" class="text-center">Departamento</th>--%>
                                            <th style="font-size:12px;" class="text-center">Direccion</th>
                                            <th style="font-size:12px;" class="text-center">Correo</th>
                                            <th style="font-size:12px;" class="text-center">Estado</th>
<%--                                            <th style="font-size:12px;"class="text-center"> Modificar</th>--%>
                                            <th style="font-size:12px;"class="text-center"> Inactivar</th>

<%--                                            <th style="font-size:12px;" class="text-center">Eliminar</th>--%>

                                        </tr>
                                    </thead>
         <%--                           <tfoot>
                                        <tr>
                                            <th>Name</th>
                                            <th>Position</th>
                                            <th>Office</th>
                                            <th>Age</th>
                                            <th>Start date</th>
                                            <th>Salary</th>
                                        </tr>
                                    </tfoot>--%>
                                    <tbody id="dtTablaEmpresa">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>




  <div class="modal fade" id="RegistroEmpresa" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel"><span id="idTitulo"></span></h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Ruc</span>
                            </div>
                            <input type="text" class="form-control" aria-label="Descripcion" placeholder="Ruc" required id="txtRuc" maxlength="11"/>
                        </div>
                        </div>
                    </div>

                  <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Razon Social</span>
                            </div>
                            <input type="text" class="form-control" aria-label="Descripcion" placeholder="Razon Social" required id="txtRazonSocial" />
                        </div>
                        </div>
                </div>
             <div class="row">
                <div class="col">
                     <div class="input-group mb-3">
                       <div class="input-group-prepend">
                            <span class="input-group-text">Departamento</span>
                         </div>
                      <select id="cmdDepartamento" style="width:100%;" class="form-control" >
                     </select>                  

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

<script src="MantenimientoEmpresas.aspx.js"></script>


</asp:Content>

