using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using MaritimeTravel.Source.GameComponents;
using Microsoft.Xna.Framework.Input;



namespace MaritimeTravel.Source.GameObjects {
    class Fish : GameObject {
        private Transform transform;
        private Sprite fishSprite;
        private Rigidbody physics;

        float lastSwimPosition = 1f;

        public Fish(Texture2D fishTexture) {
            fishSprite = new Sprite(fishTexture, new Vector2(fishTexture.Width / 2, fishTexture.Height / 2));
            transform = new Transform();
            physics = new Rigidbody(30, 0.05f);

            transform.Scale *= 1;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            fishSprite.Draw(spriteBatch, transform);
        }

        public override void Update(GameTime gameTime) {
            float currentSwimPosition = lastSwimPosition;
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -0.2f)
                currentSwimPosition = -1f;
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0.2f)
                currentSwimPosition = 1f;

            if (GamePad.GetState(PlayerIndex.One).Buttons.B != ButtonState.Pressed) //Not in Drift mode
            {
                Vector2 parallelAxis = new Vector2((float)Math.Cos(transform.Rotation), (float)Math.Sin(transform.Rotation));
                Vector2 perpendicularAxis = new Vector2((float)Math.Cos(transform.Rotation - Math.PI / 2), (float)Math.Sin(transform.Rotation - Math.PI / 2));
                physics.AddForce(perpendicularAxis * Math.Min(-Vector2.Dot(perpendicularAxis, physics.Velocity) * 500f, 500f));
                physics.AddForce(parallelAxis * -Math.Min(Vector2.Dot(parallelAxis, physics.Velocity), 0) * 100f);
                
                if (currentSwimPosition != lastSwimPosition)
                {
                    lastSwimPosition = currentSwimPosition;

                    physics.AddForce(parallelAxis * physics.Mass * 75f);
                    physics.AddTorque(lastSwimPosition * physics.Velocity.Length() * 25f);
                }
            }
            else
                lastSwimPosition = 0f;

            physics.AddTorque(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * 5f);

            physics.Update(transform, gameTime);
        }
    }
}
