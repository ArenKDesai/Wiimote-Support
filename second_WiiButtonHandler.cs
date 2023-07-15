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
    internal sealed class WiiButtonHandler_Second
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


        public WiiButtonHandler_Second(ModEntry modEntry, Wiimote wiimote)
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
            if(wiimote.WiimoteState.ButtonState.A)
            {
                if (!isAButtonPressed)
                {
                    isAButtonPressed = true;
                    AButtonPressed();
                }
            }
            else
            {
                if (isAButtonPressed)
                {
                    isAButtonPressed = false;
                    modEntry.Monitor.Log("A button released", LogLevel.Info);
                }
            }
        }

        private void AButtonPressed()
        {
            IInputToolsAPI inputTools = modEntry.Helper.ModRegistry.GetApi<IInputToolsAPI>("Pathoschild.Input");
            SButtonExtensions.ToSButton
        }

        private void AButtonReleased()
        {
            Game1.player.EndUsingTool();
        }

        private void BButtonPressed()
        {
            Game1.player.CurrentItem.actionWhenBeingHeld(Game1.player);
            Game1.player
        }
    }
}