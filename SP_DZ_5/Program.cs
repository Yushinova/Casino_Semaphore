using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_DZ_5
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //В моем казино все играют до последнего))
            Casino casino = new Casino();
            casino.SetPlayers();
            Console.WriteLine($"Всего игроков сегодня: {casino.players.Count} человек");
            casino.StartThreads();
            while (casino.players.Find(p=>p.isTable==true)!=null)
            {
                Thread.Sleep(2000);
                casino.SetNumber();
                Console.WriteLine("ВЫПАЛО ЧИСЛО : " + casino.casino_number);
                casino.proverka();
                Thread.Sleep(1000);
               
            }
            foreach (var item in casino.players)
            {
                Console.WriteLine("____________________________________");
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"Общий выигрыш: {item.TotalWin} руб");
                Console.WriteLine($"Общий проигрыш: {item.Totalose} руб");
            }
            Console.ReadKey();
 
        }
    }
}
