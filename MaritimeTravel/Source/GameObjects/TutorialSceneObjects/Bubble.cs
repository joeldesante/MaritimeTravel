using MaritimeTravel.Source.GameComponents;
using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameObjects.TutorialSceneObjects {
    class Bubble : GameObject {

        private Sprite sprite;
        public Transform Transform { get; set; }

        public Bubble(Texture2D texture) {
            this.sprite = new Sprite(texture);
            this.Transform = new Transform(new Vector2(texture.Width, texture.Height));
            this.Transform.Position = new Vector2(500, 500);
            this.Transform.Scale = new Vector2(10f);

            this.sprite.LayerDepth = 0;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Camera camera) {
            this.sprite.Draw(spriteBatch, Transform, camera, "Bubble");
        }

        public override void Update(GameTime gameTime, Camera camera) {}
    }
}
