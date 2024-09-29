using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace AdventureGame;

public partial class MainWindow : Form
{

    private PlayerState playerState;
    private bool isAttackOnCooldown;
    //private ItemContainer itemContainer;


    public MainWindow()
    {
        InitializeComponent();
        //this.BackColor = Color.FromArgb(80, 80, 90); // sets the color of the window to black
        this.DoubleBuffered = true; // helps flickering
        playerState = new PlayerState();
        panelMonster.Visible = false;
        panelEncounter.Visible = false;
        StoryProgress storyProgress = new StoryProgress();
        InitializePlayerLabels();

        buttonPlayGame.MouseEnter += buttonPlayGame_MouseEnter;
        buttonPlayGame.MouseLeave += buttonPlayGame_MouseLeave;

        FadeTitle();

        this.KeyPreview = true;
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

    private void InitializePlayerLabels()
    {
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
        labelExperience.Text = $"Experience: {playerState.Player.Experience}/{10 * (playerState.Player.Level + playerState.Player.Level)}";
    }


    private void progressBar1_Click(object sender, EventArgs e)
    {

    }

    private async void btn_attack_Click(object sender, EventArgs e)
    {
        Encounter.PlayerAttacks(playerState);
        MonsterIsDead();

        await ShakeControl(MainWindow.pictureBoxMonster1);

        btn_attack.Enabled = false;
        await Task.Delay(500);
        btn_attack.Enabled = true;

    }

    private void MonsterIsDead()
    {
        Encounter.MonsterIsDefeated(playerState);
        if (Encounter.Monster == null) // This is wrong for sure
        {
            Encounter.PlayerFindsItemFromMonster(playerState);
        }

    }

    // This method lets the player attack using the space key
    protected override async void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (e.KeyCode == Keys.Space && !isAttackOnCooldown)
        {
            isAttackOnCooldown = true;
            btn_attack_Click(this, EventArgs.Empty);
            e.SuppressKeyPress = true;
            btn_attack.Enabled = false;
            await Task.Delay(200);
            btn_attack.Enabled = true;

            isAttackOnCooldown = false;
        }


        if (e.KeyCode == Keys.Enter)
        {
            button1_Click_1(this, EventArgs.Empty);
            e.SuppressKeyPress = true;
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

    private void buttonDiscardItem_Click(object sender, EventArgs e)
    {
        {
            if (comboBoxInventory.SelectedItem != null)
            {
                // Remove the selected item
                MainWindow.textBox1.Text = $"You throw away the item {comboBoxInventory.SelectedItem.ToString()}.";
                comboBoxInventory.Items.Remove(comboBoxInventory.SelectedItem);
                comboBoxInventory.SelectedItem = null;

            }
        }
    }

    private void buttonPlayGame_Click(object sender, EventArgs e)
    {
        panelStartScreen.Visible = false;
        panelEncounter.Visible = true;
        btn_next.Focus();
    }
}
