using System;
using System.Collections.Generic;
using System.Text;

namespace game_in_console.otherSystem
{
    public class SystemDataBase
    {
        public void Capslock()
        {
            if (Console.CapsLock == true)
                Console.Title = "Game in a console with CapsLock";
            else
                Console.Title = "Game in a console";
        }
        public void WL(string mess)
        {
            Console.WriteLine(mess);
        }
        public void WL(int num)
        {
            Console.WriteLine(num);
        }
    }
}
