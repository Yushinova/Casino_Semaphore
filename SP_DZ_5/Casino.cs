using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_DZ_5
{
    public class Casino
    {
        public List<Player> players;        
        public List<Thread> threads;
        public Random random = new Random();
        public int casino_number = 0;
        public Semaphore semaphore = new Semaphore(5, 5);
        public int SetNumber()
        {
            return casino_number = random.Next(0, 35);
        }
        public void SetPlayers()
        {
            players = new List<Player>();
            for (int i = 0; i < random.Next(20, 100); i++)
            {
                players.Add(new Player { Name = $"Player " + (i+1), TotalMoney = random.Next(10, 200) });
            }
        }
        public void StartThreads()
        {
            threads = new List<Thread>();
            for (int i = 0; i < players.Count; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Go));
                thread.Start(players[i]);
            }
        }
       public void Go(object obj)
        {
            Player player = obj as Player;

            try
            {
                semaphore.WaitOne();
                do
                {
                    player.isTable = true;
                    Console.WriteLine($"{player.Name} думает..........");
                    player.Bet = random.Next(1, player.TotalMoney);
                    Console.WriteLine($"{player.Name} ставка: {player.Bet} RUB");
                    player.Number = random.Next(0, 35);
                    Console.WriteLine($"{player.Name} число: {player.Number}");
                    Thread.Sleep(3000);

                } while (player.isTable);
            }
            finally
            {
                semaphore.Release();
            }
        }
        public void proverka()
        {
            foreach (var item in players)
            {
                if (item.isTable)
                {
                    if (item.Number == casino_number)
                    {
                        item.TotalMoney += item.Bet * 2;
                        Console.WriteLine($"{item.Name} УРА!!! Выигрыш составил: {item.Bet * 2} RUB");
                        item.TotalWin += item.Bet * 2;
                    }
                    else
                    {
                        if ((item.TotalMoney - item.Bet) > 0)
                        {
                            item.TotalMoney -= item.Bet;
                            Console.WriteLine($"{item.Name} Проиграл!!! Остаток суммы: {item.TotalMoney} RUB");
                            item.Totalose+= item.Bet;
                        }
                        else
                        {
                            item.isTable = false;
                            Console.WriteLine($"{item.Name} уходит из-за стола");
                        }

                    }
                }

            }

        }
    }
}
