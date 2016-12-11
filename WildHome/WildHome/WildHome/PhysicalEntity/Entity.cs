using System;
using Microsoft.Xna.Framework;
using WildHome.Physics;

namespace WildHome.PhysicalEntity
{
    abstract class Entity : PhysicalObject
    {
        public int countObstacle = 0;

        public bool IsIntersecting(Vector2 position, PhysicalObject box2) //Ne marche qu'avec des rectangles AABB
        {
            return (position.X < box2.Position.X + box2.Texture.Width &&
                    position.X + this._texture.Width > box2.Position.X &&
                    position.Y < box2.Position.Y + box2.Texture.Height &&
                    position.Y + this._texture.Height > box2.Position.Y);
        }

        public void UpdateCollision(PhysicalObject obstacle)
        {
            if (this.IsIntersecting(this.Position, obstacle))
            {
                //Console.WriteLine("Touche un obstacle !");
                if ((this.IsIntersecting(new Vector2(this.Position.X, this.PositionOld.Y), obstacle) && //Si le fantome Y n'est pas en collision
                    !this.IsIntersecting(new Vector2(this.PositionOld.X, this.Position.Y), obstacle)))
                {
                    if (this.Position.X > this.PositionOld.X)
                    {

                        this.Position = new Vector2(DeplacementCollisionXRight(obstacle), this.Position.Y);
                        this.Speed = new Vector2(this.InitialSpeed.X, this.Speed.Y);
                    }
                    if (this.Position.X < this.PositionOld.X)
                    {

                        this.Position = new Vector2(DeplacementCollisionXLeft(obstacle), this.Position.Y);
                        this.Speed = new Vector2(this.InitialSpeed.X, this.Speed.Y);
                    }

                }
                else if (!this.IsIntersecting(new Vector2(this.Position.X, this.PositionOld.Y), obstacle) && //Si le fantome X n'est pas en collision
                    this.IsIntersecting(new Vector2(this.PositionOld.X, this.Position.Y), obstacle) ||
                    (!this.IsIntersecting(new Vector2(this.Position.X, this.PositionOld.Y), obstacle) && //Ou si le des deux fantomes ne sont pas en collision
                    !this.IsIntersecting(new Vector2(this.PositionOld.X, this.Position.Y), obstacle)))

                {
                    if (this.Position.Y > this.PositionOld.Y)
                    {

                        this.Position = new Vector2(this.Position.X, DeplacementCollisionYFall(obstacle));
                        this.Speed = new Vector2(this.Speed.X, this.InitialSpeed.Y);
                    }
                    if (this.Position.Y < this.PositionOld.Y)
                    {

                        this.Position = new Vector2(this.Position.X, DeplacementCollisionYUp(obstacle));
                        this.Speed = new Vector2(this.Speed.X, this.InitialSpeed.Y);
                    }

                }

            }
            if (this.IsIntersecting(new Vector2(this.Position.X, this.Position.Y +1), obstacle))
                this._isOnTheGround = true;
            else
            {
                if (countObstacle == World.OBSTACLE_COUNT)
                {
                    this._isOnTheGround = false;
                }
            }
            if (countObstacle == World.OBSTACLE_COUNT)
            {
                countObstacle = 0;
            }
            countObstacle++;
        }

        public int DeplacementCollisionXLeft(PhysicalObject obstacle)
        {
            int movement_X = 0;
            for (int i = (int)this.PositionOld.X; !this.IsIntersecting(new Vector2(i, this.Position.Y), obstacle); i--)
            {
                movement_X = i;
            }
            return movement_X;
        }

        public int DeplacementCollisionXRight(PhysicalObject obstacle)
        {
            int movement_X = 0;
            for (int i = (int)this.PositionOld.X; !this.IsIntersecting(new Vector2(i, this.Position.Y), obstacle); i++)
            {
                movement_X = i;
            }
            return movement_X;
        }


        public int DeplacementCollisionYFall(PhysicalObject obstacle)
        {
            int movement_Y = 0;
            for (int i = (int)this.PositionOld.Y; !this.IsIntersecting(new Vector2(this.Position.X, i), obstacle); i++)
            {
                movement_Y = i;
            }
            return movement_Y;
        }

        public int DeplacementCollisionYUp(PhysicalObject obstacle)
        {
            int movement_Y = 0;
            for (int i = (int)this.PositionOld.Y; !this.IsIntersecting(new Vector2(this.Position.X, i), obstacle); i--)
            {
                movement_Y = i;
            }
            return movement_Y;
        }


    }
}
