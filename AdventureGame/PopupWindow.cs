using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame;

public partial class PopupWindowModifier : Form
{

    ModifierProcessor _modifierProcessor;
    private MainWindow _mainWindow;
    private CustomControlStyles _styles;

    public string UserInput { get; set; }

    public PopupWindowModifier(ModifierProcessor modifier, MainWindow mainWindow, CustomControlStyles styles)
    {
        InitializeComponent();
        _modifierProcessor = modifier; // Stores a reference of the modifierProcessor
        _mainWindow = mainWindow;
        _styles = styles;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        _styles.CoolRedShadow(buttonEnterModifier);
    }

    private void buttonEnterModifier_Click(object sender, EventArgs e)
    {
        ModifierEnterButton();
    }

    public void ModifierEnterButton()
    {
        string userInput = textBoxModifierInput.Text.Trim(); // Trim removes the spaces
        string resultMsg = _modifierProcessor.ProcessCommand(userInput); // process command and get result back

        textBoxModifierInput.Text = resultMsg; 
        textBoxModifierInput.SelectAll();

        // Update UI after the modifiers have been applied
        _mainWindow.buttonHeal.Text = $"Heal {Player.priceToHeal.ToString()}G";
        _mainWindow.buttonLearnTechnique.Text = $"Learn {Player.PriceToLearnTechnique}G";
        _mainWindow.buttonReforgeStat.Text = $"{ReforgeItemStat.PriceToReforgeFrog}G";
        _mainWindow.buttonUpgradeItem.Text = $"{Item.CostToUpgrade}G";
        _mainWindow.UpdatePlayerLabels();

    }

    private void textBoxModifierInput_Click(object sender, EventArgs e)
    {
        textBoxModifierInput.Clear();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Check for specific key presses
        switch (keyData)
        {
            case Keys.Enter:
                ModifierEnterButton();
                return true;
            case Keys.Escape:
                this.Close();
                return true;
            default:
                return base.ProcessCmdKey(ref msg, keyData); // Let the base method handle other keys

        }
    }


}
