using Prog_3._1_RPG_game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    internal class EventManager
    {
        private Dictionary<Type, List<Action>> _eventTable;

        public EventManager()
        {

        }

        public void RegisterToEvent<EVENT_TYPE>(Action action_linked_to_event) where EVENT_TYPE : GameEvent
        {
            Type type_of_event = typeof(EVENT_TYPE);

            if (!(_eventTable.ContainsKey(type_of_event)))
            {
                _eventTable.Add(type_of_event, new List<Action>());
            }

            _eventTable[type_of_event].Add(action_linked_to_event);
        }

        public void TriggerEvent(GameEvent game_event)
        {
            Type type_of_event = game_event.GetType();

            if(_eventTable.ContainsKey(type_of_event))
            {
                foreach (Action action in _eventTable[type_of_event])
                action();
            }
        }
    }
}
