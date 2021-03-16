using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MaritimeTravel.Source.GameComponents {
    class Sprite {

        public Vector2 Origin { get; set; }
        public Texture2D Texture { get; }
        public Vector2 Dimensions { get; set; }
        public Color ColorMask { get; set; }
        public float LayerDepth { get; set; }

        public Sprite(Texture2D texture) {
            Texture = texture;
            ColorMask = Color.White;
            Origin = new Vector2(0f, 0f);
            LayerDepth = 0;
            Dimensions = new Vector2(texture.Width, texture.Height);
        }

        public Sprite(Texture2D texture, Vector2 origin) {
            Texture = texture;
            ColorMask = Color.White;
            Origin = origin;
            LayerDepth = 0;
            Dimensions = new Vector2(texture.Width, texture.Height);
        }

        public Sprite(Texture2D texture, Vector2 origin, int ZIndex) {
            Texture = texture;
            ColorMask = Color.White;
            Origin = origin;
            this.LayerDepth = ZIndex;
            Dimensions = new Vector2(texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch, Transform transform, Camera camera, string? debugName) {

            Point scale = new Point(
                (int) (Dimensions.X * transform.Scale.X * camera.Zoom * camera.GlobalScale.X), 
                (int) (Dimensions.Y * transform.Scale.Y * camera.Zoom * camera.GlobalScale.Y)
            );

            // Calculate the rotation
            /*float rotationalOffset = camera.RotationalOffset;       // In Radians
            Vector2 spritePosition = transform.Position;
            Vector2 cameraOffset = camera.Offset;
            Vector2 cameraOrigin = camera.Origin;
            Vector2 positionRelativeToOrigin = spritePosition - cameraOrigin;

            float CosineTheta = (float) Math.Cos(rotationalOffset);
            float SineTheta = (float) Math.Sin(rotationalOffset);

            Vector2 calculatedPosition = new Vector2();
            calculatedPosition.X = (positionRelativeToOrigin.X * CosineTheta) - (positionRelativeToOrigin.Y * SineTheta);
            calculatedPosition.Y = (positionRelativeToOrigin.X * SineTheta) + (positionRelativeToOrigin.Y * CosineTheta);

            Vector2 finalPosition = calculatedPosition - cameraOffset;*/

            Vector2 finalPosition = Vector2.Transform(transform.Position * camera.GlobalScale, camera.transformation);
            float rotationalOffset = camera.RotationalOffset;

            spriteBatch.Draw(
                Texture, 
                new Rectangle(finalPosition.ToPoint(), scale), 
                null, 
                ColorMask,
                transform.Rotation + rotationalOffset,
                Origin,
                SpriteEffects.None,
                Math.Clamp(LayerDepth, 0, 1)
            );
        }

    }
}
