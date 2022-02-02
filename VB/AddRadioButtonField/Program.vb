Imports DevExpress.Pdf
Imports System.Drawing

Namespace AddRadioButtonField

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Create an empty document. 
                processor.CreateEmptyDocument("..\..\Result.pdf")
                ' Create graphics and draw a radio button field.
                Using graphics As PdfGraphics = processor.CreateGraphics()
                    DrawRadioButtonGroupField(graphics)
                    ' Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics)
                End Using
            End Using
        End Sub

        Private Shared Sub DrawRadioButtonGroupField(ByVal graphics As PdfGraphics)
            ' Create a radio group field.
            Dim radioGroup As PdfGraphicsAcroFormRadioGroupField = New PdfGraphicsAcroFormRadioGroupField("First Group")
            ' Add the first radio button and specify its location using a RectangleF object.
            radioGroup.AddButton("button1", New RectangleF(0, 0, 20, 20))
            ' Add the second radio button.
            radioGroup.AddButton("button2", New RectangleF(0, 20, 20, 20))
            ' Specify radio group selected index, style and appearance.  
            radioGroup.SelectedIndex = 1
            radioGroup.ButtonStyle = PdfAcroFormButtonStyle.Circle
            radioGroup.Appearance.BackgroundColor = Color.Aqua
            radioGroup.Appearance.BorderAppearance = New PdfGraphicsAcroFormBorderAppearance() With {.Color = Color.Red, .Width = 3}
            ' Add the field to graphics.
            graphics.AddFormField(radioGroup)
        End Sub
    End Class
End Namespace
