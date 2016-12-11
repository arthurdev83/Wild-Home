using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WildHome.PhysicalEntity;
using WildHome.Physics;
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

        private World _world;
        private Camera2D _camera;
        private SpriteFont _font;

        private Player _player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            //this.TargetElapsedTime = TimeSpan.FromMilliseconds(500);
            //this.IsFixedTimeStep = true;
            //graphics.SynchronizeWithVerticalRetrace = false;
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
            this._font = Content.Load<SpriteFont>("arial");

            //AJOUT DES ENTITY AU WORLD
            this._world.AddPhysicalEntity(this._player);
            this._world.AddObstacle(new Obstacle(0, new Vector2(300, 82)));
            this._world.AddObstacle(new Obstacle(1, new Vector2(0, 420)));
            this._camera = new Camera2D();
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {

            this._world.Update(gameTime);
            this._camera.Pos = this._player.Position;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null,  this._camera.get_transformation(GraphicsDevice));
            this._world.Draw(spriteBatch);

            spriteBatch.DrawString(_font, "Position : " + this._player.Position.ToString(), new Vector2(10, 20), Color.White);
            spriteBatch.DrawString(_font, "Positionold : " + this._player.PositionOld.ToString(), new Vector2(10, 35), Color.White);
            spriteBatch.DrawString(_font, "Vitesse : " + this._player.Speed.ToString(), new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(_font, "Acceleration : " + this._player.Acceleration.ToString(), new Vector2(10, 65), Color.White);
            spriteBatch.DrawString(_font, "isOnTheGround : " + this._player._isOnTheGround.ToString(), new Vector2(10, 80), Color.White);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
