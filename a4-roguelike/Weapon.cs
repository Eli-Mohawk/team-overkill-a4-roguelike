using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MohawkGame2D
{
    public class Weapon
    {
        public int weaponType = 0;
        int weaponImage = 0;

        Vector2 weaponSize = new Vector2(32, 32);
        Vector2 weaponPos;

        Vector2 mousePos;
        bool mouseClick;

        int projectileIndex = 0;
        int magCurrent = 10;
        int magMax = 10; // temp

        Vector2 barPos;
        Vector2 maxBarSize;
        Vector2 currentBarSize;

        public Vector2 gunSubset;
        public Weapon(int weaponType)
        {
            this.weaponType = weaponType;
        }

        public void Update(Projectile[] projectiles, Player player, Enemy[] enemies, Wall[] walls)
        {
            mousePos = Input.GetMousePosition();
            mouseClick = Input.IsMouseButtonPressed(0);

            if (weaponType == 0)
            {
                Pistol(projectiles, player, enemies, walls);
            }

            drawAmmoCounter();
            drawHelp(player);
            reloadLogic();
        }

        void drawHelp(Player player)
        {
            bool leftScreen = mousePos.X < player.pos.X;
            bool rightScreen = mousePos.X > player.pos.X + player.size.X;
            bool middleScreenX = !leftScreen && !rightScreen;

            bool topScreen = mousePos.Y < player.pos.Y;
            bool bottomScreen = mousePos.Y > player.pos.Y + player.size.Y;
            bool middleScreenY = !topScreen && !bottomScreen;

            //left side of the screen image type
            if (leftScreen && topScreen) weaponImage = 0; // left top
            if (leftScreen && middleScreenY) weaponImage = 1; // left middle
            if (leftScreen && bottomScreen) weaponImage = 2; // left bottom

            //middle of the screen image type
            if (middleScreenX && topScreen) weaponImage = 3; // top middle
            if (middleScreenX && bottomScreen) weaponImage = 4; // bottom middle

            //rigth of the screen image type
            if (rightScreen && topScreen) weaponImage = 5; // right top
            if (rightScreen && middleScreenY) weaponImage = 6; // right middle
            if (rightScreen && bottomScreen) weaponImage = 7; // right bottom

            Texture2D gunSpriteSheet = new Texture2D
            {
                FilePath = @"Sprites\guns-overkill.png",
                FileName = "guns-overkill.png",
                RaylibTexture2D = Raylib.LoadTexture(@"Sprites\guns-overkill.png")
            };
            //sets position of weapon
            Draw.LineSize = 0;
            if (weaponImage == 0)//top left
            {
                weaponPos = player.pos - weaponSize;
                Graphics.DrawSubset(gunSpriteSheet, weaponPos, gunSubset, new Vector2(32, 32));
            }
            else if (weaponImage == 1)//left
            {
                weaponPos = new Vector2(player.pos.X - weaponSize.X, player.pos.Y + player.size.Y / 2 - weaponSize.Y / 2);
                Graphics.DrawSubset(gunSpriteSheet, weaponPos, gunSubset, new Vector2(32, 32));
            }
            else if (weaponImage == 2)//bottom left
            {
                weaponPos = new Vector2(player.pos.X - weaponSize.X, player.pos.Y + player.size.Y);
                Graphics.DrawSubset(gunSpriteSheet, weaponPos, gunSubset, new Vector2(32, 32));
            }
            else if (weaponImage == 3)//top
            {
                weaponPos = new Vector2(player.pos.X + player.size.X / 2 - weaponSize.X / 2, player.pos.Y - weaponSize.Y);
                Graphics.DrawSubset(gunSpriteSheet, weaponPos, gunSubset, new Vector2(32, 32));
            }
            else if (weaponImage == 4)//bottom
            {
                weaponPos = new Vector2(player.pos.X + player.size.X / 2 - weaponSize.X / 2, player.pos.Y + player.size.Y);
                Graphics.DrawSubset(gunSpriteSheet, weaponPos, gunSubset, new Vector2(32, 32));
            }
            else if (weaponImage == 5)//top right
            {
                weaponPos = new Vector2(player.pos.X + player.size.X, player.pos.Y - weaponSize.Y);
                Graphics.DrawSubset(gunSpriteSheet, weaponPos, gunSubset, new Vector2(32, 32));
            }
            else if (weaponImage == 6)//right
            {
                weaponPos = new Vector2(player.pos.X + player.size.X, player.pos.Y + player.size.Y / 2 - weaponSize.Y / 2);
                Graphics.DrawSubset(gunSpriteSheet, weaponPos, gunSubset, new Vector2(32, 32));
            }
            else if (weaponImage == 7)//bottom right
            {
                weaponPos = new Vector2(player.pos.X + player.size.X, player.pos.Y + player.size.Y);
                Graphics.DrawSubset(gunSpriteSheet, weaponPos, gunSubset, new Vector2(32, 32));
            }
            else {/* middle of the charater */}
        }
        void drawAmmoCounter()
        {
            barPos = new Vector2(13, 730);
            maxBarSize = new Vector2(106, 25);
            currentBarSize = new Vector2(maxBarSize.X / magMax * magCurrent, maxBarSize.Y);

            Draw.FillColor = Color.Gray;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 3;
            Draw.Rectangle(barPos, maxBarSize);

            if (magCurrent > 0)
            {
                Draw.LineSize = 0;
                Draw.FillColor = new Color(255, 170, 20);
                Draw.Rectangle(barPos.X + 3, barPos.Y + 3, currentBarSize.X - 6, maxBarSize.Y - 6);
            }

            Text.Color = Color.White;
            Text.Size = 15;
            int textWidth = Raylib.MeasureText($"Ammo: {magCurrent}/{magMax}", 15);
            float textX = barPos.X + (maxBarSize.X / 2 - textWidth / 2);
            float textY = barPos.Y + (maxBarSize.Y / 2 - 15 / 2);
            Text.Draw($"Ammo: {magCurrent}/{magMax}", new Vector2(textX - 3, textY));
        }
        void reloadLogic()
        {
            if (Input.IsKeyboardKeyPressed((KeyboardInput)Screen.reloadKey))
            {
                projectileIndex = 0;
                magCurrent = 10;
            }
        }
        void Pistol(Projectile[] projectiles, Player player, Enemy[] enemies, Wall[] walls)
        {
            //Darws weapon
            #region DrawPistol
            //assign image ( right now its color )
            if (weaponImage == 0) gunSubset = new Vector2(64, 32);

            else if (weaponImage == 1) gunSubset = new Vector2(0, 32);

            else if (weaponImage == 2) gunSubset = new Vector2(96, 32);

            else if (weaponImage == 3) gunSubset = new Vector2(32, 32);

            else if (weaponImage == 4) gunSubset = new Vector2(32, 0);

            else if (weaponImage == 5) gunSubset = new Vector2(96, 0);

            else if (weaponImage == 6) gunSubset = new Vector2(0, 0);

            else if (weaponImage == 7) gunSubset = new Vector2(64, 0);

            #endregion

            //attack logic
            #region pistolAttack
            if (mouseClick && projectileIndex < projectiles.Length)
            {
                Projectile projectile = new Projectile();
                projectile.pos = weaponPos + weaponSize / 2;

                projectile.angle = Vector2.Normalize(mousePos - weaponPos);

                projectiles[projectileIndex] = projectile;
                projectileIndex++;
                magCurrent--;
            }
            for (int i = 0; i < projectileIndex; i++)
            {
                if (projectiles[i] == null) continue;

                projectiles[i].Update(projectiles, player, enemies, walls);
            }

            #endregion
        }

    }
}
