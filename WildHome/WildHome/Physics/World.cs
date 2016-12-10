using System.Collections.Generic;
using WildHome.PhysicalEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WildHome.Physics
{
    class World
    {
        public static int OBSTACLE_COUNT;

        //VARIABLE
        private List<Entity> physicalEntities;
        private List<Obstacle> obstacles;

        //CONSTRUCTOR
        public World()
        {
            this.physicalEntities = new List<Entity>();
            this.obstacles = new List<Obstacle>();
        }

        //UPDATE
        public void Update(GameTime gameTime)
        {
            //Appel des méthode Update des objets
            foreach (Entity entity in physicalEntities)
            {
                entity.Update(gameTime); //Update
            }
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Update(gameTime);
            }

            //Gestion des colisions
            foreach (Entity entity in physicalEntities)
            {
                foreach (Obstacle obstacle in obstacles)
                {
                    entity.UpdateCollision(obstacle);
                }
            }
        }

        //DRAW
        public void Draw(SpriteBatch spriteBatch)
        {
            //Appel des méthode Draw des objets
            foreach (Entity entity in physicalEntities)
            {
                spriteBatch.Draw(entity.Texture, entity.Position, Color.White);
            }

            foreach (Obstacle obstacle in obstacles)
            {
                spriteBatch.Draw(obstacle.Texture, obstacle.Position, Color.White);
            }
        }

        //Add Physical Object to World
        public void AddPhysicalEntity(Entity physicalObject)
        {
            this.physicalEntities.Add(physicalObject);
        }

        //Add Obstacle
        public void AddObstacle(Obstacle obstacle)
        {
            this.obstacles.Add(obstacle);
            World.OBSTACLE_COUNT = obstacles.Count;
        }
    }
}
