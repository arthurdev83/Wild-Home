using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WildHome.PhysicalEntity;
using WildHome.Physics;

namespace WildHome
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private World _world;
        private SpriteFont _font;

        private Player _player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            Ressources.Initialize();
            Ressources.CONTENT = Content;

            this.IsMouseVisible = true;

            this._world = new World();
            this._player = new Player();
            base.Initialize();
        }


        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this._font = Content.Load<SpriteFont>("maFont");

            //AJOUT DES ENTITY AU WORLD
            this._world.AddPhysicalEntity(this._player);
            this._world.AddObstacle(new Obstacle(0, new Vector2(300, 342)));
            this._world.AddObstacle(new Obstacle(1, new Vector2(0, 420)));
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {

            this._world.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            this._world.Draw(spriteBatch);

            
            spriteBatch.DrawString(_font, "Position : " + this._player.Position.ToString(), new Vector2(10, 20), Color.White);
            spriteBatch.DrawString(_font, "Positionold : " + this._player.PositionOld.ToString(), new Vector2(10, 35), Color.White);
            spriteBatch.DrawString(_font, "Vitesse : " + this._player.Speed.ToString(), new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(_font, "Acceleration : " + this._player.Acceleration.ToString(), new Vector2(10, 65), Color.White);
            


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
