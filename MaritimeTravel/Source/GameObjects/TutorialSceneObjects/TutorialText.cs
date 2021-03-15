using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameObjects.TutorialSceneObjects {
    class TutorialText : GameObject {
        public GameComponents.Transform Transform { get; }
        public GameComponents.Sprite Drawable { get; }

        public TutorialText(Texture2D texture) {
            Transform = new GameComponents.Transform();
            Drawable = new GameComponents.Sprite(texture);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Camera camera) {
            Drawable.Draw(spriteBatch, Transform, camera, "TutText");
        }

        public override void Update(GameTime gameTime, Camera camera) {
            throw new NotImplementedException();
        }
    }
}
