using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    public class ItemDatabase
    {
        private List<ItemData> _items = new List<ItemData>();
        public bool _hasFoundFile = false;

        public void LoadItemsFromFile(string file_path)
        {
            string[] all_lines = File.ReadAllLines(file_path);

            for (int line_index = 0; line_index < all_lines.Length; line_index++)
            {
                string line = all_lines[line_index];
                string[] values = line.Split(',');

                if (values.Length == 4)
                {
                    ItemData item_data = new ItemData();
                    item_data._id = values[0];
                    item_data._name = values[1];
                    item_data._description = values[2];
                    int.TryParse(values[3], out item_data._value);

                    _items.Add(item_data);
                }
            }
            _hasFoundFile = true;
        }

        public ItemData GetItemById(string searched_id)
        {
            ItemData selected_item = null;

            for (int item_retriever_index = 0; item_retriever_index < _items.Count; item_retriever_index++)
            {
                ItemData item = _items[item_retriever_index];

                if (item._id == searched_id)
                {
                    selected_item = item;
                }
            }

            return selected_item;
        }
    }
}
