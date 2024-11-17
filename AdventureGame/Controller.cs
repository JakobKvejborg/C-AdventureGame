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
    private const int ButtonCooldownMilliseconds = 120; // A timer to prevent accidental double-button-presses
    private bool isLeftTriggerPressed = false;
    private bool isRightTriggerPressed = false;
    private bool isLeftStickActive = false;
    PlayerState _playerState;
    private readonly Dictionary<ItemType, Panel> _itemTypeToPanel;

    internal Controller(PlayerState playerState, MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        _playerState = playerState;
        InitializeController();

        // Initialize cooldown timer
        buttonCooldownTimer = new System.Timers.Timer(ButtonCooldownMilliseconds);
        buttonCooldownTimer.Elapsed += OnCooldownElapsed;
        buttonCooldownTimer.AutoReset = false; // Make it a one-shot timer

        // Connect ItemType to the correct popupPanel
        _itemTypeToPanel = new Dictionary<ItemType, Panel>
    {
        { ItemType.Helmet, mainWindow.panelPopupHelmet },
        { ItemType.Leggings, mainWindow.panelPopupLeggings },
        { ItemType.Amulet, mainWindow.panelPopupAmulet },
        { ItemType.Gloves, mainWindow.panelPopupGloves },
        { ItemType.Armor, mainWindow.panelPopupArmor },
        { ItemType.Boots, mainWindow.panelPopupBoots },
        { ItemType.Belt, mainWindow.panelPopupBelt },
        { ItemType.WeaponRightHand, mainWindow.panelPopupWeaponRightHand },
        { ItemType.WeaponLeftHand, mainWindow.panelPopupWeaponLeftHand },
        { ItemType.Shoulders, mainWindow.panelPopupShoulders },
    };
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
            // Retrieve joystick state (axes and buttons)
            float* axesPtr = GLFW.GetJoystickAxesRaw(joystickIndex, out int axesCount);
            byte* buttonsPtr = (byte*)GLFW.GetJoystickButtonsRaw(joystickIndex, out int buttonCount);

            if (!isControllerConnected)
            {
                Debug.WriteLine("Controller not connected");
                return;
            }

            if (axesPtr != null && axesCount >= 6) // Ensure there are enough axes (at least 6)
            {
                float leftStickX = axesPtr[0];   // Left analog
                float leftStickY = axesPtr[1];   // Left analog
                float rightStickX = axesPtr[2];   // Right analog
                float rightStickY = axesPtr[3];   // Right analog
                float leftTrigger = axesPtr[4];  // Left trigger (L2) on axis 4
                float rightTrigger = axesPtr[5]; // Right trigger (R2) on axis 5

                // Handle left trigger and right trigger press release press and release
                HandleTriggerPress(leftTrigger, ref isLeftTriggerPressed, TriggerType.Left);
                HandleTriggerPress(rightTrigger, ref isRightTriggerPressed, TriggerType.Right);

                // Left stick release handle
                if (Math.Abs(leftStickX) > 0.5f || Math.Abs(leftStickY) > 0.5f)
                {
                    if (!isLeftStickActive) // If it's newly moved
                    {
                        isLeftStickActive = true; // Mark as active
                        // Handle movement here
                    }
                }
                else // Stick is in neutral position
                {
                    if (isLeftStickActive) // If it was previously moved
                    {
                        isLeftStickActive = false; // Mark as inactive
                        OnLeftStickReleased(); // Handle release
                    }
                }
                // Handles left stick movement
                LeftStickAction(leftStickX, leftStickY);

                // Handles right stick movement
                if (rightStickY > 0.5f) // Down Right Stick
                {
                    _mainWindow.KeysDown();
                    //PanelPopupItemsShow();
                    StartCooldown(); // Enforce cooldown on all buttons
                    return;
                }
                else if (rightStickY < -0.5f) // Up Right Stick
                {
                    _mainWindow.KeysUp();
                    //PanelPopupItemsShow();
                    StartCooldown(); // Enforce cooldown on all buttons
                    return;
                }
            }

            // Handle button presses (you may already have this logic in place)
            if (buttonsPtr != null)
            {
                ButtonPresses(buttonsPtr, buttonCount);
            }
        }
    }

    // When the left stick is "released" to resting position
    private void OnLeftStickReleased()
    {
        _mainWindow.HideAllEquipmentPanels();
    }

    public void LeftStickAction(float leftStickX, float leftStickY)
    {
        StickDirection direction = GetStickDirection(leftStickX, leftStickY);

        // Left stick only works if hero is visible
        if (_mainWindow.pictureBoxHero.Visible == true && _mainWindow.panelEncounter.Visible == true && !StoryProgress.playerIsInTown) // && _mainWindow.panelMonster.Visible == false
        {
            //_mainWindow.HideAllEquipmentPanels(); // This ensures only 1 panel is showed at a time, but is quite buggy

            // Use switch on the direction to determine actions
            switch (direction)
            {
                case StickDirection.Up:
                    ShowPanelIfEquipped(ItemType.Helmet);
                    break;

                case StickDirection.Down:
                    ShowPanelIfEquipped(ItemType.Leggings);
                    break;

                case StickDirection.Left:
                    ShowPanelIfEquipped(ItemType.Amulet);
                    break;

                case StickDirection.Right:
                    ShowPanelIfEquipped(ItemType.Gloves);
                    break;

                case StickDirection.DownLeft:
                    ShowPanelIfEquipped(ItemType.Belt);
                    break;

                case StickDirection.UpRight:
                    ShowPanelIfEquipped(ItemType.Shoulders);
                    break;
                case StickDirection.UpLeft:
                    ShowPanelIfEquipped(ItemType.Armor);
                    break;
                case StickDirection.DownRight:
                    ShowPanelIfEquipped(ItemType.Boots);
                    ShowPanelIfEquipped(ItemType.WeaponRightHand);
                    break;

                case StickDirection.Neutral: // note this method is always spamming
                    break;
            }
        }
    }

    private unsafe void PanelPopupItemsShow()
    {
        if (isRightTriggerPressed)
        {
            _mainWindow.ShowPopupPanelsBasedOnItemType();
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
                    else if (_mainWindow.IsInventoryOpen) // Discard item
                    {
                        _mainWindow.ButtonDiscardItem();
                    }
                    break;

                case 2: // "X" button
                    if (_mainWindow.IsInventoryOpen)
                    {
                        _mainWindow.ButtonEquipItems();
                        //PanelPopupItemsShow();
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
                    else
                    {
                        _mainWindow.StartAct1Quest1(); // only starts if player is in act1
                    }
                    break;
                case 4: // L1
                    _mainWindow.ButtonBloodLustAttack();
                    break;
                case 5: // "R1" button
                    Task task = _mainWindow.ButtonAttack();
                    break;
                case 6: // Select
                    break;
                case 7: // Start button
                    if (!_mainWindow.PlayGameHasBeenPressed)
                    {
                        _mainWindow.ButtonPlayGame();
                    }
                    break;
                case 8: // Left Thumbstick
                    break;
                case 10: // D-pad up
                    _mainWindow.ButtonNorth();
                    break;
                case 11: // D-pad right
                    _mainWindow.ButtonEast();
                    break;
                case 12: // D-pad down
                    _mainWindow.ButtonSouth();
                    _mainWindow.ReturnToTownClick();
                    break;
                case 13: // D-pad left
                    _mainWindow.ButtonWest();
                    break;
                case 14: //
                    Debug.WriteLine("14");
                    break;
                case 15: //
                    Debug.WriteLine("15");
                    break;
                case 164: //
                    Debug.WriteLine("16");
                    break;

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

    // Method to handle right and left triggers
    private void HandleTriggerPress(float triggerValue, ref bool triggerState, TriggerType triggerType)
    {
        // Check if trigger is pressed (threshold > 0.5f)
        if (triggerValue > 0.5f)
        {
            // If trigger is not already pressed, perform actions
            if (!triggerState)
            {
                triggerState = true; // Mark as pressed

                // Trigger actions based on which trigger is pressed
                if (triggerType == TriggerType.Left)
                {
                    OnLeftTriggerPressed();
                }
                else if (triggerType == TriggerType.Right)
                {
                    OnRightTriggerPressed();
                }
            }
        }
        else
        {
            // If trigger is released, perform release actions
            if (triggerState)
            {
                triggerState = false; // Mark as released

                // Trigger actions based on which trigger is released
                if (triggerType == TriggerType.Left)
                {
                    OnLeftTriggerReleased();
                }
                else if (triggerType == TriggerType.Right)
                {
                    OnRightTriggerReleased();
                }
            }
        }
    }

    // Define actions for the Left Trigger
    private void OnLeftTriggerPressed()
    {
        if (!_mainWindow.IsInventoryOpen)
        {
            _mainWindow.ButtonRoarAttack();
        }
        if (_mainWindow.IsInventoryOpen)
        {
            PanelPopupItemsShow(); // Makes left trigger "compare" items in inventory vs. equipped
        }
    }

    private void OnLeftTriggerReleased()
    {
        if (isRightTriggerPressed)
        {
            _mainWindow.HideAllEquipmentPanels();
        }
    }

    // Define actions for the Right Trigger
    private void OnRightTriggerPressed()
    {
        _mainWindow.InventoryPanelPopupInfoShow();
        //_mainWindow.ShowPopupPanelsBasedOnItemType(); // This shows the co-responding item the player has equipped

        if (!_mainWindow.IsInventoryOpen)
        {
            _mainWindow.ButtonDodgeJabAttack();
        }
    }

    private void OnRightTriggerReleased()
    {
        _mainWindow.panelPopupInventoryInfo.Hide();
        _mainWindow.HideAllEquipmentPanels();
    }
    public StickDirection GetStickDirection(float x, float y)
    {
        // Define thresholds for directional movement
        const float axisThreshold = 0.5f;

        // Check for diagonal directions (corners)
        if (x > axisThreshold && y < -axisThreshold) return StickDirection.UpRight;
        if (x < -axisThreshold && y < -axisThreshold) return StickDirection.UpLeft;
        if (x > axisThreshold && y > axisThreshold) return StickDirection.DownRight;
        if (x < -axisThreshold && y > axisThreshold) return StickDirection.DownLeft;

        // Check for primary cardinal directions
        if (y < -axisThreshold) return StickDirection.Up;
        if (y > axisThreshold) return StickDirection.Down;
        if (x < -axisThreshold) return StickDirection.Left;
        if (x > axisThreshold) return StickDirection.Right;


        // If the stick is near the center, return Neutral
        return StickDirection.Neutral;

    }

    private void ShowPanelIfEquipped(ItemType itemType)
    {
        if (_playerState.Player.EquippedItems.TryGetValue(itemType, out var equippedItem) &&
            equippedItem.Type == itemType &&
            _itemTypeToPanel.TryGetValue(itemType, out var panel))
        {
            panel.Show();
        }
    }

}

public enum TriggerType
{
    Left,
    Right
}
public enum StickDirection
{
    Neutral,
    Up,
    Down,
    Left,
    Right,
    UpRight,
    UpLeft,
    DownRight,
    DownLeft
}