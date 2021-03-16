using MaritimeTravel.Source.GameObjects;
using MaritimeTravel.Source.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.Scene {
    class TitleScene : Scene {

        private List<GameObjects.GameObject> gameObjects;

        private IntroText logo;
        private double totalSceneTime;

        private Camera camera;

        public TitleScene(MaritimeTravel game): base(game) {
            this.gameObjects = new List<GameObject>();
            this.camera = new Camera();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            camera.CalculateTransformation();
            logo.Draw(spriteBatch, gameTime, camera);
        }

        public override void Initialize() {}

        public override void LoadContent() {
            Texture2D logoTexture = game.Content.Load<Texture2D>("logo");
            logo = new IntroText(logoTexture);
            logo.Drawable.Origin = new Vector2(logo.Drawable.Texture.Width / 2, logo.Drawable.Texture.Height / 2);
            gameObjects.Add(logo);
        }

        public override void UnloadContent() {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime) {

            // Update the dimensions of the graphic
            int viewportWidth = game.GraphicsDevice.Viewport.Width;
            int viewportHeight = game.GraphicsDevice.Viewport.Height;
            float textureAspectRatio = logo.Drawable.Texture.Width / logo.Drawable.Texture.Height;
            int logoMargin = viewportWidth / 2;
            int calculatedWidth = viewportWidth - logoMargin;

            logo.Drawable.Dimensions = new Vector2(calculatedWidth, calculatedWidth / textureAspectRatio);

            // Center the logo
            logo.Transform.Position = new Vector2(
                viewportWidth / 2, 
                viewportHeight / 2
            );
            
            // Update the transparency
            logo.Drawable.ColorMask = Color.White * (float) (gameTime.TotalGameTime.TotalSeconds / 10);

            totalSceneTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (totalSceneTime >= 2) {
                base.game.ChangeScene("tutorial");
            }
        }
    }
}
