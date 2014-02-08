using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class Button
    {
        public delegate void OnClickEvent();
        public TextureMap Texture { get; set; }
        public Vector2 Position { get; set; }
        public OnClickEvent OnClick { get; set; }
        private int width, height;

        public Button(TextureMap tex, Vector2 pos, OnClickEvent evt)
        {
            Position = pos;
            OnClick = evt;
            Texture = tex;
            width = tex.width;
            height = tex.height;
        }

        public void draw()
        {
            Constants.sb.Draw(Texture.Texture, Position, Color.White);
        }

        public void update(MouseState m)
        {
            if (m.X >= Position.X && m.X <= Position.X + width)
                if (m.Y >= Position.Y && m.Y <= Position.Y + height)
                    if(m.LeftButton == ButtonState.Pressed)
                    this.OnClick();
        }
    }
}
