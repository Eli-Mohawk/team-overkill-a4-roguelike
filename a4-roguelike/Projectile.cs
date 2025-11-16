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

        float speed = 500f;

        public void Update()
        {
            Movement();
            DrawBullet();
        }
        public void DrawBullet()
        {
            Draw.FillColor = Color.Gray;
            Draw.Circle(pos, 7f);
        }
        public void Movement()
        {
            pos += speed * angle * Time.DeltaTime;
        }
    }
}
