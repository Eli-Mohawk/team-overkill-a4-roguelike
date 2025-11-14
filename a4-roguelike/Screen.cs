using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    /// 0 - title
    /// 1 - rules
    /// 2 - settings
    /// 3 - game
    /// 4 - win
    /// 5 - lose
    /// 

    public class Screen
    {
        KeyboardKey movementUp = KeyboardKey.W;
        KeyboardKey movementDown = KeyboardKey.S;
        KeyboardKey movementLeft = KeyboardKey.A;
        KeyboardKey movementRight = KeyboardKey.D;
        KeyboardKey dodgeKey = KeyboardKey.Space;
        KeyboardKey reloadKey = KeyboardKey.R;


        Button[] titleButtons =
        {
            // Window. width and height dont work for some reason
            new Button("Rule Button", 10, new Vector2(1280 /2 - 100, 800 / 3 + 280), new Vector2(200, 80), new Color(180, 30, 115), Color.White),
            new Button("setings", 10, new Vector2(1280 /2 - 100, 800 / 3 + 400), new Vector2(200, 80), new Color(180, 30, 115), Color.White),
            new Button("play", 10, new Vector2(1280 / 2 - 100, 800 / 3 + 160), new Vector2(200, 80), new Color(180, 30, 115), Color.White),
        };

        Button[] ruleButtons =
        {
            new Button("Back Button", 10, new Vector2(1160, 25), new Vector2(100, 40), new Color(180, 30, 115), Color.White),
        };

        Button[] settingsButtons =
        {
            new Button("Back Button", 10, new Vector2(1160, 25), new Vector2(40, 20), new Color(180, 30, 115), Color.White),
        };

        public int currentScreen = 0;
        public bool isChangeLeft;

        public void Update(Vector2 mousePos)
        {
            if (currentScreen == 0) TitleScreen(mousePos, titleButtons);
            if (currentScreen == 1) RuleScreen(mousePos, ruleButtons);
            if (currentScreen == 2) SettingsScreen(mousePos, settingsButtons);
        }

        void TitleScreen(Vector2 mousePos, Button[] titleButtons)
        {
            for (int i = 0; i < titleButtons.Length; i++)
            {
                titleButtons[i].Update(mousePos);
                if (titleButtons[i].IsClicked(mousePos, titleButtons[i].isHovering)) currentScreen = i += 1;
            }
            Text.Size = 70;
            Text.Draw("Data Wraith Descent", Window.Width / 4, Window.Height / 3);
           
        }

        void RuleScreen(Vector2 mousePos, Button[] ruleButtons)
        {
            for (int i = 0; i < ruleButtons.Length; i++) ruleButtons[i].Update(mousePos);

            Text.Size = 70;
            Text.Draw("RULE SCREEN", new Vector2(20, 25));

            if (ruleButtons[0].IsClicked(mousePos, ruleButtons[0].isHovering)) currentScreen = 0;

            /*
            //base keybinds//
            WASD movement
            Space douge
            leftclick specal shot
            R reload
            //strech goal// rightclick specal shot
            */

            Text.Size = 30;
            Text.Draw("In this game your objective is to beat the final boss", new Vector2(20, 145));
            Text.Draw("To do this you'll have to fight thier horde floor by floor", new Vector2(20, 180));
            Text.Draw("to do this you'll have to use weapons you upgrade along the way", new Vector2(20, 215));
            Text.Draw("Controls:", new Vector2(20, 250));
            Text.Draw($"Movement:", new Vector2(20, 285));
            Text.Draw($"Up: {movementUp},", new Vector2(20, 320));
            Text.Draw($"Down: {movementDown},", new Vector2(20, 355));
            Text.Draw($"Left: {movementLeft},", new Vector2(20, 390));
            Text.Draw($"Right: {movementRight},", new Vector2(20, 425));
            Text.Draw($"Dodge: {dodgeKey}.", new Vector2(20, 460));
            Text.Draw($"Reload: {reloadKey}", new Vector2(20, 505));
        }

        void SettingsScreen(Vector2 mousePos, Button[] settingsButtons)
        {
            for (int i = 0; i < settingsButtons.Length; i++) settingsButtons[i].Update(mousePos);

            Text.Size = 70;
            Text.Draw("SETTINGS SCREEN", new Vector2(100, 25));

            if (settingsButtons[0].IsClicked(mousePos, settingsButtons[0].isHovering)) currentScreen = 0;
        }
    }
}
