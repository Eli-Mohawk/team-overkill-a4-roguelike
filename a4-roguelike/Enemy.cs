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
        float speed;

        public Enemy(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;
        }

        public void Update()
        {
            DrawEnemy();
        }

        void DrawEnemy()
        {
            Draw.FillColor = Color.Red;
            Draw.Rectangle(pos, size);
        }
    }
}
