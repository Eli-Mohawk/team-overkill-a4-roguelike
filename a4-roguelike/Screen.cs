using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
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

    public class Screen
    {
        Button[] titleButtons =
        {
            new Button("play", 10, new Vector2(100, 100), new Vector2(40, 20), new Color(180, 30, 115), Color.White),
            new Button("Rule Button", 10, new Vector2(100, 200), new Vector2(40, 20), new Color(180, 30, 115), Color.White),
            new Button("setings", 10, new Vector2(100, 300), new Vector2(40, 20), new Color(180, 30, 115), Color.White),
        };

        Button[] ruleButtons =
        {
            new Button("Back Button", 10, new Vector2(100, 100), new Vector2(40, 20), new Color(180, 30, 115), Color.White),
        };

        Button[] settingsButtons =
        {
            new Button("Back Button", 10, new Vector2(100, 100), new Vector2(40, 20), new Color(180, 30, 115), Color.White),
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
            for (int i = 0; i < titleButtons.Length; i++) titleButtons[i].Update(mousePos);

            if (titleButtons[0].IsClicked(mousePos, titleButtons[0].isHovering)) currentScreen = 3;
            if (titleButtons[1].IsClicked(mousePos, titleButtons[1].isHovering)) currentScreen = 1;
            if (titleButtons[2].IsClicked(mousePos, titleButtons[2].isHovering)) currentScreen = 2;
       
            Text.Color = Color.White;
            Text.Size = 20;
            Text.Draw("TITLE SCREEN", new Vector2(100, 25));
        }

        void RuleScreen(Vector2 mousePos, Button[] ruleButtons)
        {
            for (int i = 0; i < ruleButtons.Length; i++) ruleButtons[i].Update(mousePos);

            if (ruleButtons[0].IsClicked(mousePos, ruleButtons[0].isHovering)) currentScreen = 0;
            Text.Draw("RULE SCREEN", new Vector2(100, 25));
        }

        void SettingsScreen(Vector2 mousePos, Button[] settingsButtons)
        {
            for (int i = 0; i < settingsButtons.Length; i++) settingsButtons[i].Update(mousePos);

            if (settingsButtons[0].IsClicked(mousePos, settingsButtons[0].isHovering)) currentScreen = 0;
            Text.Draw("SETTINGS SCREEN", new Vector2(100, 25));
        }
    }
}
