using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Wizard : Character
    {
        public Wizard(int health, int mana, int strength, string name)
            : base(500, 250, strength, name) { }

        public string SendMessage(string message)
        {
            return name + " a dit " + Chat(message);
        }

        public void Fire()
        {
            bool x = isBlock(Attack());

            if (x)
            {
                health -= Attack();
            }
        }

    }
}
