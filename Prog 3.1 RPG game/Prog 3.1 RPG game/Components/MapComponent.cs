using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class MapComponent : Component
    {
        GameObject[] _mapContentsTable = new GameObject[4];
        //créer des bordures de map
        private int _mapSizeX;
        private int _mapSizeY;

        public MapComponent(int map_size_x, int map_size_y)
        {
            _mapSizeX = map_size_x;
            _mapSizeY = map_size_y;

        }

        public override void Update(float time_since_last_update)
        {

        }

        public override void FixedUpdate(float fixed_update_time)
        {

        }

        public GameObject[] GetAllObjectsInside()
        {
            return _mapContentsTable;
        }
    }
}
