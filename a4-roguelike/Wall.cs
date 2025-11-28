using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Wall
    {
        public Vector2 pos;
        public Vector2 size;

        public Wall(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;
        }

        public void Update(Wall[] walls, Player player, Enemy[] enemies)
        {
            Collision(walls, player, enemies);
            DrawWalls();
        }

        void DrawWalls()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Blue;
            Draw.Rectangle(pos, size);
        }

        void Collision(Wall[] walls, Player player, Enemy[] enemies)
        {
            for (int i = 0; i < walls.Length; i++)
            {
                Wall wall = walls[i];
                if (walls[i] == null) continue;

                float wallLeft = wall.pos.X;
                float wallRight = wall.pos.X + wall.size.X;
                float wallTop = wall.pos.Y;
                float wallBottom = wall.pos.Y + wall.size.Y;

                #region player collision
                float playerLeft = player.pos.X;
                float playerRight = player.pos.X + player.size.X;
                float playerTop = player.pos.Y;
                float playerBottom = player.pos.Y + player.size.Y;

                bool isPlayerColliding = playerRight > wallLeft && playerLeft < wallRight && playerBottom > wallTop && playerTop < wallBottom;
                bool isInsideWall = playerLeft > wallLeft && playerRight < wallRight && playerTop > wallTop && playerBottom < wallBottom;

                // UNFINISHED
                if (isPlayerColliding)
                {
                    if (isInsideWall)
                    {
                        float leftDist = playerLeft - wallLeft;
                        float rightDist = playerRight - wallRight;
                        float topDist = playerTop - wallTop;
                        float bottomDist = playerBottom - wallBottom;

                        float minDist = Math.Min(Math.Min(leftDist, rightDist), Math.Min(topDist, bottomDist));

                        if (minDist == leftDist) player.pos.X = wallLeft - player.size.X;
                        else if (minDist == rightDist) player.pos.X = wallRight;
                        else if (minDist == topDist) player.pos.Y = wallRight - player.size.Y;
                        else if (minDist == bottomDist) player.pos.Y = wallBottom;

                        continue;
                    }

                    if (playerBottom > wallTop && playerTop < wallTop) player.pos.Y = wallTop - player.size.Y;
                    else if (playerTop < wallBottom && playerBottom > wallBottom) player.pos.Y = wallBottom;
                    else if (playerRight  > wallLeft && playerLeft < wallLeft) player.pos.X = wallLeft - player.size.X;
                    else if (playerLeft < wallRight && playerRight > wallRight) player.pos.X = wallRight;
                }
                #endregion

                #region enemy collision
                for (int j = 0; j < enemies.Length; j++)
                {
                    Enemy enemy = enemies[j];
                    if (enemy == null) continue;

                    float enemyLeft = enemy.pos.X;
                    float enemyRight = enemy.pos.X + enemy.size.X;
                    float enemyTop = enemy.pos.Y;
                    float enemyBottom = enemy.pos.Y + enemy.size.Y;

                    bool isEnemyColliding = enemyRight > wallLeft && enemyLeft < wallRight && enemyBottom > wallTop && enemyTop < wallBottom;

                    if (isEnemyColliding)
                    {
                        if (enemyBottom > wallTop && enemyTop < wallTop) enemy.pos.Y = wallTop - enemy.size.Y;
                        else if (enemyTop < wallBottom && enemyBottom > wallBottom) enemy.pos.Y = wallBottom;
                        else if (enemyRight > wallLeft && enemyLeft < wallLeft) enemy.pos.X = wallLeft - enemy.size.X;
                        else if (enemyLeft < wallRight && enemyRight > wallRight) enemy.pos.X = wallRight;
                    }
                }
                #endregion
            }
        }
    }
}