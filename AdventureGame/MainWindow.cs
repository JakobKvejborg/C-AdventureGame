using AdventureGame.Properties;
using Microsoft.VisualBasic.Devices;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Media;

namespace AdventureGame;

public partial class MainWindow : Form
{

    private PlayerState playerState;
    private bool isAttackOnCooldown;
    private MonsterContainer monsterContainer = new MonsterContainer();
    private ItemContainer itemContainer = new ItemContainer();
    private StoryProgress storyProgress;

    public MainWindow()
    {
        InitializeComponent();
        //this.BackColor = Color.FromArgb(80, 80, 90); // sets the color of the window to black
        this.DoubleBuffered = true; // helps flickering
        playerState = new PlayerState();
        panelMonster.Visible = false;
        panelEncounter.Visible = false;
        panelTown.Visible = false;
        panelGameOver.Visible = false;
        SetTownPictureBoxImage(); // places the "town.png" into the picturebox
        storyProgress = new StoryProgress(this);
        InitializePlayerLabels();

        // Event that listens for player levelup
        playerState.Player.LevelUpEvent += OnPlayerLevelUp;

        buttonPlayGame.MouseEnter += buttonPlayGame_MouseEnter;
        buttonPlayGame.MouseLeave += buttonPlayGame_MouseLeave;


        // Method to make the Game Title change colors slowly
        FadeTitle();

        this.KeyPreview = true;
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
            var resourceName = "town.png";
            var resourcePath = Path.Combine(assembly, "Images", resourceName);// $"AdventureGame.Images.{resourceName}";

            return Image.FromFile(resourcePath);
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show("Image file not found.");
            return null;
        }
    }

    public static async Task ShakeControl(Control control, int duration = 100, int shakeAmount = 5)
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
    }


    private void PlayIntroSound()
    {
        SoundPlayer sound = new SoundPlayer("thunder.wav");
        sound.Play();
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
        //      Setting the progress bar and label player health
        int currentHealth = playerState.Player.CurrentHealth;
        int maxHealth = playerState.Player.MaxHealth;

        progressBarPlayerHP.Maximum = maxHealth;
        progressBarPlayerHP.Value = currentHealth;
        labelPlayerHP.Text = $"HP: {currentHealth}/{maxHealth}";

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


    private void progressBar1_Click(object sender, EventArgs e)
    {

    }

    private async void btn_attack_Click(object sender, EventArgs e)
    {
        Encounter.PlayerAttacks(playerState, this);
        MonsterIsDead();

        await ShakeControl(pictureBoxMonster1);

        btn_attack.Enabled = false;
        await Task.Delay(500);
        btn_attack.Enabled = true;

    }

    private void MonsterIsDead()
    {
        Encounter.MonsterIsDefeated(playerState, this);
        if (Encounter.Monster == null) // This is wrong for sure
        {
            Encounter.PlayerFindsItemFromMonster(playerState, this);
        }

    }

    // This method lets the player use the buttons by pressing a key instead
    protected override async void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (e.KeyCode == Keys.Space && !isAttackOnCooldown)
        {
            isAttackOnCooldown = true;
            btn_attack_Click(this, EventArgs.Empty);
            e.SuppressKeyPress = true;
            btn_attack.Enabled = false;
            await Task.Delay(200);
            btn_attack.Enabled = true;

            isAttackOnCooldown = false;
        }


        if (e.KeyCode == Keys.Enter)
        {
            //button1_Click_1(this, EventArgs.Empty);
            //e.SuppressKeyPress = true;
            ButtonContinue();
        }

        if (e.KeyCode == Keys.A)
        {
            buttonWest_Click(this, EventArgs.Empty);
        }


    }


    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        PlayIntroSound();
    }

    private void label2_Click_1(object sender, EventArgs e)
    {

    }

    private void buttonDiscardItem_Click(object sender, EventArgs e)
    {
        {
            if (comboBoxInventory.SelectedItem != null)
            {
                // Remove the selected item
                textBox1.Text = $"You throw away the item {comboBoxInventory.SelectedItem.ToString()}.";
                comboBoxInventory.Items.Remove(comboBoxInventory.SelectedItem);
                comboBoxInventory.SelectedItem = null;

            }
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

    private void buttonSouth_Click(object sender, EventArgs e)
    {

    }

    private void buttonWest_Click(object sender, EventArgs e)
    {
        ButtonWest();
    }

    private void ButtonWest()
    {
        panelTown.Visible = false;
        if (StoryProgress.townEncountersEnabled == true)
        {
            Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items2, this);
        }
    }

    private void buttonNorth_Click(object sender, EventArgs e)
    {

    }

    private void buttonEast_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        ButtonContinue();
    }

    private void ButtonContinue()
    {
        storyProgress.ProgressStory(textBox1);
    }
}
