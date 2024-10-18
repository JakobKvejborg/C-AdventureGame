using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace AdventureGame;

public class MusicAndSound
{
    private Random random = new Random();
    private SoundPlayer[] soundPlayers;
    private WindowsMediaPlayer mediaPlayer1, mediaPlayer2;

    // Helper method to load media "sounds/music" from the "sounds" folder
    public string MediaSoundPath(string soundName)
    {
        string soundDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
        return Path.Combine(soundDirectory, soundName);
    }
    // Helper method to load the sounds from the folder "sounds" folder
    public SoundPlayer GetSoundPath(string soundName)
    {
        string soundDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
        return new SoundPlayer(Path.Combine(soundDirectory, soundName));
    }

    public void SetListOfSounds()
    {
        soundPlayers = new SoundPlayer[]
     {
        GetSoundPath("letmehealyou5db.wav"),  // index 0
         GetSoundPath("sword1.wav"),  // index 1
          GetSoundPath("sword2.wav"),
           GetSoundPath("sword3.wav"),
            GetSoundPath("sword4.wav"),
             GetSoundPath("sword5.wav"),  // index 5
              GetSoundPath("sword6.wav"),
               GetSoundPath("sword7.wav"),
        GetSoundPath("act1boss.wav"),
     };
        foreach (var soundPlayer in soundPlayers)
        {
            soundPlayer.Load();
        }
    }

    public void PlayThunderSound()
    {
        try
        {
            mediaPlayer1 = new WindowsMediaPlayer();
            mediaPlayer1.URL = MediaSoundPath("thunder.wav");
            mediaPlayer1.controls.play();
        }
        catch
        {
            throw new FileLoadException("The sound file was not found");
        }
    }

    public void PlayAct1BossSound()
    {
        try
        {
            mediaPlayer2 = new WindowsMediaPlayer(); // play boss sound
            mediaPlayer2.URL = MediaSoundPath("act1boss.wav");
            mediaPlayer2.controls.play();
        }
        catch
        {
            throw new FileLoadException("The sound file was not found");
        }
    }

    public void PlayHealingSound()
    {
        try
        {
            soundPlayers[0].Play();
        }
        catch
        {
            throw new Exception("The sound file was not found");
        }
    }

    public void PlaySwordAttackSound()
    {
        try
        {
            if (random.NextDouble() <= 0.89) // 89% chance to play a sound
            {
                int soundIndex = random.Next(1, 8);
                soundPlayers[soundIndex].Play();
            }
        }
        catch
        {
            throw new Exception("The sound file was not found");
        }
    }
}



