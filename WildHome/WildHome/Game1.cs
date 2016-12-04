using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace WildHome
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Entity.Player _joueur;
        private Physics.PhysicalObject _obstacle;
        private SpriteFont _font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            this._joueur = new Entity.Player();
            this. _obstacle = new Physics.PhysicalObject();
            this._obstacle.Position = new Vector2(200, 342);

            base.Initialize();
        }
        

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("maFont");

            this._joueur.LoadContent(Content);
            this._obstacle.LoadContent(Content);
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {

            this._joueur.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //GESTION DE COLLISION
            if (this._joueur.IsIntersecting(this._joueur.Position, this._obstacle))
            {
                if (this._joueur.IsIntersecting(new Vector2(this._joueur.Position.X, this._joueur.PositionOld.Y), this._obstacle))
                {
                    
                }





            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(_font, "Position : " + this._joueur.Position.ToString(), new Vector2(10, 20), Color.White);
            spriteBatch.DrawString(_font, "Vitesse : " + this._joueur.Speed.ToString(), new Vector2(10, 35), Color.White);
            spriteBatch.DrawString(_font, "Acceleration : " + this._joueur.Acceleration.ToString(), new Vector2(10, 50), Color.White);
            this._joueur.Draw(spriteBatch);
            this._obstacle.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
