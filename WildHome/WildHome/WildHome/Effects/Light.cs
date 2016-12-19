using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WildHome.Effects
{
    class Light
    {
        public int _diffuse;
        public int _center;
        public Vector2 position;

        public Light(int diffuse, int center, Vector2 position)
        {
            this._diffuse = diffuse;
            this._center = center;
            this.position = position;
        }
    }
}
