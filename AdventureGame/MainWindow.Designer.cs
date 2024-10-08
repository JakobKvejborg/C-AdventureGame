﻿
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
        btn_next = new Button();
        btn_attack = new Button();
        buttonWest = new Button();
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
        buttonEquipUnequip = new Button();
        panelEncounter = new Panel();
        panelTown = new Panel();
        buttonEast = new Button();
        buttonNorth = new Button();
        buttonSouth = new Button();
        pictureBoxTown = new PictureBox();
        panelStartScreen = new Panel();
        buttonPlayGame = new Button();
        labelGameTitle = new Label();
        panelGameOver = new Panel();
        labelGameOverText = new Label();
        panelMonster.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).BeginInit();
        panelEncounter.SuspendLayout();
        panelTown.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxTown).BeginInit();
        panelStartScreen.SuspendLayout();
        panelGameOver.SuspendLayout();
        SuspendLayout();
        // 
        // btn_next
        // 
        btn_next.Location = new Point(3, 105);
        btn_next.Name = "btn_next";
        btn_next.Size = new Size(94, 29);
        btn_next.TabIndex = 0;
        btn_next.Text = "->";
        toolTip.SetToolTip(btn_next, "\"Enter\"");
        btn_next.UseVisualStyleBackColor = true;
        btn_next.Click += button1_Click_1;
        // 
        // btn_attack
        // 
        btn_attack.Location = new Point(128, 306);
        btn_attack.Name = "btn_attack";
        btn_attack.Size = new Size(94, 29);
        btn_attack.TabIndex = 5;
        btn_attack.Text = "Attack";
        toolTip.SetToolTip(btn_attack, "\"Space\"");
        btn_attack.UseVisualStyleBackColor = true;
        btn_attack.Click += btn_attack_Click;
        // 
        // buttonWest
        // 
        buttonWest.Location = new Point(51, 55);
        buttonWest.Name = "buttonWest";
        buttonWest.Size = new Size(56, 38);
        buttonWest.TabIndex = 3;
        buttonWest.Text = "West";
        toolTip.SetToolTip(buttonWest, "\"A\"");
        buttonWest.UseVisualStyleBackColor = true;
        buttonWest.Click += buttonWest_Click;
        // 
        // textBox1
        // 
        textBox1.BackColor = Color.FromArgb(195, 195, 195);
        textBox1.BorderStyle = BorderStyle.None;
        textBox1.Font = new Font("Microsoft Sans Serif", 12F);
        textBox1.Location = new Point(3, 9);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(519, 90);
        textBox1.TabIndex = 1;
        textBox1.Text = "Press 'Enter' to progress the story.";
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // comboBoxInventory
        // 
        comboBoxInventory.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxInventory.FormattingEnabled = true;
        comboBoxInventory.Location = new Point(37, 463);
        comboBoxInventory.Name = "comboBoxInventory";
        comboBoxInventory.Size = new Size(151, 28);
        comboBoxInventory.TabIndex = 2;
        // 
        // labelInventory
        // 
        labelInventory.AutoSize = true;
        labelInventory.BackColor = Color.Transparent;
        labelInventory.ForeColor = Color.White;
        labelInventory.Location = new Point(37, 440);
        labelInventory.Name = "labelInventory";
        labelInventory.Size = new Size(70, 20);
        labelInventory.TabIndex = 3;
        labelInventory.Text = "Inventory";
        // 
        // buttonDiscardItem
        // 
        buttonDiscardItem.Location = new Point(37, 532);
        buttonDiscardItem.Name = "buttonDiscardItem";
        buttonDiscardItem.Size = new Size(151, 29);
        buttonDiscardItem.TabIndex = 4;
        buttonDiscardItem.Text = "Discard item";
        buttonDiscardItem.UseVisualStyleBackColor = true;
        buttonDiscardItem.Click += buttonDiscardItem_Click;
        // 
        // btn_useMagic
        // 
        btn_useMagic.Location = new Point(128, 341);
        btn_useMagic.Name = "btn_useMagic";
        btn_useMagic.Size = new Size(94, 29);
        btn_useMagic.TabIndex = 6;
        btn_useMagic.Text = "Magic";
        btn_useMagic.UseVisualStyleBackColor = true;
        // 
        // btn_block
        // 
        btn_block.Location = new Point(128, 376);
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
        labelPlayerArmor.ForeColor = Color.White;
        labelPlayerArmor.Location = new Point(14, 340);
        labelPlayerArmor.Name = "labelPlayerArmor";
        labelPlayerArmor.Size = new Size(49, 20);
        labelPlayerArmor.TabIndex = 11;
        labelPlayerArmor.Text = "armor";
        // 
        // labelPlayerDamage
        // 
        labelPlayerDamage.AutoSize = true;
        labelPlayerDamage.BackColor = Color.Transparent;
        labelPlayerDamage.ForeColor = Color.White;
        labelPlayerDamage.Location = new Point(14, 242);
        labelPlayerDamage.Name = "labelPlayerDamage";
        labelPlayerDamage.Size = new Size(64, 20);
        labelPlayerDamage.TabIndex = 12;
        labelPlayerDamage.Text = "damage";
        // 
        // labelPlayerDodge
        // 
        labelPlayerDodge.AutoSize = true;
        labelPlayerDodge.BackColor = Color.Transparent;
        labelPlayerDodge.ForeColor = Color.White;
        labelPlayerDodge.Location = new Point(14, 370);
        labelPlayerDodge.Name = "labelPlayerDodge";
        labelPlayerDodge.Size = new Size(53, 20);
        labelPlayerDodge.TabIndex = 13;
        labelPlayerDodge.Text = "dodge";
        // 
        // labelHeroName
        // 
        labelHeroName.AutoSize = true;
        labelHeroName.BackColor = Color.Transparent;
        labelHeroName.ForeColor = Color.DarkSeaGreen;
        labelHeroName.Location = new Point(14, 155);
        labelHeroName.Name = "labelHeroName";
        labelHeroName.Size = new Size(42, 20);
        labelHeroName.TabIndex = 14;
        labelHeroName.Text = "Hero";
        // 
        // labelPlayerStrength
        // 
        labelPlayerStrength.AutoSize = true;
        labelPlayerStrength.BackColor = Color.Transparent;
        labelPlayerStrength.ForeColor = Color.White;
        labelPlayerStrength.Location = new Point(14, 274);
        labelPlayerStrength.Name = "labelPlayerStrength";
        labelPlayerStrength.Size = new Size(63, 20);
        labelPlayerStrength.TabIndex = 15;
        labelPlayerStrength.Text = "strength";
        // 
        // labelPlayerLifeSteal
        // 
        labelPlayerLifeSteal.AutoSize = true;
        labelPlayerLifeSteal.BackColor = Color.Transparent;
        labelPlayerLifeSteal.ForeColor = Color.White;
        labelPlayerLifeSteal.Location = new Point(14, 306);
        labelPlayerLifeSteal.Name = "labelPlayerLifeSteal";
        labelPlayerLifeSteal.Size = new Size(61, 20);
        labelPlayerLifeSteal.TabIndex = 16;
        labelPlayerLifeSteal.Text = "lifesteal";
        // 
        // labelGoldInPocket
        // 
        labelGoldInPocket.AutoSize = true;
        labelGoldInPocket.BackColor = Color.Transparent;
        labelGoldInPocket.ForeColor = Color.Gold;
        labelGoldInPocket.Location = new Point(14, 399);
        labelGoldInPocket.Name = "labelGoldInPocket";
        labelGoldInPocket.Size = new Size(40, 20);
        labelGoldInPocket.TabIndex = 17;
        labelGoldInPocket.Text = "gold";
        // 
        // labelLevel
        // 
        labelLevel.AutoSize = true;
        labelLevel.BackColor = Color.Transparent;
        labelLevel.ForeColor = Color.White;
        labelLevel.Location = new Point(134, 242);
        labelLevel.Name = "labelLevel";
        labelLevel.Size = new Size(43, 20);
        labelLevel.TabIndex = 18;
        labelLevel.Text = "Level";
        // 
        // labelExperience
        // 
        labelExperience.AutoSize = true;
        labelExperience.BackColor = Color.Transparent;
        labelExperience.ForeColor = Color.White;
        labelExperience.Location = new Point(134, 274);
        labelExperience.Name = "labelExperience";
        labelExperience.Size = new Size(81, 20);
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
        panelMonster.Size = new Size(258, 264);
        panelMonster.TabIndex = 20;
        // 
        // pictureBoxMonster1
        // 
        pictureBoxMonster1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        pictureBoxMonster1.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBoxMonster1.Location = new Point(3, 78);
        pictureBoxMonster1.Name = "pictureBoxMonster1";
        pictureBoxMonster1.Size = new Size(252, 210);
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
        labelMonsterHp.ForeColor = Color.White;
        labelMonsterHp.Location = new Point(24, 20);
        labelMonsterHp.Name = "labelMonsterHp";
        labelMonsterHp.Size = new Size(31, 20);
        labelMonsterHp.TabIndex = 1;
        labelMonsterHp.Text = "HP:";
        // 
        // labelMonsterName
        // 
        labelMonsterName.AutoSize = true;
        labelMonsterName.BackColor = Color.Transparent;
        labelMonsterName.ForeColor = Color.White;
        labelMonsterName.Location = new Point(24, 0);
        labelMonsterName.Name = "labelMonsterName";
        labelMonsterName.Size = new Size(103, 20);
        labelMonsterName.TabIndex = 0;
        labelMonsterName.Text = "monsterName";
        // 
        // buttonEquipUnequip
        // 
        buttonEquipUnequip.Location = new Point(37, 497);
        buttonEquipUnequip.Name = "buttonEquipUnequip";
        buttonEquipUnequip.Size = new Size(151, 29);
        buttonEquipUnequip.TabIndex = 21;
        buttonEquipUnequip.Text = "Equip/unequip";
        buttonEquipUnequip.UseVisualStyleBackColor = true;
        // 
        // panelEncounter
        // 
        panelEncounter.BackColor = Color.Transparent;
        panelEncounter.Controls.Add(panelTown);
        panelEncounter.Controls.Add(panelMonster);
        panelEncounter.Controls.Add(textBox1);
        panelEncounter.Controls.Add(buttonEquipUnequip);
        panelEncounter.Controls.Add(btn_next);
        panelEncounter.Controls.Add(comboBoxInventory);
        panelEncounter.Controls.Add(labelExperience);
        panelEncounter.Controls.Add(labelInventory);
        panelEncounter.Controls.Add(labelLevel);
        panelEncounter.Controls.Add(buttonDiscardItem);
        panelEncounter.Controls.Add(labelGoldInPocket);
        panelEncounter.Controls.Add(btn_attack);
        panelEncounter.Controls.Add(labelPlayerLifeSteal);
        panelEncounter.Controls.Add(btn_useMagic);
        panelEncounter.Controls.Add(labelPlayerStrength);
        panelEncounter.Controls.Add(btn_block);
        panelEncounter.Controls.Add(labelHeroName);
        panelEncounter.Controls.Add(progressBarPlayerHP);
        panelEncounter.Controls.Add(labelPlayerDodge);
        panelEncounter.Controls.Add(labelPlayerHP);
        panelEncounter.Controls.Add(labelPlayerDamage);
        panelEncounter.Controls.Add(labelPlayerArmor);
        panelEncounter.Location = new Point(7, 6);
        panelEncounter.Name = "panelEncounter";
        panelEncounter.Size = new Size(550, 978);
        panelEncounter.TabIndex = 22;
        // 
        // panelTown
        // 
        panelTown.Controls.Add(buttonEast);
        panelTown.Controls.Add(buttonWest);
        panelTown.Controls.Add(buttonNorth);
        panelTown.Controls.Add(buttonSouth);
        panelTown.Controls.Add(pictureBoxTown);
        panelTown.Location = new Point(0, 140);
        panelTown.Name = "panelTown";
        panelTown.Size = new Size(700, 699);
        panelTown.TabIndex = 22;
        // 
        // buttonEast
        // 
        buttonEast.Location = new Point(175, 55);
        buttonEast.Name = "buttonEast";
        buttonEast.Size = new Size(56, 38);
        buttonEast.TabIndex = 4;
        buttonEast.Text = "East";
        buttonEast.UseVisualStyleBackColor = true;
        buttonEast.Click += buttonEast_Click;
        // 
        // buttonNorth
        // 
        buttonNorth.Location = new Point(113, 33);
        buttonNorth.Name = "buttonNorth";
        buttonNorth.Size = new Size(56, 38);
        buttonNorth.TabIndex = 2;
        buttonNorth.Text = "North";
        buttonNorth.UseVisualStyleBackColor = true;
        buttonNorth.Click += buttonNorth_Click;
        // 
        // buttonSouth
        // 
        buttonSouth.Location = new Point(113, 85);
        buttonSouth.Name = "buttonSouth";
        buttonSouth.Size = new Size(56, 38);
        buttonSouth.TabIndex = 1;
        buttonSouth.Text = "South";
        buttonSouth.UseVisualStyleBackColor = true;
        buttonSouth.Click += buttonSouth_Click;
        // 
        // pictureBoxTown
        // 
        pictureBoxTown.Location = new Point(89, 193);
        pictureBoxTown.Name = "pictureBoxTown";
        pictureBoxTown.Size = new Size(525, 362);
        pictureBoxTown.TabIndex = 0;
        pictureBoxTown.TabStop = false;
        // 
        // panelStartScreen
        // 
        panelStartScreen.BackColor = Color.Transparent;
        panelStartScreen.Controls.Add(buttonPlayGame);
        panelStartScreen.Controls.Add(labelGameTitle);
        panelStartScreen.Location = new Point(-3, -6);
        panelStartScreen.Name = "panelStartScreen";
        panelStartScreen.Size = new Size(557, 750);
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
        panelGameOver.ForeColor = Color.FromArgb(94, 94, 94);
        panelGameOver.Location = new Point(0, 0);
        panelGameOver.Name = "panelGameOver";
        panelGameOver.Size = new Size(549, 738);
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
        ClientSize = new Size(549, 743);
        Controls.Add(panelEncounter);
        Controls.Add(panelStartScreen);
        Controls.Add(panelGameOver);
        DoubleBuffered = true;
        Name = "MainWindow";
        Text = "Horrors Awoken";
        Load += MainWindow_Load;
        panelMonster.ResumeLayout(false);
        panelMonster.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).EndInit();
        panelEncounter.ResumeLayout(false);
        panelEncounter.PerformLayout();
        panelTown.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxTown).EndInit();
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

    private Button btn_next;
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
    public Button buttonSouth;
    public PictureBox pictureBoxTown;
    public Button buttonEast;
    public Button buttonWest;
    public Button buttonNorth;
    public Label labelGameOverText;

}
