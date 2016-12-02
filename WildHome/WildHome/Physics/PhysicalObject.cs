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

        private Texture2D _texture;

        protected float _mass;
        protected float _angle;
        protected float _vitesseMax; // Vitesse max (a multiplier par alpha pour obtenir la vitesse en pixel/tics)
        protected float _alphaX; // FACTEUR D'ACCELERATION
        protected float _alphaY;

        protected Vector2 _position;
        protected Vector2 _speed;
        protected Vector2 _acceleration;
        protected Vector2 _initialPosition;
        protected Vector2 _initialSpeed;
        protected Vector2 _initialAcceleration;

        protected float gravity;

        private World _world;

        //PROPERTYS
        public Vector2 Position
        {
            get { return _position; }
            set { this._position = value; }
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
            get { return this._vitesseMax; }
            set { this._vitesseMax = value; }
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
            this._texture = content.Load<Texture2D>("player");
        }

        public virtual void Update(GameTime gameTime)
        {
            //Mise a jour de la position & vitesse
            this._speed += this._acceleration;
            this._position += this._speed;

            ///SAUT UPDATE
            if (!this.IsOnTheFloor())
            {
                
                this._acceleration = new Vector2(this._acceleration.X, this.gravity - this._speed.Y / this._alphaY);
            }
            else
            {
                this._acceleration = new Vector2(this._acceleration.X, this._initialAcceleration.Y);
                this._speed = new Vector2(this._speed.X, this._initialSpeed.Y);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, this._position, Color.White);
        }

        //Tester si on est au sol
        public bool IsOnTheFloor()
        {
            return (this.Position.Y > 400);
        }

        //Appliquer une impulsion
        public void ApplyImpulsion(int strength)
        {
            this._speed = new Vector2(this._speed.X, -strength);
        }

        //Appliquer une force directionnelle
        public void ApplyForce(Utilities.Direction dir)
        {
            this._acceleration = new Vector2(((dir == 0 ? -1 : 1 )*this._vitesseMax) - this._speed.X / this._alphaX, this._acceleration.Y);
        }

        public void ResetForce()
        {
            this._speed = new Vector2(this._initialSpeed.X, this._speed.Y);
            this._acceleration = new Vector2(this._initialAcceleration.X, this._acceleration.Y);
        }

    }
}
