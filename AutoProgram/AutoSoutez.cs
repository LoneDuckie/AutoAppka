using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProgram
{
    internal class AutoSoutez : ZavodniAuto
    {
       public JmenoNavigatora Navigator { get; set; }
        public int Odpruzeni { get; set; }
        public VyrobceWRC VyrobceWRC { get; set; }
        public AutoSoutez(string jmeno, VyrobceWRC vyrobceWRC, JmenoRidice ridic, double vykon, int stav, int zrychleni, int brzdy, JmenoNavigatora navigator, int odpruzeni)
            : base(TypyAut.Wrc,jmeno, ridic, vykon, stav, zrychleni, brzdy)
        {
            Navigator = navigator;
            Odpruzeni = odpruzeni;
            VyrobceWRC = vyrobceWRC;
        }
        public override string Vypsat()
        {
            return $"{Jmeno}, {VyrobceWRC}, {Ridic}, {Vykon}kw, {Stav}%, {Zrychleni}, {Brzdy}, {Navigator}, {Odpruzeni}";
        }
        public override string Vypsat2()
        {
            return $"{base.Vypsat2()} | navigator: {Navigator} | odpružení: {Odpruzeni}";
        }
    }
}
