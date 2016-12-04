using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace WildHome.Physics
{
    class PhysicalObject
    {
        //VARIABLES

        protected Texture2D _texture;

        protected float _mass;
        protected float _angle;
        protected float _vitesseMaxX; // Vitesse max sur X(a multiplier par alphaX pour obtenir la vitesse en pixel/tics)
        protected float _alphaX; // FACTEUR D'ACCELERATION
        protected float _alphaY;

        protected Vector2 _position;
        protected Vector2 _positionOld;
        protected Vector2 _speed;
        protected Vector2 _acceleration;
        protected Vector2 _initialPosition;
        protected Vector2 _initialSpeed;
        protected Vector2 _initialAcceleration;

        protected float gravity;
        private World _world;

        //PROPERTIES
        public Vector2 Position
        {
            get { return _position; }
            set { this._position = value; }
        }
        public Vector2 PositionOld
        {
            get { return _positionOld; }
            set { this._positionOld = value; }
        }
        public Vector2 Speed
        {
            get { return _speed; }
            set { this._speed = value; }
        }
        public Vector2 Acceleration
        {
            get { return _acceleration; }
            set { this._acceleration = value; }
        }
        public Vector2 InitialPosition
        {
            get { return _initialPosition; }
            set { this._initialPosition = value; }
        }
        public Vector2 InitialSpeed
        {
            get { return _initialSpeed; }
            set { this._initialSpeed = value; }
        }
        public Vector2 InitialAcceleration
        {
            get { return _initialAcceleration; }
            set { this._initialAcceleration = value; }
        }
        public float VitesseMax
        {
            get { return this._vitesseMaxX; }
            set { this._vitesseMaxX = value; }
        }
        public float Alpha
        {
            get { return this._alphaX; }
            set { this._alphaX = value; }
        }


        //CONSTRUCTOR
        public PhysicalObject()
        {
            this._mass = 0;
            this._angle = 0;
            this.gravity = 1.45f;

            this._position = Vector2.Zero;
            this._speed = Vector2.Zero;
            this._acceleration = Vector2.Zero;
        }


        //METHODE
        public virtual void LoadContent(ContentManager content)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            //Mise a jour de la position & vitesse
            this._speed += this._acceleration;
            this._position += this._speed;

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, this._position, Color.White);
        }
        

        //Appliquer une impulsion verticale
        public void ApplyImpulsion(int strength)
        {
            this._speed = new Vector2(this._speed.X, -strength);
        }

        //Appliquer une force directionnelle horizontale
        public void ApplyForce(Utilities.Direction dir)
        {
            this._acceleration = new Vector2(((dir == 0 ? -1 : 1) * this._vitesseMaxX) - this._speed.X / this._alphaX, this._acceleration.Y);
        }

        public void ResetForceX()
        {
            this._speed = new Vector2(this._initialSpeed.X, this._speed.Y);
            this._acceleration = new Vector2(this._initialAcceleration.X, this._acceleration.Y);
        }

        public bool IsIntersecting(Vector2 position, Physics.PhysicalObject box2) //Ne marche qu'avec des rectangles AABB
        {
            return (position.X < box2.Position.X + box2._texture.Width &&
                    position.X + this._texture.Width > box2.Position.X &&
                    position.Y < box2.Position.Y + box2._texture.Height &&
                    position.Y + this._texture.Height > box2.Position.Y);
        }

        
    }
}
