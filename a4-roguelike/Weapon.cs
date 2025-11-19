using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MohawkGame2D
{
    public class Weapon
    {
        public int weaponType = 0;
        int weaponImage = 0;

        Vector2 weaponSize = new Vector2(16, 16);
        Vector2 weaponPos;

        Vector2 mousePos;
        bool mouseClick;

        int projectileIndex = 0;
        int magCurrent = 10;
        int magMax = 10; // temp

        Vector2 barPos;
        Vector2 maxBarSize;
        Vector2 currentBarSize;

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

            //sets position of weapon
            if (weaponImage == 0)
            {
                weaponPos = player.pos - weaponSize;
                Draw.Rectangle(weaponPos, weaponSize);
            }
            else if (weaponImage == 1)
            {
                weaponPos = new Vector2(player.pos.X - weaponSize.X, player.pos.Y + player.size.Y / 2 - weaponSize.Y / 2);
                Draw.Rectangle(weaponPos, weaponSize);
            }
            else if (weaponImage == 2)
            {
                weaponPos = new Vector2(player.pos.X - weaponSize.X, player.pos.Y + player.size.Y);
                Draw.Rectangle(weaponPos, weaponSize);
            }
            else if (weaponImage == 3)
            {
                weaponPos = new Vector2(player.pos.X + player.size.X / 2 - weaponSize.X / 2, player.pos.Y - weaponSize.Y);
                Draw.Rectangle(weaponPos, weaponSize);
            }
            else if (weaponImage == 4)
            {
                weaponPos = new Vector2(player.pos.X + player.size.X / 2 - weaponSize.X / 2, player.pos.Y + player.size.Y);
                Draw.Rectangle(weaponPos, weaponSize);
            }
            else if (weaponImage == 5)
            {
                weaponPos = new Vector2(player.pos.X + player.size.X, player.pos.Y - weaponSize.Y);
                Draw.Rectangle(weaponPos, weaponSize);
            }
            else if (weaponImage == 6)
            {
                weaponPos = new Vector2(player.pos.X + player.size.X, player.pos.Y + player.size.Y / 2 - weaponSize.Y / 2);
                Draw.Rectangle(weaponPos, weaponSize);
            }
            else if (weaponImage == 7)
            {
                weaponPos = new Vector2(player.pos.X + player.size.X, player.pos.Y + player.size.Y);
                Draw.Rectangle(weaponPos, weaponSize);
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

            Draw.FillColor = new Color(255, 170, 20);
            Draw.Rectangle(barPos, currentBarSize);
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
            if (weaponImage == 0) Draw.FillColor = Color.White;

            else if (weaponImage == 1) Draw.FillColor = Color.Green;

            else if (weaponImage == 2) Draw.FillColor = Color.Red;

            else if (weaponImage == 3) Draw.FillColor = Color.Green;

            else if (weaponImage == 4) Draw.FillColor = Color.Green;

            else if (weaponImage == 5) Draw.FillColor = Color.Red;

            else if (weaponImage == 6) Draw.FillColor = Color.Green;

            else if (weaponImage == 7) Draw.FillColor = Color.White;

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
