using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    public abstract class Component
    {
        public abstract void Update(float time_since_last_update);

        public abstract void FixedUpdate (float fixed_update_time);

        public abstract GameObject GetParentGameObject();
    }
}
