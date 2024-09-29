using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class GradientLabel : Label
{
    protected override void OnPaint(PaintEventArgs e)
    {
        // Create a gradient brush to fill the text with a gradient color
        using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.DarkRed, Color.Red, 45F))
        {
            // Define the font and string format for text alignment
            Font font = new Font("Impact", 70F, FontStyle.Bold);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;  // Center text
            format.LineAlignment = StringAlignment.Center;  // Center vertically

            // Draw the gradient-filled text
            e.Graphics.DrawString(this.Text, font, brush, this.ClientRectangle, format);
        }
    }
}