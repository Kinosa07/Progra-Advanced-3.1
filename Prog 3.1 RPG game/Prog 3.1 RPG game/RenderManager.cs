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

        public void Reset()
        {
            _renderComponentsCollection = new RenderComponent[3];
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
                    _renderComponentsCollection[collection_index].FixedUpdate(fixed_time_until_update, delta_time);
                }
            }
        }

        public void Render(MapComponent current_map)
        {
            Console.Clear();

            //Taille a parcourir de render
            int horizontal_position = 0;
            int vertical_position = 0;
            bool is_location_empty = true;
            bool can_object_be_rendered = false;

            //Parcourir le "Tableau" vide a remplir d'éléments (Vertical)
            for (int vertical_index_map = 0; vertical_index_map < current_map.GetSizeY(); vertical_index_map++)
            {
                //Parcourir le "tableau" vide à remplir d'éléments 2 (Horizontal)
                for (int horizontal_index_map = 0; horizontal_index_map < current_map.GetSizeX(); horizontal_index_map++)
                {
                    //prendre en compte tout les RenderComponents
                    for (int collection_index = 0; collection_index < _renderComponentsCollection.Length; collection_index++)
                    {
                        //Are you from a MapComponent
                        if ( (_renderComponentsCollection[collection_index] != null) && (_renderComponentsCollection[collection_index].GetCopyOfParentGameObject().GetComponent<MapComponent>() != null) )
                        {
                            MapComponent object_map_component = _renderComponentsCollection[collection_index].GetCopyOfParentGameObject().GetComponent<MapComponent>();
                            if (object_map_component == current_map)
                            {
                                can_object_be_rendered = true;
                            }
                            else
                            {
                                can_object_be_rendered = false;
                            }
                        }
                        //Are you NOT from a MapComponent
                        if ( (_renderComponentsCollection[collection_index] != null) && (_renderComponentsCollection[collection_index].GetCopyOfParentGameObject().GetComponent<MapComponent>() == null) )
                        {
                            can_object_be_rendered = true;
                        }

                        if (can_object_be_rendered)
                        {
                            is_location_empty = !((_renderComponentsCollection[collection_index].GetPositionComponent().GetPositionX() == horizontal_index_map) && (_renderComponentsCollection[collection_index].GetPositionComponent().GetPositionY() == vertical_index_map));
                            if (!is_location_empty && (horizontal_index_map != current_map.GetSizeX() - 1))
                            {
                                Console.Write(_renderComponentsCollection[collection_index].GetAppearance());
                                break;
                            }

                            else if (!is_location_empty && (horizontal_index_map == current_map.GetSizeX() - 1))
                            {
                                Console.WriteLine(_renderComponentsCollection[collection_index].GetAppearance());
                                break;
                            }
                        }
                    }

                    //vérifier si la position est à la limite
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
