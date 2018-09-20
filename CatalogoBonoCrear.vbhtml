@ModelType Administrador_Corporativo.CatalogoBonoModel

@Code
    ViewData("Title") = "Registrar Bono"
End Code

<div class="modal-content">
    <div class="modal-header">
        <h4 Class="modal-title">@ViewBag.Title</h4>
        <button type="button" Class="close" data-dismiss="modal">&times;</button>
    </div>
    <div>
    @*@Using (Html.BeginForm("CatalogoBonoCrear", "CatalogoBono", FormMethod.Post, New With {.class = "modal-form"}))*@
    <div Class="modal-body" style="height:550px; overflow-y:auto;">
        <div id="smartwizard">
             <ul>
                 <li><a href="#step-1">General<br /><small>Datos Generales</small></a></li>
                 <li><a href="#step-2">Flujo<br /><small>Cronograma de Pagos</small></a></li>
             </ul>

             <div>
                 <div id="step-1" class="">
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.ISIN, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.ISIN, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.ISIN, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.Nemonico, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.Nemonico, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.Nemonico, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div Class="form-group row">
                         @Html.LabelFor(Function(model) model.IDEmisor, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div Class="col-sm-9">
                             @Html.DropDownList("IDEmisor", Nothing, htmlAttributes:=New With {.class = "form-control form-control-sm"})
                             @Html.ValidationMessageFor(Function(model) model.IDEmisor, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.MetodoAmortizacion, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.MetodoAmortizacion, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.MetodoAmortizacion, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.BaseCalculoDcto, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.BaseCalculoDcto, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.BaseCalculoDcto, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.BaseCalculoIC, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.BaseCalculoIC, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.BaseCalculoIC, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.BaseCalculoFlujo, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.BaseCalculoFlujo, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.BaseCalculoFlujo, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.CodCurva, "CodCurva", htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.DropDownList("CodCurva", Nothing, htmlAttributes:=New With {.class = "form-control form-control-sm"})
                             @Html.ValidationMessageFor(Function(model) model.CodCurva, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.FormulaTasa, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.FormulaTasa, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.FormulaTasa, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.CodMoneda, "CodMoneda", htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.DropDownList("CodMoneda", Nothing, htmlAttributes:=New With {.class = "form-control form-control-sm"})
                             @Html.ValidationMessageFor(Function(model) model.CodMoneda, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.FecInicio, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.FecInicio, New With {.htmlAttributes = New With {.class = "form-control form-control-sm", .id = "dtpFechaEmision"}})
                             @Html.ValidationMessageFor(Function(model) model.FecInicio, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.FecVencimiento, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.FecVencimiento, New With {.htmlAttributes = New With {.class = "form-control form-control-sm", .id = "dtpFechaVencimiento"}})
                             @Html.ValidationMessageFor(Function(model) model.FecVencimiento, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.FrecuenciaPago, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.FrecuenciaPago, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.FrecuenciaPago, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.TasaCupon, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.TasaCupon, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.TasaCupon, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.TipoTasa, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.TipoTasa, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.TipoTasa, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.TipoTasaReajuste, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.TipoTasaReajuste, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.TipoTasaReajuste, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.MontoSpreadEmision, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.MontoSpreadEmision, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.MontoSpreadEmision, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.MontoSpreadLiquidez, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.MontoSpreadLiquidez, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.MontoSpreadLiquidez, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.SpreadTasaVar, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.SpreadTasaVar, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.SpreadTasaVar, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.ResetIndex, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.ResetIndex, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.ResetIndex, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.TipoBonoCVG, "CodTipoBonoCVG", htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.DropDownList("CodTipoBonoCVG", Nothing, htmlAttributes:=New With {.class = "form-control form-control-sm"})
                             @Html.ValidationMessageFor(Function(model) model.TipoBonoCVG, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.TipoBonoSBS, "CodTipoBonoSBS", htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.DropDownList("CodTipoBonoSBS", Nothing, htmlAttributes:=New With {.class = "form-control form-control-sm"})
                             @Html.ValidationMessageFor(Function(model) model.TipoBonoSBS, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.ISINSobGDN, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.ISINSobGDN, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.ISINSobGDN, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                     <div class="form-group row">
                         @Html.LabelFor(Function(model) model.Bullet, htmlAttributes:=New With {.class = "control-label col-sm-3 col-form-label col-form-label-sm"})
                         <div class="col-sm-9">
                             @Html.EditorFor(Function(model) model.Bullet, New With {.htmlAttributes = New With {.class = "form-control form-control-sm"}})
                             @Html.ValidationMessageFor(Function(model) model.Bullet, "", New With {.class = "text-danger"})
                         </div>
                     </div>
                 </div>
                 <div id="step-2" class="">
                     @Using Html.BeginForm("FlujoBonoObtener", "CatalogoBono", Nothing, FormMethod.Post, New With {.enctype = "multipart/form-data"})
                     @Html.Raw(ViewBag.Error)

                     @<div>
                         <span>Excel File </span>
                         <br />
                         <input type="file" name="excelfile" value="Examinar" />
                         <br />
                         <input type="submit" value="Import" />
                     </div>

                     @<table class="table table-hover">
                        <tr>
                            <th>ISIN</th>
                            <th>Cupon</th>
                            <th>Vencimiento</th>
                            <th>Pago</th>
                            <th>Fijación</th>
                            <th>Tasa Bono</th>
                            <th>Interes Bono</th>
                            <th>Amortización Bono</th>
                            <th>Flujo Bono</th>
                            <th>Flag Cupon</th>
                        </tr>
                        @code
                            For Each p In ViewBag.Lista
                                @<tr>
                                    <td>@p.Isin</td>
                                    <td>@p.NroCupon</td>
                                    <td>@p.FecFijacion</td>
                                    <td>@p.FecPago</td>
                                    <td>@p.FecVencimiento</td>
                                    <td>@p.TasaCupon</td>
                                    <td>@p.MontoInteres</td>
                                    <td>@p.MontoAmortizacion</td>
                                    <td>@p.MtoFlujoBono</td>
                                    <td>@p.FlgCupon</td>
                                </tr>
                            Next
                        End Code
                    </table>

                            End Using
                 </div>
             </div>
        </div>
    </div>

    <div Class="modal-footer">
        <Button type="submit" Class="btn btn-success">Registrar</Button>
        <Button type="button" Class="btn btn-danger" data-dismiss="modal">Cancelar</Button>
    </div>
    @*End Using*@
    </div>
</div>

<script type="text/javascript">
    $(document).ready(function () {
        $('#smartwizard').smartWizard();
    });
</script>



