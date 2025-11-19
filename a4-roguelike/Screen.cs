using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
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
        public static KeyboardKey movementUp = KeyboardKey.W;
        public static KeyboardKey movementDown = KeyboardKey.S;
        public static KeyboardKey movementLeft = KeyboardKey.A;
        public static KeyboardKey movementRight = KeyboardKey.D;
        public static KeyboardKey dodgeKey = KeyboardKey.Space;
        public static KeyboardKey reloadKey = KeyboardKey.R;

        bool askInputUP = false;
        bool askInputDOWN = false;
        bool askInputLEFT = false;
        bool askInputRIGHT = false;
        bool askInputDODGE = false;
        bool askInputRELOAD = false;

        Button[] titleButtons =
        {
            // Window. width and height dont work for some reason
            new Button("Rule Button", 10, new Vector2(1280 /2 - 100, 800 / 3 + 280), new Vector2(200, 80), new Color(26, 78, 117), Color.White),
            new Button("setings", 10, new Vector2(1280 /2 - 100, 800 / 3 + 400), new Vector2(200, 80), new Color(26, 78, 117), Color.White),
            new Button("play", 10, new Vector2(1280 / 2 - 100, 800 / 3 + 160), new Vector2(200, 80), new Color(26, 78, 117), Color.White),
        };

        Button[] ruleButtons =
        {
            new Button("Back Button", 10, new Vector2(1160, 25), new Vector2(100, 40), new Color(180, 30, 115), Color.White),
        };

        Button[] settingsButtons;

        public int currentScreen = 0;
        public bool isChangeLeft;

        public void Update(Vector2 mousePos)
        {
            if (currentScreen == 0) TitleScreen(mousePos, titleButtons);
            if (currentScreen == 1) RuleScreen(mousePos, ruleButtons);
            if (currentScreen == 2) SettingsScreen(mousePos, settingsButtons);
            if (currentScreen == 5) GameOverScreen();
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
            settingsButtons = new Button[]
            {
                new Button("Back Button", 10, new Vector2(1160, 25), new Vector2(100, 40), new Color(180, 30, 115), Color.White),
                new Button($"{movementUp}", 30, new Vector2(100, 150), new Vector2(300, 50), new Color(26, 78, 117), Color.White),
                new Button($"{movementDown}", 30, new Vector2(100, 250), new Vector2(300, 50), new Color(26, 78, 117), Color.White),
                new Button($"{movementLeft}", 30, new Vector2(100, 350), new Vector2(300, 50), new Color(26, 78, 117), Color.White),
                new Button($"{movementRight}", 30, new Vector2(100, 450), new Vector2(300, 50), new Color(26, 78, 117), Color.White),
                new Button($"{dodgeKey}", 30, new Vector2(100, 550), new Vector2(300, 50), new Color(26, 78, 117), Color.White),
                new Button($"{reloadKey}", 30, new Vector2(100, 650), new Vector2(300, 50), new Color(26, 78, 117), Color.White),
            };

            for (int i = 0; i < settingsButtons.Length; i++) settingsButtons[i].Update(mousePos);

            Text.Size = 70;
            Text.Draw("SETTINGS SCREEN", new Vector2(100, 25));
            Text.Size = 20;
            Text.Draw("click buttons to remap", new Vector2(100, 120));
            Text.Size = 50;
            Text.Draw(" - UP", new Vector2(410, 150));
            Text.Draw(" - DOWN", new Vector2(410, 250));
            Text.Draw(" - LEFT", new Vector2(410, 350));
            Text.Draw(" - RIGHT", new Vector2(410, 450));
            Text.Draw(" - DODGE", new Vector2(410, 550));
            Text.Draw(" - RELOAD", new Vector2(410, 650));
            if (!askInputUP || !askInputDOWN || !askInputLEFT || !askInputRIGHT || !askInputDODGE || !askInputRELOAD)
            {
                if (settingsButtons[0].IsClicked(mousePos, settingsButtons[0].isHovering)) currentScreen = 0;

                if (settingsButtons[1].IsClicked(mousePos, settingsButtons[1].isHovering)) askInputUP = true;
                if (settingsButtons[2].IsClicked(mousePos, settingsButtons[2].isHovering)) askInputDOWN = true;
                if (settingsButtons[3].IsClicked(mousePos, settingsButtons[3].isHovering)) askInputLEFT = true;
                if (settingsButtons[4].IsClicked(mousePos, settingsButtons[4].isHovering)) askInputRIGHT = true;
                if (settingsButtons[5].IsClicked(mousePos, settingsButtons[5].isHovering)) askInputDODGE = true;
                if (settingsButtons[6].IsClicked(mousePos, settingsButtons[6].isHovering)) askInputRELOAD = true;
            }

            if (askInputUP || askInputDOWN || askInputLEFT || askInputRIGHT || askInputDODGE || askInputRELOAD)
            {
                //tells player to pick a new key bind
                Text.Size = 100;
                Draw.FillColor = Color.DarkGray;
                Draw.Rectangle(new Vector2(0, 0), new Vector2(1280, 800));
                Text.Draw("Click a key on your ", new Vector2(10, 200));
                Text.Draw("keyboard ", new Vector2(110, 310));
                //tracks button input
                int keyPressed = Raylib.GetKeyPressed();
                //remaps button input and stops asling for new input
                if (keyPressed != 0)
                {
                    if (askInputUP)
                    {
                        movementUp = (KeyboardKey)keyPressed;
                        askInputUP = false;
                    }
                    if (askInputDOWN)
                    {
                        movementDown = (KeyboardKey)keyPressed;
                        askInputDOWN = false;
                    }
                    if(askInputLEFT)
                    {
                        movementLeft = (KeyboardKey)keyPressed;
                        askInputLEFT = false;
                    }
                    if (askInputRIGHT)
                    {
                        movementRight = (KeyboardKey)keyPressed;
                        askInputRIGHT = false;
                    }
                    if(askInputDODGE)
                    {
                        dodgeKey = (KeyboardKey)keyPressed;
                        askInputDODGE = false;
                    }
                    if(askInputRELOAD)
                    {
                        reloadKey = (KeyboardKey)keyPressed;
                        askInputRELOAD = false;
                    }
                }
            }
        }

        void GameOverScreen()
        {
            Text.Size = 100;
            Text.Draw("EAT GRENADES LOSER!", new Vector2(10, 10));
        }
    }
}
