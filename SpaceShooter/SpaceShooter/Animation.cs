using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    public class Animation
    {
        public AnimatedSprite Sprite { get; set; }
        public Vector2 Location { get; set; }

        public Animation(AnimatedSprite sprite, Vector2 loc)
        {
            Sprite = sprite;
            Location = loc;
        }
    }
}
