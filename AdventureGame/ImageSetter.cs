using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class ImageSetter
{

    private MainWindow _mainWindow;

    public ImageSetter(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public Image GetImagePath(string imageName)
    {


        Image image = null;
        try
        {
            var assembly = AppDomain.CurrentDomain.BaseDirectory;
            var resourcePath = Path.Combine(assembly, "Images", imageName);

            image = Image.FromFile(resourcePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading the image. Possibly the image doesn't exist: {ex.Message}");
        }
        return image;
    }

    // ACT 1 images
    public void SetAct1TownBackgroundimage()
    {
        _mainWindow.panelTown.BackgroundImage = GetImagePath("act1townbackground.png");
    }

    public void SetAct1Backgroundimage()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("castle.png");
    }

    public void SetAct1Quest1BackgroundImage()
    {
        _mainWindow.panelAct1Quest1.BackgroundImage = GetImagePath("act1quest1background.png");
    }
    public void SetAct1Quest1CompletedBackgroundImage()
    {
        _mainWindow.panelAct1Quest1.BackgroundImage = GetImagePath("act1quest1backgroundboyfound.png");
    }

    public void SetAct1HealerPictureBoxImage()
    {
        _mainWindow.pictureBoxHealer.Image = GetImagePath("healer.png");
    }
   

    // ACT 2 images
    public void SetAct2Backgroundimage()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("act2background.png");
        _mainWindow.panelTown.BackgroundImage = GetImagePath("act2background.png");
    }

    public void SetAct2PictureBoxTownImage()
    {
        _mainWindow.pictureBoxTown.Image = GetImagePath("act2town.png");
    }

    public void SetAct2HealerPictureBoxImage()
    {
        _mainWindow.pictureBoxHealer.Image = GetImagePath("act2healer.png");
    }

    public void SetAct2SmithPictureBoxImage()
    {
        _mainWindow.pictureBoxAct2Smith.Image = GetImagePath("act2smith.png");
    }

    // ACT 3 images
    public void SetAct3Backgroundimage()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("act3background.png");
        _mainWindow.panelTown.BackgroundImage = GetImagePath("act3town.png");
    }

    public void SetAct3BossBackgroundimage()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("act3boss.png");
    }

    public void SetAct4BackgroundImage()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("act4background.png");
    }


}
