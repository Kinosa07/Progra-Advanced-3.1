using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    public class DoorwayComponent : Component
    {
        private GameObject _parentGameObject;
        private GameObject _destination;

        public DoorwayComponent(GameObject parent_object, GameObject destination_object)
        {
            _parentGameObject = parent_object;
            _destination = destination_object;

            _parentGameObject.AddComponent(this);
        }

        public override void Update(float deltaTime)
        {

        }

        public override void FixedUpdate(float fixed_update_time)
        {

        }

        public override GameObject GetCopyOfParentGameObject()
        {
            GameObject copy_of_parent = new GameObject(_parentGameObject);
            return copy_of_parent;
        }

        public GameObject GetDestination()
        {
            GameObject copy_of_desination = new GameObject(_destination);
            return copy_of_desination;
        }
    }
}
