using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProgram
{
    internal class Taxi:Auto
    {
        public int Taxametr { get; set; }
        public AutoTaxi AutoTaxi { get; set; }
        public Taxi(string jmeno, AutoTaxi autotaxi, JmenoRidice ridic, double vykon, int stav, int taxametr)
           : base(TypyAut.Taxi, jmeno, ridic, vykon, stav)
        {
            Taxametr = taxametr;
            AutoTaxi = autotaxi;
        }

        public override string Vypsat()
        {
            return $"{Jmeno}, {AutoTaxi}, {Ridic}, {Vykon}kw, {Stav}%, {Taxametr}kc/km";
        }
        public override string Vypsat2()
        {
            return $"{base.Vypsat2()} | taxametr: {Taxametr}";
        }
    }
}
