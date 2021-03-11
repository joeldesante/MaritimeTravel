using MaritimeTravel.Source.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.Scene {
    class TitleScene : Scene {

        private MaritimeTravel game;
        private List<GameObjects.GameObject> gameObjects;

        private IntroText logo;
        
        public TitleScene(MaritimeTravel game) {
            this.game = game;
            this.gameObjects = new List<GameObjects.GameObject>();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            logo.Draw(spriteBatch, gameTime);
        }

        public override void LoadContent() {
            Texture2D logoTexture = game.Content.Load<Texture2D>("logo");
            logo = new IntroText(logoTexture);
            logo.Transform.Scale = new Vector2(0.3f);
            logo.Drawable.Origin = new Vector2(logo.Drawable.Texture.Width / 2, logo.Drawable.Texture.Height / 2);
            gameObjects.Add(logo);
        }

        public override void UnloadContent() {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime) {
            logo.Transform.Position = new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);
            
            logo.Drawable.ColorMask = Color.White * (float) (gameTime.TotalGameTime.TotalSeconds / 10);
            logo.Transform.Rotate((float) gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
