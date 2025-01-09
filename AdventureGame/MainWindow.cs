using System.Diagnostics;
using System.Media;
using Color = System.Drawing.Color;

namespace AdventureGame;

public partial class MainWindow : Form
{
    internal PlayerState playerState;
    private bool IsAttackOnCooldown;
    private ModifierProcessor _modifierProcessor;
    private MonsterContainer monsterContainer = new MonsterContainer();
    private ItemContainer itemContainer = new ItemContainer();
    private StoryProgress storyProgress;
    PopupWindowModifier _windowModifier;

    private bool cooldownOnSound;
    public List<Panel> panelsList;
    public int panelsIndex;
    private Random random = new Random();
    ImageSetter imageSetter;
    MusicAndSound sounds = new MusicAndSound();
    bool isContinueOnCooldown; // Prevents the player from spamming Continue too fast
    public bool IsInventoryOpen { get; set; } = false;
    public bool PlayGameHasBeenPressed { get; set; } = false;
    bool EnabledAct1TechniqueTeacher;
    bool OneTimeBool;
    bool OneTimeBool2;
    bool OneTimeBool3;
    public bool IsReturnToTownEnabled = true;
    public bool IsButtonContinueEnabled = true;
    private QuestManager quests;
    private Controller _controller;

    public MainWindow()
    {
        InitializeComponent();
        this.DoubleBuffered = true; // helps flickering
        playerState = new PlayerState();
        panelsList = new List<Panel>();
        _modifierProcessor = new ModifierProcessor(playerState);
        _windowModifier = new PopupWindowModifier(_modifierProcessor, this);
        HidePanelsEtc();
        storyProgress = new StoryProgress(this, sounds);
        imageSetter = new ImageSetter(this);
        _controller = new Controller(playerState, this); // Initialize controller
        quests = new QuestManager(this, imageSetter);
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

        buttonPlayGame.MouseEnter += buttonPlayGame_MouseEnter; // Button Play Game Color
        buttonPlayGame.MouseLeave += buttonPlayGame_MouseLeave;
        //this.KeyDown += new KeyEventHandler(Form_KeyDown); // Cool unused code
        //this.KeyUp += new KeyEventHandler(Form_KeyUp); // Cool unused code
        this.KeyUp += MainWindow_KeyUp;

        // Make the window non-reziable
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;

        // Method to make the Game Title change colors slowly
        FadeTitle();
        this.KeyPreview = true; // prevents the buttons from gaining unwanted focus

        SetInvisbleCompassLabels();
        SetInisibleEquippedItemsLabels();

        comboBoxInventory.SelectedIndexChanged += ComboBoxInventory_SelectedIndexChanged; // event that listens when index is changed

        // Set up a timer to poll controller state every 50ms
        var controllerPollTimer = new System.Windows.Forms.Timer
        {
            Interval = 50 // Poll every 50 ms
        };
        controllerPollTimer.Tick += (sender, e) => _controller.UpdateControllerState();
        controllerPollTimer.Start();
    }

