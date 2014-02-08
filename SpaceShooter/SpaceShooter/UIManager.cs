using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    public class UIElement
    {
        public string Text { get; set; }
        public string DisplayText { get; set; }
        public int Var { get; set; }

        unsafe
        public int* ptr;

        public UIElement(string text, int arg)
        {
            Var = arg;
            Text = text;
            DisplayText = text + Convert.ToString(Var);
        }

        public UIElement(string text, string arg)
        {
            Text = text;
            DisplayText = text + arg;
        }

        public void update()
        {
            
            unsafe
            {
                if (ptr!=null)
                DisplayText = Text + Convert.ToString(*ptr);
            }
        }
    }

    public class UIManager
    {
        public SpriteFont Font { get; set; }
        public List<UIElement> Display { get; set; }
        public SpriteBatch SB { get; set; }

        public UIManager(string font, ref SpriteBatch sb)
        {
            SB = sb;
            Font = Constants.content.Load<SpriteFont>(font);
            Display = new List<UIElement>(0);
        }

        public UIManager()
        {
            Font = Constants.content.Load<SpriteFont>("MyFont");
            Display = new List<UIElement>(0);
        }

        public void draw()
        {
            string drawableString = "";
            foreach (UIElement s in Display)
            {
                s.update();
                drawableString += s.DisplayText + "\n ";
            }
            SB.DrawString(Font, drawableString, 
                new Vector2(30.0f, Constants.graphics.PreferredBackBufferHeight - (40.0f * Display.Count())), Color.White);
        }

        public void addString(UIElement elem)
        {
            Display.Add(elem);
        }

        public void addStrings(List<UIElement> elems)
        {
            Display.AddRange(elems);
        }

        public void removeString(UIElement elem)
        {
            Display.Remove(elem);
        }

        public void removeStrings(List<UIElement> s)
        {
            Display.RemoveRange(0, s.Count());
        }
    }
}
