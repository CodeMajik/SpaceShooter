using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class SplashScreen: Screen
    {
        private SpriteFont font;
        private List<UIElement> mDisplay;
        public SplashScreen(string textureName, ref SpriteBatch sb, params string[] uistrings)
        {
            SB = sb;
            Backgrounds = new List<TextureMap>();
            DrawableEntities = new List<GameEntity>();
            Backgrounds.Add(new TextureMap(Constants.content.Load<Texture2D>(textureName), 1, 1));
            font = Constants.content.Load<SpriteFont>("MyFont");

            mDisplay = new List<UIElement>(0);
            mDisplay.Add(new UIElement("", uistrings[0]));

            Constants.mUiManager.addStrings(mDisplay);
        }

        public override void draw()
        {
            foreach (TextureMap t in Backgrounds)
            {
                t.Draw(SB, new Vector2());
            }
 
            //foreach (GameEntity g in DrawableEntities)
            //{
            //    g.draw();
            //}
        }

        public override void update(GameTime t, KeyboardState k, MouseState m)
        {
            foreach (GameEntity g in DrawableEntities)
            {
                g.update();
            }
            controls(k);
        }

        public override void destroy()
        {
            Constants.mUiManager.removeStrings(mDisplay);
        }

        public override void controls(KeyboardState k)
        {
            if (k.IsKeyDown(Keys.Space)&&!Constants.GAME_OVER)
            {
                this.destroy();
                Constants.mScreenStack.push(Constants.mMenuScreen);
            }
        }

        public override void addEntity(GameEntity e)
        {
            DrawableEntities.Add(e);
        }

        public override void addBackground(TextureMap t)
        {
            Backgrounds.Add(t);
        }
    }
}
