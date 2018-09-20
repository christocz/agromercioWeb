Imports System.Web.Mvc
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Data.Entity
Imports System.Net
Imports ClosedXML.Excel

Namespace Controllers
    Public Class CatalogoBonoController
        Inherits Controller

        Private db As New BD_RRMMEntities

        Function CatalogoBonoListar() As ActionResult

            Dim result = db.CatalogoBono.Include(Function(c) c.MA_Emisor).Where(Function(c) c.FlgBorradoLogico = False).ToList()
            Dim ListaBono As New List(Of CatalogoBonoXEmisorModel)

            For Each item In result
                Dim Bono As New CatalogoBonoXEmisorModel
                Bono.ISIN = item.ISIN
                Bono.Nemonico = item.Nemonico
                Bono.Emisor = item.MA_Emisor.Emisor
                ListaBono.Add(Bono)
            Next

            Return View(ListaBono)
        End Function

        Function CatalogoBonoCrear() As ActionResult
            ViewBag.IDEmisor = New SelectList(db.MA_Emisor, "IDEmisor", "Emisor")
            ViewBag.CodCurva = New SelectList(db.MA_Curva, "CodCurva", "Curva")
            ViewBag.CodMoneda = New SelectList(db.MA_Moneda, "CodMoneda", "Moneda")
            ViewBag.CodTipoBonoCVG = New SelectList(db.TipoBonoCVG, "CodTipoBonoCVG", "DesTipoBonoCVG")
            ViewBag.CodTipoBonoSBS = New SelectList(db.TipoBonoSBS, "CodTipoBonoSBS", "DesTipoBonoSBS")

            Return PartialView("CatalogoBonoCrear")
        End Function

        <HttpPost>
        Function CatalogoBonoCrear(ByVal Bono As CatalogoBonoModel) As ActionResult
            If ModelState.IsValid Then
                Dim bon As New CatalogoBono

                bon.ISIN = Bono.ISIN
                bon.Nemonico = Bono.Nemonico
                bon.IDEmisor = Bono.IDEmisor
                bon.MetodoAmortizacion = Bono.MetodoAmortizacion
                bon.BaseCalculoDcto = Bono.BaseCalculoDcto
                bon.BaseCalculoIC = Bono.BaseCalculoIC
                bon.BaseCalculoFlujo = Bono.BaseCalculoFlujo
                bon.CodCurva = Bono.CodCurva
                bon.FormulaTasa = Bono.FormulaTasa
                bon.CodMoneda = Bono.CodMoneda
                bon.FecInicio = Bono.FecInicio
                bon.FecVencimiento = Bono.FecVencimiento
                bon.FrecuenciaPago = Bono.FrecuenciaPago
                bon.TasaCupon = Bono.TasaCupon
                bon.TipoTasa = Bono.TipoTasa
                bon.TipoTasaReajuste = Bono.TipoTasaReajuste
                bon.MontoSpreadEmsion = Bono.MontoSpreadEmision
                bon.MontoSpreadLiquidez = Bono.MontoSpreadLiquidez
                bon.SpreadTasaVar = Bono.SpreadTasaVar
                bon.ResetIndex = Bono.ResetIndex
                bon.TipoBonoCVG = Bono.TipoBonoCVG
                bon.TipoBonoSBS = Bono.TipoBonoSBS
                bon.ISINSobGDN = Bono.ISINSobGDN
                bon.Bullet = Bono.Bullet
                bon.CodTipoEstado = Bono.CodTipoEstado
                bon.CodVertice = Bono.CodVertice
                bon.FlgExcluirVector = Bono.FlgExcluirVector
                bon.FlgTipoPago = Bono.FlgTipoPago
                bon.FlgFicticio = Bono.FlgFicticio
                bon.FlgOpcionCall = Bono.FlgOpcionCall
                bon.FlgProrrateo = Bono.FlgProrrateo
                bon.FlgRevisado = Bono.FlgRevisado
                bon.FlgValCir = Bono.FlgValCir
                bon.FlgVinculado = Bono.FlgVinculado
                bon.FlgBorradoLogico = Bono.FlgBorradoLogico
                db.CatalogoBono.Add(bon)
                db.SaveChanges()
            End If

            ViewBag.IDEmisor = New SelectList(db.MA_Emisor, "IDEmisor", "Emisor")

            Return RedirectToAction("CatalogoBonoListar", "CatalogoBono")
        End Function

        Dim Lista As List(Of CatalogoBonoFlujo) = New List(Of CatalogoBonoFlujo)

        Function FlujoBonoObtener() As ActionResult
            Dim uploadFile As New UploadFile
            ViewBag.Lista = Lista
            Return View(uploadFile)
        End Function

        <HttpPost>
        Function FlujoBonoObtener(uploadFile As UploadFile) As ActionResult
            If ModelState.IsValid Then
                If uploadFile.ExcelFile.ContentLength > 0 Then
                    If uploadFile.ExcelFile.FileName.EndsWith(".xlsx") Or uploadFile.ExcelFile.FileName.EndsWith(".xls") Then
                        Dim workbook As XLWorkbook
                        Try
                            workbook = New XLWorkbook(uploadFile.ExcelFile.InputStream)
                        Catch ex As Exception
                            ModelState.AddModelError(String.Empty, $"Verificar el archivo. {ex.Message}")
                            ViewBag.CodMoneda = New SelectList(db.MA_Moneda, "CodMoneda", "Moneda")
                            ViewBag.IDEmisor = New SelectList(db.MA_Emisor, "IDEmisor", "Emisor")
                            ViewBag.Lista = Lista
                            Return View("CatalogoBonoCrear")
                        End Try
                        Dim worksheet As IXLWorksheet
                        Try
                            worksheet = workbook.Worksheet("BonoFlujo")
                        Catch ex As Exception
                            ModelState.AddModelError(String.Empty, "Hoja no encontrada.")
                            ViewBag.CodMoneda = New SelectList(db.MA_Moneda, "CodMoneda", "Moneda")
                            ViewBag.IDEmisor = New SelectList(db.MA_Emisor, "IDEmisor", "Emisor")
                            ViewBag.Lista = Lista
                            Return View("CatalogoBonoCrear")
                        End Try
                        worksheet.FirstRow().Delete()
                        'Dim primeraFila As Boolean = False
                        For Each row As IXLRangeRow In workbook.Worksheet(1).RangeUsed.Rows
                            'If primeraFila = False Then
                            'primeraFila = True
                            '                            Else
                            Dim p As CatalogoBonoFlujo = New CatalogoBonoFlujo
                            p.ISIN = CStr(row.Cell(1).Value)
                            p.NroCupon = CInt(row.Cell(2).Value)
                            p.FecFijacion = CDate(row.Cell(3).Value)
                            p.FecPago = CDate(row.Cell(4).Value)
                            p.FecVencimiento = CDate(row.Cell(5).Value)
                            p.TasaCupon = CDbl(row.Cell(6).Value)
                            p.MontoInteres = CDbl(row.Cell(7).Value)
                            p.MontoAmortizacion = CDbl(row.Cell(8).Value)
                            p.MtoFlujoBono = CDbl(row.Cell(9).Value)
                            p.FlgCupon = CStr(row.Cell(10).Value)

                            Lista.Add(p)
                            'End If
                        Next
                    Else
                        ViewBag.Lista = Lista
                        ModelState.AddModelError(String.Empty, "Solo archivos .xlsx y .xls son admitidos.")
                        ViewBag.CodMoneda = New SelectList(db.MA_Moneda, "CodMoneda", "Moneda")
                        ViewBag.IDEmisor = New SelectList(db.MA_Emisor, "IDEmisor", "Emisor")
                        Return View("CatalogoBonoCrear")
                    End If
                Else
                    ViewBag.Lista = Lista
                    ModelState.AddModelError(String.Empty, "No es un archivo válido.")
                    ViewBag.CodMoneda = New SelectList(db.MA_Moneda, "CodMoneda", "Moneda")
                    ViewBag.IDEmisor = New SelectList(db.MA_Emisor, "IDEmisor", "Emisor")
                    Return View("CatalogoBonoCrear")
                End If
            End If
            ViewBag.Lista = Lista
            ViewBag.CodMoneda = New SelectList(db.MA_Moneda, "CodMoneda", "Moneda")
            ViewBag.IDEmisor = New SelectList(db.MA_Emisor, "IDEmisor", "Emisor")
            Return View("CatalogoBonoCrear")
        End Function

    End Class
End Namespace