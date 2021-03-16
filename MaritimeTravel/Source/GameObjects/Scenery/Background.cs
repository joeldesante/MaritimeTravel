using MaritimeTravel.Source.GameComponents;
using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameObjects.Scenery {
    class Background : GameObject {

        private Sprite sprite;
        private Transform transform;

        public int ParalaxDepth { get; set; }

        public Background(Texture2D texture) {
            this.sprite = new Sprite(texture);
            this.sprite.LayerDepth = 0;
            this.transform = new Transform();
            this.sprite.Origin = new Vector2(texture.Width / 2, texture.Height / 2);
            this.transform.Scale = new Vector2(2f);
            ParalaxDepth = 7500;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Camera camera) {
            sprite.Draw(spriteBatch, transform, camera, "Background");
        }

        public override void Update(GameTime gameTime, Camera camera) {
            transform.Position -= (camera.Origin / ParalaxDepth);
        }
    }
}
