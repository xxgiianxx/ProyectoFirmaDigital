<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DocumentosFirmados.aspx.cs" Inherits="ProyectoFirmaDigital.DocumentosFirmados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

              <div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Estadísticos de Documentos Firmados</h6>
                        </div>
                        <div class="card-body">
                         <div class="contenedorcirculos">
                            <div class="circ">
                                <div id="circulo">
                                    <h2>40</h2>
                                </div>
                            </div>

                             <div class="circ2">
                                <div id="circulo2">
                                    <h2>60</h2>
                                </div>
                             </div>
                         </div>

                            <div class="contFiltrar">

                                <div class="contDesde">
                                    <span>Desde</span>
                                    <input type="date" name="desde" value="" />

                                </div>
                                    
                                <div class="contHasta">
                                    <span>Hasta</span>
                                    <input type="date" name="hasta" value="" />

                                </div>
                                
                                <div class="contBoton">

                                    <a href="#" class="btn btn-success btn-icon-split" id="btnFiltrar">
                                        <span class="icon text-white-50">
                                            <i class="fas fa-filter"></i>
                                        </span>
                                        <span class="text">Filtrar</span>
                                    </a>

                                </div>

                            </div>

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
                                            
                                        </tr>


                                    </thead>
        
                                    <tbody id="dtTablaDocumentosFirmados">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>

<script src="DocumentosFirmados.aspx.js"></script>

    <link rel="stylesheet" href="css/estadisticodocumentos.css"/>
</asp:Content>

