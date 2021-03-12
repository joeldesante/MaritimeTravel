using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MaritimeTravel.Source.Scene {
    abstract class Scene {

        protected MaritimeTravel game;
        
        public Scene(MaritimeTravel game) {
            this.game = game;
        }

        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
