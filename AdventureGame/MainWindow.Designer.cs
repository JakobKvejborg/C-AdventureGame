
using System.Runtime.InteropServices;
namespace AdventureGame;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private ToolTip toolTip;

    StoryProgress storyProgress = new StoryProgress();

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
        toolTip = new ToolTip();
        btn_next = new Button();
        textBox1 = new TextBox();
        comboBoxInventory = new ComboBox();
        labelInventory = new Label();
        buttonDiscardItem = new Button();
        btn_attack = new Button();
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
        panelStartScreen = new Panel();
        buttonPlayGame = new Button();
        labelGameTitle = new Label();
        panelMonster.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).BeginInit();
        panelEncounter.SuspendLayout();
        panelStartScreen.SuspendLayout();
        SuspendLayout();
        // 
        // btn_next
        // 
        btn_next.Location = new Point(3, 105);
        btn_next.Name = "btn_next";
        btn_next.Size = new Size(94, 29);
        btn_next.TabIndex = 0;
        btn_next.Text = "->";
        btn_next.UseVisualStyleBackColor = true;
        btn_next.Click += button1_Click_1;
        toolTip.SetToolTip(btn_next, "Enter");
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
        textBox1.TextChanged += textBox1_TextChanged;
        textBox1.Text = "'Press Enter to progress the story.'";
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
        // btn_attack
        // 
        btn_attack.Location = new Point(128, 306);
        btn_attack.Name = "btn_attack";
        btn_attack.Size = new Size(94, 29);
        btn_attack.TabIndex = 5;
        btn_attack.Text = "Attack";
        btn_attack.UseVisualStyleBackColor = true;
        btn_attack.Click += btn_attack_Click;
        toolTip.SetToolTip(btn_attack, "Space");
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
        pictureBoxMonster1.BackgroundImageLayout = ImageLayout.Stretch;
        pictureBoxMonster1.Location = new Point(3, 78);
        pictureBoxMonster1.Name = "pictureBoxMonster1";
        pictureBoxMonster1.Size = new Size(311, 210);
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
        panelEncounter.Controls.Add(textBox1);
        panelEncounter.Controls.Add(buttonEquipUnequip);
        panelEncounter.Controls.Add(btn_next);
        panelEncounter.Controls.Add(panelMonster);
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
        labelGameTitle.Location = new Point(61, 98);
        labelGameTitle.Name = "labelGameTitle";
        labelGameTitle.Size = new Size(435, 274);
        labelGameTitle.TabIndex = 0;
        labelGameTitle.Text = "Horrors \n\rAwoken";
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaptionText;
        BackgroundImage = Properties.Resources.castle1;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(549, 743);
        Controls.Add(panelStartScreen);
        Controls.Add(panelEncounter);
        DoubleBuffered = true;
        Name = "MainWindow";
        Text = "Horrors Awoken";
        Load += MainWindow_Load;
        panelMonster.ResumeLayout(false);
        panelMonster.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).EndInit();
        panelEncounter.ResumeLayout(false);
        panelEncounter.PerformLayout();
        panelStartScreen.ResumeLayout(false);
        panelStartScreen.PerformLayout();
        ResumeLayout(false);
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
            await Task.Delay(50);
        }

        // Optionally loop the effect
        FadeTitle();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        storyProgress.ProgressStory(textBox1, panelMonster);
    }




    #endregion

    private Button btn_next;
    private Label labelInventory;
    private Button buttonDiscardItem;
    private Button btn_attack;
    private Button btn_useMagic;
    private Button btn_block;

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

    public static Panel panelStartScreen;
    public static Panel panelEncounter;
    public static ComboBox comboBoxInventory;
    public static Button buttonEquipUnequip;
    public static TextBox textBox1;
    public static ProgressBar progressBarPlayerHP;
    public static Label labelPlayerArmor;
    public static Label labelPlayerDamage;
    public static Label labelPlayerDodge;
    public static Label labelHeroName;
    public static Label labelPlayerHP;
    public static Label labelPlayerStrength;
    public static Label labelPlayerLifeSteal;
    public static Label labelGoldInPocket;
    public static Label labelLevel;
    public static PictureBox pictureBoxMonster1;
    public static Label labelExperience;
    public static Panel panelMonster;
    public static ProgressBar progressBarMonsterHP;
    public static Label labelMonsterHp;
    public static Label labelMonsterName;
    public static Button buttonPlayGame;
    public static Label labelGameTitle;

    //public static Panel panelStartScreen;
    //public static Panel panelEncounter;
    //public static ComboBox comboBoxInventory;
    //public static Button buttonEquipUnequip;
    //public static TextBox textBox1;
    //public static ProgressBar progressBarPlayerHP;
    //public static Label labelPlayerArmor;
    //public static Label labelPlayerDamage;
    //public static Label labelPlayerDodge;
    //public static Label labelHeroName;
    //public static Label labelPlayerHP;
    //public static Label labelPlayerStrength;
    //public static Label labelPlayerLifeSteal;
    //public static Label labelGoldInPocket;
    //public static Label labelLevel;
    //public static PictureBox pictureBoxMonster1;
    //public static Label labelExperience;
    //public static Panel panelMonster;
    //public static ProgressBar progressBarMonsterHP;
    //public static Label labelMonsterHp;
    //public static Label labelMonsterName;
    //public static Button buttonPlayGame;
    //public static Label labelGameTitle;


}
