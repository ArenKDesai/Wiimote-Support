using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using WiimoteLib;
using InputTools;

namespace WiiMote_Support
{
    internal sealed class WiiButtonHandler
    {
        private readonly ModEntry modEntry;
        private readonly Wiimote wiimote;
        private bool isAButtonPressed;
        private bool isBButtonPressed;
        private bool isPlusButtonPressed;
        private bool isMinusButtonPressed;
        private bool isHomeButtonPressed;
        private bool isOneButtonPressed;
        private bool isTwoButtonPressed;
        private bool isUpButtonPressed;
        private bool isDownButtonPressed;
        private bool isLeftButtonPressed;
        private bool isRightButtonPressed;


        public WiiButtonHandler(ModEntry modEntry, Wiimote wiimote)
        {
            this.modEntry = modEntry;
            this.wiimote = wiimote;
            isAButtonPressed = false;
            isBButtonPressed = false;
            isPlusButtonPressed = false;
            isMinusButtonPressed = false;
            isHomeButtonPressed = false;
            isOneButtonPressed = false;
            isTwoButtonPressed = false;
            isUpButtonPressed = false;
            isDownButtonPressed = false;
            isLeftButtonPressed = false;
            isRightButtonPressed = false;

            modEntry.Helper.Events.GameLoop.UpdateTicking += OnUpdateTicking;
        }

        private void OnUpdateTicking(object sender, UpdateTickingEventArgs e)
        {
            if (e.IsMultipleOf(2)) // Process every other update tick to reduce input lag
            {
                Stardew
            }
        }

        private GamePadState ConvertToGamePadState(WiimoteState wiimoteState)
        {
            float leftTrigger = LeftTrigger(wiimoteState);
            float rightTrigger = RightTrigger(wiimoteState);
            Vector2 leftStick = LeftStick(wiimoteState);
            Buttons buttons = GetButtons(wiimoteState);

            return new GamePadState(leftStick, Vector2.Zero, leftTrigger, rightTrigger, buttons);
        }

        private float LeftTrigger(WiimoteState wiimoteState)
        {
            if (wiimoteState.ButtonState.Plus)
            {
                return 1.0f;
            }
            else
            {
                return 0.0f;
            }
        }

        private float RightTrigger(WiimoteState wiimoteState)
        {
            if (wiimoteState.ButtonState.Minus)
            {
                return 1.0f;
            }
            else
            {
                return 0.0f;
            }
            
        }

        private Vector2 LeftStick(WiimoteState wiimoteState)
        {
            float x = 0.0f;
            float y = 0.0f;

            if (wiimoteState.ButtonState.Right)
            {
                y = 1.0f;
            }
            else if (wiimoteState.ButtonState.Left)
            {
                y = -1.0f;
            }

            if (wiimoteState.ButtonState.Up)
            {
                x = -1.0f;
            }
            else if (wiimoteState.ButtonState.Down)
            {
                x = 1.0f;
            }

            return new Vector2(x, y);
        }

        private Buttons GetButtons(WiimoteState wiimoteState)
        {
            Buttons buttons = 0;

            if (wiimoteState.ButtonState.A)
            {
                buttons |= Buttons.A;
            }

            if (wiimoteState.ButtonState.B)
            {
                buttons |= Buttons.B;
            }

            if (wiimoteState.ButtonState.Plus)
            {
                buttons |= Buttons.X;
            }

            if (wiimoteState.ButtonState.Minus)
            {
                buttons |= Buttons.Y;
            }

            if (wiimoteState.ButtonState.Home)
            {
                buttons |= Buttons.Back;
            }

            if (wiimoteState.ButtonState.One)
            {
                buttons |= Buttons.RightShoulder;
            }

            if (wiimoteState.ButtonState.Two)
            {
                buttons |= Buttons.LeftShoulder;
            }

            if (wiimoteState.ButtonState.Up)
            {
                buttons |= Buttons.DPadUp;
            }

            if (wiimoteState.ButtonState.Down)
            {
                buttons |= Buttons.DPadDown;
            }

            if (wiimoteState.ButtonState.Left)
            {
                buttons |= Buttons.DPadLeft;
            }

            if (wiimoteState.ButtonState.Right)
            {
                buttons |= Buttons.DPadRight;
            }

            return buttons;
        }

    }
}