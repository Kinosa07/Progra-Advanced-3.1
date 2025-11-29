using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    public class ItemComponent : Component
    {
        private GameObject _parentObject;
        ItemData _data;

        public override void Update(float time_since_last_update)
        {

        }

        public override void FixedUpdate(float fixed_update_time)
        {

        }

        public override GameObject GetCopyOfParentGameObject()
        {
            return _parentObject;
        }

        public void Describe()
        {
            Console.Write($" {_data._name} \n {_data._description} \n Value: {_data._value} \n");
        }
    }
}
