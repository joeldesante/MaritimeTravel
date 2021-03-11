using MaritimeTravel.Source.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MaritimeTravel {
    public class MaritimeTravel : Game {

        

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TitleScene scene;

        public MaritimeTravel() {
            _graphics = new GraphicsDeviceManager(this);
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            scene = new TitleScene(this);
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            scene.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            scene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            /*_spriteBatch.Draw(
                logo,
                new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, _graphics.GraphicsDevice.Viewport.Height / 2),
                null,
                Color.White * (float) (gameTime.TotalGameTime.TotalSeconds / 10),
                0f,
                new Vector2(logo.Width / 2, logo.Height / 2),
                Vector2.One / 3,
                SpriteEffects.None,
                0f
            );*/
            scene.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
