using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Level
    {
        public int levelScreen = 1;

        public void Update(Player player, Screen screen)
        {
            if (levelScreen == 1) ScreenOne(player);
            if (levelScreen == 2) ScreenTwo(player);
            if (levelScreen == 3) ScreenThree(player);
            if (levelScreen == 4) ScreenFour(player);
            if (levelScreen == 5) ScreenFive(player);
            if (levelScreen == 6) ScreenSix(player);
            if (levelScreen == 7) ScreenSeven(player);
            if (levelScreen == 8) ScreenEight(player);
            if (levelScreen == 9) ScreenNine(player);
            if (levelScreen == 10) ScreenTen(player);
            if (levelScreen == 11) ScreenEleven(player);
            if (levelScreen == 12) ScreenTwelve(player);
            if (levelScreen == 13) ScreenThirteen(player);
            if (levelScreen == 14) screen.currentScreen = 4;

            Text.Size = 15;
            Text.Draw($"room {levelScreen}", new Vector2(20, 20));
        }

        // 1-top left, 2-top right, 3-bottom left, 4-bottom right

        void ScreenOne(Player player) // 4
        {
            if (player.pos.Y + player.size.Y >= Window.Height)
            {
                levelScreen = 2;
                player.pos.Y = 5;
            }
        }
        void ScreenTwo(Player player) // 2-4
        {
            if (player.pos.Y <= 0)
            {
                levelScreen = 1;
                player.pos.Y = Window.Height - player.size.Y - 5;
            }
            if (player.pos.Y + player.size.Y >= Window.Height)
            {
                levelScreen = 4;
                player.pos.Y = 5;
            }
            if (player.pos.X + player.size.X >= Window.Width)
            {
                levelScreen = 3;
                player.pos.X = 5;
            }
        }
        void ScreenThree(Player player) // 1-2
        {
            if (player.pos.X <= 0)
            {
                levelScreen = 2;
                player.pos.X = Window.Width - player.size.X - 5;
            }
            if (player.pos.Y + player.size.Y >= Window.Height)
            {
                levelScreen = 5;
                player.pos.Y = 5;
            }
        }
        void ScreenFour(Player player) // 2
        {
            if (player.pos.Y <= 0)
            {
                levelScreen = 2;
                player.pos.Y = Window.Height - player.size.Y - 5;
            }
            if (player.pos.X + player.size.X >= Window.Width)
            {
                levelScreen = 5;
                player.pos.X = 5;
            }
        }
        void ScreenFive(Player player) // 2-3-4
        {
            if (player.pos.Y <= 0)
            {
                levelScreen = 3;
                player.pos.Y = Window.Height - player.size.Y - 5;
            }
            if (player.pos.X <= 0)
            {
                levelScreen = 4;
                player.pos.X = Window.Width - player.size.X - 5;
            }
            if (player.pos.X + player.size.X >= Window.Width)
            {
                levelScreen = 6;
                player.pos.X = 5;
            }
        }
        void ScreenSix(Player player) // 3-4
        {
            if (player.pos.X <= 0)
            {
                levelScreen = 5;
                player.pos.X = Window.Width - player.size.X - 5;
            }
            if (player.pos.X + player.size.X >= Window.Width)
            {
                levelScreen = 7;
                player.pos.X = 5;
            }
        }
        void ScreenSeven(Player player) // 1-2-3-4
        {
            if (player.pos.X <= 0)
            {
                levelScreen = 6;
                player.pos.X = Window.Width - player.size.X - 5;
            }
            if (player.pos.Y <= 0)
            {
                levelScreen = 10;
                player.pos.Y = Window.Height - player.size.Y - 5;
            }
            if (player.pos.Y + player.size.Y >= Window.Height)
            {
                levelScreen = 8;
                player.pos.Y = 5;
            }
        }
        void ScreenEight(Player player) // 2
        {
            if (player.pos.Y <= 0)
            {
                levelScreen = 7;
                player.pos.Y = Window.Height - player.size.Y - 5;
            }
            if (player.pos.X + player.size.X >= Window.Width)
            {
                levelScreen = 9;
                player.pos.X = 5;
            }
        }
        void ScreenNine(Player player) // 1-2-3-4
        {
            if (player.pos.X <= 0)
            {
                levelScreen = 8;
                player.pos.X = Window.Width - player.size.X - 5;
            }
        }
        void ScreenTen(Player player) // 1-3-4
        {
            if (player.pos.Y + player.size.Y >= Window.Height)
            {
                levelScreen = 7;
                player.pos.Y = 5;
            }
            if (player.pos.X <= 0)
            {
                levelScreen = 11;
                player.pos.X = Window.Width - player.size.X - 5;
            }
        }
        void ScreenEleven(Player player) // 2
        {
            if (player.pos.X + player.size.X >= Window.Width)
            {
                levelScreen = 10;
                player.pos.X = 5;
            }
            if (player.pos.Y <= 0)
            {
                levelScreen = 12;
                player.pos.Y = Window.Height - player.size.Y - 5;
            }
        }
        void ScreenTwelve(Player player) // 1-3-4
        {
            if (player.pos.Y + player.size.Y >= Window.Height)
            {
                levelScreen = 11;
                player.pos.Y = 5;
            }
            if (player.pos.X <= 0)
            {
                levelScreen = 13;
                player.pos.X = Window.Width - player.size.X - 5;
            }
        }
        void ScreenThirteen(Player player) // 2-3-4
        {
            if (player.pos.X + player.size.X >= Window.Width)
            {
                levelScreen = 12;
                player.pos.X = 5;
            }
            if (player.pos.Y <= 0)
            {
                levelScreen = 14;
                player.pos.Y = Window.Height + player.size.Y - 5;
            }
        }
    }
}
