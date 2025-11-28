using Raylib_cs;
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

        public Screen screen = new Screen();
        public Level level = new Level();

        Texture2D floorSpriteSheet = new Texture2D
        {
            FilePath = @"Sprites\environment-overkill.png",
            FileName = "environment-overkill.png",
            RaylibTexture2D = Raylib.LoadTexture(@"Sprites\environment-overkill.png")
        };

        public Enemy[] enemies =
        {
            new Enemy(new Vector2(500, 600), new Vector2(16, 16), 2f),
            new Enemy(new Vector2(200, 200), new Vector2(16, 16), 2.3f),
            new Enemy(new Vector2(100, 400), new Vector2(16, 16), 2.6f),
            new Enemy(new Vector2(900, 700), new Vector2(16, 16), 2.9f),
            new Enemy(new Vector2(1100, 100), new Vector2(16, 16), 3.2f),
            new Enemy(new Vector2(300, 700), new Vector2(16, 16), 3.5f),
            new Enemy(new Vector2(20, 30), new Vector2(16, 16), 3.8f),
            new Enemy(new Vector2(650, 300), new Vector2(16, 16), 4.1f),
            new Enemy(new Vector2(425, 600), new Vector2(16, 16), 4.4f),
            new Enemy(new Vector2(1250, 720), new Vector2(16, 16), 4.7f),
            new Enemy(new Vector2(850, 500), new Vector2(16, 16), 5f)
        };

        Wall[] walls =
        {
            new Wall(new Vector2(100, 100), new Vector2(64, 64)),
            new Wall(new Vector2(300, 300), new Vector2(64, 64)),
            new Wall(new Vector2(700, 500), new Vector2(64, 64)),
            new Wall(new Vector2(250, 600), new Vector2(64, 64)),
            new Wall(new Vector2(1050, 200), new Vector2(64, 64)),
            new Wall(new Vector2(900, 700), new Vector2(64, 64)),
            new Wall(new Vector2(500, 150), new Vector2(64, 64))
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
            for (int w = 0; w < 1280; w += 16)
            {
                for(int h = 0; h < 800; h += 16)
                {
                    Graphics.DrawSubset(floorSpriteSheet, new Vector2(w, h), new Vector2(80, 0), new Vector2(16, 16));

                }
            }

            Vector2 mousePos = Input.GetMousePosition();

            cheats.Update(screen, player);

            screen.Update(mousePos);
            if (player.isDead) screen.currentScreen = 5;
            if (player.killCount == enemies.Length) screen.currentScreen = 4;
            if (screen.currentScreen != 3) return;

            //level.Update(player, screen);
            
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
