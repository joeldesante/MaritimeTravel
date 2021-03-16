using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameObjects.Scenery {
    class SceneryManager : GameObject {

        public Background background { get; set; }

        public SceneryManager() {
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Camera camera) {
            if (background != null) {
                background.Draw(spriteBatch, gameTime, camera);
            }
        }

        public override void Update(GameTime gameTime, Camera camera) {
            if (background != null) {
                background.Update(gameTime, camera);
            }
        }
    }
}
