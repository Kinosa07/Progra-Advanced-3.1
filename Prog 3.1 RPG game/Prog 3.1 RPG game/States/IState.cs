using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.States
{
    public interface IState
    {
        //Chaque GameState fonctionne essentiellement comme son propre mini-jeu

        public void Enter(GameObject player_object);

        public GameObject Exit();

        public void Update(float delta_time);

        public void FixedUpdate(float fixed_update_time, float delta_time);

        public void Render();
    }
}
