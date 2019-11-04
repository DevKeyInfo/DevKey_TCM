<?php
//CONEXAO COM A BASE DE DADOS
//PARAMETROS DA CONEXAO: SERVIDOR, USUARIO, SENHA, DB
//$GLOBALS["con"];
$con = mysqli_connect(Config::BD_HOST, Config::BD_USER, Config::BD_SENHA, Config::BD_BANCO);
if (mysqli_connect_errno()) {
   echo "Erro ao conectar com o banco de Dados:  " . mysqli_connect_error();
   }

//MODIFICAR A PAGINA DE CODIGO
mysqli_set_charset($con, 'utf8');

?>