<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MantenimientoDocumentos.aspx.cs" Inherits="ProyectoFirmaDigital.MantenimientoEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

              <div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Mantenimiento Documentos</h6>
                        </div>
                        <div class="card-body">
                         <a href="#" class="btn btn-success btn-icon-split" id="btnNuevo">
                                  <span class="icon text-white-50">
                                    <i class="fas fa-plus"></i>
                                     </span>
                                   <span class="text">Nuevo</span>
                              </a>
                            <br>
                            <br>
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th style="font-size:12px;" class="text-center">Código</th>
                                            <th style="font-size:12px;" class="text-center">Nombre</th>
                                            <th style="font-size:12px;" class="text-center">Descripción</th>
                                            <th style="font-size:12px;" class="text-center">Trab. Carga</th>
                                            <th style="font-size:12px;" class="text-center">Fecha Carga</th>
                                            <th style="font-size:12px;" class="text-center">Trab. Firma</th>
                                            <th style="font-size:12px;" class="text-center">Estado</th>
                                            <th style="font-size:12px;" class="text-center" colspan="2"> Accion</th>
<%--                                            <th style="font-size:12px;" class="text-center">Eliminar</th>--%>
                                            
                                        </tr>


                                    </thead>
        
                                    <tbody id="dtTablaDocumento">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>




  <div class="modal fade" id="RegistroDocumento" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
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
                                <span class="input-group-text">Nombre Documento</span>
                            </div>
                            <input type="text" class="form-control" aria-label="NombreDocumento" placeholder="Nombre del Documento" required id="txtRuc" maxlength="11"/>
                        </div>
                        </div>
                    </div>

                  <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Descripción</span>
                            </div>
                            <input type="text" class="form-control" aria-label="Descripcion" placeholder="Descripción del documento" required id="txtRazonSocial" />
                        </div>
                        </div>
                   </div>

                    <div class="row">
                <div class="col">
                     <div class="input-group mb-3">
                       <div class="input-group-prepend">
                            <span class="input-group-text">Trabajador</span>
                         </div>
                      <select id="cmdTrabajador" style="width:70%;" class="form-control" >
                     </select>                  

                     </div>
               </div>
           </div>

                    <div id="drop_zone" ondrop="dropHandler(event);" ondragover="dragOverHandler(event);">
                        <p class="arrastre">Seleccione y arrastre los archivos o <span class="clickaqui">haga click aqui</span></p>
                        <br>
                        
                    </div>
                    

                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary Registrar" id="btnRegistrar">Subir</a>

                </div>
            </div>
        </div>
    </div>

<script src="MantenimientoDocumentos.aspx.js"></script>

    <link rel="stylesheet" href="css/estilosdocumentos.css"/>
</asp:Content>

