using MaritimeTravel.Source.GameObjects;
using MaritimeTravel.Source.GameObjects.TutorialSceneObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.Scene {
    class TutorialScene : Scene {

        private List<GameObject> gameObjects;
        private Dictionary<string, Texture2D> registeredTextures; 

        public TutorialScene(MaritimeTravel game) : base(game) {
            gameObjects = new List<GameObject>();
            registeredTextures = new Dictionary<string, Texture2D>();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            foreach (GameObject gameObject in gameObjects) {
                gameObject.Draw(spriteBatch, gameTime);
            }
        }

        public override void Initialize() {
        }

        public override void LoadContent() {

            // Load the textures
            registeredTextures.Add("fish", game.Content.Load<Texture2D>("images/fish"));

            // Create the game objects
            gameObjects.Add(new Fish(registeredTextures["fish"]));
        }

        public override void UnloadContent() {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime) {
            foreach (GameObject gameObject in gameObjects) {
                gameObject.Update(gameTime);
            }
        }
    }
}
