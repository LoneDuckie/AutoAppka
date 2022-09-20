using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProgram
{
    abstract class Auto
    {
        private static int _pocitadlo = 0;
        public int Id { get; }
        public string Jmeno { get; set; }
        public JmenoRidice Ridic { get; set; }

        public string Vypis2 { get; set; }

        public double Vykon { get; set; }
        public int Stav {get; set; }

        public TypyAut TypAuta { get; }


        protected Auto(TypyAut typAuta, string jmeno, JmenoRidice ridic, double vykon, int stav)
        {
            Id = _pocitadlo++;
            Jmeno = jmeno;
            Ridic = ridic;
            Vykon = vykon;
            Stav = stav;
            TypAuta = typAuta;
        }

        public int GetId()
        {
            return Id;
        } 
        public int Opravit()
        {
            Stav = 100;
            return Stav;
        }
        public string GetStavStr()
        {
            return $"{Stav:0.#} %";
        }
        public virtual string Vypsat()
        {
            return $"{Jmeno}, {Ridic}, {Vykon}kw, {Stav}%";
        }
        public virtual string Vypsat2()
        {
            return $"{Vykon} kW | stav: {GetStavStr()}";
        }

        public override string ToString()
        {
            return Vypsat();
        }

    }
}
