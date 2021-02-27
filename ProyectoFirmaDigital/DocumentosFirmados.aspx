<%@ Page Title="" Language="C#" MasterPageFile="~/HomeCliente.Master" AutoEventWireup="true" CodeBehind="DocumentosFirmados.aspx.cs" Inherits="ProyectoFirmaDigital.DocumentosFirmados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <link rel="stylesheet" href="css/estadisticodocumentos.css"/>

              <div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Estadísticos de Documentos Firmados</h6>
                        </div>
                        <div class="card-body">
                         <div class="contenedorcirculos">
                            <div class="circ">
                                <div id="circulo">
                                    <h2 id="idDisponibles">0</h2>
                                </div>
                                <div style="text-align:center;">
                                <span>Firmas Restantes</span>
                                </div>
                            </div>

                          <div class="circ2">
                                <div id="circulo2">
                                    <h2 id="idUsuadas">0</h2>
                                </div>
                                <div style="text-align:center;">
                                <span>Firmas Usadas</span>
                                </div>
                             </div>
                         </div>

<%--                  <div class="row">
                          <div class="col">
                           <div class="input-group mb-1">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Gestor</span>
                            </div>
                               <select id="cmbPersonalGestor" class="form-control">

                               </select>

                            </div>
                          </div>

                          <div class="col">
                           <div class="input-group mb-1">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Firmante</span>
                            </div>
                               <select id="cmbPersonalFirmante" class="form-control">

                               </select>

                            </div>
                          </div>

                        </div>--%>
                        
     <div class="row">
                          <div class="col">
                           <div class="input-group mb-1">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Desde</span>
                            </div>
                                     <input type="date" name="desde" id="dtFechaInicio" class="form-control"/>


                            </div>
                          </div>
                          <div class="col">
                           <div class="input-group mb-1">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Desde</span>
                            </div>
                                    <input type="date" name="hasta" id="dtFechafin" class="form-control"/>


                            </div>
                          </div>


                                  <div class="col">
                                   <div class="contBoton">

                                    <a href="#" class="btn btn-success btn-icon-split" id="btnFiltrar">
                                        <span class="icon text-white-50">
                                            <i class="fas fa-filter"></i>
                                        </span>
                                        <span class="text">Filtrar</span>
                                    </a>

                                </div>
                                    </div>

                                </div>
                            <div class="row">
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
<%--                                            <th style="font-size:12px;" class="text-center">Código</th>--%>
                                            <th style="font-size:12px;" class="text-center">Nombre</th>
                                            <th style="font-size:12px;" class="text-center">Descripción</th>
                                            <th style="font-size:12px;" class="text-center">Trab. Carga</th>
                                            <th style="font-size:12px;" class="text-center">Fecha Carga</th>
                                            <th style="font-size:12px;" class="text-center">Trab. Firma</th>
                                            <th style="font-size:12px;" class="text-center">Fecha Firma</th>
                                            <th style="font-size:12px;" class="text-center">Cargado</th>
                                            <th style="font-size:12px;" class="text-center">Firmado</th>
                                            <th style="font-size:12px;" class="text-center">Enviar</th>


<%--                                            <th style="font-size:12px;" class="text-center">Estado</th>--%>
                                            
                                        </tr>


                                    </thead>
        
                                    <tbody id="dtTablaDocumentosFirmados">
                                    </tbody>
                                </table>
                            </div>
                            </div>

                        </div>
                    </div>

                </div>



            <div class="modal fade" id="EnvioCorreo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Enviar Correo</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Correo</span>
                            </div>
                            <input type="email" class="form-control" aria-label="Correo" placeholder="Correo" required id="txtCorreo" />
                        </div>

                        </div>
                   </div>
                    <div class="row">
                      <div class="col">
                          <div class="input-group mb-3">
                            <textarea class="form-control" id="Descripcion">

                            </textarea>
                      </div>
                   </div>

             </div>


                    

                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary Registrar" id="btEnviar">Enviar</a>
                </div>
            </div>
        </div>
    </div>
<script src="DocumentosFirmados.aspx.js"></script>

</asp:Content>

