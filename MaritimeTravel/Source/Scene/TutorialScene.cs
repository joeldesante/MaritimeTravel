using MaritimeTravel.Source.GameObjects;
using MaritimeTravel.Source.GameObjects.TutorialSceneObjects;
using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MaritimeTravel.Source.Scene {
    class TutorialScene : Scene {

        private List<GameObject> gameObjects;
        private Dictionary<string, Texture2D> registeredTextures;
        private Camera camera;

        public TutorialScene(MaritimeTravel game) : base(game) {
            gameObjects = new List<GameObject>();
            registeredTextures = new Dictionary<string, Texture2D>();
            camera = new Camera();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            foreach (GameObject gameObject in gameObjects) {
                gameObject.Draw(spriteBatch, gameTime, camera);
            }
        }

        public override void Initialize() {
        }

        public override void LoadContent() {

            // Load the textures
            registeredTextures.Add("fish", game.Content.Load<Texture2D>("images/fish"));
            registeredTextures.Add("bubble", game.Content.Load<Texture2D>("images/tutorial/Bubble"));

            // Create the game objects
            gameObjects.Add(new Fish(registeredTextures["fish"], this.game));
            gameObjects.Add(new Bubble(registeredTextures["bubble"]));
        }

        public override void UnloadContent() {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime) {
            foreach (GameObject gameObject in gameObjects) {
                gameObject.Update(gameTime, camera);
            }
        }
    }
}
