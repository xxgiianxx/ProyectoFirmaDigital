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
                                            <th style="font-size:12px;" class="text-center">Razon Social </th>
                                            <th style="font-size:12px;" class="text-center">Ruc</th>
                                            <th style="font-size:12px;" class="text-center">Departamento</th>
                                            <th style="font-size:12px;" class="text-center">Provincia</th>
                                            <th style="font-size:12px;" class="text-center">Distrito</th>
                                            <th style="font-size:12px;" class="text-center">Direccion</th>
                                            <th style="font-size:12px;" class="text-center">Correo</th>
                                            <th style="font-size:12px;" class="text-center">Estado</th>
                                            <th style="font-size:12px;"class="text-center" colspan="2"> Accion</th>

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
</asp:Content>
