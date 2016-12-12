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
        private bool test = false;

        //LIGHT SYSTEM ENGINE
        Texture2D rect;
        float sc;
        Color[] dataLight;

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
            this._font = Content.Load<SpriteFont>("arial");

            //LIGHT
            rect = new Texture2D(graphics.GraphicsDevice, 800, 480);
            dataLight = new Color[800 * 480];
            for (int i = 0; i < dataLight.Length; ++i)
            {
                dataLight[i] = new Color(0,0,0,0);
            }
            rect.SetData(dataLight);

            //AJOUT DES ENTITY AU WORLD
            this._world.AddPhysicalEntity(this._player);
            this._world.AddObstacle(new Obstacle(0, new Vector2(300, 82)));
            this._world.AddObstacle(new Obstacle(1, new Vector2(0, 420)));
            this._camera = new Camera2D(GraphicsDevice.Viewport, 1280,720, 1f);
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private void UpdateAmbient(int value)
        {
            for (int i = 0; i < dataLight.Length; ++i)
            {
                dataLight[i] = new Color(dataLight[i].R, dataLight[i].G, dataLight[i].B, dataLight[i].A + value);
            }
            rect.SetData(dataLight);
        }

        private void SetPixel(Vector2 pos, Color color)
        {
            dataLight[Convert.ToInt32(pos.X + (800 * pos.Y))] = new Color(color.R, color.G, color.B, color.A);
        }
        private Color GetPixel(Vector2 pos)
        {
            return dataLight[Convert.ToInt32(pos.X + (800 * pos.Y))];
        }


        protected override void Update(GameTime gameTime)
        {

            Matrix inverse = Matrix.Invert(this._camera.GetTransformation());
            Vector2 mousePos = Vector2.Transform(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), inverse);

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                Console.WriteLine("ALPHA : " + GetPixel(new Vector2(Mouse.GetState().X, Mouse.GetState().Y)).A);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !test)
            {
                test = true;
                Vector2 mousePosSave = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                for (int x = 0; x < 800; x++)
                {
                    for (int y = 0; y < 480; y++)
                    {
                        //Console.WriteLine(Convert.ToInt32(Math.Sqrt(((x - mousePosSave.X) * (x - mousePosSave.X)) + ((y - mousePosSave.Y) * (y - mousePosSave.Y)))));
                        if (new Vector2(x, y) != mousePosSave)
                        {
                            int alpha = 255 - 255 / Convert.ToInt32(Math.Sqrt(((x - mousePosSave.X) * (x - mousePosSave.X)) + ((y - mousePosSave.Y) * (y - mousePosSave.Y))));
                            SetPixel(new Vector2(x, y), new Color(0, 0, 0, 255 - ((255 - alpha) + (255- GetPixel(new Vector2(x, y)).A))) );
                        }
                    }
                }
            }

            this._world.Update(gameTime);
            this._camera.Pos = this._player.Position;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Change Ambient
            if (Mouse.GetState().ScrollWheelValue > sc)
            {
                UpdateAmbient(10);
            }
            else if (Mouse.GetState().ScrollWheelValue < sc)
            {
                UpdateAmbient(-10);
            }
            sc = Mouse.GetState().ScrollWheelValue;

            //UPDATE COLOR
            rect.SetData(dataLight);


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null,  this._camera.GetTransformation());
            this._world.Draw(spriteBatch);
            spriteBatch.Draw(rect, this._camera.Pos - new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.White);
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
