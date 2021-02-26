<%@ Page Title="" Language="C#" MasterPageFile="~/HomeFirmante.Master" AutoEventWireup="true" CodeBehind="Documento.aspx.cs" Inherits="ProyectoFirmaDigital.Documento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                  <div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Documentos Pendientes a Firmar</h6>
                        </div>
                        <div class="card-body">
                            <br>
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th style="font-size:12px" class="text-center">Nombre</th>
                                            <th style="font-size:12px" class="text-center">Descripción</th>
                                            <th style="font-size:12px" class="text-center">Trab. Carga</th>
                                            <th style="font-size:12px" class="text-center">Fecha Carga</th>
                                            <th style="font-size:12px" class="text-center">Documento</th>
                                            <th style="font-size:12px" class="text-center" > Firmar</th>
                                            
                                        </tr>


                                    </thead>
        
                                    <tbody id="dtTablaDocumento">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>

    <div class="modal fade" id="pleaseWaitDialog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header text-center" style="font:bold;">
          <h3>Firmando</h3>
      </div>
      <div class="modal-body">
        <div class="progress" id="submit_progress" style="width:100%">
            <div class="progress-bar progress-bar-success " role="progressbar" aria-valuenow="0" aria-valuemin="0"
                aria-valuemax="100" id="load" style="width:0%;">
                0%
            </div>
        </div>
      </div>
    </div>
  </div>
</div>

    <script src="Documento.aspx.js"></script>
</asp:Content>
