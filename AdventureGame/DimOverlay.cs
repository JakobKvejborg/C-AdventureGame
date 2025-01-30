namespace AdventureGame;

public class DimOverlay : Form
{

    public DimOverlay()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.BackColor = Color.Black; // Dim color
        this.Opacity = 0.8; // Adjust dim intensity
        this.WindowState = FormWindowState.Maximized;
        this.ShowInTaskbar = false; // Hide from taskbar
        this.Enabled = false; // Disable user interaction

    }

}

