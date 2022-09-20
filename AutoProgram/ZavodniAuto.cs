using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProgram
{
    abstract class ZavodniAuto : Auto
    {
        public int Zrychleni;
        public int Brzdy;

        protected ZavodniAuto(TypyAut typAuta, string jmeno, JmenoRidice ridic, double vykon, int stav, int zrychleni, int brzdy)
            :base(typAuta,jmeno,ridic,vykon,stav)
        {
            Zrychleni = zrychleni;
            Brzdy = brzdy;
        }
        public override string Vypsat()
        {
            return $"{Jmeno}, {Ridic}, {Vykon}kw, {Stav}%, {Zrychleni}, {Brzdy}";
        }
        public override string Vypsat2()
        {
            return $"{base.Vypsat2()} | zrychleni: {Zrychleni} | brzdy: {Brzdy}";
        }
    }
}
