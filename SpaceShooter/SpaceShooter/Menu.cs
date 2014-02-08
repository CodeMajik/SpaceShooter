using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class Menu
    {
        public List<Button> Buttons { get; set; }
        public SpriteBatch SB { get; set; }
        public Menu(ref SpriteBatch sb)
        {
            SB = sb;
            Buttons = new List<Button>();
        }
        public void addButton(Button b)
        {
            Buttons.Add(b);
        }
        public void addButtons(List<Button> b)
        {
            Buttons.AddRange(b);
        }
        public void removeButton(Button b)
        {
            Buttons.Remove(b);
        }
        public void update(MouseState m)
        {
            foreach (Button b in Buttons)
            {
                b.update(m);
            }
        }
        public void draw()
        {
            foreach (Button b in Buttons)
            {
                b.draw();
            }
        }
    }
}
