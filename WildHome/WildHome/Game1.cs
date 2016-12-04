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
        private Entity.Obstacle _obstacle;
        private Entity.Obstacle _sol;
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
            this._obstacle = new Entity.Obstacle();
            this._sol = new Entity.Obstacle();
            this._obstacle.Position = new Vector2(300, 342);
            this._sol.Position = new Vector2(0, 420);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this._font = Content.Load<SpriteFont>("maFont");
            //this._obstacle.SetTexture("obstacle") = Content.Load<Texture2D>("obstacle");

            //this._obstacle = new Entity.Obstacle(Content.Load <Texture2D> "obstacle"), new Rectangle(440, 310, 150, 98));

            //man = new Entity.Obstacle(Content.Load<Texture2D>("ManImage"), new Rectangle(440, 310, 150, 98));
            //player = new Player(Content.Load<Texture2D>("playerSheet"), new Vector2(40, 420), 50, 44);


            this._joueur.LoadContent(Content);
            this._obstacle.SetTexture("obstacle", Content);
            this._sol.SetTexture("sol", Content);
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

            this._joueur.GestionCollision(_obstacle);
            this._joueur.GestionCollision(_sol);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(_font, "Position : " + this._joueur.Position.ToString(), new Vector2(10, 20), Color.White);
            spriteBatch.DrawString(_font, "Positionold : " + this._joueur.PositionOld.ToString(), new Vector2(10, 35), Color.White);
            spriteBatch.DrawString(_font, "Vitesse : " + this._joueur.Speed.ToString(), new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(_font, "Acceleration : " + this._joueur.Acceleration.ToString(), new Vector2(10, 65), Color.White);
            this._joueur.Draw(spriteBatch);
            this._obstacle.Draw(spriteBatch);
            this._sol.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
