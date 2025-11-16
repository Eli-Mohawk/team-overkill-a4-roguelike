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
        bool melee = false;

        float meleeAttack = 0;
        float meleeCooldown = 2;

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

                float playerLeft = player.pos.X;
                float playerRight = player.pos.X + player.size.X;
                float playerTop = player.pos.Y;
                float playerBottom = player.pos.Y + player.size.Y;

                float enemyLeft = enemy.pos.X;
                float enemyRight = enemy.pos.X + enemy.size.X;
                float enemyTop = enemy.pos.Y;
                float enemyBottom = enemy.pos.Y + enemy.size.Y;

                bool isColliding = playerLeft < enemyRight && playerRight > enemyLeft && playerTop < enemyBottom && playerBottom > enemyTop;

                if (isColliding)
                {
                    meleeAttack += Time.DeltaTime;

                    if (meleeAttack >= meleeCooldown)
                    {
                        meleeAttack = 0;
                        player.currentHP -= 1;
                    }
                }
            }
        }
    }
}
