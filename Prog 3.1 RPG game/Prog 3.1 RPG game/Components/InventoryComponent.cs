using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Components
{
    internal class InventoryComponent
    {
        //Contenu: Argent, bazar, ???
        private int _money;
        private string[] _itemTable = new string[0];

        public InventoryComponent(int starting_money, int starting_item_table_size)
        {
            _money = starting_money;
            _itemTable = new string[starting_item_table_size];
        }

        //Ajout d'objet dans le tableau
        //Créer augmentation du tableau quand devient trop petit
    }
}
