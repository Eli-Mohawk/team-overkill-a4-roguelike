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

        float meleeAttack = 0;
        float meleeCooldown = 2;

        public float maxHP = 5;
        public float currentHP;
        Vector2 barPos;
        Vector2 barSize;

        public Enemy(Vector2 pos, Vector2 size, float speedNum)
        {
            this.pos = pos;
            this.size = size;
            this.speedNum = speedNum;
        }

        public void Setup()
        {
            currentHP = maxHP;
        }

        public void Update(Player player, Enemy[] enemies)
        {
            Collision(player, enemies);
            PlayerTracking(player, enemies);
            DrawEnemy();
            HealthSystem(enemies);
        }

        void DrawEnemy()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Red;
            Draw.Rectangle(pos, size);
        }

        void PlayerTracking(Player player, Enemy[] enemies)
        {
            speed = new Vector2(speedNum, speedNum);

            angle = Vector2.Normalize(pos - player.pos);
            pos -= angle * speed;


        }

        void Collision(Player player, Enemy[] enemies)
        {
            float playerLeft = player.pos.X;
            float playerRight = player.pos.X + player.size.X;
            float playerTop = player.pos.Y;
            float playerBottom = player.pos.Y + player.size.Y;

            float enemyLeft = pos.X;
            float enemyRight = pos.X + size.X;
            float enemyTop = pos.Y;
            float enemyBottom = pos.Y + size.Y;

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

        void HealthSystem(Enemy[] enemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i];
                if (enemy == null) continue;

                barPos = new Vector2(enemy.pos.X, enemy.pos.Y + 26);
                barSize = new Vector2(enemy.size.X / enemy.maxHP * enemy.currentHP, 5);

                Draw.LineSize = 0;
                Draw.FillColor = Color.Green;
                Draw.Rectangle(barPos, barSize);

                if (enemy.currentHP == 0) enemies[i] = null;
            }
        }
    }
}
