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
        public Vector2 size = new Vector2(16, 16);
        public float speed = 5;

        float maxHP = 100;
        public float currentHP;
        public bool isDead = false;

        Vector2 barPos;
        Vector2 maxBarSize;
        Vector2 currentBarSize;

        public void Setup()
        {
            currentHP = maxHP;
        }

        public void Update()
        {
            Inputs();
            EdgeCollision();
            DrawPlayer();
            HealthSystem();
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

            if (playerLeft < 0) pos.X = 0;
            if (playerRight > Window.Width) pos.X = Window.Width - size.X;
            if (playerTop < 0) pos.Y = 0;
            if (playerBottom > Window.Height) pos.Y = Window.Height - size.Y;
        }

        public void Inputs()
        {
            bool isLeft = Input.IsKeyboardKeyDown((KeyboardInput)Screen.movementLeft);
            bool isRight = Input.IsKeyboardKeyDown((KeyboardInput)Screen.movementRight);
            bool isUp = Input.IsKeyboardKeyDown((KeyboardInput)Screen.movementUp);
            bool isDown = Input.IsKeyboardKeyDown((KeyboardInput)Screen.movementDown);

            bool isDodging = Input.IsKeyboardKeyPressed((KeyboardInput)Screen.dodgeKey);
            
            if (isLeft) pos.X -= speed;
            if (isRight) pos.X += speed;
            if (isUp) pos.Y -= speed;
            if (isDown) pos.Y += speed;

            if (isDodging && isLeft) pos.X -= speed * 5;
            if (isDodging && isRight) pos.X += speed * 5;
            if (isDodging && isUp) pos.Y -= speed * 5;
            if (isDodging && isDown) pos.Y += speed * 5;
        }

        void HealthSystem()
        {
            barPos = new Vector2(13, 765);
            maxBarSize = new Vector2(106, 25);
            currentBarSize.X = currentHP;

            Draw.LineSize = 3;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(barPos, maxBarSize);

            Draw.LineSize = 0;
            Draw.FillColor = Color.Red;
            Draw.Rectangle(barPos.X + 3, barPos.Y + 3, currentBarSize.X, maxBarSize.Y - 6);

            if (currentHP <= 0) isDead = true;
        }
    }
}
