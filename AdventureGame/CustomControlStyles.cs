using System.Drawing.Drawing2D;

namespace AdventureGame;

public class CustomControlStyles
{
    public void ApplyCommonEvents(Button button, Action<bool> setIsPressed)
    {
        button.MouseDown += (s, e) =>
        {
            setIsPressed(true);
            button.Invalidate(); // Redraw button
        };

        button.MouseUp += (s, e) =>
        {
            setIsPressed(false);
            button.Invalidate(); // Redraw button
        };

        button.MouseEnter += (s, e) =>
        {
            button.Cursor = Cursors.Hand; // Change cursor to hand on hover
            button.Invalidate(); // Trigger repaint
        };

        button.MouseLeave += (s, e) =>
        {
            setIsPressed(false); // Reset pressed state
            button.Invalidate(); // Trigger repaint
        };
    }

    public void GreyBlackText(Button button)
    {
        button.FlatStyle = FlatStyle.Flat; // Remove default borders
        button.FlatAppearance.BorderSize = 0; // No border

        // Variable to track whether the button is pressed
        bool isPressed = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Adjust appearance based on press state
            var baseColor = isPressed ? Color.FromArgb(80, 80, 80) : Color.FromArgb(100, 100, 100);
            var highlightStart = isPressed ? Color.FromArgb(140, 140, 140) : Color.FromArgb(160, 160, 160);
            var highlightEnd = isPressed ? Color.FromArgb(80, 80, 80) : Color.FromArgb(100, 100, 100);
            var shadowColor = isPressed ? Color.FromArgb(60, 60, 60) : Color.FromArgb(80, 80, 80);

            // Fill the button with a slightly lighter base color
            using (var baseBrush = new SolidBrush(baseColor))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Draw a light gradient at the top for a "highlight" effect
            using (var highlightBrush = new LinearGradientBrush(
                       new Point(0, 0),
                       new Point(0, rect.Height),
                       highlightStart,
                       highlightEnd))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add a dark inner shadow
            using (var shadowPen = new Pen(shadowColor, 2))
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4);
            }

            // Draw a 3D border
            using (var borderPen = new Pen(isPressed ? Color.FromArgb(120, 120, 120) : Color.FromArgb(140, 140, 140)))
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left
            }

            using (var borderPenDark = new Pen(isPressed ? Color.FromArgb(70, 70, 70) : Color.FromArgb(90, 90, 90)))
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom
            }

            // Draw the button text, slightly offset when pressed
            var textOffset = isPressed ? new Point(1, 1) : Point.Empty;
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                new Rectangle(rect.X + textOffset.X, rect.Y + textOffset.Y, rect.Width, rect.Height),
                button.ForeColor, // Text color
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center text
            );
        };

        ApplyCommonEvents(button, (value) => isPressed = value);
    }

    public void BlackButtonWhiteText(Button button)
    {
        button.FlatStyle = FlatStyle.Flat; // Remove default borders
        button.FlatAppearance.BorderSize = 10; // No border

        // Variable to track whether the button is pressed
        bool isPressed = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Adjust appearance based on press state
            var baseColor = isPressed ? Color.FromArgb(70, 70, 70) : Color.FromArgb(80, 80, 80); // Darker base color
            var highlightStart = isPressed ? Color.FromArgb(130, 130, 130) : Color.FromArgb(150, 150, 150);
            var highlightEnd = isPressed ? Color.FromArgb(70, 70, 70) : Color.FromArgb(80, 80, 80);
            var shadowColor = isPressed ? Color.FromArgb(50, 50, 50) : Color.FromArgb(60, 60, 60);

            // Fill the button with a darker base color
            using (var baseBrush = new SolidBrush(baseColor))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Draw a light gradient at the top for a "highlight" effect
            using (var highlightBrush = new LinearGradientBrush(
                     new Point(0, 0),
                     new Point(0, rect.Height),
                     highlightStart,
                     highlightEnd))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add a dark inner shadow
            using (var shadowPen = new Pen(shadowColor, 2))
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4);
            }

            // Draw a 3D border
            using (var borderPen = new Pen(isPressed ? Color.FromArgb(110, 110, 110) : Color.FromArgb(130, 130, 130)))
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left
            }

            using (var borderPenDark = new Pen(isPressed ? Color.FromArgb(60, 60, 60) : Color.FromArgb(70, 70, 70)))
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom
            }

            // Draw the button text in white
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                Color.White, // White text color
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center text
            );
        };

        ApplyCommonEvents(button, (value) => isPressed = value);

    }

    public void Purple(Button button)
    {
        button.FlatStyle = FlatStyle.Flat; // Remove default borders
        button.FlatAppearance.BorderSize = 0; // No border

        // Variable to track whether the button is pressed
        bool isPressed = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Adjust appearance based on press state
            var baseColor = isPressed ? Color.FromArgb(50, 50, 90) : Color.FromArgb(60, 60, 100); // Darker base color when pressed
            var highlightStart = isPressed ? Color.FromArgb(120, 120, 170) : Color.FromArgb(150, 150, 200);
            var highlightEnd = isPressed ? Color.FromArgb(50, 50, 90) : Color.FromArgb(60, 60, 100);
            var shadowColor = isPressed ? Color.FromArgb(40, 40, 60) : Color.FromArgb(50, 50, 70);

            // Fill the button with a darker base color
            using (var baseBrush = new SolidBrush(baseColor))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Draw a light gradient at the top for a "highlight" effect
            using (var highlightBrush = new LinearGradientBrush(
                       new Point(0, 0),
                       new Point(0, rect.Height),
                       highlightStart,
                       highlightEnd))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add a dark inner shadow
            using (var shadowPen = new Pen(shadowColor, 2)) // Dark shadow color
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4); // Inner shadow offset
            }

            // Draw a 3D border
            using (var borderPen = new Pen(Color.FromArgb(90, 90, 150))) // Lighter border color
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left
            }

            using (var borderPenDark = new Pen(Color.FromArgb(30, 30, 60))) // Darker border
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom
            }

            // Draw the button text
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                button.ForeColor, // Text color (white by default)
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center text
            );
        };

        ApplyCommonEvents(button, (value) => isPressed = value);
    }

    public void Orange(Button button)
    {
        button.FlatStyle = FlatStyle.Flat; // Remove default borders
        button.FlatAppearance.BorderSize = 0; // No border

        bool isPressed = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Colors for an adventurous, rustic look
            var baseColor = isPressed ? Color.FromArgb(120, 70, 20) : Color.FromArgb(140, 90, 40); // Earthy brown tones
            var highlightStart = isPressed ? Color.FromArgb(170, 120, 60) : Color.FromArgb(200, 150, 80);
            var highlightEnd = isPressed ? Color.FromArgb(110, 60, 30) : Color.FromArgb(140, 90, 40);
            var shadowColor = isPressed ? Color.FromArgb(90, 50, 20) : Color.FromArgb(110, 60, 30);

            // Fill the button with an earthy gradient for a rustic look
            using (var baseBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, highlightEnd))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Draw a subtle highlight on top to simulate light reflection
            using (var highlightBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, Color.Transparent))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add a soft inner shadow to give the button a worn look
            using (var shadowPen = new Pen(shadowColor, 2))
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4);
            }

            // Draw a rugged border effect
            using (var borderPen = new Pen(isPressed ? Color.FromArgb(90, 60, 20) : Color.FromArgb(120, 80, 30)))
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left
            }

            using (var borderPenDark = new Pen(isPressed ? Color.FromArgb(60, 30, 10) : Color.FromArgb(90, 50, 20)))
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom
            }

            // Draw the button text in a worn, engraved style
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                Color.White, // White text color
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center text
            );
        };

        ApplyCommonEvents(button, (value) => isPressed = value);
    }

    public void Brownish(Button button)
    {
        button.FlatStyle = FlatStyle.Flat; // Remove default borders
        button.FlatAppearance.BorderSize = 0; // No border

        bool isPressed = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Colors for an adventurous, earthy feel
            var baseColor = isPressed ? Color.FromArgb(75, 60, 50) : Color.FromArgb(90, 70, 55); // Deep brown with forest undertones
            var highlightStart = isPressed ? Color.FromArgb(130, 100, 80) : Color.FromArgb(160, 120, 100); // Golden earthy highlights
            var highlightEnd = isPressed ? Color.FromArgb(60, 50, 40) : Color.FromArgb(80, 60, 50); // Slightly darker gradient for depth
            var shadowColor = isPressed ? Color.FromArgb(50, 40, 30) : Color.FromArgb(70, 55, 45); // Earthy shadow color for the worn effect

            // Fill the button with a rich gradient (earthy feel)
            using (var baseBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, highlightEnd))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Add a soft highlight on top for a subtle 3D effect
            using (var highlightBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, Color.Transparent))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add a soft inner shadow for a "worn" effect
            using (var shadowPen = new Pen(shadowColor, 2))
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4);
            }

            // Draw a rugged border with slightly golden edges for the adventure feel
            using (var borderPen = new Pen(isPressed ? Color.FromArgb(90, 75, 60) : Color.FromArgb(120, 100, 80)))
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left
            }

            using (var borderPenDark = new Pen(isPressed ? Color.FromArgb(60, 50, 40) : Color.FromArgb(80, 65, 50)))
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom
            }

            // Draw the button text in ivory white for better contrast with the earth tones
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                Color.Ivory, // Ivory text for a rustic feel
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center text
            );
        };

        // Add mouse events to handle the pressed effect
        button.MouseDown += (s, e) =>
        {
            isPressed = true;
            button.Invalidate(); // Repaint the button
        };

        button.MouseUp += (s, e) =>
        {
            isPressed = false;
            button.Invalidate(); // Repaint the button
        };

        // Hover effect to indicate interactivity
        button.MouseEnter += (s, e) =>
        {
            button.Cursor = Cursors.Hand; // Change cursor to hand on hover
            button.Invalidate(); // Trigger repaint when mouse enters button
        };

        button.MouseLeave += (s, e) =>
        {
            isPressed = false;  // Reset pressed state when mouse leaves
            button.Invalidate(); // Repaint the button
        };
    }

    public void Orange3D(Button button)
    {
        button.FlatStyle = FlatStyle.Standard; // Standard style for 3D effect
        button.FlatAppearance.BorderSize = 0; // Remove default border

        bool isPressed = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Colors for the 3D look
            var baseColor = isPressed ? Color.FromArgb(75, 60, 50) : Color.FromArgb(90, 70, 55); // Deep brown for base
            var highlightStart = isPressed ? Color.FromArgb(130, 100, 80) : Color.FromArgb(160, 120, 100); // Light golden highlights
            var highlightEnd = isPressed ? Color.FromArgb(60, 50, 40) : Color.FromArgb(80, 60, 50); // Darker gradient at the bottom
            var shadowColor = isPressed ? Color.FromArgb(50, 40, 30) : Color.FromArgb(70, 55, 45); // Shadow to add depth

            // Create a gradient for the 3D effect (highlight on top, dark on the bottom)
            using (var baseBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, highlightEnd))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Draw a light highlight on the top edge for a raised effect
            using (var highlightBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, Color.Transparent))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add an inner shadow for a worn-out effect
            using (var shadowPen = new Pen(shadowColor, 2))
            {
                g.DrawRectangle(shadowPen, 3, 3, rect.Width - 6, rect.Height - 6);
            }

            // Draw the raised border to make the button pop out
            using (var borderPen = new Pen(isPressed ? Color.FromArgb(110, 90, 70) : Color.FromArgb(140, 110, 80), 2))
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top edge
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left edge
            }

            // Add a darker border on the right and bottom to simulate depth
            using (var borderPenDark = new Pen(isPressed ? Color.FromArgb(50, 40, 30) : Color.FromArgb(70, 55, 45), 2))
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right edge
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom edge
            }

            // Draw the button text in ivory to maintain contrast with the earthy background
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                Color.Ivory, // Ivory text color
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center the text
            );
        };

        // Add mouse events to handle the pressed effect
        button.MouseDown += (s, e) =>
        {
            isPressed = true;
            button.Invalidate(); // Redraw the button
        };

        button.MouseUp += (s, e) =>
        {
            isPressed = false;
            button.Invalidate(); // Redraw the button
        };

        // Hover effect to indicate interactivity
        button.MouseEnter += (s, e) =>
        {
            button.Cursor = Cursors.Hand; // Change cursor to hand on hover
            button.Invalidate(); // Trigger repaint when mouse enters button
        };

        button.MouseLeave += (s, e) =>
        {
            isPressed = false;  // Reset pressed state when mouse leaves
            button.Invalidate(); // Redraw the button
        };
    }

    public void DarkGrey(Button button)
    {
        button.FlatStyle = FlatStyle.Standard; // Set to standard to give a 3D look
        button.FlatAppearance.BorderSize = 0; // Remove default border

        bool isPressed = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Define colors for the WoW-style button
            var baseColor = isPressed ? Color.FromArgb(50, 50, 50) : Color.FromArgb(60, 60, 60); // Dark, metallic grey
            var highlightStart = isPressed ? Color.FromArgb(110, 110, 110) : Color.FromArgb(120, 120, 120); // Light highlight for top edge
            var highlightEnd = isPressed ? Color.FromArgb(70, 70, 70) : Color.FromArgb(80, 80, 80); // Shadow at the bottom edge
            var borderColor = isPressed ? Color.FromArgb(200, 200, 200) : Color.FromArgb(180, 180, 180); // Golden edge effect
            var shadowColor = isPressed ? Color.FromArgb(40, 40, 40) : Color.FromArgb(50, 50, 50); // Inner shadow color

            // Fill the button with a gradient from dark grey to a slightly lighter grey
            using (var baseBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, highlightEnd))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Add a light highlight on top for a raised effect
            using (var highlightBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, Color.Transparent))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add inner shadow to create depth, making it feel more 3D
            using (var shadowPen = new Pen(shadowColor, 2))
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4);
            }

            // Draw the border to give it a worn metallic look
            using (var borderPen = new Pen(borderColor, 3))
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top edge
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left edge
            }

            // Darker border on the bottom and right for 3D effect
            using (var borderPenDark = new Pen(Color.FromArgb(30, 30, 30), 2))
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right edge
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom edge
            }

            // Draw the button text in white for contrast
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                Color.White, // White text color
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center the text
            );
        };

        ApplyCommonEvents(button, (value) => isPressed = value);
    }

    public void DarkWoWButton(Button button)
    {
        button.FlatStyle = FlatStyle.Standard; // Set to standard to give a 3D look
        button.FlatAppearance.BorderSize = 0; // Remove default border

        bool isPressed = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Define colors for the darker WoW-style button
            var baseColor = isPressed ? Color.FromArgb(30, 30, 30) : Color.FromArgb(40, 40, 40); // Darker metallic grey
            var highlightStart = isPressed ? Color.FromArgb(90, 90, 90) : Color.FromArgb(100, 100, 100); // Lighter highlight for top edge
            var highlightEnd = isPressed ? Color.FromArgb(50, 50, 50) : Color.FromArgb(60, 60, 60); // Dark shadow at the bottom edge
            var borderColor = isPressed ? Color.FromArgb(150, 150, 150) : Color.FromArgb(130, 130, 130); // Dimmed golden edge effect
            var shadowColor = isPressed ? Color.FromArgb(20, 20, 20) : Color.FromArgb(30, 30, 30); // Inner shadow color for depth

            // Fill the button with a gradient from dark grey to a slightly lighter grey
            using (var baseBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, highlightEnd))
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Add a light highlight on top for a raised effect
            using (var highlightBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, rect.Height), highlightStart, Color.Transparent))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add inner shadow to create depth, making it feel more 3D
            using (var shadowPen = new Pen(shadowColor, 2))
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4);
            }

            // Draw the border to give it a worn metallic look
            using (var borderPen = new Pen(borderColor, 3))
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top edge
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left edge
            }

            // Darker border on the bottom and right for 3D effect
            using (var borderPenDark = new Pen(Color.FromArgb(10, 10, 10), 2))
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right edge
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom edge
            }

            // Draw the button text in white for contrast
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                Color.White, // White text color
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center the text
            );
        };

        ApplyCommonEvents(button, (value) => isPressed = value);
    }

    public void CoolRedShadow(Button button)
    {
        button.FlatStyle = FlatStyle.Flat; // Remove default borders
        button.FlatAppearance.BorderSize = 0; // No border

        bool isPressed = false;
        bool isHovered = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Intensity for hover/press effects
            float highlightIntensity = isPressed ? 0.2f : (isHovered ? 0.6f : 0.4f);
            float shadowIntensity = isPressed ? 0.4f : (isHovered ? 0.2f : 0.2f);

            // Fill the button with a base color
            using (var baseBrush = new SolidBrush(Color.FromArgb(60, 60, 60))) // Neutral black-gray base
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Add a light gradient at the top for a highlight effect
            using (var highlightBrush = new LinearGradientBrush(
                       new Point(0, 0),
                       new Point(0, rect.Height),
                       Color.FromArgb(120, (int)(120 * highlightIntensity), (int)(120 * highlightIntensity)), // Lighter gray with intensity
                       Color.FromArgb(60, 60, 60)))
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add a dark inner shadow with dynamic intensity
            using (var shadowPen = new Pen(Color.FromArgb((int)(30 + shadowIntensity * 30), 30, 30), 2)) // Darker shadow with intensity
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4); // Inner shadow offset
            }

            // Draw a 3D border with dynamic intensity
            using (var borderPen = new Pen(Color.FromArgb(80, 80, 80))) // Medium gray for the light border
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left
            }

            using (var borderPenDark = new Pen(Color.FromArgb(40, 40, 40))) // Darker gray for the shadowed border
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom
            }

            // Draw the button text in white
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                Color.FromArgb(255, 47, 47), //button.ForeColor, // Text color, change the color of the text
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center text
            );
        };

        // Add mouse events to handle hover and press effects
        ApplyCommonEvents(button, (value) => isPressed = value);
    }

    public void DarkerRedShadow(Button button)
    {
        button.FlatStyle = FlatStyle.Flat; // Remove default borders
        button.FlatAppearance.BorderSize = 0; // No border

        bool isPressed = false;
        bool isHovered = false;

        // Handle Paint event to draw the button
        button.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = button.ClientRectangle;

            // Intensity for hover/press effects
            float highlightIntensity = isPressed ? 0.2f : (isHovered ? 0.6f : 0.4f);
            float shadowIntensity = isPressed ? 0.4f : (isHovered ? 0.2f : 0.2f);

            // Fill the button with a deeper base color (darker than before)
            using (var baseBrush = new SolidBrush(Color.FromArgb(30, 30, 30))) // Deeper black-gray base
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Add a light gradient at the top for a highlight effect
            using (var highlightBrush = new LinearGradientBrush(
                       new Point(0, 0),
                       new Point(0, rect.Height),
                       Color.FromArgb(120, (int)(120 * highlightIntensity), (int)(120 * highlightIntensity)), // Lighter gray with intensity
                       Color.FromArgb(30, 30, 30)))  // Darker base color for gradient
            {
                g.FillRectangle(highlightBrush, rect);
            }

            // Add a dark inner shadow with dynamic intensity
            using (var shadowPen = new Pen(Color.FromArgb((int)(30 + shadowIntensity * 30), 30, 30), 2)) // Darker shadow with intensity
            {
                g.DrawRectangle(shadowPen, 2, 2, rect.Width - 4, rect.Height - 4); // Inner shadow offset
            }

            // Draw a 3D border with dynamic intensity
            using (var borderPen = new Pen(Color.FromArgb(80, 80, 80))) // Medium gray for the light border
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left
            }

            using (var borderPenDark = new Pen(Color.FromArgb(40, 40, 40))) // Darker gray for the shadowed border
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom
            }

            // Draw the button text in white
            TextRenderer.DrawText(
                g,
                button.Text, // Button's text
                button.Font, // Font
                rect,        // Button rectangle
                button.ForeColor, // Text color
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter // Center text
            );
        };

        ApplyCommonEvents(button, (value) => isPressed = value);
    }

    public void CoolRedShadowComboBox(ComboBox comboBox)
    {
       
        comboBox.DisplayMember = "Name"; // Set the DisplayMember so that only the "Name" property of items is shown
        comboBox.DrawMode = DrawMode.OwnerDrawFixed; // Use custom drawing for items
        comboBox.FlatStyle = FlatStyle.Flat; // Remove default borders
        comboBox.BackColor = Color.FromArgb(60, 60, 60); // Background color
        comboBox.ForeColor = Color.FromArgb(255, 47, 47); // Text color (red)

        bool isDroppedDown = false;

        // Handle the Paint event for the ComboBox to draw a custom border
        comboBox.Paint += (s, e) =>
        {
            var g = e.Graphics;
            var rect = comboBox.ClientRectangle;

            // Fill the ComboBox background
            using (var baseBrush = new SolidBrush(Color.FromArgb(60, 60, 60))) // Neutral black-gray base
            {
                g.FillRectangle(baseBrush, rect);
            }

            // Draw a 3D custom border
            using (var borderPen = new Pen(Color.FromArgb(80, 80, 80))) // Medium gray for the light border
            {
                g.DrawLine(borderPen, 0, 0, rect.Width - 1, 0); // Top
                g.DrawLine(borderPen, 0, 0, 0, rect.Height - 1); // Left
            }

            using (var borderPenDark = new Pen(Color.FromArgb(40, 40, 40))) // Darker gray for the shadowed border
            {
                g.DrawLine(borderPenDark, rect.Width - 1, 0, rect.Width - 1, rect.Height - 1); // Right
                g.DrawLine(borderPenDark, 0, rect.Height - 1, rect.Width - 1, rect.Height - 1); // Bottom
            }

            // Draw the dropdown arrow
            var arrowRect = new Rectangle(rect.Width - 20, rect.Height / 2 - 5, 10, 10);
            using (var arrowBrush = new SolidBrush(Color.FromArgb(255, 47, 47))) // Red arrow
            {
                g.FillPolygon(arrowBrush, new Point[]
                {
                new Point(arrowRect.Left, arrowRect.Top),
                new Point(arrowRect.Right, arrowRect.Top),
                new Point(arrowRect.Left + arrowRect.Width / 2, arrowRect.Bottom)
                });
            }
        };

        // Handle the drawing of each item in the dropdown
        comboBox.DrawItem += (s, e) =>
        {
            e.DrawBackground();
            var g = e.Graphics;
            var rect = e.Bounds;

            // Highlight the selected item or hovered item
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (var selectedBrush = new SolidBrush(Color.FromArgb(255, 47, 47))) // Red background for selection
                {
                    g.FillRectangle(selectedBrush, rect);
                }
            }
            else
            {
                using (var baseBrush = new SolidBrush(Color.FromArgb(60, 60, 60))) // Neutral black-gray base
                {
                    g.FillRectangle(baseBrush, rect);
                }
            }

            // Draw item text
            if (e.Index >= 0) // Ensure index is valid
            {
                string text = comboBox.GetItemText(comboBox.Items[e.Index]); // Get display text
                TextRenderer.DrawText(
                    g,
                    text,
                    comboBox.Font,
                    rect,
                    (e.State & DrawItemState.Selected) == DrawItemState.Selected
                        ? Color.White // White text for selected
                        : Color.FromArgb(255, 47, 47), // Red text for unselected
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left
                );
            }
        };

        // Toggle dropdown state on drop
        comboBox.DropDown += (s, e) => isDroppedDown = true;
        comboBox.DropDownClosed += (s, e) => isDroppedDown = false;
    }
    public void CoolRedShadowListView(ListView listView)
    {
        listView.OwnerDraw = true; // Enable custom drawing
        listView.BackColor = Color.FromArgb(60, 60, 60); // Background color
        listView.ForeColor = Color.FromArgb(255, 47, 47); // Text color
        listView.BorderStyle = BorderStyle.None; // Remove default border
        //listView.Font = new Font("Segoe UI", 12, FontStyle.Semibold); // Custom font

        // Handle the DrawColumnHeader event for column headers
        listView.DrawColumnHeader += (s, e) =>
        {
            using (var brush = new SolidBrush(Color.FromArgb(80, 80, 80))) // Header background
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            using (var pen = new Pen(Color.FromArgb(40, 40, 40))) // Header border
            {
                e.Graphics.DrawRectangle(pen, e.Bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                e.Header.Text,
                e.Font,
                e.Bounds,
                Color.FromArgb(255, 47, 47), // Header text color
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            );
        };

        // Handle the DrawItem event for the entire row
        listView.DrawItem += (s, e) =>
        {
            e.DrawBackground();
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(
                    new SolidBrush(Color.FromArgb(100, 60, 60)), // Selection background
                    e.Bounds
                );
            }

            TextRenderer.DrawText(
                e.Graphics,
                e.Item.Text,
                listView.Font,
                e.Bounds,
                listView.ForeColor, // Item text color
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
            );
        };

        // Handle the DrawSubItem event for sub-items
        listView.DrawSubItem += (s, e) =>
        {
            TextRenderer.DrawText(
                e.Graphics,
                e.SubItem.Text,
                listView.Font,
                e.Bounds,
                listView.ForeColor, // Sub-item text color
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
            );
        };

        // Add a subtle shadow effect for the entire control
        listView.Paint += (s, e) =>
        {
            using (var pen = new Pen(Color.FromArgb(40, 40, 40), 2))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(1, 1, listView.Width - 3, listView.Height - 3));
            }
        };
    }







}
