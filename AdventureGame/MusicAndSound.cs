using System;
using System.IO;
using System.Media;
using WMPLib;

namespace AdventureGame;
// Note that the music started from an object must be stopped from the same object again
public class MusicAndSound
{
    private Random random = new Random();
    private SoundPlayer[] soundPlayers;

    // Separate media players for different music tracks
    private WindowsMediaPlayer act1TownPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer act2TownPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer act1ThunderPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer act2WindPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer bossPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer soundEffectPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer critSoundPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer healingMusicPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer NPCspeechPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer act3WavesPlayer = new WindowsMediaPlayer();
    private WindowsMediaPlayer act4MusicPlayer = new WindowsMediaPlayer();

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
        try
        {
            soundPlayers = new SoundPlayer[]
            {
                GetSoundPath("letmehealyou5db.wav"),  // index 0
                GetSoundPath("sword1.wav"),          // index 1
                GetSoundPath("sword2.wav"),
                GetSoundPath("sword3.wav"),
                GetSoundPath("sword4.wav"),
                GetSoundPath("sword5.wav"),          // index 5
                GetSoundPath("sword6.wav"),
                GetSoundPath("sword7.wav"),
                GetSoundPath("act1boss.wav"), // unused
                GetSoundPath("act2healer.wav"),
                GetSoundPath("smithing.wav"),        // index 10
                GetSoundPath("inventory.wav"),
                GetSoundPath("deathgameover.wav"),
                GetSoundPath("lootitems.wav"),
                GetSoundPath("roarattack.wav"), // index 14
                GetSoundPath("divineattack.wav"),
            };
            foreach (var soundPlayer in soundPlayers)
            {
                soundPlayer.Load();
            }
        }
        catch
        {
            throw new FileLoadException("The sound file was not found");
        }
    }

    public void PlayThunderSound() // This is never used
    {
        PlaySound("thunder.wav", act1ThunderPlayer);
    }

    public void PlayAct2WindMusic()
    {
        PlayMusic("act2wind.wav", act2WindPlayer);
    }

    public void PlayAct1BossSound()
    {
        PlayMusic("act1boss.wav", bossPlayer);
    }

    public void PlayHealingSound()
    {
        PlaySound(0);
    }

    public void PlayAct2HealingSound()
    {
        PlaySound(9);
    }

    public void PlaySwordAttackSound()
    {
        try
        {
            if (random.NextDouble() <= 0.99) // % chance to play a sound
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

    public void PlayAct1TownMusic()
    {
        PlayMusic("act1town.wav", act1TownPlayer);
    }

    public void PlayAct1HealingMusic()
    {
        PlayMusic("letmehealyou5db.wav", healingMusicPlayer);
    }
    public void PlayAct1ArtsTeacher()
    {
        PlayMusic("act1artsteacher.wav", NPCspeechPlayer);
    }

    public void PlayAct1ArtsTeacherNo()
    {
        PlayMusic("act1artsteacherno.wav", NPCspeechPlayer);
    }
    public void PlayAct1WomanCrying()
    {
        PlayMusic("act1quest1womancrying.wav", NPCspeechPlayer);
    }

    public void PlayAct2SmithOffer()
    {
        if (random.Next(0, 2) == 0) // chooses 0 or 1, and if 0 then...
        {
            PlayMusic("act2smithoffer.wav", NPCspeechPlayer);
        }
        else
        {
            PlayMusic("act2smithoffer2.wav", NPCspeechPlayer);
        }
    }
    public void PlayAct2SmithNo()
    {
        PlayMusic("act2smithno.wav", NPCspeechPlayer);
    }

    public void PlaySmithingSound()
    {
        PlaySound(10);
    }

    public void PlayInventorySound()
    {
        PlaySound(11);
    }

    public void PlayDeathGameOverSound()
    {
        PlaySound(12);
    }

    public void PlayLootItemsSound()
    {
        PlaySound(13);
    }
    public void PlayRoarAttackSound()
    {
        PlaySound(14);
    }
    public void PlayDivineAttackSound()
    {
        PlaySound(15);
    }

    public void PlayCoinSound()
    {
        PlayMusic("coin.wav", soundEffectPlayer);
    }

    public void PlayLevelUpSound()
    {
        PlayMusic("levelup.wav", soundEffectPlayer);
    }

    public void PlayBloodLustSound()
    {
        PlayMusic("bloodlust.wav", soundEffectPlayer);
    }

    public void PlayDodgeJabSound()
    {
        PlayMusic("dodgejab.wav", soundEffectPlayer);
    }
    public void PlayRetributionSound()
    {
        PlayMusic("retribution.wav", soundEffectPlayer);
    }

    public void PlayCritSound()
    {
        PlayMusic("crit.wav", critSoundPlayer);
    }

    public void PlayDodgeSound()
    {
        PlayMusic("dodge.wav", soundEffectPlayer);
    }

    public void PlayAct2BossSound()
    {
        PlayMusic("act2boss.wav", soundEffectPlayer);
    }

    public void PlayAct2TownMusic()
    {
        PlayMusic("act2town.wav", act2TownPlayer);
    }

    public void PlayAct4Music()
    {
        PlayMusic("act4.wav", act4MusicPlayer);
    }

    private void PlayMusic(string fileName, WindowsMediaPlayer player)
    {
        try
        {
            // Stop any currently playing music
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.stop();
            }

            player.URL = MediaSoundPath(fileName);
            player.controls.play();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing music {fileName}: {ex.Message}");
        }
    }

    private void PlaySound(int index)
    {
        try
        {
            soundPlayers[index].Play();
        }
        catch
        {
            throw new Exception("The sound file was not found");
        }
    }

    private void PlaySound(string fileName, WindowsMediaPlayer player)
    {
        try
        {
            player.URL = MediaSoundPath(fileName);
            player.controls.play();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing sound {fileName}: {ex.Message}");
        }
    }

    public void PlayAct3Waves()
    {
        PlayMusic("act3waves.wav", act3WavesPlayer);
    }
    public void PlayAct3Boss()
    {
        PlayMusic("act3boss.wav", bossPlayer);
    }

    public void StopAct1TownMusic()
    {
        act1TownPlayer.controls.stop();
    }
    public void StopAct2TownMusic()
    {
        act2TownPlayer.controls.stop();
    }
    public void StopAct2WindSound()
    {
        act2WindPlayer.controls.stop();
    }
    public void StopAct1ThunderSound()
    {
        act1ThunderPlayer.controls.stop();
    }
    public void StopAct3Waves()
    {
        act3WavesPlayer.controls.stop();
    }
    public void StopAct4Music()
    {
        act4MusicPlayer.controls.stop();
    }

    public void MuteAllMusic()
    {
        StopAct1TownMusic();
        StopAct1ThunderSound();
        StopAct2TownMusic();
        StopAct2WindSound();
    }
}
