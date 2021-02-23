<%@ Page Title="" Language="C#" MasterPageFile="~/HomeCliente.Master" AutoEventWireup="true" CodeBehind="MantenimientoTrabajadores.aspx.cs" Inherits="ProyectoFirmaDigital.MantenimientoTrabajadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Mantenimiento Trabajadores</h6>
                        </div>
                        <div class="card-body">
                             <a href="#" class="btn btn-success btn-icon-split" id="btnNuevo">
                                  <span class="icon text-white-50">
                                    <i class="fas fa-plus"></i>
                                     </span>
                                   <span class="text">Nuevo</span>
                              </a>
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0" style="color:black">
                                    <thead>
                                        <tr>
                                            <th style="font-size:12px;" class="text-center" >ID</th>
                                            <th style="font-size:12px;" class="text-center" >Nombre</th>
                                            <th style="font-size:12px;" class="text-center">A. Paterno</th>
                                            <th style="font-size:12px;" class="text-center">A. Materno</th>
                                            <th style="font-size:12px;" class="text-center">Clave</th>
                                            <th style="font-size:12px;" class="text-center">Telefono</th>
                                            <th style="font-size:12px;" class="text-center">Clave</th>
                                            <th style="font-size:12px;" class="text-center">ROL</th>
                                            <th style="font-size:12px;" class="text-center">ESTADO</th>
<%--                                            <th style="font-size:12px;" class="text-center">Estado</th>--%>
<%--                                            <th style="font-size:12px;width:1%;"class="text-center" colspan="2"> Accion</th>--%>
                                              <th style="font-size:12px;width:1%;" class="text-center">Modificar</th>
                                              <th style="font-size:12px;width:1%;" class="text-center" >Eliminar</th>
                                        </tr>
                                    </thead>
                                    <tbody id="dtTablaTrabajadores">
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
                                <span class="input-group-text">NombreTrabajador</span>
                            </div>
                            <input type="text" class="form-control" aria-label="NombreTrabajador" placeholder="NombreTrabajador" required id="txtNombreTrabajador" maxlength="50"/>
                        </div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">APaterno</span>
                            </div>
                            <input type="text" class="form-control" aria-label="APaterno" placeholder="APaterno" required id="txtAPaterno" maxlength="50"/>
                        </div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">AMaterno</span>
                            </div>
                            <input type="text" class="form-control" aria-label="AMaterno" placeholder="AMaterno" required id="txtAMaterno" maxlength="50"/>
                        </div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">DNI</span>
                            </div>
                            <input type="text" class="form-control" aria-label="DNI" placeholder="DNI" required id="txtDNI" maxlength="50"/>
                        </div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Clave</span>
                            </div>
                            <input type="text" class="form-control" aria-label="Clave" placeholder="Clave" required id="txtClave" maxlength="50"/>
                        </div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Telefono</span>
                            </div>
                            <input type="text" class="form-control" aria-label="Telefono" placeholder="Telefono" required id="txtTelefono" maxlength="50"/>
                        </div>

                        </div>

                    </div>


                    <div class="row">
                      <div class="col">
                          <div class="input-group mb-3">
                              <div class="input-group-prepend">
                                  <span class="input-group-text" >Rol</span>
                             </div>
                            <input type="text" class="form-control" required  id="txtRol"  step="1">
                      </div>
                   </div>
               <div class="col">
    <div class="input-group mb-3">
  <div class="input-group-prepend">
    <span class="input-group-text" id="basic-addon2">Estado</span>
  </div>
  <input type="text" class="form-control" required id="txtEstado">
</div>
  </div>
</div>


                    

                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary Registrar" id="btnRegistrar">Registrar</a>
                     <a class="btn btn-primary Editar" id="btnModificar">Guardar</a>

                </div>
            </div>
        </div>
    </div>

    <script src="MantenimientoPlanes.aspx.js"></script>


</asp:Content>
