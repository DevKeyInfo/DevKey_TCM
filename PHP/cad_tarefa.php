<div class="container">

  <form action="cadastros.php" method="post">

    <section class="row" id="cadastro">

      <div class="col-md-2">
        <label>Tarefa:</label>
        <input type="text"  name="trf_nome" class="form-control" minlength="3" required>
      </div>

      <div class="col-md-5">
        <label>Descrição:</label>
        <textarea name="trf_descricao" class="form-control"  minlength="3" required>
        </textarea> 
      </div>

      <div class="col-sm-3">
        <label>Usuário:</label>
        <select class="form-control" name="trf_usu" required>
          <option value=0>
            Responsável pela tarefa
          </option>

          <?php

          $cSQL1 = "SELECT usu.usu_nome, usu.usu_id 
          FROM "       . Config::BD_PREFIX . "usuario usu";

          $oDados = mysqli_query($con, $cSQL1);

          while ($reg = mysqli_fetch_assoc($oDados)){

            echo  "<option value='" . $reg['usu_id'] . "'>" . $reg['usu_nome'] . "</option>";

          }

          ?>

        </select>
      </div>

      <div>
        <br>

        <button class="btn btn-success btn-block ">
          <i class="fa fa-check"></i> 
           
        </button>
        <input type="hidden" name="action" value="cad_trf">
      </div>

    </section>
  </form>
</div>
<br>