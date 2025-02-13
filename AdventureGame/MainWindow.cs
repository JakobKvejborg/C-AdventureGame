using OpenTK.Windowing.Common.Input;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Media;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using Color = System.Drawing.Color;

namespace AdventureGame;

public partial class MainWindow : Form
{
    internal PlayerState _playerState;
    private bool IsAttackOnCooldown;
    private ModifierProcessor _modifierProcessor;
    private MonsterContainer _monsterContainer = new MonsterContainer();
    private ItemContainer _itemContainer = new ItemContainer();
    private StoryProgress _storyProgress;
    private TechniquesTrainer _techniquesTrainer;
    private AttackMoves _attacks;
    PopupWindowModifier _windowModifier;

    private bool CooldownOnSound;
    public List<Panel> panelsList;
    public int PanelsIndex;
    private Random random = new Random();
    ImageSetter _imageSetter;
    MusicAndSound _sounds = new MusicAndSound();
    bool IsContinueOnCooldown; // Prevents the player from spamming Continue too fast
    public bool IsInventoryOpen { get; set; } = false;
    public bool PlayGameHasBeenPressed { get; set; } = false;
    bool EnabledAct1TechniqueTeacher;
    bool OneTimeBool;
    bool OneTimeBool2;
    bool OneTimeBool3;
    bool OneTimeBool4;
    public bool IsReturnToTownEnabled = true;
    public bool IsButtonContinueEnabled = true;
    private QuestManager _quests;
    private Controller _controller;
    private ReforgeItemStat _reforge;
    private CustomControlStyles _styles;
    private DimOverlay _overlay;
    private PlayVideos _videos;

    public MainWindow()
    {
        InitializeComponent();
        this.DoubleBuffered = true; // helps flickering
        _playerState = new PlayerState();
        panelsList = new List<Panel>();
        _modifierProcessor = new ModifierProcessor(_playerState, this);
        _videos = new PlayVideos(this);
        _storyProgress = new StoryProgress(this, _sounds, _videos);
        _techniquesTrainer = new TechniquesTrainer(_playerState, _storyProgress, this, _sounds);
        _attacks = new AttackMoves(_playerState, this, _sounds);
        _imageSetter = new ImageSetter(this);
        _controller = new Controller(_playerState, this, _techniquesTrainer); // Initialize controller
        _quests = new QuestManager(this, _imageSetter, _storyProgress);
        _reforge = new ReforgeItemStat();
        _styles = new CustomControlStyles();
        _overlay = new DimOverlay();
        _windowModifier = new PopupWindowModifier(_modifierProcessor, this, _styles);
        UpdatePlayerLabels();
        panelTown.Location = new Point(0, 0); // Example: position it at the top-left corner
        panelTown.Size = new Size(400, 300);  // Example: set a proper size to make it visible
        panelTown.BringToFront();
        this.Controls.Add(panelTown);

        CustomStylesForControls(); // Custom button looks

        MakeHeroBagBackgroundTrulyTransparent(); // this method makes the picturebox HeroBag have an truly invisible background
        MakeInventoryBackgroundTrulyTransparent();

        // Event that listens for player levelup
        _playerState.Player.LevelUpEvent += OnPlayerLevelUp;

        buttonPlayGame.MouseEnter += buttonPlayGame_MouseEnter; // Button Play Game Color
        buttonPlayGame.MouseLeave += buttonPlayGame_MouseLeave;

        this.KeyUp += MainWindow_KeyUp;

        // Makes the GuardAttackButton glow when the player is on low health
        buttonGuard.Paint += GlowingButton_Paint;
        buttonSwiftAttack.Paint += GlowingDodgeButton_Paint;

        // Make the window non-reziable
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;

        // Method to make the Game Title change colors slowly
        //FadeTitle();
        this.KeyPreview = true; // prevents the buttons from gaining unwanted focus

        // Subscribe to focus events (used for dimming outside the program)
        this.Activated += MainWindow_Activated;
        this.Deactivate += MainWindow_Deactivate;

        SetInvisbleCompassLabels();
        SetInisibleEquippedItemsLabels();

        comboBoxInventory.SelectedIndexChanged += ComboBoxInventory_SelectedIndexChanged; // event that listens when index is changed

        // Set up a timer to poll controller state every 50ms // TODO TEST if actually needed
        var controllerPollTimer = new System.Windows.Forms.Timer
        {
            Interval = 50 // Poll every 50 ms
        };
        controllerPollTimer.Tick += (sender, e) => _controller.UpdateControllerState();
        controllerPollTimer.Start();
    }

    private void MainWindow_Activated(object sender, EventArgs e)
    {
        // Ensure the overlay is shown when the main window gains focus
        if (!_overlay.Visible)
        {
            _overlay?.Show();
        }
    }

    private void MainWindow_Deactivate(object sender, EventArgs e)
    {
        // Hide the overlay when the window loses focus
        if (_overlay.Visible)
        {
            _overlay?.Hide();
        }
    }

    private void MainWindow_Click(object sender, EventArgs e)
    {
        // Toggle the overlay's visibility on click
        _overlay.Visible = !_overlay.Visible;
    }


    private void CustomStylesForControls()
    {
        _styles.BlackButtonWhiteText(btn_attack);
        _styles.BlackButtonWhiteText(buttonSwiftAttack);
        _styles.BlackButtonWhiteText(buttonBloodLust);
        _styles.BlackButtonWhiteText(buttonRoarAttack);
        _styles.BlackButtonWhiteText(buttonDivine);
        _styles.BlackButtonWhiteText(buttonGuard);

        _styles.CoolRedShadow(buttonUpgradeItem);
        _styles.CoolRedShadow(btn_continue);
        _styles.CoolRedShadow(buttonReturnToTown);
        _styles.CoolRedShadow(btn_Continuetown);
        _styles.CoolRedShadow(buttonTalkMage);
        _styles.CoolRedShadow(buttonAct1Q1Town);
        _styles.CoolRedShadow(buttonAct1Quest1Continue);
        _styles.CoolRedShadow(buttonAct2Q1Continue);
        _styles.CoolRedShadow(buttonAct2Q1Town);
        _styles.CoolRedShadow(buttonAct3Q1Continue);
        _styles.CoolRedShadow(buttonAct3Q1Town);
        _styles.CoolRedShadow(buttonAct4Q1Town);
        _styles.CoolRedShadow(buttonAct4Quest1Continue);

        _styles.CoolRedShadow(buttonEquipUnequip);
        _styles.CoolRedShadow(buttonDiscardItem);

        _styles.CoolRedShadow(buttonHeal);
        _styles.CoolRedShadow(buttonLearnTechnique);
        _styles.CoolRedShadow(buttonReforge);
        _styles.CoolRedShadow(buttonReforgeStat);

        _styles.CoolRedShadowComboBox(comboBoxInventory);
        _styles.CoolRedShadowComboBox(comboBoxUpgradeItems);
        _styles.CoolRedShadowComboBox(comboBoxAct3Q1Frog);

        _styles.CoolRedShadowListView(listViewItemStatsFrog);
    }

