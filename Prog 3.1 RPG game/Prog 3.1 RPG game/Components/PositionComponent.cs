using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class PositionComponent : Component
    {
        private int _xPos;
        private int _yPos;

        public PositionComponent()
        {

        }

        //Fonction Update
        public override void Update(float time_since_last_update)
        {

        }

        //Fonction FixedUpdate
        public override void FixedUpdate(float fixed_update_time)
        {

        }

        public int[] GetPosition()
        {
            int[] position_table = new int[2];
            position_table[0] = _xPos;
            position_table[1] = _yPos;

            return position_table;
        }
    }
}
