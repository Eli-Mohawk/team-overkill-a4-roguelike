using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Cheats cheats = new Cheats();

        public Player player = new Player();
        public Enemy[] enemies =
        {
            new Enemy(new Vector2(500, 600), new Vector2(20, 30), 0.5f),
            new Enemy(new Vector2(200, 200), new Vector2(20, 30), 1),
            new Enemy(new Vector2(100, 400), new Vector2(20, 30), 1.5f),
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
            Window.SetTitle("Data Wraith Descent");

            player.Setup();
        }

        public void Update()
        {
            Window.ClearBackground(new Color(46, 46, 46));

            Vector2 mousePos = Input.GetMousePosition();

            cheats.Update(screen, player);

            if (player.isDead) screen.currentScreen = 5;

            screen.Update(mousePos);
            if (screen.currentScreen != 3) return;
            
            for (int i = 0; i < walls.Length; i++) walls[i].Update(walls, player, enemies);

            for (int i = 0; i < enemies.Length; i++) enemies[i].Update(player, enemies);

            player.Update();
        }
    }
}