    private void ComboBoxInventory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboboxInventorySetInfoLabel();
    }

    // A method for making a button glow (when the player is on low health)
    private void GlowingButton_Paint(object sender, PaintEventArgs e)
    {
        Button btn = (Button)sender;

        // Check if the player's health is low and the GuardBuff is not active
        if (_playerState.Player.CurrentHealth <= _playerState.Player.PlayerIsOnLowHealth && !_playerState.Player.GuardBuffIsActive)
        {
            // Create a glow effect around the button
            using (Pen glowPen = new Pen(Color.DeepSkyBlue, 2))
            {
                glowPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
                Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                e.Graphics.DrawRectangle(glowPen, rect);
            }
        }
    }

    // A method for making a button glow (when the player dodges)
    private void GlowingDodgeButton_Paint(object sender, PaintEventArgs e)
    {
        Button btn = (Button)sender;

        // Check if the player dodged
        if (Encounter.PlayerDodgedFlag)
        {
            // Create a glow effect around the button
            using (Pen glowPen = new Pen(Color.DeepSkyBlue, 2))
            {
                glowPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
                Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                e.Graphics.DrawRectangle(glowPen, rect);
            }
        }
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
        buttonSwiftAttack.Hide();
        buttonRoarAttack.Hide();
        buttonDivine.Hide();
        buttonGuard.Hide();
        panelAct1Quest1.Hide();
        panelAct4Quest1.Hide();
        panelAct3Q1.Hide();
        panelPopupInventoryInfo.Hide();
        pictureBoxDragonEggs.Hide();
        labelDragonEggs.Hide();
        labelAct4Q1.Hide();
        labelAct3Q1.Hide();
        buttonTalkMage.Hide();
        panelXboxControlsLayout.Hide();
        panelReforgeItemFrog.Hide();
        pictureBoxAct5Hero.Hide();
        pictureBoxRuby.Hide();
        panelAct2Q1.Hide();
        labelAct2Q1.Hide();
        pictureBoxFrozenLily.Hide();
        labelAct5Q1.Hide();
        panelAnyVideo.Hide();
        #endregion
    }

    private void MakeHeroBagBackgroundTrulyTransparent()
    {
        pictureBoxHero.Controls.Add(pictureBoxHeroBag);
        pictureBoxHeroBag.Location = new Point(210, 300);
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

    //async void FadeTitle()
    //{
    //    Color startColor = Color.FromArgb(128, 3, 3);
    //    Color endColor = Color.Red;
    //    int steps = 140;  // Number of steps for the color transition

    //    for (int i = 0; i < steps; i++)
    //    {
    //        // Interpolate between startColor and endColor
    //        int r = startColor.R + (endColor.R - startColor.R) * i / steps;
    //        int g = startColor.G + (endColor.G - startColor.G) * i / steps;
    //        int b = startColor.B + (endColor.B - startColor.B) * i / steps;

    //        // Apply the interpolated color to the label
    //        labelGameTitle.ForeColor = Color.FromArgb(r, g, b);

    //        // Delay to make the transition smooth
    //        await Task.Delay(40);
    //    }
    //    // Optionally loop the effect
    //    FadeTitle();
    //}

    public static async Task ShakeMonsterPicturebox(Control control, Control progressBarMonsterHP, int duration = 80, int shakeAmount = 5)
    {
        if (Encounter.Monster == null) { return; }

        // Store the original locations of the controls
        var originalLocationControl = control.Location;
        var originalLocationProgressBar = progressBarMonsterHP.Location;
        var rand = new Random();

        int shakeTime = 0;

        // Shake the controls for the specified duration
        while (shakeTime < duration)
        {
            // Generate random offsets within the shake range
            int offsetX = rand.Next(-shakeAmount, shakeAmount + 1);
            int offsetY = rand.Next(-shakeAmount, shakeAmount + 1);

            // Apply the shake effect to the control
            control.Location = new Point(originalLocationControl.X + offsetX, originalLocationControl.Y + offsetY);

            if (Encounter.Monster.MonsterImage == null)
            {
                // Apply the shake effect to the monster HP bar
                int offsetXBar = rand.Next(-shakeAmount, shakeAmount + 1);
                int offsetYBar = rand.Next(-shakeAmount, shakeAmount + 1);
                progressBarMonsterHP.Location = new Point(originalLocationProgressBar.X + offsetXBar, originalLocationProgressBar.Y + offsetYBar);
            }

            // Redraw the controls to apply background updates
            control.Invalidate();
            control.Update();

            if (Encounter.Monster.MonsterImage == null)
            {
                progressBarMonsterHP.Invalidate();
                progressBarMonsterHP.Update();
            }

            // Wait for a short period of time before the next shake
            await Task.Delay(20); // Adjust delay for faster or slower shakes

            shakeTime += 20;
        }

        // Restore the original positions after shaking
        control.Location = originalLocationControl;

        if (Encounter.Monster.MonsterImage == null)
        {
            progressBarMonsterHP.Location = originalLocationProgressBar;
        }
    }

    public void OnPlayerLevelUp()
    {
        textBoxEncounter.AppendText($"\r\nYou have leveled up to level {_playerState.Player.Level}!");
        UpdatePlayerLabels();
        UpdatePlayerHealthBar();
        _sounds.PlayLevelUpSound();
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
                task = SwiftAttack();
                return true;
            case Keys.D4:
                task = RoarAttack();
                return true;
            case Keys.D5:
                task = DivineAttack();
                return true;
            case Keys.D6:
                GuardAttack();
                return true;
            case Keys.Enter:
                EnterKeyPressed();
                return true;
            case Keys.Escape:
                if (_videos.IntroVideoIsPlaying)
                {
                    _videos.SkipIntroVid();
                }
                else
                {
                    _overlay?.Close();
                    Application.Exit();
                }
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
                ChooseItemToReforge();
                return true;
            case Keys.E:
                if (IsInventoryOpen) { ButtonEquipItems(); }
                return true;
            case Keys.T:
                if (IsInventoryOpen) { ButtonDiscardItem(); }
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
                return true;
            case Keys.L:
                UpgradeItem();
                task = _techniquesTrainer.LearnTechniqueAsync();
                TalkToMageAct4();
                ReforgeItemStatFrog();
                return true;
            case Keys.Y:
                StartQuests();
                return true;
            case Keys.Tab:
                InventoryPanelPopupInfoShow();
                return true; // Indicate that the key was handled
            case Keys.M:
                _sounds.MuteAllMusic();
                OpenModifierPopupWindow();
                return true;
            default:
                return base.ProcessCmdKey(ref msg, keyData); // Let the base method handle other keys
        }
    }

    public void StartQuests()
    {
        StartAct1Quest1();
        StartAct4Quest1();
        StartAct3Quest1();
        StartAct2Quest1();
        StartAct5Quest1();
    }

    public void KeysDown()
    {
        ScrollTextBox(textBoxEncounter, 1);
        ScrollTextBox(textBoxAct1Quest1, 1);
        ScrollTextBox(textBoxAct3Q1, 1);
        ScrollTextBox(textBoxAct4Quest1, 1);
        ScrollTextBox(txtBox_Town, 1);
        ScrollTextBox(textBoxAct2Q1, 1);

        if (IsInventoryOpen)
        {
            if (comboBoxInventory.Items.Count > 0)
            {
                comboBoxInventory.SelectedIndex = (comboBoxInventory.SelectedIndex + 1) % comboBoxInventory.Items.Count;
            }
        }

        ScrollDownComboboxSmith();
        ScrollDownComboboxFrog();
        ScrollDownViewListFrog();
    }

    private void ScrollDownViewListFrog()
    {
        if (panelReforgeItemFrog.Visible == true)
        {
            // Ensure there's at least one item in the list view
            if (listViewItemStatsFrog.Items.Count > 0)
            {
                // Get the currently selected index, or -1 if no item is selected
                int currentIndex = listViewItemStatsFrog.SelectedIndices.Count > 0 ? listViewItemStatsFrog.SelectedIndices[0] : -1;

                // If there are no selected items, start from the first item
                if (currentIndex == -1)
                {
                    currentIndex = 0;
                    listViewItemStatsFrog.Items[currentIndex].Selected = true; // Select the first item if none are selected
                    listViewItemStatsFrog.EnsureVisible(currentIndex);        // Make sure the item is visible
                }
                else
                {
                    // Calculate the new index, ensuring it's within bounds
                    int newIndex = currentIndex + 1; // Move down by one
                    if (newIndex >= listViewItemStatsFrog.Items.Count)
                    {
                        newIndex = 0; // Wrap around if it goes past the last item
                    }

                    // Deselect the current item and select the new item
                    if (currentIndex != newIndex)
                    {
                        listViewItemStatsFrog.Items[currentIndex].Selected = false; // Deselect the current item
                        listViewItemStatsFrog.Items[newIndex].Selected = true;     // Select the next item
                        listViewItemStatsFrog.EnsureVisible(newIndex);             // Make sure the item is visible
                    }
                }
            }
        }
    }

    private void ScrollDownComboboxSmith()
    {
        if (StoryProgress.playerIsInTown && _storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 2) // act 2 smith
        {
            if (comboBoxUpgradeItems.Items.Count > 0) // Scrolls through upgradable items
                comboBoxUpgradeItems.SelectedIndex = (comboBoxUpgradeItems.SelectedIndex + 1) % comboBoxUpgradeItems.Items.Count;
        }
    }

    private void ScrollDownComboboxFrog()
    {
        if (_quests.IsInsideQuestPanel && _storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 3 && panelReforgeItemFrog.Visible == false) // act 3 froggy boi
        {
            if (comboBoxAct3Q1Frog.Items.Count > 0) // Scrolls through upgradable items
                comboBoxAct3Q1Frog.SelectedIndex = (comboBoxAct3Q1Frog.SelectedIndex + 1) % comboBoxAct3Q1Frog.Items.Count;
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
        ScrollTextBox(textBoxEncounter, -1);
        ScrollTextBox(textBoxAct1Quest1, -1);
        ScrollTextBox(textBoxAct3Q1, -1);
        ScrollTextBox(textBoxAct4Quest1, -1);
        ScrollTextBox(txtBox_Town, -1);
        ScrollTextBox(textBoxAct2Q1, -1);

        if (IsInventoryOpen)
        {
            if (comboBoxInventory.Items.Count > 0)
            {
                comboBoxInventory.SelectedIndex = (comboBoxInventory.SelectedIndex - 1 + comboBoxInventory.Items.Count) % comboBoxInventory.Items.Count;
            }
        }

        ScrollUpComboboxSmith();
        ScrollUpComboboxFrog();
        ScrollUpViewListFrog();

    }

    private void ScrollUpComboboxFrog()
    {
        if (_quests.IsInsideQuestPanel && _storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 3 && panelReforgeItemFrog.Visible == false) // Act 3 froggy boi
        {
            if (comboBoxAct3Q1Frog.Items.Count > 0)
            {
                comboBoxAct3Q1Frog.SelectedIndex = (comboBoxAct3Q1Frog.SelectedIndex - 1 + comboBoxAct3Q1Frog.Items.Count) % comboBoxAct3Q1Frog.Items.Count;
            }
        }
    }

    private void ScrollUpComboboxSmith()
    {
        if (StoryProgress.playerIsInTown && _storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 2) // Act 2 smith
        {
            if (comboBoxUpgradeItems.Items.Count > 0)
            {
                comboBoxUpgradeItems.SelectedIndex = (comboBoxUpgradeItems.SelectedIndex - 1 + comboBoxUpgradeItems.Items.Count) % comboBoxUpgradeItems.Items.Count;
            }
        }
    }

    private void ScrollUpViewListFrog()
    {
        if (panelReforgeItemFrog.Visible == true)
        {
            // Ensure there's at least one item in the list view
            if (listViewItemStatsFrog.Items.Count > 0)
            {
                // Get the currently selected index, or -1 if no item is selected
                int currentIndex = listViewItemStatsFrog.SelectedIndices.Count > 0 ? listViewItemStatsFrog.SelectedIndices[0] : -1;

                // If there are no selected items, start from the first item
                if (currentIndex == -1)
                {
                    currentIndex = 0;
                    listViewItemStatsFrog.Items[currentIndex].Selected = true; // Select the first item if none are selected
                    listViewItemStatsFrog.EnsureVisible(currentIndex);        // Make sure the item is visible
                }
                else
                {
                    // Calculate the new index, moving up by one
                    int newIndex = currentIndex - 1; // Move up by one
                    if (newIndex < 0)
                    {
                        newIndex = listViewItemStatsFrog.Items.Count - 1; // Wrap around if it goes past the first item
                    }

                    // Deselect the current item and select the new item
                    if (currentIndex != newIndex)
                    {
                        listViewItemStatsFrog.Items[currentIndex].Selected = false; // Deselect the current item
                        listViewItemStatsFrog.Items[newIndex].Selected = true;     // Select the previous item
                        listViewItemStatsFrog.EnsureVisible(newIndex);             // Make sure the item is visible
                    }
                }
            }
        }
    }

    public void InventoryPanelPopupInfoShow()
    {
        if (IsInventoryOpen && comboBoxInventory.Items.Count > 0 && comboBoxInventory.SelectedItem != null) // TEST TODO
        {
            panelPopupInventoryInfo.Show();
        }
    }

    public void EnterKeyPressed()
    {
        if (_videos.IntroVideoIsPlaying) { _videos.SkipIntroVid(); return; }

        if (!PlayGameHasBeenPressed)
        {
            ButtonPlayGame();
        }
        ButtonContinue();
        HideInventory();
        Quest1ContinueDialog();
        ButtonContinueAct4Q1();
        ButtonContinueAct2Q1();
    }

    public void ButtonPlayGame()
    {
        PlayGameHasBeenPressed = true;
        panelStartScreen.Hide();
        panelEncounter.Show();
        buttonPlayGame.Dispose();
        _sounds.PlayThunderSound();
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
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("swordicon.ico");
                    break;
                case ItemType.Gloves:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("gauntletsicon.ico");
                    break;
                case ItemType.Boots:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("bootsicon.png");
                    break;
                case ItemType.Armor:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("armoricon.png");
                    break;
                case ItemType.Belt:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("belticon.png");
                    break;
                case ItemType.Amulet:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("amuleticon.png");
                    break;
                case ItemType.Leggings:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("leggingsicon.png");
                    break;
                case ItemType.Helmet:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("helmeticon.png");
                    break;
                case ItemType.Shoulders:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("shouldersicon.png");
                    break;
                case ItemType.WeaponLeftHand:
                    pictureBoxInventoryIcon.Image = _imageSetter.GetImagePath("hookicon.png");
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
            if (_playerState.Player.EquippedItems.TryGetValue(itemType, out var item))
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
        // Create and show the dim overlay
        _overlay.Show();

        // Ensure the main window stays on top of the dim overlay
        //this.TopMost = true;
        this.BringToFront();

        HidePanelsEtc();

        // These panelslists decides the order of panels I think
        panelsList.Add(panelIntroVidWMP);
        panelsList.Add(panelEncounter);
        panelsList.Add(panelStartScreen);
        panelsList.Add(panelGameOver);
        panelsList.Add(panelTown);

        panelsList[PanelsIndex].BringToFront();
        labelInventoryItemInfo.Text = null;
        _imageSetter.SetAct1Quest1BackgroundImage();
        _imageSetter.SetAct3Q1BackgroundImage();
        buttonUpgradeItem.Text = $"{Item.CostToUpgrade}G";

        _imageSetter.SetAct2SmithPictureBoxImage();

        _sounds.SetListOfSounds();

        // Play opening intro video movie
        try
        {
            _videos.PlayOpeningIntroVid();
            _videos.IntroVideoIsPlaying = true;
        }
        catch (FileNotFoundException)
        {
            throw new Exception("The intro video media file was not found.");
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Close the overlay when the main form is closing
        _overlay?.Close();
        base.OnFormClosing(e);
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
            textBoxEncounter.Text = $"You threw away the item {item.Name}.";
            RemoveItemFromComboboxInventory(item);
            UpdatePlayerLabels();
        }
    }
    private void buttonPlayGame_Click(object sender, EventArgs e)
    {
        ButtonPlayGame();
    }

    public void ButtonWest()
    {
        if (StoryProgress.playerIsInTown == true)
        {
            panelTown.Hide();
            panelEncounter.Show();
            if (StoryProgress.WhichActIsThePlayerIn == 1)
            {
                _storyProgress.StoryState = 100; // repeated encounters west act 1
            }
            if (StoryProgress.WhichActIsThePlayerIn == 2)
            {
                _storyProgress.StoryState = 102; // repeated encounters west act 2
            }
            if (StoryProgress.WhichActIsThePlayerIn == 3)
            {
                _storyProgress.StoryState = 104; // repeated encounters west act 3
            }
            if (StoryProgress.WhichActIsThePlayerIn == 4)
            {
                _storyProgress.StoryState = 106; // repeated encounters west act 3
            }
            if (StoryProgress.WhichActIsThePlayerIn == 5)
            {
                _storyProgress.StoryState = 108; // repeated encounters west act 3
            }
            _storyProgress.ProgressStory();
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
                _storyProgress.StoryState = 101; // repeated encounters east act 1
            }
            if (StoryProgress.WhichActIsThePlayerIn == 2)
            {
                _storyProgress.StoryState = 103; // repeated encounters east act 2
            }
            if (StoryProgress.WhichActIsThePlayerIn == 3)
            {
                _storyProgress.StoryState = 104; // repeated encounters west act 3 // should be 105, design choice
            }
            if (StoryProgress.WhichActIsThePlayerIn == 4)
            {
                _storyProgress.StoryState = 105; // repeated encounters east act 4
            }
            if (StoryProgress.WhichActIsThePlayerIn == 5)
            {
                _storyProgress.StoryState = 109; // repeated encounters east act 4
            }
            _storyProgress.ProgressStory();
        }
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        ButtonContinue();
    }

    public void ButtonContinue()
    {
        if (!IsContinueOnCooldown && IsButtonContinueEnabled && !_quests.IsInsideQuestPanel)
        {
            IsContinueOnCooldown = true;
            _storyProgress.ProgressStory();
            IsContinueOnCooldown = false;

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
            StoryProgress.playerIsInTown = false;

            switch (StoryProgress.WhichActIsThePlayerIn)
            {
                case 1: // Player is in act 1
                    // Act 1 Boss Encounter
                    if (!_storyProgress.Act1BossDefeatedFlag)
                    {
                        Act1BossFight();
                    }

                    break;

                case 2: // Player is in act 2
                    // Act 2 Boss Encounter
                    if (!_storyProgress.Act2BossDefeatedFlag)
                    {
                        Act2BossFight();
                    }
                    else
                    {
                        _storyProgress.StoryState = 14;
                        ButtonContinue();
                        _sounds.PlayAct3Waves();
                        _sounds.PlayAct3Music();
                    }
                    break;

                case 3: // Player is in act 3
                    // Act 3 Boss Encounter
                    if (!_storyProgress.Act3BossDefeatedFlag)
                    {
                        Act3BossFight();
                    }
                    else
                    {
                        _storyProgress.StoryState = 18;
                        ButtonContinue();
                        _sounds.PlayAct4Music();
                    }
                    break;

                case 4: // Player is in act 4
                    _storyProgress.StoryState = 107; // repeated Dragon Egg encounters North
                    ButtonContinue();
                    break;

                case 5: // Player is in act 5
                    DisableReturnToTown();
                    if (!_storyProgress.Act5BossDefeatedFlag)
                    {
                        Act5BossFight();
                    }
                    else
                    {   // Do this if the Act 5 has already been defeated
                        _storyProgress.StoryState = 23;
                        ButtonContinue();
                    }
                    break;

                default:
                    break;
            }
        }
    }

    private void Act1BossFight()
    {
        _sounds.PlayAct1BossSound();
        Encounter.EncounterCompleted += OnAct1BossDefeated;

        buttonReturnToTown.Hide();

        // Start the encounter for Act 1 boss
        Encounter.PerformEncounter(_monsterContainer.ListOfMonstersBossAct1, _itemContainer.weakAmulets, this);

        // Enable the technique teacher if not already done
        if (!OneTimeBool2)
        {
            _storyProgress.Act1ArtsTeacherIsAvailable = true;
            OneTimeBool2 = true;
        }
    }

    private void Act2BossFight()
    {
        buttonReturnToTown.Hide();
        buttonReturnToTown.Enabled = false;
        _sounds.PlayAct2BossSound();

        Encounter.PerformEncounter(_monsterContainer.ListOfMonstersBossAct2, _itemContainer.magicAmulets, this);

        Encounter.EncounterCompleted += OnAct2BossDefeated; // Subscribe to the EncounterCompleted event for the Act 2 boss

        // Enable the technique teacher if not already done
        if (!OneTimeBool)
        {
            _storyProgress.Act1ArtsTeacherIsAvailable = true;
            OneTimeBool = true;
        }
    }

    private void Act3BossFight()
    {
        IsButtonContinueEnabled = false;
        DisableReturnToTown();
        _imageSetter.SetAct3BossBackgroundimage();
        Encounter.PerformEncounter(_monsterContainer.ListOfMonstersBossAct3, _itemContainer.rareAmulets, this);
        Encounter.EncounterCompleted += OnAct3BossDefeated;
        _sounds.PlayAct3Boss();
        if (!OneTimeBool3)
        {
            _storyProgress.Act1ArtsTeacherIsAvailable = true;
            OneTimeBool3 = true;
        }
    }


    private void Act5BossFight()
    {
        IsButtonContinueEnabled = false;

        Encounter.PerformEncounter(_monsterContainer.ListOfMonstersBossAct5, _itemContainer.godlyBossItems, this);
        Encounter.EncounterCompleted += OnAct5BossDefeated;

    }

    private void OnAct1BossDefeated(object sender, EventArgs e)
    {
        StoryProgress.playerIsInTown = false;
        _storyProgress.Act1BossDefeatedFlag = true;
        _storyProgress.StoryState = 8;
        buttonReturnToTown.Hide();
        IsReturnToTownEnabled = false;
        _sounds.StopAct1TownMusic();
        Encounter.EncounterCompleted -= OnAct1BossDefeated; // Unsubscribe from the event to avoid multiple invocations
    }

    private void OnAct2BossDefeated(object sender, EventArgs e)
    {
        StoryProgress.playerIsInTown = false;
        _storyProgress.Act2BossDefeatedFlag = true;
        _storyProgress.StoryState = 13;
        _sounds.StopAct2TownMusic();
        buttonReturnToTown.Enabled = false;
        IsReturnToTownEnabled = false;
        buttonReturnToTown.Hide();
        Encounter.EncounterCompleted -= OnAct2BossDefeated; // Unsubscribe from the event to avoid multiple invocations
    }

    private void OnAct3BossDefeated(object sender, EventArgs e)
    {
        StoryProgress.playerIsInTown = false;
        _storyProgress.Act3BossDefeatedFlag = true;
        _storyProgress.StoryState = 17;
        buttonReturnToTown.Enabled = false;
        IsReturnToTownEnabled = false;
        IsButtonContinueEnabled = true;
        buttonReturnToTown.Hide();
        Encounter.EncounterCompleted -= OnAct3BossDefeated; // Unsubscribe from the event to avoid multiple invocations
    }

    private void OnAct5BossDefeated(object sender, EventArgs e)
    {
        StoryProgress.playerIsInTown = false;
        _storyProgress.Act5BossDefeatedFlag = true;
        _storyProgress.StoryState = 21;
        buttonReturnToTown.Enabled = false;
        IsReturnToTownEnabled = false;
        IsButtonContinueEnabled = true;
        buttonReturnToTown.Hide();
        _storyProgress.Act1ArtsTeacherIsAvailable = true;
        Encounter.EncounterCompleted -= OnAct5BossDefeated; // Unsubscribe from the event to avoid multiple invocations
    }

    public void DisableReturnToTown()
    {
        buttonReturnToTown.Hide();
        buttonReturnToTown.Enabled = false;
        IsReturnToTownEnabled = false;
    }

    private void labelCompassS_Click(object sender, EventArgs e)
    {
        ButtonSouth();
    }

    public void ButtonSouth()
    {
        // Act 1 Quest 1 special encounter
        if (_quests.Act1Quest1EncounterIsActive && !_storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 1 && StoryProgress.playerIsInTown)
        {
            _quests.Act1Quest1EncounterIsActive = false;
            panelTown.Hide();
            panelEncounter.Show();
            _storyProgress.StoryState = 99;
            _storyProgress.ProgressStory();
            _quests.Act1Quest1BoyFound = true;
        }
        if (!_storyProgress.Act1BossDefeatedFlag)
        {
            txtBox_Town.Text = "You cannot turn back now. You must press on, your destiny awaits.";
            return;
        }
        if (_storyProgress.Act1BossDefeatedFlag && StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 2) // if the player is in act2, returns to act1
        {
            _storyProgress.Act1BossDefeatedFlag = false; // This is so the act1boss can be defeated again
            _sounds.PlayAct1TownMusic();
            _storyProgress.StoryState = 6;
            _storyProgress.ProgressStory();
        }
        if (_storyProgress.Act2BossDefeatedFlag && StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 3) // if in act3, returns to act2
        {
            //Act2BossDefeatedFlag = false; // set this if the act2 boss should be encountered more than once
            _storyProgress.StoryState = 12;
            _storyProgress.ProgressStory();
            _sounds.PlayAct2TownMusic();
        }
        if (_storyProgress.Act3BossDefeatedFlag && StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 4) // if the player is in act4, return to act3
        {
            _sounds.PlayAct3Waves();
            _sounds.PlayAct3Music();
            _storyProgress.StoryState = 16;
            _storyProgress.ProgressStory();
        }
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 5)
        {
            _storyProgress.StoryState = 17;
            _storyProgress.ProgressStory();
        }

    }

    private void buttonHeal_Click(object sender, EventArgs e)
    {
        ButtonHeal();
    }

    public async void ButtonHeal()
    {
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn != 3 && StoryProgress.WhichActIsThePlayerIn != 5) // We don't want the player to be able to heal in act 3 and 5 because there's no healer
        {
            if (_playerState.Player.GoldInPocket >= Player.priceToHeal) // the players' gold has to be checked here, due to labels being set
            {
                _playerState.Player.HealPlayer(_playerState);
                UpdatePlayerLabels();
                buttonHeal.Text = $"Heal {Player.priceToHeal.ToString()}G";
                UpdatePlayerHealthBar(); // updates the players health bar after being healed
                if (!CooldownOnSound)
                {
                    switch (StoryProgress.WhichActIsThePlayerIn)
                    {
                        case 1:
                            txtBox_Town.Text = _storyProgress.GetHealingText();
                            _sounds.PlayAct1HealingMusic();
                            break;
                        case 2:
                            txtBox_Town.Text = _storyProgress.GetAct2HealingText();
                            _sounds.PlayAct2HealingSound();
                            break;
                        case 4:
                            txtBox_Town.Text = _storyProgress.GetAct4HealingText();
                            _sounds.PlayAct4HealingSound();
                            break;

                    }
                }
                CooldownOnSound = true;
                await Task.Delay(5000);
                CooldownOnSound = false;
            }
            else
            { // Sounds playing if the player doesn't have enough gold to heal
                if (!CooldownOnSound)
                {
                    switch (StoryProgress.WhichActIsThePlayerIn)
                    {
                        case 1:
                            _sounds.PlayAct1HealingNoGold();
                            txtBox_Town.Text = "\"Is a single coin too much to ask?\"";
                            break;
                        case 2:
                            break;
                        case 4:
                            break;
                    }
                }
            }
        }
    }

    private void btn_Continuetown_Click(object sender, EventArgs e)
    {
        ButtonContinue();
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
            if (_playerState.Player.Level >= item.LevelRequirement && _playerState.Player.Strength >= item.StrengthRequirement)
            {
                _sounds.PlayEquipSound();
                _playerState.Player.EquipItem(item, comboBoxInventory, comboBoxUpgradeItems, comboBoxAct3Q1Frog);
                UpdatePlayerLabels();
                RemoveItemFromComboboxInventory(item); // removes the equipped item from the combobox
                SetHiddenPanelLabelsOnly(item.Type);
                comboBoxUpgradeItems.Items.Add(item);
                comboBoxAct3Q1Frog.Items.Add(item);
                Task task = CheckIfPlayerIsDefeated(); // checks if the player dies from unequipping an item that gives health

                if (item.Type == ItemType.WeaponLeftHand)
                {
                    _imageSetter.SetHeroLeftWeaponPictureBoxImage();
                }
            }
            else
            {
                //textBox1.Text = $"The level requirement to equip {item.Name} is {item.LevelRequirement}, and the " +
                //    $"strength requirement is {item.StrengthRequirement}.";
                textBoxEncounter.Text = $"The requirements to equip {item.Name} are not met.";
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
        if (_playerState.Player.EquippedItems.TryGetValue(itemType, out var item) && item != null)
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
        if (_playerState.Player.EquippedItems.TryGetValue(itemType, out var item) && item != null)

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
        UpgradeItem();
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

    public void UpgradeItem()
    {
        if (StoryProgress.playerIsInTown && _storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 2)
        {
            if (_playerState.Player.HasDragonMageUpgradeForSmith && !OneTimeBool4) // Special onetime-dialog when the player has DragonMageUpgrade
            {
                txtBox_Town.Text = "\"What is this now? Where did you find this?! I can sense powerful magic surrounding this item. Perhaps I can make some use of it...\"";
                OneTimeBool4 = true;
                _sounds.PlaySmithUpgradeRubySound();
                Item.SmithUpgradeMultiplication++;
                _imageSetter.SetAct2SmithUpgradedImage();
                pictureBoxRuby.Hide();
                _storyProgress.Act1ArtsTeacherIsAvailable = true;
                return;
            }

            if (comboBoxUpgradeItems.SelectedItem != null && _playerState.Player.GoldInPocket >= Item.CostToUpgrade)
            {
                Item item = (Item)comboBoxUpgradeItems.SelectedItem;
                if (item.IsItemUpgraded || item.Type == ItemType.Amulet)
                {
                    txtBox_Town.Text = "\"Sorry but no, I can't upgrade this item. Give me another one!\"";
                    _sounds.PlayAct2SmithNo();
                    return;
                }
                _sounds.PlaySmithingSound();
                _playerState.Player.UnequipItem(item, comboBoxInventory, comboBoxUpgradeItems, comboBoxAct3Q1Frog); // unequips the item to prevent stat bugs
                _playerState.Player.GoldInPocket -= Item.CostToUpgrade;
                item.UpgradeItem();
                _sounds.PlayAct2SmithOffer();
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
                txtBox_Town.Text = $"\"Sorry, the best I can do is {Item.CostToUpgrade} gold. No discounts.\"";
                _sounds.PlayAct2SmithNo();
            }
        }
    }

    public void TalkToMageAct4()
    {
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 4)
        {
            _sounds.PlayAct4MageSound();

            if (_playerState.Player.HasDragonMageUpgradeForSmith)
            {
                txtBox_Town.Text = _storyProgress.GetMageDoesntWantAnythingText();
                return;
            }

            if (_playerState.Player.NumberOfDragonEggsInInventory > 2 && !_playerState.Player.HasDragonMageUpgradeForSmith)
            {
                _playerState.Player.NumberOfDragonEggsInInventory -= 3;
                UpdateDragonEggsLabels();
                txtBox_Town.Text = _storyProgress.GetMageText(playerHasDragonEggs: true);
                _playerState.Player.HasDragonMageUpgradeForSmith = true;
                pictureBoxRuby.Show();
            }
            else
            {
                txtBox_Town.Text = _storyProgress.GetMageText(playerHasDragonEggs: false);
            }
        }
    }

    public void UpdateDragonEggsLabels()
    {
        if (_playerState.Player.NumberOfDragonEggsInInventory < 1)
        {
            labelDragonEggs.Text = "";
            pictureBoxDragonEggs.Hide();
            labelDragonEggs.Hide();
        }
        labelDragonEggs.Text = $"{_playerState.Player.NumberOfDragonEggsInInventory}x";
    }

    private void buttonTalkMage_Click(object sender, EventArgs e)
    {
        TalkToMageAct4();
    }

    public async Task CheckIfPlayerIsDefeated()
    {
        if (_playerState.Player.CurrentHealth <= 0)
        {
            await Task.Delay(400);
            _sounds.PlayDeathGameOverSound();
            await Task.Delay(500);
            panelEncounter.Hide();
            panelGameOver.Show();
            await Task.Delay(3500);
            _overlay?.Close();
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
        _sounds.PlayInventorySound();
        IsInventoryOpen = true;
    }

    private void pictureBoxInventory_Click(object sender, EventArgs e)
    {
        HideInventory();
    }

    public void HideInventory()
    {
        pictureBoxInventory.Hide();
        comboBoxInventory.DroppedDown = false;
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
            if (comboBoxInventory.Items.Count > 29) // How many items the inventory can hold max
            {
                textBoxEncounter.Text = "Inventory full.";
                return;
            }

            pictureBoxLoot.Hide();
            Encounter.ItemIsLootetFromMonster(_playerState, this);
            _sounds.PlayLootItemsSound();
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
            if (StoryProgress.WhichActIsThePlayerIn == 1 && !_storyProgress.Act1BossDefeatedFlag)
            {
                _storyProgress.StoryState = 7; // act 1 town
            }
            if (StoryProgress.WhichActIsThePlayerIn == 2)
            {
                _storyProgress.StoryState = 12; // act 2 town
            }
            if (StoryProgress.WhichActIsThePlayerIn == 3)
            {
                _storyProgress.StoryState = 16; // act 3 town
            }
            if (StoryProgress.WhichActIsThePlayerIn == 4)
            {
                _storyProgress.StoryState = 18; // act 4 town
            }
            if (StoryProgress.WhichActIsThePlayerIn == 5)
            {
                _storyProgress.StoryState = 20; // act 5 town
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
        Encounter.DisplayInitialEncounterText(monster, this);

        int monsterMaxHealth = monster.MaxHealth;
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
        labelPlayerDamage.Text = $"Damage: {_playerState.Player.Damage}";
        labelPlayerStrength.Text = $"Strength: {_playerState.Player.Strength}";
        labelPlayerLifeSteal.Text = $"Lifesteal: {_playerState.Player.Lifesteal}%";
        labelPlayerArmor.Text = $"Armor: {_playerState.Player.Armor}";
        labelPlayerDodge.Text = $"{_playerState.Player.DodgeChance}%";
        labelGoldInPocket.Text = $"{_playerState.Player.GoldInPocket}";
        labelLevel.Text = $"Level: {_playerState.Player.Level}";
        labelExperience.Text = $"Exp: {_playerState.Player.Experience}/{_playerState.Player.XpNeededToLevelUp}";
        labelCritChance.Text = $"{_playerState.Player.CritChance}%";
        labelPlayerCritDmg.Text = $"CritDmg: {_playerState.Player.CritDamage}%";
        labelRegeneration.Text = $"Regen: {_playerState.Player.Regeneration}";
    }

    private void UpdatePlayerHealthBar()
    {
        // Setting the progress bar and label player health
        int currentHealth = _playerState.Player.CurrentHealth;
        int maxHealth = _playerState.Player.MaxHealth;

        CheckIfPlayerIsDefeated();
        progressBarPlayerHP.Maximum = maxHealth;
        progressBarPlayerHP.Value = currentHealth;
        labelPlayerHP.Text = $"HP: {currentHealth}/{maxHealth}";
        buttonGuard.Invalidate();
    }

    // This is a method that plays the sounds for the attack, calls the attack methods from Encounter, and handles attack controls
    private async Task PerformAttack(Action attackAction, bool shakeControl = true)
    {
        if (!IsAttackOnCooldown && Encounter.Monster != null)
        {
            IsAttackOnCooldown = true;

            textBoxEncounter.Clear();
            attackAction(); // Executes the specific attack

            // Check if the monster is defeated after the attack
            Encounter.CheckIfMonsterIsDefeated(_playerState, this);

            if (shakeControl)
            {
                await ShakeMonsterPicturebox(pictureBoxMonster1, progressBarMonsterHP);
            }

            await Task.Delay(200); // Increase this delay for a slower attack rate
            IsAttackOnCooldown = false;
        }
    }

    public async Task NormalAttack()
    {
        await PerformAttack(() => _attacks.NormalAttack(), shakeControl: true);
    }

    public async Task BloodLustAttack()
    {
        if (_playerState.Player.techniqueBloodLustIsLearned)
            await PerformAttack(() => _attacks.BloodLustAttack(), shakeControl: true);
    }
    public async Task SwiftAttack()
    {
        if (_playerState.Player.techniqueSwiftIsLearned)
            await PerformAttack(() => _attacks.SwiftAttack(), shakeControl: true);
    }
    public async Task RoarAttack()
    {
        if (_playerState.Player.techniqueRoarIsLearned)
            await PerformAttack(() => _attacks.RoarAttack(), shakeControl: false);
        UpdatePlayerLabels();
    }
    public async Task DivineAttack()
    {
        if (_playerState.Player.techniqueDivineIsLearned)
            await PerformAttack(() => _attacks.DivineAttack(), shakeControl: true);
    }
    public void GuardAttack()
    {
        if (_playerState.Player.techniqueGuardIsLearned)
        {
            _attacks.GuardAttack();
        }
    }

    private async void buttonDodgeJab_Click(object sender, EventArgs e)
    {
        await SwiftAttack();
    }
    private async void buttonRoarAttack_Click(object sender, EventArgs e)
    {
        await RoarAttack();
    }

    private async void buttonDivine_Click(object sender, EventArgs e)
    {
        await DivineAttack();
    }

    private async void btn_attack_Click(object sender, EventArgs e)
    {
        await NormalAttack();
    }

    private async void buttonBloodLust_Click(object sender, EventArgs e)
    {
        await BloodLustAttack();
    }

    private void buttonGuard_Click(object sender, EventArgs e)
    {
        GuardAttack();
    }

    private void buttonLearnTechnique_Click(object sender, EventArgs e)
    {
        Task task = _techniquesTrainer.LearnTechniqueAsync();
    }

    public void StartAct1Quest1()
    {
        _quests.StartAct1Quest1();
    }

    public void StartAct4Quest1()
    {
        _quests.StartAct4Quest1();
    }

    public void StartAct3Quest1()
    {
        _quests.StartAct3Quest1();
    }
    public void StartAct2Quest1()
    {
        _quests.StartAct2Quest1();
    }

    public void StartAct5Quest1()
    {
        _quests.StartAct5Quest1();
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
        _quests.ContinueAct1Quest1Dialogue();
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
        _quests.ReturnToTownFromQuest();
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
                _windowModifier.ShowDialog();
                // Ensure MainWindow has focus after the popup closes
                this.Focus();
            }
            else
            {
                _windowModifier.Close();
            }
        }
    }

    private void buttonReforge_Click(object sender, EventArgs e)
    {
        ChooseItemToReforge();
    }

    // This method picks the selected item in the combobox and adds it to a viewlist so the player can see the stats of the item and choose one of them
    public void ChooseItemToReforge()
    {
        if (panelReforgeItemFrog.Visible == true) // This makes it possible to choose another item to reforge
        {
            panelReforgeItemFrog.Hide();
            return;
        }

        if (_quests.IsInsideQuestPanel && StoryProgress.WhichActIsThePlayerIn == 3 && comboBoxAct3Q1Frog.SelectedItem != null)
        {
            panelReforgeItemFrog.Show();
            listViewItemStatsFrog.Items.Clear();
            if (comboBoxAct3Q1Frog.SelectedItem is Item selectedItem)
            {
                foreach (var prop in typeof(Item).GetProperties())
                {
                    object value = prop.GetValue(selectedItem);

                    // Skip unwanted attributes
                    if (prop.Name == "Name" || prop.Name == "Type" || prop.Name == "CostToUpgrade" ||
                        prop.Name == "IsItemUpgraded" || prop.Name == "SmithUpgradeMultiplication" ||
                        prop.Name == "LevelRequirement" || prop.Name == "StrengthRequirement" ||
                        prop.Name == "IsItemReforged" || value is int intValue && intValue == 0)
                        continue;

                    ListViewItem item = new ListViewItem(new[] { prop.Name, value?.ToString() ?? "N/A" });

                    // Set the Tag property to the selected Item (this links the ListViewItem to the actual Item)
                    item.Tag = selectedItem;

                    // Add the ListViewItem to the ListView
                    listViewItemStatsFrog.Items.Add(item);

                }
            }
        }
    }

    private void buttonReforgeStat_Click(object sender, EventArgs e)
    {
        ReforgeItemStatFrog();
    }

    // This reforges an item stat in Act3Q1 from a stat selected in the viewlist
    public void ReforgeItemStatFrog()
    {
        if (_quests.IsInsideQuestPanel && StoryProgress.WhichActIsThePlayerIn == 3 && panelReforgeItemFrog.Visible == true
            && listViewItemStatsFrog.SelectedItems.Count > 0)
        {
            panelReforgeItemFrog.Hide();
            _sounds.PlayAct3ReforgeFroggy();

            // Player doesn't have enough gold
            if (_playerState.Player.GoldInPocket < ReforgeItemStat.PriceToReforgeFrog)
            {
                textBoxAct3Q1.Text = _storyProgress.GetAct3FrogNoCoinText();
                return;
            }

            textBoxAct3Q1.Text = _storyProgress.GetAct3FrogReforgeText();

            ListViewItem selectedItem = listViewItemStatsFrog.SelectedItems[0];
            Item associatedItem = selectedItem.Tag as Item;

            // Exits if the item already is reforged
            if (associatedItem.IsItemReforged)
            {
                textBoxAct3Q1.Text = _storyProgress.GetAct3FrogItemAlreadyReforgedText();
                return;
            }

            if (associatedItem != null)
            {
                // Unequip the item before reforging
                associatedItem.Name = $"|{associatedItem.Name}";
                _playerState.Player.UnequipItem(associatedItem, comboBoxInventory, comboBoxUpgradeItems, comboBoxAct3Q1Frog);
                _playerState.Player.GoldInPocket -= ReforgeItemStat.PriceToReforgeFrog;
                _sounds.PlayCoinSound();
                UpdatePlayerLabels();

                string statName = selectedItem.SubItems[0].Text; // Stat name (e.g., "Damage", "Health")
                _reforge.ReforgeItemProperty(associatedItem, statName); // Reforging the item stat

                var property = associatedItem.GetType().GetProperty(statName); // Update the ListView to reflect the new value
                if (property != null)
                {
                    object newStatValue = property.GetValue(associatedItem);
                    selectedItem.SubItems[1].Text = newStatValue?.ToString();
                }
            }
        }
    }

    private void buttonAct3Q1Town_Click(object sender, EventArgs e)
    {
        ReturnToTownFromQuests();
    }

    private void labelAct3Q1_Click(object sender, EventArgs e)
    {
        StartAct3Quest1();
    }

    private void buttonAct4Quest1Continue_Click(object sender, EventArgs e)
    {
        ButtonContinueAct4Q1();
    }

    private void ButtonContinueAct4Q1()
    {
        if (StoryProgress.WhichActIsThePlayerIn == 4 && _quests.IsInsideQuestPanel)
        {
            IsReturnToTownEnabled = false;
            _storyProgress.StoryState = 19;
            _storyProgress.ProgressStory();
            _quests.IsInsideQuestPanel = false;
        }
    }

    private void ButtonContinueAct2Q1()
    {
        if (StoryProgress.WhichActIsThePlayerIn == 2 && _quests.IsInsideQuestPanel)
        {
            _quests.FrozenKingEncounter();
        }
    }

    private void buttonAct2Q1Town_Click(object sender, EventArgs e)
    {
        ReturnToTownFromQuests();
    }

    private void buttonAct2Q1Continue_Click(object sender, EventArgs e)
    {
        ButtonContinueAct2Q1();
    }

    private void labelAct2Q1_Click(object sender, EventArgs e)
    {
        StartAct2Quest1();
    }

    private void labelAct5Q1_Click(object sender, EventArgs e)
    {
        StartAct5Quest1();
    }


}


