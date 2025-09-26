using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    internal class RenderManager
    {
        private RenderComponent[] _renderComponentsCollection = new RenderComponent[3];

        public RenderManager()
        {

        }

        public void AddRenderComponent(RenderComponent render_component_to_add)
        {
            //Is table Full
            bool is_table_full = true;
            for (int collection_index = 0; collection_index < _renderComponentsCollection.Length; collection_index++)
            {
                if (_renderComponentsCollection[collection_index] == null)
                {
                    is_table_full = false;
                    break;
                }
            }

            if (is_table_full == true)
            {
                //magic to expand Table
                RenderComponent[] temporary_table = new RenderComponent[_renderComponentsCollection.Length + 3];
                for (int collection_index = 0; collection_index < _renderComponentsCollection.Length; collection_index++)
                {
                    temporary_table[collection_index] = _renderComponentsCollection[collection_index];
                }
                _renderComponentsCollection = temporary_table;
                is_table_full = false;
            }

            if (is_table_full == false)
            {
                //NOT FINISHED
                for (int collection_index = 0; collection_index < _renderComponentsCollection.Length; collection_index++)
                {
                    if (_renderComponentsCollection[collection_index] == null)
                    {
                        _renderComponentsCollection[collection_index] = render_component_to_add;
                    }
                }
            }
        }
    }
}
