Imports System.ComponentModel.DataAnnotations

Public Class CatalogoBonoModel
    <Required(ErrorMessage:="asd")>
    Public Property ISIN As String
    Public Property Nemonico As String
    Public Property IDEmisor As Integer
    Public Property MetodoAmortizacion As String
    Public Property BaseCalculoDcto As String
    Public Property BaseCalculoIC As String
    Public Property BaseCalculoFlujo As String
    Public Property CodCurva As String
    Public Property FormulaTasa As String
    Public Property CodMoneda As String
    Public Property FecInicio As DateTime
    Public Property FecVencimiento As DateTime
    Public Property FrecuenciaPago As String
    Public Property TasaCupon As Double
    Public Property TipoTasa As String
    Public Property TipoTasaReajuste As String
    Public Property MontoSpreadEmision As Double
    Public Property MontoSpreadLiquidez As Double
    Public Property SpreadTasaVar As Double
    Public Property ResetIndex As String
    Public Property TipoBonoCVG As String
    Public Property TipoBonoSBS As String
    Public Property ISINSobGDN As String
    Public Property Bullet As String
    Public Property CodTipoEstado As String
    Public Property CodVertice As String
    Public Property FlgExcluirVector As Boolean
    Public Property FlgTipoPago As Boolean
    Public Property FlgFicticio As Boolean
    Public Property FlgOpcionCall As Boolean
    Public Property FlgProrrateo As Boolean
    Public Property FlgRevisado As Boolean
    Public Property FlgValCir As Boolean
    Public Property FlgVinculado As Boolean
    Public Property FlgBorradoLogico As Boolean
End Class
