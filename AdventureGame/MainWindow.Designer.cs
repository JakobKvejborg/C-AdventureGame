
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
        btn_attack = new Button();
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
        buttonBloodLust = new Button();
        buttonUpgradeItem = new Button();
        buttonLearnTechnique = new Button();
        buttonSwiftAttack = new Button();
        buttonRoarAttack = new Button();
        buttonAct1Quest1Continue = new Button();
        buttonAct1Q1Town = new Button();
        comboBoxInventory = new ComboBox();
        buttonDivine = new Button();
        buttonAct4Q1Town = new Button();
        buttonAct4Quest1Continue = new Button();
        buttonGuard = new Button();
        buttonAct3Q1Town = new Button();
        buttonAct3Q1Continue = new Button();
        buttonTalkMage = new Button();
        buttonReforge = new Button();
        buttonReforgeStat = new Button();
        buttonAct2Q1Town = new Button();
        buttonAct2Q1Continue = new Button();
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
        labelCritText = new Label();
        labelDodgeText = new Label();
        panelPopupWeaponLeftHand = new Panel();
        pictureBoxIconWeaponLeftHand = new PictureBox();
        labelInfoWeaponLeftHandEquipped = new Label();
        labelWeaponLeftHandName = new Label();
        panelPopupShoulders = new Panel();
        labelShouldersName = new Label();
        pictureBoxIconShoulders = new PictureBox();
        labelInfoShouldersEquipped = new Label();
        labelInvisibleWeaponLeftHand = new Label();
        labelGold = new Label();
        panelPopupInventoryInfo = new Panel();
        pictureBoxInventoryIcon = new PictureBox();
        labelInventoryItemInfo = new Label();
        labelHpPopup = new Label();
        panelPopupBelt = new Panel();
        pictureBoxIconBelt = new PictureBox();
        labelInfoBeltEquipped = new Label();
        labelBeltName = new Label();
        panelPopupLeggings = new Panel();
        pictureBoxIconLeggings = new PictureBox();
        labelInfoLeggingsEquipped = new Label();
        labelLeggingsName = new Label();
        panelPopupHelmet = new Panel();
        pictureBoxIconHelmet = new PictureBox();
        labelInfoHelmetEquipped = new Label();
        labelHelmetName = new Label();
        panelPopupAmulet = new Panel();
        pictureBoxIconAmulet = new PictureBox();
        labelInfoAmuletEquipped = new Label();
        labelAmuletName = new Label();
        panelPopupBoots = new Panel();
        pictureBoxIconBoots = new PictureBox();
        labelInfoBootsEquipped = new Label();
        labelBootsName = new Label();
        labelInvisibleBoots = new Label();
        panelPopupGloves = new Panel();
        pictureBoxIconGloves = new PictureBox();
        labelInfoGlovesEquipped = new Label();
        labelGlovesName = new Label();
        labelInvisibleGloves = new Label();
        panelPopupArmor = new Panel();
        pictureBoxIconArmor = new PictureBox();
        labelInfoArmorEquipped = new Label();
        labelArmorName = new Label();
        labelInvisibleArmor = new Label();
        labelGoldPopup = new Label();
        panelPopupWeaponRightHand = new Panel();
        pictureBoxIconWeaponRightHand = new PictureBox();
        labelInfoWeaponRightHandEquipped = new Label();
        labelWeaponRightHandName = new Label();
        panelInventory = new Panel();
        labelRegeneration = new Label();
        labelCritChance = new Label();
        labelInvisibleAmulet = new Label();
        labelInvisibleLeggings = new Label();
        labelInvisibleShoulders = new Label();
        labelInvisibleHelmet = new Label();
        labelInvisibleBelt = new Label();
        pictureBoxHero = new PictureBox();
        pictureBoxInventory = new PictureBox();
        labelPlayerCritDmg = new Label();
        panelTown = new Panel();
        labelAct2Q1 = new Label();
        pictureBoxAct5Hero = new PictureBox();
        labelAct3Q1 = new Label();
        labelAct4Q1 = new Label();
        labelAct1Quest1 = new Label();
        pictureBoxAct1ArtsTeacher = new PictureBox();
        comboBoxUpgradeItems = new ComboBox();
        txtBox_Town = new TextBox();
        pictureBoxCompass = new PictureBox();
        pictureBoxTown = new PictureBox();
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
        ((System.ComponentModel.ISupportInitialize)pictureBoxHeroBag).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxLoot).BeginInit();
        panelMonster.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxDragonEggs).BeginInit();
        panelEncounter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxFrozenLily).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxRuby).BeginInit();
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
        panelPopupHelmet.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconHelmet).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)pictureBoxTown).BeginInit();
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
        SuspendLayout();
        // 
        // btn_continue
        // 
        btn_continue.Location = new Point(9, 111);
        btn_continue.Name = "btn_continue";
        btn_continue.Size = new Size(94, 29);
        btn_continue.TabIndex = 0;
        btn_continue.Text = "Continue";
        toolTip.SetToolTip(btn_continue, "\"Enter\"");
        btn_continue.UseVisualStyleBackColor = true;
        btn_continue.Click += button1_Click_1;
        // 
        // btn_attack
        // 
        btn_attack.BackColor = Color.Gainsboro;
        btn_attack.Font = new Font("Matura MT Script Capitals", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn_attack.ForeColor = SystemColors.ActiveCaptionText;
        btn_attack.Location = new Point(5, 745);
        btn_attack.Name = "btn_attack";
        btn_attack.Size = new Size(98, 35);
        btn_attack.TabIndex = 5;
        btn_attack.Text = "Attack";
        toolTip.SetToolTip(btn_attack, "\"Space\" or \"1\"");
        btn_attack.UseVisualStyleBackColor = false;
        btn_attack.Click += btn_attack_Click;
        // 
        // labelCompassE
        // 
        labelCompassE.AutoSize = true;
        labelCompassE.ForeColor = Color.Transparent;
        labelCompassE.Location = new Point(103, 202);
        labelCompassE.Name = "labelCompassE";
        labelCompassE.Size = new Size(73, 60);
        labelCompassE.TabIndex = 7;
        labelCompassE.Text = "            \r\n            \r\n                \r\n";
        toolTip.SetToolTip(labelCompassE, "\"D\"");
        labelCompassE.Click += labelCompassE_Click;
        // 
        // labelCompassW
        // 
        labelCompassW.AutoSize = true;
        labelCompassW.ForeColor = Color.Transparent;
        labelCompassW.Location = new Point(5, 203);
        labelCompassW.Name = "labelCompassW";
        labelCompassW.Size = new Size(73, 60);
        labelCompassW.TabIndex = 6;
        labelCompassW.Text = "            \r\n            \r\n                \r\n";
        toolTip.SetToolTip(labelCompassW, "\"A\"");
        labelCompassW.Click += labelCompassW_Click;
        // 
        // buttonReturnToTown
        // 
        buttonReturnToTown.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonReturnToTown.ForeColor = Color.MidnightBlue;
        buttonReturnToTown.Location = new Point(107, 111);
        buttonReturnToTown.Name = "buttonReturnToTown";
        buttonReturnToTown.Size = new Size(98, 29);
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
        labelCompassN.Location = new Point(50, 143);
        labelCompassN.Name = "labelCompassN";
        labelCompassN.Size = new Size(81, 60);
        labelCompassN.TabIndex = 8;
        labelCompassN.Text = "            \r\n            \r\n                  ";
        toolTip.SetToolTip(labelCompassN, "\"W\"");
        labelCompassN.Click += labelCompassN_Click;
        // 
        // labelCompassS
        // 
        labelCompassS.AutoSize = true;
        labelCompassS.ForeColor = Color.Transparent;
        labelCompassS.Location = new Point(53, 261);
        labelCompassS.Name = "labelCompassS";
        labelCompassS.Size = new Size(73, 60);
        labelCompassS.TabIndex = 9;
        labelCompassS.Text = "            \r\n            \r\n                ";
        toolTip.SetToolTip(labelCompassS, "\"S\"");
        labelCompassS.Click += labelCompassS_Click;
        // 
        // buttonHeal
        // 
        buttonHeal.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonHeal.Location = new Point(32, 662);
        buttonHeal.Name = "buttonHeal";
        buttonHeal.Size = new Size(124, 31);
        buttonHeal.TabIndex = 11;
        buttonHeal.Text = "Healing 2G";
        toolTip.SetToolTip(buttonHeal, "\"H\"");
        buttonHeal.UseVisualStyleBackColor = true;
        buttonHeal.Click += buttonHeal_Click;
        // 
        // btn_Continuetown
        // 
        btn_Continuetown.Location = new Point(9, 111);
        btn_Continuetown.Name = "btn_Continuetown";
        btn_Continuetown.Size = new Size(94, 29);
        btn_Continuetown.TabIndex = 13;
        btn_Continuetown.Text = "Continue";
        toolTip.SetToolTip(btn_Continuetown, "\"Enter\"");
        btn_Continuetown.UseVisualStyleBackColor = true;
        btn_Continuetown.Click += btn_Continuetown_Click;
        // 
        // buttonEquipUnequip
        // 
        buttonEquipUnequip.Location = new Point(4, 58);
        buttonEquipUnequip.Name = "buttonEquipUnequip";
        buttonEquipUnequip.Size = new Size(151, 29);
        buttonEquipUnequip.TabIndex = 21;
        buttonEquipUnequip.Text = "Equip item";
        toolTip.SetToolTip(buttonEquipUnequip, "\"E\"");
        buttonEquipUnequip.UseVisualStyleBackColor = true;
        buttonEquipUnequip.Click += buttonEquipUnequip_Click;
        // 
        // buttonDiscardItem
        // 
        buttonDiscardItem.Location = new Point(4, 93);
        buttonDiscardItem.Name = "buttonDiscardItem";
        buttonDiscardItem.Size = new Size(151, 29);
        buttonDiscardItem.TabIndex = 4;
        buttonDiscardItem.Text = "Discard item";
        toolTip.SetToolTip(buttonDiscardItem, "\"T\"");
        buttonDiscardItem.UseVisualStyleBackColor = true;
        buttonDiscardItem.Click += buttonDiscardItem_Click;
        // 
        // pictureBoxHeroBag
        // 
        pictureBoxHeroBag.Image = Properties.Resources.bag2;
        pictureBoxHeroBag.Location = new Point(125, 558);
        pictureBoxHeroBag.Name = "pictureBoxHeroBag";
        pictureBoxHeroBag.Size = new Size(82, 98);
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
        labelPlayerArmor.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelPlayerArmor.ForeColor = Color.White;
        labelPlayerArmor.Location = new Point(8, 324);
        labelPlayerArmor.Name = "labelPlayerArmor";
        labelPlayerArmor.Size = new Size(59, 23);
        labelPlayerArmor.TabIndex = 11;
        labelPlayerArmor.Text = "armor";
        toolTip.SetToolTip(labelPlayerArmor, "The amount of damage blocked from an attack.");
        // 
        // pictureBoxLoot
        // 
        pictureBoxLoot.Image = (Image)resources.GetObject("pictureBoxLoot.Image");
        pictureBoxLoot.Location = new Point(299, 324);
        pictureBoxLoot.Name = "pictureBoxLoot";
        pictureBoxLoot.Size = new Size(209, 149);
        pictureBoxLoot.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxLoot.TabIndex = 34;
        pictureBoxLoot.TabStop = false;
        toolTip.SetToolTip(pictureBoxLoot, "\"F\"");
        pictureBoxLoot.Click += pictureBoxLoot_Click;
        // 
        // buttonBloodLust
        // 
        buttonBloodLust.BackColor = Color.Gainsboro;
        buttonBloodLust.Font = new Font("Matura MT Script Capitals", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonBloodLust.Location = new Point(105, 745);
        buttonBloodLust.Name = "buttonBloodLust";
        buttonBloodLust.Size = new Size(97, 35);
        buttonBloodLust.TabIndex = 37;
        buttonBloodLust.Text = "Bloodlust";
        toolTip.SetToolTip(buttonBloodLust, "\"2\"");
        buttonBloodLust.UseVisualStyleBackColor = false;
        buttonBloodLust.Click += buttonBloodLust_Click;
        // 
        // buttonUpgradeItem
        // 
        buttonUpgradeItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonUpgradeItem.Location = new Point(436, 311);
        buttonUpgradeItem.Name = "buttonUpgradeItem";
        buttonUpgradeItem.Size = new Size(81, 28);
        buttonUpgradeItem.TabIndex = 15;
        buttonUpgradeItem.Text = "Upgrade";
        toolTip.SetToolTip(buttonUpgradeItem, "\"U\"");
        buttonUpgradeItem.UseVisualStyleBackColor = true;
        buttonUpgradeItem.Click += buttonUpgradeItem_Click;
        // 
        // buttonLearnTechnique
        // 
        buttonLearnTechnique.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonLearnTechnique.Location = new Point(386, 614);
        buttonLearnTechnique.Name = "buttonLearnTechnique";
        buttonLearnTechnique.Size = new Size(124, 32);
        buttonLearnTechnique.TabIndex = 18;
        buttonLearnTechnique.Text = "Learn 10G";
        toolTip.SetToolTip(buttonLearnTechnique, "\"L\"");
        buttonLearnTechnique.UseVisualStyleBackColor = true;
        buttonLearnTechnique.Click += buttonLearnTechnique_Click;
        // 
        // buttonSwiftAttack
        // 
        buttonSwiftAttack.BackColor = Color.Gainsboro;
        buttonSwiftAttack.Font = new Font("Matura MT Script Capitals", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonSwiftAttack.Location = new Point(204, 745);
        buttonSwiftAttack.Name = "buttonSwiftAttack";
        buttonSwiftAttack.Size = new Size(93, 35);
        buttonSwiftAttack.TabIndex = 7;
        buttonSwiftAttack.Text = "Swift";
        toolTip.SetToolTip(buttonSwiftAttack, "\"3\"");
        buttonSwiftAttack.UseVisualStyleBackColor = false;
        buttonSwiftAttack.Click += buttonDodgeJab_Click;
        // 
        // buttonRoarAttack
        // 
        buttonRoarAttack.BackColor = Color.Gainsboro;
        buttonRoarAttack.Font = new Font("Matura MT Script Capitals", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonRoarAttack.Location = new Point(156, 716);
        buttonRoarAttack.Name = "buttonRoarAttack";
        buttonRoarAttack.Size = new Size(93, 35);
        buttonRoarAttack.TabIndex = 44;
        buttonRoarAttack.Text = "Roar";
        toolTip.SetToolTip(buttonRoarAttack, "\"4\"");
        buttonRoarAttack.UseVisualStyleBackColor = false;
        buttonRoarAttack.Click += buttonRoarAttack_Click;
        // 
        // buttonAct1Quest1Continue
        // 
        buttonAct1Quest1Continue.ForeColor = Color.Black;
        buttonAct1Quest1Continue.Location = new Point(9, 111);
        buttonAct1Quest1Continue.Name = "buttonAct1Quest1Continue";
        buttonAct1Quest1Continue.Size = new Size(94, 29);
        buttonAct1Quest1Continue.TabIndex = 3;
        buttonAct1Quest1Continue.Text = "Continue";
        toolTip.SetToolTip(buttonAct1Quest1Continue, "\"Enter\"");
        buttonAct1Quest1Continue.UseVisualStyleBackColor = true;
        buttonAct1Quest1Continue.Click += buttonAct1Quest1Continue_Click;
        // 
        // buttonAct1Q1Town
        // 
        buttonAct1Q1Town.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct1Q1Town.ForeColor = Color.MidnightBlue;
        buttonAct1Q1Town.Location = new Point(107, 111);
        buttonAct1Q1Town.Name = "buttonAct1Q1Town";
        buttonAct1Q1Town.Size = new Size(98, 29);
        buttonAct1Q1Town.TabIndex = 37;
        buttonAct1Q1Town.Text = "Town";
        toolTip.SetToolTip(buttonAct1Q1Town, "\"B\"");
        buttonAct1Q1Town.UseVisualStyleBackColor = true;
        buttonAct1Q1Town.Click += buttonAct1Q1Town_Click;
        // 
        // comboBoxInventory
        // 
        comboBoxInventory.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxInventory.FormattingEnabled = true;
        comboBoxInventory.Location = new Point(4, 23);
        comboBoxInventory.Name = "comboBoxInventory";
        comboBoxInventory.Size = new Size(151, 28);
        comboBoxInventory.TabIndex = 2;
        toolTip.SetToolTip(comboBoxInventory, "\"Tab\" & \"Arrows\"");
        // 
        // buttonDivine
        // 
        buttonDivine.BackColor = Color.Gainsboro;
        buttonDivine.Font = new Font("Matura MT Script Capitals", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonDivine.Location = new Point(298, 745);
        buttonDivine.Name = "buttonDivine";
        buttonDivine.Size = new Size(93, 35);
        buttonDivine.TabIndex = 58;
        buttonDivine.Text = "Divine";
        toolTip.SetToolTip(buttonDivine, "\"5\"");
        buttonDivine.UseVisualStyleBackColor = false;
        buttonDivine.Click += buttonDivine_Click;
        // 
        // buttonAct4Q1Town
        // 
        buttonAct4Q1Town.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct4Q1Town.ForeColor = Color.MidnightBlue;
        buttonAct4Q1Town.Location = new Point(107, 111);
        buttonAct4Q1Town.Name = "buttonAct4Q1Town";
        buttonAct4Q1Town.Size = new Size(98, 29);
        buttonAct4Q1Town.TabIndex = 37;
        buttonAct4Q1Town.Text = "Town";
        toolTip.SetToolTip(buttonAct4Q1Town, "\"B\"");
        buttonAct4Q1Town.UseVisualStyleBackColor = true;
        buttonAct4Q1Town.Click += buttonAct4Q1Town_Click;
        // 
        // buttonAct4Quest1Continue
        // 
        buttonAct4Quest1Continue.ForeColor = Color.Black;
        buttonAct4Quest1Continue.Location = new Point(9, 111);
        buttonAct4Quest1Continue.Name = "buttonAct4Quest1Continue";
        buttonAct4Quest1Continue.Size = new Size(94, 29);
        buttonAct4Quest1Continue.TabIndex = 3;
        buttonAct4Quest1Continue.Text = "Continue";
        toolTip.SetToolTip(buttonAct4Quest1Continue, "\"Enter\"");
        buttonAct4Quest1Continue.UseVisualStyleBackColor = true;
        buttonAct4Quest1Continue.Click += buttonAct4Quest1Continue_Click;
        // 
        // buttonGuard
        // 
        buttonGuard.BackColor = Color.Gainsboro;
        buttonGuard.Font = new Font("Matura MT Script Capitals", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonGuard.Location = new Point(251, 716);
        buttonGuard.Name = "buttonGuard";
        buttonGuard.Size = new Size(93, 35);
        buttonGuard.TabIndex = 62;
        buttonGuard.Text = "Guard";
        toolTip.SetToolTip(buttonGuard, "\"6\"");
        buttonGuard.UseVisualStyleBackColor = false;
        buttonGuard.Click += buttonGuard_Click;
        // 
        // buttonAct3Q1Town
        // 
        buttonAct3Q1Town.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct3Q1Town.ForeColor = Color.MidnightBlue;
        buttonAct3Q1Town.Location = new Point(107, 111);
        buttonAct3Q1Town.Name = "buttonAct3Q1Town";
        buttonAct3Q1Town.Size = new Size(98, 29);
        buttonAct3Q1Town.TabIndex = 37;
        buttonAct3Q1Town.Text = "Town";
        toolTip.SetToolTip(buttonAct3Q1Town, "\"B\"");
        buttonAct3Q1Town.UseVisualStyleBackColor = true;
        buttonAct3Q1Town.Click += buttonAct3Q1Town_Click;
        // 
        // buttonAct3Q1Continue
        // 
        buttonAct3Q1Continue.ForeColor = Color.Black;
        buttonAct3Q1Continue.Location = new Point(9, 111);
        buttonAct3Q1Continue.Name = "buttonAct3Q1Continue";
        buttonAct3Q1Continue.Size = new Size(94, 29);
        buttonAct3Q1Continue.TabIndex = 3;
        buttonAct3Q1Continue.Text = "Continue";
        toolTip.SetToolTip(buttonAct3Q1Continue, "\"Enter\"");
        buttonAct3Q1Continue.UseVisualStyleBackColor = true;
        // 
        // buttonTalkMage
        // 
        buttonTalkMage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonTalkMage.Location = new Point(398, 658);
        buttonTalkMage.Name = "buttonTalkMage";
        buttonTalkMage.Size = new Size(125, 31);
        buttonTalkMage.TabIndex = 22;
        buttonTalkMage.Text = "Talk To Mage";
        toolTip.SetToolTip(buttonTalkMage, "\"L\"");
        buttonTalkMage.UseVisualStyleBackColor = true;
        buttonTalkMage.Click += buttonTalkMage_Click;
        // 
        // buttonReforge
        // 
        buttonReforge.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonReforge.ForeColor = Color.Black;
        buttonReforge.Location = new Point(54, 367);
        buttonReforge.Name = "buttonReforge";
        buttonReforge.Size = new Size(100, 29);
        buttonReforge.TabIndex = 39;
        buttonReforge.Text = "Reforge";
        toolTip.SetToolTip(buttonReforge, "\"H\"");
        buttonReforge.UseVisualStyleBackColor = true;
        buttonReforge.Click += buttonReforge_Click;
        // 
        // buttonReforgeStat
        // 
        buttonReforgeStat.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonReforgeStat.ForeColor = Color.Black;
        buttonReforgeStat.Location = new Point(42, 173);
        buttonReforgeStat.Name = "buttonReforgeStat";
        buttonReforgeStat.Size = new Size(94, 29);
        buttonReforgeStat.TabIndex = 41;
        buttonReforgeStat.Text = "100G";
        toolTip.SetToolTip(buttonReforgeStat, "\"L\"");
        buttonReforgeStat.UseVisualStyleBackColor = true;
        buttonReforgeStat.Click += buttonReforgeStat_Click;
        // 
        // buttonAct2Q1Town
        // 
        buttonAct2Q1Town.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonAct2Q1Town.ForeColor = Color.MidnightBlue;
        buttonAct2Q1Town.Location = new Point(107, 111);
        buttonAct2Q1Town.Name = "buttonAct2Q1Town";
        buttonAct2Q1Town.Size = new Size(98, 29);
        buttonAct2Q1Town.TabIndex = 37;
        buttonAct2Q1Town.Text = "Town";
        toolTip.SetToolTip(buttonAct2Q1Town, "\"B\"");
        buttonAct2Q1Town.UseVisualStyleBackColor = true;
        buttonAct2Q1Town.Click += buttonAct2Q1Town_Click;
        // 
        // buttonAct2Q1Continue
        // 
        buttonAct2Q1Continue.ForeColor = Color.Black;
        buttonAct2Q1Continue.Location = new Point(9, 111);
        buttonAct2Q1Continue.Name = "buttonAct2Q1Continue";
        buttonAct2Q1Continue.Size = new Size(94, 29);
        buttonAct2Q1Continue.TabIndex = 3;
        buttonAct2Q1Continue.Text = "Continue";
        toolTip.SetToolTip(buttonAct2Q1Continue, "\"Enter\"");
        buttonAct2Q1Continue.UseVisualStyleBackColor = true;
        buttonAct2Q1Continue.Click += buttonAct2Q1Continue_Click;
        // 
        // labelInvisibleWeaponRightHandEquipped
        // 
        labelInvisibleWeaponRightHandEquipped.AutoSize = true;
        labelInvisibleWeaponRightHandEquipped.ForeColor = Color.Transparent;
        labelInvisibleWeaponRightHandEquipped.Location = new Point(213, 544);
        labelInvisibleWeaponRightHandEquipped.Name = "labelInvisibleWeaponRightHandEquipped";
        labelInvisibleWeaponRightHandEquipped.Size = new Size(89, 60);
        labelInvisibleWeaponRightHandEquipped.TabIndex = 24;
        labelInvisibleWeaponRightHandEquipped.Text = "            \r\n            \r\n                    \r\n";
        labelInvisibleWeaponRightHandEquipped.MouseEnter += labelInvisibleWeaponRightHandEquipped_MouseEnter;
        labelInvisibleWeaponRightHandEquipped.MouseLeave += labelInvisibleWeaponRightHandEquipped_MouseLeave;
        // 
        // textBoxEncounter
        // 
        textBoxEncounter.BackColor = Color.FromArgb(195, 195, 195);
        textBoxEncounter.Font = new Font("Microsoft Sans Serif", 12F);
        textBoxEncounter.Location = new Point(11, 15);
        textBoxEncounter.Multiline = true;
        textBoxEncounter.Name = "textBoxEncounter";
        textBoxEncounter.ReadOnly = true;
        textBoxEncounter.ScrollBars = ScrollBars.Vertical;
        textBoxEncounter.Size = new Size(519, 90);
        textBoxEncounter.TabIndex = 1;
        textBoxEncounter.Text = "Press ENTER to progress the story.";
        textBoxEncounter.TextChanged += textBox1_TextChanged;
        // 
        // labelInventory
        // 
        labelInventory.BackColor = Color.Transparent;
        labelInventory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelInventory.ForeColor = Color.White;
        labelInventory.Location = new Point(34, 0);
        labelInventory.Name = "labelInventory";
        labelInventory.Size = new Size(90, 20);
        labelInventory.TabIndex = 3;
        labelInventory.Text = "Inventory";
        labelInventory.Click += labelInventory_Click;
        // 
        // progressBarPlayerHP
        // 
        progressBarPlayerHP.ForeColor = Color.Blue;
        progressBarPlayerHP.Location = new Point(14, 198);
        progressBarPlayerHP.Name = "progressBarPlayerHP";
        progressBarPlayerHP.Size = new Size(212, 29);
        progressBarPlayerHP.TabIndex = 8;
        progressBarPlayerHP.Click += progressBar1_Click;
        // 
        // labelPlayerHP
        // 
        labelPlayerHP.AutoSize = true;
        labelPlayerHP.BackColor = Color.Transparent;
        labelPlayerHP.Font = new Font("Impact", 11F);
        labelPlayerHP.ForeColor = Color.White;
        labelPlayerHP.Location = new Point(14, 172);
        labelPlayerHP.Name = "labelPlayerHP";
        labelPlayerHP.Size = new Size(31, 23);
        labelPlayerHP.TabIndex = 9;
        labelPlayerHP.Text = "HP";
        // 
        // labelPlayerDamage
        // 
        labelPlayerDamage.AutoSize = true;
        labelPlayerDamage.BackColor = Color.Transparent;
        labelPlayerDamage.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelPlayerDamage.ForeColor = Color.White;
        labelPlayerDamage.Location = new Point(8, 231);
        labelPlayerDamage.Name = "labelPlayerDamage";
        labelPlayerDamage.Size = new Size(75, 23);
        labelPlayerDamage.TabIndex = 12;
        labelPlayerDamage.Text = "damage";
        // 
        // labelPlayerDodge
        // 
        labelPlayerDodge.AutoSize = true;
        labelPlayerDodge.BackColor = Color.Transparent;
        labelPlayerDodge.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelPlayerDodge.ForeColor = Color.White;
        labelPlayerDodge.Location = new Point(72, 354);
        labelPlayerDodge.Name = "labelPlayerDodge";
        labelPlayerDodge.Size = new Size(62, 23);
        labelPlayerDodge.TabIndex = 13;
        labelPlayerDodge.Text = "dodge";
        // 
        // labelHeroName
        // 
        labelHeroName.BackColor = Color.Transparent;
        labelHeroName.Font = new Font("Viner Hand ITC", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelHeroName.ForeColor = Color.SteelBlue;
        labelHeroName.Location = new Point(13, 143);
        labelHeroName.Name = "labelHeroName";
        labelHeroName.Size = new Size(84, 29);
        labelHeroName.TabIndex = 14;
        labelHeroName.Text = "Hero";
        // 
        // labelPlayerStrength
        // 
        labelPlayerStrength.AutoSize = true;
        labelPlayerStrength.BackColor = Color.Transparent;
        labelPlayerStrength.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelPlayerStrength.ForeColor = Color.White;
        labelPlayerStrength.Location = new Point(8, 262);
        labelPlayerStrength.Name = "labelPlayerStrength";
        labelPlayerStrength.Size = new Size(78, 23);
        labelPlayerStrength.TabIndex = 15;
        labelPlayerStrength.Text = "strength";
        // 
        // labelPlayerLifeSteal
        // 
        labelPlayerLifeSteal.AutoSize = true;
        labelPlayerLifeSteal.BackColor = Color.Transparent;
        labelPlayerLifeSteal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelPlayerLifeSteal.ForeColor = Color.White;
        labelPlayerLifeSteal.Location = new Point(8, 294);
        labelPlayerLifeSteal.Name = "labelPlayerLifeSteal";
        labelPlayerLifeSteal.Size = new Size(73, 23);
        labelPlayerLifeSteal.TabIndex = 16;
        labelPlayerLifeSteal.Text = "lifesteal";
        // 
        // labelGoldInPocket
        // 
        labelGoldInPocket.AutoSize = true;
        labelGoldInPocket.BackColor = Color.Transparent;
        labelGoldInPocket.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelGoldInPocket.ForeColor = Color.Gold;
        labelGoldInPocket.Location = new Point(189, 354);
        labelGoldInPocket.Name = "labelGoldInPocket";
        labelGoldInPocket.Size = new Size(47, 23);
        labelGoldInPocket.TabIndex = 17;
        labelGoldInPocket.Text = "gold";
        // 
        // labelLevel
        // 
        labelLevel.AutoSize = true;
        labelLevel.BackColor = Color.Transparent;
        labelLevel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelLevel.ForeColor = Color.White;
        labelLevel.Location = new Point(138, 231);
        labelLevel.Name = "labelLevel";
        labelLevel.Size = new Size(51, 23);
        labelLevel.TabIndex = 18;
        labelLevel.Text = "Level";
        // 
        // labelExperience
        // 
        labelExperience.AutoSize = true;
        labelExperience.BackColor = Color.Transparent;
        labelExperience.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelExperience.ForeColor = Color.White;
        labelExperience.Location = new Point(136, 261);
        labelExperience.Name = "labelExperience";
        labelExperience.Size = new Size(96, 23);
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
        panelMonster.Location = new Point(264, 155);
        panelMonster.Name = "panelMonster";
        panelMonster.Size = new Size(258, 360);
        panelMonster.TabIndex = 20;
        // 
        // pictureBoxMonster1
        // 
        pictureBoxMonster1.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBoxMonster1.Location = new Point(3, 78);
        pictureBoxMonster1.Name = "pictureBoxMonster1";
        pictureBoxMonster1.Size = new Size(252, 278);
        pictureBoxMonster1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxMonster1.TabIndex = 21;
        pictureBoxMonster1.TabStop = false;
        // 
        // progressBarMonsterHP
        // 
        progressBarMonsterHP.Location = new Point(24, 43);
        progressBarMonsterHP.Name = "progressBarMonsterHP";
        progressBarMonsterHP.Size = new Size(212, 29);
        progressBarMonsterHP.TabIndex = 2;
        // 
        // labelMonsterHp
        // 
        labelMonsterHp.AutoSize = true;
        labelMonsterHp.BackColor = Color.Transparent;
        labelMonsterHp.Font = new Font("Impact", 10F);
        labelMonsterHp.ForeColor = Color.White;
        labelMonsterHp.Location = new Point(24, 20);
        labelMonsterHp.Name = "labelMonsterHp";
        labelMonsterHp.Size = new Size(31, 21);
        labelMonsterHp.TabIndex = 1;
        labelMonsterHp.Text = "HP:";
        // 
        // labelMonsterName
        // 
        labelMonsterName.AutoSize = true;
        labelMonsterName.BackColor = Color.Transparent;
        labelMonsterName.Font = new Font("Impact", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelMonsterName.ForeColor = Color.White;
        labelMonsterName.Location = new Point(22, -1);
        labelMonsterName.Name = "labelMonsterName";
        labelMonsterName.Size = new Size(110, 22);
        labelMonsterName.TabIndex = 0;
        labelMonsterName.Text = "monsterName";
        // 
        // labelDragonEggs
        // 
        labelDragonEggs.AutoSize = true;
        labelDragonEggs.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelDragonEggs.ForeColor = Color.IndianRed;
        labelDragonEggs.Location = new Point(180, 146);
        labelDragonEggs.Name = "labelDragonEggs";
        labelDragonEggs.Size = new Size(26, 20);
        labelDragonEggs.TabIndex = 60;
        labelDragonEggs.Text = "1x";
        // 
        // pictureBoxDragonEggs
        // 
        pictureBoxDragonEggs.Image = Properties.Resources.dragonegg;
        pictureBoxDragonEggs.Location = new Point(208, 105);
        pictureBoxDragonEggs.Name = "pictureBoxDragonEggs";
        pictureBoxDragonEggs.Size = new Size(51, 71);
        pictureBoxDragonEggs.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxDragonEggs.TabIndex = 59;
        pictureBoxDragonEggs.TabStop = false;
        // 
        // panelEncounter
        // 
        panelEncounter.BackColor = Color.Transparent;
        panelEncounter.BackgroundImage = Properties.Resources.castle;
        panelEncounter.BackgroundImageLayout = ImageLayout.Stretch;
        panelEncounter.Controls.Add(pictureBoxFrozenLily);
        panelEncounter.Controls.Add(pictureBoxRuby);
        panelEncounter.Controls.Add(labelDragonEggs);
        panelEncounter.Controls.Add(pictureBoxDragonEggs);
        panelEncounter.Controls.Add(buttonDivine);
        panelEncounter.Controls.Add(labelCritText);
        panelEncounter.Controls.Add(labelDodgeText);
        panelEncounter.Controls.Add(panelPopupWeaponLeftHand);
        panelEncounter.Controls.Add(panelPopupShoulders);
        panelEncounter.Controls.Add(labelInvisibleWeaponLeftHand);
        panelEncounter.Controls.Add(labelGold);
        panelEncounter.Controls.Add(panelPopupInventoryInfo);
        panelEncounter.Controls.Add(labelHpPopup);
        panelEncounter.Controls.Add(panelPopupBelt);
        panelEncounter.Controls.Add(panelPopupLeggings);
        panelEncounter.Controls.Add(panelPopupHelmet);
        panelEncounter.Controls.Add(panelPopupAmulet);
        panelEncounter.Controls.Add(buttonBloodLust);
        panelEncounter.Controls.Add(buttonSwiftAttack);
        panelEncounter.Controls.Add(buttonRoarAttack);
        panelEncounter.Controls.Add(buttonGuard);
        panelEncounter.Controls.Add(btn_attack);
        panelEncounter.Controls.Add(buttonReturnToTown);
        panelEncounter.Controls.Add(pictureBoxLoot);
        panelEncounter.Controls.Add(panelPopupBoots);
        panelEncounter.Controls.Add(labelInvisibleBoots);
        panelEncounter.Controls.Add(panelPopupGloves);
        panelEncounter.Controls.Add(labelInvisibleGloves);
        panelEncounter.Controls.Add(panelPopupArmor);
        panelEncounter.Controls.Add(labelInvisibleArmor);
        panelEncounter.Controls.Add(labelGoldPopup);
        panelEncounter.Controls.Add(panelPopupWeaponRightHand);
        panelEncounter.Controls.Add(textBoxEncounter);
        panelEncounter.Controls.Add(btn_continue);
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
        panelEncounter.Controls.Add(labelCritChance);
        panelEncounter.Controls.Add(labelPlayerArmor);
        panelEncounter.Controls.Add(labelPlayerHP);
        panelEncounter.Controls.Add(progressBarPlayerHP);
        panelEncounter.Controls.Add(labelInvisibleWeaponRightHandEquipped);
        panelEncounter.Controls.Add(labelInvisibleAmulet);
        panelEncounter.Controls.Add(labelInvisibleLeggings);
        panelEncounter.Controls.Add(labelInvisibleShoulders);
        panelEncounter.Controls.Add(labelInvisibleHelmet);
        panelEncounter.Controls.Add(labelInvisibleBelt);
        panelEncounter.Controls.Add(pictureBoxHero);
        panelEncounter.Controls.Add(pictureBoxHeroBag);
        panelEncounter.Controls.Add(pictureBoxInventory);
        panelEncounter.Controls.Add(labelPlayerCritDmg);
        panelEncounter.Dock = DockStyle.Fill;
        panelEncounter.Location = new Point(0, 0);
        panelEncounter.Name = "panelEncounter";
        panelEncounter.Size = new Size(537, 797);
        panelEncounter.TabIndex = 22;
        // 
        // pictureBoxFrozenLily
        // 
        pictureBoxFrozenLily.Image = (Image)resources.GetObject("pictureBoxFrozenLily.Image");
        pictureBoxFrozenLily.Location = new Point(475, 735);
        pictureBoxFrozenLily.Name = "pictureBoxFrozenLily";
        pictureBoxFrozenLily.Size = new Size(51, 50);
        pictureBoxFrozenLily.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxFrozenLily.TabIndex = 64;
        pictureBoxFrozenLily.TabStop = false;
        // 
        // pictureBoxRuby
        // 
        pictureBoxRuby.Image = (Image)resources.GetObject("pictureBoxRuby.Image");
        pictureBoxRuby.Location = new Point(419, 735);
        pictureBoxRuby.Name = "pictureBoxRuby";
        pictureBoxRuby.Size = new Size(49, 50);
        pictureBoxRuby.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxRuby.TabIndex = 63;
        pictureBoxRuby.TabStop = false;
        // 
        // labelCritText
        // 
        labelCritText.AutoSize = true;
        labelCritText.BackColor = Color.Transparent;
        labelCritText.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelCritText.ForeColor = Color.White;
        labelCritText.Location = new Point(8, 383);
        labelCritText.Name = "labelCritText";
        labelCritText.Size = new Size(45, 23);
        labelCritText.TabIndex = 57;
        labelCritText.Text = "Crit:";
        // 
        // labelDodgeText
        // 
        labelDodgeText.AutoSize = true;
        labelDodgeText.BackColor = Color.Transparent;
        labelDodgeText.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelDodgeText.ForeColor = Color.White;
        labelDodgeText.Location = new Point(7, 354);
        labelDodgeText.Name = "labelDodgeText";
        labelDodgeText.Size = new Size(69, 23);
        labelDodgeText.TabIndex = 56;
        labelDodgeText.Text = "Dodge:";
        // 
        // panelPopupWeaponLeftHand
        // 
        panelPopupWeaponLeftHand.AutoSize = true;
        panelPopupWeaponLeftHand.BorderStyle = BorderStyle.Fixed3D;
        panelPopupWeaponLeftHand.Controls.Add(pictureBoxIconWeaponLeftHand);
        panelPopupWeaponLeftHand.Controls.Add(labelInfoWeaponLeftHandEquipped);
        panelPopupWeaponLeftHand.Controls.Add(labelWeaponLeftHandName);
        panelPopupWeaponLeftHand.Location = new Point(3, 559);
        panelPopupWeaponLeftHand.Name = "panelPopupWeaponLeftHand";
        panelPopupWeaponLeftHand.Size = new Size(171, 97);
        panelPopupWeaponLeftHand.TabIndex = 55;
        // 
        // pictureBoxIconWeaponLeftHand
        // 
        pictureBoxIconWeaponLeftHand.Image = Properties.Resources.hookicon;
        pictureBoxIconWeaponLeftHand.Location = new Point(120, 3);
        pictureBoxIconWeaponLeftHand.Name = "pictureBoxIconWeaponLeftHand";
        pictureBoxIconWeaponLeftHand.Size = new Size(41, 33);
        pictureBoxIconWeaponLeftHand.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconWeaponLeftHand.TabIndex = 3;
        pictureBoxIconWeaponLeftHand.TabStop = false;
        // 
        // labelInfoWeaponLeftHandEquipped
        // 
        labelInfoWeaponLeftHandEquipped.AutoSize = true;
        labelInfoWeaponLeftHandEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoWeaponLeftHandEquipped.ForeColor = Color.White;
        labelInfoWeaponLeftHandEquipped.Location = new Point(-1, 17);
        labelInfoWeaponLeftHandEquipped.Name = "labelInfoWeaponLeftHandEquipped";
        labelInfoWeaponLeftHandEquipped.Size = new Size(87, 16);
        labelInfoWeaponLeftHandEquipped.TabIndex = 1;
        labelInfoWeaponLeftHandEquipped.Text = "lefthandInfo";
        // 
        // labelWeaponLeftHandName
        // 
        labelWeaponLeftHandName.AutoSize = true;
        labelWeaponLeftHandName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelWeaponLeftHandName.ForeColor = SystemColors.ActiveCaption;
        labelWeaponLeftHandName.Location = new Point(1, -1);
        labelWeaponLeftHandName.Name = "labelWeaponLeftHandName";
        labelWeaponLeftHandName.Size = new Size(98, 16);
        labelWeaponLeftHandName.TabIndex = 0;
        labelWeaponLeftHandName.Text = "LeftHandName";
        // 
        // panelPopupShoulders
        // 
        panelPopupShoulders.AutoSize = true;
        panelPopupShoulders.BorderStyle = BorderStyle.Fixed3D;
        panelPopupShoulders.Controls.Add(labelShouldersName);
        panelPopupShoulders.Controls.Add(pictureBoxIconShoulders);
        panelPopupShoulders.Controls.Add(labelInfoShouldersEquipped);
        panelPopupShoulders.Location = new Point(163, 394);
        panelPopupShoulders.Name = "panelPopupShoulders";
        panelPopupShoulders.Size = new Size(171, 97);
        panelPopupShoulders.TabIndex = 54;
        // 
        // labelShouldersName
        // 
        labelShouldersName.AutoSize = true;
        labelShouldersName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelShouldersName.ForeColor = SystemColors.ActiveCaption;
        labelShouldersName.Location = new Point(1, 2);
        labelShouldersName.Name = "labelShouldersName";
        labelShouldersName.Size = new Size(105, 16);
        labelShouldersName.TabIndex = 4;
        labelShouldersName.Text = "ShouldersName";
        // 
        // pictureBoxIconShoulders
        // 
        pictureBoxIconShoulders.Image = Properties.Resources.shouldersicon;
        pictureBoxIconShoulders.Location = new Point(121, 3);
        pictureBoxIconShoulders.Name = "pictureBoxIconShoulders";
        pictureBoxIconShoulders.Size = new Size(41, 33);
        pictureBoxIconShoulders.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconShoulders.TabIndex = 3;
        pictureBoxIconShoulders.TabStop = false;
        // 
        // labelInfoShouldersEquipped
        // 
        labelInfoShouldersEquipped.AutoSize = true;
        labelInfoShouldersEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoShouldersEquipped.ForeColor = Color.White;
        labelInfoShouldersEquipped.Location = new Point(-1, 17);
        labelInfoShouldersEquipped.Name = "labelInfoShouldersEquipped";
        labelInfoShouldersEquipped.Size = new Size(95, 16);
        labelInfoShouldersEquipped.TabIndex = 1;
        labelInfoShouldersEquipped.Text = "shouldersInfo";
        // 
        // labelInvisibleWeaponLeftHand
        // 
        labelInvisibleWeaponLeftHand.AutoSize = true;
        labelInvisibleWeaponLeftHand.ForeColor = Color.Transparent;
        labelInvisibleWeaponLeftHand.Location = new Point(27, 544);
        labelInvisibleWeaponLeftHand.Name = "labelInvisibleWeaponLeftHand";
        labelInvisibleWeaponLeftHand.Size = new Size(41, 60);
        labelInvisibleWeaponLeftHand.TabIndex = 52;
        labelInvisibleWeaponLeftHand.Text = "       \r\n        \r\n ";
        labelInvisibleWeaponLeftHand.MouseEnter += labelInvisibleWeaponLeftHand_MouseEnter;
        labelInvisibleWeaponLeftHand.MouseLeave += labelInvisibleWeaponLeftHand_MouseLeave;
        // 
        // labelGold
        // 
        labelGold.AutoSize = true;
        labelGold.BackColor = Color.Transparent;
        labelGold.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelGold.ForeColor = Color.White;
        labelGold.Location = new Point(138, 354);
        labelGold.Name = "labelGold";
        labelGold.Size = new Size(53, 23);
        labelGold.TabIndex = 51;
        labelGold.Text = "Gold:";
        // 
        // panelPopupInventoryInfo
        // 
        panelPopupInventoryInfo.AutoSize = true;
        panelPopupInventoryInfo.BorderStyle = BorderStyle.Fixed3D;
        panelPopupInventoryInfo.Controls.Add(pictureBoxInventoryIcon);
        panelPopupInventoryInfo.Controls.Add(labelInventoryItemInfo);
        panelPopupInventoryInfo.Location = new Point(327, 607);
        panelPopupInventoryInfo.Name = "panelPopupInventoryInfo";
        panelPopupInventoryInfo.Size = new Size(199, 112);
        panelPopupInventoryInfo.TabIndex = 50;
        // 
        // pictureBoxInventoryIcon
        // 
        pictureBoxInventoryIcon.Location = new Point(142, 3);
        pictureBoxInventoryIcon.Name = "pictureBoxInventoryIcon";
        pictureBoxInventoryIcon.Size = new Size(41, 33);
        pictureBoxInventoryIcon.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxInventoryIcon.TabIndex = 3;
        pictureBoxInventoryIcon.TabStop = false;
        // 
        // labelInventoryItemInfo
        // 
        labelInventoryItemInfo.AutoSize = true;
        labelInventoryItemInfo.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInventoryItemInfo.ForeColor = Color.White;
        labelInventoryItemInfo.Location = new Point(1, 3);
        labelInventoryItemInfo.Name = "labelInventoryItemInfo";
        labelInventoryItemInfo.Size = new Size(127, 72);
        labelInventoryItemInfo.TabIndex = 1;
        labelInventoryItemInfo.Text = "inventoryInfo    \r\n\r\n\r\n\r\n";
        // 
        // labelHpPopup
        // 
        labelHpPopup.AutoSize = true;
        labelHpPopup.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelHpPopup.ForeColor = Color.Green;
        labelHpPopup.Location = new Point(213, 173);
        labelHpPopup.Name = "labelHpPopup";
        labelHpPopup.Size = new Size(38, 25);
        labelHpPopup.TabIndex = 49;
        labelHpPopup.Text = "HP";
        // 
        // panelPopupBelt
        // 
        panelPopupBelt.AutoSize = true;
        panelPopupBelt.BorderStyle = BorderStyle.Fixed3D;
        panelPopupBelt.Controls.Add(pictureBoxIconBelt);
        panelPopupBelt.Controls.Add(labelInfoBeltEquipped);
        panelPopupBelt.Controls.Add(labelBeltName);
        panelPopupBelt.Location = new Point(93, 541);
        panelPopupBelt.Name = "panelPopupBelt";
        panelPopupBelt.Size = new Size(170, 97);
        panelPopupBelt.TabIndex = 48;
        // 
        // pictureBoxIconBelt
        // 
        pictureBoxIconBelt.Image = Properties.Resources.belticon;
        pictureBoxIconBelt.Location = new Point(122, 3);
        pictureBoxIconBelt.Name = "pictureBoxIconBelt";
        pictureBoxIconBelt.Size = new Size(41, 33);
        pictureBoxIconBelt.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconBelt.TabIndex = 3;
        pictureBoxIconBelt.TabStop = false;
        // 
        // labelInfoBeltEquipped
        // 
        labelInfoBeltEquipped.AutoSize = true;
        labelInfoBeltEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoBeltEquipped.ForeColor = Color.White;
        labelInfoBeltEquipped.Location = new Point(-1, 17);
        labelInfoBeltEquipped.Name = "labelInfoBeltEquipped";
        labelInfoBeltEquipped.Size = new Size(58, 16);
        labelInfoBeltEquipped.TabIndex = 1;
        labelInfoBeltEquipped.Text = "beltInfo";
        // 
        // labelBeltName
        // 
        labelBeltName.AutoSize = true;
        labelBeltName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelBeltName.ForeColor = SystemColors.ActiveCaption;
        labelBeltName.Location = new Point(1, -1);
        labelBeltName.Name = "labelBeltName";
        labelBeltName.Size = new Size(66, 16);
        labelBeltName.TabIndex = 0;
        labelBeltName.Text = "beltName";
        // 
        // panelPopupLeggings
        // 
        panelPopupLeggings.AutoScroll = true;
        panelPopupLeggings.AutoSize = true;
        panelPopupLeggings.BorderStyle = BorderStyle.Fixed3D;
        panelPopupLeggings.Controls.Add(pictureBoxIconLeggings);
        panelPopupLeggings.Controls.Add(labelInfoLeggingsEquipped);
        panelPopupLeggings.Controls.Add(labelLeggingsName);
        panelPopupLeggings.Location = new Point(85, 491);
        panelPopupLeggings.Name = "panelPopupLeggings";
        panelPopupLeggings.Size = new Size(178, 97);
        panelPopupLeggings.TabIndex = 47;
        // 
        // pictureBoxIconLeggings
        // 
        pictureBoxIconLeggings.Image = Properties.Resources.leggingsicon;
        pictureBoxIconLeggings.Location = new Point(130, 5);
        pictureBoxIconLeggings.Name = "pictureBoxIconLeggings";
        pictureBoxIconLeggings.Size = new Size(41, 33);
        pictureBoxIconLeggings.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconLeggings.TabIndex = 3;
        pictureBoxIconLeggings.TabStop = false;
        // 
        // labelInfoLeggingsEquipped
        // 
        labelInfoLeggingsEquipped.AutoSize = true;
        labelInfoLeggingsEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoLeggingsEquipped.ForeColor = Color.White;
        labelInfoLeggingsEquipped.Location = new Point(-1, 17);
        labelInfoLeggingsEquipped.Name = "labelInfoLeggingsEquipped";
        labelInfoLeggingsEquipped.Size = new Size(86, 16);
        labelInfoLeggingsEquipped.TabIndex = 1;
        labelInfoLeggingsEquipped.Text = "leggingsInfo";
        // 
        // labelLeggingsName
        // 
        labelLeggingsName.AutoSize = true;
        labelLeggingsName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelLeggingsName.ForeColor = SystemColors.ActiveCaption;
        labelLeggingsName.Location = new Point(1, -1);
        labelLeggingsName.Name = "labelLeggingsName";
        labelLeggingsName.Size = new Size(96, 16);
        labelLeggingsName.TabIndex = 0;
        labelLeggingsName.Text = "leggingsName";
        // 
        // panelPopupHelmet
        // 
        panelPopupHelmet.AutoScroll = true;
        panelPopupHelmet.AutoSize = true;
        panelPopupHelmet.BorderStyle = BorderStyle.Fixed3D;
        panelPopupHelmet.Controls.Add(pictureBoxIconHelmet);
        panelPopupHelmet.Controls.Add(labelInfoHelmetEquipped);
        panelPopupHelmet.Controls.Add(labelHelmetName);
        panelPopupHelmet.Location = new Point(91, 417);
        panelPopupHelmet.Name = "panelPopupHelmet";
        panelPopupHelmet.Size = new Size(170, 97);
        panelPopupHelmet.TabIndex = 45;
        // 
        // pictureBoxIconHelmet
        // 
        pictureBoxIconHelmet.Image = Properties.Resources.helmeticon;
        pictureBoxIconHelmet.Location = new Point(120, 3);
        pictureBoxIconHelmet.Name = "pictureBoxIconHelmet";
        pictureBoxIconHelmet.Size = new Size(41, 33);
        pictureBoxIconHelmet.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconHelmet.TabIndex = 3;
        pictureBoxIconHelmet.TabStop = false;
        // 
        // labelInfoHelmetEquipped
        // 
        labelInfoHelmetEquipped.AutoSize = true;
        labelInfoHelmetEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoHelmetEquipped.ForeColor = Color.White;
        labelInfoHelmetEquipped.Location = new Point(-1, 17);
        labelInfoHelmetEquipped.Name = "labelInfoHelmetEquipped";
        labelInfoHelmetEquipped.Size = new Size(77, 16);
        labelInfoHelmetEquipped.TabIndex = 1;
        labelInfoHelmetEquipped.Text = "helmetInfo";
        // 
        // labelHelmetName
        // 
        labelHelmetName.AutoSize = true;
        labelHelmetName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelHelmetName.ForeColor = SystemColors.ActiveCaption;
        labelHelmetName.Location = new Point(1, -1);
        labelHelmetName.Name = "labelHelmetName";
        labelHelmetName.Size = new Size(87, 16);
        labelHelmetName.TabIndex = 0;
        labelHelmetName.Text = "HelmetName";
        // 
        // panelPopupAmulet
        // 
        panelPopupAmulet.AutoSize = true;
        panelPopupAmulet.BorderStyle = BorderStyle.Fixed3D;
        panelPopupAmulet.Controls.Add(pictureBoxIconAmulet);
        panelPopupAmulet.Controls.Add(labelInfoAmuletEquipped);
        panelPopupAmulet.Controls.Add(labelAmuletName);
        panelPopupAmulet.Location = new Point(9, 435);
        panelPopupAmulet.Name = "panelPopupAmulet";
        panelPopupAmulet.Size = new Size(177, 97);
        panelPopupAmulet.TabIndex = 43;
        // 
        // pictureBoxIconAmulet
        // 
        pictureBoxIconAmulet.Image = Properties.Resources.amuleticon;
        pictureBoxIconAmulet.Location = new Point(122, 3);
        pictureBoxIconAmulet.Name = "pictureBoxIconAmulet";
        pictureBoxIconAmulet.Size = new Size(41, 33);
        pictureBoxIconAmulet.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconAmulet.TabIndex = 3;
        pictureBoxIconAmulet.TabStop = false;
        // 
        // labelInfoAmuletEquipped
        // 
        labelInfoAmuletEquipped.AutoSize = true;
        labelInfoAmuletEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoAmuletEquipped.ForeColor = Color.White;
        labelInfoAmuletEquipped.Location = new Point(-1, 17);
        labelInfoAmuletEquipped.Name = "labelInfoAmuletEquipped";
        labelInfoAmuletEquipped.Size = new Size(78, 16);
        labelInfoAmuletEquipped.TabIndex = 1;
        labelInfoAmuletEquipped.Text = "AmuletInfo";
        // 
        // labelAmuletName
        // 
        labelAmuletName.AutoSize = true;
        labelAmuletName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelAmuletName.ForeColor = SystemColors.ActiveCaption;
        labelAmuletName.Location = new Point(1, -1);
        labelAmuletName.Name = "labelAmuletName";
        labelAmuletName.Size = new Size(85, 16);
        labelAmuletName.TabIndex = 0;
        labelAmuletName.Text = "AmuletName";
        // 
        // panelPopupBoots
        // 
        panelPopupBoots.AutoSize = true;
        panelPopupBoots.BorderStyle = BorderStyle.Fixed3D;
        panelPopupBoots.Controls.Add(pictureBoxIconBoots);
        panelPopupBoots.Controls.Add(labelInfoBootsEquipped);
        panelPopupBoots.Controls.Add(labelBootsName);
        panelPopupBoots.Location = new Point(103, 600);
        panelPopupBoots.Name = "panelPopupBoots";
        panelPopupBoots.Size = new Size(171, 97);
        panelPopupBoots.TabIndex = 29;
        // 
        // pictureBoxIconBoots
        // 
        pictureBoxIconBoots.Image = Properties.Resources.bootsicon;
        pictureBoxIconBoots.Location = new Point(121, 3);
        pictureBoxIconBoots.Name = "pictureBoxIconBoots";
        pictureBoxIconBoots.Size = new Size(41, 33);
        pictureBoxIconBoots.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconBoots.TabIndex = 3;
        pictureBoxIconBoots.TabStop = false;
        // 
        // labelInfoBootsEquipped
        // 
        labelInfoBootsEquipped.AutoSize = true;
        labelInfoBootsEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoBootsEquipped.ForeColor = Color.White;
        labelInfoBootsEquipped.Location = new Point(-1, 17);
        labelInfoBootsEquipped.Name = "labelInfoBootsEquipped";
        labelInfoBootsEquipped.Size = new Size(84, 16);
        labelInfoBootsEquipped.TabIndex = 1;
        labelInfoBootsEquipped.Text = "weaponInfo";
        // 
        // labelBootsName
        // 
        labelBootsName.AutoSize = true;
        labelBootsName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelBootsName.ForeColor = SystemColors.ActiveCaption;
        labelBootsName.Location = new Point(1, -1);
        labelBootsName.Name = "labelBootsName";
        labelBootsName.Size = new Size(78, 16);
        labelBootsName.TabIndex = 0;
        labelBootsName.Text = "bootsName";
        // 
        // labelInvisibleBoots
        // 
        labelInvisibleBoots.AutoSize = true;
        labelInvisibleBoots.ForeColor = Color.Transparent;
        labelInvisibleBoots.Location = new Point(53, 674);
        labelInvisibleBoots.Name = "labelInvisibleBoots";
        labelInvisibleBoots.Size = new Size(133, 60);
        labelInvisibleBoots.TabIndex = 28;
        labelInvisibleBoots.Text = "            \r\n            \r\n                               ";
        labelInvisibleBoots.MouseEnter += labelInvisibleBoots_MouseEnter;
        labelInvisibleBoots.MouseLeave += labelInvisibleBoots_MouseLeave;
        // 
        // panelPopupGloves
        // 
        panelPopupGloves.AutoSize = true;
        panelPopupGloves.BorderStyle = BorderStyle.Fixed3D;
        panelPopupGloves.Controls.Add(pictureBoxIconGloves);
        panelPopupGloves.Controls.Add(labelInfoGlovesEquipped);
        panelPopupGloves.Controls.Add(labelGlovesName);
        panelPopupGloves.Location = new Point(145, 436);
        panelPopupGloves.Name = "panelPopupGloves";
        panelPopupGloves.Size = new Size(164, 97);
        panelPopupGloves.TabIndex = 31;
        // 
        // pictureBoxIconGloves
        // 
        pictureBoxIconGloves.Image = Properties.Resources.gauntletsicon;
        pictureBoxIconGloves.Location = new Point(106, 5);
        pictureBoxIconGloves.Name = "pictureBoxIconGloves";
        pictureBoxIconGloves.Size = new Size(41, 33);
        pictureBoxIconGloves.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconGloves.TabIndex = 3;
        pictureBoxIconGloves.TabStop = false;
        // 
        // labelInfoGlovesEquipped
        // 
        labelInfoGlovesEquipped.AutoSize = true;
        labelInfoGlovesEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoGlovesEquipped.ForeColor = Color.White;
        labelInfoGlovesEquipped.Location = new Point(-1, 17);
        labelInfoGlovesEquipped.Name = "labelInfoGlovesEquipped";
        labelInfoGlovesEquipped.Size = new Size(75, 16);
        labelInfoGlovesEquipped.TabIndex = 1;
        labelInfoGlovesEquipped.Text = "glovesInfo";
        // 
        // labelGlovesName
        // 
        labelGlovesName.AutoSize = true;
        labelGlovesName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelGlovesName.ForeColor = SystemColors.ActiveCaption;
        labelGlovesName.Location = new Point(1, -1);
        labelGlovesName.Name = "labelGlovesName";
        labelGlovesName.Size = new Size(87, 16);
        labelGlovesName.TabIndex = 0;
        labelGlovesName.Text = "GlovesName";
        // 
        // labelInvisibleGloves
        // 
        labelInvisibleGloves.AutoSize = true;
        labelInvisibleGloves.ForeColor = Color.Transparent;
        labelInvisibleGloves.Location = new Point(149, 495);
        labelInvisibleGloves.Name = "labelInvisibleGloves";
        labelInvisibleGloves.Size = new Size(33, 60);
        labelInvisibleGloves.TabIndex = 30;
        labelInvisibleGloves.Text = "     \r\n     \r\n      ";
        labelInvisibleGloves.MouseEnter += labelInvisibleGloves_MouseEnter;
        labelInvisibleGloves.MouseLeave += labelInvisibleGloves_MouseLeave;
        // 
        // panelPopupArmor
        // 
        panelPopupArmor.AutoSize = true;
        panelPopupArmor.BorderStyle = BorderStyle.Fixed3D;
        panelPopupArmor.Controls.Add(pictureBoxIconArmor);
        panelPopupArmor.Controls.Add(labelInfoArmorEquipped);
        panelPopupArmor.Controls.Add(labelArmorName);
        panelPopupArmor.Location = new Point(115, 402);
        panelPopupArmor.Name = "panelPopupArmor";
        panelPopupArmor.Size = new Size(187, 97);
        panelPopupArmor.TabIndex = 27;
        // 
        // pictureBoxIconArmor
        // 
        pictureBoxIconArmor.Image = Properties.Resources.armoricon;
        pictureBoxIconArmor.Location = new Point(134, 5);
        pictureBoxIconArmor.Name = "pictureBoxIconArmor";
        pictureBoxIconArmor.Size = new Size(41, 33);
        pictureBoxIconArmor.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconArmor.TabIndex = 4;
        pictureBoxIconArmor.TabStop = false;
        // 
        // labelInfoArmorEquipped
        // 
        labelInfoArmorEquipped.AutoSize = true;
        labelInfoArmorEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoArmorEquipped.ForeColor = Color.White;
        labelInfoArmorEquipped.Location = new Point(-1, 17);
        labelInfoArmorEquipped.Name = "labelInfoArmorEquipped";
        labelInfoArmorEquipped.Size = new Size(70, 16);
        labelInfoArmorEquipped.TabIndex = 1;
        labelInfoArmorEquipped.Text = "armorInfo";
        // 
        // labelArmorName
        // 
        labelArmorName.AutoSize = true;
        labelArmorName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelArmorName.ForeColor = SystemColors.ActiveCaption;
        labelArmorName.Location = new Point(1, -1);
        labelArmorName.Name = "labelArmorName";
        labelArmorName.Size = new Size(80, 16);
        labelArmorName.TabIndex = 0;
        labelArmorName.Text = "ArmorName";
        // 
        // labelInvisibleArmor
        // 
        labelInvisibleArmor.AutoSize = true;
        labelInvisibleArmor.ForeColor = Color.Transparent;
        labelInvisibleArmor.Location = new Point(85, 453);
        labelInvisibleArmor.Name = "labelInvisibleArmor";
        labelInvisibleArmor.Size = new Size(53, 60);
        labelInvisibleArmor.TabIndex = 26;
        labelInvisibleArmor.Text = "     \r\n       \r\n           ";
        labelInvisibleArmor.MouseEnter += labelInvisibleArmor_MouseEnter;
        labelInvisibleArmor.MouseLeave += labelInvisibleArmor_MouseLeave;
        // 
        // labelGoldPopup
        // 
        labelGoldPopup.AutoSize = true;
        labelGoldPopup.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelGoldPopup.ForeColor = Color.Gold;
        labelGoldPopup.Location = new Point(245, 354);
        labelGoldPopup.Name = "labelGoldPopup";
        labelGoldPopup.Size = new Size(57, 23);
        labelGoldPopup.TabIndex = 35;
        labelGoldPopup.Text = "GOLD";
        // 
        // panelPopupWeaponRightHand
        // 
        panelPopupWeaponRightHand.AutoSize = true;
        panelPopupWeaponRightHand.BackColor = Color.Transparent;
        panelPopupWeaponRightHand.BorderStyle = BorderStyle.Fixed3D;
        panelPopupWeaponRightHand.Controls.Add(pictureBoxIconWeaponRightHand);
        panelPopupWeaponRightHand.Controls.Add(labelInfoWeaponRightHandEquipped);
        panelPopupWeaponRightHand.Controls.Add(labelWeaponRightHandName);
        panelPopupWeaponRightHand.Location = new Point(252, 497);
        panelPopupWeaponRightHand.Name = "panelPopupWeaponRightHand";
        panelPopupWeaponRightHand.Size = new Size(164, 97);
        panelPopupWeaponRightHand.TabIndex = 25;
        // 
        // pictureBoxIconWeaponRightHand
        // 
        pictureBoxIconWeaponRightHand.Image = Properties.Resources.swordicon;
        pictureBoxIconWeaponRightHand.Location = new Point(114, 3);
        pictureBoxIconWeaponRightHand.Name = "pictureBoxIconWeaponRightHand";
        pictureBoxIconWeaponRightHand.Size = new Size(41, 33);
        pictureBoxIconWeaponRightHand.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxIconWeaponRightHand.TabIndex = 2;
        pictureBoxIconWeaponRightHand.TabStop = false;
        // 
        // labelInfoWeaponRightHandEquipped
        // 
        labelInfoWeaponRightHandEquipped.AutoSize = true;
        labelInfoWeaponRightHandEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoWeaponRightHandEquipped.ForeColor = Color.White;
        labelInfoWeaponRightHandEquipped.Location = new Point(-1, 17);
        labelInfoWeaponRightHandEquipped.Name = "labelInfoWeaponRightHandEquipped";
        labelInfoWeaponRightHandEquipped.Size = new Size(84, 16);
        labelInfoWeaponRightHandEquipped.TabIndex = 1;
        labelInfoWeaponRightHandEquipped.Text = "weaponInfo";
        // 
        // labelWeaponRightHandName
        // 
        labelWeaponRightHandName.AutoSize = true;
        labelWeaponRightHandName.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelWeaponRightHandName.ForeColor = SystemColors.ActiveCaption;
        labelWeaponRightHandName.Location = new Point(1, -1);
        labelWeaponRightHandName.Name = "labelWeaponRightHandName";
        labelWeaponRightHandName.Size = new Size(92, 16);
        labelWeaponRightHandName.TabIndex = 0;
        labelWeaponRightHandName.Text = "weaponName";
        // 
        // panelInventory
        // 
        panelInventory.Controls.Add(labelInventory);
        panelInventory.Controls.Add(buttonDiscardItem);
        panelInventory.Controls.Add(comboBoxInventory);
        panelInventory.Controls.Add(buttonEquipUnequip);
        panelInventory.Location = new Point(334, 554);
        panelInventory.Name = "panelInventory";
        panelInventory.Size = new Size(159, 124);
        panelInventory.TabIndex = 23;
        // 
        // labelRegeneration
        // 
        labelRegeneration.AutoSize = true;
        labelRegeneration.BackColor = Color.Transparent;
        labelRegeneration.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelRegeneration.ForeColor = Color.White;
        labelRegeneration.Location = new Point(138, 291);
        labelRegeneration.Name = "labelRegeneration";
        labelRegeneration.Size = new Size(117, 23);
        labelRegeneration.TabIndex = 39;
        labelRegeneration.Text = "Regeneration";
        // 
        // labelCritChance
        // 
        labelCritChance.AutoSize = true;
        labelCritChance.BackColor = Color.Transparent;
        labelCritChance.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelCritChance.ForeColor = Color.White;
        labelCritChance.Location = new Point(50, 383);
        labelCritChance.Name = "labelCritChance";
        labelCritChance.Size = new Size(37, 23);
        labelCritChance.TabIndex = 38;
        labelCritChance.Text = "crit";
        // 
        // labelInvisibleAmulet
        // 
        labelInvisibleAmulet.AutoSize = true;
        labelInvisibleAmulet.ForeColor = Color.Transparent;
        labelInvisibleAmulet.Location = new Point(89, 427);
        labelInvisibleAmulet.Name = "labelInvisibleAmulet";
        labelInvisibleAmulet.Size = new Size(41, 20);
        labelInvisibleAmulet.TabIndex = 40;
        labelInvisibleAmulet.Text = "        ";
        labelInvisibleAmulet.MouseEnter += labelInvisibleAmulet_MouseEnter;
        labelInvisibleAmulet.MouseLeave += labelInvisibleAmulet_MouseLeave;
        // 
        // labelInvisibleLeggings
        // 
        labelInvisibleLeggings.AutoSize = true;
        labelInvisibleLeggings.ForeColor = Color.Transparent;
        labelInvisibleLeggings.Location = new Point(80, 564);
        labelInvisibleLeggings.Name = "labelInvisibleLeggings";
        labelInvisibleLeggings.Size = new Size(65, 100);
        labelInvisibleLeggings.TabIndex = 46;
        labelInvisibleLeggings.Text = "              \r\n            \r\n\r\n\r\n\r\n";
        labelInvisibleLeggings.MouseEnter += labelInvisibleLeggings_MouseEnter;
        labelInvisibleLeggings.MouseLeave += labelInvisibleLeggings_MouseLeave;
        // 
        // labelInvisibleShoulders
        // 
        labelInvisibleShoulders.AutoSize = true;
        labelInvisibleShoulders.ForeColor = Color.Transparent;
        labelInvisibleShoulders.Location = new Point(118, 441);
        labelInvisibleShoulders.Name = "labelInvisibleShoulders";
        labelInvisibleShoulders.Size = new Size(45, 40);
        labelInvisibleShoulders.TabIndex = 53;
        labelInvisibleShoulders.Text = "         \r\n ";
        labelInvisibleShoulders.MouseEnter += labelInvisibleShoulders_MouseEnter;
        labelInvisibleShoulders.MouseLeave += labelInvisibleShoulders_MouseLeave;
        // 
        // labelInvisibleHelmet
        // 
        labelInvisibleHelmet.AutoSize = true;
        labelInvisibleHelmet.ForeColor = Color.Transparent;
        labelInvisibleHelmet.Location = new Point(89, 403);
        labelInvisibleHelmet.Name = "labelInvisibleHelmet";
        labelInvisibleHelmet.Size = new Size(41, 20);
        labelInvisibleHelmet.TabIndex = 42;
        labelInvisibleHelmet.Text = "        \r\n";
        labelInvisibleHelmet.MouseEnter += labelInvisibleHelmet_MouseEnter;
        labelInvisibleHelmet.MouseLeave += labelInvisibleHelmet_MouseLeave;
        // 
        // labelInvisibleBelt
        // 
        labelInvisibleBelt.AutoSize = true;
        labelInvisibleBelt.ForeColor = Color.Transparent;
        labelInvisibleBelt.Location = new Point(85, 523);
        labelInvisibleBelt.Name = "labelInvisibleBelt";
        labelInvisibleBelt.Size = new Size(61, 20);
        labelInvisibleBelt.TabIndex = 41;
        labelInvisibleBelt.Text = "             ";
        labelInvisibleBelt.MouseEnter += labelInvisibleBelt_MouseEnter;
        labelInvisibleBelt.MouseLeave += labelInvisibleBelt_MouseLeave;
        // 
        // pictureBoxHero
        // 
        pictureBoxHero.Image = Properties.Resources.hero;
        pictureBoxHero.Location = new Point(-13, 382);
        pictureBoxHero.Name = "pictureBoxHero";
        pictureBoxHero.Size = new Size(351, 357);
        pictureBoxHero.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxHero.TabIndex = 22;
        pictureBoxHero.TabStop = false;
        // 
        // pictureBoxInventory
        // 
        pictureBoxInventory.Image = Properties.Resources.inventory;
        pictureBoxInventory.Location = new Point(293, 500);
        pictureBoxInventory.Name = "pictureBoxInventory";
        pictureBoxInventory.Size = new Size(232, 229);
        pictureBoxInventory.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxInventory.TabIndex = 33;
        pictureBoxInventory.TabStop = false;
        pictureBoxInventory.Click += pictureBoxInventory_Click;
        // 
        // labelPlayerCritDmg
        // 
        labelPlayerCritDmg.AutoSize = true;
        labelPlayerCritDmg.BackColor = Color.Transparent;
        labelPlayerCritDmg.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
        labelPlayerCritDmg.ForeColor = Color.White;
        labelPlayerCritDmg.Location = new Point(138, 324);
        labelPlayerCritDmg.Name = "labelPlayerCritDmg";
        labelPlayerCritDmg.Size = new Size(80, 23);
        labelPlayerCritDmg.TabIndex = 61;
        labelPlayerCritDmg.Text = "CritDmg";
        // 
        // panelTown
        // 
        panelTown.BackColor = Color.Transparent;
        panelTown.BackgroundImage = Properties.Resources.castle;
        panelTown.BackgroundImageLayout = ImageLayout.Stretch;
        panelTown.Controls.Add(labelAct2Q1);
        panelTown.Controls.Add(pictureBoxAct5Hero);
        panelTown.Controls.Add(labelAct3Q1);
        panelTown.Controls.Add(buttonTalkMage);
        panelTown.Controls.Add(labelAct4Q1);
        panelTown.Controls.Add(labelAct1Quest1);
        panelTown.Controls.Add(buttonLearnTechnique);
        panelTown.Controls.Add(pictureBoxAct1ArtsTeacher);
        panelTown.Controls.Add(comboBoxUpgradeItems);
        panelTown.Controls.Add(buttonUpgradeItem);
        panelTown.Controls.Add(btn_Continuetown);
        panelTown.Controls.Add(txtBox_Town);
        panelTown.Controls.Add(buttonHeal);
        panelTown.Controls.Add(labelCompassS);
        panelTown.Controls.Add(labelCompassN);
        panelTown.Controls.Add(labelCompassE);
        panelTown.Controls.Add(labelCompassW);
        panelTown.Controls.Add(pictureBoxCompass);
        panelTown.Controls.Add(pictureBoxTown);
        panelTown.Controls.Add(pictureBoxHealer);
        panelTown.Controls.Add(pictureBoxAct2Smith);
        panelTown.Controls.Add(pictureBoxAct4Mage);
        panelTown.Dock = DockStyle.Fill;
        panelTown.Location = new Point(0, 0);
        panelTown.Name = "panelTown";
        panelTown.Size = new Size(537, 797);
        panelTown.TabIndex = 0;
        // 
        // labelAct2Q1
        // 
        labelAct2Q1.AutoSize = true;
        labelAct2Q1.Location = new Point(42, 328);
        labelAct2Q1.Name = "labelAct2Q1";
        labelAct2Q1.Size = new Size(93, 60);
        labelAct2Q1.TabIndex = 25;
        labelAct2Q1.Text = "                   \r\n                \r\n                     \r\n";
        labelAct2Q1.Click += labelAct2Q1_Click;
        // 
        // pictureBoxAct5Hero
        // 
        pictureBoxAct5Hero.Image = Properties.Resources.hero;
        pictureBoxAct5Hero.Location = new Point(-77, 353);
        pictureBoxAct5Hero.Name = "pictureBoxAct5Hero";
        pictureBoxAct5Hero.Size = new Size(351, 357);
        pictureBoxAct5Hero.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxAct5Hero.TabIndex = 24;
        pictureBoxAct5Hero.TabStop = false;
        // 
        // labelAct3Q1
        // 
        labelAct3Q1.AutoSize = true;
        labelAct3Q1.Location = new Point(451, 316);
        labelAct3Q1.Name = "labelAct3Q1";
        labelAct3Q1.Size = new Size(57, 80);
        labelAct3Q1.TabIndex = 23;
        labelAct3Q1.Text = "            \r\n\r\n\r\n      \r\n";
        labelAct3Q1.Click += labelAct3Q1_Click;
        // 
        // labelAct4Q1
        // 
        labelAct4Q1.AutoSize = true;
        labelAct4Q1.Location = new Point(213, 357);
        labelAct4Q1.Name = "labelAct4Q1";
        labelAct4Q1.Size = new Size(93, 120);
        labelAct4Q1.TabIndex = 20;
        labelAct4Q1.Text = "                   \r\n                \r\n                     \r\n\r\n\r\n\r\n";
        labelAct4Q1.Click += labelAct4Q1_Click;
        // 
        // labelAct1Quest1
        // 
        labelAct1Quest1.AutoSize = true;
        labelAct1Quest1.Location = new Point(231, 488);
        labelAct1Quest1.Name = "labelAct1Quest1";
        labelAct1Quest1.Size = new Size(69, 80);
        labelAct1Quest1.TabIndex = 19;
        labelAct1Quest1.Text = "               \r\n\r\n\r\n       \r\n";
        labelAct1Quest1.Click += labelAct1Quest1_Click;
        // 
        // pictureBoxAct1ArtsTeacher
        // 
        pictureBoxAct1ArtsTeacher.Location = new Point(338, 353);
        pictureBoxAct1ArtsTeacher.Name = "pictureBoxAct1ArtsTeacher";
        pictureBoxAct1ArtsTeacher.Size = new Size(195, 305);
        pictureBoxAct1ArtsTeacher.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxAct1ArtsTeacher.TabIndex = 17;
        pictureBoxAct1ArtsTeacher.TabStop = false;
        // 
        // comboBoxUpgradeItems
        // 
        comboBoxUpgradeItems.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxUpgradeItems.FormattingEnabled = true;
        comboBoxUpgradeItems.Location = new Point(284, 311);
        comboBoxUpgradeItems.Name = "comboBoxUpgradeItems";
        comboBoxUpgradeItems.Size = new Size(151, 28);
        comboBoxUpgradeItems.TabIndex = 16;
        // 
        // txtBox_Town
        // 
        txtBox_Town.BackColor = Color.FromArgb(195, 195, 195);
        txtBox_Town.BorderStyle = BorderStyle.None;
        txtBox_Town.Font = new Font("Microsoft Sans Serif", 12F);
        txtBox_Town.Location = new Point(11, 15);
        txtBox_Town.Multiline = true;
        txtBox_Town.Name = "txtBox_Town";
        txtBox_Town.ReadOnly = true;
        txtBox_Town.ScrollBars = ScrollBars.Vertical;
        txtBox_Town.Size = new Size(519, 90);
        txtBox_Town.TabIndex = 12;
        // 
        // pictureBoxCompass
        // 
        pictureBoxCompass.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBoxCompass.Image = Properties.Resources.compass;
        pictureBoxCompass.Location = new Point(-3, 141);
        pictureBoxCompass.Name = "pictureBoxCompass";
        pictureBoxCompass.Size = new Size(181, 186);
        pictureBoxCompass.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxCompass.TabIndex = 5;
        pictureBoxCompass.TabStop = false;
        // 
        // pictureBoxTown
        // 
        pictureBoxTown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        pictureBoxTown.Location = new Point(160, 382);
        pictureBoxTown.Name = "pictureBoxTown";
        pictureBoxTown.Size = new Size(377, 415);
        pictureBoxTown.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxTown.TabIndex = 0;
        pictureBoxTown.TabStop = false;
        // 
        // pictureBoxHealer
        // 
        pictureBoxHealer.Image = Properties.Resources.healer;
        pictureBoxHealer.Location = new Point(-21, 409);
        pictureBoxHealer.Name = "pictureBoxHealer";
        pictureBoxHealer.Size = new Size(197, 299);
        pictureBoxHealer.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxHealer.TabIndex = 10;
        pictureBoxHealer.TabStop = false;
        // 
        // pictureBoxAct2Smith
        // 
        pictureBoxAct2Smith.Location = new Point(220, 101);
        pictureBoxAct2Smith.Name = "pictureBoxAct2Smith";
        pictureBoxAct2Smith.Size = new Size(311, 301);
        pictureBoxAct2Smith.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxAct2Smith.TabIndex = 14;
        pictureBoxAct2Smith.TabStop = false;
        // 
        // pictureBoxAct4Mage
        // 
        pictureBoxAct4Mage.Location = new Point(298, 311);
        pictureBoxAct4Mage.Name = "pictureBoxAct4Mage";
        pictureBoxAct4Mage.Size = new Size(348, 449);
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
        panelStartScreen.Name = "panelStartScreen";
        panelStartScreen.Size = new Size(537, 797);
        panelStartScreen.TabIndex = 22;
        // 
        // labelVersionNumber
        // 
        labelVersionNumber.AutoSize = true;
        labelVersionNumber.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelVersionNumber.ForeColor = Color.White;
        labelVersionNumber.Location = new Point(12, 763);
        labelVersionNumber.Name = "labelVersionNumber";
        labelVersionNumber.Size = new Size(45, 20);
        labelVersionNumber.TabIndex = 6;
        labelVersionNumber.Text = "v0.76";
        // 
        // labelXboxRecommended
        // 
        labelXboxRecommended.AutoSize = true;
        labelXboxRecommended.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelXboxRecommended.ForeColor = Color.White;
        labelXboxRecommended.Location = new Point(219, 683);
        labelXboxRecommended.Name = "labelXboxRecommended";
        labelXboxRecommended.Size = new Size(114, 20);
        labelXboxRecommended.TabIndex = 5;
        labelXboxRecommended.Text = "Recommended";
        // 
        // pictureBoxXboxLogo
        // 
        pictureBoxXboxLogo.Image = Properties.Resources.xbox;
        pictureBoxXboxLogo.Location = new Point(230, 629);
        pictureBoxXboxLogo.Name = "pictureBoxXboxLogo";
        pictureBoxXboxLogo.Size = new Size(89, 66);
        pictureBoxXboxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBoxXboxLogo.TabIndex = 4;
        pictureBoxXboxLogo.TabStop = false;
        // 
        // buttonStartModifiers
        // 
        buttonStartModifiers.BackColor = Color.DarkRed;
        buttonStartModifiers.FlatAppearance.BorderSize = 0;
        buttonStartModifiers.FlatStyle = FlatStyle.Flat;
        buttonStartModifiers.Font = new Font("Impact", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        buttonStartModifiers.ForeColor = Color.White;
        buttonStartModifiers.Location = new Point(179, 513);
        buttonStartModifiers.Name = "buttonStartModifiers";
        buttonStartModifiers.Size = new Size(195, 55);
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
        labelGameAuthorName.Location = new Point(378, 760);
        labelGameAuthorName.Name = "labelGameAuthorName";
        labelGameAuthorName.Size = new Size(151, 20);
        labelGameAuthorName.TabIndex = 2;
        labelGameAuthorName.Text = "Jakob Kvejborg 2024";
        // 
        // buttonPlayGame
        // 
        buttonPlayGame.BackColor = Color.DarkRed;
        buttonPlayGame.FlatAppearance.BorderSize = 0;
        buttonPlayGame.FlatStyle = FlatStyle.Flat;
        buttonPlayGame.Font = new Font("Impact", 20F, FontStyle.Bold);
        buttonPlayGame.ForeColor = Color.White;
        buttonPlayGame.Location = new Point(179, 439);
        buttonPlayGame.Name = "buttonPlayGame";
        buttonPlayGame.Size = new Size(195, 55);
        buttonPlayGame.TabIndex = 1;
        buttonPlayGame.Text = "Play Game";
        buttonPlayGame.UseVisualStyleBackColor = false;
        buttonPlayGame.Click += buttonPlayGame_Click;
        // 
        // labelGameTitle
        // 
        labelGameTitle.AutoSize = true;
        labelGameTitle.Font = new Font("Imprint MT Shadow", 67.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelGameTitle.ForeColor = Color.Red;
        labelGameTitle.Location = new Point(35, 87);
        labelGameTitle.Name = "labelGameTitle";
        labelGameTitle.Size = new Size(477, 268);
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
        panelGameOver.Name = "panelGameOver";
        panelGameOver.Size = new Size(537, 797);
        panelGameOver.TabIndex = 5;
        // 
        // labelGameOverText
        // 
        labelGameOverText.AutoSize = true;
        labelGameOverText.Font = new Font("Impact", 51F, FontStyle.Bold);
        labelGameOverText.ForeColor = Color.FromArgb(178, 34, 34);
        labelGameOverText.Location = new Point(25, 179);
        labelGameOverText.Name = "labelGameOverText";
        labelGameOverText.Size = new Size(501, 309);
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
        panelAct1Quest1.Name = "panelAct1Quest1";
        panelAct1Quest1.Size = new Size(537, 797);
        panelAct1Quest1.TabIndex = 45;
        // 
        // textBoxAct1Quest1
        // 
        textBoxAct1Quest1.BackColor = Color.FromArgb(195, 195, 195);
        textBoxAct1Quest1.Font = new Font("Microsoft Sans Serif", 12F);
        textBoxAct1Quest1.Location = new Point(11, 15);
        textBoxAct1Quest1.Multiline = true;
        textBoxAct1Quest1.Name = "textBoxAct1Quest1";
        textBoxAct1Quest1.ReadOnly = true;
        textBoxAct1Quest1.ScrollBars = ScrollBars.Vertical;
        textBoxAct1Quest1.Size = new Size(519, 90);
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
        panelAct4Quest1.Name = "panelAct4Quest1";
        panelAct4Quest1.Size = new Size(537, 797);
        panelAct4Quest1.TabIndex = 46;
        // 
        // textBoxAct4Quest1
        // 
        textBoxAct4Quest1.BackColor = Color.FromArgb(195, 195, 195);
        textBoxAct4Quest1.Font = new Font("Microsoft Sans Serif", 12F);
        textBoxAct4Quest1.Location = new Point(11, 15);
        textBoxAct4Quest1.Multiline = true;
        textBoxAct4Quest1.Name = "textBoxAct4Quest1";
        textBoxAct4Quest1.ReadOnly = true;
        textBoxAct4Quest1.ScrollBars = ScrollBars.Vertical;
        textBoxAct4Quest1.Size = new Size(519, 90);
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
        panelXboxControlsLayout.Name = "panelXboxControlsLayout";
        panelXboxControlsLayout.Size = new Size(537, 797);
        panelXboxControlsLayout.TabIndex = 6;
        // 
        // axWMPintroVid
        // 
        axWMPintroVid.Dock = DockStyle.Fill;
        axWMPintroVid.Enabled = true;
        axWMPintroVid.Location = new Point(0, 0);
        axWMPintroVid.Name = "axWMPintroVid";
        axWMPintroVid.OcxState = (AxHost.State)resources.GetObject("axWMPintroVid.OcxState");
        axWMPintroVid.Size = new Size(537, 797);
        axWMPintroVid.TabIndex = 6;
        // 
        // panelIntroVidWMP
        // 
        panelIntroVidWMP.Controls.Add(axWMPintroVid);
        panelIntroVidWMP.Dock = DockStyle.Fill;
        panelIntroVidWMP.Location = new Point(0, 0);
        panelIntroVidWMP.Name = "panelIntroVidWMP";
        panelIntroVidWMP.Size = new Size(537, 797);
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
        panelAct3Q1.Name = "panelAct3Q1";
        panelAct3Q1.Size = new Size(537, 797);
        panelAct3Q1.TabIndex = 48;
        // 
        // panelReforgeItemFrog
        // 
        panelReforgeItemFrog.Controls.Add(buttonReforgeStat);
        panelReforgeItemFrog.Controls.Add(listViewItemStatsFrog);
        panelReforgeItemFrog.Location = new Point(357, 276);
        panelReforgeItemFrog.Name = "panelReforgeItemFrog";
        panelReforgeItemFrog.Size = new Size(177, 230);
        panelReforgeItemFrog.TabIndex = 41;
        // 
        // listViewItemStatsFrog
        // 
        listViewItemStatsFrog.BackColor = SystemColors.ScrollBar;
        listViewItemStatsFrog.Columns.AddRange(new ColumnHeader[] { columnType, columnStat });
        listViewItemStatsFrog.FullRowSelect = true;
        listViewItemStatsFrog.Location = new Point(7, 5);
        listViewItemStatsFrog.Name = "listViewItemStatsFrog";
        listViewItemStatsFrog.Size = new Size(165, 165);
        listViewItemStatsFrog.TabIndex = 40;
        listViewItemStatsFrog.UseCompatibleStateImageBehavior = false;
        listViewItemStatsFrog.View = View.Details;
        // 
        // columnType
        // 
        columnType.Text = "Type";
        columnType.Width = 109;
        // 
        // columnStat
        // 
        columnStat.Text = "Stat";
        columnStat.Width = 50;
        // 
        // comboBoxAct3Q1Frog
        // 
        comboBoxAct3Q1Frog.FormattingEnabled = true;
        comboBoxAct3Q1Frog.Location = new Point(30, 334);
        comboBoxAct3Q1Frog.Name = "comboBoxAct3Q1Frog";
        comboBoxAct3Q1Frog.Size = new Size(151, 28);
        comboBoxAct3Q1Frog.TabIndex = 38;
        // 
        // textBoxAct3Q1
        // 
        textBoxAct3Q1.BackColor = Color.FromArgb(195, 195, 195);
        textBoxAct3Q1.Font = new Font("Microsoft Sans Serif", 12F);
        textBoxAct3Q1.Location = new Point(11, 15);
        textBoxAct3Q1.Multiline = true;
        textBoxAct3Q1.Name = "textBoxAct3Q1";
        textBoxAct3Q1.ReadOnly = true;
        textBoxAct3Q1.ScrollBars = ScrollBars.Vertical;
        textBoxAct3Q1.Size = new Size(519, 90);
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
        panelAct2Q1.Name = "panelAct2Q1";
        panelAct2Q1.Size = new Size(537, 797);
        panelAct2Q1.TabIndex = 64;
        // 
        // textBoxAct2Q1
        // 
        textBoxAct2Q1.BackColor = Color.FromArgb(195, 195, 195);
        textBoxAct2Q1.Font = new Font("Microsoft Sans Serif", 12F);
        textBoxAct2Q1.Location = new Point(11, 15);
        textBoxAct2Q1.Multiline = true;
        textBoxAct2Q1.Name = "textBoxAct2Q1";
        textBoxAct2Q1.ReadOnly = true;
        textBoxAct2Q1.ScrollBars = ScrollBars.Vertical;
        textBoxAct2Q1.Size = new Size(519, 90);
        textBoxAct2Q1.TabIndex = 2;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaptionText;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(537, 797);
        Controls.Add(panelTown);
        Controls.Add(panelAct3Q1);
        Controls.Add(panelStartScreen);
        Controls.Add(panelEncounter);
        Controls.Add(panelAct4Quest1);
        Controls.Add(panelAct2Q1);
        Controls.Add(panelAct1Quest1);
        Controls.Add(panelXboxControlsLayout);
        Controls.Add(panelGameOver);
        Controls.Add(panelIntroVidWMP);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
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
        panelPopupHelmet.ResumeLayout(false);
        panelPopupHelmet.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxIconHelmet).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)pictureBoxTown).EndInit();
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
    public PictureBox pictureBoxTown;
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
    public Button btn_attack;
    public Button buttonSwiftAttack;
    public Button buttonBloodLust;
    private Label labelInvisibleAmulet;
    private Label labelInvisibleBelt;
    private Label labelInvisibleHelmet;
    public Panel panelPopupAmulet;
    private Label labelInfoAmuletEquipped;
    private Label labelAmuletName;
    public Button buttonRoarAttack;
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
    public Button buttonDivine;
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
    public Button buttonGuard;
    private AxWMPLib.AxWindowsMediaPlayer axWMPintroVid;
    private Panel panelIntroVidWMP;
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
}
