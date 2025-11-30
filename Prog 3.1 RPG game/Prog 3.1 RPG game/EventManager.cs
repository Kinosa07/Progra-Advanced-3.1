using Prog_3._1_RPG_game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game
{
    public class EventManager
    {
        //Type comme Key pour permettre une simplicité de traversée grâce a des composants généric  
        //List comme Value pour permettre à un event d'activer plusieurs actions (Ex: Tirer 1.envoie un balle & 2.réduit le nombre de balles dans un chargeur
        //Action<GameEvent> pour s'assurer de pouvoir récupérer des infos transmises pas l'Event si nécessaire
        private Dictionary<Type, List<Action<GameEvent>>> _eventTable;

        public EventManager()
        {
            _eventTable = new Dictionary<Type, List<Action<GameEvent>>>();
        }

        public void RegisterToEvent<EVENT_TYPE>(Action<GameEvent> action_linked_to_event) where EVENT_TYPE : GameEvent
        {
            Type type_of_event = typeof(EVENT_TYPE);

            if (!(_eventTable.ContainsKey(type_of_event)))
            {
                _eventTable.Add(type_of_event, new List<Action<GameEvent>>());
            }

            _eventTable[type_of_event].Add(action_linked_to_event);
        }

        public void UnRegisterEvent<EVENT_TYPE>(Action<GameEvent> action_to_remove) where EVENT_TYPE : GameEvent
        {
            Type type_of_event = typeof(EVENT_TYPE);

            _eventTable[type_of_event].Remove(action_to_remove);
        }

        public void TriggerEvent(GameEvent game_event)
        {
            Type type_of_event = game_event.GetType();

            if (_eventTable.ContainsKey(type_of_event))
            {
                foreach (Action<GameEvent> action in _eventTable[type_of_event])
                    action(game_event);
            }
        }

        public Dictionary<Type,List<Action<GameEvent>>>GetCopyEventTable()
        {
            //UTILISE UNIQUEMENT POUR LES TESTS
            Dictionary<Type, List<Action<GameEvent>>> copy_of_event_table = _eventTable;

            return copy_of_event_table;
        }
    }
}
