using System;
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
            new Button("Title Button", 10, new Vector2(100, 100), new Vector2(40, 20), new Color(180, 30, 115), Color.White)
        };

        Button[] ruleButtons =
        {
            new Button("Rule Button", 10, new Vector2(100, 100), new Vector2(40, 20), new Color(180, 30, 115), Color.White)
        };

        Button[] settingsButtons =
        {
            new Button("Move Left", 10, new Vector2(100, 100), new Vector2(40, 20), new Color(180, 30, 115), Color.White)
        };

        public int currentScreen = 0;
        public bool isChangeLeft;

        public void Update(Vector2 mousePos)
        {
            if (currentScreen == 0) TitleScreen(mousePos);
            if (currentScreen == 1) RuleScreen(mousePos);
            if (currentScreen == 2) SettingsScreen(mousePos);
        }

        void TitleScreen(Vector2 mousePos)
        {
            for (int i = 0; i < titleButtons.Length; i++)
            {
                titleButtons[i].Update(mousePos);
            }

            Text.Color = Color.White;
            Text.Size = 20;
            Text.Draw("TITLE SCREEN", new Vector2(100, 25));
        }

        void RuleScreen(Vector2 mousePos)
        {
            for (int i = 0; i < ruleButtons.Length; i++)
            {
                ruleButtons[i].Update(mousePos);
            }

            Text.Draw("RULE SCREEN", new Vector2(100, 25));
        }

        void SettingsScreen(Vector2 mousePos)
        {
            isChangeLeft = false;

            for (int i = 0; i < settingsButtons.Length; i++) settingsButtons[i].Update(mousePos);

            Text.Draw("SETTINGS SCREEN", new Vector2(100, 25));
        }
    }
}
