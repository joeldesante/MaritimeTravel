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

        public Fish(Texture2D fishTexture) {
            this.fishSprite = new Sprite(fishTexture, new Vector2(fishTexture.Width / 2, fishTexture.Height / 2));
            transform = new Transform();
            physics = new Rigidbody(30);

            transform.Scale *= 5;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            fishSprite.Draw(spriteBatch, transform);
        }

        public override void Update(GameTime gameTime) {
            Vector2 invertedY = new Vector2(
                GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X,
                -GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y
            );

            physics.AddForce(invertedY * physics.Mass * 5);
            physics.Update(transform, gameTime);
        }
    }
}