    private void ComboBoxInventory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboboxInventorySetInfoLabel();
    }

    #region Cool unused code
    //private void Form_KeyUp(object? sender, KeyEventArgs e)
    //{
    //    if (e.KeyCode == Keys.C)
    //    {
    //        panelPopupInventoryInfo.Hide();
    //    }
    //}

    //private void Form_KeyDown(object? sender, KeyEventArgs e)
    //{
    //    if (e.KeyCode == Keys.C && IsInventoryOpen)
    //    {
    //        if (IsInventoryOpen)
    //        {
    //            panelPopupInventoryInfo.Show();
    //        }
    //    }
    //} 
    #endregion

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
        panelPopupBelt.Hide();
        panelPopupGloves.Hide();
        panelPopupHelmet.Hide();
        panelPopupAmulet.Hide();
        panelPopupLeggings.Hide();
        panelPopupShoulders.Hide();
        panelPopupWeaponLeftHand.Hide();
        comboBoxUpgradeItems.Hide();
        buttonUpgradeItem.Hide();
        pictureBoxHeroBag.Hide();
        pictureBoxInventory.Hide();
        panelInventory.Hide();
        pictureBoxLoot.Hide();
        labelGoldPopup.Hide();
        labelHpPopup.Hide();
        buttonReturnToTown.Hide();
        btn_attack.Hide();
        buttonBloodLust.Hide();
        buttonDodgeJab.Hide();
        buttonRoarAttack.Hide();
        buttonDivine.Hide();
        panelAct1Quest1.Hide();
        panelAct4Quest1.Hide();
        panelPopupInventoryInfo.Hide();
        pictureBoxDragonEggs.Hide();
        labelDragonEggs.Hide();
        labelAct4Q1.Hide();
        buttonTalkMage.Hide();
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
        // belt
        var posBelt = labelInvisibleBelt.Parent
           .PointToScreen(labelInvisibleBelt.Location);
        posBelt = pictureBoxHero.PointToClient(posBelt);
        labelInvisibleBelt.Parent = pictureBoxHero;
        labelInvisibleBelt.Location = posBelt;
        labelInvisibleBelt.BackColor = Color.Transparent;
        // amulet
        var posAmulet = labelInvisibleAmulet.Parent
           .PointToScreen(labelInvisibleAmulet.Location);
        posAmulet = pictureBoxHero.PointToClient(posAmulet);
        labelInvisibleAmulet.Parent = pictureBoxHero;
        labelInvisibleAmulet.Location = posAmulet;
        labelInvisibleAmulet.BackColor = Color.Transparent;
        // helmet
        var posHelmet = labelInvisibleHelmet.Parent
           .PointToScreen(labelInvisibleHelmet.Location);
        posHelmet = pictureBoxHero.PointToClient(posHelmet);
        labelInvisibleHelmet.Parent = pictureBoxHero;
        labelInvisibleHelmet.Location = posHelmet;
        labelInvisibleHelmet.BackColor = Color.Transparent;
        // leggings
        var posLeggings = labelInvisibleLeggings.Parent
           .PointToScreen(labelInvisibleLeggings.Location);
        posLeggings = pictureBoxHero.PointToClient(posLeggings);
        labelInvisibleLeggings.Parent = pictureBoxHero;
        labelInvisibleLeggings.Location = posLeggings;
        labelInvisibleLeggings.BackColor = Color.Transparent;
        // Shoulders
        var posShoulders = labelInvisibleShoulders.Parent
           .PointToScreen(labelInvisibleShoulders.Location);
        posShoulders = pictureBoxHero.PointToClient(posShoulders);
        labelInvisibleShoulders.Parent = pictureBoxHero;
        labelInvisibleShoulders.Location = posShoulders;
        labelInvisibleShoulders.BackColor = Color.Transparent;
        // WeaponLeftHand
        var posWeaponLeftHand = labelInvisibleWeaponLeftHand.Parent
           .PointToScreen(labelInvisibleWeaponLeftHand.Location);
        posWeaponLeftHand = pictureBoxHero.PointToClient(posWeaponLeftHand);
        labelInvisibleWeaponLeftHand.Parent = pictureBoxHero;
        labelInvisibleWeaponLeftHand.Location = posWeaponLeftHand;
        labelInvisibleWeaponLeftHand.BackColor = Color.Transparent;

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

    public static async Task ShakeMonsterPicturebox(Control control, int duration = 80, int shakeAmount = 5)
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

    public void OnPlayerLevelUp()
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
        await NormalAttack();
    }
    private async void buttonBloodLust_Click(object sender, EventArgs e)
    {
        await BloodLustAttack();
    }

    // This method lets the player use the buttons by pressing a key instead of clicking
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Check for specific key presses
        switch (keyData)
        {
            case Keys.Space:
            case Keys.D1:
                Task task = NormalAttack();
                return true;
            case Keys.D2:
                task = BloodLustAttack();
                return true;
            case Keys.D3:
                task = DodgeJabAttack();
                return true;
            case Keys.D4:
                task = RoarAttack();
                return true;
            case Keys.D5:
                task = DivineAttack();
                return true;
            case Keys.Enter:
                EnterKeyPressed();
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
                KeysDown();
                return true;
            case Keys.Up:
                KeysUp();
                return true;
            case Keys.F:
                LootIsClicked(); // player finds item from loot
                return true;
            case Keys.B:
                ReturnToTownClick(); // Returns the player to the town
                ReturnToTownFromQuests();
                return true;
            case Keys.U:
                ButtonUpgradeItem();
                return true;
            case Keys.L:
                task = LearnTechniqueAsync();
                return true;
            case Keys.Y:
                StartAct1Quest1();
                StartAct4Quest1();
                return true;
            case Keys.Tab:
                InventoryPanelPopupInfoShow();
                return true; // Indicate that the key was handled
            case Keys.M:
                //sounds.MuteAllMusic();
                OpenModifierPopupWindow();
                return true;
            default:
                return base.ProcessCmdKey(ref msg, keyData); // Let the base method handle other keys
        }
    }

    public void KeysDown()
    {
        ScrollTextBox(textBox1, 1);
        ScrollTextBox(textBoxAct1Quest1, 1);
        if (IsInventoryOpen)
        {
            if (comboBoxInventory.Items.Count > 0)
            {
                comboBoxInventory.SelectedIndex = (comboBoxInventory.SelectedIndex + 1) % comboBoxInventory.Items.Count;
            } // Scrolls through inventory items
        }
        if (StoryProgress.playerIsInTown && storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 2) // act 2 smith
        {
            if (comboBoxUpgradeItems.Items.Count > 0) // Scrolls through upgradable items
                comboBoxUpgradeItems.SelectedIndex = (comboBoxUpgradeItems.SelectedIndex + 1) % comboBoxUpgradeItems.Items.Count;
        }

    }

    private void ScrollTextBox(TextBox textBox, int lines)
    {
        // Ensure the TextBox contains text
        if (string.IsNullOrEmpty(textBox.Text))
            return;

        int firstVisibleLine = textBox.GetLineFromCharIndex(textBox.SelectionStart);
        int totalLines = textBox.GetLineFromCharIndex(textBox.TextLength); // Total number of lines based on text length

        // Calculate the new line to scroll to
        int newLine = Math.Max(0, Math.Min(totalLines, firstVisibleLine + lines));

        if (lines > 0 && newLine == totalLines) // Scrolling down to the very end
        {
            textBox.SelectionStart = textBox.Text.Length; // Set caret to the very end
        }
        else
        {
            int charIndex = textBox.GetFirstCharIndexFromLine(newLine);
            if (charIndex >= 0) // Ensure charIndex is valid
            {
                textBox.SelectionStart = charIndex;
            }
        }

        textBox.SelectionLength = 0; // Prevent text selection
        textBox.ScrollToCaret();    // Scroll to the new caret position
    }


    public void KeysUp()
    {
        ScrollTextBox(textBox1, -1);
        ScrollTextBox(textBoxAct1Quest1, -1);
        if (IsInventoryOpen)
        {
            if (comboBoxInventory.Items.Count > 0)
            {
                comboBoxInventory.SelectedIndex = (comboBoxInventory.SelectedIndex - 1 + comboBoxInventory.Items.Count) % comboBoxInventory.Items.Count;
            }
        }
        if (StoryProgress.playerIsInTown && storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 2) // Act 2 smith
        {
            if (comboBoxUpgradeItems.Items.Count > 0)
            {
                comboBoxUpgradeItems.SelectedIndex = (comboBoxUpgradeItems.SelectedIndex - 1 + comboBoxUpgradeItems.Items.Count) % comboBoxUpgradeItems.Items.Count;
            }
        }
    }

    public void InventoryPanelPopupInfoShow()
    {
        if (IsInventoryOpen && comboBoxInventory.Items.Count > 0)
        {
            panelPopupInventoryInfo.Show();
        }
    }

    public void EnterKeyPressed()
    {
        if (!PlayGameHasBeenPressed)
        {
            ButtonPlayGame();
        }
        ButtonContinueAsync();
        HideInventory();
        Quest1ContinueDialog();
    }

    private void MainWindow_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab)
        {
            panelPopupInventoryInfo.Hide();

        }
    }

    private void ComboboxInventorySetInfoLabel()
    {
        if (comboBoxInventory.SelectedItem is Item selectedItem)
        {
            labelInventoryItemInfo.Text = selectedItem.ToString(); // Sets infoLabel on items in inventory

            ItemType itemType = selectedItem.Type;
            switch (itemType)
            {
                case ItemType.WeaponRightHand:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("swordicon.ico");
                    break;
                case ItemType.Gloves:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("gauntletsicon.ico");
                    break;
                case ItemType.Boots:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("bootsicon.png");
                    break;
                case ItemType.Armor:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("armoricon.png");
                    break;
                case ItemType.Belt:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("belticon.png");
                    break;
                case ItemType.Amulet:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("amuleticon.png");
                    break;
                case ItemType.Leggings:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("leggingsicon.png");
                    break;
                case ItemType.Helmet:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("helmeticon.png");
                    break;
                case ItemType.Shoulders:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("shouldersicon.png");
                    break;
                case ItemType.WeaponLeftHand:
                    pictureBoxInventoryIcon.Image = imageSetter.GetImagePath("hookicon.png");
                    break;
            }
        }
    }

    public void ShowPopupPanelsBasedOnItemType()
    {
        if (comboBoxInventory.SelectedItem is Item selectedItem && IsInventoryOpen)
        {
            // Get the item type from the selected item
            ItemType itemType = selectedItem.Type;

            // Get the item from the EquippedItems collection
            if (playerState.Player.EquippedItems.TryGetValue(itemType, out var item))
            {
                // If the item exists in the EquippedItems, show the appropriate panel
                switch (itemType)
                {
                    case ItemType.WeaponRightHand:
                        panelPopupWeaponRightHand.Show();
                        labelWeaponRightHandName.Text = item.Name;
                        labelInfoWeaponRightHandEquipped.Text = item.ToString();
                        break;

                    case ItemType.Gloves:
                        panelPopupGloves.Show();
                        labelGlovesName.Text = item.Name;
                        labelInfoGlovesEquipped.Text = item.ToString();
                        break;

                    case ItemType.Boots:
                        panelPopupBoots.Show();
                        labelBootsName.Text = item.Name;
                        labelInfoBootsEquipped.Text = item.ToString();
                        break;

                    case ItemType.Armor:
                        panelPopupArmor.Show();
                        labelArmorName.Text = item.Name;
                        labelInfoArmorEquipped.Text = item.ToString();
                        break;

                    case ItemType.Belt:
                        panelPopupBelt.Show();
                        labelBeltName.Text = item.Name;
                        labelInfoBeltEquipped.Text = item.ToString();
                        break;

                    case ItemType.Amulet:
                        panelPopupAmulet.Show();
                        labelAmuletName.Text = item.Name;
                        labelInfoAmuletEquipped.Text = item.ToString();
                        break;

                    case ItemType.Leggings:
                        panelPopupLeggings.Show();
                        labelLeggingsName.Text = item.Name;
                        labelInfoLeggingsEquipped.Text = item.ToString();
                        break;

                    case ItemType.Helmet:
                        panelPopupHelmet.Show();
                        labelHelmetName.Text = item.Name;
                        labelInfoHelmetEquipped.Text = item.ToString();
                        break;

                    case ItemType.Shoulders:
                        panelPopupShoulders.Show();
                        labelShouldersName.Text = item.Name;
                        labelInfoShouldersEquipped.Text = item.ToString();
                        break;

                    case ItemType.WeaponLeftHand:
                        panelPopupWeaponLeftHand.Show();
                        labelWeaponLeftHandName.Text = item.Name;
                        labelInfoWeaponLeftHandEquipped.Text = item.ToString();
                        break;
                }
            }
        }
    }


    public void HideAllEquipmentPanels()
    {
        panelPopupWeaponRightHand.Hide();
        panelPopupArmor.Hide();
        panelPopupBoots.Hide();
        panelPopupGloves.Hide();
        panelPopupBelt.Hide();
        panelPopupHelmet.Hide();
        panelPopupAmulet.Hide();
        panelPopupLeggings.Hide();
        panelPopupShoulders.Hide();
        panelPopupWeaponLeftHand.Hide();
    }

    // This method runs after the entire layout of WinForms is loaded
    private void MainWindow_Load(object sender, EventArgs e)
    {
        sounds.SetListOfSounds();
        sounds.PlayThunderSound();

        panelsList.Add(panelEncounter);
        panelsList.Add(panelStartScreen);
        panelsList.Add(panelGameOver);
        panelsList.Add(panelTown);
        panelsList[panelsIndex].BringToFront();
        labelInventoryItemInfo.Text = null;
    }

    private void label2_Click_1(object sender, EventArgs e)
    {

    }

    private void buttonDiscardItem_Click(object sender, EventArgs e)
    {
        ButtonDiscardItem();
    }

    public void ButtonDiscardItem()
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

    public void ButtonPlayGame()
    {
        PlayGameHasBeenPressed = true;
        panelStartScreen.Hide();
        panelEncounter.Show();
        buttonPlayGame.Dispose();
    }

    public void ButtonWest()
    {
        if (StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            if (StoryProgress.WhichActIsThePlayerIn == 1)
            {
                storyProgress.StoryState = 100; // repeated encounters west act 1
            }
            if (StoryProgress.WhichActIsThePlayerIn == 2)
            {
                storyProgress.StoryState = 102; // repeated encounters west act 2
            }
            if (StoryProgress.WhichActIsThePlayerIn == 3)
            {
                storyProgress.StoryState = 104; // repeated encounters west act 3
            }
            if (StoryProgress.WhichActIsThePlayerIn == 4)
            {
                storyProgress.StoryState = 106; // repeated encounters west act 3
            }
            storyProgress.ProgressStory();
        }
    }

    public void ButtonEast()
    {
        if (StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            if (StoryProgress.WhichActIsThePlayerIn == 1)
            {
                storyProgress.StoryState = 101; // repeated encounters east act 1
            }
            if (StoryProgress.WhichActIsThePlayerIn == 2)
            {
                storyProgress.StoryState = 103; // repeated encounters east act 2
            }
            if (StoryProgress.WhichActIsThePlayerIn == 3)
            {
                storyProgress.StoryState = 104; // repeated encounters west act 3 // should be 105, design choice
            }
            if (StoryProgress.WhichActIsThePlayerIn == 4)
            {
                storyProgress.StoryState = 105; // repeated encounters east act 4
            }
            storyProgress.ProgressStory();
        }
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        ButtonContinueAsync();
    }

    public async Task ButtonContinueAsync()
    {
        //if (quests.isInsideAct1Quest1Panel || quests.isInsideAct1Quest1Panel)
        //{
        //    return;
        //}

        if (!isContinueOnCooldown && IsButtonContinueEnabled)
        {
            isContinueOnCooldown = true;
            storyProgress.ProgressStory();

            await Task.Delay(280);
            isContinueOnCooldown = false;

        }
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

    public void ButtonNorth()
    {
        if (StoryProgress.playerIsInTown)
        {
            panelTown.Hide();
            panelEncounter.Show();
            switch (StoryProgress.WhichActIsThePlayerIn)
            {
                case 1: // Player is in act 1
                    // Act 1 Boss Encounter
                    if (!storyProgress.Act1BossDefeatedFlag)
                    {
                        Act1BossFight();
                    }

                    break;

                case 2: // Player is in act 2
                    // Act 2 Boss Encounter
                    if (!storyProgress.Act2BossDefeatedFlag)
                    {
                        Act2BossFight();
                    }
                    else
                    {
                        storyProgress.StoryState = 14;
                        ButtonContinueAsync();
                        sounds.PlayAct3Waves();
                    }
                    break;

                case 3: // Player is in act 3
                    // Act 3 Boss Encounter
                    if (!storyProgress.Act3BossDefeatedFlag)
                    {
                        Act3BossFight();
                    }
                    else
                    {
                        storyProgress.StoryState = 18;
                        ButtonContinueAsync();
                        sounds.PlayAct4Music();
                    }
                    break;
                case 4: // Player is in act 4
                    storyProgress.StoryState = 107; // repeated Dragon Egg encounters North
                    ButtonContinueAsync();
                    break;

                default:
                    break;
            }
        }
    }

    private void Act1BossFight()
    {
        sounds.PlayAct1BossSound();
        Encounter.EncounterCompleted += OnAct1BossDefeated;

        buttonReturnToTown.Hide();

        // Start the encounter for Act 1 boss
        Encounter.PerformEncounter(monsterContainer.listOfMonstersBossAct1, itemContainer.weakAmulets, this);

        // Enable the technique teacher if not already done
        if (!OneTimeBool2)
        {
            storyProgress.Act1ArtsTeacherIsAvailable = true;
            OneTimeBool2 = true;
        }
    }

    private void Act2BossFight()
    {
        buttonReturnToTown.Hide();
        buttonReturnToTown.Enabled = false;
        sounds.PlayAct2BossSound();

        // Start the encounter for Act 2 boss
        Encounter.PerformEncounter(monsterContainer.listOfMonstersBossAct2, itemContainer.magicAmulets, this);

        // Subscribe to the EncounterCompleted event for the Act 2 boss
        Encounter.EncounterCompleted += OnAct2BossDefeated;

        // Enable the technique teacher if not already done
        if (!OneTimeBool)
        {
            storyProgress.Act1ArtsTeacherIsAvailable = true;
            OneTimeBool = true;
        }
    }

    private void Act3BossFight()
    {
        IsButtonContinueEnabled = false;
        buttonReturnToTown.Hide();
        buttonReturnToTown.Enabled = false;
        IsReturnToTownEnabled = false;
        imageSetter.SetAct3BossBackgroundimage();
        Encounter.PerformEncounter(monsterContainer.listOfMonstersBossAct3, itemContainer.rareAmulets, this);
        Encounter.EncounterCompleted += OnAct3BossDefeated;
        sounds.PlayAct3Boss();
        if (!OneTimeBool3)
        {
            storyProgress.Act1ArtsTeacherIsAvailable = true;
            OneTimeBool3 = true;
        }
        //storyProgress.WhichActIsThePlayerIn = 3;  // Update to Act 3
    }

    private void OnAct1BossDefeated(object sender, EventArgs e)
    {
        StoryProgress.playerIsInTown = false;
        storyProgress.Act1BossDefeatedFlag = true;
        storyProgress.StoryState = 8;
        buttonReturnToTown.Hide();
        IsReturnToTownEnabled = false;
        sounds.StopAct1TownMusic();

        // Unsubscribe from the event to avoid multiple invocations
        Encounter.EncounterCompleted -= OnAct1BossDefeated;
    }
    private void OnAct2BossDefeated(object sender, EventArgs e)
    {
        StoryProgress.playerIsInTown = false;
        storyProgress.Act2BossDefeatedFlag = true;
        storyProgress.StoryState = 13;
        sounds.StopAct2TownMusic();
        buttonReturnToTown.Enabled = false;
        IsReturnToTownEnabled = false;
        buttonReturnToTown.Hide();
        // Unsubscribe from the event to avoid multiple invocations
        Encounter.EncounterCompleted -= OnAct2BossDefeated;
    }

    private void OnAct3BossDefeated(object sender, EventArgs e)
    {
        StoryProgress.playerIsInTown = false;
        storyProgress.Act3BossDefeatedFlag = true;
        storyProgress.StoryState = 17;
        //sounds.StopAct3TownMusic(); // TODO maybe
        buttonReturnToTown.Enabled = false;
        IsReturnToTownEnabled = false;
        IsButtonContinueEnabled = true;
        buttonReturnToTown.Hide();
        // Unsubscribe from the event to avoid multiple invocations
        Encounter.EncounterCompleted -= OnAct3BossDefeated;
    }


    private void labelCompassS_Click(object sender, EventArgs e)
    {
        ButtonSouth();
    }

    public void ButtonSouth()
    {
        // Act 1 Quest 1 special encounter
        if (quests.Act1Quest1EncounterIsActive && !storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 1 && StoryProgress.playerIsInTown)
        {
            quests.Act1Quest1EncounterIsActive = false;
            panelTown.Hide();
            panelEncounter.Show();
            storyProgress.StoryState = 99;
            storyProgress.ProgressStory();
            quests.Act1Quest1BoyFound = true;
        }
        if (!storyProgress.Act1BossDefeatedFlag)
        {
            txtBox_Town.Text = "You cannot turn back now. You must press on, your destiny awaits.";
            return;
        }
        if (storyProgress.Act1BossDefeatedFlag && StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 2) // if the player is in act2, returns to act1
        {
            storyProgress.Act1BossDefeatedFlag = false; // This is so the act1boss can be defeated again
            sounds.PlayAct1TownMusic();
            storyProgress.StoryState = 6;
            storyProgress.ProgressStory();
        }
        if (storyProgress.Act2BossDefeatedFlag && StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 3) // if in act3, returns to act2
        {
            //Act2BossDefeatedFlag = false; // set this if the act2 boss should be encountered more than once
            storyProgress.StoryState = 12;
            storyProgress.ProgressStory();
            sounds.PlayAct2TownMusic();
        }
        if (storyProgress.Act2BossDefeatedFlag && StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 4) // if the player is in act4, return to act3
        {
            sounds.PlayAct3Waves();
            storyProgress.StoryState = 16;
            storyProgress.ProgressStory();
        }

    }

    private void buttonHeal_Click(object sender, EventArgs e)
    {
        ButtonHeal();
    }

    public async void ButtonHeal()
    {
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn != 3) // We don't want the player to be able to heal in act 3 because there's no healer
        {
            if (playerState.Player.GoldInPocket >= Player.priceToHeal) // the players' gold has to be checked here, due to labels being set
            {
                playerState.Player.HealPlayer(playerState);
                UpdatePlayerLabels();
                buttonHeal.Text = $"Heal {Player.priceToHeal.ToString()}G";
                UpdatePlayerHealthBar(); // updates the players health bar after being healed
                if (!cooldownOnSound)
                {
                    switch (StoryProgress.WhichActIsThePlayerIn)
                    {
                        case 1:
                            txtBox_Town.Text = storyProgress.GetHealingText();
                            sounds.PlayAct1HealingMusic();
                            break;
                        case 2:
                            txtBox_Town.Text = storyProgress.GetAct2HealingText();
                            sounds.PlayAct2HealingSound();
                            break;
                        case 4:
                            txtBox_Town.Text = storyProgress.GetAct4HealingText();
                            sounds.PlayAct4HealingSound();
                            break;

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
        ButtonContinueAsync();
    }

    private void buttonEquipUnequip_Click(object sender, EventArgs e)
    {
        ButtonEquipItems();
    }

    public void ButtonEquipItems()
    {
        if (comboBoxInventory.SelectedItem != null)
        {
            Item item = (Item)comboBoxInventory.SelectedItem;
            if (playerState.Player.Level >= item.LevelRequirement && playerState.Player.Strength >= item.StrengthRequirement)
            {
                playerState.Player.EquipItem(item, comboBoxInventory, comboBoxUpgradeItems);
                UpdatePlayerLabels();
                RemoveItemFromComboboxInventory(item); // removes the equipped item from the combobox
                SetHiddenPanelLabelsOnly(item.Type);
                comboBoxUpgradeItems.Items.Add(item);
                Task task = CheckIfPlayerIsDefeated(); // checks if the player dies from unequipping an item that gives health

                if (item.Type == ItemType.WeaponLeftHand)
                {
                    imageSetter.SetHeroLeftWeaponPictureBoxImage();
                }
            }
            else
            {
                //textBox1.Text = $"The level requirement to equip {item.Name} is {item.LevelRequirement}, and the " +
                //    $"strength requirement is {item.StrengthRequirement}.";
                textBox1.Text = $"The requirements to equip {item.Name} are not met.";
            }
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
    public void ShowHiddenItemPanelAndSetLabels(ItemType itemType)
    {
        if (playerState.Player.EquippedItems.TryGetValue(itemType, out var item) && item != null)
        {

            SetHiddenPanelLabelsOnly(item.Type);

            // Show the corresponding panel for the itemType 
            switch (itemType)
            {
                case ItemType.WeaponRightHand:
                    panelPopupWeaponRightHand.Show();
                    break;
                case ItemType.Armor:
                    panelPopupArmor.Show();
                    break;
                case ItemType.Boots:
                    panelPopupBoots.Show();
                    break;
                case ItemType.Gloves:
                    panelPopupGloves.Show();
                    break;
                case ItemType.Amulet:
                    panelPopupAmulet.Show();
                    break;
                case ItemType.Helmet:
                    panelPopupHelmet.Show();
                    break;
                case ItemType.Leggings:
                    panelPopupLeggings.Show();
                    break;
                case ItemType.Belt:
                    panelPopupBelt.Show();
                    break;
                case ItemType.Shoulders:
                    panelPopupShoulders.Show();
                    break;
                case ItemType.WeaponLeftHand:
                    panelPopupWeaponLeftHand.Show();
                    break;
            }
        }
    }

    public void SetHiddenPanelLabelsOnly(ItemType itemType)
    {
        if (playerState.Player.EquippedItems.TryGetValue(itemType, out var item) && item != null)

            // Show the corresponding panel for the itemType 
            switch (itemType)
            {
                case ItemType.WeaponRightHand:
                    labelWeaponRightHandName.Text = item.Name;
                    labelInfoWeaponRightHandEquipped.Text = item.ToString();
                    break;
                case ItemType.Armor:
                    labelArmorName.Text = item.Name;
                    labelInfoArmorEquipped.Text = item.ToString();
                    break;
                case ItemType.Boots:
                    labelBootsName.Text = item.Name;
                    labelInfoBootsEquipped.Text = item.ToString();
                    break;
                case ItemType.Gloves:
                    labelGlovesName.Text = item.Name;
                    labelInfoGlovesEquipped.Text = item.ToString();
                    break;
                case ItemType.Amulet:
                    labelAmuletName.Text = item.Name;
                    labelInfoAmuletEquipped.Text = item.ToString();
                    break;
                case ItemType.Helmet:
                    labelHelmetName.Text = item.Name;
                    labelInfoHelmetEquipped.Text = item.ToString();
                    break;
                case ItemType.Leggings:
                    labelLeggingsName.Text = item.Name;
                    labelInfoLeggingsEquipped.Text = item.ToString();
                    break;
                case ItemType.Belt:
                    labelBeltName.Text = item.Name;
                    labelInfoBeltEquipped.Text = item.ToString();
                    break;
                case ItemType.Shoulders:
                    labelShouldersName.Text = item.Name;
                    labelInfoShouldersEquipped.Text = item.ToString();
                    break;
                case ItemType.WeaponLeftHand:
                    labelWeaponLeftHandName.Text = item.Name;
                    labelInfoWeaponLeftHandEquipped.Text = item.ToString();
                    break;
            }
    }



    private void labelInvisibleAmulet_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.Amulet);
    }

    private void labelInvisibleAmulet_MouseLeave(object sender, EventArgs e)
    {
        panelPopupAmulet.Hide();
    }

    private void labelInvisibleArmor_MouseLeave(object sender, EventArgs e)
    {
        panelPopupArmor.Hide();
    }

    private void labelInvisibleArmor_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.Armor);
    }

    private void labelInvisibleBoots_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.Boots);
    }

    private void labelInvisibleBoots_MouseLeave(object sender, EventArgs e)
    {
        panelPopupBoots.Hide();
    }

    private void labelInvisibleWeaponRightHandEquipped_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.WeaponRightHand);
    }

    private void labelInvisibleWeaponRightHandEquipped_MouseLeave(object sender, EventArgs e)
    {
        panelPopupWeaponRightHand.Hide();
    }
    private void labelInvisibleHelmet_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.Helmet);
    }

    private void labelInvisibleHelmet_MouseLeave(object sender, EventArgs e)
    {
        panelPopupHelmet.Hide();
    }

    private void labelInvisibleBelt_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.Belt);
    }

    private void labelInvisibleBelt_MouseLeave(object sender, EventArgs e)
    {
        panelPopupBelt.Hide();
    }

    private void labelInvisibleLeggings_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.Leggings);
    }

    private void labelInvisibleLeggings_MouseLeave(object sender, EventArgs e)
    {
        panelPopupLeggings.Hide();
    }
    private void labelInvisibleGloves_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.Gloves);
    }

    private void labelInvisibleGloves_MouseLeave(object sender, EventArgs e)
    {
        panelPopupGloves.Hide();
    }

    private void buttonUpgradeItem_Click(object sender, EventArgs e)
    {
        ButtonUpgradeItem();
    }

    private void labelInvisibleWeaponLeftHand_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.WeaponLeftHand);
    }

    private void labelInvisibleWeaponLeftHand_MouseLeave(object sender, EventArgs e)
    {
        panelPopupWeaponLeftHand.Hide();
    }
    private void labelInvisibleShoulders_MouseEnter(object sender, EventArgs e)
    {
        ShowHiddenItemPanelAndSetLabels(ItemType.Shoulders);
    }

    private void labelInvisibleShoulders_MouseLeave(object sender, EventArgs e)
    {
        panelPopupShoulders.Hide();
    }

    public void ButtonUpgradeItem()
    {
        if (StoryProgress.playerIsInTown && storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 2)
        {
            if (comboBoxUpgradeItems.SelectedItem != null && playerState.Player.GoldInPocket >= Item.CostToUpgrade)
            {
                Item item = (Item)comboBoxUpgradeItems.SelectedItem;
                if (item.IsItemUpgraded || item.Type == ItemType.Amulet)
                {
                    txtBox_Town.Text = "\"Aaah, this item has already been upgraded. Give me another one!\"";
                    sounds.PlayAct2SmithNo();
                    return;
                }
                sounds.PlaySmithingSound();
                playerState.Player.UnequipItem(item, comboBoxInventory, comboBoxUpgradeItems); // unequips the item to prevent stat bugs
                item.UpgradeItem();
                sounds.PlayAct2SmithOffer();
                playerState.Player.GoldInPocket -= Item.CostToUpgrade;
                Item.CostToUpgrade += 20;
                buttonUpgradeItem.Text = $"{Item.CostToUpgrade}G";
                UpdatePlayerLabels();
                comboBoxInventory.Items[comboBoxInventory.Items.IndexOf(item)] = item; // Update the item in the ComboBox

                if (comboBoxInventory.Items.Count > 0)
                {
                    comboBoxInventory.SelectedIndex = 0; // This just ensures the combobox "stands" on an item
                }
            }
            else
            {
                txtBox_Town.Text = $"\"Sorry, the best I can do is {Item.CostToUpgrade}G. No discounts.\"";
                sounds.PlayAct2SmithNo();
            }
        }
    }

    public void TalkToMageAct4()
    {
        //TODO
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 4)
        {
            txtBox_Town.Text = storyProgress.GetMageFirstText();
        }
    }

    private void buttonTalkMage_Click(object sender, EventArgs e)
    {
        TalkToMageAct4();
    }


    public async Task CheckIfPlayerIsDefeated()
    {
        if (playerState.Player.CurrentHealth <= 0)
        {
            await Task.Delay(400);
            sounds.PlayDeathGameOverSound();
            await Task.Delay(500);
            panelEncounter.Hide();
            panelGameOver.Show();
            await Task.Delay(3500);
            Application.Exit();
        }
    }


    private void pictureBoxHeroBag_Click(object sender, EventArgs e)
    {
        ShowInventory();
    }

    public void ShowInventory()
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
        LootIsClicked();
    }

    public void LootIsClicked()
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

    public void ReturnToTownClick()
    {
        if (StoryProgress.TutorialIsOver && StoryProgress.playerIsInTown == false && IsReturnToTownEnabled) // Makes sure the player can't go to the town before the tutorial is over
        {
            if (StoryProgress.WhichActIsThePlayerIn == 1 && !storyProgress.Act1BossDefeatedFlag)
            {
                storyProgress.StoryState = 7; // act 1 town
            }
            if (StoryProgress.WhichActIsThePlayerIn == 2)
            {
                storyProgress.StoryState = 12; // act 2 town
            }
            if (StoryProgress.WhichActIsThePlayerIn == 3)
            {
                storyProgress.StoryState = 16; // act 3 town
            }
            if (StoryProgress.WhichActIsThePlayerIn == 4)
            {
                storyProgress.StoryState = 18; // act 4 town
            }
            ButtonContinueAsync();
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
        if (monster.Name == "Aldrus Thornfell" || monster.Name == "Wintermaw" || monster.Name == "The Devouring Abyss")
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
        labelPlayerLifeSteal.Text = $"Lifesteal: {playerState.Player.Lifesteal}%";
        labelPlayerArmor.Text = $"Armor: {playerState.Player.Armor}";
        labelPlayerDodge.Text = $"{playerState.Player.DodgeChance}%";
        labelGoldInPocket.Text = $"{playerState.Player.GoldInPocket}";
        labelLevel.Text = $"Level: {playerState.Player.Level}";
        labelExperience.Text = $"Exp: {playerState.Player.Experience}/{playerState.Player.XpNeededToLevelUp}";
        labelCritChance.Text = $"{playerState.Player.CritChance}%";
        labelRegeneration.Text = $"Regen: {playerState.Player.Regeneration}";
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

    // This is a method that plays the sounds for the attack, calls the attack methods from Encounter, and handles attack controls
    private async Task PerformAttack(Action attackAction, Action primarySoundAction, Action? secondarySoundAction = null)
    {
        if (!IsAttackOnCooldown && Encounter.Monster != null)
        {
            IsAttackOnCooldown = true;

            // Play primary sound (and secondary if provided)
            primarySoundAction();
            secondarySoundAction?.Invoke();

            textBox1.Clear();
            attackAction(); // Executes the specific attack

            // Check if the monster is defeated after the attack
            Encounter.MonsterIsDefeated(playerState, this);

            await ShakeMonsterPicturebox(pictureBoxMonster1);

            // Handle attack cooldown
            //buttonDodgeJab.Enabled = false;
            //buttonRoarAttack.Enabled = false;
            //buttonDivine.Enabled = false;
            //btn_attack.Enabled = false;
            //buttonBloodLust.Enabled = false;
            await Task.Delay(180); // Increase this delay for a slower attack rate
            //buttonBloodLust.Enabled = true;
            //buttonDivine.Enabled = true;
            //buttonRoarAttack.Enabled = true;
            //buttonDodgeJab.Enabled = true;
            //btn_attack.Enabled = true;
            IsAttackOnCooldown = false;
        }
    }

    public async Task NormalAttack()
    {
        await PerformAttack(() => Encounter.NormalAttack(playerState, this), sounds.PlaySwordAttackSound);
    }

    public async Task BloodLustAttack()
    {
        if (playerState.Player.techniqueBloodLustIsLearned)
            await PerformAttack(() => Encounter.BloodLustAttack(playerState, this), sounds.PlayBloodLustSound, sounds.PlaySwordAttackSound);
    }
    public async Task DodgeJabAttack()
    {
        if (playerState.Player.techniqueDodgeJabIsLearned)
            await PerformAttack(() => Encounter.DodgeJabAttack(playerState, this), sounds.PlayDodgeJabSound);
    }
    public async Task RoarAttack()
    {
        if (playerState.Player.techniqueRoarIsLearned)
            await PerformAttack(() => Encounter.RoarAttack(playerState, this), sounds.PlayRoarAttackSound);
        UpdatePlayerLabels();
    }
    public async Task DivineAttack()
    {
        if (playerState.Player.techniqueDivineIsLearned)
            await PerformAttack(() => Encounter.DivineAttack(playerState, this), sounds.PlayDivineAttackSound);
    }

    private async void buttonDodgeJab_Click(object sender, EventArgs e)
    {
        await DodgeJabAttack();
    }
    private async void buttonRoarAttack_Click(object sender, EventArgs e)
    {
        await RoarAttack();
    }
    private async void buttonDivine_Click(object sender, EventArgs e)
    {
        await DivineAttack();
    }

    private void buttonLearnTechnique_Click(object sender, EventArgs e)
    {
        LearnTechniqueAsync();
    }

    public async Task LearnTechniqueAsync()
    {
        if (StoryProgress.playerIsInTown && !storyProgress.Act1BossDefeatedFlag && storyProgress.Act1ArtsTeacherIsAvailable)
        {
            if (playerState.Player.GoldInPocket >= Player.PriceToLearnTechnique)
            {
                playerState.Player.GoldInPocket -= Player.PriceToLearnTechnique;

                switch (playerState.Player.advanceTechnique)
                {
                    case 0:
                        playerState.Player.techniqueBloodLustIsLearned = true;
                        txtBox_Town.Text = "After many hours of training you have learned the Bloodlust technique. Use it with care.";
                        buttonBloodLust.Show();
                        break;
                    case 1:
                        playerState.Player.techniqueDodgeJabIsLearned = true;
                        txtBox_Town.Text = "After many hours of training you have learned the Dodge Jab technique. A way to angle the sword after dodging an attack.";
                        buttonDodgeJab.Show();
                        break;
                    case 2:
                        playerState.Player.techniqueRoarIsLearned = true;
                        txtBox_Town.Text = "After many hours of training you have learned the Roar technique. A battle cry that boosts your stats for a period.";
                        buttonRoarAttack.Show();
                        break;
                    case 3:
                        playerState.Player.techniqueDivineIsLearned = true;
                        txtBox_Town.Text = "After many hours of training you have learned the Divine technique - a sacred plea for aid in your most desperate hour.";
                        buttonDivine.Show();
                        break;
                }
                playerState.Player.advanceTechnique += 1;
                Player.PriceToLearnTechnique *= 4;
                buttonLearnTechnique.Text = $"Learn {Player.PriceToLearnTechnique}G";
                UpdatePlayerLabels();
                sounds.PlayAct1ArtsTeacher();
                storyProgress.Act1ArtsTeacherIsAvailable = false;
                buttonLearnTechnique.Hide();

                await Task.Delay(7280);
                pictureBoxAct1ArtsTeacher.Hide();
            }
            else
            {
                sounds.PlayAct1ArtsTeacherNo();
            }
        }
    }

    public void StartAct1Quest1()
    {
        quests.StartAct1Quest1();
    }
    public void StartAct4Quest1()
    {
        quests.StartAct4Quest1();
    }

    private void labelAct1Quest1_Click(object sender, EventArgs e)
    {
        StartAct1Quest1();
    }
    private void labelAct4Q1_Click(object sender, EventArgs e)
    {
        StartAct4Quest1();
    }

    private void buttonAct1Quest1Continue_Click(object sender, EventArgs e)
    {
        Quest1ContinueDialog();
    }

    private void Quest1ContinueDialog()
    {
        quests.ContinueAct1Quest1Dialogue();
    }

    private void buttonAct1Q1Town_Click(object sender, EventArgs e)
    {
        ReturnToTownFromQuests();
    }
    private void buttonAct4Q1Town_Click(object sender, EventArgs e)
    {
        ReturnToTownFromQuests();
    }

    public void ReturnToTownFromQuests()
    {
        quests.ReturnToTownFromQuest();
    }

    private void buttonStartModifiers_Click(object sender, EventArgs e)
    {
        OpenModifierPopupWindow();
    }

    public void OpenModifierPopupWindow()
    {
        if (!PlayGameHasBeenPressed)
        {
            if (!_windowModifier.Visible)
            {
                _windowModifier.ShowDialog(); // Opens the popup
            }
            else
            {
                _windowModifier.Close();
            }
        }
    }


}


