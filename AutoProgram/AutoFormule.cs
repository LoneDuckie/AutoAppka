using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProgram
{
    internal class AutoFormule : ZavodniAuto
    {
        public int Pritlak { get; set; }
        public Staj Staj { get; set; }
        public AutoFormule(string jmeno, Staj staj, JmenoRidice ridic, double vykon, int stav, int zrychleni, int brzdy, int pritlak)
            : base(TypyAut.Formule, jmeno, ridic, vykon, stav, zrychleni, brzdy)
        {
            Pritlak = pritlak;
            Staj = staj;
        }
        public override string Vypsat()
        {
            return $"{Jmeno}, {Staj}, {Ridic}, {Vykon}kw, {Stav}%, {Zrychleni}, {Brzdy}, {Pritlak}";
        }
        public override string Vypsat2()
        {
            return $"{base.Vypsat2()} | přítlak: {Pritlak}";
        }
    }
}
