﻿using System;
using Microsoft.Xna.Framework;
using WildHome.Physics;

namespace WildHome.PhysicalEntity
{
    abstract class Entity : PhysicalObject
    {
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
                        for (int i = 1; !this.IsIntersecting(new Vector2(this.PositionOld.X + i, this.PositionOld.Y), obstacle); i++)
                        {
                            Console.WriteLine(i);
                            this.PositionOld = new Vector2(this.PositionOld.X + i, this.PositionOld.Y);
                        }
                        this.Position = new Vector2(this.PositionOld.X, this.Position.Y);
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

                        this.Position = new Vector2(this.Position.X, DeplacementCollisionY(obstacle));
                        this.Speed = new Vector2(this.Speed.X, this.InitialSpeed.Y);
                    }
                    //if (this.Position.Y + this._texture.Height < obstacle.Position.Y+1)
                    //{
                    //    this._isOnTheGround = true;
                    //}
                }

            }
            if (this.IsIntersecting(new Vector2(this.Position.X, this.Position.Y + 1), obstacle))
            {
                this._isOnTheGround = true;
                Console.WriteLine("coucou");
            }
            else
            {
                this._isOnTheGround = false;
            }
        }

        public int DeplacementCollisionY(PhysicalObject obstacle)
        {
            int movement_Y = 0;
            for (int i = (int)this.PositionOld.Y; !this.IsIntersecting(new Vector2(this.Position.X, i), obstacle); i++)
            {
                movement_Y = i;
                Console.WriteLine(movement_Y);
            }
            return movement_Y;
        }
    }
}
