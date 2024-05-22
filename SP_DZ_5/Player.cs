using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_DZ_5
{
    public class Player
    {
        public string Name { get; set; }
        public int TotalMoney { get; set; }
        public int Bet = 0;
        public int Number = 0;
        public bool isTable = false;
        public int TotalWin = 0;
        public int Totalose = 0;
    }
}
