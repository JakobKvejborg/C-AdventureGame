using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class PlayVideos
{

    private MainWindow _mainWindow;
    public bool IntroVideoIsPlaying { get; set; }
    public bool OneTimeDarknessVideoHasBeenPlayed { get; set; }
    public bool OneTimeFrostfallenVideoHasBeenPlayed { get; set; }

    public PlayVideos(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public string GetVideoPath(string videoName)
    {
        string videoPath = null;
        try
        {
            // Get the base directory of the application
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine the base directory with the relative path to the video
            videoPath = Path.Combine(baseDirectory, "Videos", videoName);

            // Check if the file exists
            if (!File.Exists(videoPath))
            {
                throw new FileNotFoundException("The specified video file does not exist.", videoPath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while retrieving the video file: {ex.Message}");
        }
        return videoPath;
    }

    public void SkipIntroVid()
    {
        _mainWindow.axWMPintroVid.Ctlcontrols.stop();
        _mainWindow.panelIntroVidWMP.Hide();

        // Manually invoke the PlayStateChange event logic with "Media Ended" state (8)
        axWMPintroVid_PlayStateChange(this, new AxWMPLib._WMPOCXEvents_PlayStateChangeEvent(8));
    }

    public void PlayOpeningIntroVid()
    {
        string introVideoPath = GetVideoPath("intromoviehorror.mov");
        _mainWindow.axWMPintroVid.uiMode = "none";
        _mainWindow.axWMPintroVid.URL = introVideoPath;
        _mainWindow.axWMPintroVid.stretchToFit = true; // Stretches video to fit the player
        _mainWindow.axWMPintroVid.Ctlcontrols.play();
        _mainWindow.axWMPintroVid.PlayStateChange += axWMPintroVid_PlayStateChange;
    }

    public void PlayAnyVideo(string videoPath)
    {
        _mainWindow.axWMPAnyVideo.URL = GetVideoPath(videoPath);
        _mainWindow.panelAnyVideo.Show();
        _mainWindow.axWMPAnyVideo.uiMode = "none";
        _mainWindow.axWMPAnyVideo.stretchToFit = true;
        _mainWindow.axWMPAnyVideo.Ctlcontrols.play();
        _mainWindow.axWMPAnyVideo.PlayStateChange += axWMPAnyVid_PlayStateChange;
    }



    private void axWMPAnyVid_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
    {
        // 8 corresponds to the "Media Ended" state in Windows Media Player
        if (e.newState == 8)  // "Media Ended" state
        {
            // Hide the media player when the video finishes
            //_mainWindow.axWMPAnyVideo.Visible = false;
            _mainWindow.panelAnyVideo.Visible = false;
        }
    }

    private void axWMPintroVid_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
    {
        // 8 corresponds to the "Media Ended" state in Windows Media Player
        if (e.newState == 8)  // "Media Ended" state
        {
            // Hide the media player when the video finishes
            _mainWindow.axWMPintroVid.Visible = false;
            _mainWindow.panelIntroVidWMP.Visible = false;
            IntroVideoIsPlaying = false;
        }
    }

}
