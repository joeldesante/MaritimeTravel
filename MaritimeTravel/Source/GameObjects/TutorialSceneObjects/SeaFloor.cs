using MaritimeTravel.Source.GameComponents;
using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameObjects.TutorialSceneObjects {
    class SeaFloor : GameObject {

        private Sprite sprite;
        private Transform transform;

        public SeaFloor(Texture2D texture) {
            transform = new Transform(new Vector2(texture.Width, texture.Height));
            sprite = new Sprite(texture);

            transform.Position = new Vector2(-1400, 700);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Camera camera) {
            sprite.Draw(spriteBatch, transform, camera, "Sea Floor");
        }

        public override void Update(GameTime gameTime, Camera camera) {
            
        }
    }
}
