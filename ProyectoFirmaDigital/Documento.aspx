<%@ Page Title="" Language="C#" MasterPageFile="~/HomeFirmante.Master" AutoEventWireup="true" CodeBehind="Documento.aspx.cs" Inherits="ProyectoFirmaDigital.Documento" %>
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
                                            <th style="font-size:12px;" class="text-center">Nombre</th>
                                            <th style="font-size:12px;" class="text-center">Descripción</th>
                                            <th style="font-size:12px;" class="text-center">Trab. Carga</th>
                                            <th style="font-size:12px;" class="text-center">Fecha Carga</th>
                                            <th style="font-size:12px;" class="text-center">Trab. Firma</th>
                                            <th style="font-size:12px;" class="text-center">Estado</th>
                                            <th style="font-size:12px;" class="text-center">Documento</th>
                                            <th style="width:0.8%;font-size:12px" class="text-center" > Firmar</th>
                                            
                                        </tr>


                                    </thead>
        
                                    <tbody id="dtTablaDocumento">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>

    <script src="Documento.aspx.js"></script>
</asp:Content>
