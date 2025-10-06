using Prog_3._1_RPG_game.Events;
using System.Threading.Tasks.Sources;

namespace Prog_3._1_RPG_game.Components
{
    internal class MovementComponent : Component
    {
        private PositionComponent _positionComponent;
        private GameObject _parentGameObject;
        private bool _hasMovedlast;
        private EventManager _eventManager;

        public MovementComponent(PositionComponent position_component, GameObject parent, EventManager event_manager)
        {
            _positionComponent = position_component;
            _parentGameObject = parent;
            _hasMovedlast = false;
            _eventManager = event_manager;

            _eventManager.RegisterToEvent<KeyPressedEvent>(EventManagerAction);
        }

        public MovementComponent(MovementComponent movement_component_to_copy)
        {
            _positionComponent = movement_component_to_copy._positionComponent;
            _parentGameObject = movement_component_to_copy._parentGameObject;
            _hasMovedlast = movement_component_to_copy._hasMovedlast;
            _eventManager = movement_component_to_copy._eventManager;
        }

        //Fonction Update
        public override void Update(float time_since_last_update)
        {

        }

        //Fonction FixedUpdate
        public override void FixedUpdate(float fixed_update_time, float time_since_last_update)
        {
            _hasMovedlast = false;
        }
        public override GameObject GetCopyOfParentGameObject()
        {
            GameObject copy_of_parent = new GameObject(_parentGameObject);
            return copy_of_parent;
        }

        public void MoveObject(int new_x_position, int new_y_position)
        {
            //Bouger l'objet selon de nouvelles positions
            _positionComponent.SetPosition(new_x_position, new_y_position);
            _hasMovedlast = true;
        }

        //RENAME CETTE FONCTION: IMPORTANT (Pas d'inspi RN)
        public void EventManagerAction(GameEvent game_event)
        {
            KeyPressedEvent key_pressed_event = game_event as KeyPressedEvent;
            int current_x_pos = _positionComponent.GetPositionX();
            int current_y_pos = _positionComponent.GetPositionY();

            if (key_pressed_event != null)
            {
                switch(key_pressed_event._keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        {
                            MoveObject(current_x_pos, current_y_pos - 1);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            MoveObject(current_x_pos, current_y_pos + 1);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            MoveObject(current_x_pos - 1, current_y_pos);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            MoveObject(current_x_pos + 1, current_y_pos);
                            break;
                        }
                }
            }
        }

        public bool GetHasMoved()
        { 
            return _hasMovedlast; 
        }
    }
}
