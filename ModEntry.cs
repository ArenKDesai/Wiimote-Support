using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputTools;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using WiimoteLib;

namespace WiiMote_Support
{
    internal sealed class ModEntry : Mod
    {
        private Wiimote wiimote = new Wiimote();
        private bool isAButtonPressed = false;

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            WiiButtonHandler wiiButtonHandler = new WiiButtonHandler(this, this.wiimote);
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            IInputToolsAPI inputTools = this.Helper.ModRegistry.GetApi<IInputToolsAPI>("Pathoschild.InputTools");

            try
            {
                this.wiimote.Connect();
                this.Monitor.Log("Connected to Wiimote!", LogLevel.Info);
                this.wiimote.SetRumble(true);
                Game1.delayedActions.Add(
                    new DelayedAction(1000, () => this.wiimote.SetRumble(false))
                );
            }
            catch (Exception ex)
            {
                this.Monitor.Log($"Failed to connect to Wiimote: {ex}", LogLevel.Error);
            }
        }
    }
}
