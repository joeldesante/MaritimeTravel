using MaritimeTravel.Source.GameObjects;
using MaritimeTravel.Source.GameObjects.TutorialSceneObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.Scene {
    class TutorialScene : Scene {

        private List<GameObject> gameObjects;
        private TutorialText tutorial;

        public TutorialScene(MaritimeTravel game) : base(game) {
            gameObjects = new List<GameObject>();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            tutorial.Draw(spriteBatch, gameTime);
        }

        public override void LoadContent() {
            Texture2D tutTexture = game.Content.Load<Texture2D>("images/tutorial/Tutorial");
            tutorial = new TutorialText(tutTexture);
            tutorial.Drawable.Origin = new Vector2(tutorial.Drawable.Texture.Width / 2, tutorial.Drawable.Texture.Height / 2);
            gameObjects.Add(tutorial);
        }

        public override void UnloadContent() {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime) {
            tutorial.Transform.Position = new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);
        }
    }
}
