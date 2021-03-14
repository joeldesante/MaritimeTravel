using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameObjects {
    class IntroText : GameObject {
        public GameComponents.Transform Transform { get; }
        public GameComponents.Sprite Drawable { get; }

        private Camera camera;

        public IntroText(Texture2D texture) {
            Transform = new GameComponents.Transform(new Vector2(0, 0));
            Drawable = new GameComponents.Sprite(texture);
            camera = new Camera();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Camera camera) {
            Drawable.Draw(spriteBatch, Transform, camera);
        }

        public override void Update(GameTime gameTime, Camera camera) {
            throw new NotImplementedException();
        }
    }
}
