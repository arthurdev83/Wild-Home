using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildHome.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace WildHome.Entity
{
    class Player : PhysicalObject
    {

        private SpriteFont _font;
        private KeyboardState _keyboardState;
        private KeyboardState _keyboardStateOld;


        public Player()
        {
            this._initialSpeed = new Vector2(0, 0);
            this._initialAcceleration = new Vector2(0, 0);
            this._speed = this._initialSpeed;
            this._acceleration = this._initialAcceleration;
            this._vitesseMax = 1.5f;
            this._alphaX = 5;
            this._alphaY = 50;
        }

        public override void LoadContent(ContentManager content)
        {
            _font = content.Load<SpriteFont>("maFont");

            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            this._keyboardState = Keyboard.GetState();

            //GAUCHE DROITE
            if (_keyboardState.IsKeyDown(Keys.D))
            {
                this.ApplyForce(Utilities.Direction.Right);
            }
            if (_keyboardState.IsKeyDown(Keys.Q))
            {
                this.ApplyForce(Utilities.Direction.Left);
            }


            //On relache
            if (_keyboardState.IsKeyUp(Keys.Q) && _keyboardStateOld.IsKeyDown(Keys.Q) 
                || _keyboardState.IsKeyUp(Keys.D) && _keyboardStateOld.IsKeyDown(Keys.D))
            {
                this.ResetForce();
            }

            //Gestion du saut
            if (_keyboardState.IsKeyDown(Keys.Space) && _keyboardStateOld.IsKeyDown(Keys.Space) && this.IsOnTheFloor())
            {
                this.ApplyImpulsion(20);
            }

            _keyboardStateOld = _keyboardState;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
