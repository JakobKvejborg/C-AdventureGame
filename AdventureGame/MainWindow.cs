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
    private bool cooldownOnSound;
    public List<Panel> panelsList;
    public int panelsIndex;
    private System.Windows.Forms.Timer hoverTimer;
    private Random random = new Random();
    public bool Act1BossDefeatedFlag = false;
    ImageSetter imageSetter = new ImageSetter();
    MusicAndSound sounds = new MusicAndSound();

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
        panelPopupWeaponRightHand.Hide();
        storyProgress = new StoryProgress(this);
        UpdatePlayerLabels();
        panelTown.Location = new Point(0, 0); // Example: position it at the top-left corner
        panelTown.Size = new Size(400, 300);  // Example: set a proper size to make it visible
        panelTown.BringToFront();
        this.Controls.Add(panelTown);
        comboBoxInventory.DisplayMember = "Name"; // Makes the comboboxInventory only display the item.Name

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

        buttonEquipUnequip.TabStop = false;
        buttonDiscardItem.TabStop = false;
    }

    // This dream method stops a lot of flickering
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams handleParam = base.CreateParams;
            handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
            return handleParam;
        }
    }

    // Preloads images (doesn't do much yet)
    private void PreloadResources()
    {
        Image image = Properties.Resources.healer; // Preload images
        image = Properties.Resources.compass;
        Font font = new Font("Arial", 12); // Preload fonts
    }

    private void HoverTimer_Tick(object? sender, EventArgs e)
    {
        // Hide the panel
        panelPopupWeaponRightHand.Hide();
        // Stop the timer to prevent it from ticking again
        hoverTimer.Stop();
    }

    private void SetInisibleEquippedItemsLabels()
    {
        var posWeapon = labelInvisibleWeaponRightHandEquipped.Parent
            .PointToScreen(labelInvisibleWeaponRightHandEquipped.Location);
        posWeapon = pictureBoxHero.PointToClient(posWeapon);
        labelInvisibleWeaponRightHandEquipped.Parent = pictureBoxHero;
        labelInvisibleWeaponRightHandEquipped.Location = posWeapon;
        labelInvisibleWeaponRightHandEquipped.BackColor = Color.Transparent;
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

    private void UpdatePlayerLabels()
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
            sounds.PlaySwordAttackSound(); // plays the attack sound
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
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Check for specific key presses
        switch (keyData)
        {
            case Keys.Space:
                ButtonAttack(); // Call your attack method
                return true; // Indicate the key was handled
            case Keys.Enter:
                ButtonPlayGame();
                ButtonContinue(); // Call your continue method
                return true;
            case Keys.W:
                ButtonNorth(); // Call your move north method
                return true;
            case Keys.A:
                ButtonWest();
                return true;
            case Keys.S:
                ButtonSouth();
                return true;
            case Keys.D:
                ButtonEast();
                return true;
            case Keys.H:
                ButtonHeal();
                return true;
            default:
                return base.ProcessCmdKey(ref msg, keyData); // Let the base method handle other keys
        }
    }



    private void label2_Click(object sender, EventArgs e)
    {

    }

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

    // This method runs after the entire layout of WinForms is loaded
    private void MainWindow_Load(object sender, EventArgs e)
    {
        pictureBoxTown.Image = imageSetter.GetPictureBoxImage("act1town.png"); // places the "town2.png" into the picturebox
        pictureBoxTown.SizeMode = PictureBoxSizeMode.Zoom; // This will center the image 

        sounds.SetListOfSounds();
        sounds.PlayThunderSound();

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
            Item item = (Item)comboBoxInventory.SelectedItem;
            textBox1.Text = $"You throw away the item {item.Name}.";
            comboBoxInventory.Items.Remove(item);
            //comboBoxInventory.SelectedItem = null;
            //playerState.Player.AddItemToInventory(item);
            playerState.Player.UnequipItem(item, comboBoxInventory);
            UpdatePlayerLabels();
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
        buttonPlayGame.Dispose();
    }

    private void ButtonWest()
    {
        if (StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1, this);
            //SetAct1Backgroundimage();
        }
    }

    private void ButtonEast() // TODO
    {
        if (!Act1BossDefeatedFlag && StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            Encounter.PerformEncounter(monsterContainer.listOfMonsters2, itemContainer.items2, this);
        }
        if (Act1BossDefeatedFlag && StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            Encounter.PerformEncounter(monsterContainer.listOfSnowMonsters1, itemContainer.items2, this);
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
        if (StoryProgress.playerIsInTown == true && !Act1BossDefeatedFlag)
        {
            panelTown.Hide();
            panelEncounter.Show();
            sounds.PlayAct1BossSound();
            // Subscribe to the EncounterCompleted event
            //Encounter.EncounterCompleted += OnEncounterCompleted;
            Encounter.EncounterCompleted += OnAct1BossDefeated;

            Encounter.PerformEncounter(monsterContainer.listOfMonstersBossAct1, itemContainer.items2, this);
        }
        else
        {
            // act 2 boss logic here
        }
    }

    private void OnAct1BossDefeated(object sender, EventArgs e)
    {
        Act1BossDefeatedFlag = true;
        storyProgress.StoryState = 8; // Go to case 8.

        // Unsubscribe from the event to avoid multiple invocations
        Encounter.EncounterCompleted -= OnAct1BossDefeated;
    }

    public void SetAct2Backgroundimage()
    {
        Act1BossDefeatedFlag = true; // Set the defeated flag
        BackgroundImage = imageSetter.GetPictureBoxImage("act2background.png");
    }

    public void SetAct1TownBackgroundimage() // TODO delete
    {
        BackgroundImage = imageSetter.GetPictureBoxImage("act1town.png");
    }

    public void SetAct1Backgroundimage() // TODO delete
    {
        BackgroundImage = imageSetter.GetPictureBoxImage("castle.png");
    }

    private void labelCompassS_Click(object sender, EventArgs e)
    {
        ButtonSouth();
    }

    private void ButtonSouth()
    {
        if (!Act1BossDefeatedFlag)
        {
            txtBox_Town.Text = "You cannot turn back now. You must press on, your destiny awaits.";
        }
    }

    private void buttonHeal_Click(object sender, EventArgs e)
    {
        ButtonHeal();
    }

    private async void ButtonHeal()
    {
        if (StoryProgress.playerIsInTown)
        {
            if (playerState.Player.GoldInPocket >= Player.priceToHeal)
            {
                playerState.Player.HealPlayer(playerState);
                labelGoldInPocket.Text = $"Gold: {playerState.Player.GoldInPocket}";
                buttonHeal.Text = $"Heal {Player.priceToHeal.ToString()}G";
                UpdatePlayerHealthBar(); // updates the players health bar after being healed
                txtBox_Town.Text = storyProgress.GetHealingText();
            }
            if (!cooldownOnSound)
            {
                sounds.PlayHealingSound();
                cooldownOnSound = true;
                await Task.Delay(5000);
                cooldownOnSound = false;
            }
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
        ShowWeaponRightHandPanel();
    }

    private void ShowWeaponRightHandPanel()
    {
        if (playerState.Player.EquippedItems.ContainsKey(ItemType.WeaponRightHand))
        {
            panelPopupWeaponRightHand.Show();
            hoverTimer.Stop();
        }
    }

    private void labelWeaponEquipped_MouseLeave(object sender, EventArgs e)
    {
        hoverTimer.Start();
    }

    private void buttonEquipUnequip_Click(object sender, EventArgs e)
    {
        ButtonEquipItems();
    }

    private void ButtonEquipItems()
    {
        if (comboBoxInventory.SelectedItem != null)
        {
            Item item = (Item)comboBoxInventory.SelectedItem;
            if (playerState.Player.Level >= item.LevelRequirement)
            {
                SetItemLabelInfo(item);
                //playerState.Player.AddItemToInventory(item);
                playerState.Player.EquipItem(item, comboBoxInventory);
                UpdatePlayerLabels();
                comboBoxInventory.Items.Remove(item); // removes the equipped item from the combobox
            }
            else
            {
                textBox1.Text = $"You don't meet the level requirement to equip {item.Name}.";
            }
        }
        else
        {
            textBox1.Text = "Select an item to equip.";
        }
    }

    private void SetItemLabelInfo(Item item)
    {
        switch (item.Type)
        {
            case ItemType.WeaponRightHand:
                labelWeaponRightHandName.Text = item.Name;
                labelInfoWeaponRightHandEquipped.Text = item.ToString();
                break;
        }
    }
}
