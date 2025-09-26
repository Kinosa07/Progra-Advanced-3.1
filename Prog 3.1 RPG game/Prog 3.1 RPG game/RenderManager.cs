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
                for (int collection_index = 0; collection_index < _renderComponentsCollection.Length; collection_index++)
                {
                    if (_renderComponentsCollection[collection_index] == null)
                    {
                        _renderComponentsCollection[collection_index] = render_component_to_add;
                    }
                }
            }
        }

        public void Update(float delta_time)
        {
            for (int collection_index = 0; collection_index < _renderComponentsCollection.Length; collection_index++)
            {
                _renderComponentsCollection[collection_index].Update(delta_time);
            }
        }

        public void FixedUpdate(float fixed_time_until_update, float delta_time)
        {
            if (delta_time >= fixed_time_until_update)
            {
                for (int collection_index = 0; collection_index < _renderComponentsCollection.Length; collection_index++)
                {
                    _renderComponentsCollection[collection_index].FixedUpdate(fixed_time_until_update);
                }
            }
        }

        public void Render(MapComponent current_map)
        {
            //Taille a parcourir de render
            int horizontal_position = 0;
            int vertical_position = 0;
            bool is_location_empty = true;
            RenderComponent potential_object = null;

            //Parcourir le "Tableau" vide a remplir d'éléments (Vertical)
            for (int vertical_index_map = 0; vertical_index_map < current_map.GetSizeY(); vertical_index_map++)
            {
                //Parcourir le "tableau" vide à remplir d'éléments 2 (Horizontal)
                for (int horizontal_index_map = 0; horizontal_index_map < current_map.GetSizeX(); horizontal_index_map++)
                {
                    //prendre en compte tout les RenderComponents
                    for (int collection_index = 0; collection_index < _renderComponentsCollection.Length; collection_index++)
                    {
                        if (_renderComponentsCollection[collection_index] != null)
                        {
                            is_location_empty = !(_renderComponentsCollection[collection_index].GetPositionComponent().GetPositionX() == horizontal_position) && (_renderComponentsCollection[collection_index].GetPositionComponent().GetPositionY() == vertical_position);
                            if (!is_location_empty)
                            {
                                Console.WriteLine(_renderComponentsCollection[collection_index].GetAppearance());
                            }
                        }
                    }

                    //vérifier si la position est déja prise
                    if (is_location_empty && horizontal_index_map != current_map.GetSizeX() - 1)
                    {
                        Console.Write(" ");
                    }
                    
                    else if (is_location_empty && horizontal_index_map == current_map.GetSizeX() - 1)
                    {
                        Console.WriteLine(" ");
                    }
                }
            }
        }
    }
}
