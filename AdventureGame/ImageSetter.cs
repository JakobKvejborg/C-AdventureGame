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
        _mainWindow.panelAct1Quest1.BackgroundImageLayout = ImageLayout.Stretch;
    }

    public void SetAct1Quest1CompletedBackgroundImage()
    {
        _mainWindow.panelAct1Quest1.BackgroundImage = GetImagePath("act1quest1backgroundboyfound.png");
        _mainWindow.panelAct1Quest1.BackgroundImageLayout = ImageLayout.Stretch;
    }

    public void SetAct1HealerPictureBoxImage()
    {
        _mainWindow.pictureBoxHealer.Image = GetImagePath("healer.png");
    }
    public void SetHeroLeftWeaponPictureBoxImage()
    {
        _mainWindow.pictureBoxHero.Image = GetImagePath("herolefthand.png");
    }


    // ACT 2 images
    public void SetAct2BackgroundImages()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("act2background.png");
        _mainWindow.panelTown.BackgroundImage = GetImagePath("act2town.png");
    }

    public void SetAct2HealerPictureBoxImage()
    {
        _mainWindow.pictureBoxHealer.Image = GetImagePath("act2healer.png");
    }

    public void SetAct2SmithPictureBoxImage()
    {
        _mainWindow.pictureBoxAct2Smith.Image = GetImagePath("act2smith.png");
    }

    public void SetAct2SmithUpgradedImage()
    {
        _mainWindow.pictureBoxAct2Smith.Image = GetImagePath("act2smithupgraded.png");
    }

    public void SetAct2FrostFallenKingImage()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("frostfallenking.png");
    }

    public void SetAct2IcyCaveImage()
    {
        _mainWindow.panelAct2Q1.BackgroundImage = GetImagePath("act2icytomb.png");
        _mainWindow.panelAct2Q1.BackgroundImageLayout = ImageLayout.Stretch;
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

    public void SetAct3Q1BackgroundImage()
    {
        _mainWindow.panelAct3Q1.BackgroundImage = GetImagePath("act3froggy.png");
        _mainWindow.panelAct3Q1.BackgroundImageLayout = ImageLayout.Stretch;
    }

    public void SetAct3Q1FrogGotLilyImage()
    {
        _mainWindow.panelAct3Q1.BackgroundImage = GetImagePath("act3frogwithlily.png");
        _mainWindow.panelAct3Q1.BackgroundImageLayout = ImageLayout.Stretch;
    }

    // ACT 4 images
    public void SetAct4EncounterBackgroundImage()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("act4background.png");
    }
    public void SetAct4TownBackgroundImage()
    {
        _mainWindow.panelTown.BackgroundImage = GetImagePath("act4town.png");
    }
    public void SetAct4HealerImage()
    {
        _mainWindow.pictureBoxHealer.Image = GetImagePath("act4healer.png");
    }
    public void SetAct4Quest1BackgroundImage()
    {
        _mainWindow.panelAct4Quest1.BackgroundImage = GetImagePath("act4q1background.png");
        _mainWindow.panelAct4Quest1.BackgroundImageLayout = ImageLayout.Stretch;
    }
    public void SetAct4MageImage()
    {
        // No need to hide the picturebox (smith & mage) on mainwindow load because this image is not yet set
        _mainWindow.pictureBoxAct4Mage.Image = GetImagePath("act4mage.png");
    }

    // Act 5
    public void SetAct5IntroImage()
    {
        _mainWindow.panelTown.BackgroundImage = GetImagePath("act5intro.png");
    }

    public void SetAct5TownBackgroundImage()
    {
        _mainWindow.panelTown.BackgroundImage = GetImagePath("act5background.png");
    }

    public void SetAct5EncounterBackground()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("act5encounterbackground.png");
    }

    public void SetAct5SophiaDeath()
    {
        _mainWindow.panelTown.BackgroundImage = GetImagePath("sophiadead.png");
    }

    public void SetAct5SophiaAlive()
    {
        _mainWindow.panelTown.BackgroundImage = GetImagePath("sophiaalive.png");
    }

    public void SetAct5SecretFinalBossImage()
    {
        _mainWindow.panelEncounter.BackgroundImage = GetImagePath("ultimatedarkness.png");
    }

    public void SetXboxControlsLayoutImage()
    {
        _mainWindow.panelXboxControlsLayout.BackgroundImage = GetImagePath("xboxlayout.png");
    }
}
