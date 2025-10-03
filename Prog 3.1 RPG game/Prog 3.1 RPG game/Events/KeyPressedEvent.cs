using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3._1_RPG_game.Events
{
    internal class KeyPressedEvent
    {
        private ConsoleKey _keyPressed;

        public KeyPressedEvent(ConsoleKey key_pressed)
        {
            _keyPressed = key_pressed;
        }
    }
}
