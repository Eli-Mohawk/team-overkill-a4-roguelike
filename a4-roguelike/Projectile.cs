using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Projectile
    {
        public Vector2 pos;
        public Vector2 angle;
        public float rad = 3.5f; // temp

        float damage = 1; // temp
        float speed = 500f; // temp

        public void Update(Projectile[] projectiles, Player player, Enemy[] enemies, Wall[] walls)
        {
            Collision(projectiles, player, enemies, walls);
            Movement();
            DrawBullet();
        }

        void DrawBullet()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.White;
            Draw.Circle(pos, rad);
        }

        public void Movement()
        {
            pos += speed * angle * Time.DeltaTime;
        }

        void Collision(Projectile[] projectiles, Player player, Enemy[] enemies, Wall[] walls)
        {
            for (int i = 0; i < projectiles.Length; i++)
            {
                Projectile projectile = projectiles[i];
                if (projectile == null) continue;

                float projectileLeft = projectile.pos.X - projectile.rad;
                float projectileRight = projectile.pos.X + projectile.rad;
                float projectileTop = projectile.pos.Y - projectile.rad;
                float projectileBottom = projectile.pos.Y + projectile.rad;

                float playerLeft = player.pos.X;
                float playerRight = player.pos.X + player.size.X;
                float playerTop = player.pos.Y;
                float playerBottom = player.pos.Y + player.size.Y;

                bool isPlayerHit = playerLeft < projectileRight && playerRight > projectileLeft && playerTop < projectileBottom && playerBottom > projectileTop;

                if (isPlayerHit)
                {
                    projectiles[i] = null;
                    player.currentHP -= 1;
                }

                for (int j = 0; j < enemies.Length; j++)
                {
                    Enemy enemy = enemies[j];
                    if (enemy == null) continue;

                    float enemyLeft = enemy.pos.X;
                    float enemyRight = enemy.pos.X + enemy.size.X;
                    float enemyTop = enemy.pos.Y;
                    float enemyBottom = enemy.pos.Y + enemy.size.Y;

                    bool isEnemyHit = enemyLeft < projectileRight && enemyRight > projectileLeft && enemyTop < projectileBottom && enemyBottom > projectileTop;

                    if (isEnemyHit)
                    {
                        projectiles[i] = null;
                        enemy.currentHP -= damage;
                    }
                }

                for (int j = 0; j < walls.Length; j++)
                {
                    Wall wall = walls[j];
                    if (walls[j] == null) continue;

                    float wallLeft = wall.pos.X;
                    float wallRight = wall.pos.X + wall.size.X;
                    float wallTop = wall.pos.Y;
                    float wallBottom = wall.pos.Y + wall.size.X;

                    bool isWallHit = wallLeft < projectileRight && wallRight > projectileLeft && wallTop < projectileBottom && wallBottom > projectileTop;

                    if (isWallHit) projectiles[i] = null;
                }
            }
        }
    }
}
