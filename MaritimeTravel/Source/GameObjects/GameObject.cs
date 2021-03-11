using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameObjects {
    abstract class GameObject {
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
