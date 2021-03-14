
using MaritimeTravel.Source.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MaritimeTravel {
    public class MaritimeTravel : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Dictionary<string, Scene> registeredScenes;
        private Scene currentScene;

        public MaritimeTravel() {
            _graphics = new GraphicsDeviceManager(this);
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Scenes
            registeredScenes = new Dictionary<string, Scene>();
            registeredScenes.Add("title", new TitleScene(this));
            registeredScenes.Add("tutorial", new TutorialScene(this));

            currentScene = registeredScenes["title"];
        }
        public void ChangeScene(string registeredSceneName) {
            currentScene = registeredScenes[registeredSceneName];
            currentScene.Initialize();
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (Scene scene in registeredScenes.Values) {
                scene.LoadContent();
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            currentScene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            currentScene.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
