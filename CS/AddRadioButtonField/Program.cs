using DevExpress.Pdf;
using System.Drawing;

namespace AddRadioButtonField {
    class Program {
        static void Main(string[] args) {
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Create an empty document. 
                processor.CreateEmptyDocument("..\\..\\Result.pdf");

                // Create graphics and draw a radio button field.
                using (PdfGraphics graphics = processor.CreateGraphics()) {
                    DrawRadioButtonGroupField(graphics);

                    // Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics);
                }
            }
        }

        static void DrawRadioButtonGroupField(PdfGraphics graphics) {

            // Create a radio group field.
            PdfGraphicsAcroFormRadioGroupField radioGroup = new PdfGraphicsAcroFormRadioGroupField("First Group");

            // Add the first radio button and specify its location using a RectangleF object.
            radioGroup.AddButton("button1", new RectangleF(0, 0, 20, 20));

            // Add the second radio button.
            radioGroup.AddButton("button2", new RectangleF(0, 20, 20, 20));

            // Specify radio group selected index, style and appearance.  
            radioGroup.SelectedIndex = 1;
            radioGroup.ButtonStyle = PdfAcroFormButtonStyle.Circle;
            radioGroup.Appearance.BackgroundColor = Color.Aqua;
            radioGroup.Appearance.BorderAppearance = new PdfGraphicsAcroFormBorderAppearance() { Color = Color.Red, Width = 3 };

            // Add the field to graphics.
            graphics.AddFormField(radioGroup);
        }
    }
}
