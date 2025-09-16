using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class InventoryComponent
    {
        //Contenu: Argent, objets, ???
        private int _money;
        private string[] _itemTable = new string[0];

        public InventoryComponent(int starting_money, int starting_item_table_size)
        {
            _money = starting_money;
            _itemTable = new string[starting_item_table_size];
        }
        
        //Ajout d'objet dans le tableau
        public void AddItem(string item)
        {
            for (int item_table_index = 0; item_table_index < _itemTable.Length; item_table_index++)
            {
                if (_itemTable[item_table_index] == null)
                {
                    _itemTable[item_table_index] = item;
                    break;
                }
            }

            //Créer augmentation du tableau quand devient trop petit
            int last_table_slot = _itemTable.Length - 1;
            if (_itemTable[last_table_slot] != null)
            {
                string[] temporary_table = new string[_itemTable.Length + 10];
                for (int item_table_index = 0; item_table_index < _itemTable.Length; item_table_index++)
                {
                    temporary_table[item_table_index] = _itemTable[item_table_index];
                }
                _itemTable = temporary_table;
            }
        }
    }
}
