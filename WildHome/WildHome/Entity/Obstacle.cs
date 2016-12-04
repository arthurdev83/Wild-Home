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
    class Obstacle : PhysicalObject
    {

        private SpriteFont _font;


        public Obstacle()
        {
            this._initialSpeed = new Vector2(0, 0);
            this._initialAcceleration = new Vector2(0, 0);
            this._speed = this._initialSpeed;
            this._acceleration = this._initialAcceleration;
            this._vitesseMaxX = 1.5f;
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
            
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void SetTexture(String nomTexture, ContentManager content)
        {
            this._texture = content.Load<Texture2D>(nomTexture);
        }
    }
}
