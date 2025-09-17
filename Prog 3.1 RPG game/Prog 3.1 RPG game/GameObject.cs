using Prog_3._1_RPG_game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    public class GameObject
    {
        private Component[] _componentTable = new Component[5];

        public GameObject()
        {

        }

        //Ajouter un Component
        public void AddComponent(Component component_to_add)
        {
            for (int component_table_index = 0; component_table_index < _componentTable.Length; component_table_index++)
            {
                if (_componentTable[component_table_index] == null)
                {
                    _componentTable[component_table_index] = component_to_add;
                    break;
                }
            }
        }

        //Récupérer un Component
        public TYPE GetComponent<TYPE>() where TYPE : Component
        {
            TYPE result_component = null;

            for (int component_table_index = 0; component_table_index < _componentTable.Length; component_table_index++)
            {
                if (_componentTable[component_table_index] != null)
                {
                    result_component = _componentTable[component_table_index] as TYPE;

                    if (result_component != null)
                    {
                        break;
                    }
                    //QUESTION: Comment fonctionne le code. Plus précisement, comment le code permet l'extraction du Type spécifié lors de l'appel de la fonction
                }
            }

            return result_component;
        }

        //Transférer l'ordre Update aux Components
        public virtual void Update(float time_since_last_update)
        {
            for(int component_table_index = 0; component_table_index < _componentTable.Length; component_table_index++)
            {
                if (_componentTable[component_table_index] != null)
                {
                    _componentTable[component_table_index].Update(time_since_last_update);
                }
            }
        }
    }
}
