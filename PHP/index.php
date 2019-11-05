<?php

include_once(dirname(__FILE__) . '/Config.class.php');
include_once(dirname(__FILE__) . '/conexao.php');

?>

<!DOCTYPE html>
<html>
<head>

	<title>DEVKEY - ORGANOGRAMA</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
	<script type="text/javascript" src="JS/jquery-2.1.0.min.js"></script>
	<script type="text/javascript" src="JS/jquery-ui-1.10.4.custom.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="css/estilo.css">

</head>
<body>

	<?php

	include_once(dirname(__FILE__) . '/cad_usuario.php');
	include_once(dirname(__FILE__) . '/cad_tarefa.php');

	?>

	<div class="container" id="conteudo">		

		<?php

			$cSQL = "SELECT * FROM " . Config::BD_PREFIX . "tarefa trf 
			INNER JOIN " . Config::BD_PREFIX . "usuario usu 
			ON trf.trf_usu = usu.usu_id 
			ORDER BY CASE trf_status 
			WHEN 'pen' THEN 0 
			WHEN 'exe' THEN 1 
			WHEN 'fin' THEN 2 END, 
			trf_ordem ASC";

			//die($cSQL);

			$oDados = mysqli_query($con, $cSQL) or die(mysqli_error($con));
			$status_atual='';

			while ($retorno = mysqli_fetch_assoc($oDados)){ 
				$status = $retorno['trf_status'];

				switch ($status) {

					case 'pen':
					if ($status_atual != $status) {	

						$status_atual= $status;

						echo '<ul id="sortable1" class="connectedSortable">';
						
					}

						echo '
						<li class="alert alert-danger item" 
							id="'.$retorno['trf_id'].'">
							Tarefa: ' . $retorno['trf_nome'] . '<br>
							Responsável: '.$retorno['usu_nome'].'<br>
							Descrição: '.$retorno['trf_descricao'].'
						</li>';

					break;

					case 'exe':

					if ($status_atual != $status) {	

						if ($status_atual != '') {
							echo "</ul>";
						}

						$status_atual= $status;

						echo '<ul id="sortable2" class="connectedSortable">';
						
					}

						echo '
						<li class="alert alert-warning item" 
							id="'.$retorno['trf_id'].'">
							Tarefa: ' . $retorno['trf_nome'] . '<br>
							Responsável: '.$retorno['usu_nome'].'<br>
							Descrição: '.$retorno['trf_descricao'].'
						</li>';
						
					break;

					case 'fin':

					if ($status_atual != $status) {	

						if ($status_atual != '') {
							echo "</ul>";
						}

						$status_atual= $status;

						echo '<ul id="sortable3" class="connectedSortable">';
						
					}
						echo '
							<li class="alert alert-success item" 
								id="'.$retorno['trf_id'].'">
								Tarefa: ' . $retorno['trf_nome'] . '<br>
								Responsável: '.$retorno['usu_nome'].'<br>
								Descrição: '.$retorno['trf_descricao'].'
							</li>';

					break;
				}
			}

			if ($status_atual != '') {
				echo "</ul>";
			}

		?>		
		
	</div>
</body>
<script type="text/javascript">

	$(function(){

		$("#sortable1, #sortable2, #sortable3").sortable({
			connectWith: ".connectedSortable",
			placeholder: 'dragHelper',
			scroll: true,
			revert: true,
			cursor: "move",

			update: function(event, ui) {
				var trf_id_list = $(this).sortable('toArray').toString();

				$.ajax({
					url: 'trf_ordenar_item.php',
					type: 'POST',
					data: {trf_id : trf_id_list},
					success: function(data) {

					}
				});
			},

			start: function( event, ui ) {

			},

			receive: function(event, ui) {
				var trf_id_list = $(this).sortable('toArray').toString();
				var receivesort = "[" + this.id + "]";
				//console.log("[" + this.id + "]");
				
				//nome -> ui.item.html
				//sortable id -> "[" + this.id + "]"
				
				//alert("[" + this.id + "] received [" + ui.item.html() + "]");
				
				$.ajax({
					url: 'trf_ordenar_item.php',
					type: 'POST',
					data: {
						trf_status : receivesort,
						trf_id : trf_id_list
					},
					success: function(data) {

						$(document).ready(function(){
							location.reload();
						});
					}
				});
			},

			stop: function( event, ui ) {

			}

		});
	}); 


</script>
</html>