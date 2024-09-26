
using System.Runtime.InteropServices;
namespace AdventureGame;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
        btn_next = new Button();
        textBox1 = new TextBox();
        comboBox1 = new ComboBox();
        label1 = new Label();
        button2 = new Button();
        btn_attack = new Button();
        btn_useMagic = new Button();
        btn_block = new Button();
        progressBarPlayerHP = new ProgressBar();
        labelPlayerHP = new Label();
        labelPlayerArmor = new Label();
        labelPlayerDamage = new Label();
        labelPlayerDodge = new Label();
        labelHeroNAme = new Label();
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
        panelMonster.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).BeginInit();
        SuspendLayout();
        // 
        // btn_next
        // 
        btn_next.Location = new Point(12, 108);
        btn_next.Name = "btn_next";
        btn_next.Size = new Size(94, 29);
        btn_next.TabIndex = 0;
        btn_next.Text = "->";
        btn_next.UseVisualStyleBackColor = true;
        btn_next.Click += button1_Click_1;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(12, 12);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(597, 90);
        textBox1.TabIndex = 1;
        textBox1.Text = "                                              Welcome to this adventure game!\r\n                                           Press the -> button to start the game.\r\n\r\n- Made by Jakob Kvejborg 2024\r\n\r\n";
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(46, 466);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(151, 28);
        comboBox1.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(46, 443);
        label1.Name = "label1";
        label1.Size = new Size(70, 20);
        label1.TabIndex = 3;
        label1.Text = "Inventory";
        // 
        // button2
        // 
        button2.Location = new Point(46, 535);
        button2.Name = "button2";
        button2.Size = new Size(151, 29);
        button2.TabIndex = 4;
        button2.Text = "Discard item";
        button2.UseVisualStyleBackColor = true;
        // 
        // btn_attack
        // 
        btn_attack.Location = new Point(137, 309);
        btn_attack.Name = "btn_attack";
        btn_attack.Size = new Size(94, 29);
        btn_attack.TabIndex = 5;
        btn_attack.Text = "Attack";
        btn_attack.UseVisualStyleBackColor = true;
        btn_attack.Click += btn_attack_Click;
        // 
        // btn_useMagic
        // 
        btn_useMagic.Location = new Point(137, 344);
        btn_useMagic.Name = "btn_useMagic";
        btn_useMagic.Size = new Size(94, 29);
        btn_useMagic.TabIndex = 6;
        btn_useMagic.Text = "Magic";
        btn_useMagic.UseVisualStyleBackColor = true;
        // 
        // btn_block
        // 
        btn_block.Location = new Point(137, 379);
        btn_block.Name = "btn_block";
        btn_block.Size = new Size(94, 29);
        btn_block.TabIndex = 7;
        btn_block.Text = "Block";
        btn_block.UseVisualStyleBackColor = true;
        // 
        // progressBarPlayerHP
        // 
        progressBarPlayerHP.ForeColor = Color.Blue;
        progressBarPlayerHP.Location = new Point(23, 201);
        progressBarPlayerHP.Name = "progressBarPlayerHP";
        progressBarPlayerHP.Size = new Size(212, 29);
        progressBarPlayerHP.TabIndex = 8;
        progressBarPlayerHP.Click += progressBar1_Click;
        // 
        // labelPlayerHP
        // 
        labelPlayerHP.AutoSize = true;
        labelPlayerHP.Location = new Point(23, 178);
        labelPlayerHP.Name = "labelPlayerHP";
        labelPlayerHP.Size = new Size(28, 20);
        labelPlayerHP.TabIndex = 9;
        labelPlayerHP.Text = "HP";
        labelPlayerHP.Click += label2_Click;
        // 
        // labelPlayerArmor
        // 
        labelPlayerArmor.AutoSize = true;
        labelPlayerArmor.Location = new Point(23, 343);
        labelPlayerArmor.Name = "labelPlayerArmor";
        labelPlayerArmor.Size = new Size(49, 20);
        labelPlayerArmor.TabIndex = 11;
        labelPlayerArmor.Text = "armor";
        // 
        // labelPlayerDamage
        // 
        labelPlayerDamage.AutoSize = true;
        labelPlayerDamage.Location = new Point(23, 245);
        labelPlayerDamage.Name = "labelPlayerDamage";
        labelPlayerDamage.Size = new Size(64, 20);
        labelPlayerDamage.TabIndex = 12;
        labelPlayerDamage.Text = "damage";
        // 
        // labelPlayerDodge
        // 
        labelPlayerDodge.AutoSize = true;
        labelPlayerDodge.Location = new Point(23, 373);
        labelPlayerDodge.Name = "labelPlayerDodge";
        labelPlayerDodge.Size = new Size(53, 20);
        labelPlayerDodge.TabIndex = 13;
        labelPlayerDodge.Text = "dodge";
        // 
        // labelHeroNAme
        // 
        labelHeroNAme.AutoSize = true;
        labelHeroNAme.Location = new Point(23, 158);
        labelHeroNAme.Name = "labelHeroNAme";
        labelHeroNAme.Size = new Size(42, 20);
        labelHeroNAme.TabIndex = 14;
        labelHeroNAme.Text = "Hero";
        // 
        // labelPlayerStrength
        // 
        labelPlayerStrength.AutoSize = true;
        labelPlayerStrength.Location = new Point(23, 277);
        labelPlayerStrength.Name = "labelPlayerStrength";
        labelPlayerStrength.Size = new Size(63, 20);
        labelPlayerStrength.TabIndex = 15;
        labelPlayerStrength.Text = "strength";
        // 
        // labelPlayerLifeSteal
        // 
        labelPlayerLifeSteal.AutoSize = true;
        labelPlayerLifeSteal.Location = new Point(23, 309);
        labelPlayerLifeSteal.Name = "labelPlayerLifeSteal";
        labelPlayerLifeSteal.Size = new Size(61, 20);
        labelPlayerLifeSteal.TabIndex = 16;
        labelPlayerLifeSteal.Text = "lifesteal";
        // 
        // labelGoldInPocket
        // 
        labelGoldInPocket.AutoSize = true;
        labelGoldInPocket.Location = new Point(23, 402);
        labelGoldInPocket.Name = "labelGoldInPocket";
        labelGoldInPocket.Size = new Size(40, 20);
        labelGoldInPocket.TabIndex = 17;
        labelGoldInPocket.Text = "gold";
        // 
        // labelLevel
        // 
        labelLevel.AutoSize = true;
        labelLevel.Location = new Point(143, 245);
        labelLevel.Name = "labelLevel";
        labelLevel.Size = new Size(43, 20);
        labelLevel.TabIndex = 18;
        labelLevel.Text = "Level";
        // 
        // labelExperience
        // 
        labelExperience.AutoSize = true;
        labelExperience.Location = new Point(143, 277);
        labelExperience.Name = "labelExperience";
        labelExperience.Size = new Size(81, 20);
        labelExperience.TabIndex = 19;
        labelExperience.Text = "Experience";
        // 
        // panelMonster
        // 
        panelMonster.BackColor = Color.FromArgb(60, 60, 60);
        panelMonster.Controls.Add(pictureBoxMonster1);
        panelMonster.Controls.Add(progressBarMonsterHP);
        panelMonster.Controls.Add(labelMonsterHp);
        panelMonster.Controls.Add(labelMonsterName);
        panelMonster.Location = new Point(270, 158);
        panelMonster.Name = "panelMonster";
        panelMonster.Size = new Size(305, 291);
        panelMonster.TabIndex = 20;
        // 
        // pictureBoxMonster1
        // 
        pictureBoxMonster1.Location = new Point(24, 90);
        pictureBoxMonster1.Name = "pictureBoxMonster1";
        pictureBoxMonster1.Size = new Size(257, 174);
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
        labelMonsterHp.Location = new Point(24, 20);
        labelMonsterHp.Name = "labelMonsterHp";
        labelMonsterHp.Size = new Size(31, 20);
        labelMonsterHp.TabIndex = 1;
        labelMonsterHp.Text = "HP:";
        // 
        // labelMonsterName
        // 
        labelMonsterName.AutoSize = true;
        labelMonsterName.Location = new Point(24, 0);
        labelMonsterName.Name = "labelMonsterName";
        labelMonsterName.Size = new Size(103, 20);
        labelMonsterName.TabIndex = 0;
        labelMonsterName.Text = "monsterName";
        // 
        // buttonEquipUnequip
        // 
        buttonEquipUnequip.Location = new Point(46, 500);
        buttonEquipUnequip.Name = "buttonEquipUnequip";
        buttonEquipUnequip.Size = new Size(151, 29);
        buttonEquipUnequip.TabIndex = 21;
        buttonEquipUnequip.Text = "Equip/unequip";
        buttonEquipUnequip.UseVisualStyleBackColor = true;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(593, 592);
        Controls.Add(buttonEquipUnequip);
        Controls.Add(panelMonster);
        Controls.Add(labelExperience);
        Controls.Add(labelLevel);
        Controls.Add(labelGoldInPocket);
        Controls.Add(labelPlayerLifeSteal);
        Controls.Add(labelPlayerStrength);
        Controls.Add(labelHeroNAme);
        Controls.Add(labelPlayerDodge);
        Controls.Add(labelPlayerDamage);
        Controls.Add(labelPlayerArmor);
        Controls.Add(labelPlayerHP);
        Controls.Add(progressBarPlayerHP);
        Controls.Add(btn_block);
        Controls.Add(btn_useMagic);
        Controls.Add(btn_attack);
        Controls.Add(button2);
        Controls.Add(label1);
        Controls.Add(comboBox1);
        Controls.Add(textBox1);
        Controls.Add(btn_next);
        Name = "MainWindow";
        Text = "RPG made by Jakob Kvejborg";
        Load += MainWindow_Load;
        panelMonster.ResumeLayout(false);
        panelMonster.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMonster1).EndInit();
        ResumeLayout(false);
        PerformLayout();
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
    private ComboBox comboBox1;
    private Label label1;
    private Button button2;
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

            // Wait for a short period of time before the next shake
            await Task.Delay(20);  // Adjust delay for a faster or slower shake

            shakeTime += 20;
        }

        // Restore the control to its original location
        control.Location = originalLocation;
    }

    public static Button buttonEquipUnequip;
    public static TextBox textBox1;
    public static ProgressBar progressBarPlayerHP;
    private static Label labelPlayerArmor;
    private static Label labelPlayerDamage;
    private static Label labelPlayerDodge;
    private static Label labelHeroNAme;
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
    //public static Button buttonEquipUnequip;
    //public static TextBox textBox1;
    //public static ProgressBar progressBarPlayerHP;
    //private static Label labelPlayerArmor;
    //private static Label labelPlayerDamage;
    //private static Label labelPlayerDodge;
    //private static Label labelHeroNAme;
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


}
