using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 pos = new Vector2(300, 200);
        public Vector2 size = new Vector2(10, 20);
        float speed = 2;

        public void Update()
        {
            Inputs();
            EdgeCollision();
            DrawPlayer();
        }

        void DrawPlayer()
        {
            Draw.FillColor = Color.Yellow;
            Draw.Rectangle(pos, size);
        }

        void EdgeCollision()
        {
            float playerLeft = pos.X;
            float playerRight = pos.X + size.X;
            float playerTop = pos.Y;
            float playerBottom = pos.Y + size.Y;

            if (playerLeft < 0)
            {
                pos.X = 0;
            }
            if (playerRight > 800)
            {
                pos.X = 800 - size.X;
            }
            if (playerTop < 0)
            {
                pos.Y = 0;
            }
            if (playerBottom > 600)
            {
                pos.Y = 600 - size.Y;
            }
        }

        public void Inputs()
        {
            bool isLeft = Input.IsKeyboardKeyDown(KeyboardInput.A);
            bool isRight = Input.IsKeyboardKeyDown(KeyboardInput.D);
            bool isUp = Input.IsKeyboardKeyDown(KeyboardInput.W);
            bool isDown = Input.IsKeyboardKeyDown(KeyboardInput.S);

            bool isDodging = Input.IsKeyboardKeyPressed(KeyboardInput.Space);

            if (isLeft) pos.X -= speed;
            if (isRight) pos.X += speed;
            if (isUp) pos.Y -= speed;
            if (isDown) pos.Y += speed;

            if (isDodging && isLeft) pos.X -= speed * 5;
            if (isDodging && isRight) pos.X += speed * 5;
            if (isDodging && isUp) pos.Y -= speed * 5;
            if (isDodging && isDown) pos.Y += speed * 5;
        }
    }
}
