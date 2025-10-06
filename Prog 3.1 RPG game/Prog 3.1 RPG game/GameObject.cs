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

        public GameObject(GameObject objcet_to_copy)
        {
            _componentTable = objcet_to_copy._componentTable;
        }

        //Ajouter un Component
        public void AddComponent(Component component_to_add)
        {
            bool is_table_full = true;
            int free_table_slot = -1;
            for (int component_table_index = 0; component_table_index < _componentTable.Length; component_table_index++)
            {
                if (_componentTable[component_table_index] == null)
                {
                    is_table_full = false;
                    free_table_slot = component_table_index;
                    break;
                }
            }
            if (is_table_full)
            { 
                Component[] temporary_table = new Component[_componentTable.Length + 5];
                for (int item_table_index = 0; item_table_index < _componentTable.Length; item_table_index++)
                {
                    temporary_table[item_table_index] = _componentTable[item_table_index];
                }
                _componentTable = temporary_table;
                is_table_full = false;
            }
            if (!is_table_full)
            {
                _componentTable[free_table_slot] = component_to_add;
            }
        }

        //Récupérer un Component
        //Le morceau de code "<TYPE>" demande un TYPE (int, string, etc...). "Where TYPE : Component" s'assure que la fonction cherche un Component
        public TYPE GetComponent<TYPE>() where TYPE : Component
        {
            TYPE result_component = null;

            for (int component_table_index = 0; component_table_index < _componentTable.Length; component_table_index++)
            {
                if (_componentTable[component_table_index] != null)
                {
                    //Cette ligne s'assure que le type du component trouvé correspond à celui utilisé pour appeler la fonction
                    //Cad: GetComponent<PositionComponent> donnera result_component = _componentTable[component_table_index] as PositionComponent
                    //Pas d'extraction accidentelle d'un autre component présent dans l'objet
                    result_component = _componentTable[component_table_index] as TYPE;

                    if (result_component != null)
                    {
                        break;
                    }
                }
            }

            return result_component;
        }

        //Transférer l'ordre Update aux Components
        public virtual void Update(float time_since_last_update)
        {
            for (int component_table_index = 0; component_table_index < _componentTable.Length; component_table_index++)
            {
                if (_componentTable[component_table_index] != null)
                {
                    _componentTable[component_table_index].Update(time_since_last_update);
                }
            }
        }

        //Transférer l'ordre FixedUpdate aux Components
        public virtual void FixedUpdate(float fixed_update_time, float time_since_last_update)
        {
            for (int component_table_index = 0; component_table_index < _componentTable.Length; component_table_index++)
            {
                if (_componentTable[component_table_index] != null)
                {
                    _componentTable[component_table_index].FixedUpdate(fixed_update_time);
                }
            }
        }
    }
}
