using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace AdventureGame;

public partial class MainWindow : Form
{

    private PlayerState playerState;


    public MainWindow()
    {
        InitializeComponent();
        //this.BackColor = Color.FromArgb(80, 80, 90); // sets the color of the window to black
        this.DoubleBuffered = true; // helps flickering
        playerState = new PlayerState();
        panelMonster.Visible = false;
        StoryProgress storyProgress = new StoryProgress();


        //      Setting the progress bar and label player health
        int currentHealth = playerState.Player.CurrentHealth;
        int maxHealth = playerState.Player.MaxHealth;

        progressBarPlayerHP.Maximum = maxHealth;
        progressBarPlayerHP.Value = currentHealth;
        labelPlayerHP.Text = $"HP: {currentHealth}/{maxHealth}";

        // Setting the player stats labels
        labelPlayerDamage.Text = $"Damage: {playerState.Player.Damage}";
        labelPlayerStrength.Text = $"Strength: {playerState.Player.Strength}";
        labelPlayerLifeSteal.Text = $"Lifesteal: {playerState.Player.Lifesteal}";
        labelPlayerArmor.Text = $"Armor: {playerState.Player.Armor}";
        labelPlayerDodge.Text = $"Dodge: {playerState.Player.DodgeChance}%";
        labelGoldInPocket.Text = $"Gold: {playerState.Player.GoldInPocket}";
        labelLevel.Text = $"Level: {playerState.Player.Level}";
        labelExperience.Text = $"Experience: {playerState.Player.Experience}";

        this.KeyPreview = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Create the rectangle for the form
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

        // Create two colors for the gradient (lighter gray and darker gray)
        Color lightGray = Color.FromArgb(100, 100, 100);
        Color darkGray = Color.FromArgb(25, 25, 25);

        // Create a linear gradient brush for the background
        using (LinearGradientBrush brush = new LinearGradientBrush(rect, lightGray, darkGray, 45f)) // 45f for diagonal gradient
        {
            e.Graphics.FillRectangle(brush, rect);
        }
    }

    private void progressBar1_Click(object sender, EventArgs e)
    { 

    }

    private void btn_attack_Click(object sender, EventArgs e)
    {
        Encounter.PlayerAttacks(playerState, textBox1);
        //Encounter.MonsterAttacks(playerState, textBox1); // delete

    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (e.KeyCode == Keys.Space)
        {
            btn_attack_Click(this, EventArgs.Empty);
            e.SuppressKeyPress = true;
        }

      
        if (e.KeyCode == Keys.Enter)
        {
            button1_Click_1(this, EventArgs.Empty);
            e.SuppressKeyPress = true; //
        }
    }


    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void MainWindow_Load(object sender, EventArgs e)
    {

    }

    private void label2_Click_1(object sender, EventArgs e)
    {

    }
}
