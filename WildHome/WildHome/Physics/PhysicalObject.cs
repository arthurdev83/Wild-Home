﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WildHome.Physics
{
    class PhysicalObject
    {
        //VARIABLE
        protected float _mass;
        protected float _angle;

        protected Vector2 _position;
        protected Vector2 _speed;
        protected Vector2 _acceleration;

        private World _world;

        //CONSTRUCTOR
        public PhysicalObject(float mass)
        {
            this._mass = mass;
            this._angle = 0;

            this._position = Vector2.Zero;
            this._speed = Vector2.Zero;
            this._acceleration = Vector2.Zero;
        }

    }
}