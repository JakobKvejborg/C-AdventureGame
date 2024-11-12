using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers; // Import System.Timers for Timer usage

namespace AdventureGame;

public class Controller
{
    private readonly int joystickIndex = 0;
    private bool isControllerConnected;
    private MainWindow _mainWindow;

    // Specify System.Timers.Timer explicitly to resolve ambiguity
    private System.Timers.Timer buttonCooldownTimer;
    private bool isCooldownActive;

    private const int ButtonCooldownMilliseconds = 130;

    public Controller(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        InitializeController();

        // Initialize cooldown timer
        buttonCooldownTimer = new System.Timers.Timer(ButtonCooldownMilliseconds);
        buttonCooldownTimer.Elapsed += OnCooldownElapsed;
        buttonCooldownTimer.AutoReset = false; // Make it a one-shot timer
    }

    private void InitializeController()
    {
        if (!GLFW.Init())
        {
            Console.WriteLine("Failed to initialize GLFW.");
            return;
        }

        isControllerConnected = GLFW.JoystickPresent(joystickIndex);
        if (isControllerConnected)
        {
            string joystickName = GLFW.GetJoystickName(joystickIndex);
            Console.WriteLine($"Controller connected: {joystickName}");
        }
        else
        {
            Console.WriteLine("No controller connected.");
        }
    }

    public void UpdateControllerState()
    {
        if (!isControllerConnected || isCooldownActive)
            return;

        unsafe
        {
            byte* buttonsPtr = (byte*)GLFW.GetJoystickButtonsRaw(joystickIndex, out int buttonCount);
            if (buttonsPtr != null)
            {
                ButtonPresses(buttonsPtr, buttonCount);
            }
        }
    }

    public unsafe void ButtonPresses(byte* buttonsPtr, int buttonCount)
    {
        for (int buttonIndex = 0; buttonIndex < buttonCount; buttonIndex++)
        {
            if (IsButtonPressed(buttonsPtr, buttonCount, buttonIndex))
            {
                HandleButtonAction(buttonIndex);
                StartCooldown();
                break; // Enforce cooldown on all buttons
            }
        }
    }


    public unsafe void HandleButtonAction(int buttonIndex)
    {
        // Loop through each button and check if it's pressed
        {
            switch (buttonIndex)
            {
                case 0: // "A" button
                    _mainWindow.EnterKeyPressed();
                    break;

                case 1: // "B" button
                    if (StoryProgress.playerIsInTown)
                    {
                        _mainWindow.LearnTechniqueAsync();
                        _mainWindow.ButtonUpgradeItem();
                    }
                    else if (_mainWindow.IsInventoryOpen)
                    {
                        _mainWindow.ButtonDiscardItem();
                    }
                    else
                    {
                        _mainWindow.ReturnToTownClick();
                    }
                    break;

                case 2: // "X" button
                    if (_mainWindow.IsInventoryOpen)
                    {
                        _mainWindow.ButtonEquipItems();
                    }
                    else if (StoryProgress.playerIsInTown)
                    {
                        _mainWindow.ButtonHeal();
                    }
                    else
                    {
                        _mainWindow.LootIsClicked();
                    }
                    break;

                case 3: // "Y" button
                    if (_mainWindow.pictureBoxHero.Visible)
                    {
                        if (_mainWindow.IsInventoryOpen)
                            _mainWindow.HideInventory();
                        else
                            _mainWindow.ShowInventory();
                    }
                    break;

                case 5: // "R1" button
                    Task task = _mainWindow.ButtonAttack();
                    break;

                case 7: // Start button
                    _mainWindow.ButtonPlayGame();
                    break;

                case 10: // D-pad up
                    if (_mainWindow.IsInventoryOpen)
                    {
                        if (_mainWindow.comboBoxInventory.Items.Count > 0)
                        {
                            _mainWindow.comboBoxInventory.SelectedIndex =
                                (_mainWindow.comboBoxInventory.SelectedIndex - 1 + _mainWindow.comboBoxInventory.Items.Count) %
                                _mainWindow.comboBoxInventory.Items.Count;
                        }
                    }
                    else
                    {
                        _mainWindow.ButtonNorth();
                    }
                    break;

                case 11: // D-pad right
                    _mainWindow.ButtonEast();
                    break;

                case 12: // D-pad down
                    if (_mainWindow.IsInventoryOpen)
                    {
                        if (_mainWindow.comboBoxInventory.Items.Count > 0)
                        {
                            _mainWindow.comboBoxInventory.SelectedIndex =
                                (_mainWindow.comboBoxInventory.SelectedIndex + 1) % _mainWindow.comboBoxInventory.Items.Count;
                        }
                    }
                    if (StoryProgress.playerIsInTown)
                    {
                        if (_mainWindow.comboBoxUpgradeItems.Items.Count > 0)
                        {
                            _mainWindow.comboBoxUpgradeItems.SelectedIndex =
                                (_mainWindow.comboBoxUpgradeItems.SelectedIndex + 1) % _mainWindow.comboBoxUpgradeItems.Items.Count;
                        }
                        _mainWindow.ButtonSouth(); // TODO fix
                    }

                    break;

                case 13: // D-pad left
                    _mainWindow.ButtonWest();
                    break;

                // Add additional cases for other buttons if needed

                default:
                    Console.WriteLine($"Unhandled button index.");
                    break;
            }
        }
    }


    private void StartCooldown()
    {
        isCooldownActive = true;
        buttonCooldownTimer.Start();
    }

    private void OnCooldownElapsed(object sender, ElapsedEventArgs e)
    {
        isCooldownActive = false;
    }

    private unsafe bool IsButtonPressed(byte* buttonsPtr, int buttonCount, int buttonIndex)
    {
        return buttonIndex < buttonCount && buttonsPtr[buttonIndex] == (byte)InputAction.Press;
    }

}