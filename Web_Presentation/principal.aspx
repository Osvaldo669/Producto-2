<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="Web_Presentation.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./css/estilos.css" />
    <link rel="icon" href="Imagenes/equipo.jpg" type="image/x-icon" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" integrity="sha384-lKuwvrZot6UHsBSfcMvOkWwlCMgc0TaWr+30HWe3a4ltaBwTZhyTEggF5tJv8tbt" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Poppins" rel="stylesheet" />
    <title>Inventario de computadoras</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <body>
                <header>
                    <label class="labelMenu"><i class="fa fa-bars"></i></label>
                </header>

                <div class="menu">
                    <h1><i class="fa fa-address-card"></i></h1>
                    <nav>
                        <ul>
                            <a href="">
                                <li class="icone1"><i class="fa fa-box"></i></li>
                                <li>Mouse</li>
                            </a>

                            <a href="">
                                <li class="icone2"><i class="fa fa-box"></i></li>
                                <li>Monitor</li>
                            </a>

                            <a href="">
                                <li class="icone3"><i class="fa fa-box"></i></li>
                                <li>Teclado</li>
                            </a>

                            <a href="">
                                <li class="icone4"><i class="fa fa-box"></i></li>
                                <li>Gabinete</li>
                            </a>

                            <a href="">
                                <li class="icone2"><i class="fa fa-box"></i></li>
                                <li>Disco Duro</li>
                            </a>

                            <a href="">
                                <li class="icone3"><i class="fa fa-box"></i></li>
                                <li>Marca</li>
                            </a>

                            <a href="">
                                <li class="icone4"><i class="fa fa-box"></i></li>
                                <li>Componente</li>
                            </a>

                            <a href="">
                                <li class="icone2"><i class="fa fa-box"></i></li>
                                <li>Modelo CPU</li>
                            </a>

                            <a href="">
                                <li class="icone3"><i class="fa fa-box"></i></li>
                                <li>Tipo CPU</li>
                            </a>

                            <a href="">
                                <li class="icone4"><i class="fa fa-box"></i></li>
                                <li>Tipo RAM</li>
                            </a>

                            <a href="">
                                <li class="icone2"><i class="fa fa-box"></i></li>
                                <li>RAM</li>
                            </a>

                            <a href="">
                                <li class="icone3"><i class="fa fa-box"></i></li>
                                <li>Cantidad Disco</li>
                            </a>

                            <a href="">
                                <li class="icone4"><i class="fa fa-box"></i></li>
                                <li>Laboratorio</li>
                            </a>

                            <a href="">
                                <li class="icone2"><i class="fa fa-box"></i></li>
                                <li>Ubicación</li>
                            </a>

                            <a href="">
                                <li class="icone3"><i class="fa fa-box"></i></li>
                                <li>Actualización</li>
                            </a>

                            <a href="">
                                <li class="icone4"><i class="fa fa-box"></i></li>
                                <li>CPU Generico</li>
                            </a>

                            <a href="">
                                <li class="icone2"><i class="fa fa-box"></i></li>
                                <li>Computadora Final</li>
                            </a>
                        </ul>

                        <ul>
                            <a href="">
                                <li class="icone5"><i class="fa fa-lightbulb"></i></li>
                                <li>Ayuda</li>
                            </a>

                            <a href="">
                                <li class="icone6"><i class="fa fa-cog"></i></li>
                                <li>Configuraciones</li>
                            </a>

                            <a href="">
                                <li class="icone7"><i class="fa fa-comment"></i></li>
                                <li>Comentarios</li>
                            </a>

                            <a href="">
                                <li class="icone8"><i class="fa fa-angle-double-left"></i></li>
                                <li>Salir</li>
                            </a>
                        </ul>
                    </nav>
                </div>

                <p class="content">
                    Pagina <i class="fa fa-chevron-right"></i> Principal <span><i class="fa fa-grin-hearts"></i></span>
                </p>

                <div class="opacMenu"></div>
                <!--  Jquery  -->
                <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
                <script>

                    $(document).ready
                        (
                            function () {
                                $('.labelMenu').click
                                    (
                                        function () {
                                            $('.menu').css('left', 0);
                                            $('.opacMenu').fadeIn();
                                        }
                                    )

                                $('.opacMenu').click
                                    (
                                        function () {
                                            $('.menu').css('left', '-205px');
                                            $('.opacMenu').fadeOut();
                                        }
                                    )
                            }
                        )
                </script>
            </body>
        </div>
    </form>
    <!-- CSS only -->
       <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous"/>
    <!-- JavaScript Bundle with Popper -->
       <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
</body>
</html>
