using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class MenuScreen: Screen
    {
        public Menu _Menu { get; set; }
        public MenuScreen(ref SpriteBatch sb)
        {
            SB = sb;
            Backgrounds = new List<TextureMap>();
            DrawableEntities = new List<GameEntity>();
        }

        public MenuScreen(ref SpriteBatch sb, List<Button> b)
        {
            SB = sb;
            Backgrounds = new List<TextureMap>();
            DrawableEntities = new List<GameEntity>();
            _Menu = new Menu(ref sb);
            this._Menu.addButtons(b);
        }

        public override void draw()
        {
            _Menu.draw();
            foreach (TextureMap t in Backgrounds)
            {
                t.Draw(SB, Vector2.Zero);
            }
        }

        public override void update(GameTime t, KeyboardState k, MouseState m)
        {
            _Menu.update(m);
        }

        public override void destroy()
        {
            unsafe
            {
                fixed (int* ptr = &Constants.PLAYER_SCORE)
                {
                    Constants.mUiManager.addString(new UIElement("Score: ", *ptr));
                    Constants.mUiManager.Display.Last().ptr = ptr;
                }
            } 
        }

        public override void addEntity(GameEntity e)
        {
            
        }

        public override void addBackground(TextureMap t)
        {
            
        }

        public override void controls(KeyboardState k)
        {
            
        }
    }
}
