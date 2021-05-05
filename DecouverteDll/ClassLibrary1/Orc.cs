using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Orc : Character
    {
        public Orc(int health, int mana, int strength, string name)
            : base(1000, 0, strength, name) { }

        public string SendMessage(string message)
        {
            return name + " a dit " + Chat(message);
        }

        public void Kick()
        {
            bool bl = isBlock(Attack());

            if (bl)
            {

                health -= Attack();
            }
        }

    }
}
