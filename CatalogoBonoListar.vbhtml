@ModelType List(Of Administrador_Corporativo.CatalogoBonoXEmisorModel)

@Code
    ViewData("Title") = "CatalogoBonoListar"
End Code

<div>
    <h2>Catálogo de Bonos</h2>
    @Html.ActionLink("Registrar Bono", "CatalogoBonoCrear", "CatalogoBono", Nothing, New With {.class = "btn btn-small btn-info registrar-bono"})
</div>

<div class="modal fade" id="registrar-bono" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div id="registrar-bono-container" class="modal-dialog modal-lg"></div>
</div>

<div>
<table id="dtBonosListar" class="table table-striped table-bordered" style="width:100%">
    <thead>
        <tr>
            <th class="th-sm">
                ISIN
            </th>
            <th class="th-sm">
                Nemonico
            </th>
            <th class="th-sm">
                Emisor
            </th>
            <th class="th-sm">
                Acciones
            </th>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model
            @<tr>
                <td>
                    @item.ISIN
                </td>
                <td>
                    @item.Nemonico
                </td>
                <td>
                    @item.Emisor
                </td>

                <td>
                    @Html.ActionLink("Edit", "CatalogoBonoEditar", New With {.id = item.ISIN}) |
                    @Html.ActionLink("Details", "CatalogoBonoDetalles", New With {.id = item.ISIN}) |
                    @Html.ActionLink("Delete", "CatalogoBonoEliminar", New With {.id = item.ISIN})
                </td>
            </tr>
        Next
    </tbody>

</table>
</div>

<script type="text/javascript">
    $(function () {
        $('.registrar-bono').click(function () {
            var id = $(this).attr('id');

            $('#registrar-bono-container').load(this.href + '/' + id, function () {
                $('#registrar-bono').modal({
                    backdrop: 'static',
                    keyboard: true
                }, 'show');
                bindForm(this);
            });
            return false;
        });
    });

    function bindForm(dialog) {
        $('form', dialog).submit(function () {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),

            });
            return false;
        });
    }
</script>