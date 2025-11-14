using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Enemy
    {

        public Vector2 pos;
        public Vector2 size;
        float speedNum;
        Vector2 angle;
        Vector2 speed;
        Vector2 TEMP = new Vector2(30, 30);

        public Enemy(Vector2 pos, Vector2 size, float speedNum)
        {
            this.pos = pos;
            this.size = size;
            this.speedNum = speedNum;
        }

        public void Update(Player player, Enemy[] enemies)
        {
            EnemyDistance(player, enemies);
            PlayerTracking(player, enemies);
            DrawEnemy();
        }

        void DrawEnemy()
        {
            Draw.FillColor = Color.Red;
            Draw.Rectangle(pos, size);
        }

        void PlayerTracking(Player player, Enemy[] enemies)
        {
            

            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i];

                enemy.speed = new Vector2(enemy.speedNum, enemy.speedNum);

                enemy.angle = Vector2.Normalize(enemy.pos - player.pos);
                enemy.pos -= enemy.angle * enemy.speed;
            }
        }

        void EnemyDistance(Player player, Enemy[] enemies)
        {
            

            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i];

                float playerBoxLeft = player.pos.X - TEMP.X;
                float playerBoxRight = player.pos.X + player.size.X + TEMP.X;
                float playerBoxTop = player.pos.Y - TEMP.Y;
                float playerBoxBottom = player.pos.Y + player.size.Y + TEMP.Y;

                float enemyLeft = enemy.pos.X;
                float enemyRight = enemy.pos.X + enemy.size.X;
                float enemyTop = enemy.pos.Y;
                float enemyBottom = enemy.pos.Y + enemy.size.Y;

                bool isColliding = playerBoxLeft < enemyRight && playerBoxRight > enemyLeft && playerBoxTop < enemyBottom && playerBoxBottom > enemyTop;

                if (isColliding)
                {
                    if (playerBoxLeft < enemyRight) enemy.pos.X = playerBoxLeft - enemy.size.X;
                    else if (playerBoxRight > enemyLeft) enemy.pos.X = playerBoxRight;
                    else if (playerBoxTop < enemyBottom) enemy.pos.Y = playerBoxTop - enemy.size.Y;
                    else if (playerBoxBottom > enemyTop) enemy.pos.Y = playerBoxBottom;
                }
            }
        }
    }
}
