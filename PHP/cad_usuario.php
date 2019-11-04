<script>

  $(function() {
    $(".btn-toggle").click(function(e) {
      e.preventDefault();
      el = $(this).data('element');
      $(el).toggle();
    });
  });

</script>


<div class="container">
  <h3>
    Devkey - Organograma
  </h3>
  <br>
  <div class="form-group">
    <button type="button" class="btn btn-success btn-toggle" data-element="#cad_usu">
      Adicionar Membro&nbsp;
      <i class="fa fa-plus"></i>
    </button>
  </div>
  <div class="form-group" id="cad_usu" style="display:none;">

    <form action="cadastros.php" method="post">

      <section class="row">       

        <div class="col-md-4">
          <label>Nome:</label>
          <input type="text"  name="usu_nome" class="form-control" minlength="3" required>
        </div>

        <div class="col-md-4">
          <label>E-mail:</label>
          <input type="email" name="usu_email" class="form-control"  minlength="3" required>         
        </div>

        <div>
          <label></label>
          <button class="btn btn-success btn-block">
            <i class="fa fa-check"></i>
          </button>
          <input type="hidden" name="action" value="cad_usu">
        </div>

      </section>
    </form>
  </div>
</div>
<br>

<br>