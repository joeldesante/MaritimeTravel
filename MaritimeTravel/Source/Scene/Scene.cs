using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MaritimeTravel.Source.Scene {
    abstract class Scene {
        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
