<%@ Page Title="" Language="C#" MasterPageFile="~/HomeCliente.Master" AutoEventWireup="true" CodeBehind="CompraPlan.aspx.cs" Inherits="ProyectoFirmaDigital.CompraPlan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <div class="container-fluid" style="padding-left:0px;padding-right:0px;">
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Compra Plan</h6>
                        </div>
                        <li class="nav-item dropdown no-arrow" style="list-style:none;">
                            <a class="nav-link dropdown-toggle" href="#" id="alertsDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
<%--                                <i class="fas fa-bell fa-fw"></i>--%>
                                                               <i class="fas fa-bell fa-fw"></i>

                                <span class="badge badge-danger  mr-2 d-none d-lg-inline  small">Total firmas Disponibles</span>
                                <span style="color:black;"><span id="txtDisponible">0</span> </span>
                            </a>
                            <!-- Dropdown - Alerts -->

                        </li>
                        <div class="card-body">
                                                       
        <div class="row" id="Plan">


        </div>
        </div>
        </div>
       </div>

<%--    <div class="container-fluid">

    </div>--%>



     <div class="modal fade" id="MetodoPago" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Compra Online</h5>
                </div>
                <div class="modal-body">


                 <div class="row">
                      <div class="col">
                       <div class="input-group">
                         <div class="input-group-prepend">
                          <span class="input-group-text">Marca Tarjeta</span>
                           </div>
                            <select id="cmbTipoPago">
                              <option value="0"></option>

                                <option value="1"> Visa</option>
<%--                                <option value="2"> Mastercard</option>--%>
                                <option value="3"> American Express</option>
                            </select>
                         </div>
                       </div>
                  </div>

                <div class="row">
                      <div class="col">
                       <div class="input-group">
                         <div class="input-group-prepend">
                          <span class="input-group-text">Nro Tarjeta</span>
                           </div>
                              <input type="text" class="form-control" required  id="txtNroTarjeta" >
                         </div>
                       </div>
                  </div>
                 <div class="row">
                      <div class="col">
                       <div class="input-group">
                         <div class="input-group-prepend">
                          <span class="input-group-text">Nombre Titular</span>
                           </div>
                              <input type="text" class="form-control" required  id="txtNombreTarjeta" >
                         </div>
                       </div>
                  </div>
                  <div class="row">
                      <div class="col">
                       <div class="input-group mb-4">
                         <div class="input-group-prepend">
                          <span class="input-group-text">Fecha Vencimiento</span>
                           </div>
                          <select  id="creditCardpayment-card-0Month" name="cardExpirationMonth">
                            <option value="">MM</option>
                              <option value="01">01</option>
                              <option value="02">02</option>
                              <option value="03">03</option>
                              <option value="04">04</option>
                              <option value="05">05</option>
                              <option value="06">06</option>
                              <option value="07">07</option>
                              <option value="08">08</option>
                              <option value="09">09</option>
                              <option value="10">10</option>
                              <option value="11">11</option>
                              <option value="12">12</option>
                          </select> 
                           <select id="creditCardpayment-card-0Year" name="cardExpirationYear">
                               <option value="">AA</option>
                               <option value="21">21</option>
                               <option value="22">22</option>
                               <option value="23">23</option>
                               <option value="24">24</option>
                               <option value="25">25</option>
                               <option value="26">26</option>
                               <option value="27">27</option>
                               <option value="28">28</option>
                               <option value="29">29</option>
                               <option value="30">30</option>
                               <option value="31">31</option>
                               <option value="32">32</option>
                               <option value="33">33</option>
                               <option value="34">34</option>
                               <option value="35">35</option>
                               <option value="36">36</option>
                               <option value="37">37</option>
                               <option value="38">38</option>
                               <option value="39">39</option>
                               <option value="40">40</option>
                               <option value="41">41</option>
                               <option value="42">42</option>
                               <option value="43">43</option>
                               <option value="44">44</option>
                               <option value="45">45</option>
                               <option value="46">46</option>
                               <option value="47">47</option>
                               <option value="48">48</option>
                               <option value="49">49</option>
                               <option value="50">50</option>
                               <option value="51">51</option>
                               <option value="52">52</option>
                               <option value="53">53</option>
                               <option value="54">54</option>
                               <option value="55">55</option>
                               <option value="56">56</option>
                               <option value="57">57</option>
                               <option value="58">58</option>
                               <option value="59">59</option>
                               <option value="60">60</option>
                               <option value="61">61</option>

                           </select>

                       </div>
                       </div>
                      <div class="col-4">
                              <div class="input-group mb-1">
  <div class="input-group-prepend">
    <span class="input-group-text" id="basic-addon2">CVV</span>
  </div>
  <input type="text" class="form-control" required id="txtCvv" maxlength="4">
</div>
                      </div>
                  </div>

                    <div class="row" >
                      <div class="col-6">
                       <div class="input-group">
                         <div class="input-group-prepend">
                          <span class="input-group-text">Total a Pagar</span>
                           </div>
                              <input type="text" class="form-control" required  id="txtTotalPagar" readonly="readonly" >
                         </div>
                       </div>
                  </div>


                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary Registrar" id="btnConfirmarCompra">Pagar</a>

                </div>
            </div>
        </div>
    </div>

    <script src="CompraPlan.aspx.js"></script>
</asp:Content>
