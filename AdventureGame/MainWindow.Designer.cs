
using System.Runtime.InteropServices;
namespace AdventureGame;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private ToolTip toolTip;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
        toolTip = new ToolTip(components);
        btn_continue = new Button();
        labelCompassE = new Label();
        labelCompassW = new Label();
        buttonReturnToTown = new Button();
        labelCompassN = new Label();
        labelCompassS = new Label();
        buttonHeal = new Button();
        btn_Continuetown = new Button();
        buttonEquipUnequip = new Button();
        buttonDiscardItem = new Button();
        pictureBoxHeroBag = new PictureBox();
        labelPlayerArmor = new Label();
        pictureBoxLoot = new PictureBox();
        buttonUpgradeItem = new Button();
        buttonLearnTechnique = new Button();
        buttonAct1Quest1Continue = new Button();
        buttonAct1Q1Town = new Button();
        comboBoxInventory = new ComboBox();
        buttonAct4Q1Town = new Button();
        buttonAct4Quest1Continue = new Button();
        buttonAct3Q1Town = new Button();
        buttonAct3Q1Continue = new Button();
        buttonTalkMage = new Button();
        buttonReforge = new Button();
        buttonReforgeStat = new Button();
        buttonAct2Q1Town = new Button();
        buttonAct2Q1Continue = new Button();
        buttonDivine = new Button();
        buttonGuard = new Button();
        buttonSwiftAttack = new Button();
        buttonRoarAttack = new Button();
        buttonBloodLust = new Button();
        btn_attack = new Button();
        labelInvisibleWeaponRightHandEquipped = new Label();
        textBoxEncounter = new TextBox();
        labelInventory = new Label();
        progressBarPlayerHP = new ProgressBar();
        labelPlayerHP = new Label();
        labelPlayerDamage = new Label();
        labelPlayerDodge = new Label();
        labelHeroName = new Label();
        labelPlayerStrength = new Label();
        labelPlayerLifeSteal = new Label();
        labelGoldInPocket = new Label();
        labelLevel = new Label();
        labelExperience = new Label();
        panelMonster = new Panel();
        pictureBoxMonster1 = new PictureBox();
        progressBarMonsterHP = new ProgressBar();
        labelMonsterHp = new Label();
        labelMonsterName = new Label();
        labelDragonEggs = new Label();
        pictureBoxDragonEggs = new PictureBox();
        panelEncounter = new Panel();
        pictureBoxFrozenLily = new PictureBox();
        pictureBoxRuby = new PictureBox();
        labelDodgeText = new Label();
        panelPopupHelmet = new Panel();
        labelInfoHelmetEquipped = new Label();
        labelHelmetName = new Label();
        pictureBoxIconHelmet = new PictureBox();
        panelPopupWeaponLeftHand = new Panel();
        labelInfoWeaponLeftHandEquipped = new Label();
        labelWeaponLeftHandName = new Label();
        pictureBoxIconWeaponLeftHand = new PictureBox();
        panelPopupShoulders = new Panel();
        labelShouldersName = new Label();
        pictureBoxIconShoulders = new PictureBox();
        labelInfoShouldersEquipped = new Label();
        labelGold = new Label();
        panelPopupInventoryInfo = new Panel();
        pictureBoxInventoryIcon = new PictureBox();
        labelInventoryItemInfo = new Label();
        labelHpPopup = new Label();
        panelPopupBelt = new Panel();
        labelInfoBeltEquipped = new Label();
        labelBeltName = new Label();
        pictureBoxIconBelt = new PictureBox();
        panelPopupLeggings = new Panel();
        labelInfoLeggingsEquipped = new Label();
        labelLeggingsName = new Label();
        pictureBoxIconLeggings = new PictureBox();
        panelPopupAmulet = new Panel();
        labelInfoAmuletEquipped = new Label();
        labelAmuletName = new Label();
        pictureBoxIconAmulet = new PictureBox();
        panelPopupBoots = new Panel();
        labelInfoBootsEquipped = new Label();
        labelBootsName = new Label();
        pictureBoxIconBoots = new PictureBox();
        labelInvisibleBoots = new Label();
        panelPopupGloves = new Panel();
        labelInfoGlovesEquipped = new Label();
        labelGlovesName = new Label();
        pictureBoxIconGloves = new PictureBox();
        labelInvisibleGloves = new Label();
        panelPopupArmor = new Panel();
        labelInfoArmorEquipped = new Label();
        labelArmorName = new Label();
        pictureBoxIconArmor = new PictureBox();
        labelInvisibleArmor = new Label();
        labelGoldPopup = new Label();
        panelPopupWeaponRightHand = new Panel();
        labelInfoWeaponRightHandEquipped = new Label();
        labelWeaponRightHandName = new Label();
        pictureBoxIconWeaponRightHand = new PictureBox();
        panelInventory = new Panel();
        labelRegeneration = new Label();
        labelCritText = new Label();
        labelCritChance = new Label();
        labelPlayerCritDmg = new Label();
        labelInvisibleAmulet = new Label();
        labelInvisibleLeggings = new Label();
        labelInvisibleWeaponLeftHand = new Label();
        labelInvisibleShoulders = new Label();
        labelInvisibleHelmet = new Label();
        labelInvisibleBelt = new Label();
        pictureBoxHero = new PictureBox();
        pictureBoxInventory = new PictureBox();
        panelTown = new Panel();
        txtBox_Town = new TextBox();
        labelAct2Q1 = new Label();
        labelAct5Q1 = new Label();
        pictureBoxAct5Hero = new PictureBox();
        labelAct4Q1 = new Label();
        labelAct3Q1 = new Label();
        labelAct1Quest1 = new Label();
        pictureBoxAct1ArtsTeacher = new PictureBox();
        comboBoxUpgradeItems = new ComboBox();
        pictureBoxCompass = new PictureBox();
        pictureBoxHealer = new PictureBox();
        pictureBoxAct2Smith = new PictureBox();
        pictureBoxAct4Mage = new PictureBox();
        panelStartScreen = new Panel();
        labelVersionNumber = new Label();
        labelXboxRecommended = new Label();
        pictureBoxXboxLogo = new PictureBox();
        buttonStartModifiers = new Button();
        labelGameAuthorName = new Label();
        buttonPlayGame = new Button();
        labelGameTitle = new Label();
        panelGameOver = new Panel();
        labelGameOverText = new Label();
        panelAct1Quest1 = new Panel();
        textBoxAct1Quest1 = new TextBox();
        panelAct4Quest1 = new Panel();
        textBoxAct4Quest1 = new TextBox();
        panelXboxControlsLayout = new Panel();
        axWMPintroVid = new AxWMPLib.AxWindowsMediaPlayer();
        panelIntroVidWMP = new Panel();
        panelAct3Q1 = new Panel();
        panelReforgeItemFrog = new Panel();
        listViewItemStatsFrog = new ListView();
        columnType = new ColumnHeader();
        columnStat = new ColumnHeader();
        comboBoxAct3Q1Frog = new ComboBox();
        textBoxAct3Q1 = new TextBox();
        panelAct2Q1 = new Panel();
        textBoxAct2Q1 = new TextBox();
        panelAnyVideo = new Panel();
        axWMPAnyVideo = new AxWMPLib.AxWindowsMediaPlayer();
        ((System.ComponentModel.ISupportInitialize)pictureBoxHeroBag).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxLoot).BeginInit();
        panelMonster.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxDragonEggs).BeginInit();
        panelEncounter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxFrozenLily).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxRuby).BeginInit();
        panelPopupHelmet.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconHelmet).BeginInit();
        panelPopupWeaponLeftHand.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconWeaponLeftHand).BeginInit();
        panelPopupShoulders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconShoulders).BeginInit();
        panelPopupInventoryInfo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxInventoryIcon).BeginInit();
        panelPopupBelt.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconBelt).BeginInit();
        panelPopupLeggings.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconLeggings).BeginInit();
        panelPopupAmulet.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconAmulet).BeginInit();
        panelPopupBoots.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconBoots).BeginInit();
        panelPopupGloves.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconGloves).BeginInit();
        panelPopupArmor.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconArmor).BeginInit();
        panelPopupWeaponRightHand.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconWeaponRightHand).BeginInit();
        panelInventory.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxHero).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxInventory).BeginInit();
        panelTown.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct5Hero).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct1ArtsTeacher).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxCompass).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxHealer).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct2Smith).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct4Mage).BeginInit();
        panelStartScreen.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxXboxLogo).BeginInit();
        panelGameOver.SuspendLayout();
        panelAct1Quest1.SuspendLayout();
        panelAct4Quest1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)axWMPintroVid).BeginInit();
        panelIntroVidWMP.SuspendLayout();
        panelAct3Q1.SuspendLayout();
        panelReforgeItemFrog.SuspendLayout();
        panelAct2Q1.SuspendLayout();
        panelAnyVideo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)axWMPAnyVideo).BeginInit();
        SuspendLayout();
        // 
        // btn_continue
        // 
        btn_continue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btn_continue.Location = new Point(10, 118);
        btn_continue.Margin = new Padding(3, 2, 3, 2);
        btn_continue.Name = "btn_continue";
        btn_continue.Size = new Size(125, 40);
        btn_continue.TabIndex = 0;
        btn_continue.Text = "Continue";
        toolTip.SetToolTip(btn_continue, "\"Enter\"");
        btn_continue.UseVisualStyleBackColor = true;
        btn_continue.Click += button1_Click_1;
        // 
        // labelCompassE
        // 
        labelCompassE.AutoSize = true;
        labelCompassE.ForeColor = Color.Transparent;
        labelCompassE.Location = new Point(156, 257);
        labelCompassE.Name = "labelCompassE";
        labelCompassE.Size = new Size(79, 60);
        labelCompassE.TabIndex = 7;
        labelCompassE.Text = "            \r\n            \r\n                        \r\n\r\n";
        toolTip.SetToolTip(labelCompassE, "\"D\"");
        labelCompassE.Click += labelCompassE_Click;
        // 
        // labelCompassW
        // 
        labelCompassW.AutoSize = true;
        labelCompassW.ForeColor = Color.Transparent;
        labelCompassW.Location = new Point(17, 255);
        labelCompassW.Name = "labelCompassW";
        labelCompassW.Size = new Size(76, 60);
        labelCompassW.TabIndex = 6;
        labelCompassW.Text = "            \r\n            \r\n                       \r\n\r\n";
        toolTip.SetToolTip(labelCompassW, "\"A\"");
        labelCompassW.Click += labelCompassW_Click;
        // 
        // buttonReturnToTown
        // 
        buttonReturnToTown.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonReturnToTown.ForeColor = Color.MidnightBlue;
        buttonReturnToTown.Location = new Point(139, 118);
        buttonReturnToTown.Margin = new Padding(3, 2, 3, 2);
        buttonReturnToTown.Name = "buttonReturnToTown";
        buttonReturnToTown.Size = new Size(130, 40);
        buttonReturnToTown.TabIndex = 36;
        buttonReturnToTown.Text = "Town";
        toolTip.SetToolTip(buttonReturnToTown, "\"B\"");
        buttonReturnToTown.UseVisualStyleBackColor = true;
        buttonReturnToTown.Click += buttonReturnToTown_Click;
        // 
        // labelCompassN
        // 
        labelCompassN.AutoSize = true;
        labelCompassN.ForeColor = Color.Transparent;
        labelCompassN.Location = new Point(98, 178);
        labelCompassN.Name = "labelCompassN";
        labelCompassN.Size = new Size(61, 75);
        labelCompassN.TabIndex = 8;
        labelCompassN.Text = "            \r\n            \r\n                  \r\n\r\n\r\n";
        toolTip.SetToolTip(labelCompassN, "\"W\"");
        labelCompassN.Click += labelCompassN_Click;
        // 
        // labelCompassS
        // 
        labelCompassS.AutoSize = true;
        labelCompassS.ForeColor = Color.Transparent;
        labelCompassS.Location = new Point(98, 330);
        labelCompassS.Name = "labelCompassS";
        labelCompassS.Size = new Size(55, 60);
        labelCompassS.TabIndex = 9;
        labelCompassS.Text = "            \r\n            \r\n                \r\n\r\n";
        toolTip.SetToolTip(labelCompassS, "\"S\"");
        labelCompassS.Click += labelCompassS_Click;
        // 
        // buttonHeal
        // 
        buttonHeal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonHeal.Location = new Point(83, 980);
        buttonHeal.Margin = new Padding(3, 2, 3, 2);
        buttonHeal.Name = "buttonHeal";
        buttonHeal.Size = new Size(145, 39);
        buttonHeal.TabIndex = 11;
        buttonHeal.Text = "Healing 2G";
        toolTip.SetToolTip(buttonHeal, "\"H\"");
        buttonHeal.UseVisualStyleBackColor = true;
        buttonHeal.Click += buttonHeal_Click;
        // 
        // btn_Continuetown
        // 
        btn_Continuetown.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btn_Continuetown.Location = new Point(10, 119);
        btn_Continuetown.Margin = new Padding(3, 2, 3, 2);
        btn_Continuetown.Name = "btn_Continuetown";
        btn_Continuetown.Size = new Size(125, 39);
        btn_Continuetown.TabIndex = 13;
        btn_Continuetown.Text = "Continue";
        toolTip.SetToolTip(btn_Continuetown, "\"Enter\"");
        btn_Continuetown.UseVisualStyleBackColor = true;
        btn_Continuetown.Click += btn_Continuetown_Click;
        // 
        // buttonEquipUnequip
        // 
        buttonEquipUnequip.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonEquipUnequip.Location = new Point(3, 64);
        buttonEquipUnequip.Margin = new Padding(3, 2, 3, 2);
        buttonEquipUnequip.Name = "buttonEquipUnequip";
        buttonEquipUnequip.Size = new Size(164, 32);
        buttonEquipUnequip.TabIndex = 21;
        buttonEquipUnequip.Text = "Equip item";
        toolTip.SetToolTip(buttonEquipUnequip, "\"E\"");
        buttonEquipUnequip.UseVisualStyleBackColor = true;
        buttonEquipUnequip.Click += buttonEquipUnequip_Click;
        // 
        // buttonDiscardItem
        // 
        buttonDiscardItem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonDiscardItem.Location = new Point(3, 98);
        buttonDiscardItem.Margin = new Padding(3, 2, 3, 2);
        buttonDiscardItem.Name = "buttonDiscardItem";
        buttonDiscardItem.Size = new Size(164, 33);
        buttonDiscardItem.TabIndex = 4;
        buttonDiscardItem.Text = "Discard item";
        toolTip.SetToolTip(buttonDiscardItem, "\"T\"");
        buttonDiscardItem.UseVisualStyleBackColor = true;
        buttonDiscardItem.Click += buttonDiscardItem_Click;
        // 
        // pictureBoxHeroBag
        // 
        pictureBoxHeroBag.Image = Properties.Resources.bag2;
        pictureBoxHeroBag.Location = new Point(422, 909);
        pictureBoxHeroBag.Margin = new Padding(3, 2, 3, 2);
        pictureBoxHeroBag.Name = "pictureBoxHeroBag";
        pictureBoxHeroBag.Size = new Size(92, 146);
        pictureBoxHeroBag.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxHeroBag.TabIndex = 32;
        pictureBoxHeroBag.TabStop = false;
        toolTip.SetToolTip(pictureBoxHeroBag, "\"I\"");
        pictureBoxHeroBag.Click += pictureBoxHeroBag_Click;
        // 
        // labelPlayerArmor
        // 
        labelPlayerArmor.AutoSize = true;
        labelPlayerArmor.BackColor = Color.Transparent;
        labelPlayerArmor.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelPlayerArmor.ForeColor = Color.White;
        labelPlayerArmor.Location = new Point(29, 384);
        labelPlayerArmor.Name = "labelPlayerArmor";
        labelPlayerArmor.Size = new Size(67, 25);
        labelPlayerArmor.TabIndex = 11;
        labelPlayerArmor.Text = "armor";
        toolTip.SetToolTip(labelPlayerArmor, "The amount of damage blocked from an attack.");
        // 
        // pictureBoxLoot
        // 
        pictureBoxLoot.Image = (Image)resources.GetObject("pictureBoxLoot.Image");
        pictureBoxLoot.Location = new Point(473, 437);
        pictureBoxLoot.Margin = new Padding(3, 2, 3, 2);
        pictureBoxLoot.Name = "pictureBoxLoot";
        pictureBoxLoot.Size = new Size(215, 197);
        pictureBoxLoot.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxLoot.TabIndex = 34;
        pictureBoxLoot.TabStop = false;
        toolTip.SetToolTip(pictureBoxLoot, "\"F\"");
        pictureBoxLoot.Click += pictureBoxLoot_Click;
        // 
        // buttonUpgradeItem
        // 
        buttonUpgradeItem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonUpgradeItem.Location = new Point(673, 658);
        buttonUpgradeItem.Margin = new Padding(3, 2, 3, 2);
        buttonUpgradeItem.Name = "buttonUpgradeItem";
        buttonUpgradeItem.Size = new Size(94, 34);
        buttonUpgradeItem.TabIndex = 15;
        buttonUpgradeItem.Text = "Upgrade";
        toolTip.SetToolTip(buttonUpgradeItem, "\"U\"");
        buttonUpgradeItem.UseVisualStyleBackColor = true;
        buttonUpgradeItem.Click += buttonUpgradeItem_Click;
        // 
        // buttonLearnTechnique
        // 
        buttonLearnTechnique.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonLearnTechnique.Location = new Point(574, 950);
        buttonLearnTechnique.Margin = new Padding(3, 2, 3, 2);
        buttonLearnTechnique.Name = "buttonLearnTechnique";
        buttonLearnTechnique.Size = new Size(145, 39);
        buttonLearnTechnique.TabIndex = 18;
        buttonLearnTechnique.Text = "Learn 10G";
        toolTip.SetToolTip(buttonLearnTechnique, "\"L\"");
        buttonLearnTechnique.UseVisualStyleBackColor = true;
        buttonLearnTechnique.Click += buttonLearnTechnique_Click;
        // 
        // buttonAct1Quest1Continue
        // 
        buttonAct1Quest1Continue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct1Quest1Continue.ForeColor = Color.Black;
        buttonAct1Quest1Continue.Location = new Point(11, 116);
        buttonAct1Quest1Continue.Margin = new Padding(3, 2, 3, 2);
        buttonAct1Quest1Continue.Name = "buttonAct1Quest1Continue";
        buttonAct1Quest1Continue.Size = new Size(124, 41);
        buttonAct1Quest1Continue.TabIndex = 3;
        buttonAct1Quest1Continue.Text = "Continue";
        toolTip.SetToolTip(buttonAct1Quest1Continue, "\"Enter\"");
        buttonAct1Quest1Continue.UseVisualStyleBackColor = true;
        buttonAct1Quest1Continue.Click += buttonAct1Quest1Continue_Click;
        // 
        // buttonAct1Q1Town
        // 
        buttonAct1Q1Town.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct1Q1Town.ForeColor = Color.MidnightBlue;
        buttonAct1Q1Town.Location = new Point(138, 116);
        buttonAct1Q1Town.Margin = new Padding(3, 2, 3, 2);
        buttonAct1Q1Town.Name = "buttonAct1Q1Town";
        buttonAct1Q1Town.Size = new Size(132, 41);
        buttonAct1Q1Town.TabIndex = 37;
        buttonAct1Q1Town.Text = "Town";
        toolTip.SetToolTip(buttonAct1Q1Town, "\"B\"");
        buttonAct1Q1Town.UseVisualStyleBackColor = true;
        buttonAct1Q1Town.Click += buttonAct1Q1Town_Click;
        // 
        // comboBoxInventory
        // 
        comboBoxInventory.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxInventory.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        comboBoxInventory.FormattingEnabled = true;
        comboBoxInventory.Location = new Point(3, 29);
        comboBoxInventory.Margin = new Padding(3, 2, 3, 2);
        comboBoxInventory.Name = "comboBoxInventory";
        comboBoxInventory.Size = new Size(164, 29);
        comboBoxInventory.TabIndex = 2;
        toolTip.SetToolTip(comboBoxInventory, "\"Tab\" & \"Arrows\"");
        // 
        // buttonAct4Q1Town
        // 
        buttonAct4Q1Town.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct4Q1Town.ForeColor = Color.MidnightBlue;
        buttonAct4Q1Town.Location = new Point(140, 116);
        buttonAct4Q1Town.Margin = new Padding(3, 2, 3, 2);
        buttonAct4Q1Town.Name = "buttonAct4Q1Town";
        buttonAct4Q1Town.Size = new Size(129, 41);
        buttonAct4Q1Town.TabIndex = 37;
        buttonAct4Q1Town.Text = "Town";
        toolTip.SetToolTip(buttonAct4Q1Town, "\"B\"");
        buttonAct4Q1Town.UseVisualStyleBackColor = true;
        buttonAct4Q1Town.Click += buttonAct4Q1Town_Click;
        // 
        // buttonAct4Quest1Continue
        // 
        buttonAct4Quest1Continue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct4Quest1Continue.ForeColor = Color.Black;
        buttonAct4Quest1Continue.Location = new Point(10, 116);
        buttonAct4Quest1Continue.Margin = new Padding(3, 2, 3, 2);
        buttonAct4Quest1Continue.Name = "buttonAct4Quest1Continue";
        buttonAct4Quest1Continue.Size = new Size(125, 41);
        buttonAct4Quest1Continue.TabIndex = 3;
        buttonAct4Quest1Continue.Text = "Continue";
        toolTip.SetToolTip(buttonAct4Quest1Continue, "\"Enter\"");
        buttonAct4Quest1Continue.UseVisualStyleBackColor = true;
        buttonAct4Quest1Continue.Click += buttonAct4Quest1Continue_Click;
        // 
        // buttonAct3Q1Town
        // 
        buttonAct3Q1Town.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct3Q1Town.ForeColor = Color.MidnightBlue;
        buttonAct3Q1Town.Location = new Point(140, 118);
        buttonAct3Q1Town.Margin = new Padding(3, 2, 3, 2);
        buttonAct3Q1Town.Name = "buttonAct3Q1Town";
        buttonAct3Q1Town.Size = new Size(128, 39);
        buttonAct3Q1Town.TabIndex = 37;
        buttonAct3Q1Town.Text = "Town";
        toolTip.SetToolTip(buttonAct3Q1Town, "\"B\"");
        buttonAct3Q1Town.UseVisualStyleBackColor = true;
        buttonAct3Q1Town.Click += buttonAct3Q1Town_Click;
        // 
        // buttonAct3Q1Continue
        // 
        buttonAct3Q1Continue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct3Q1Continue.ForeColor = Color.Black;
        buttonAct3Q1Continue.Location = new Point(11, 118);
        buttonAct3Q1Continue.Margin = new Padding(3, 2, 3, 2);
        buttonAct3Q1Continue.Name = "buttonAct3Q1Continue";
        buttonAct3Q1Continue.Size = new Size(127, 39);
        buttonAct3Q1Continue.TabIndex = 3;
        buttonAct3Q1Continue.Text = "Continue";
        toolTip.SetToolTip(buttonAct3Q1Continue, "\"Enter\"");
        buttonAct3Q1Continue.UseVisualStyleBackColor = true;
        // 
        // buttonTalkMage
        // 
        buttonTalkMage.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonTalkMage.Location = new Point(573, 977);
        buttonTalkMage.Margin = new Padding(3, 2, 3, 2);
        buttonTalkMage.Name = "buttonTalkMage";
        buttonTalkMage.Size = new Size(145, 39);
        buttonTalkMage.TabIndex = 22;
        buttonTalkMage.Text = "Talk To Mage";
        toolTip.SetToolTip(buttonTalkMage, "\"L\"");
        buttonTalkMage.UseVisualStyleBackColor = true;
        buttonTalkMage.Click += buttonTalkMage_Click;
        // 
        // buttonReforge
        // 
        buttonReforge.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonReforge.ForeColor = Color.Black;
        buttonReforge.Location = new Point(85, 577);
        buttonReforge.Margin = new Padding(3, 2, 3, 2);
        buttonReforge.Name = "buttonReforge";
        buttonReforge.Size = new Size(103, 29);
        buttonReforge.TabIndex = 39;
        buttonReforge.Text = "Reforge";
        toolTip.SetToolTip(buttonReforge, "\"H\"");
        buttonReforge.UseVisualStyleBackColor = true;
        buttonReforge.Click += buttonReforge_Click;
        // 
        // buttonReforgeStat
        // 
        buttonReforgeStat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonReforgeStat.ForeColor = Color.Black;
        buttonReforgeStat.Location = new Point(67, 259);
        buttonReforgeStat.Margin = new Padding(3, 2, 3, 2);
        buttonReforgeStat.Name = "buttonReforgeStat";
        buttonReforgeStat.Size = new Size(104, 30);
        buttonReforgeStat.TabIndex = 41;
        buttonReforgeStat.Text = "100G";
        toolTip.SetToolTip(buttonReforgeStat, "\"L\"");
        buttonReforgeStat.UseVisualStyleBackColor = true;
        buttonReforgeStat.Click += buttonReforgeStat_Click;
        // 
        // buttonAct2Q1Town
        // 
        buttonAct2Q1Town.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct2Q1Town.ForeColor = Color.MidnightBlue;
        buttonAct2Q1Town.Location = new Point(140, 119);
        buttonAct2Q1Town.Margin = new Padding(3, 2, 3, 2);
        buttonAct2Q1Town.Name = "buttonAct2Q1Town";
        buttonAct2Q1Town.Size = new Size(128, 39);
        buttonAct2Q1Town.TabIndex = 37;
        buttonAct2Q1Town.Text = "Town";
        toolTip.SetToolTip(buttonAct2Q1Town, "\"B\"");
        buttonAct2Q1Town.UseVisualStyleBackColor = true;
        buttonAct2Q1Town.Click += buttonAct2Q1Town_Click;
        // 
        // buttonAct2Q1Continue
        // 
        buttonAct2Q1Continue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct2Q1Continue.ForeColor = Color.Black;
        buttonAct2Q1Continue.Location = new Point(11, 119);
        buttonAct2Q1Continue.Margin = new Padding(3, 2, 3, 2);
        buttonAct2Q1Continue.Name = "buttonAct2Q1Continue";
        buttonAct2Q1Continue.Size = new Size(124, 39);
        buttonAct2Q1Continue.TabIndex = 3;
        buttonAct2Q1Continue.Text = "Continue";
        toolTip.SetToolTip(buttonAct2Q1Continue, "\"Enter\"");
        buttonAct2Q1Continue.UseVisualStyleBackColor = true;
        buttonAct2Q1Continue.Click += buttonAct2Q1Continue_Click;
        // 
        // buttonDivine
        // 
        buttonDivine.BackColor = Color.Gainsboro;
        buttonDivine.Font = new Font("Matura MT Script Capitals", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonDivine.Location = new Point(581, 1129);
        buttonDivine.Margin = new Padding(3, 2, 3, 2);
        buttonDivine.Name = "buttonDivine";
        buttonDivine.Size = new Size(183, 64);
        buttonDivine.TabIndex = 58;
        buttonDivine.Text = "Divine";
        toolTip.SetToolTip(buttonDivine, "\"5\"");
        buttonDivine.UseVisualStyleBackColor = false;
        buttonDivine.Click += buttonDivine_Click;
        // 
        // buttonGuard
        // 
        buttonGuard.BackColor = Color.Gainsboro;
        buttonGuard.Font = new Font("Matura MT Script Capitals", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonGuard.Location = new Point(487, 1064);
        buttonGuard.Margin = new Padding(3, 2, 3, 2);
        buttonGuard.Name = "buttonGuard";
        buttonGuard.Size = new Size(183, 64);
        buttonGuard.TabIndex = 62;
        buttonGuard.Text = "Guard";
        toolTip.SetToolTip(buttonGuard, "\"6\"");
        buttonGuard.UseVisualStyleBackColor = false;
        buttonGuard.Click += buttonGuard_Click;
        // 
        // buttonSwiftAttack
        // 
        buttonSwiftAttack.BackColor = Color.Gainsboro;
        buttonSwiftAttack.Font = new Font("Matura MT Script Capitals", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonSwiftAttack.Location = new Point(394, 1129);
        buttonSwiftAttack.Margin = new Padding(3, 2, 3, 2);
        buttonSwiftAttack.Name = "buttonSwiftAttack";
        buttonSwiftAttack.Size = new Size(183, 64);
        buttonSwiftAttack.TabIndex = 7;
        buttonSwiftAttack.Text = "Swift";
        toolTip.SetToolTip(buttonSwiftAttack, "\"3\"");
        buttonSwiftAttack.UseVisualStyleBackColor = false;
        buttonSwiftAttack.Click += buttonDodgeJab_Click;
        // 
        // buttonRoarAttack
        // 
        buttonRoarAttack.BackColor = Color.Gainsboro;
        buttonRoarAttack.Font = new Font("Matura MT Script Capitals", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonRoarAttack.Location = new Point(299, 1064);
        buttonRoarAttack.Margin = new Padding(3, 2, 3, 2);
        buttonRoarAttack.Name = "buttonRoarAttack";
        buttonRoarAttack.Size = new Size(183, 64);
        buttonRoarAttack.TabIndex = 44;
        buttonRoarAttack.Text = "Roar";
        toolTip.SetToolTip(buttonRoarAttack, "\"4\"");
        buttonRoarAttack.UseVisualStyleBackColor = false;
        buttonRoarAttack.Click += buttonRoarAttack_Click;
        // 
        // buttonBloodLust
        // 
        buttonBloodLust.BackColor = Color.Gainsboro;
        buttonBloodLust.Font = new Font("Matura MT Script Capitals", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonBloodLust.Location = new Point(203, 1129);
        buttonBloodLust.Margin = new Padding(3, 2, 3, 2);
        buttonBloodLust.Name = "buttonBloodLust";
        buttonBloodLust.Size = new Size(187, 64);
        buttonBloodLust.TabIndex = 37;
        buttonBloodLust.Text = "Bloodlust";
        toolTip.SetToolTip(buttonBloodLust, "\"2\"");
        buttonBloodLust.UseVisualStyleBackColor = false;
        buttonBloodLust.Click += buttonBloodLust_Click;
        // 
        // btn_attack
        // 
        btn_attack.BackColor = Color.Gainsboro;
        btn_attack.Font = new Font("Matura MT Script Capitals", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn_attack.ForeColor = SystemColors.ActiveCaptionText;
        btn_attack.Location = new Point(10, 1129);
        btn_attack.Margin = new Padding(3, 2, 3, 2);
        btn_attack.Name = "btn_attack";
        btn_attack.Size = new Size(188, 64);
        btn_attack.TabIndex = 5;
        btn_attack.Text = "Attack";
        toolTip.SetToolTip(btn_attack, "\"Space\" or \"1\"");
        btn_attack.UseVisualStyleBackColor = false;
        btn_attack.Click += btn_attack_Click;
        // 
        // labelInvisibleWeaponRightHandEquipped
        // 
        labelInvisibleWeaponRightHandEquipped.AutoSize = true;
        labelInvisibleWeaponRightHandEquipped.ForeColor = Color.Transparent;
        labelInvisibleWeaponRightHandEquipped.Location = new Point(326, 847);
        labelInvisibleWeaponRightHandEquipped.Name = "labelInvisibleWeaponRightHandEquipped";
        labelInvisibleWeaponRightHandEquipped.Size = new Size(163, 60);
        labelInvisibleWeaponRightHandEquipped.TabIndex = 24;
        labelInvisibleWeaponRightHandEquipped.Text = "            \r\n            \r\n                    \r\n                                                    ";
        labelInvisibleWeaponRightHandEquipped.MouseEnter += labelInvisibleWeaponRightHandEquipped_MouseEnter;
        labelInvisibleWeaponRightHandEquipped.MouseLeave += labelInvisibleWeaponRightHandEquipped_MouseLeave;
        // 
        // textBoxEncounter
        // 
        textBoxEncounter.BackColor = Color.FromArgb(195, 195, 195);
        textBoxEncounter.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxEncounter.Location = new Point(10, 19);
        textBoxEncounter.Margin = new Padding(3, 2, 3, 2);
        textBoxEncounter.Multiline = true;
        textBoxEncounter.Name = "textBoxEncounter";
        textBoxEncounter.ReadOnly = true;
        textBoxEncounter.ScrollBars = ScrollBars.Vertical;
        textBoxEncounter.Size = new Size(767, 95);
        textBoxEncounter.TabIndex = 1;
        textBoxEncounter.Text = "Press ENTER to progress the story.";
        textBoxEncounter.TextChanged += textBox1_TextChanged;
        // 
        // labelInventory
        // 
        labelInventory.BackColor = Color.Transparent;
        labelInventory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelInventory.ForeColor = Color.White;
        labelInventory.Location = new Point(41, 5);
        labelInventory.Name = "labelInventory";
        labelInventory.Size = new Size(91, 20);
        labelInventory.TabIndex = 3;
        labelInventory.Text = "Inventory";
        labelInventory.Click += labelInventory_Click;
        // 
        // progressBarPlayerHP
        // 
        progressBarPlayerHP.ForeColor = Color.Blue;
        progressBarPlayerHP.Location = new Point(29, 234);
        progressBarPlayerHP.Margin = new Padding(3, 2, 3, 2);
        progressBarPlayerHP.Name = "progressBarPlayerHP";
        progressBarPlayerHP.Size = new Size(266, 37);
        progressBarPlayerHP.TabIndex = 8;
        progressBarPlayerHP.Click += progressBar1_Click;
        // 
        // labelPlayerHP
        // 
        labelPlayerHP.AutoSize = true;
        labelPlayerHP.BackColor = Color.Transparent;
        labelPlayerHP.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelPlayerHP.ForeColor = Color.White;
        labelPlayerHP.Location = new Point(29, 209);
        labelPlayerHP.Name = "labelPlayerHP";
        labelPlayerHP.Size = new Size(31, 23);
        labelPlayerHP.TabIndex = 9;
        labelPlayerHP.Text = "HP";
        // 
        // labelPlayerDamage
        // 
        labelPlayerDamage.AutoSize = true;
        labelPlayerDamage.BackColor = Color.Transparent;
        labelPlayerDamage.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelPlayerDamage.ForeColor = Color.White;
        labelPlayerDamage.Location = new Point(26, 283);
        labelPlayerDamage.Name = "labelPlayerDamage";
        labelPlayerDamage.Size = new Size(83, 25);
        labelPlayerDamage.TabIndex = 12;
        labelPlayerDamage.Text = "damage";
        // 
        // labelPlayerDodge
        // 
        labelPlayerDodge.AutoSize = true;
        labelPlayerDodge.BackColor = Color.Transparent;
        labelPlayerDodge.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelPlayerDodge.ForeColor = Color.White;
        labelPlayerDodge.Location = new Point(103, 417);
        labelPlayerDodge.Name = "labelPlayerDodge";
        labelPlayerDodge.Size = new Size(70, 25);
        labelPlayerDodge.TabIndex = 13;
        labelPlayerDodge.Text = "dodge";
        // 
        // labelHeroName
        // 
        labelHeroName.BackColor = Color.Transparent;
        labelHeroName.Font = new Font("Viner Hand ITC", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelHeroName.ForeColor = Color.SteelBlue;
        labelHeroName.Location = new Point(17, 167);
        labelHeroName.Name = "labelHeroName";
        labelHeroName.Size = new Size(105, 35);
        labelHeroName.TabIndex = 14;
        labelHeroName.Text = "Hero";
        // 
        // labelPlayerStrength
        // 
        labelPlayerStrength.AutoSize = true;
        labelPlayerStrength.BackColor = Color.Transparent;
        labelPlayerStrength.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelPlayerStrength.ForeColor = Color.White;
        labelPlayerStrength.Location = new Point(29, 316);
        labelPlayerStrength.Name = "labelPlayerStrength";
        labelPlayerStrength.Size = new Size(87, 25);
        labelPlayerStrength.TabIndex = 15;
        labelPlayerStrength.Text = "strength";
        // 
        // labelPlayerLifeSteal
        // 
        labelPlayerLifeSteal.AutoSize = true;
        labelPlayerLifeSteal.BackColor = Color.Transparent;
        labelPlayerLifeSteal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelPlayerLifeSteal.ForeColor = Color.White;
        labelPlayerLifeSteal.Location = new Point(29, 351);
        labelPlayerLifeSteal.Name = "labelPlayerLifeSteal";
        labelPlayerLifeSteal.Size = new Size(79, 25);
        labelPlayerLifeSteal.TabIndex = 16;
        labelPlayerLifeSteal.Text = "lifesteal";
        // 
        // labelGoldInPocket
        // 
        labelGoldInPocket.AutoSize = true;
        labelGoldInPocket.BackColor = Color.Transparent;
        labelGoldInPocket.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelGoldInPocket.ForeColor = Color.Gold;
        labelGoldInPocket.Location = new Point(250, 417);
        labelGoldInPocket.Name = "labelGoldInPocket";
        labelGoldInPocket.Size = new Size(53, 25);
        labelGoldInPocket.TabIndex = 17;
        labelGoldInPocket.Text = "gold";
        // 
        // labelLevel
        // 
        labelLevel.AutoSize = true;
        labelLevel.BackColor = Color.Transparent;
        labelLevel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelLevel.ForeColor = Color.White;
        labelLevel.Location = new Point(191, 284);
        labelLevel.Name = "labelLevel";
        labelLevel.Size = new Size(57, 25);
        labelLevel.TabIndex = 18;
        labelLevel.Text = "Level";
        // 
        // labelExperience
        // 
        labelExperience.AutoSize = true;
        labelExperience.BackColor = Color.Transparent;
        labelExperience.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelExperience.ForeColor = Color.White;
        labelExperience.Location = new Point(191, 316);
        labelExperience.Name = "labelExperience";
        labelExperience.Size = new Size(109, 25);
        labelExperience.TabIndex = 19;
        labelExperience.Text = "Experience";
        // 
        // panelMonster
        // 
        panelMonster.BackColor = Color.Transparent;
        panelMonster.Controls.Add(pictureBoxMonster1);
        panelMonster.Controls.Add(progressBarMonsterHP);
        panelMonster.Controls.Add(labelMonsterHp);
        panelMonster.Controls.Add(labelMonsterName);
        panelMonster.Location = new Point(396, 170);
        panelMonster.Margin = new Padding(3, 2, 3, 2);
        panelMonster.Name = "panelMonster";
        panelMonster.Size = new Size(357, 624);
        panelMonster.TabIndex = 20;
        // 
        // pictureBoxMonster1
        // 
        pictureBoxMonster1.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBoxMonster1.Location = new Point(6, 113);
        pictureBoxMonster1.Margin = new Padding(3, 2, 3, 2);
        pictureBoxMonster1.Name = "pictureBoxMonster1";
        pictureBoxMonster1.Size = new Size(346, 503);
        pictureBoxMonster1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxMonster1.TabIndex = 21;
        pictureBoxMonster1.TabStop = false;
        // 
        // progressBarMonsterHP
        // 
        progressBarMonsterHP.Location = new Point(43, 64);
        progressBarMonsterHP.Margin = new Padding(3, 2, 3, 2);
        progressBarMonsterHP.Name = "progressBarMonsterHP";
        progressBarMonsterHP.Size = new Size(269, 37);
        progressBarMonsterHP.TabIndex = 2;
        // 
        // labelMonsterHp
        // 
        labelMonsterHp.AutoSize = true;
        labelMonsterHp.BackColor = Color.Transparent;
        labelMonsterHp.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelMonsterHp.ForeColor = Color.White;
        labelMonsterHp.Location = new Point(43, 39);
        labelMonsterHp.Name = "labelMonsterHp";
        labelMonsterHp.Size = new Size(31, 23);
        labelMonsterHp.TabIndex = 1;
        labelMonsterHp.Text = "HP";
        // 
        // labelMonsterName
        // 
        labelMonsterName.AutoSize = true;
        labelMonsterName.BackColor = Color.Transparent;
        labelMonsterName.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelMonsterName.ForeColor = Color.White;
        labelMonsterName.Location = new Point(43, 7);
        labelMonsterName.Name = "labelMonsterName";
        labelMonsterName.Size = new Size(152, 29);
        labelMonsterName.TabIndex = 0;
        labelMonsterName.Text = "monsterName";
        // 
        // labelDragonEggs
        // 
        labelDragonEggs.AutoSize = true;
        labelDragonEggs.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelDragonEggs.ForeColor = Color.IndianRed;
        labelDragonEggs.Location = new Point(142, 205);
        labelDragonEggs.Name = "labelDragonEggs";
        labelDragonEggs.Size = new Size(26, 20);
        labelDragonEggs.TabIndex = 60;
        labelDragonEggs.Text = "1x";
        // 
        // pictureBoxDragonEggs
        // 
        pictureBoxDragonEggs.Image = Properties.Resources.dragonegg;
        pictureBoxDragonEggs.Location = new Point(170, 163);
        pictureBoxDragonEggs.Margin = new Padding(3, 2, 3, 2);
        pictureBoxDragonEggs.Name = "pictureBoxDragonEggs";
        pictureBoxDragonEggs.Size = new Size(59, 67);
        pictureBoxDragonEggs.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxDragonEggs.TabIndex = 59;
        pictureBoxDragonEggs.TabStop = false;
        // 
        // panelEncounter
        // 
        panelEncounter.BackColor = Color.Transparent;
        panelEncounter.BackgroundImage = Properties.Resources.castle;
        panelEncounter.BackgroundImageLayout = ImageLayout.Stretch;
        panelEncounter.Controls.Add(pictureBoxLoot);
        panelEncounter.Controls.Add(textBoxEncounter);
        panelEncounter.Controls.Add(pictureBoxFrozenLily);
        panelEncounter.Controls.Add(pictureBoxRuby);
        panelEncounter.Controls.Add(labelDragonEggs);
        panelEncounter.Controls.Add(pictureBoxDragonEggs);
        panelEncounter.Controls.Add(buttonDivine);
        panelEncounter.Controls.Add(labelDodgeText);
        panelEncounter.Controls.Add(panelPopupHelmet);
        panelEncounter.Controls.Add(panelPopupWeaponLeftHand);
        panelEncounter.Controls.Add(panelPopupShoulders);
        panelEncounter.Controls.Add(labelGold);
        panelEncounter.Controls.Add(panelPopupInventoryInfo);
        panelEncounter.Controls.Add(labelHpPopup);
        panelEncounter.Controls.Add(panelPopupBelt);
        panelEncounter.Controls.Add(panelPopupLeggings);
        panelEncounter.Controls.Add(panelPopupAmulet);
        panelEncounter.Controls.Add(panelPopupBoots);
        panelEncounter.Controls.Add(buttonSwiftAttack);
        panelEncounter.Controls.Add(buttonBloodLust);
        panelEncounter.Controls.Add(buttonRoarAttack);
        panelEncounter.Controls.Add(buttonGuard);
        panelEncounter.Controls.Add(btn_attack);
        panelEncounter.Controls.Add(buttonReturnToTown);
        panelEncounter.Controls.Add(btn_continue);
        panelEncounter.Controls.Add(labelInvisibleBoots);
        panelEncounter.Controls.Add(panelPopupGloves);
        panelEncounter.Controls.Add(labelInvisibleGloves);
        panelEncounter.Controls.Add(panelPopupArmor);
        panelEncounter.Controls.Add(labelInvisibleArmor);
        panelEncounter.Controls.Add(labelGoldPopup);
        panelEncounter.Controls.Add(panelPopupWeaponRightHand);
        panelEncounter.Controls.Add(panelMonster);
        panelEncounter.Controls.Add(panelInventory);
        panelEncounter.Controls.Add(labelHeroName);
        panelEncounter.Controls.Add(labelGoldInPocket);
        panelEncounter.Controls.Add(labelPlayerStrength);
        panelEncounter.Controls.Add(labelExperience);
        panelEncounter.Controls.Add(labelLevel);
        panelEncounter.Controls.Add(labelPlayerDamage);
        panelEncounter.Controls.Add(labelPlayerLifeSteal);
        panelEncounter.Controls.Add(labelPlayerDodge);
        panelEncounter.Controls.Add(labelRegeneration);
        panelEncounter.Controls.Add(labelCritText);
        panelEncounter.Controls.Add(labelCritChance);
        panelEncounter.Controls.Add(labelPlayerCritDmg);
        panelEncounter.Controls.Add(labelPlayerArmor);
        panelEncounter.Controls.Add(labelPlayerHP);
        panelEncounter.Controls.Add(progressBarPlayerHP);
        panelEncounter.Controls.Add(labelInvisibleWeaponRightHandEquipped);
        panelEncounter.Controls.Add(labelInvisibleAmulet);
        panelEncounter.Controls.Add(labelInvisibleLeggings);
        panelEncounter.Controls.Add(labelInvisibleWeaponLeftHand);
        panelEncounter.Controls.Add(labelInvisibleShoulders);
        panelEncounter.Controls.Add(labelInvisibleHelmet);
        panelEncounter.Controls.Add(labelInvisibleBelt);
        panelEncounter.Controls.Add(pictureBoxHero);
        panelEncounter.Controls.Add(pictureBoxHeroBag);
        panelEncounter.Controls.Add(pictureBoxInventory);
        panelEncounter.Dock = DockStyle.Fill;
        panelEncounter.Location = new Point(0, 0);
        panelEncounter.Margin = new Padding(3, 2, 3, 2);
        panelEncounter.Name = "panelEncounter";
        panelEncounter.Size = new Size(789, 1218);
        panelEncounter.TabIndex = 22;
        // 
        // pictureBoxFrozenLily
        // 
        pictureBoxFrozenLily.Image = (Image)resources.GetObject("pictureBoxFrozenLily.Image");
        pictureBoxFrozenLily.Location = new Point(295, 162);
        pictureBoxFrozenLily.Margin = new Padding(3, 2, 3, 2);
        pictureBoxFrozenLily.Name = "pictureBoxFrozenLily";
        pictureBoxFrozenLily.Size = new Size(59, 52);
        pictureBoxFrozenLily.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxFrozenLily.TabIndex = 64;
        pictureBoxFrozenLily.TabStop = false;
        // 
        // pictureBoxRuby
        // 
        pictureBoxRuby.Image = (Image)resources.GetObject("pictureBoxRuby.Image");
        pictureBoxRuby.Location = new Point(233, 163);
        pictureBoxRuby.Margin = new Padding(3, 2, 3, 2);
        pictureBoxRuby.Name = "pictureBoxRuby";
        pictureBoxRuby.Size = new Size(57, 52);
        pictureBoxRuby.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxRuby.TabIndex = 63;
        pictureBoxRuby.TabStop = false;
        // 
        // labelDodgeText
        // 
        labelDodgeText.AutoSize = true;
        labelDodgeText.BackColor = Color.Transparent;
        labelDodgeText.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelDodgeText.ForeColor = Color.White;
        labelDodgeText.Location = new Point(29, 417);
        labelDodgeText.Name = "labelDodgeText";
        labelDodgeText.Size = new Size(77, 25);
        labelDodgeText.TabIndex = 56;
        labelDodgeText.Text = "Dodge:";
        // 
        // panelPopupHelmet
        // 
        panelPopupHelmet.AutoScroll = true;
        panelPopupHelmet.AutoSize = true;
        panelPopupHelmet.BorderStyle = BorderStyle.Fixed3D;
        panelPopupHelmet.Controls.Add(labelInfoHelmetEquipped);
        panelPopupHelmet.Controls.Add(labelHelmetName);
        panelPopupHelmet.Controls.Add(pictureBoxIconHelmet);
        panelPopupHelmet.Location = new Point(5, 467);
        panelPopupHelmet.Margin = new Padding(3, 2, 3, 2);
        panelPopupHelmet.Name = "panelPopupHelmet";
        panelPopupHelmet.Size = new Size(209, 110);
        panelPopupHelmet.TabIndex = 45;
        // 
        // labelInfoHelmetEquipped
        // 
        labelInfoHelmetEquipped.AutoSize = true;
        labelInfoHelmetEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoHelmetEquipped.ForeColor = Color.White;
        labelInfoHelmetEquipped.Location = new Point(2, 22);
        labelInfoHelmetEquipped.Name = "labelInfoHelmetEquipped";
        labelInfoHelmetEquipped.Size = new Size(98, 18);
        labelInfoHelmetEquipped.TabIndex = 1;
        labelInfoHelmetEquipped.Text = "helmetInfo";
        // 
        // labelHelmetName
        // 
        labelHelmetName.AutoSize = true;
        labelHelmetName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelHelmetName.ForeColor = SystemColors.ActiveCaption;
        labelHelmetName.Location = new Point(1, -1);
        labelHelmetName.Name = "labelHelmetName";
        labelHelmetName.Size = new Size(112, 20);
        labelHelmetName.TabIndex = 0;
        labelHelmetName.Text = "HelmetName";
        // 
        // pictureBoxIconHelmet
        // 
        pictureBoxIconHelmet.Image = Properties.Resources.helmeticon;
        pictureBoxIconHelmet.Location = new Point(157, 2);
        pictureBoxIconHelmet.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconHelmet.Name = "pictureBoxIconHelmet";
        pictureBoxIconHelmet.Size = new Size(41, 39);
        pictureBoxIconHelmet.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconHelmet.TabIndex = 3;
        pictureBoxIconHelmet.TabStop = false;
        // 
        // panelPopupWeaponLeftHand
        // 
        panelPopupWeaponLeftHand.AutoSize = true;
        panelPopupWeaponLeftHand.BorderStyle = BorderStyle.Fixed3D;
        panelPopupWeaponLeftHand.Controls.Add(labelInfoWeaponLeftHandEquipped);
        panelPopupWeaponLeftHand.Controls.Add(labelWeaponLeftHandName);
        panelPopupWeaponLeftHand.Controls.Add(pictureBoxIconWeaponLeftHand);
        panelPopupWeaponLeftHand.Location = new Point(7, 935);
        panelPopupWeaponLeftHand.Margin = new Padding(3, 2, 3, 2);
        panelPopupWeaponLeftHand.Name = "panelPopupWeaponLeftHand";
        panelPopupWeaponLeftHand.Size = new Size(206, 121);
        panelPopupWeaponLeftHand.TabIndex = 55;
        // 
        // labelInfoWeaponLeftHandEquipped
        // 
        labelInfoWeaponLeftHandEquipped.AutoSize = true;
        labelInfoWeaponLeftHandEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoWeaponLeftHandEquipped.ForeColor = Color.White;
        labelInfoWeaponLeftHandEquipped.Location = new Point(4, 22);
        labelInfoWeaponLeftHandEquipped.Name = "labelInfoWeaponLeftHandEquipped";
        labelInfoWeaponLeftHandEquipped.Size = new Size(109, 18);
        labelInfoWeaponLeftHandEquipped.TabIndex = 1;
        labelInfoWeaponLeftHandEquipped.Text = "lefthandInfo";
        // 
        // labelWeaponLeftHandName
        // 
        labelWeaponLeftHandName.AutoSize = true;
        labelWeaponLeftHandName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelWeaponLeftHandName.ForeColor = SystemColors.ActiveCaption;
        labelWeaponLeftHandName.Location = new Point(1, -1);
        labelWeaponLeftHandName.Name = "labelWeaponLeftHandName";
        labelWeaponLeftHandName.Size = new Size(130, 20);
        labelWeaponLeftHandName.TabIndex = 0;
        labelWeaponLeftHandName.Text = "LeftHandName";
        // 
        // pictureBoxIconWeaponLeftHand
        // 
        pictureBoxIconWeaponLeftHand.Image = Properties.Resources.hookicon;
        pictureBoxIconWeaponLeftHand.Location = new Point(154, 4);
        pictureBoxIconWeaponLeftHand.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconWeaponLeftHand.Name = "pictureBoxIconWeaponLeftHand";
        pictureBoxIconWeaponLeftHand.Size = new Size(40, 39);
        pictureBoxIconWeaponLeftHand.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconWeaponLeftHand.TabIndex = 3;
        pictureBoxIconWeaponLeftHand.TabStop = false;
        // 
        // panelPopupShoulders
        // 
        panelPopupShoulders.AutoSize = true;
        panelPopupShoulders.BorderStyle = BorderStyle.Fixed3D;
        panelPopupShoulders.Controls.Add(labelShouldersName);
        panelPopupShoulders.Controls.Add(pictureBoxIconShoulders);
        panelPopupShoulders.Controls.Add(labelInfoShouldersEquipped);
        panelPopupShoulders.Location = new Point(252, 552);
        panelPopupShoulders.Margin = new Padding(3, 2, 3, 2);
        panelPopupShoulders.Name = "panelPopupShoulders";
        panelPopupShoulders.Size = new Size(221, 105);
        panelPopupShoulders.TabIndex = 54;
        // 
        // labelShouldersName
        // 
        labelShouldersName.AutoSize = true;
        labelShouldersName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelShouldersName.ForeColor = SystemColors.ActiveCaption;
        labelShouldersName.Location = new Point(1, 2);
        labelShouldersName.Name = "labelShouldersName";
        labelShouldersName.Size = new Size(136, 20);
        labelShouldersName.TabIndex = 4;
        labelShouldersName.Text = "ShouldersName";
        // 
        // pictureBoxIconShoulders
        // 
        pictureBoxIconShoulders.Image = Properties.Resources.shouldersicon;
        pictureBoxIconShoulders.Location = new Point(166, 2);
        pictureBoxIconShoulders.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconShoulders.Name = "pictureBoxIconShoulders";
        pictureBoxIconShoulders.Size = new Size(46, 42);
        pictureBoxIconShoulders.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconShoulders.TabIndex = 3;
        pictureBoxIconShoulders.TabStop = false;
        // 
        // labelInfoShouldersEquipped
        // 
        labelInfoShouldersEquipped.AutoSize = true;
        labelInfoShouldersEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoShouldersEquipped.ForeColor = Color.White;
        labelInfoShouldersEquipped.Location = new Point(2, 29);
        labelInfoShouldersEquipped.Name = "labelInfoShouldersEquipped";
        labelInfoShouldersEquipped.Size = new Size(120, 18);
        labelInfoShouldersEquipped.TabIndex = 1;
        labelInfoShouldersEquipped.Text = "shouldersInfo";
        // 
        // labelGold
        // 
        labelGold.AutoSize = true;
        labelGold.BackColor = Color.Transparent;
        labelGold.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelGold.ForeColor = Color.White;
        labelGold.Location = new Point(190, 417);
        labelGold.Name = "labelGold";
        labelGold.Size = new Size(60, 25);
        labelGold.TabIndex = 51;
        labelGold.Text = "Gold:";
        // 
        // panelPopupInventoryInfo
        // 
        panelPopupInventoryInfo.AutoSize = true;
        panelPopupInventoryInfo.BorderStyle = BorderStyle.Fixed3D;
        panelPopupInventoryInfo.Controls.Add(pictureBoxInventoryIcon);
        panelPopupInventoryInfo.Controls.Add(labelInventoryItemInfo);
        panelPopupInventoryInfo.Location = new Point(549, 917);
        panelPopupInventoryInfo.Margin = new Padding(3, 2, 3, 2);
        panelPopupInventoryInfo.Name = "panelPopupInventoryInfo";
        panelPopupInventoryInfo.Size = new Size(198, 108);
        panelPopupInventoryInfo.TabIndex = 50;
        // 
        // pictureBoxInventoryIcon
        // 
        pictureBoxInventoryIcon.Location = new Point(145, 2);
        pictureBoxInventoryIcon.Margin = new Padding(3, 2, 3, 2);
        pictureBoxInventoryIcon.Name = "pictureBoxInventoryIcon";
        pictureBoxInventoryIcon.Size = new Size(39, 41);
        pictureBoxInventoryIcon.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxInventoryIcon.TabIndex = 3;
        pictureBoxInventoryIcon.TabStop = false;
        // 
        // labelInventoryItemInfo
        // 
        labelInventoryItemInfo.AutoSize = true;
        labelInventoryItemInfo.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInventoryItemInfo.ForeColor = Color.White;
        labelInventoryItemInfo.Location = new Point(1, 3);
        labelInventoryItemInfo.Name = "labelInventoryItemInfo";
        labelInventoryItemInfo.Size = new Size(141, 72);
        labelInventoryItemInfo.TabIndex = 1;
        labelInventoryItemInfo.Text = "inventoryInfo    \r\n\r\n\r\n\r\n";
        // 
        // labelHpPopup
        // 
        labelHpPopup.AutoSize = true;
        labelHpPopup.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelHpPopup.ForeColor = Color.Green;
        labelHpPopup.Location = new Point(296, 217);
        labelHpPopup.Name = "labelHpPopup";
        labelHpPopup.Size = new Size(39, 25);
        labelHpPopup.TabIndex = 49;
        labelHpPopup.Text = "HP";
        // 
        // panelPopupBelt
        // 
        panelPopupBelt.AutoSize = true;
        panelPopupBelt.BorderStyle = BorderStyle.Fixed3D;
        panelPopupBelt.Controls.Add(labelInfoBeltEquipped);
        panelPopupBelt.Controls.Add(labelBeltName);
        panelPopupBelt.Controls.Add(pictureBoxIconBelt);
        panelPopupBelt.Location = new Point(216, 813);
        panelPopupBelt.Margin = new Padding(3, 2, 3, 2);
        panelPopupBelt.Name = "panelPopupBelt";
        panelPopupBelt.Size = new Size(217, 110);
        panelPopupBelt.TabIndex = 48;
        // 
        // labelInfoBeltEquipped
        // 
        labelInfoBeltEquipped.AutoSize = true;
        labelInfoBeltEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoBeltEquipped.ForeColor = Color.White;
        labelInfoBeltEquipped.Location = new Point(5, 27);
        labelInfoBeltEquipped.Name = "labelInfoBeltEquipped";
        labelInfoBeltEquipped.Size = new Size(73, 18);
        labelInfoBeltEquipped.TabIndex = 1;
        labelInfoBeltEquipped.Text = "beltInfo";
        // 
        // labelBeltName
        // 
        labelBeltName.AutoSize = true;
        labelBeltName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelBeltName.ForeColor = SystemColors.ActiveCaption;
        labelBeltName.Location = new Point(5, 4);
        labelBeltName.Name = "labelBeltName";
        labelBeltName.Size = new Size(85, 20);
        labelBeltName.TabIndex = 0;
        labelBeltName.Text = "beltName";
        // 
        // pictureBoxIconBelt
        // 
        pictureBoxIconBelt.Image = Properties.Resources.belticon;
        pictureBoxIconBelt.Location = new Point(158, 5);
        pictureBoxIconBelt.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconBelt.Name = "pictureBoxIconBelt";
        pictureBoxIconBelt.Size = new Size(47, 36);
        pictureBoxIconBelt.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconBelt.TabIndex = 3;
        pictureBoxIconBelt.TabStop = false;
        // 
        // panelPopupLeggings
        // 
        panelPopupLeggings.AutoScroll = true;
        panelPopupLeggings.AutoSize = true;
        panelPopupLeggings.BorderStyle = BorderStyle.Fixed3D;
        panelPopupLeggings.Controls.Add(labelInfoLeggingsEquipped);
        panelPopupLeggings.Controls.Add(labelLeggingsName);
        panelPopupLeggings.Controls.Add(pictureBoxIconLeggings);
        panelPopupLeggings.Location = new Point(229, 934);
        panelPopupLeggings.Margin = new Padding(3, 2, 3, 2);
        panelPopupLeggings.Name = "panelPopupLeggings";
        panelPopupLeggings.Size = new Size(230, 110);
        panelPopupLeggings.TabIndex = 47;
        // 
        // labelInfoLeggingsEquipped
        // 
        labelInfoLeggingsEquipped.AutoSize = true;
        labelInfoLeggingsEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoLeggingsEquipped.ForeColor = Color.White;
        labelInfoLeggingsEquipped.Location = new Point(1, 22);
        labelInfoLeggingsEquipped.Name = "labelInfoLeggingsEquipped";
        labelInfoLeggingsEquipped.Size = new Size(110, 18);
        labelInfoLeggingsEquipped.TabIndex = 1;
        labelInfoLeggingsEquipped.Text = "leggingsInfo";
        // 
        // labelLeggingsName
        // 
        labelLeggingsName.AutoSize = true;
        labelLeggingsName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelLeggingsName.ForeColor = SystemColors.ActiveCaption;
        labelLeggingsName.Location = new Point(1, -1);
        labelLeggingsName.Name = "labelLeggingsName";
        labelLeggingsName.Size = new Size(122, 20);
        labelLeggingsName.TabIndex = 0;
        labelLeggingsName.Text = "leggingsName";
        // 
        // pictureBoxIconLeggings
        // 
        pictureBoxIconLeggings.Image = Properties.Resources.leggingsicon;
        pictureBoxIconLeggings.Location = new Point(185, 3);
        pictureBoxIconLeggings.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconLeggings.Name = "pictureBoxIconLeggings";
        pictureBoxIconLeggings.Size = new Size(34, 40);
        pictureBoxIconLeggings.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconLeggings.TabIndex = 3;
        pictureBoxIconLeggings.TabStop = false;
        // 
        // panelPopupAmulet
        // 
        panelPopupAmulet.AutoSize = true;
        panelPopupAmulet.BorderStyle = BorderStyle.Fixed3D;
        panelPopupAmulet.Controls.Add(labelInfoAmuletEquipped);
        panelPopupAmulet.Controls.Add(labelAmuletName);
        panelPopupAmulet.Controls.Add(pictureBoxIconAmulet);
        panelPopupAmulet.Location = new Point(5, 654);
        panelPopupAmulet.Margin = new Padding(3, 2, 3, 2);
        panelPopupAmulet.Name = "panelPopupAmulet";
        panelPopupAmulet.Size = new Size(207, 100);
        panelPopupAmulet.TabIndex = 43;
        // 
        // labelInfoAmuletEquipped
        // 
        labelInfoAmuletEquipped.AutoSize = true;
        labelInfoAmuletEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoAmuletEquipped.ForeColor = Color.White;
        labelInfoAmuletEquipped.Location = new Point(1, 24);
        labelInfoAmuletEquipped.Name = "labelInfoAmuletEquipped";
        labelInfoAmuletEquipped.Size = new Size(99, 18);
        labelInfoAmuletEquipped.TabIndex = 1;
        labelInfoAmuletEquipped.Text = "AmuletInfo";
        // 
        // labelAmuletName
        // 
        labelAmuletName.AutoSize = true;
        labelAmuletName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelAmuletName.ForeColor = SystemColors.ActiveCaption;
        labelAmuletName.Location = new Point(1, -1);
        labelAmuletName.Name = "labelAmuletName";
        labelAmuletName.Size = new Size(111, 20);
        labelAmuletName.TabIndex = 0;
        labelAmuletName.Text = "AmuletName";
        // 
        // pictureBoxIconAmulet
        // 
        pictureBoxIconAmulet.Image = Properties.Resources.amuleticon;
        pictureBoxIconAmulet.Location = new Point(155, 2);
        pictureBoxIconAmulet.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconAmulet.Name = "pictureBoxIconAmulet";
        pictureBoxIconAmulet.Size = new Size(41, 40);
        pictureBoxIconAmulet.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconAmulet.TabIndex = 3;
        pictureBoxIconAmulet.TabStop = false;
        // 
        // panelPopupBoots
        // 
        panelPopupBoots.AutoSize = true;
        panelPopupBoots.BorderStyle = BorderStyle.Fixed3D;
        panelPopupBoots.Controls.Add(labelInfoBootsEquipped);
        panelPopupBoots.Controls.Add(labelBootsName);
        panelPopupBoots.Controls.Add(pictureBoxIconBoots);
        panelPopupBoots.Location = new Point(229, 1053);
        panelPopupBoots.Margin = new Padding(3, 2, 3, 2);
        panelPopupBoots.Name = "panelPopupBoots";
        panelPopupBoots.Size = new Size(228, 111);
        panelPopupBoots.TabIndex = 29;
        // 
        // labelInfoBootsEquipped
        // 
        labelInfoBootsEquipped.AutoSize = true;
        labelInfoBootsEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoBootsEquipped.ForeColor = Color.White;
        labelInfoBootsEquipped.Location = new Point(0, 24);
        labelInfoBootsEquipped.Name = "labelInfoBootsEquipped";
        labelInfoBootsEquipped.Size = new Size(104, 18);
        labelInfoBootsEquipped.TabIndex = 1;
        labelInfoBootsEquipped.Text = "weaponInfo";
        // 
        // labelBootsName
        // 
        labelBootsName.AutoSize = true;
        labelBootsName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelBootsName.ForeColor = SystemColors.ActiveCaption;
        labelBootsName.Location = new Point(1, -1);
        labelBootsName.Name = "labelBootsName";
        labelBootsName.Size = new Size(100, 20);
        labelBootsName.TabIndex = 0;
        labelBootsName.Text = "bootsName";
        // 
        // pictureBoxIconBoots
        // 
        pictureBoxIconBoots.Image = Properties.Resources.bootsicon;
        pictureBoxIconBoots.Location = new Point(171, 4);
        pictureBoxIconBoots.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconBoots.Name = "pictureBoxIconBoots";
        pictureBoxIconBoots.Size = new Size(47, 40);
        pictureBoxIconBoots.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconBoots.TabIndex = 3;
        pictureBoxIconBoots.TabStop = false;
        // 
        // labelInvisibleBoots
        // 
        labelInvisibleBoots.AutoSize = true;
        labelInvisibleBoots.ForeColor = Color.Transparent;
        labelInvisibleBoots.Location = new Point(113, 1035);
        labelInvisibleBoots.Name = "labelInvisibleBoots";
        labelInvisibleBoots.Size = new Size(142, 75);
        labelInvisibleBoots.TabIndex = 28;
        labelInvisibleBoots.Text = "            \r\n            \r\n                                             \r\n\r\n\r\n";
        labelInvisibleBoots.MouseEnter += labelInvisibleBoots_MouseEnter;
        labelInvisibleBoots.MouseLeave += labelInvisibleBoots_MouseLeave;
        // 
        // panelPopupGloves
        // 
        panelPopupGloves.AutoSize = true;
        panelPopupGloves.BorderStyle = BorderStyle.Fixed3D;
        panelPopupGloves.Controls.Add(labelInfoGlovesEquipped);
        panelPopupGloves.Controls.Add(labelGlovesName);
        panelPopupGloves.Controls.Add(pictureBoxIconGloves);
        panelPopupGloves.Location = new Point(292, 670);
        panelPopupGloves.Margin = new Padding(3, 2, 3, 2);
        panelPopupGloves.Name = "panelPopupGloves";
        panelPopupGloves.Size = new Size(230, 108);
        panelPopupGloves.TabIndex = 31;
        // 
        // labelInfoGlovesEquipped
        // 
        labelInfoGlovesEquipped.AutoSize = true;
        labelInfoGlovesEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoGlovesEquipped.ForeColor = Color.White;
        labelInfoGlovesEquipped.Location = new Point(4, 19);
        labelInfoGlovesEquipped.Name = "labelInfoGlovesEquipped";
        labelInfoGlovesEquipped.Size = new Size(94, 18);
        labelInfoGlovesEquipped.TabIndex = 1;
        labelInfoGlovesEquipped.Text = "glovesInfo";
        // 
        // labelGlovesName
        // 
        labelGlovesName.AutoSize = true;
        labelGlovesName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelGlovesName.ForeColor = SystemColors.ActiveCaption;
        labelGlovesName.Location = new Point(1, -1);
        labelGlovesName.Name = "labelGlovesName";
        labelGlovesName.Size = new Size(110, 20);
        labelGlovesName.TabIndex = 0;
        labelGlovesName.Text = "GlovesName";
        // 
        // pictureBoxIconGloves
        // 
        pictureBoxIconGloves.Image = Properties.Resources.gauntletsicon;
        pictureBoxIconGloves.Location = new Point(175, 5);
        pictureBoxIconGloves.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconGloves.Name = "pictureBoxIconGloves";
        pictureBoxIconGloves.Size = new Size(46, 41);
        pictureBoxIconGloves.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconGloves.TabIndex = 3;
        pictureBoxIconGloves.TabStop = false;
        // 
        // labelInvisibleGloves
        // 
        labelInvisibleGloves.AutoSize = true;
        labelInvisibleGloves.ForeColor = Color.Transparent;
        labelInvisibleGloves.Location = new Point(246, 748);
        labelInvisibleGloves.Name = "labelInvisibleGloves";
        labelInvisibleGloves.Size = new Size(49, 90);
        labelInvisibleGloves.TabIndex = 30;
        labelInvisibleGloves.Text = "     \r\n     \r\n      \r\n\r\n\r\n              ";
        labelInvisibleGloves.MouseEnter += labelInvisibleGloves_MouseEnter;
        labelInvisibleGloves.MouseLeave += labelInvisibleGloves_MouseLeave;
        // 
        // panelPopupArmor
        // 
        panelPopupArmor.AutoSize = true;
        panelPopupArmor.BorderStyle = BorderStyle.Fixed3D;
        panelPopupArmor.Controls.Add(labelInfoArmorEquipped);
        panelPopupArmor.Controls.Add(labelArmorName);
        panelPopupArmor.Controls.Add(pictureBoxIconArmor);
        panelPopupArmor.Location = new Point(7, 762);
        panelPopupArmor.Margin = new Padding(3, 2, 3, 2);
        panelPopupArmor.Name = "panelPopupArmor";
        panelPopupArmor.Size = new Size(205, 141);
        panelPopupArmor.TabIndex = 27;
        // 
        // labelInfoArmorEquipped
        // 
        labelInfoArmorEquipped.AutoSize = true;
        labelInfoArmorEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoArmorEquipped.ForeColor = Color.White;
        labelInfoArmorEquipped.Location = new Point(-1, 25);
        labelInfoArmorEquipped.Name = "labelInfoArmorEquipped";
        labelInfoArmorEquipped.Size = new Size(88, 18);
        labelInfoArmorEquipped.TabIndex = 1;
        labelInfoArmorEquipped.Text = "armorInfo";
        // 
        // labelArmorName
        // 
        labelArmorName.AutoSize = true;
        labelArmorName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelArmorName.ForeColor = SystemColors.ActiveCaption;
        labelArmorName.Location = new Point(1, -1);
        labelArmorName.Name = "labelArmorName";
        labelArmorName.Size = new Size(103, 20);
        labelArmorName.TabIndex = 0;
        labelArmorName.Text = "ArmorName";
        // 
        // pictureBoxIconArmor
        // 
        pictureBoxIconArmor.Image = Properties.Resources.armoricon;
        pictureBoxIconArmor.Location = new Point(148, 4);
        pictureBoxIconArmor.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconArmor.Name = "pictureBoxIconArmor";
        pictureBoxIconArmor.Size = new Size(49, 37);
        pictureBoxIconArmor.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconArmor.TabIndex = 4;
        pictureBoxIconArmor.TabStop = false;
        // 
        // labelInvisibleArmor
        // 
        labelInvisibleArmor.AutoSize = true;
        labelInvisibleArmor.ForeColor = Color.Transparent;
        labelInvisibleArmor.Location = new Point(118, 656);
        labelInvisibleArmor.Name = "labelInvisibleArmor";
        labelInvisibleArmor.Size = new Size(82, 120);
        labelInvisibleArmor.TabIndex = 26;
        labelInvisibleArmor.Text = "     \r\n       \r\n                         \r\n\r\n\r\n\r\n\r\n\r\n";
        labelInvisibleArmor.MouseEnter += labelInvisibleArmor_MouseEnter;
        labelInvisibleArmor.MouseLeave += labelInvisibleArmor_MouseLeave;
        // 
        // labelGoldPopup
        // 
        labelGoldPopup.AutoSize = true;
        labelGoldPopup.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelGoldPopup.ForeColor = Color.Gold;
        labelGoldPopup.Location = new Point(337, 417);
        labelGoldPopup.Name = "labelGoldPopup";
        labelGoldPopup.Size = new Size(64, 25);
        labelGoldPopup.TabIndex = 35;
        labelGoldPopup.Text = "GOLD";
        // 
        // panelPopupWeaponRightHand
        // 
        panelPopupWeaponRightHand.AutoSize = true;
        panelPopupWeaponRightHand.BackColor = Color.Transparent;
        panelPopupWeaponRightHand.BorderStyle = BorderStyle.Fixed3D;
        panelPopupWeaponRightHand.Controls.Add(labelInfoWeaponRightHandEquipped);
        panelPopupWeaponRightHand.Controls.Add(labelWeaponRightHandName);
        panelPopupWeaponRightHand.Controls.Add(pictureBoxIconWeaponRightHand);
        panelPopupWeaponRightHand.Location = new Point(438, 787);
        panelPopupWeaponRightHand.Margin = new Padding(3, 2, 3, 2);
        panelPopupWeaponRightHand.Name = "panelPopupWeaponRightHand";
        panelPopupWeaponRightHand.Size = new Size(237, 115);
        panelPopupWeaponRightHand.TabIndex = 25;
        // 
        // labelInfoWeaponRightHandEquipped
        // 
        labelInfoWeaponRightHandEquipped.AutoSize = true;
        labelInfoWeaponRightHandEquipped.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoWeaponRightHandEquipped.ForeColor = Color.White;
        labelInfoWeaponRightHandEquipped.Location = new Point(3, 22);
        labelInfoWeaponRightHandEquipped.Name = "labelInfoWeaponRightHandEquipped";
        labelInfoWeaponRightHandEquipped.Size = new Size(104, 18);
        labelInfoWeaponRightHandEquipped.TabIndex = 1;
        labelInfoWeaponRightHandEquipped.Text = "weaponInfo";
        // 
        // labelWeaponRightHandName
        // 
        labelWeaponRightHandName.AutoSize = true;
        labelWeaponRightHandName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelWeaponRightHandName.ForeColor = SystemColors.ActiveCaption;
        labelWeaponRightHandName.Location = new Point(1, -1);
        labelWeaponRightHandName.Name = "labelWeaponRightHandName";
        labelWeaponRightHandName.Size = new Size(117, 20);
        labelWeaponRightHandName.TabIndex = 0;
        labelWeaponRightHandName.Text = "weaponName";
        // 
        // pictureBoxIconWeaponRightHand
        // 
        pictureBoxIconWeaponRightHand.Image = Properties.Resources.swordicon;
        pictureBoxIconWeaponRightHand.Location = new Point(184, 4);
        pictureBoxIconWeaponRightHand.Margin = new Padding(3, 2, 3, 2);
        pictureBoxIconWeaponRightHand.Name = "pictureBoxIconWeaponRightHand";
        pictureBoxIconWeaponRightHand.Size = new Size(46, 37);
        pictureBoxIconWeaponRightHand.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconWeaponRightHand.TabIndex = 2;
        pictureBoxIconWeaponRightHand.TabStop = false;
        // 
        // panelInventory
        // 
        panelInventory.Controls.Add(labelInventory);
        panelInventory.Controls.Add(buttonDiscardItem);
        panelInventory.Controls.Add(comboBoxInventory);
        panelInventory.Controls.Add(buttonEquipUnequip);
        panelInventory.Location = new Point(540, 852);
        panelInventory.Margin = new Padding(3, 2, 3, 2);
        panelInventory.Name = "panelInventory";
        panelInventory.Size = new Size(180, 142);
        panelInventory.TabIndex = 23;
        // 
        // labelRegeneration
        // 
        labelRegeneration.AutoSize = true;
        labelRegeneration.BackColor = Color.Transparent;
        labelRegeneration.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelRegeneration.ForeColor = Color.White;
        labelRegeneration.Location = new Point(190, 351);
        labelRegeneration.Name = "labelRegeneration";
        labelRegeneration.Size = new Size(132, 25);
        labelRegeneration.TabIndex = 39;
        labelRegeneration.Text = "Regeneration";
        // 
        // labelCritText
        // 
        labelCritText.AutoSize = true;
        labelCritText.BackColor = Color.Transparent;
        labelCritText.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelCritText.ForeColor = Color.White;
        labelCritText.Location = new Point(30, 452);
        labelCritText.Name = "labelCritText";
        labelCritText.Size = new Size(49, 25);
        labelCritText.TabIndex = 57;
        labelCritText.Text = "Crit:";
        // 
        // labelCritChance
        // 
        labelCritChance.AutoSize = true;
        labelCritChance.BackColor = Color.Transparent;
        labelCritChance.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelCritChance.ForeColor = Color.White;
        labelCritChance.Location = new Point(80, 452);
        labelCritChance.Name = "labelCritChance";
        labelCritChance.Size = new Size(41, 25);
        labelCritChance.TabIndex = 38;
        labelCritChance.Text = "crit";
        // 
        // labelPlayerCritDmg
        // 
        labelPlayerCritDmg.AutoSize = true;
        labelPlayerCritDmg.BackColor = Color.Transparent;
        labelPlayerCritDmg.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        labelPlayerCritDmg.ForeColor = Color.White;
        labelPlayerCritDmg.Location = new Point(191, 384);
        labelPlayerCritDmg.Name = "labelPlayerCritDmg";
        labelPlayerCritDmg.Size = new Size(87, 25);
        labelPlayerCritDmg.TabIndex = 61;
        labelPlayerCritDmg.Text = "CritDmg";
        // 
        // labelInvisibleAmulet
        // 
        labelInvisibleAmulet.AutoSize = true;
        labelInvisibleAmulet.ForeColor = Color.Transparent;
        labelInvisibleAmulet.Location = new Point(142, 626);
        labelInvisibleAmulet.Name = "labelInvisibleAmulet";
        labelInvisibleAmulet.Size = new Size(58, 30);
        labelInvisibleAmulet.TabIndex = 40;
        labelInvisibleAmulet.Text = "                 \r\n\r\n";
        labelInvisibleAmulet.MouseEnter += labelInvisibleAmulet_MouseEnter;
        labelInvisibleAmulet.MouseLeave += labelInvisibleAmulet_MouseLeave;
        // 
        // labelInvisibleLeggings
        // 
        labelInvisibleLeggings.AutoSize = true;
        labelInvisibleLeggings.ForeColor = Color.Transparent;
        labelInvisibleLeggings.Location = new Point(110, 845);
        labelInvisibleLeggings.Name = "labelInvisibleLeggings";
        labelInvisibleLeggings.Size = new Size(142, 180);
        labelInvisibleLeggings.TabIndex = 46;
        labelInvisibleLeggings.Text = "              \r\n            \r\n                               \r\n\r\n                                             \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
        labelInvisibleLeggings.MouseEnter += labelInvisibleLeggings_MouseEnter;
        labelInvisibleLeggings.MouseLeave += labelInvisibleLeggings_MouseLeave;
        // 
        // labelInvisibleWeaponLeftHand
        // 
        labelInvisibleWeaponLeftHand.AutoSize = true;
        labelInvisibleWeaponLeftHand.ForeColor = Color.Transparent;
        labelInvisibleWeaponLeftHand.Location = new Point(22, 825);
        labelInvisibleWeaponLeftHand.Name = "labelInvisibleWeaponLeftHand";
        labelInvisibleWeaponLeftHand.Size = new Size(82, 90);
        labelInvisibleWeaponLeftHand.TabIndex = 52;
        labelInvisibleWeaponLeftHand.Text = "       \r\n                         \r\n\r\n\r\n \r\n\r\n";
        labelInvisibleWeaponLeftHand.MouseEnter += labelInvisibleWeaponLeftHand_MouseEnter;
        labelInvisibleWeaponLeftHand.MouseLeave += labelInvisibleWeaponLeftHand_MouseLeave;
        // 
        // labelInvisibleShoulders
        // 
        labelInvisibleShoulders.AutoSize = true;
        labelInvisibleShoulders.ForeColor = Color.Transparent;
        labelInvisibleShoulders.Location = new Point(194, 645);
        labelInvisibleShoulders.Name = "labelInvisibleShoulders";
        labelInvisibleShoulders.Size = new Size(64, 60);
        labelInvisibleShoulders.TabIndex = 53;
        labelInvisibleShoulders.Text = "         \r\n                   \r\n\r\n\r\n";
        labelInvisibleShoulders.MouseEnter += labelInvisibleShoulders_MouseEnter;
        labelInvisibleShoulders.MouseLeave += labelInvisibleShoulders_MouseLeave;
        // 
        // labelInvisibleHelmet
        // 
        labelInvisibleHelmet.AutoSize = true;
        labelInvisibleHelmet.ForeColor = Color.Transparent;
        labelInvisibleHelmet.Location = new Point(144, 578);
        labelInvisibleHelmet.Name = "labelInvisibleHelmet";
        labelInvisibleHelmet.Size = new Size(58, 45);
        labelInvisibleHelmet.TabIndex = 42;
        labelInvisibleHelmet.Text = "        \r\n                 \r\n\r\n";
        labelInvisibleHelmet.MouseEnter += labelInvisibleHelmet_MouseEnter;
        labelInvisibleHelmet.MouseLeave += labelInvisibleHelmet_MouseLeave;
        // 
        // labelInvisibleBelt
        // 
        labelInvisibleBelt.AutoSize = true;
        labelInvisibleBelt.ForeColor = Color.Transparent;
        labelInvisibleBelt.Location = new Point(132, 785);
        labelInvisibleBelt.Name = "labelInvisibleBelt";
        labelInvisibleBelt.Size = new Size(103, 45);
        labelInvisibleBelt.TabIndex = 41;
        labelInvisibleBelt.Text = "                                \r\n\r\n\r\n";
        labelInvisibleBelt.MouseEnter += labelInvisibleBelt_MouseEnter;
        labelInvisibleBelt.MouseLeave += labelInvisibleBelt_MouseLeave;
        // 
        // pictureBoxHero
        // 
        pictureBoxHero.Image = Properties.Resources.hero;
        pictureBoxHero.Location = new Point(-23, 558);
        pictureBoxHero.Margin = new Padding(3, 2, 3, 2);
        pictureBoxHero.Name = "pictureBoxHero";
        pictureBoxHero.Size = new Size(560, 569);
        pictureBoxHero.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBoxHero.TabIndex = 22;
        pictureBoxHero.TabStop = false;
        // 
        // pictureBoxInventory
        // 
        pictureBoxInventory.Image = Properties.Resources.inventory;
        pictureBoxInventory.Location = new Point(514, 807);
        pictureBoxInventory.Margin = new Padding(3, 2, 3, 2);
        pictureBoxInventory.Name = "pictureBoxInventory";
        pictureBoxInventory.Size = new Size(244, 258);
        pictureBoxInventory.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxInventory.TabIndex = 33;
        pictureBoxInventory.TabStop = false;
        pictureBoxInventory.Click += pictureBoxInventory_Click;
        // 
        // panelTown
        // 
        panelTown.BackColor = Color.Transparent;
        panelTown.BackgroundImage = Properties.Resources.castle;
        panelTown.BackgroundImageLayout = ImageLayout.Stretch;
        panelTown.Controls.Add(txtBox_Town);
        panelTown.Controls.Add(labelAct2Q1);
        panelTown.Controls.Add(labelAct5Q1);
        panelTown.Controls.Add(pictureBoxAct5Hero);
        panelTown.Controls.Add(buttonTalkMage);
        panelTown.Controls.Add(labelAct4Q1);
        panelTown.Controls.Add(labelAct3Q1);
        panelTown.Controls.Add(labelAct1Quest1);
        panelTown.Controls.Add(buttonLearnTechnique);
        panelTown.Controls.Add(pictureBoxAct1ArtsTeacher);
        panelTown.Controls.Add(comboBoxUpgradeItems);
        panelTown.Controls.Add(buttonUpgradeItem);
        panelTown.Controls.Add(btn_Continuetown);
        panelTown.Controls.Add(buttonHeal);
        panelTown.Controls.Add(labelCompassS);
        panelTown.Controls.Add(labelCompassN);
        panelTown.Controls.Add(labelCompassE);
        panelTown.Controls.Add(labelCompassW);
        panelTown.Controls.Add(pictureBoxCompass);
        panelTown.Controls.Add(pictureBoxHealer);
        panelTown.Controls.Add(pictureBoxAct2Smith);
        panelTown.Controls.Add(pictureBoxAct4Mage);
        panelTown.Dock = DockStyle.Fill;
        panelTown.Location = new Point(0, 0);
        panelTown.Margin = new Padding(3, 2, 3, 2);
        panelTown.Name = "panelTown";
        panelTown.Size = new Size(789, 1218);
        panelTown.TabIndex = 0;
        // 
        // txtBox_Town
        // 
        txtBox_Town.BackColor = Color.FromArgb(195, 195, 195);
        txtBox_Town.BorderStyle = BorderStyle.None;
        txtBox_Town.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtBox_Town.Location = new Point(10, 19);
        txtBox_Town.Margin = new Padding(3, 2, 3, 2);
        txtBox_Town.Multiline = true;
        txtBox_Town.Name = "txtBox_Town";
        txtBox_Town.ReadOnly = true;
        txtBox_Town.ScrollBars = ScrollBars.Vertical;
        txtBox_Town.Size = new Size(767, 95);
        txtBox_Town.TabIndex = 12;
        // 
        // labelAct2Q1
        // 
        labelAct2Q1.AutoSize = true;
        labelAct2Q1.Location = new Point(309, 193);
        labelAct2Q1.Name = "labelAct2Q1";
        labelAct2Q1.Size = new Size(412, 135);
        labelAct2Q1.TabIndex = 25;
        labelAct2Q1.Text = "                   \r\n                \r\n                                                                                                                                       \r\n\r\n\r\n\r\n\r\n\r\n\r\n";
        labelAct2Q1.Click += labelAct2Q1_Click;
        // 
        // labelAct5Q1
        // 
        labelAct5Q1.AutoSize = true;
        labelAct5Q1.Location = new Point(523, 314);
        labelAct5Q1.Name = "labelAct5Q1";
        labelAct5Q1.Size = new Size(79, 165);
        labelAct5Q1.TabIndex = 26;
        labelAct5Q1.Text = "                        \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
        labelAct5Q1.Click += labelAct5Q1_Click;
        // 
        // pictureBoxAct5Hero
        // 
        pictureBoxAct5Hero.Image = Properties.Resources.hero;
        pictureBoxAct5Hero.Location = new Point(-101, 615);
        pictureBoxAct5Hero.Margin = new Padding(3, 2, 3, 2);
        pictureBoxAct5Hero.Name = "pictureBoxAct5Hero";
        pictureBoxAct5Hero.Size = new Size(479, 610);
        pictureBoxAct5Hero.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxAct5Hero.TabIndex = 24;
        pictureBoxAct5Hero.TabStop = false;
        // 
        // labelAct4Q1
        // 
        labelAct4Q1.AutoSize = true;
        labelAct4Q1.Location = new Point(355, 534);
        labelAct4Q1.Name = "labelAct4Q1";
        labelAct4Q1.Size = new Size(91, 120);
        labelAct4Q1.TabIndex = 20;
        labelAct4Q1.Text = "                   \r\n                \r\n                            \r\n\r\n\r\n\r\n\r\n\r\n";
        labelAct4Q1.Click += labelAct4Q1_Click;
        // 
        // labelAct3Q1
        // 
        labelAct3Q1.AutoSize = true;
        labelAct3Q1.Location = new Point(645, 492);
        labelAct3Q1.Name = "labelAct3Q1";
        labelAct3Q1.Size = new Size(115, 120);
        labelAct3Q1.TabIndex = 23;
        labelAct3Q1.Text = "                                    \r\n\r\n\r\n\r\n\r\n\r\n      \r\n\r\n";
        labelAct3Q1.Click += labelAct3Q1_Click;
        // 
        // labelAct1Quest1
        // 
        labelAct1Quest1.AutoSize = true;
        labelAct1Quest1.Location = new Point(350, 767);
        labelAct1Quest1.Name = "labelAct1Quest1";
        labelAct1Quest1.Size = new Size(58, 105);
        labelAct1Quest1.TabIndex = 19;
        labelAct1Quest1.Text = "                 \r\n\r\n\r\n       \r\n\r\n\r\n\r\n";
        labelAct1Quest1.Click += labelAct1Quest1_Click;
        // 
        // pictureBoxAct1ArtsTeacher
        // 
        pictureBoxAct1ArtsTeacher.Location = new Point(501, 542);
        pictureBoxAct1ArtsTeacher.Margin = new Padding(3, 2, 3, 2);
        pictureBoxAct1ArtsTeacher.Name = "pictureBoxAct1ArtsTeacher";
        pictureBoxAct1ArtsTeacher.Size = new Size(317, 518);
        pictureBoxAct1ArtsTeacher.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxAct1ArtsTeacher.TabIndex = 17;
        pictureBoxAct1ArtsTeacher.TabStop = false;
        // 
        // comboBoxUpgradeItems
        // 
        comboBoxUpgradeItems.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxUpgradeItems.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        comboBoxUpgradeItems.FormattingEnabled = true;
        comboBoxUpgradeItems.Location = new Point(487, 660);
        comboBoxUpgradeItems.Margin = new Padding(3, 2, 3, 2);
        comboBoxUpgradeItems.Name = "comboBoxUpgradeItems";
        comboBoxUpgradeItems.Size = new Size(185, 29);
        comboBoxUpgradeItems.TabIndex = 16;
        // 
        // pictureBoxCompass
        // 
        pictureBoxCompass.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBoxCompass.Image = Properties.Resources.compass;
        pictureBoxCompass.Location = new Point(-3, 178);
        pictureBoxCompass.Margin = new Padding(3, 2, 3, 2);
        pictureBoxCompass.Name = "pictureBoxCompass";
        pictureBoxCompass.Size = new Size(254, 219);
        pictureBoxCompass.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxCompass.TabIndex = 5;
        pictureBoxCompass.TabStop = false;
        // 
        // pictureBoxHealer
        // 
        pictureBoxHealer.Image = Properties.Resources.healer;
        pictureBoxHealer.Location = new Point(-24, 626);
        pictureBoxHealer.Margin = new Padding(3, 2, 3, 2);
        pictureBoxHealer.Name = "pictureBoxHealer";
        pictureBoxHealer.Size = new Size(305, 538);
        pictureBoxHealer.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxHealer.TabIndex = 10;
        pictureBoxHealer.TabStop = false;
        // 
        // pictureBoxAct2Smith
        // 
        pictureBoxAct2Smith.Location = new Point(376, 361);
        pictureBoxAct2Smith.Margin = new Padding(3, 2, 3, 2);
        pictureBoxAct2Smith.Name = "pictureBoxAct2Smith";
        pictureBoxAct2Smith.Size = new Size(458, 435);
        pictureBoxAct2Smith.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxAct2Smith.TabIndex = 14;
        pictureBoxAct2Smith.TabStop = false;
        // 
        // pictureBoxAct4Mage
        // 
        pictureBoxAct4Mage.Location = new Point(413, 351);
        pictureBoxAct4Mage.Margin = new Padding(3, 2, 3, 2);
        pictureBoxAct4Mage.Name = "pictureBoxAct4Mage";
        pictureBoxAct4Mage.Size = new Size(493, 837);
        pictureBoxAct4Mage.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxAct4Mage.TabIndex = 21;
        pictureBoxAct4Mage.TabStop = false;
        // 
        // panelStartScreen
        // 
        panelStartScreen.BackColor = Color.Transparent;
        panelStartScreen.BackgroundImage = Properties.Resources.castle;
        panelStartScreen.BackgroundImageLayout = ImageLayout.Stretch;
        panelStartScreen.Controls.Add(labelVersionNumber);
        panelStartScreen.Controls.Add(labelXboxRecommended);
        panelStartScreen.Controls.Add(pictureBoxXboxLogo);
        panelStartScreen.Controls.Add(buttonStartModifiers);
        panelStartScreen.Controls.Add(labelGameAuthorName);
        panelStartScreen.Controls.Add(buttonPlayGame);
        panelStartScreen.Controls.Add(labelGameTitle);
        panelStartScreen.Dock = DockStyle.Fill;
        panelStartScreen.Location = new Point(0, 0);
        panelStartScreen.Margin = new Padding(3, 2, 3, 2);
        panelStartScreen.Name = "panelStartScreen";
        panelStartScreen.Size = new Size(789, 1218);
        panelStartScreen.TabIndex = 22;
        // 
        // labelVersionNumber
        // 
        labelVersionNumber.AutoSize = true;
        labelVersionNumber.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelVersionNumber.ForeColor = Color.White;
        labelVersionNumber.Location = new Point(12, 1175);
        labelVersionNumber.Name = "labelVersionNumber";
        labelVersionNumber.Size = new Size(37, 15);
        labelVersionNumber.TabIndex = 6;
        labelVersionNumber.Text = "v0.88";
        // 
        // labelXboxRecommended
        // 
        labelXboxRecommended.AutoSize = true;
        labelXboxRecommended.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelXboxRecommended.ForeColor = Color.White;
        labelXboxRecommended.Location = new Point(337, 934);
        labelXboxRecommended.Name = "labelXboxRecommended";
        labelXboxRecommended.Size = new Size(114, 20);
        labelXboxRecommended.TabIndex = 5;
        labelXboxRecommended.Text = "Recommended";
        // 
        // pictureBoxXboxLogo
        // 
        pictureBoxXboxLogo.Image = Properties.Resources.xbox;
        pictureBoxXboxLogo.Location = new Point(347, 865);
        pictureBoxXboxLogo.Margin = new Padding(3, 2, 3, 2);
        pictureBoxXboxLogo.Name = "pictureBoxXboxLogo";
        pictureBoxXboxLogo.Size = new Size(99, 75);
        pictureBoxXboxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBoxXboxLogo.TabIndex = 4;
        pictureBoxXboxLogo.TabStop = false;
        // 
        // buttonStartModifiers
        // 
        buttonStartModifiers.BackColor = Color.DarkRed;
        buttonStartModifiers.FlatAppearance.BorderSize = 0;
        buttonStartModifiers.FlatStyle = FlatStyle.Flat;
        buttonStartModifiers.Font = new Font("Impact", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonStartModifiers.ForeColor = Color.White;
        buttonStartModifiers.Location = new Point(285, 756);
        buttonStartModifiers.Margin = new Padding(3, 2, 3, 2);
        buttonStartModifiers.Name = "buttonStartModifiers";
        buttonStartModifiers.Size = new Size(222, 61);
        buttonStartModifiers.TabIndex = 3;
        buttonStartModifiers.Text = "Modifiers";
        buttonStartModifiers.UseVisualStyleBackColor = false;
        buttonStartModifiers.Click += buttonStartModifiers_Click;
        // 
        // labelGameAuthorName
        // 
        labelGameAuthorName.AutoSize = true;
        labelGameAuthorName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelGameAuthorName.ForeColor = SystemColors.ButtonHighlight;
        labelGameAuthorName.Location = new Point(631, 1175);
        labelGameAuthorName.Name = "labelGameAuthorName";
        labelGameAuthorName.Size = new Size(150, 15);
        labelGameAuthorName.TabIndex = 2;
        labelGameAuthorName.Text = "Jakob Kvejborg 2024-2025";
        // 
        // buttonPlayGame
        // 
        buttonPlayGame.BackColor = Color.DarkRed;
        buttonPlayGame.FlatAppearance.BorderSize = 0;
        buttonPlayGame.FlatStyle = FlatStyle.Flat;
        buttonPlayGame.Font = new Font("Impact", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonPlayGame.ForeColor = Color.White;
        buttonPlayGame.Location = new Point(285, 675);
        buttonPlayGame.Margin = new Padding(3, 2, 3, 2);
        buttonPlayGame.Name = "buttonPlayGame";
        buttonPlayGame.Size = new Size(218, 64);
        buttonPlayGame.TabIndex = 1;
        buttonPlayGame.Text = "Play Game";
        buttonPlayGame.UseVisualStyleBackColor = false;
        buttonPlayGame.Click += buttonPlayGame_Click;
        // 
        // labelGameTitle
        // 
        labelGameTitle.AutoSize = true;
        labelGameTitle.Font = new Font("Imprint MT Shadow", 117.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelGameTitle.ForeColor = Color.Red;
        labelGameTitle.Location = new Point(63, 161);
        labelGameTitle.Name = "labelGameTitle";
        labelGameTitle.Size = new Size(653, 370);
        labelGameTitle.TabIndex = 0;
        labelGameTitle.Text = "Horrors \n\rAwoken";
        // 
        // panelGameOver
        // 
        panelGameOver.BackgroundImageLayout = ImageLayout.Stretch;
        panelGameOver.Controls.Add(labelGameOverText);
        panelGameOver.Dock = DockStyle.Fill;
        panelGameOver.ForeColor = Color.FromArgb(94, 94, 94);
        panelGameOver.Location = new Point(0, 0);
        panelGameOver.Margin = new Padding(3, 2, 3, 2);
        panelGameOver.Name = "panelGameOver";
        panelGameOver.Size = new Size(789, 1218);
        panelGameOver.TabIndex = 5;
        // 
        // labelGameOverText
        // 
        labelGameOverText.AutoSize = true;
        labelGameOverText.Font = new Font("Impact", 87.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelGameOverText.ForeColor = Color.FromArgb(192, 0, 0);
        labelGameOverText.Location = new Point(52, 289);
        labelGameOverText.Name = "labelGameOverText";
        labelGameOverText.Size = new Size(691, 426);
        labelGameOverText.TabIndex = 0;
        labelGameOverText.Text = "You Are Dead\n\r\n\r  Game Over";
        // 
        // panelAct1Quest1
        // 
        panelAct1Quest1.BackColor = Color.Transparent;
        panelAct1Quest1.Controls.Add(buttonAct1Q1Town);
        panelAct1Quest1.Controls.Add(buttonAct1Quest1Continue);
        panelAct1Quest1.Controls.Add(textBoxAct1Quest1);
        panelAct1Quest1.Dock = DockStyle.Fill;
        panelAct1Quest1.ForeColor = Color.Transparent;
        panelAct1Quest1.Location = new Point(0, 0);
        panelAct1Quest1.Margin = new Padding(3, 2, 3, 2);
        panelAct1Quest1.Name = "panelAct1Quest1";
        panelAct1Quest1.Size = new Size(789, 1218);
        panelAct1Quest1.TabIndex = 45;
        // 
        // textBoxAct1Quest1
        // 
        textBoxAct1Quest1.BackColor = Color.FromArgb(195, 195, 195);
        textBoxAct1Quest1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxAct1Quest1.Location = new Point(10, 19);
        textBoxAct1Quest1.Margin = new Padding(3, 2, 3, 2);
        textBoxAct1Quest1.Multiline = true;
        textBoxAct1Quest1.Name = "textBoxAct1Quest1";
        textBoxAct1Quest1.ReadOnly = true;
        textBoxAct1Quest1.ScrollBars = ScrollBars.Vertical;
        textBoxAct1Quest1.Size = new Size(767, 95);
        textBoxAct1Quest1.TabIndex = 2;
        // 
        // panelAct4Quest1
        // 
        panelAct4Quest1.BackColor = Color.Transparent;
        panelAct4Quest1.Controls.Add(buttonAct4Q1Town);
        panelAct4Quest1.Controls.Add(buttonAct4Quest1Continue);
        panelAct4Quest1.Controls.Add(textBoxAct4Quest1);
        panelAct4Quest1.Dock = DockStyle.Fill;
        panelAct4Quest1.ForeColor = Color.Transparent;
        panelAct4Quest1.Location = new Point(0, 0);
        panelAct4Quest1.Margin = new Padding(3, 2, 3, 2);
        panelAct4Quest1.Name = "panelAct4Quest1";
        panelAct4Quest1.Size = new Size(789, 1218);
        panelAct4Quest1.TabIndex = 46;
        // 
        // textBoxAct4Quest1
        // 
        textBoxAct4Quest1.BackColor = Color.FromArgb(195, 195, 195);
        textBoxAct4Quest1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxAct4Quest1.Location = new Point(10, 19);
        textBoxAct4Quest1.Margin = new Padding(3, 2, 3, 2);
        textBoxAct4Quest1.Multiline = true;
        textBoxAct4Quest1.Name = "textBoxAct4Quest1";
        textBoxAct4Quest1.ReadOnly = true;
        textBoxAct4Quest1.ScrollBars = ScrollBars.Vertical;
        textBoxAct4Quest1.Size = new Size(767, 95);
        textBoxAct4Quest1.TabIndex = 2;
        // 
        // panelXboxControlsLayout
        // 
        panelXboxControlsLayout.BackColor = Color.Transparent;
        panelXboxControlsLayout.BackgroundImage = (Image)resources.GetObject("panelXboxControlsLayout.BackgroundImage");
        panelXboxControlsLayout.BackgroundImageLayout = ImageLayout.Stretch;
        panelXboxControlsLayout.Dock = DockStyle.Fill;
        panelXboxControlsLayout.ForeColor = Color.Transparent;
        panelXboxControlsLayout.Location = new Point(0, 0);
        panelXboxControlsLayout.Margin = new Padding(3, 2, 3, 2);
        panelXboxControlsLayout.Name = "panelXboxControlsLayout";
        panelXboxControlsLayout.Size = new Size(789, 1218);
        panelXboxControlsLayout.TabIndex = 6;
        // 
        // axWMPintroVid
        // 
        axWMPintroVid.Dock = DockStyle.Fill;
        axWMPintroVid.Enabled = true;
        axWMPintroVid.Location = new Point(0, 0);
        axWMPintroVid.Margin = new Padding(3, 2, 3, 2);
        axWMPintroVid.Name = "axWMPintroVid";
        axWMPintroVid.OcxState = (AxHost.State)resources.GetObject("axWMPintroVid.OcxState");
        axWMPintroVid.Size = new Size(789, 1218);
        axWMPintroVid.TabIndex = 6;
        // 
        // panelIntroVidWMP
        // 
        panelIntroVidWMP.Controls.Add(axWMPintroVid);
        panelIntroVidWMP.Dock = DockStyle.Fill;
        panelIntroVidWMP.Location = new Point(0, 0);
        panelIntroVidWMP.Margin = new Padding(3, 2, 3, 2);
        panelIntroVidWMP.Name = "panelIntroVidWMP";
        panelIntroVidWMP.Size = new Size(789, 1218);
        panelIntroVidWMP.TabIndex = 47;
        // 
        // panelAct3Q1
        // 
        panelAct3Q1.BackColor = Color.Transparent;
        panelAct3Q1.Controls.Add(panelReforgeItemFrog);
        panelAct3Q1.Controls.Add(buttonReforge);
        panelAct3Q1.Controls.Add(comboBoxAct3Q1Frog);
        panelAct3Q1.Controls.Add(buttonAct3Q1Town);
        panelAct3Q1.Controls.Add(buttonAct3Q1Continue);
        panelAct3Q1.Controls.Add(textBoxAct3Q1);
        panelAct3Q1.Dock = DockStyle.Fill;
        panelAct3Q1.ForeColor = Color.Transparent;
        panelAct3Q1.Location = new Point(0, 0);
        panelAct3Q1.Margin = new Padding(3, 2, 3, 2);
        panelAct3Q1.Name = "panelAct3Q1";
        panelAct3Q1.Size = new Size(789, 1218);
        panelAct3Q1.TabIndex = 48;
        // 
        // panelReforgeItemFrog
        // 
        panelReforgeItemFrog.Controls.Add(buttonReforgeStat);
        panelReforgeItemFrog.Controls.Add(listViewItemStatsFrog);
        panelReforgeItemFrog.Location = new Point(530, 460);
        panelReforgeItemFrog.Margin = new Padding(3, 2, 3, 2);
        panelReforgeItemFrog.Name = "panelReforgeItemFrog";
        panelReforgeItemFrog.Size = new Size(235, 324);
        panelReforgeItemFrog.TabIndex = 41;
        // 
        // listViewItemStatsFrog
        // 
        listViewItemStatsFrog.BackColor = SystemColors.ScrollBar;
        listViewItemStatsFrog.Columns.AddRange(new ColumnHeader[] { columnType, columnStat });
        listViewItemStatsFrog.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        listViewItemStatsFrog.FullRowSelect = true;
        listViewItemStatsFrog.Location = new Point(6, 4);
        listViewItemStatsFrog.Margin = new Padding(3, 2, 3, 2);
        listViewItemStatsFrog.Name = "listViewItemStatsFrog";
        listViewItemStatsFrog.Size = new Size(226, 251);
        listViewItemStatsFrog.TabIndex = 40;
        listViewItemStatsFrog.UseCompatibleStateImageBehavior = false;
        listViewItemStatsFrog.View = View.Details;
        // 
        // columnType
        // 
        columnType.Text = "Type";
        columnType.Width = 172;
        // 
        // columnStat
        // 
        columnStat.Text = "Stat";
        columnStat.Width = 50;
        // 
        // comboBoxAct3Q1Frog
        // 
        comboBoxAct3Q1Frog.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        comboBoxAct3Q1Frog.FormattingEnabled = true;
        comboBoxAct3Q1Frog.Location = new Point(47, 544);
        comboBoxAct3Q1Frog.Margin = new Padding(3, 2, 3, 2);
        comboBoxAct3Q1Frog.Name = "comboBoxAct3Q1Frog";
        comboBoxAct3Q1Frog.Size = new Size(184, 29);
        comboBoxAct3Q1Frog.TabIndex = 38;
        // 
        // textBoxAct3Q1
        // 
        textBoxAct3Q1.BackColor = Color.FromArgb(195, 195, 195);
        textBoxAct3Q1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxAct3Q1.Location = new Point(10, 19);
        textBoxAct3Q1.Margin = new Padding(3, 2, 3, 2);
        textBoxAct3Q1.Multiline = true;
        textBoxAct3Q1.Name = "textBoxAct3Q1";
        textBoxAct3Q1.ReadOnly = true;
        textBoxAct3Q1.ScrollBars = ScrollBars.Vertical;
        textBoxAct3Q1.Size = new Size(767, 95);
        textBoxAct3Q1.TabIndex = 2;
        // 
        // panelAct2Q1
        // 
        panelAct2Q1.BackColor = Color.Transparent;
        panelAct2Q1.Controls.Add(buttonAct2Q1Town);
        panelAct2Q1.Controls.Add(buttonAct2Q1Continue);
        panelAct2Q1.Controls.Add(textBoxAct2Q1);
        panelAct2Q1.Dock = DockStyle.Fill;
        panelAct2Q1.ForeColor = Color.Transparent;
        panelAct2Q1.Location = new Point(0, 0);
        panelAct2Q1.Margin = new Padding(3, 2, 3, 2);
        panelAct2Q1.Name = "panelAct2Q1";
        panelAct2Q1.Size = new Size(789, 1218);
        panelAct2Q1.TabIndex = 64;
        // 
        // textBoxAct2Q1
        // 
        textBoxAct2Q1.BackColor = Color.FromArgb(195, 195, 195);
        textBoxAct2Q1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxAct2Q1.Location = new Point(10, 19);
        textBoxAct2Q1.Margin = new Padding(3, 2, 3, 2);
        textBoxAct2Q1.Multiline = true;
        textBoxAct2Q1.Name = "textBoxAct2Q1";
        textBoxAct2Q1.ReadOnly = true;
        textBoxAct2Q1.ScrollBars = ScrollBars.Vertical;
        textBoxAct2Q1.Size = new Size(767, 95);
        textBoxAct2Q1.TabIndex = 2;
        // 
        // panelAnyVideo
        // 
        panelAnyVideo.Controls.Add(axWMPAnyVideo);
        panelAnyVideo.Dock = DockStyle.Fill;
        panelAnyVideo.Location = new Point(0, 0);
        panelAnyVideo.Name = "panelAnyVideo";
        panelAnyVideo.Size = new Size(789, 1218);
        panelAnyVideo.TabIndex = 27;
        // 
        // axWMPAnyVideo
        // 
        axWMPAnyVideo.Dock = DockStyle.Fill;
        axWMPAnyVideo.Enabled = true;
        axWMPAnyVideo.Location = new Point(0, 0);
        axWMPAnyVideo.Margin = new Padding(3, 2, 3, 2);
        axWMPAnyVideo.Name = "axWMPAnyVideo";
        axWMPAnyVideo.OcxState = (AxHost.State)resources.GetObject("axWMPAnyVideo.OcxState");
        axWMPAnyVideo.Size = new Size(789, 1218);
        axWMPAnyVideo.TabIndex = 7;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaptionText;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(789, 1218);
        Controls.Add(panelEncounter);
        Controls.Add(panelTown);
        Controls.Add(panelAnyVideo);
        Controls.Add(panelAct2Q1);
        Controls.Add(panelAct4Quest1);
        Controls.Add(panelAct3Q1);
        Controls.Add(panelAct1Quest1);
        Controls.Add(panelIntroVidWMP);
        Controls.Add(panelXboxControlsLayout);
        Controls.Add(panelGameOver);
        Controls.Add(panelStartScreen);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(3, 2, 3, 2);
        Name = "MainWindow";
        Text = "Horrors Awoken";
        Load += MainWindow_Load;
        ((System.ComponentModel.ISupportInitialize)pictureBoxHeroBag).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxLoot).EndInit();
        panelMonster.ResumeLayout(false);
        panelMonster.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxDragonEggs).EndInit();
        panelEncounter.ResumeLayout(false);
        panelEncounter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxFrozenLily).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxRuby).EndInit();
        panelPopupHelmet.ResumeLayout(false);
        panelPopupHelmet.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconHelmet).EndInit();
        panelPopupWeaponLeftHand.ResumeLayout(false);
        panelPopupWeaponLeftHand.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconWeaponLeftHand).EndInit();
        panelPopupShoulders.ResumeLayout(false);
        panelPopupShoulders.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconShoulders).EndInit();
        panelPopupInventoryInfo.ResumeLayout(false);
        panelPopupInventoryInfo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxInventoryIcon).EndInit();
        panelPopupBelt.ResumeLayout(false);
        panelPopupBelt.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconBelt).EndInit();
        panelPopupLeggings.ResumeLayout(false);
        panelPopupLeggings.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconLeggings).EndInit();
        panelPopupAmulet.ResumeLayout(false);
        panelPopupAmulet.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconAmulet).EndInit();
        panelPopupBoots.ResumeLayout(false);
        panelPopupBoots.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconBoots).EndInit();
        panelPopupGloves.ResumeLayout(false);
        panelPopupGloves.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconGloves).EndInit();
        panelPopupArmor.ResumeLayout(false);
        panelPopupArmor.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconArmor).EndInit();
        panelPopupWeaponRightHand.ResumeLayout(false);
        panelPopupWeaponRightHand.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconWeaponRightHand).EndInit();
        panelInventory.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxHero).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxInventory).EndInit();
        panelTown.ResumeLayout(false);
        panelTown.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct5Hero).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct1ArtsTeacher).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxCompass).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxHealer).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct2Smith).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct4Mage).EndInit();
        panelStartScreen.ResumeLayout(false);
        panelStartScreen.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxXboxLogo).EndInit();
        panelGameOver.ResumeLayout(false);
        panelGameOver.PerformLayout();
        panelAct1Quest1.ResumeLayout(false);
        panelAct1Quest1.PerformLayout();
        panelAct4Quest1.ResumeLayout(false);
        panelAct4Quest1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)axWMPintroVid).EndInit();
        panelIntroVidWMP.ResumeLayout(false);
        panelAct3Q1.ResumeLayout(false);
        panelAct3Q1.PerformLayout();
        panelReforgeItemFrog.ResumeLayout(false);
        panelAct2Q1.ResumeLayout(false);
        panelAct2Q1.PerformLayout();
        panelAnyVideo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)axWMPAnyVideo).EndInit();
        ResumeLayout(false);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
    #endregion

    private Button btn_continue;
    private Label labelInventory;
    private Button buttonDiscardItem;


    public Panel panelGameOver;
    public Panel panelTown;
    public Panel panelStartScreen;
    public Panel panelEncounter;
    public ComboBox comboBoxInventory;
    public Button buttonEquipUnequip;
    public TextBox textBoxEncounter;
    public ProgressBar progressBarPlayerHP;
    public Label labelPlayerArmor;
    public Label labelPlayerDamage;
    public Label labelPlayerDodge;
    public Label labelHeroName;
    public Label labelPlayerHP;
    public Label labelPlayerStrength;
    public Label labelPlayerLifeSteal;
    public Label labelGoldInPocket;
    public Label labelLevel;
    public PictureBox pictureBoxMonster1;
    public Label labelExperience;
    public Panel panelMonster;
    public ProgressBar progressBarMonsterHP;
    public Label labelMonsterHp;
    public Label labelMonsterName;
    public Button buttonPlayGame;
    public Label labelGameTitle;
    public Label labelGameOverText;
    public PictureBox pictureBoxHero;
    private Label labelCompassW;
    private Label labelCompassE;
    private Label labelCompassN;
    private Label labelCompassS;
    public TextBox txtBox_Town;
    private Button btn_Continuetown;
    private Panel panelInventory;
    private Label labelInvisibleWeaponRightHandEquipped;
    private Label labelWeaponRightHandName;
    private Label labelInfoWeaponRightHandEquipped;
    public PictureBox pictureBoxHealer;
    private Label labelInvisibleArmor;
    private Label labelInfoArmorEquipped;
    private Label labelArmorName;
    private Label labelInvisibleBoots;
    private Label labelInfoBootsEquipped;
    private Label labelBootsName;
    public PictureBox pictureBoxAct2Smith;
    public ComboBox comboBoxUpgradeItems;
    public Button buttonUpgradeItem;
    private Label labelInvisibleGloves;
    private Label labelInfoGlovesEquipped;
    private Label labelGlovesName;
    public PictureBox pictureBoxHeroBag;
    private PictureBox pictureBoxInventory;
    public PictureBox pictureBoxLoot;
    public Label labelGoldPopup;
    public Button buttonReturnToTown;
    public Label labelCritChance;
    public Label labelRegeneration;
    private Label labelGameAuthorName;
    public PictureBox pictureBoxAct1ArtsTeacher;
    public Button buttonLearnTechnique;
    private Label labelInvisibleAmulet;
    private Label labelInvisibleBelt;
    private Label labelInvisibleHelmet;
    public Panel panelPopupAmulet;
    private Label labelInfoAmuletEquipped;
    private Label labelAmuletName;
    private Button buttonAct1Quest1Continue;
    public TextBox textBoxAct1Quest1;
    public Button buttonHeal;
    public Label labelAct1Quest1;
    public Panel panelAct1Quest1;
    public Button buttonAct1Q1Town;
    private Label labelInfoHelmetEquipped;
    private Label labelHelmetName;
    private Label labelInvisibleLeggings;
    private Label labelInfoLeggingsEquipped;
    private Label labelLeggingsName;
    private Label labelInfoBeltEquipped;
    private Label labelBeltName;
    public Label labelHpPopup;
    private Label labelInventoryItemInfo;
    public Panel panelPopupInventoryInfo;
    private PictureBox pictureBoxIconWeaponRightHand;
    private PictureBox pictureBoxInventoryIcon;
    private PictureBox pictureBoxIconBelt;
    private PictureBox pictureBoxIconLeggings;
    private PictureBox pictureBoxIconHelmet;
    private PictureBox pictureBoxIconGloves;
    private PictureBox pictureBoxIconAmulet;
    private PictureBox pictureBoxIconBoots;
    private PictureBox pictureBoxIconArmor;
    public Label labelGold;
    public Panel panelPopupHelmet;
    public Panel panelPopupBoots;
    public Panel panelPopupLeggings;
    public Panel panelPopupBelt;
    public Panel panelPopupWeaponRightHand;
    public Panel panelPopupArmor;
    public Panel panelPopupGloves;
    private Label labelInvisibleWeaponLeftHand;
    private Label labelInvisibleShoulders;
    private PictureBox pictureBoxIconShoulders;
    public Panel panelPopupShoulders;
    public Panel panelPopupWeaponLeftHand;
    private PictureBox pictureBoxIconWeaponLeftHand;
    private Label labelWeaponLeftHandName;
    public Label labelInfoShouldersEquipped;
    public Label labelInfoWeaponLeftHandEquipped;
    private Label labelShouldersName;
    public Button buttonStartModifiers;
    public Label labelCritText;
    public Label labelDodgeText;
    public PictureBox pictureBoxDragonEggs;
    public Label labelDragonEggs;
    public Panel panelAct4Quest1;
    public Button buttonAct4Q1Town;
    private Button buttonAct4Quest1Continue;
    public TextBox textBoxAct4Quest1;
    public PictureBox pictureBoxAct4Mage;
    public Label labelAct4Q1;
    public Button buttonTalkMage;
    public Label labelPlayerCritDmg;
    private PictureBox pictureBoxXboxLogo;
    private Label labelXboxRecommended;
    public Panel panelXboxControlsLayout;
    public Panel panelAct3Q1;
    public Button buttonAct3Q1Town;
    private Button buttonAct3Q1Continue;
    public TextBox textBoxAct3Q1;
    public ComboBox comboBoxAct3Q1Frog;
    public Button buttonReforge;
    private ListView listViewItemStatsFrog;
    private ColumnHeader columnType;
    private ColumnHeader columnStat;
    private Button buttonCancelReforge;
    public Panel panelReforgeItemFrog;
    public Label labelAct3Q1;
    public PictureBox pictureBoxCompass;
    public PictureBox pictureBoxAct5Hero;
    public Button buttonReforgeStat;
    private Label labelVersionNumber;
    public PictureBox pictureBoxRuby;
    public Panel panelAct2Q1;
    public Button buttonAct2Q1Town;
    private Button buttonAct2Q1Continue;
    public TextBox textBoxAct2Q1;
    public Label labelAct2Q1;
    public PictureBox pictureBoxFrozenLily;
    public Button buttonDivine;
    public Button buttonBloodLust;
    public Button buttonSwiftAttack;
    public Button buttonRoarAttack;
    public Button buttonGuard;
    public Button btn_attack;
    public Label labelAct5Q1;
    public AxWMPLib.AxWindowsMediaPlayer axWMPAnyVideo;
    public AxWMPLib.AxWindowsMediaPlayer axWMPintroVid;
    public Panel panelIntroVidWMP;
    public Panel panelAnyVideo;
}
