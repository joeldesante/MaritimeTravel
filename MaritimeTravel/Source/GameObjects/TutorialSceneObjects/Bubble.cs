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
        private Transform transform;

        public Bubble(Texture2D texture) {
            this.sprite = new Sprite(texture);
            this.transform = new Transform(new Vector2(texture.Width, texture.Height));
            this.transform.Position = new Vector2(500, 500);

            this.sprite.LayerDepth = 0;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Camera camera) {
            this.sprite.Draw(spriteBatch, transform, camera);
        }

        public override void Update(GameTime gameTime, Camera camera) {}
    }
}
