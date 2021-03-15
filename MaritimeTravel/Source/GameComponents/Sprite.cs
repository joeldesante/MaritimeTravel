using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MaritimeTravel.Source.GameComponents {
    class Sprite {

        public Vector2 Origin { get; set; }
        public Texture2D Texture { get; }
        public Color ColorMask { get; set; }
        public float LayerDepth { get; set; }

        public Sprite(Texture2D texture) {
            Texture = texture;
            ColorMask = Color.White;
            Origin = new Vector2(0f, 0f);
            LayerDepth = 0;
        }

        public Sprite(Texture2D texture, Vector2 origin) {
            Texture = texture;
            ColorMask = Color.White;
            Origin = origin;
            LayerDepth = 0;
        }

        public Sprite(Texture2D texture, Vector2 origin, int ZIndex) {
            Texture = texture;
            ColorMask = Color.White;
            Origin = origin;
            this.LayerDepth = ZIndex;
        }

        public void Draw(SpriteBatch spriteBatch, Transform transform, Camera camera) {

            Point scale = new Point(
                (int) (transform.Dimensions.X * transform.Scale.X), 
                (int) (transform.Dimensions.Y * transform.Scale.Y)
            );

            Vector2 r = new Vector2(
                (float) (Math.Cos(camera.RotationalOffset * transform.Position.X) - Math.Sin(camera.RotationalOffset * transform.Position.Y)),
                (float) (Math.Sin(camera.RotationalOffset * transform.Position.X) + Math.Cos(camera.RotationalOffset * transform.Position.Y))
            );

            Point offsetPosition = transform.Position.ToPoint() - camera.Offset.ToPoint();
            double distanceFromOrigin = Math.Sqrt(
                Math.Pow(transform.Position.X - camera.Origin.X, 2) + 
                Math.Pow(transform.Position.Y - camera.Origin.Y, 2)
            );

            /*
             * Gets the relative position in which everything must be account for.
             * Ex. (0, 1) means that everything must be rotated 90deg from the origin.
             */
            Vector2 rotationalOffsetPosition = new Vector2(
                (float)Math.Cos(camera.RotationalOffset),
                (float)Math.Sin(camera.RotationalOffset)
            );
            Vector2 rotatedPositionLocalSpace = transform.Position * rotationalOffsetPosition;
            
            Point finalPosition = (rotationalOffsetPosition.ToPoint() * new Point((int) distanceFromOrigin));

            //Point offsetPosition = rotationalOffsetPosition - camera.Offset.ToPoint();

            /*System.Diagnostics.Debug.WriteLine("Position: " + transform.Position.ToPoint());
            System.Diagnostics.Debug.WriteLine("Roational Position Offset: " + rotationalOffsetPosition);
            System.Diagnostics.Debug.WriteLine("Rotated Position: " + rotatedPositionLocalSpace);
            System.Diagnostics.Debug.WriteLine("Distance From Origin: " + distanceFromOrigin);
            System.Diagnostics.Debug.WriteLine("Final Position: " + finalPosition);*/

            System.Diagnostics.Debug.WriteLine("R: " + r);

            spriteBatch.Draw(
                Texture, 
                new Rectangle(finalPosition, scale), 
                null, 
                ColorMask,
                transform.Rotation + camera.RotationalOffset,
                Origin,
                SpriteEffects.None,
                Math.Clamp(LayerDepth, 0, 1)
            );
        }

    }
}
