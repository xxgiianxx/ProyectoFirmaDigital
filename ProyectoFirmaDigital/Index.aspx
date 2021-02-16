<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProyectoFirmaDigital.Index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>DevSist</title>
    <link rel="stylesheet" href="css/estilosindex.css"/>
        <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>

<%--    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">--%>

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
        <li><a href="Login.aspx" onclick=" toggleMenu();">Login</a></li>
    </ul>
</header>

<!-- banner -->
<section class="banner" id="banner" style="background: url(img/banner.png);">
    <div class="content">
        <h2>Elija siempre lo mejor</h2>
        <p>Estamos comprometidos siempre con tu seguridad y la de tus clientes.</p>
        <a href="#" class="btn">Menú</a>
    </div>
</section>

<!-- about us -->
<section class="about" id="about">
    <div class="row">
        <div class="col50">
            <h2 class="titulo"><span>S</span>obre Nosotros</h2>
            <p>Somos una empresa peruana dedicada a brindar seguridad y calidad al consumidor mediante firmas digitales a un muy bajo costo.
                <br><br>
                Nuestro objetivo es siempre brindar lo mejor de nosotros al consumidor, satisfaciendo sus necesidades y garantizando la calidad de nuestro servicio.
            </p>
        </div>
        <div class="col50">
            <div class="imgBx">
                <img src="img/img1.jpg">
            </div>
        </div>
    </div>
</section>

<!-- menu -->
<section class="menu" id="menu">
    <div class="titulomenu">
        <h2 class="titulo"><span>M</span>enú</h2>
        <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit.</p>
    </div>
    <div class="content">
        <div class="box">
            <div class="imgBx">
                <img src="img/menu1.jpg" alt="">
            </div>
            <div class="text">
                <h3>Ensalada Especial</h3>
            </div>
        </div>
        <div class="box">
            <div class="imgBx">
                <img src="img/menu2.jpg" alt="">
            </div>
            <div class="text">
                <h3>Sopas</h3>
            </div>
        </div>
        <div class="box">
            <div class="imgBx">
                <img src="img/menu3.jpg" alt="">
            </div>
            <div class="text">
                <h3>Pastas</h3>
            </div>
        </div>
        <div class="box">
            <div class="imgBx">
                <img src="img/menu4.jpg" alt="">
            </div>
            <div class="text">
                <h3>No sé q es :v</h3>
            </div>
        </div>
        <div class="box">
            <div class="imgBx">
                <img src="img/menu5.jpg" alt="">
            </div>
            <div class="text">
                <h3>Sopa</h3>
            </div>
        </div>
        <div class="box">
            <div class="imgBx">
                <img src="img/menu6.jpg" alt="">
            </div>
            <div class="text">
                <h3>Pollo</h3>
            </div>
        </div>
    </div>
    <div class="titulomenu">
        <a href="#" class="btn">Ver Todo</a>
    </div>
</section>

<!-- Chef -->
<section class="chef" id="chef">
    <div class="titulomenu">
        <h2 class="titulo">Nuestros <span>C</span>hef</h2>
        <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit.</p>
    </div>
    <div class="content">
        <div class="box">
            <div class="imgBx">
                <img src="img/chef1.png">
            </div>
            <div class="text">
                <h3>Pedro Miguel Schiaffino</h3>
            </div>
        </div>
        <div class="box">
            <div class="imgBx">
                <img src="img/chef2.png">
            </div>
            <div class="text">
                <h3>Cachetes Acurio</h3>
            </div>
        </div>
        <div class="box">
            <div class="imgBx">
                <img src="img/chef3.png">
            </div>
            <div class="text">
                <h3>Héctor Solís</h3>
            </div>
        </div>
        <div class="box">
            <div class="imgBx">
                <img src="img/chef4.png">
            </div>
            <div class="text">
                <h3>Virgilio Martínez</h3>
            </div>
        </div>
    </div>
</section>

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
<div class="copyright">
    <p>Copyright 2020 <a href="#">VíctorVicente</a>. Todos los derechos reservados</p>
</div>

<script type="text/javascript">
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
</body>
</html>
