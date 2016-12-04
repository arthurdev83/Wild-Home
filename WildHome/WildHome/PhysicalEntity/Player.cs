using WildHome.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WildHome.PhysicalEntity
{
    class Player : Entity
    {
        private KeyboardState _keyboardState;
        private KeyboardState _keyboardStateOld;

        public Player()
        {
            this._initialSpeed = new Vector2(0, 0);
            this._initialAcceleration = new Vector2(0, 0);
            this._speed = this._initialSpeed;
            this._acceleration = this._initialAcceleration;
            this._vitesseMaxX = 1.5f;
            this._alphaX = 5;
            this._alphaY = 50;
            this._isOnTheGround = false;

            SetTexture(Ressources.PLAYER_TEXTURE);
        }

        public override void Update(GameTime gameTime)
        {
            this._keyboardState = Keyboard.GetState();

            //GAUCHE DROITE
            if (_keyboardState.IsKeyDown(Keys.D))
                this.ApplyForce(Utilities.Direction.Right);
            if (_keyboardState.IsKeyDown(Keys.Q))
                this.ApplyForce(Utilities.Direction.Left);

            //SAUT
                this._acceleration = new Vector2(this._acceleration.X, this.gravity - this._speed.Y / this._alphaY);


            //On relache
            if (_keyboardState.IsKeyUp(Keys.Q) && _keyboardStateOld.IsKeyDown(Keys.Q)
                || _keyboardState.IsKeyUp(Keys.D) && _keyboardStateOld.IsKeyDown(Keys.D))
                this.ResetForceX();

            //Gestion du saut
            if (_keyboardState.IsKeyDown(Keys.Space) && _keyboardStateOld.IsKeyDown(Keys.Space) && this._isOnTheGround)
            {
                this._isOnTheGround = false;
                this.ApplyImpulsion(20);
            }

            //GESTION COLLISION
            this._positionOld = this.Position;

            _keyboardStateOld = _keyboardState;

            base.Update(gameTime);
        }

    }
}
