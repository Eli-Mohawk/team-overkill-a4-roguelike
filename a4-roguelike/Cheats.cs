using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Cheats
    {
        public void Update(Screen screen, Player player)
        {
            ChangeLevel(screen, player);
            KillYourself(player);
        }

        void ChangeLevel(Screen screen, Player player)
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.L)) screen.currentScreen += 1;
            if (Input.IsKeyboardKeyPressed(KeyboardInput.K)) screen.currentScreen -= 1;
            if (screen.currentScreen == null) return;
        }

        void KillYourself(Player player)
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.P)) player.currentHP -= 1;
            if (Input.IsKeyboardKeyPressed(KeyboardInput.O)) player.currentHP = 0;
        }
    }
}
