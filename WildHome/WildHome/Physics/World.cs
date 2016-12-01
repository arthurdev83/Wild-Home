using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildHome.Physics
{
    class World
    {
        //VARIABLE
        private float _gravity;

        private List<PhysicalObject> physicalObjects;

        //PROPERTY
        public float Gravity
        {
            get { return this._gravity; }
            set { this._gravity = value; }
        }

        //CONSTRUCTOR
        public World(float gravity = 9.8f)
        {
            this.physicalObjects = new List<PhysicalObject>();
            this._gravity = gravity;
        }

        //Add Physical Object to World
        public void AddPhysicalObject(PhysicalObject physicalObject)
        {
            this.physicalObjects.Add(physicalObject);
        }
    }
}
