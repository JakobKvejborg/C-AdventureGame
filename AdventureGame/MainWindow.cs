using System.Media;
using Color = System.Drawing.Color;
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
    bool IsInventoryOpen { get; set; } = false;
    bool playGameHasBeenPressed { get; set; } = false;

    public MainWindow()
    {
        InitializeComponent();
        this.DoubleBuffered = true; // helps flickering
        playerState = new PlayerState();
        panelsList = new List<Panel>();
        HidePanelsEtc();
        storyProgress = new StoryProgress(this);
        UpdatePlayerLabels();
        panelTown.Location = new Point(0, 0); // Example: position it at the top-left corner
        panelTown.Size = new Size(400, 300);  // Example: set a proper size to make it visible
        panelTown.BringToFront();
        this.Controls.Add(panelTown);
        comboBoxInventory.DisplayMember = "Name"; // Makes the comboboxInventory only display the item.Name
        comboBoxUpgradeItems.DisplayMember = "Name"; // Makes the comboboxInventory only display the item.Name
        MakeHeroBagBackgroundTrulyTransparent(); // this method makes the picturebox HeroBag have an truly invisible background
        MakeInventoryBackgroundTrulyTransparent();

        // Event that listens for player levelup
        playerState.Player.LevelUpEvent += OnPlayerLevelUp;

        buttonPlayGame.MouseEnter += buttonPlayGame_MouseEnter;
        buttonPlayGame.MouseLeave += buttonPlayGame_MouseLeave;

        // Make the window non-reziable
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;

        // Method to make the Game Title change colors slowly
        FadeTitle();
        this.KeyPreview = true; // prevents the buttons from gaining unwanted focus

        SetInvisbleCompassLabels();
        SetInisibleEquippedItemsLabels();

        // Set how long equipped items info panels should be shown after mousehover
        hoverTimer = new System.Windows.Forms.Timer();  // Create the timer instance
        hoverTimer.Interval = 500;
        hoverTimer.Tick += HoverTimer_Tick;
    }

    private void HidePanelsEtc()
    {
        #region Hide panels, buttons, combobox
        panelMonster.Hide();
        panelEncounter.Hide();
        panelTown.Hide();
        panelGameOver.Hide();
        pictureBoxHero.Hide();
        panelPopupWeaponRightHand.Hide();
        panelPopupArmor.Hide();
        panelPopupBoots.Hide();
        panelPopupGloves.Hide();
        comboBoxUpgradeItems.Hide();
        buttonUpgradeItem.Hide();
        pictureBoxHeroBag.Hide();
        pictureBoxInventory.Hide();
        panelInventory.Hide();
        pictureBoxLoot.Hide();
        labelGoldPopup.Hide();
        buttonReturnToTown.Hide();
        #endregion
    }

    private void MakeHeroBagBackgroundTrulyTransparent()
    {
        pictureBoxHero.Controls.Add(pictureBoxHeroBag);
        pictureBoxHeroBag.Location = new Point(120, 170);
        pictureBoxHeroBag.BackColor = Color.Transparent;
    }

    private void MakeInventoryBackgroundTrulyTransparent()
    {
        pictureBoxInventory.Controls.Add(panelInventory);
        panelInventory.Location = new Point(45, 40);
        panelInventory.BackColor = Color.Transparent;
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
        Font font = new Font("Arial", 12); // Preload fonts
    }

    private void HoverTimer_Tick(object? sender, EventArgs e)
    {
        // Hide the panel
        panelPopupWeaponRightHand.Hide();
        panelPopupArmor.Hide();
        panelPopupBoots.Hide();
        panelPopupGloves.Hide();
    }

    #region Invisible labels
    private void SetInisibleEquippedItemsLabels()
    {
        // right weapon
        var posWeapon = labelInvisibleWeaponRightHandEquipped.Parent
            .PointToScreen(labelInvisibleWeaponRightHandEquipped.Location);
        posWeapon = pictureBoxHero.PointToClient(posWeapon);
        labelInvisibleWeaponRightHandEquipped.Parent = pictureBoxHero;
        labelInvisibleWeaponRightHandEquipped.Location = posWeapon;
        labelInvisibleWeaponRightHandEquipped.BackColor = Color.Transparent;
        // armor
        var posArmor = labelInvisibleArmor.Parent
           .PointToScreen(labelInvisibleArmor.Location);
        posArmor = pictureBoxHero.PointToClient(posArmor);
        labelInvisibleArmor.Parent = pictureBoxHero;
        labelInvisibleArmor.Location = posArmor;
        labelInvisibleArmor.BackColor = Color.Transparent;
        // boots
        var posBoots = labelInvisibleBoots.Parent
           .PointToScreen(labelInvisibleBoots.Location);
        posBoots = pictureBoxHero.PointToClient(posBoots);
        labelInvisibleBoots.Parent = pictureBoxHero;
        labelInvisibleBoots.Location = posBoots;
        labelInvisibleBoots.BackColor = Color.Transparent;
        // gloves
        var posGloves = labelInvisibleGloves.Parent
           .PointToScreen(labelInvisibleGloves.Location);
        posGloves = pictureBoxHero.PointToClient(posGloves);
        labelInvisibleGloves.Parent = pictureBoxHero;
        labelInvisibleGloves.Location = posGloves;
        labelInvisibleGloves.BackColor = Color.Transparent;

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
    #endregion


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
        textBox1.AppendText($"\r\nYou have leveled up to level {playerState.Player.Level}!");
        UpdatePlayerLabels();
        UpdatePlayerHealthBar();
        sounds.PlayLevelUpSound();
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
            sounds.PlaySwordAttackSound(); // plays the attack sound
            Encounter.PlayerAttacks(playerState, this);
            Encounter.MonsterIsDefeated(playerState, this); // Checks if the monster is dead
            await ShakeControl(pictureBoxMonster1);

            btn_attack.Enabled = false;
            await Task.Delay(80); // set this higher for a slower attackrate
            btn_attack.Enabled = true;
            isAttackOnCooldown = false;
        }
    }

    private void buttonBloodLust_Click(object sender, EventArgs e)
    {
        ButtonAttack();
    }

    // This method lets the player use the buttons by pressing a key instead of clicking
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Check for specific key presses
        switch (keyData)
        {
            case Keys.Space:
                Task task = ButtonAttack();
                return true;
            case Keys.Enter:
                if (!playGameHasBeenPressed)
                {
                    ButtonPlayGame();
                }
                ButtonContinue();
                HideInventory();
                return true;
            case Keys.W:
                ButtonNorth();
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
            case Keys.E:
                if (IsInventoryOpen) ButtonEquipItems();
                return true;
            case Keys.T:
                if (IsInventoryOpen) ButtonDiscardItem();
                return true;
            case Keys.I:
                if (pictureBoxHero.Visible == true) if (IsInventoryOpen) HideInventory(); else ShowInventory();
                return true;
            case Keys.Down:
                if (IsInventoryOpen)
                    if (comboBoxInventory.Items.Count > 0)
                        comboBoxInventory.SelectedIndex = (comboBoxInventory.SelectedIndex + 1) % comboBoxInventory.Items.Count;
                return true;
            case Keys.Up:
                if (IsInventoryOpen)
                    if (comboBoxInventory.Items.Count > 0)
                        comboBoxInventory.SelectedIndex = (comboBoxInventory.SelectedIndex - 1 + comboBoxInventory.Items.Count) % comboBoxInventory.Items.Count;
                return true;
            case Keys.L:
                pictureBoxLootIsClicked(); // player finds item from loot
                return true;
            case Keys.B:
                ReturnToTownClick(); // Returns the player to the town
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
        pictureBoxTown.Image = imageSetter.GetImagePath("act1town.png"); // places the "town2.png" into the picturebox
        //pictureBoxTown.SizeMode = PictureBoxSizeMode.Zoom; // This will center the image 

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
            textBox1.Text = $"You threw away the item {item.Name}.";
            RemoveItemFromComboboxInventory(item);
            UpdatePlayerLabels();
        }
    }
    private void buttonPlayGame_Click(object sender, EventArgs e)
    {
        ButtonPlayGame();
    }

    private void ButtonPlayGame()
    {
        playGameHasBeenPressed = true;
        panelStartScreen.Hide();
        panelEncounter.Show();
        buttonPlayGame.Dispose();
    }

    private void ButtonWest()
    {
        panelTown.Hide();
        panelEncounter.Show();
        if (!Act1BossDefeatedFlag && StoryProgress.playerIsInTown == true)
        {
            Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1, this);
            storyProgress.StoryState = 100; // repeated encounters west act 1
        }
        if (Act1BossDefeatedFlag && StoryProgress.playerIsInTown == true)
        {
            Encounter.PerformEncounter(monsterContainer.listOfMonstersSnowGoldGoblin, itemContainer.noItems, this);
            storyProgress.StoryState = 103; // repeated encounters west act 1
        }
    }

    private void ButtonEast()
    {
        panelTown.Hide();
        panelEncounter.Show();
        if (!Act1BossDefeatedFlag && StoryProgress.playerIsInTown == true)
        {
            Encounter.PerformEncounter(monsterContainer.listOfMonsters2, itemContainer.items2, this);
            storyProgress.StoryState = 101; // repeated encounters east act 1
        }
        if (Act1BossDefeatedFlag && StoryProgress.playerIsInTown == true)
        {
            Encounter.PerformEncounter(monsterContainer.listOfSnowMonsters1, itemContainer.items2, this);
            storyProgress.StoryState = 102; // repeated encounters east act 1
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

    // Boss encounters
    private void ButtonNorth()
    {
        panelTown.Hide();
        panelEncounter.Show();
        if (StoryProgress.playerIsInTown == true && !Act1BossDefeatedFlag)
        {
            Act1BossDefeatedFlag = false;
            sounds.PlayAct1BossSound();
            // Subscribe to the EncounterCompleted event
            Encounter.EncounterCompleted += OnAct1BossDefeated;

            Player.priceToHeal = 4; // resets the price to heal
            buttonHeal.Text = $"Heal {Player.priceToHeal.ToString()}G";
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
        storyProgress.StoryState = 8;
        buttonReturnToTown.Hide();

        // Unsubscribe from the event to avoid multiple invocations
        Encounter.EncounterCompleted -= OnAct1BossDefeated;
    }

    public void SetAct2Backgroundimage()
    {
        Act1BossDefeatedFlag = true; // Set the defeated flag
        panelEncounter.BackgroundImage = imageSetter.GetImagePath("act2background.png");
        panelTown.BackgroundImage = imageSetter.GetImagePath("act2background.png");
    }

    public void SetAct1TownBackgroundimage() // TODO delete
    {
        panelTown.BackgroundImage = imageSetter.GetImagePath("unused (7).png");
    }

    public void SetAct1Backgroundimage() // TODO delete
    {
        panelEncounter.BackgroundImage = imageSetter.GetImagePath("castle.png");
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
            return;
        }
        if (Act1BossDefeatedFlag && StoryProgress.playerIsInTown)
        {
            Act1BossDefeatedFlag = false;
            SetAct1Backgroundimage();
            SetAct1TownBackgroundimage();
            storyProgress.StoryState = 6;
            pictureBoxTown.Image = imageSetter.GetImagePath("act1town.png");
            pictureBoxHealer.Image = imageSetter.GetImagePath("healer.png");
            pictureBoxAct2Smith.Hide();
            buttonUpgradeItem.Hide();
            comboBoxUpgradeItems.Hide();
            txtBox_Town.Text = ("You return to the dark forest. \r\nWhat comes next is up to you.");
            sounds.PlayAct1TownMusic();
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
            if (playerState.Player.GoldInPocket >= Player.priceToHeal) // the players' gold has to be checked here, due to labels being set
            {
                playerState.Player.HealPlayer(playerState);
                UpdatePlayerLabels();
                buttonHeal.Text = $"Heal {Player.priceToHeal.ToString()}G";
                UpdatePlayerHealthBar(); // updates the players health bar after being healed
                if (!cooldownOnSound)
                {
                    if (Act1BossDefeatedFlag)
                    {
                        txtBox_Town.Text = storyProgress.GetAct2HealingText();
                        sounds.PlayAct2HealingSound();
                    }
                    else
                    {
                        txtBox_Town.Text = storyProgress.GetHealingText();
                        sounds.PlayAct1HealingMusic();
                    }
                }
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
            if (playerState.Player.Level >= item.LevelRequirement && playerState.Player.Strength >= item.StrengthRequirement)
            {
                //SetItemLabelInfo(item);
                playerState.Player.EquipItem(item, comboBoxInventory, comboBoxUpgradeItems);
                UpdatePlayerLabels();
                RemoveItemFromComboboxInventory(item); // removes the equipped item from the combobox
                comboBoxUpgradeItems.Items.Add(item);
                CheckIfPlayerIsDefeated(); // checks if the player dies from unequipping an item that gives health
            }
            else
            {
                textBox1.Text = $"The level requirement to equip {item.Name} is {item.LevelRequirement}, and the " +
                    $"strength requirement is {item.StrengthRequirement}.";
            }
        }
        else
        {
        }
    }

    private void RemoveItemFromComboboxInventory(Item item)
    {
        comboBoxInventory.Items.Remove(item);
        if (comboBoxInventory.Items.Count > 0)
        {
            comboBoxInventory.SelectedIndex = 0;
        }
    }

    // This method shows the hidden panels when the mouse is over the item on the hero. It also sets the labels info and name of items.
    private void ShowHiddenItemPanel(ItemType itemType)
    {
        if (playerState.Player.EquippedItems.TryGetValue(itemType, out var item) && item != null)
        {
            // Show the corresponding panel for the itemType
            switch (itemType)
            {
                case ItemType.WeaponRightHand:
                    panelPopupWeaponRightHand.Show();
                    labelWeaponRightHandName.Text = item.Name;
                    labelInfoWeaponRightHandEquipped.Text = item.ToString();
                    break;
                case ItemType.Armor:
                    panelPopupArmor.Show();
                    labelArmorName.Text = item.Name;
                    labelInfoArmorEquipped.Text = item.ToString();
                    break;
                case ItemType.Boots:
                    panelPopupBoots.Show();
                    labelBootsName.Text = item.Name;
                    labelInfoBootsEquipped.Text = item.ToString();
                    break;
                case ItemType.Gloves:
                    panelPopupGloves.Show();
                    labelGlovesName.Text = item.Name;
                    labelInfoGlovesEquipped.Text = item.ToString();
                    break;
            }
            hoverTimer.Stop(); // Stop the hover timer regardless of item type
        }
    }



    private void labelInvisibleArmor_MouseLeave(object sender, EventArgs e)
    {
        hoverTimer.Start();
    }

    private void labelInvisibleArmor_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanel(ItemType.Armor);
    }

    private void labelInvisibleBoots_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanel(ItemType.Boots);
    }

    private void labelInvisibleBoots_MouseLeave(object sender, EventArgs e)
    {
        hoverTimer.Start();
    }

    private void labelInvisibleWeaponRightHandEquipped_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanel(ItemType.WeaponRightHand);
    }

    private void labelInvisibleWeaponRightHandEquipped_MouseLeave(object sender, EventArgs e)
    {
        hoverTimer.Start();
    }

    private void buttonUpgradeItem_Click(object sender, EventArgs e)
    {
        ButtonUpgradeItem();
    }

    private void ButtonUpgradeItem()
    {
        if (comboBoxUpgradeItems.SelectedItem != null && playerState.Player.GoldInPocket >= Item.CostToUpgrade)
        {
            sounds.PlaySmithingSound();
            Item item = (Item)comboBoxUpgradeItems.SelectedItem;
            if (item.IsItemUpgraded)
            {
                txtBox_Town.Text = "\"Aaah, this item has already been upgraded. Give me another one!\"";
                return;
            }
            playerState.Player.UnequipItem(item, comboBoxInventory, comboBoxUpgradeItems); // unequips the item to prevent stat bugs
            item.UpgradeItem();
            playerState.Player.GoldInPocket -= Item.CostToUpgrade;
            UpdatePlayerLabels();
            comboBoxInventory.Items[comboBoxInventory.Items.IndexOf(item)] = item; // Update the item in the ComboBox

            if (comboBoxInventory.Items.Count > 0) // This just ensures the combobox "stands" on an item
            {
                comboBoxInventory.SelectedIndex = 0;
            }
        }
        else
        {
            txtBox_Town.Text = "\"Sorry, the best I can do is 50G. No discounts.\"";
        }
    }

    public async Task CheckIfPlayerIsDefeated()
    {
        if (playerState.Player.CurrentHealth <= 0)
        {
            await Task.Delay(400);
            sounds.PlayDeathGameOverSound();
            Thread.Sleep(500);
            panelEncounter.Hide();
            panelGameOver.Show();
            await Task.Delay(2800);
            Application.Exit();
        }
    }

    private void labelInvisibleGloves_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanel(ItemType.Gloves);
    }

    private void labelInvisibleGloves_MouseLeave(object sender, EventArgs e)
    {
        hoverTimer.Start();
    }

    private void pictureBoxHeroBag_Click(object sender, EventArgs e)
    {
        ShowInventory();
    }

    private void ShowInventory()
    {
        pictureBoxInventory.Show();
        panelInventory.Show();
        pictureBoxHeroBag.Hide();
        sounds.PlayInventorySound();
        IsInventoryOpen = true;
    }

    private void pictureBoxInventory_Click(object sender, EventArgs e)
    {
        HideInventory();
    }

    public void HideInventory()
    {
        pictureBoxInventory.Hide();
        panelInventory.Hide();
        pictureBoxHeroBag.Show();
        IsInventoryOpen = false;
    }

    private void labelInventory_Click(object sender, EventArgs e)
    {
        HideInventory();
    }

    private void pictureBoxLoot_Click(object sender, EventArgs e)
    {
        pictureBoxLootIsClicked();
    }

    public void pictureBoxLootIsClicked()
    {
        if (pictureBoxLoot.Visible)
        {
            pictureBoxLoot.Hide();
            Encounter.ItemIsLootetFromMonster(playerState, this);
            sounds.PlayLootItemsSound();
        }
    }

    // This is called when gold is dropped
    public void PopupFadeLabel(Label label)
    {
        // Initial setup
        label.Visible = true;
        label.ForeColor = Color.FromArgb(255, label.ForeColor.R, label.ForeColor.G, label.ForeColor.B); // Fully opaque

        int opacity = 255; // Maximum opacity for RGB channels
        System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer { Interval = 40 }; // Timer interval for fade speed

        fadeTimer.Tick += (sender, e) =>
        {
            opacity -= 25; // Decrease opacity for fade-out effect
            if (opacity <= 0)
            {
                label.Visible = false; // Hide the label when fully faded
                fadeTimer.Stop();
                fadeTimer.Dispose();
            }
            else
            {
                // Update the label's ForeColor with the current opacity
                label.ForeColor = Color.FromArgb(opacity, label.ForeColor.R, label.ForeColor.G, label.ForeColor.B);
            }
        };

        fadeTimer.Start(); // Start the fading effect
    }

    private void buttonReturnToTown_Click(object sender, EventArgs e)
    {
        ReturnToTownClick();
    }

    private void ReturnToTownClick()
    {
        if (StoryProgress.TutorialIsOver) // Makes sure the player can't go to the town before the tutorial is over
        {
            if (Act1BossDefeatedFlag == false)
            {
                storyProgress.StoryState = 7; // act 1 town
            } else
            {
                storyProgress.StoryState = 12; // act 2 town
            }
                ButtonContinue();
        }
    }

    public void UpdateMonsterHealthLabels(Monster monster)
    {
        progressBarMonsterHP.Value = monster.CurrentHealth;
        labelMonsterHp.Text = $"HP: {monster.CurrentHealth}/{monster.MaxHealth}";
    }

    // This method sets all the labels to match the encountered monsters stats
    public void SetEncounteredMonsterLabels(Monster monster)
    {
        if (monster.Name == "Aldrus Thornfell" || monster.Name == "Another Boss Name")
        {
            textBox1.Text = $"You have awakened {monster.Name}! Your end is near.";
        }
        else
        {
            textBox1.Text = $"You have encountered a {monster.Name}! Kill it.";
        }

        int monsterHealth = monster.MaxHealth;
        int monsterAttack = monster.MaxDamage;

        labelMonsterName.Text = monster.Name;
        progressBarMonsterHP.Maximum = monster.MaxHealth;
        progressBarMonsterHP.Value = monster.CurrentHealth;
        labelMonsterHp.Text = $"HP: {monster.CurrentHealth}/{monster.MaxHealth}";
        pictureBoxMonster1.Image = monster.MonsterImage; // Sets the image to the encountered monster
    }
    public void UpdatePlayerLabels()
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
        labelExperience.Text = $"Exp: {playerState.Player.Experience}/{playerState.Player.XpNeededToLevelUp}";
    }

    private void UpdatePlayerHealthBar()
    {
        //      Setting the progress bar and label player health
        int currentHealth = playerState.Player.CurrentHealth;
        int maxHealth = playerState.Player.MaxHealth;

        CheckIfPlayerIsDefeated();
        progressBarPlayerHP.Maximum = maxHealth;
        progressBarPlayerHP.Value = currentHealth;
        labelPlayerHP.Text = $"HP: {currentHealth}/{maxHealth}";
    }

}


