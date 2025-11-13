using System;
using System.Collections.Generic;
using System.Linq;
﻿using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Button
    {
        public String text;
        public int fontSize;

        public Vector2 pos;
        public Vector2 size;

        public Color color;
        public Color textColor;

        Color hoverColor;

        public Button(String text, int fontSize, Vector2 pos, Vector2 size, Color color, Color textColor)
        {
            this.text = text;
            this.fontSize = fontSize;
            this.pos = pos;
            this.size = size;
            this.color = color;
            this.textColor = textColor;
            this.hoverColor = new Color(color.R - 30, color.G - 30, color.B - 30);
        }

        public void Update(Vector2 mousePos)
        {
            bool isHovering = mousePos.X > pos.X && mousePos.X < pos.X + size.X && mousePos.Y > pos.Y && mousePos.Y < pos.Y + size.Y;
            DrawButton(mousePos, isHovering);
            IsClicked(mousePos, isHovering);
        }

        void DrawButton(Vector2 mousePos, bool isHovering)
        {
            if (isHovering) Draw.FillColor = hoverColor;
            else Draw.FillColor = color;

            Draw.Rectangle(pos, size);

            Text.Size = fontSize;
            int textWidth = Raylib.MeasureText(text, fontSize);

            float textX = pos.X + (size.X / 2 - textWidth / 2);
            float textY = pos.Y + (size.Y / 2 - fontSize / 2);

            Text.Color = textColor;
            Text.Draw(text, new Vector2(textX, textY));
        }

        public bool IsClicked(Vector2 mousePos, bool isHovering)
        {
            bool isMousePressed = Input.IsMouseButtonPressed(MouseInput.Left);

            return isHovering && isMousePressed;
        }
    }
}
