using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Cheats
    {
        public void Update(Screen screen)
        {
            ChangeLevel(screen);
        }

        void ChangeLevel(Screen screen)
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.L)) screen.currentScreen += 1;
            if (Input.IsKeyboardKeyPressed(KeyboardInput.K)) screen.currentScreen -= 1;
            if (screen.currentScreen == null) return;
        }
    }
}
