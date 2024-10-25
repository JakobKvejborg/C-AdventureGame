
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
        toolTip = new ToolTip(components);
        btn_continue = new Button();
        btn_attack = new Button();
        labelCompassE = new Label();
        labelCompassW = new Label();
        labelCompassN = new Label();
        labelCompassS = new Label();
        buttonHeal = new Button();
        btn_Continuetown = new Button();
        buttonEquipUnequip = new Button();
        labelInvisibleWeaponRightHandEquipped = new Label();
        textBox1 = new TextBox();
        comboBoxInventory = new ComboBox();
        labelInventory = new Label();
        buttonDiscardItem = new Button();
        btn_useMagic = new Button();
        btn_block = new Button();
        progressBarPlayerHP = new ProgressBar();
        labelPlayerHP = new Label();
        labelPlayerArmor = new Label();
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
        panelEncounter = new Panel();
        panelPopupBoots = new Panel();
        labelInfoBootsEquipped = new Label();
        labelBootsName = new Label();
        labelInvisibleBoots = new Label();
        panelPopupArmor = new Panel();
        labelInfoArmorEquipped = new Label();
        labelArmorName = new Label();
        labelInvisibleArmor = new Label();
        panelPopupWeaponRightHand = new Panel();
        labelInfoWeaponRightHandEquipped = new Label();
        labelWeaponRightHandName = new Label();
        pictureBoxHero = new PictureBox();
        panelInventory = new Panel();
        panelTown = new Panel();
        comboBoxUpgradeItems = new ComboBox();
        buttonUpgradeItem = new Button();
        txtBox_Town = new TextBox();
        pictureBoxCompass = new PictureBox();
        pictureBoxTown = new PictureBox();
        pictureBoxHealer = new PictureBox();
        pictureBoxAct2Smith = new PictureBox();
        panelStartScreen = new Panel();
        buttonPlayGame = new Button();
        labelGameTitle = new Label();
        panelGameOver = new Panel();
        labelGameOverText = new Label();
        panelMonster.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).BeginInit();
        panelEncounter.SuspendLayout();
        panelPopupBoots.SuspendLayout();
        panelPopupArmor.SuspendLayout();
        panelPopupWeaponRightHand.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxHero).BeginInit();
        panelInventory.SuspendLayout();
        panelTown.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxCompass).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxTown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxHealer).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct2Smith).BeginInit();
        panelStartScreen.SuspendLayout();
        panelGameOver.SuspendLayout();
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
        btn_attack.Location = new Point(136, 306);
        btn_attack.Name = "btn_attack";
        btn_attack.Size = new Size(94, 29);
        btn_attack.TabIndex = 5;
        btn_attack.Text = "Attack";
        toolTip.SetToolTip(btn_attack, "\"Space\"");
        btn_attack.UseVisualStyleBackColor = true;
        btn_attack.Click += btn_attack_Click;
        // 
        // labelCompassE
        // 
        labelCompassE.AutoSize = true;
        labelCompassE.ForeColor = Color.Transparent;
        labelCompassE.Location = new Point(121, 212);
        labelCompassE.Name = "labelCompassE";
        labelCompassE.Size = new Size(89, 60);
        labelCompassE.TabIndex = 7;
        labelCompassE.Text = "            \r\n            \r\n                    \r\n";
        toolTip.SetToolTip(labelCompassE, "\"D\"");
        labelCompassE.Click += labelCompassE_Click;
        // 
        // labelCompassW
        // 
        labelCompassW.AutoSize = true;
        labelCompassW.ForeColor = Color.Transparent;
        labelCompassW.Location = new Point(6, 215);
        labelCompassW.Name = "labelCompassW";
        labelCompassW.Size = new Size(89, 60);
        labelCompassW.TabIndex = 6;
        labelCompassW.Text = "            \r\n            \r\n                    \r\n";
        toolTip.SetToolTip(labelCompassW, "\"A\"");
        labelCompassW.Click += labelCompassW_Click;
        // 
        // labelCompassN
        // 
        labelCompassN.AutoSize = true;
        labelCompassN.ForeColor = Color.Transparent;
        labelCompassN.Location = new Point(68, 133);
        labelCompassN.Name = "labelCompassN";
        labelCompassN.Size = new Size(89, 80);
        labelCompassN.TabIndex = 8;
        labelCompassN.Text = "            \r\n            \r\n                    \r\n\r\n";
        toolTip.SetToolTip(labelCompassN, "\"W\"");
        labelCompassN.Click += labelCompassN_Click;
        // 
        // labelCompassS
        // 
        labelCompassS.AutoSize = true;
        labelCompassS.ForeColor = Color.Transparent;
        labelCompassS.Location = new Point(68, 281);
        labelCompassS.Name = "labelCompassS";
        labelCompassS.Size = new Size(89, 60);
        labelCompassS.TabIndex = 9;
        labelCompassS.Text = "            \r\n            \r\n                    \r\n";
        toolTip.SetToolTip(labelCompassS, "\"S\"");
        labelCompassS.Click += labelCompassS_Click;
        // 
        // buttonHeal
        // 
        buttonHeal.Location = new Point(35, 597);
        buttonHeal.Name = "buttonHeal";
        buttonHeal.Size = new Size(124, 31);
        buttonHeal.TabIndex = 11;
        buttonHeal.Text = "Get Healed 2G";
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
        // textBox1
        // 
        textBox1.BackColor = Color.FromArgb(195, 195, 195);
        textBox1.Font = new Font("Microsoft Sans Serif", 12F);
        textBox1.Location = new Point(11, 15);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(519, 90);
        textBox1.TabIndex = 1;
        textBox1.Text = "Press ENTER to progress the story.";
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // comboBoxInventory
        // 
        comboBoxInventory.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxInventory.FormattingEnabled = true;
        comboBoxInventory.Location = new Point(4, 23);
        comboBoxInventory.Name = "comboBoxInventory";
        comboBoxInventory.Size = new Size(151, 28);
        comboBoxInventory.TabIndex = 2;
        // 
        // labelInventory
        // 
        labelInventory.BackColor = Color.Transparent;
        labelInventory.ForeColor = Color.White;
        labelInventory.Location = new Point(13, 0);
        labelInventory.Name = "labelInventory";
        labelInventory.Size = new Size(70, 20);
        labelInventory.TabIndex = 3;
        labelInventory.Text = "Inventory";
        // 
        // buttonDiscardItem
        // 
        buttonDiscardItem.Location = new Point(4, 93);
        buttonDiscardItem.Name = "buttonDiscardItem";
        buttonDiscardItem.Size = new Size(151, 29);
        buttonDiscardItem.TabIndex = 4;
        buttonDiscardItem.Text = "Discard item";
        buttonDiscardItem.UseVisualStyleBackColor = true;
        buttonDiscardItem.Click += buttonDiscardItem_Click;
        // 
        // btn_useMagic
        // 
        btn_useMagic.Location = new Point(136, 341);
        btn_useMagic.Name = "btn_useMagic";
        btn_useMagic.Size = new Size(94, 29);
        btn_useMagic.TabIndex = 6;
        btn_useMagic.Text = "Magic";
        btn_useMagic.UseVisualStyleBackColor = true;
        // 
        // btn_block
        // 
        btn_block.Location = new Point(136, 376);
        btn_block.Name = "btn_block";
        btn_block.Size = new Size(94, 29);
        btn_block.TabIndex = 7;
        btn_block.Text = "Block";
        btn_block.UseVisualStyleBackColor = true;
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
        labelPlayerHP.Location = new Point(14, 175);
        labelPlayerHP.Name = "labelPlayerHP";
        labelPlayerHP.Size = new Size(31, 23);
        labelPlayerHP.TabIndex = 9;
        labelPlayerHP.Text = "HP";
        labelPlayerHP.Click += label2_Click;
        // 
        // labelPlayerArmor
        // 
        labelPlayerArmor.AutoSize = true;
        labelPlayerArmor.BackColor = Color.Transparent;
        labelPlayerArmor.Font = new Font("Impact", 10F);
        labelPlayerArmor.ForeColor = Color.White;
        labelPlayerArmor.Location = new Point(14, 340);
        labelPlayerArmor.Name = "labelPlayerArmor";
        labelPlayerArmor.Size = new Size(53, 21);
        labelPlayerArmor.TabIndex = 11;
        labelPlayerArmor.Text = "armor";
        // 
        // labelPlayerDamage
        // 
        labelPlayerDamage.AutoSize = true;
        labelPlayerDamage.BackColor = Color.Transparent;
        labelPlayerDamage.Font = new Font("Impact", 10F);
        labelPlayerDamage.ForeColor = Color.White;
        labelPlayerDamage.Location = new Point(14, 242);
        labelPlayerDamage.Name = "labelPlayerDamage";
        labelPlayerDamage.Size = new Size(68, 21);
        labelPlayerDamage.TabIndex = 12;
        labelPlayerDamage.Text = "damage";
        // 
        // labelPlayerDodge
        // 
        labelPlayerDodge.AutoSize = true;
        labelPlayerDodge.BackColor = Color.Transparent;
        labelPlayerDodge.Font = new Font("Impact", 10F);
        labelPlayerDodge.ForeColor = Color.White;
        labelPlayerDodge.Location = new Point(14, 370);
        labelPlayerDodge.Name = "labelPlayerDodge";
        labelPlayerDodge.Size = new Size(55, 21);
        labelPlayerDodge.TabIndex = 13;
        labelPlayerDodge.Text = "dodge";
        // 
        // labelHeroName
        // 
        labelHeroName.BackColor = Color.Transparent;
        labelHeroName.Font = new Font("Docktrin", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelHeroName.ForeColor = Color.SteelBlue;
        labelHeroName.Location = new Point(13, 151);
        labelHeroName.Name = "labelHeroName";
        labelHeroName.Size = new Size(68, 23);
        labelHeroName.TabIndex = 14;
        labelHeroName.Text = "Hero";
        // 
        // labelPlayerStrength
        // 
        labelPlayerStrength.AutoSize = true;
        labelPlayerStrength.BackColor = Color.Transparent;
        labelPlayerStrength.Font = new Font("Impact", 10F);
        labelPlayerStrength.ForeColor = Color.White;
        labelPlayerStrength.Location = new Point(14, 274);
        labelPlayerStrength.Name = "labelPlayerStrength";
        labelPlayerStrength.Size = new Size(70, 21);
        labelPlayerStrength.TabIndex = 15;
        labelPlayerStrength.Text = "strength";
        // 
        // labelPlayerLifeSteal
        // 
        labelPlayerLifeSteal.AutoSize = true;
        labelPlayerLifeSteal.BackColor = Color.Transparent;
        labelPlayerLifeSteal.Font = new Font("Impact", 10F);
        labelPlayerLifeSteal.ForeColor = Color.White;
        labelPlayerLifeSteal.Location = new Point(14, 306);
        labelPlayerLifeSteal.Name = "labelPlayerLifeSteal";
        labelPlayerLifeSteal.Size = new Size(70, 21);
        labelPlayerLifeSteal.TabIndex = 16;
        labelPlayerLifeSteal.Text = "lifesteal";
        // 
        // labelGoldInPocket
        // 
        labelGoldInPocket.AutoSize = true;
        labelGoldInPocket.BackColor = Color.Transparent;
        labelGoldInPocket.Font = new Font("Impact", 10F);
        labelGoldInPocket.ForeColor = Color.Gold;
        labelGoldInPocket.Location = new Point(14, 399);
        labelGoldInPocket.Name = "labelGoldInPocket";
        labelGoldInPocket.Size = new Size(42, 21);
        labelGoldInPocket.TabIndex = 17;
        labelGoldInPocket.Text = "gold";
        // 
        // labelLevel
        // 
        labelLevel.AutoSize = true;
        labelLevel.BackColor = Color.Transparent;
        labelLevel.Font = new Font("Impact", 10F);
        labelLevel.ForeColor = Color.White;
        labelLevel.Location = new Point(132, 242);
        labelLevel.Name = "labelLevel";
        labelLevel.Size = new Size(46, 21);
        labelLevel.TabIndex = 18;
        labelLevel.Text = "Level";
        // 
        // labelExperience
        // 
        labelExperience.AutoSize = true;
        labelExperience.BackColor = Color.Transparent;
        labelExperience.Font = new Font("Impact", 10F);
        labelExperience.ForeColor = Color.White;
        labelExperience.Location = new Point(132, 274);
        labelExperience.Name = "labelExperience";
        labelExperience.Size = new Size(88, 21);
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
        panelMonster.Size = new Size(258, 344);
        panelMonster.TabIndex = 20;
        // 
        // pictureBoxMonster1
        // 
        pictureBoxMonster1.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBoxMonster1.Location = new Point(3, 78);
        pictureBoxMonster1.Name = "pictureBoxMonster1";
        pictureBoxMonster1.Size = new Size(252, 263);
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
        labelMonsterName.Font = new Font("Impact", 10F);
        labelMonsterName.ForeColor = Color.White;
        labelMonsterName.Location = new Point(24, 0);
        labelMonsterName.Name = "labelMonsterName";
        labelMonsterName.Size = new Size(109, 21);
        labelMonsterName.TabIndex = 0;
        labelMonsterName.Text = "monsterName";
        // 
        // panelEncounter
        // 
        panelEncounter.BackColor = Color.Transparent;
        panelEncounter.Controls.Add(panelPopupBoots);
        panelEncounter.Controls.Add(labelInvisibleBoots);
        panelEncounter.Controls.Add(panelPopupArmor);
        panelEncounter.Controls.Add(labelInvisibleArmor);
        panelEncounter.Controls.Add(panelPopupWeaponRightHand);
        panelEncounter.Controls.Add(panelMonster);
        panelEncounter.Controls.Add(textBox1);
        panelEncounter.Controls.Add(btn_continue);
        panelEncounter.Controls.Add(labelExperience);
        panelEncounter.Controls.Add(labelLevel);
        panelEncounter.Controls.Add(labelGoldInPocket);
        panelEncounter.Controls.Add(btn_attack);
        panelEncounter.Controls.Add(labelPlayerLifeSteal);
        panelEncounter.Controls.Add(btn_useMagic);
        panelEncounter.Controls.Add(labelPlayerStrength);
        panelEncounter.Controls.Add(btn_block);
        panelEncounter.Controls.Add(progressBarPlayerHP);
        panelEncounter.Controls.Add(labelPlayerDodge);
        panelEncounter.Controls.Add(labelPlayerHP);
        panelEncounter.Controls.Add(labelPlayerDamage);
        panelEncounter.Controls.Add(labelPlayerArmor);
        panelEncounter.Controls.Add(labelInvisibleWeaponRightHandEquipped);
        panelEncounter.Controls.Add(pictureBoxHero);
        panelEncounter.Controls.Add(labelHeroName);
        panelEncounter.Controls.Add(panelInventory);
        panelEncounter.Dock = DockStyle.Fill;
        panelEncounter.Location = new Point(0, 0);
        panelEncounter.Name = "panelEncounter";
        panelEncounter.Size = new Size(542, 768);
        panelEncounter.TabIndex = 22;
        // 
        // panelPopupBoots
        // 
        panelPopupBoots.AutoScroll = true;
        panelPopupBoots.BorderStyle = BorderStyle.Fixed3D;
        panelPopupBoots.Controls.Add(labelInfoBootsEquipped);
        panelPopupBoots.Controls.Add(labelBootsName);
        panelPopupBoots.Location = new Point(115, 607);
        panelPopupBoots.Name = "panelPopupBoots";
        panelPopupBoots.Size = new Size(160, 97);
        panelPopupBoots.TabIndex = 29;
        // 
        // labelInfoBootsEquipped
        // 
        labelInfoBootsEquipped.AutoSize = true;
        labelInfoBootsEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoBootsEquipped.ForeColor = Color.White;
        labelInfoBootsEquipped.Location = new Point(-1, 15);
        labelInfoBootsEquipped.Name = "labelInfoBootsEquipped";
        labelInfoBootsEquipped.Size = new Size(84, 16);
        labelInfoBootsEquipped.TabIndex = 1;
        labelInfoBootsEquipped.Text = "weaponInfo";
        // 
        // labelBootsName
        // 
        labelBootsName.AutoSize = true;
        labelBootsName.Font = new Font("Snap ITC", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelBootsName.ForeColor = SystemColors.ActiveCaption;
        labelBootsName.Location = new Point(1, -1);
        labelBootsName.Name = "labelBootsName";
        labelBootsName.Size = new Size(87, 17);
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
        // panelPopupArmor
        // 
        panelPopupArmor.AutoScroll = true;
        panelPopupArmor.BorderStyle = BorderStyle.Fixed3D;
        panelPopupArmor.Controls.Add(labelInfoArmorEquipped);
        panelPopupArmor.Controls.Add(labelArmorName);
        panelPopupArmor.Location = new Point(115, 402);
        panelPopupArmor.Name = "panelPopupArmor";
        panelPopupArmor.Size = new Size(145, 97);
        panelPopupArmor.TabIndex = 27;
        // 
        // labelInfoArmorEquipped
        // 
        labelInfoArmorEquipped.AutoSize = true;
        labelInfoArmorEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoArmorEquipped.ForeColor = Color.White;
        labelInfoArmorEquipped.Location = new Point(-1, 15);
        labelInfoArmorEquipped.Name = "labelInfoArmorEquipped";
        labelInfoArmorEquipped.Size = new Size(70, 16);
        labelInfoArmorEquipped.TabIndex = 1;
        labelInfoArmorEquipped.Text = "armorInfo";
        // 
        // labelArmorName
        // 
        labelArmorName.AutoSize = true;
        labelArmorName.Font = new Font("Snap ITC", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelArmorName.ForeColor = SystemColors.ActiveCaption;
        labelArmorName.Location = new Point(1, -1);
        labelArmorName.Name = "labelArmorName";
        labelArmorName.Size = new Size(93, 17);
        labelArmorName.TabIndex = 0;
        labelArmorName.Text = "ArmorName";
        // 
        // labelInvisibleArmor
        // 
        labelInvisibleArmor.AutoSize = true;
        labelInvisibleArmor.ForeColor = Color.Transparent;
        labelInvisibleArmor.Location = new Point(85, 447);
        labelInvisibleArmor.Name = "labelInvisibleArmor";
        labelInvisibleArmor.Size = new Size(41, 80);
        labelInvisibleArmor.TabIndex = 26;
        labelInvisibleArmor.Text = "     \r\n     \r\n      \r\n        ";
        labelInvisibleArmor.MouseEnter += labelInvisibleArmor_MouseEnter;
        labelInvisibleArmor.MouseLeave += labelInvisibleArmor_MouseLeave;
        // 
        // panelPopupWeaponRightHand
        // 
        panelPopupWeaponRightHand.AutoScroll = true;
        panelPopupWeaponRightHand.BorderStyle = BorderStyle.Fixed3D;
        panelPopupWeaponRightHand.Controls.Add(labelInfoWeaponRightHandEquipped);
        panelPopupWeaponRightHand.Controls.Add(labelWeaponRightHandName);
        panelPopupWeaponRightHand.Location = new Point(252, 497);
        panelPopupWeaponRightHand.Name = "panelPopupWeaponRightHand";
        panelPopupWeaponRightHand.Size = new Size(160, 97);
        panelPopupWeaponRightHand.TabIndex = 25;
        // 
        // labelInfoWeaponRightHandEquipped
        // 
        labelInfoWeaponRightHandEquipped.AutoSize = true;
        labelInfoWeaponRightHandEquipped.Font = new Font("Verdana", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelInfoWeaponRightHandEquipped.ForeColor = Color.White;
        labelInfoWeaponRightHandEquipped.Location = new Point(-1, 15);
        labelInfoWeaponRightHandEquipped.Name = "labelInfoWeaponRightHandEquipped";
        labelInfoWeaponRightHandEquipped.Size = new Size(84, 16);
        labelInfoWeaponRightHandEquipped.TabIndex = 1;
        labelInfoWeaponRightHandEquipped.Text = "weaponInfo";
        // 
        // labelWeaponRightHandName
        // 
        labelWeaponRightHandName.AutoSize = true;
        labelWeaponRightHandName.Font = new Font("Snap ITC", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelWeaponRightHandName.ForeColor = SystemColors.ActiveCaption;
        labelWeaponRightHandName.Location = new Point(1, -1);
        labelWeaponRightHandName.Name = "labelWeaponRightHandName";
        labelWeaponRightHandName.Size = new Size(100, 17);
        labelWeaponRightHandName.TabIndex = 0;
        labelWeaponRightHandName.Text = "weaponName";
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
        // panelInventory
        // 
        panelInventory.Controls.Add(labelInventory);
        panelInventory.Controls.Add(buttonDiscardItem);
        panelInventory.Controls.Add(comboBoxInventory);
        panelInventory.Controls.Add(buttonEquipUnequip);
        panelInventory.Location = new Point(340, 544);
        panelInventory.Name = "panelInventory";
        panelInventory.Size = new Size(164, 125);
        panelInventory.TabIndex = 23;
        // 
        // panelTown
        // 
        panelTown.BackColor = Color.Transparent;
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
        panelTown.Dock = DockStyle.Fill;
        panelTown.Location = new Point(0, 0);
        panelTown.Name = "panelTown";
        panelTown.Size = new Size(542, 768);
        panelTown.TabIndex = 0;
        // 
        // comboBoxUpgradeItems
        // 
        comboBoxUpgradeItems.FormattingEnabled = true;
        comboBoxUpgradeItems.Location = new Point(284, 311);
        comboBoxUpgradeItems.Name = "comboBoxUpgradeItems";
        comboBoxUpgradeItems.Size = new Size(151, 28);
        comboBoxUpgradeItems.TabIndex = 16;
        // 
        // buttonUpgradeItem
        // 
        buttonUpgradeItem.Location = new Point(441, 311);
        buttonUpgradeItem.Name = "buttonUpgradeItem";
        buttonUpgradeItem.Size = new Size(78, 28);
        buttonUpgradeItem.TabIndex = 15;
        buttonUpgradeItem.Text = "Upgrade";
        buttonUpgradeItem.UseVisualStyleBackColor = true;
        buttonUpgradeItem.Click += buttonUpgradeItem_Click;
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
        pictureBoxCompass.Location = new Point(6, 137);
        pictureBoxCompass.Name = "pictureBoxCompass";
        pictureBoxCompass.Size = new Size(204, 204);
        pictureBoxCompass.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxCompass.TabIndex = 5;
        pictureBoxCompass.TabStop = false;
        // 
        // pictureBoxTown
        // 
        pictureBoxTown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        pictureBoxTown.Location = new Point(165, 353);
        pictureBoxTown.Name = "pictureBoxTown";
        pictureBoxTown.Size = new Size(377, 415);
        pictureBoxTown.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBoxTown.TabIndex = 0;
        pictureBoxTown.TabStop = false;
        // 
        // pictureBoxHealer
        // 
        pictureBoxHealer.Image = Properties.Resources.healer;
        pictureBoxHealer.Location = new Point(-21, 438);
        pictureBoxHealer.Name = "pictureBoxHealer";
        pictureBoxHealer.Size = new Size(190, 195);
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
        // panelStartScreen
        // 
        panelStartScreen.BackColor = Color.Transparent;
        panelStartScreen.Controls.Add(buttonPlayGame);
        panelStartScreen.Controls.Add(labelGameTitle);
        panelStartScreen.Dock = DockStyle.Fill;
        panelStartScreen.Location = new Point(0, 0);
        panelStartScreen.Name = "panelStartScreen";
        panelStartScreen.Size = new Size(542, 768);
        panelStartScreen.TabIndex = 22;
        // 
        // buttonPlayGame
        // 
        buttonPlayGame.BackColor = Color.DarkRed;
        buttonPlayGame.FlatAppearance.BorderSize = 0;
        buttonPlayGame.FlatStyle = FlatStyle.Flat;
        buttonPlayGame.Font = new Font("Impact", 20F, FontStyle.Bold);
        buttonPlayGame.ForeColor = Color.White;
        buttonPlayGame.Location = new Point(180, 488);
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
        labelGameTitle.Font = new Font("Impact", 67F, FontStyle.Bold | FontStyle.Italic);
        labelGameTitle.ForeColor = Color.FromArgb(178, 34, 34);
        labelGameTitle.Location = new Point(61, 111);
        labelGameTitle.Name = "labelGameTitle";
        labelGameTitle.Size = new Size(435, 274);
        labelGameTitle.TabIndex = 0;
        labelGameTitle.Text = "Horrors \n\rAwoken";
        // 
        // panelGameOver
        // 
        panelGameOver.Controls.Add(labelGameOverText);
        panelGameOver.Dock = DockStyle.Fill;
        panelGameOver.ForeColor = Color.FromArgb(94, 94, 94);
        panelGameOver.Location = new Point(0, 0);
        panelGameOver.Name = "panelGameOver";
        panelGameOver.Size = new Size(542, 768);
        panelGameOver.TabIndex = 5;
        // 
        // labelGameOverText
        // 
        labelGameOverText.AutoSize = true;
        labelGameOverText.Font = new Font("Impact", 51F, FontStyle.Bold);
        labelGameOverText.ForeColor = Color.FromArgb(178, 34, 34);
        labelGameOverText.Location = new Point(25, 161);
        labelGameOverText.Name = "labelGameOverText";
        labelGameOverText.Size = new Size(501, 309);
        labelGameOverText.TabIndex = 0;
        labelGameOverText.Text = "You Are Dead\n\r\n\r  Game Over";
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaptionText;
        BackgroundImage = Properties.Resources.castle1;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(542, 768);
        Controls.Add(panelTown);
        Controls.Add(panelEncounter);
        Controls.Add(panelGameOver);
        Controls.Add(panelStartScreen);
        DoubleBuffered = true;
        Name = "MainWindow";
        Text = "Horrors Awoken";
        Load += MainWindow_Load;
        panelMonster.ResumeLayout(false);
        panelMonster.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).EndInit();
        panelEncounter.ResumeLayout(false);
        panelEncounter.PerformLayout();
        panelPopupBoots.ResumeLayout(false);
        panelPopupBoots.PerformLayout();
        panelPopupArmor.ResumeLayout(false);
        panelPopupArmor.PerformLayout();
        panelPopupWeaponRightHand.ResumeLayout(false);
        panelPopupWeaponRightHand.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxHero).EndInit();
        panelInventory.ResumeLayout(false);
        panelTown.ResumeLayout(false);
        panelTown.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxCompass).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxTown).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxHealer).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxAct2Smith).EndInit();
        panelStartScreen.ResumeLayout(false);
        panelStartScreen.PerformLayout();
        panelGameOver.ResumeLayout(false);
        panelGameOver.PerformLayout();
        ResumeLayout(false);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
    #endregion

    private Button btn_continue;
    private Label labelInventory;
    private Button buttonDiscardItem;
    private Button btn_attack;
    private Button btn_useMagic;
    private Button btn_block;


    public Panel panelGameOver;
    public Panel panelTown;
    public Panel panelStartScreen;
    public Panel panelEncounter;
    public ComboBox comboBoxInventory;
    public Button buttonEquipUnequip;
    public TextBox textBox1;
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
    private PictureBox pictureBoxCompass;
    private Label labelCompassW;
    private Label labelCompassE;
    private Label labelCompassN;
    private Label labelCompassS;
    private Button buttonHeal;
    public PictureBox pictureBoxTown;
    public TextBox txtBox_Town;
    private Button btn_Continuetown;
    private Panel panelInventory;
    private Label labelInvisibleWeaponRightHandEquipped;
    private Panel panelPopupWeaponRightHand;
    private Label labelWeaponRightHandName;
    private Label labelInfoWeaponRightHandEquipped;
    public PictureBox pictureBoxHealer;
    private Label labelInvisibleArmor;
    private Panel panelPopupArmor;
    private Label labelInfoArmorEquipped;
    private Label labelArmorName;
    private Label labelInvisibleBoots;
    private Panel panelPopupBoots;
    private Label labelInfoBootsEquipped;
    private Label labelBootsName;
    public PictureBox pictureBoxAct2Smith;
    public ComboBox comboBoxUpgradeItems;
    public Button buttonUpgradeItem;
}
