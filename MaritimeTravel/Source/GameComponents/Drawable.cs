﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MaritimeTravel.Source.GameComponents {
    class Drawable {

        public Vector2 Origin { get; set; }
        public Texture2D Texture { get; }
        public Color ColorMask { get; set; }

        public Drawable(Texture2D texture) {
            Texture = texture;
            ColorMask = Color.White;
            Origin = new Vector2(0f, 0f);
        }

        public void Draw(SpriteBatch spriteBatch, Transform transform) {

            Point scale = new Point(
                (int) (transform.Dimensions.X * transform.Scale.X), 
                (int) (transform.Dimensions.Y * transform.Scale.Y)
            );

            spriteBatch.Draw(
                Texture, 
                new Rectangle(transform.Position.ToPoint(), scale), 
                null, 
                ColorMask,
                transform.Rotation,
                Origin,
                SpriteEffects.None,
                0f
            );
        }

    }
}