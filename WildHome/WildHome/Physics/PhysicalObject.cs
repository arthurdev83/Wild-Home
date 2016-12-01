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
        //VARIABLE

        private Texture2D _texture;


        protected float _mass;
        protected float _angle;

        protected Vector2 _position;
        protected Vector2 _speed;
        protected Vector2 _acceleration;

        private World _world;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }



        //CONSTRUCTOR
        public PhysicalObject(float mass)
        {
            this._mass = mass;
            this._angle = 0;

            this._position = Vector2.Zero;
            this._speed = Vector2.Zero;
            this._acceleration = Vector2.Zero;
        }

        public void LoadContent(ContentManager content)
        {
            this._texture = content.Load<Texture2D>("player");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, this._position, Color.White);
        }

    }
}
