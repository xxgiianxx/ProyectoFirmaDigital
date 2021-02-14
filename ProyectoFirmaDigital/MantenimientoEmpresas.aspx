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
<script src="MantenimientoEmpresas.aspx.js"></script>

</asp:Content>

