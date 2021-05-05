using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Character
    {
        private int m_health;
        public int health
        {
            get { return m_health; }
            set { m_health = value; }
        }

        private int m_mana;
        public int mana
        {
            get { return m_mana; }
            set { m_mana = value; }
        }

        private int m_strength;
        public int strength
        {
            get { return m_strength; }
            set { m_strength = value; }
        }

        private string m_name;
        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public Character()
        {
            Console.WriteLine("personnage créée !!!");
        }
        //Déclaration des méthodes
        public Character(int health, int mana, int strenght, string name)
        {
            this.m_health = health;
            this.m_mana = mana;
            this.m_strength = strength;
            this.m_name = name;
        }

        readonly Random rnd = new Random();

        public string Chat(string message)
        {
            return message;
        }

        public int Attack()
        {
            return strength * rnd.Next(1, 11);
        }

        public bool isBlock(int number)
        {
            int x = number % 3;
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
