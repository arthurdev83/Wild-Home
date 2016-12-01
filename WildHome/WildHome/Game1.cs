using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WildHome
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private KeyboardState _keyboardState;
        private KeyboardState _keyboardStateOld;
        private Physics.PhysicalObject _joueur;
        private SpriteFont _font;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _joueur = new Physics.PhysicalObject(10);
            this._joueur.InitialSpeed = new Vector2(0, 0);
            this._joueur.InitialAcceleration = new Vector2(0, 0);
            this._joueur.Speed = this._joueur.InitialSpeed;
            this._joueur.Acceleration = this._joueur.InitialAcceleration;
            this._joueur.VitesseMax = 1.5f;
            this._joueur.Alpha = 5;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("maFont");
            this._joueur.LoadContent(Content);



            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (_keyboardState.IsKeyDown(Keys.D))
            {

                this._joueur.Acceleration = new Vector2(this._joueur.VitesseMax - this._joueur.Speed.X / this._joueur.Alpha, this._joueur.Acceleration.Y);
                this._joueur.Speed += this._joueur.Acceleration;
                this._joueur.Position += this._joueur.Speed;
            }
            if (_keyboardState.IsKeyUp(Keys.D) && _keyboardStateOld.IsKeyDown(Keys.D))
            {
                this._joueur.Speed = this._joueur.InitialSpeed;
                this._joueur.Acceleration = this._joueur.InitialAcceleration;
            }

            if (_keyboardState.IsKeyDown(Keys.Q))
            {

                this._joueur.Acceleration = new Vector2(-this._joueur.VitesseMax - this._joueur.Speed.X / this._joueur.Alpha, this._joueur.Acceleration.Y);
                this._joueur.Speed += this._joueur.Acceleration;
                this._joueur.Position += this._joueur.Speed;
            }
            if (_keyboardState.IsKeyUp(Keys.Q) && _keyboardStateOld.IsKeyDown(Keys.Q))
            {
                this._joueur.Speed = this._joueur.InitialSpeed;
                this._joueur.Acceleration = this._joueur.InitialAcceleration;
            }

            if (_keyboardState.IsKeyDown(Keys.S))
            {

                this._joueur.Acceleration = new Vector2(this._joueur.Acceleration.X, this._joueur.VitesseMax - this._joueur.Speed.Y / this._joueur.Alpha);
                this._joueur.Speed += this._joueur.Acceleration;
                this._joueur.Position += this._joueur.Speed;
            }
            if (_keyboardState.IsKeyUp(Keys.S) && _keyboardStateOld.IsKeyDown(Keys.S))
            {
                this._joueur.Speed = this._joueur.InitialSpeed;
                this._joueur.Acceleration = this._joueur.InitialAcceleration;
            }

            if (_keyboardState.IsKeyDown(Keys.Z))
            {

                this._joueur.Acceleration = new Vector2(this._joueur.Acceleration.X, -this._joueur.VitesseMax - this._joueur.Speed.Y / this._joueur.Alpha);
                this._joueur.Speed += this._joueur.Acceleration;
                this._joueur.Position += this._joueur.Speed;
            }
            if (_keyboardState.IsKeyUp(Keys.Z) && _keyboardStateOld.IsKeyDown(Keys.Z))
            {
                this._joueur.Speed = this._joueur.InitialSpeed;
                this._joueur.Acceleration = this._joueur.InitialAcceleration;
            }




            _keyboardStateOld = _keyboardState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            spriteBatch.DrawString(_font, "Position : " + this._joueur.Position.ToString(), new Vector2(10, 20), Color.White);
            spriteBatch.DrawString(_font, "Vitesse : " + this._joueur.Speed.ToString(), new Vector2(10, 35), Color.White);
            spriteBatch.DrawString(_font, "Acceleration : " + this._joueur.Acceleration.ToString(), new Vector2(10, 50), Color.White);
            this._joueur.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
