using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Enemy
    {

        public Vector2 pos;
        public Vector2 size;
        Vector2 speed = new Vector2(2, 2);

        public Enemy(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;
        }

        public void Update(Player player, Enemy[] enemies)
        {
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

                enemy.pos = pos;

                Vector2 distance = enemy.pos - player.pos;

                Vector2 angle = Vector2.Normalize(distance);

                pos -= angle;
            }
        }
    }
}
