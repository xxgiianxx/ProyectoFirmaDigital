<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoFirmaDigital.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Prueba</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous"/>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous"/>
    
    <!-- Estilos CSS -->
    <link rel="stylesheet" href="css/estilosplanes.css"/>
</head>
<body>
<!-- navbar -->
<header>
    <a href="index.html" class="logo">Nombre<span>.</span></a>
    <div class="menuToggle" onclick=" toggleMenu();" style="background: url(img/menu.png);"></div>
    <ul class="navigation">
        <li><a href="index.html" onclick=" toggleMenu();">Inicio</a></li>
        <li><a href="#about" onclick=" toggleMenu();">Nosotros</a></li>
        <li><a href="planes.html" onclick=" toggleMenu();">Servicios</a></li>
        <li><a href="#contacto" onclick=" toggleMenu();">Contacto</a></li>
        <li><a href="loginvista.html" onclick=" toggleMenu();">Login</a></li>
    </ul>
</header>

<section class="banner" id="banner">
    <div class="content">
        <h2>Comodidad al alcance de tu bolsillo</h2>
        <p>Descubre nuestros planes adaptados a tus propias necesidades</p>
        <a href="#" class="btn">Menú</a>
    </div>
</section>

<!-- Precios -->

<div class="container">
    <div class="row">
      <div class="col-sm">
        <div class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">Pequeña Empresa</h5>
              <p class="card-text">Incluye 50 firmas</p>
              <h4 class="card-title">30 soles</h4>
              <a href="#" class="btn btn-primary">Comenzar</a>
            </div>
          </div>
      </div>
      <div class="col-sm">
        <div class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">Mediana Empresa</h5>
              <p class="card-text">Incluye 100 firmas</p>
              <h4 class="card-title">55 soles</h4>
              <a href="#" class="btn btn-primary">Comenzar</a>
            </div>
          </div>
      </div>
      <div class="col-sm">
        <div class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">Gran empresa</h5>
              <p class="card-text">Incluye 200 firmas</p>
              <h4 class="card-title">100 soles</h4>
              <a href="#" class="btn btn-primary">Comenzar</a>
            </div>
          </div>
      </div>
    </div>
  </div>


<!-- contacto -->
<section class="contacto" id="contacto" style="background-image: url(img/bg3.jpg);">
    <form action="enviar.php" method="post">
    <div class="titulomenu">
        <h2 class="titulo"><span>C</span>ontacto</h2>
        <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit.</p>
    </div>
    <div class="contactForm">
        <h3>Enviar Mensaje</h3>
        <div class="inputBox">
            <input type="text" name="nombre" id="names" placeholder="Nombre">
        </div>
        <div class="inputBox">
            <input type="text" name="correo" id="email" placeholder="E-Mail">
        </div>
        <div class="inputBox">
            <textarea id="mensaje" name="mensaje" placeholder="Déjanos un mensaje"></textarea>
        </div>
        <div class="inputBox">
            <input type="submit" value="Send" id="btnSend">
        </div>
    </div>
    </form>
</section>

<!-- social-media -->
<section class="socmed">
    <ul class="mediaul">
        <li><a href="https://www.facebook.com/bongout7382" target="blank"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
        <!-- <li><a href=""><i class="fa fa-twitter" aria-hidden="true"></i></a></li> -->
        <li><a href="https://wa.me/51944448506?text=Hola%20quiero%20hacer%20un%20pedido" target="blank"><i class="fa fa-whatsapp" aria-hidden="true"></i></a></li>
        <li><a href="https://www.instagram.com/bongout7382/?hl=es-la" target="blank"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
    </ul>
</section>

<!-- Footer -->
<div class="copyright"/>
</body>
   
</html>
<script>
        window.addEventListener('scroll',function(){
    const header = document.querySelector('header');
    header.classList.toggle("sticky",window.scrollY > 0);
});

function toggleMenu(){
    const menuToggle = document.querySelector('.menuToggle');
    const navigation = document.querySelector('.navigation');
    menuToggle.classList.toggle('active');
    navigation.classList.toggle('active');
}
</script>