using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Cheats cheats = new Cheats();

        public Player player = new Player();
        Weapon weapon = new Weapon(0);

        public Enemy[] enemies =
        {
            new Enemy(new Vector2(500, 600), new Vector2(20, 30)),
            new Enemy(new Vector2(400, 200), new Vector2(20, 30)),
        };
        public Screen screen = new Screen();

        Wall[] walls =
        {
            new Wall(new Vector2(100, 100), new Vector2(100, 100)),
            new Wall(new Vector2(300, 300), new Vector2(100, 100))
        };

        public void Setup()
        {
            Window.SetSize(1280, 800);
            Window.SetTitle("");
        }

        public void Update()
        {
            Window.ClearBackground(Color.Black);

            Vector2 mousePos = Input.GetMousePosition();

            cheats.Update(screen);

            screen.Update(mousePos);
            if (screen.currentScreen != 3)
            {
                return;
            }

            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Update(walls, player, enemies);
            }

            for (int j = 0; j < enemies.Length; j++)
            {
                enemies[j].Update(player, enemies);
            }

            player.Update();
            weapon.Update(player);
        }
    }
}
