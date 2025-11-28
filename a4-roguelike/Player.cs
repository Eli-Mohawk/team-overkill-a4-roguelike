using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 pos = new Vector2(310, 210);
        public Vector2 size = new Vector2(32, 32);
        public float speed = 5;
        public int killCount;

        float maxHP = 100;
        public float currentHP;
        public bool isDead = false;

        float frameTimer;
        int frameIndex;
        bool forward;

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
            Texture2D playerSpriteSheet = new Texture2D
            {
                FilePath = @"Sprites\player-overkill.png",
                FileName = "player-overkill.png",
                RaylibTexture2D = Raylib.LoadTexture(@"Sprites\player-overkill.png")
            };

            frameTimer += 1;
            Vector2[] playerFrames = { new Vector2(0, 0), new Vector2(32, 0), new Vector2(64, 0), new Vector2(96, 0), new Vector2(128, 0) };
            Vector2[] playerFramesBackward = { new Vector2(0, 32), new Vector2(32, 32), new Vector2(64, 32), new Vector2(96, 32), new Vector2(128, 32) };

            if (frameTimer >= 10)
            {
                if (frameIndex == 4)
                    frameIndex = 0;
                else
                {
                    frameIndex += 1;
                    frameTimer = 0;
                }
            }
            if (forward)
                Graphics.DrawSubset(playerSpriteSheet, pos, playerFrames[frameIndex], new Vector2(32, 32));
            else
                Graphics.DrawSubset(playerSpriteSheet, pos, playerFramesBackward[frameIndex], new Vector2(32, 32));
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


            if (isUp) pos.Y -= speed;
            if (isDown) pos.Y += speed;

            if (isLeft)
            {
                pos.X -= speed;
                forward = false;
            }
            if (isRight)
            {
                pos.X += speed;
                forward = true;
            }

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

            if (currentHP > 0)
            {
                Draw.LineSize = 0;
                Draw.FillColor = Color.Red;
                Draw.Rectangle(barPos.X + 3, barPos.Y + 3, currentBarSize.X, maxBarSize.Y - 6);
            }

            Text.Color = Color.White;
            Text.Size = 15;
            int textWidth = Raylib.MeasureText($"HP: {currentHP}/{maxHP}", 15);
            float textX = barPos.X + (maxBarSize.X / 2 - textWidth / 2);
            float textY = barPos.Y + (maxBarSize.Y / 2 - 15 / 2);
            Text.Draw($"HP: {currentHP}/{maxHP}", new Vector2(textX - 3, textY));

            if (currentHP <= 0) isDead = true;
        }
    }
}
