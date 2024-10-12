using AdventureGame.Properties;
using Microsoft.VisualBasic.Devices;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Media;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;
using WMPLib;

namespace AdventureGame;

public partial class MainWindow : Form
{

    private PlayerState playerState;
    private bool isAttackOnCooldown;
    private MonsterContainer monsterContainer = new MonsterContainer();
    private ItemContainer itemContainer = new ItemContainer();
    private StoryProgress storyProgress;
    private SoundPlayer[] soundPlayers;
    private WindowsMediaPlayer mediaPlayer1;

    public MainWindow()
    {
        InitializeComponent();
        this.DoubleBuffered = true; // helps flickering
        playerState = new PlayerState();
        panelMonster.Visible = false;
        panelEncounter.Visible = false;
        panelTown.Visible = false;
        panelGameOver.Visible = false;
        pictureBoxHero.Visible = false;
        SetTownPictureBoxImage(); // places the "town.png" into the picturebox
        storyProgress = new StoryProgress(this);
        InitializePlayerLabels();

        // Event that listens for player levelup
        playerState.Player.LevelUpEvent += OnPlayerLevelUp;

        buttonPlayGame.MouseEnter += buttonPlayGame_MouseEnter;
        buttonPlayGame.MouseLeave += buttonPlayGame_MouseLeave;

        // Make the window non-reziable
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        // Method to make the Game Title change colors slowly
        FadeTitle();

        this.KeyPreview = true;

        SetInvisbleCompassLabels();
    }

    private void SetInvisbleCompassLabels()
    {
        var posW = labelCompassW.Parent.PointToScreen(labelCompassW.Location);
        posW = pictureBoxCompass.PointToClient(posW);
        labelCompassW.Parent = pictureBoxCompass;
        labelCompassW.Location = posW;
        labelCompassW.BackColor = Color.Transparent;
        var posE = labelCompassE.Parent.PointToScreen(labelCompassE.Location);
        posE = pictureBoxCompass.PointToClient(posE);
        labelCompassE.Parent = pictureBoxCompass;
        labelCompassE.Location = posE;
        labelCompassE.BackColor = Color.Transparent;
        var posN = labelCompassN.Parent.PointToScreen(labelCompassN.Location);
        posN = pictureBoxCompass.PointToClient(posN);
        labelCompassN.Parent = pictureBoxCompass;
        labelCompassN.Location = posN;
        labelCompassN.BackColor = Color.Transparent;
        var posS = labelCompassS.Parent.PointToScreen(labelCompassS.Location);
        posS = pictureBoxCompass.PointToClient(posS);
        labelCompassS.Parent = pictureBoxCompass;
        labelCompassS.Location = posS;
        labelCompassS.BackColor = Color.Transparent;
    }

    async void FadeTitle()
    {
        Color startColor = Color.FromArgb(128, 3, 3);
        Color endColor = Color.Red;
        int steps = 50;  // Number of steps for the color transition

        for (int i = 0; i < steps; i++)
        {
            // Interpolate between startColor and endColor
            int r = startColor.R + (endColor.R - startColor.R) * i / steps;
            int g = startColor.G + (endColor.G - startColor.G) * i / steps;
            int b = startColor.B + (endColor.B - startColor.B) * i / steps;

            // Apply the interpolated color to the label
            labelGameTitle.ForeColor = Color.FromArgb(r, g, b);

            // Delay to make the transition smooth
            await Task.Delay(40);
        }
        // Optionally loop the effect
        FadeTitle();
    }

    private Image SetTownImage()
    {
        try
        {
            var assembly = AppDomain.CurrentDomain.BaseDirectory;
            var resourceName = "town2.png";
            var resourcePath = Path.Combine(assembly, "Images", resourceName);// $"AdventureGame.Images.{resourceName}";

            return Image.FromFile(resourcePath);
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show("Image file not found.");
            return null;
        }
    }

