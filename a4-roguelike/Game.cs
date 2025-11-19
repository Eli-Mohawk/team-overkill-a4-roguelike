using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace MohawkGame2D
{
    public class Game
    {
        Cheats cheats = new Cheats();

        public Player player = new Player();
        Weapon weapon = new Weapon(0);
        Projectile[] projectiles = new Projectile[10];

        public Enemy[] enemies =
        {
            new Enemy(new Vector2(500, 600), new Vector2(16, 16), 2f),
            new Enemy(new Vector2(200, 200), new Vector2(16, 16), 2f),
            new Enemy(new Vector2(100, 400), new Vector2(16, 16), 2f),
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
            for (int i = 0; i < enemies.Length; i++) enemies[i].Setup();
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

            player.Update();
            weapon.Update(projectiles, player, enemies, walls);

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] == null) continue;
                
                enemies[i].Update(player, enemies);
            }

        }
    }
}
