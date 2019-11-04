<?php

include_once(dirname(__FILE__) . '/Config.class.php');
include_once(dirname(__FILE__) . '/conexao.php');

if ($_POST['action'] == "cad_trf") {
  cad_trf($con);
}

if ($_POST['action'] == "cad_usu") {
	cad_usu($con);
}

function cad_trf($con) {

  if (isset($_POST['trf_nome']) && ($_POST['trf_descricao']) && ($_POST['trf_usu'])){

    $con->begin_transaction();

    $cSQL = "INSERT INTO " 
    . Config::BD_PREFIX . "tarefa (trf_nome, trf_descricao, trf_usu) VALUES ('" 
    . addslashes($_POST['trf_nome']) . "', '" 
    . addslashes($_POST['trf_descricao']) . "', '" 
    . addslashes($_POST['trf_usu']) . "')";

    $oDados = mysqli_query($con, $cSQL);

    if ($oDados === TRUE) {

      $con->commit();
      header("Location:index.php");

    } else {
      echo '<script>
      document.location.href="index.php";
      alert("Erro: '.mysqli_error($con).'");              	

      </script>';
      $con->rollback();
    }
  } else { 

    if ($_POST['trf_usu'] == 0) {
      echo '<script>
      document.location.href="index.php";
      alert("Selecione o usuário");
      </script>';
    } else {
      echo '<script>
      document.location.href="index.php";
      alert("Não foi possivel cadastrar tarefa!");
      </script>';
    }
  }
} 

function cad_usu($con){

  if (isset($_POST['usu_nome']) && ($_POST['usu_email'])){

    $con->begin_transaction();

    $cSQL = "INSERT INTO " 
    . Config::BD_PREFIX . "usuario (usu_nome, usu_email) VALUES ('" 
    . addslashes($_POST['usu_nome']) . "', '" 
    . addslashes($_POST['usu_email']) . "')";

    $oDados = mysqli_query($con, $cSQL);

    if ($oDados === TRUE) {

      $con->commit();
      header("Location:index.php");

    } else {
      echo '<script>
      document.location.href="index.php";
      alert("Erro: '.mysqli_error($con).'");                

      </script>';
      $con->rollback();
    }
  }
}


?>