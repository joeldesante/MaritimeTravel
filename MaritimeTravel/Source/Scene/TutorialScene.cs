using MaritimeTravel.Source.GameObjects;
using MaritimeTravel.Source.GameObjects.Scenery;
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
        private SceneryManager sceneryManager;

        public TutorialScene(MaritimeTravel game) : base(game) {
            gameObjects = new List<GameObject>();
            registeredTextures = new Dictionary<string, Texture2D>();
            camera = new Camera();
            sceneryManager = new SceneryManager();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            camera.CalculateTransformation();

            sceneryManager.Draw(spriteBatch, gameTime, camera);

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
            registeredTextures.Add("floor", game.Content.Load<Texture2D>("images/SeaFloor"));
            registeredTextures.Add("background", game.Content.Load<Texture2D>("images/temp_background"));

            // Create the game objects
            gameObjects.Add(new Fish(registeredTextures["fish"], this.game));

            Bubble b2 = new Bubble(registeredTextures["bubble"]);
            b2.Transform.Position = new Vector2(100, 100);

            gameObjects.Add(new Bubble(registeredTextures["bubble"]));
            gameObjects.Add(b2);

            for (int i = 0; i < 25; i++) {
                Bubble b = new Bubble(registeredTextures["bubble"]);
                Random r = new Random();
                b.Transform.Position = new Vector2(
                    r.Next(-game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Width),
                    r.Next(-game.GraphicsDevice.Viewport.Height, game.GraphicsDevice.Viewport.Height)
                );

                b.Transform.Scale = new Vector2((float) Math.Clamp(r.NextDouble(), 5, 10));

                gameObjects.Add(b);
            }

            gameObjects.Add(new SeaFloor(registeredTextures["floor"]));

            sceneryManager.background = new Background(registeredTextures["background"]);
        }

        public override void UnloadContent() {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime) {
            Vector2 viewportDimensions = new Vector2(this.game.GraphicsDevice.Viewport.Width, this.game.GraphicsDevice.Viewport.Height);
            camera.CalculateGlobalScale(viewportDimensions);
            camera.Offset = -(viewportDimensions / 2);

            sceneryManager.Update(gameTime, camera);

            foreach (GameObject gameObject in gameObjects) {
                gameObject.Update(gameTime, camera);
            }
        }
    }
}