    public static async Task ShakeControl(Control control, int duration = 80, int shakeAmount = 5)
    {
        // Store the original location of the control
        var originalLocation = control.Location;
        var rand = new Random();

        int shakeTime = 0;

        // Shake the control for the specified duration
        while (shakeTime < duration)
        {
            // Generate random offsets within the shake range
            int offsetX = rand.Next(-shakeAmount, shakeAmount + 1);
            int offsetY = rand.Next(-shakeAmount, shakeAmount + 1);

            // Apply the shake effect by moving the control
            control.Location = new Point(originalLocation.X + offsetX, originalLocation.Y + offsetY);

            // Redraw the control to apply background
            control.Invalidate();
            control.Update();

            // Wait for a short period of time before the next shake
            await Task.Delay(20);  // Adjust delay for a faster or slower shake

            shakeTime += 20;
        }
        // Restore the control's original position after shaking
        control.Location = originalLocation;
    }

    private void SetTownPictureBoxImage()
    {
        var townImage = SetTownImage();
        if (townImage != null)
        {
            pictureBoxTown.Image = townImage;
            pictureBoxTown.SizeMode = PictureBoxSizeMode.CenterImage; // This will center the image
        }
    }

    private void OnPlayerLevelUp()
    {
        textBox1.Text = $"You have leveled up to level {playerState.Player.Level}!";
        labelExperience.Text = $"Experience: {playerState.Player.Experience}/{10 * (playerState.Player.Level + playerState.Player.Level)}";
        labelLevel.Text = $"Level: {playerState.Player.Level.ToString()}";
        UpdatePlayerHealthBar();
    }


    //private void PlayIntroSound()
    //{
    //    SoundPlayer sound = new SoundPlayer("thunder.wav");
    //    sound.Play();
    //}

    private void buttonPlayGame_MouseEnter(object sender, EventArgs e)
    {
        buttonPlayGame.BackColor = Color.Red;  // Change to bright red on hover
    }

    // Event handler for MouseLeave
    private void buttonPlayGame_MouseLeave(object sender, EventArgs e)
    {
        buttonPlayGame.BackColor = Color.DarkRed;  // Revert to dark red when the mouse leaves
    }

    private void InitializePlayerLabels()
    {
        UpdatePlayerHealthBar();

        // Setting the player stats labels
        labelPlayerDamage.Text = $"Damage: {playerState.Player.Damage}";
        labelPlayerStrength.Text = $"Strength: {playerState.Player.Strength}";
        labelPlayerLifeSteal.Text = $"Lifesteal: {playerState.Player.Lifesteal}";
        labelPlayerArmor.Text = $"Armor: {playerState.Player.Armor}";
        labelPlayerDodge.Text = $"Dodge: {playerState.Player.DodgeChance}%";
        labelGoldInPocket.Text = $"Gold: {playerState.Player.GoldInPocket}";
        labelLevel.Text = $"Level: {playerState.Player.Level}";
        labelExperience.Text = $"Experience: {playerState.Player.Experience}/{10 * (playerState.Player.Level + playerState.Player.Level)}";
    }

    private void UpdatePlayerHealthBar()
    {
        //      Setting the progress bar and label player health
        int currentHealth = playerState.Player.CurrentHealth;
        int maxHealth = playerState.Player.MaxHealth;

        progressBarPlayerHP.Maximum = maxHealth;
        progressBarPlayerHP.Value = currentHealth;
        labelPlayerHP.Text = $"HP: {currentHealth}/{maxHealth}";
    }

    private void progressBar1_Click(object sender, EventArgs e)
    {

    }

    private async void btn_attack_Click(object sender, EventArgs e)
    {
        await ButtonAttack();
    }

    private async Task ButtonAttack()
    {
        if (!isAttackOnCooldown)
        {
            isAttackOnCooldown = true;
            Encounter.PlayerAttacks(playerState, this);
            CheckIfMonsterIsDead();

            await ShakeControl(pictureBoxMonster1);

            btn_attack.Enabled = false;
            await Task.Delay(80); // set this higher for a slower attackrate
            btn_attack.Enabled = true;
            isAttackOnCooldown = false;
        }
    }

