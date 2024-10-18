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
    private WindowsMediaPlayer mediaPlayer1, mediaPlayer2;
    private bool cooldownOnSound;
    public List<Panel> panelsList;
    public int panelsIndex;
    private System.Windows.Forms.Timer hoverTimer;
    private Random random = new Random();
    private bool Act1BossDefeatedFlag = false;

    public MainWindow()
    {
        InitializeComponent();
        this.DoubleBuffered = true; // helps flickering
        playerState = new PlayerState();
        panelsList = new List<Panel>();
        panelMonster.Hide();
        panelEncounter.Hide();
        panelTown.Hide();
        panelGameOver.Hide();
        pictureBoxHero.Hide();
        panelPopupPanel.Hide();
        SetTownPictureBoxImage(); // places the "town.png" into the picturebox
        storyProgress = new StoryProgress(this);
        InitializePlayerLabels();
        panelTown.Location = new Point(0, 0); // Example: position it at the top-left corner
        panelTown.Size = new Size(400, 300);  // Example: set a proper size to make it visible
        panelTown.BringToFront();
        this.Controls.Add(panelTown);

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
        SetInisibleEquippedItemsLabels();

        // Set how long equipped items info panels should be shown after mousehover
        hoverTimer = new System.Windows.Forms.Timer();  // Create the timer instance
        hoverTimer.Interval = 500;
        hoverTimer.Tick += HoverTimer_Tick;

    }

    private void HoverTimer_Tick(object? sender, EventArgs e)
    {
        // Hide the panel
        panelPopupPanel.Hide();
        // Stop the timer to prevent it from ticking again
        hoverTimer.Stop();
    }

    private void SetInisibleEquippedItemsLabels()
    {
        var posWeapon = labelWeaponEquipped.Parent.PointToScreen(labelWeaponEquipped.Location);
        posWeapon = pictureBoxHero.PointToClient(posWeapon);
        labelWeaponEquipped.Parent = pictureBoxHero;
        labelWeaponEquipped.Location = posWeapon;
        labelWeaponEquipped.BackColor = Color.Transparent;
    }

    private void EnterTown()
    {
        if (StoryProgress.playerIsInTown)
        {
            panelTown.Show(); // Show the town panel when player enters the town
            panelEncounter.Hide(); // Hide other panels if necessary
            textBox1.Text = "Welcome to the Town!";
        }
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
        if (!isAttackOnCooldown && Encounter.Monster != null)
        {
            isAttackOnCooldown = true;
            Encounter.PlayerAttacks(playerState, this);
            CheckIfMonsterIsDead();
            PlaySwordAttackSound(); // plays the attack sound
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
            case Keys.S:
                ButtonSouth();
                break;
            case Keys.W:
                ButtonNorth();
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
        soundPlayers = new SoundPlayer[]
       {
        new SoundPlayer("letmehealyou5db.wav"),  // index 0
        new SoundPlayer("sword1.wav"),  // index 1
         new SoundPlayer("sword2.wav"),
          new SoundPlayer("sword3.wav"),
           new SoundPlayer("sword4.wav"),
            new SoundPlayer("sword5.wav"), // 5
             new SoundPlayer("sword6.wav"),
        new SoundPlayer("act1boss.wav"),
       };
        foreach (var soundPlayer in soundPlayers)
        {
            soundPlayer.Load();
        }
        mediaPlayer1 = new WindowsMediaPlayer();
        mediaPlayer1.URL = "thunder.wav";
        mediaPlayer1.controls.play();

        panelsList.Add(panelEncounter);
        panelsList.Add(panelStartScreen);
        panelsList.Add(panelGameOver);
        panelsList.Add(panelTown);
        panelsList[panelsIndex].BringToFront();
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
        panelStartScreen.Hide();
        panelEncounter.Show();
        btn_continue.Focus();
    }

    private void ButtonWest()
    {
        if (StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1, this);
            btn_continue.Focus();
        }
    }

    private void ButtonEast()
    {
        if (StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            Encounter.PerformEncounter(monsterContainer.listOfMonsters2, itemContainer.items2, this);
            btn_continue.Focus();
        }
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        ButtonContinue();
    }

    private void ButtonContinue()
    {
        storyProgress.ProgressStory();
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
        if (StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            mediaPlayer2 = new WindowsMediaPlayer(); // play boss sound
            mediaPlayer2.URL = "act1boss.wav";
            mediaPlayer2.controls.play();
            soundPlayers[7].Play(); 
            Encounter.PerformEncounter(monsterContainer.listOfMonstersBossAct1, itemContainer.items2, this);
            btn_continue.Focus();
        }
        Act1BossDefeatedFlag = true;
        btn_continue.Focus();
        
    }

    private void labelCompassS_Click(object sender, EventArgs e)
    {
        ButtonSouth();
    }

    private void ButtonSouth()
    {
        txtBox_Town.Text = "You cannot turn back now. You must press on, your destiny awaits.";
        btn_continue.Focus();
    }

    private void buttonHeal_Click(object sender, EventArgs e)
    {
        ButtonHeal();
    }

    private async void ButtonHeal()
    {
        if (StoryProgress.playerIsInTown)
        {
            playerState.Player.HealPlayer(playerState);
            labelGoldInPocket.Text = $"Gold: {playerState.Player.GoldInPocket}";
            buttonHeal.Text = $"Heal {Player.priceToHeal.ToString()}G";
            UpdatePlayerHealthBar(); // updates the players health bar after being healed
            if (!cooldownOnSound)
            {
                PlayHealingSound();
                cooldownOnSound = true;
                await Task.Delay(5000);
                cooldownOnSound = false;
            }
        }
    }

    private void PlayHealingSound()
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

    private void PlaySwordAttackSound()
    {
        try
        {
            if (random.NextDouble() <= 0.85) // 80% chance to play a sound
            {
                int soundIndex = random.Next(1, 7);
                soundPlayers[soundIndex].Play();
            }
        }
        catch
        {
            throw new Exception("The sound file was not found");
        }
    }

    private void btn_Continuetown_Click(object sender, EventArgs e)
    {
        ButtonContinue();
    }

    private void labelWeaponEquipped_MouseHover(object sender, EventArgs e)
    {
    }

    private void labelWeaponEquipped_MouseEnter(object sender, EventArgs e)
    {
        panelPopupPanel.Show();
        hoverTimer.Stop();
    }

    private void labelWeaponEquipped_MouseLeave(object sender, EventArgs e)
    {
        hoverTimer.Start();
    }
}
