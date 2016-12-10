using System;
using Microsoft.Xna.Framework.Graphics;

namespace WildHome
{
    class Sprite
    {
        //VARIABLE
        protected Texture2D _texture;

        //CONSTRUCTEUR
        public Sprite() { }
        public Sprite(Texture2D texture)
        {
            this._texture = texture;
        }

        //GETTER & SETTER

        public Texture2D Texture
        {
            get { return this._texture; }
            set { this._texture = value; }
        }

        public void SetTexture(String nomTexture)
        {
            this._texture = Ressources.CONTENT.Load<Texture2D>(nomTexture);
        }

    }
}