    private void CheckIfMonsterIsDead()
    {
        Encounter.MonsterIsDefeated(playerState, this);
        if (Encounter.Monster == null) // This is wrong for sure
        {
            Encounter.PlayerFindsItemFromMonster(playerState, this);
        }
    }

    // This method lets the player use the buttons by pressing a key instead of clicking
    protected override async void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        e.SuppressKeyPress = true; // suppress all key press actions

        switch (e.KeyCode)
        {
            case Keys.Space:
                await ButtonAttack();
                break;
            case Keys.Enter:
                ButtonContinue();
                break;
            case Keys.A:
                ButtonWest();
                break;
            case Keys.D:
                ButtonEast();
                break;
            case Keys.H:
                ButtonHeal();
                break;
        }
    }


    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        //PlayIntroSound();
        soundPlayers = new SoundPlayer[]
       {
        new SoundPlayer("letmehealyou5db.wav"),  // index 0
        //new SoundPlayer("thunder.wav"),  // index 1
                                              // Add other sounds as needed
       };
        foreach (var soundPlayer in soundPlayers)
        {
            soundPlayer.Load();
        }
        //soundPlayers[0].Play(); // plays the intro thunder
        mediaPlayer1 = new WindowsMediaPlayer();
        mediaPlayer1.URL = "thunder.wav";
        mediaPlayer1.controls.play();
    }

    private void label2_Click_1(object sender, EventArgs e)
    {

    }

    private void buttonDiscardItem_Click(object sender, EventArgs e)
    {
        ButtonDiscardItem();
    }

    private void ButtonDiscardItem()
    {
        if (comboBoxInventory.SelectedItem != null)
        {
            // Remove the selected item
            textBox1.Text = $"You throw away the item {comboBoxInventory.SelectedItem.ToString()}.";
            comboBoxInventory.Items.Remove(comboBoxInventory.SelectedItem);
            comboBoxInventory.SelectedItem = null;
        }
    }

    private void buttonPlayGame_Click(object sender, EventArgs e)
    {
        ButtonPlayGame();
    }

    private void ButtonPlayGame()
    {
        panelStartScreen.Visible = false;
        panelEncounter.Visible = true;
        btn_next.Focus();
    }


    private void ButtonWest()
    {
        {
            panelTown.Visible = false;
            if (StoryProgress.playerIsInTown == true)
            {
                Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1, this);
                btn_next.Focus();
            }
        }
    }


    private void ButtonEast()
    {
        panelTown.Visible = false;
        if (StoryProgress.playerIsInTown == true)
        {
            Encounter.PerformEncounter(monsterContainer.listOfMonsters2, itemContainer.items2, this);
        }
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        ButtonContinue();
    }

    private void ButtonContinue()
    {
        storyProgress.ProgressStory(textBox1);
    }

    private void labelCompassW_Click(object sender, EventArgs e)
    {
        ButtonWest();
    }

    private void labelCompassE_Click(object sender, EventArgs e)
    {
        ButtonEast();
    }

    private void labelCompassN_Click(object sender, EventArgs e)
    {
        ButtonNorth();
    }

    private void ButtonNorth()
    {
    }

    private void labelCompassS_Click(object sender, EventArgs e)
    {
        ButtonSouth();
    }

    private void ButtonSouth()
    {
        textBox1.Text = "You cannot turn back now. You have to move forward.";
    }

    private void buttonHeal_Click(object sender, EventArgs e)
    {
        ButtonHeal();
    }

    private void ButtonHeal()
    {
        if (StoryProgress.playerIsInTown)
        {
            playerState.Player.HealPlayer(playerState);
            labelGoldInPocket.Text = $"Gold: {playerState.Player.GoldInPocket}";
            buttonHeal.Text = $"Healing {Player.priceToHeal.ToString()}G";
            UpdatePlayerHealthBar(); // updates the players health bar after being healed
            PlayHealingSound();
        }
    }

    private void PlayHealingSound()
    {
        //SoundPlayer sound = new SoundPlayer("letmehealyou.wav");
        //sound.Play();
        try
        {
            soundPlayers[0].Play();
        }
        catch
        {
            throw new Exception("The sound file was not found");
        }
    }


}
