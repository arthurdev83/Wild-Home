using Microsoft.Xna.Framework;

namespace WildHome.Physics
{
    class Obstacle : PhysicalObject
    {

        public Obstacle(int textureId, Vector2 position = default(Vector2))
        {
            this._initialSpeed = new Vector2(0, 0);
            this._initialAcceleration = new Vector2(0, 0);
            this._speed = this._initialSpeed;
            this._acceleration = this._initialAcceleration;
            this._vitesseMaxX = 1.5f;
            this._alphaX = 5;
            this._alphaY = 50;

            this._position = position;
            this.SetTexture(Ressources.OBSTACLES_TEXTURE[textureId]);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
