using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    interface IScreen
    {
        void draw();
        void update(GameTime t, KeyboardState k, MouseState m);
        void destroy();
        void addEntity(GameEntity e);
        void addBackground(TextureMap t);
        void controls(KeyboardState k);
    }
    public abstract class Screen: IScreen
    {
        public List<GameEntity> DrawableEntities { get; set; }
        public List<TextureMap> Backgrounds { get; set; }
        public SpriteBatch SB { get; set; }

        public abstract void draw();
        public abstract void update(GameTime t, KeyboardState k, MouseState m);
        public abstract void destroy();
        public abstract void addEntity(GameEntity e);
        public abstract void addBackground(TextureMap t);
        public abstract void controls(KeyboardState k);
    }
}
