using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameObjects {
    class IntroText : GameObject {
        public GameComponents.Transform Transform { get; }
        public GameComponents.Sprite Drawable { get; }

        public IntroText(Texture2D texture) {
            Transform = new GameComponents.Transform(new Vector2(0, 0));
            Drawable = new GameComponents.Sprite(texture);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Drawable.Draw(spriteBatch, Transform);
        }

        public override void Update(GameTime gameTime) {
            throw new NotImplementedException();
        }
    }
}
