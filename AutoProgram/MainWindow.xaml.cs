using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Zápisy Dictionary
        //Dictionary<int,AutoFormule> Formule = new Dictionary<int, AutoFormule>();
        //Dictionary<int, AutoSoutez> WRC = new Dictionary<int, AutoSoutez>();
        //Dictionary<int, Taxi> Taxi = new Dictionary<int, Taxi>();
        //List<Auto> Auta = new List<Auto>();

        private Dictionary<int, Auto> _dictAuta = new Dictionary<int, Auto>();

        private Dictionary<int, Auto> GetTypAut(TypyAut typ)
        {
            return _dictAuta.Where(x => x.Value.TypAuta == typ).ToDictionary(x => x.Key, x => x.Value);
        }
        #endregion

        string jmeno;
        VyrobceWRC vyrobceWRC;
        JmenoRidice ridic;
        double vykon;
        int stav;
        int zrychleni;
        int brzdy;
        JmenoNavigatora navigator;
        int odpruzeni;
        Staj staj;
        int pritlak;
        AutoTaxi vyrobce;
        int taxametr;



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {     

            Random random = new Random();

            #region WRC
            for (int i = 0; i < 5; i++)
            {
                jmeno = $"WRC car n°{i + 1}";

                vyrobceWRC = (VyrobceWRC)random.Next(VyrobceWRC.GetNames(typeof(VyrobceWRC)).Length);

                ridic = (JmenoRidice)random.Next(JmenoRidice.GetNames(typeof(JmenoRidice)).Length);

                vykon = random.Next(350, 380);

                stav = 100;

                zrychleni = random.Next(0, 10);

                brzdy = random.Next(0, 10);

                navigator = (JmenoNavigatora)random.Next(JmenoNavigatora.GetNames(typeof(JmenoNavigatora)).Length);

                odpruzeni = random.Next(0, 10);

                AutoSoutez autosoutez = new AutoSoutez(jmeno, vyrobceWRC, ridic, vykon, stav, zrychleni, brzdy, navigator, odpruzeni);

                _dictAuta.Add(autosoutez.GetId(), autosoutez);
            }

            #endregion

            #region Formule
            for (int i = 0; i < 5; i++)
            {
                jmeno = $"Formula car n°{i + 1}";

                staj = (Staj)random.Next(Staj.GetNames(typeof(Staj)).Length);

                ridic = (JmenoRidice)random.Next(JmenoRidice.GetNames(typeof(JmenoRidice)).Length);

                vykon = random.Next(800, 1000);

                stav = 100;

                zrychleni = random.Next(0, 10);

                brzdy = random.Next(0, 10);

                pritlak = random.Next(0, 10);

                AutoFormule autoformule = new AutoFormule(jmeno, staj, ridic, vykon, stav, zrychleni, brzdy, pritlak);

                _dictAuta.Add(autoformule.GetId(), autoformule);
            }
            #endregion

            #region Taxi

            for (int i =0; i<5; i++)
            {
                jmeno = $"Taxi car n°{i + 1}";

                vyrobce = (AutoTaxi)random.Next(AutoTaxi.GetNames(typeof(AutoTaxi)).Length);

                ridic = (JmenoRidice)random.Next(JmenoRidice.GetNames(typeof (JmenoRidice)).Length);

                vykon = random.Next(150, 500);

                stav = 100;

                taxametr = random.Next(5, 100);

                Taxi autotaxi = new Taxi(jmeno, vyrobce, ridic, vykon, stav, taxametr);

                _dictAuta.Add(autotaxi.GetId(), autotaxi);
            }
            #endregion



        }

        private void KonecBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private int _dataauta;
        private void FormuleBtn_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)e.Source;
            if (obj == null) return;

            if (obj.Name.Equals("VseBtn"))
                _dataauta = 0;
            else if (obj.Name.Equals("FormuleBtn"))
                _dataauta = 1;
            else if (obj.Name.Equals("WRCBtn"))
                _dataauta = 2;
            else if (obj.Name.Equals("TaxiBtn"))
                _dataauta = 3;

            LvFilter();
        }

        private void LvFilter()
        {
            Dictionary<int, Auto> data = new Dictionary<int, Auto>();

            

            if (_dataauta == 0)
            {
                data = _dictAuta;
            }
            else if (_dataauta == 1)
            {
                data = GetTypAut(TypyAut.Formule);
            }
            else if (_dataauta == 2)
            {
                data = GetTypAut(TypyAut.Wrc);
            }
            else if (_dataauta == 3)
            {
                data = GetTypAut(TypyAut.Taxi);
            }

            

            Dictionary<int, Auto> data2 = new Dictionary<int, Auto>();  

            foreach (var item in data)
            {
                if (item.Value.Jmeno.ToLower().Contains(Filter.Text.ToLower())){
                    data2.Add(item.Key, item.Value);
                }
            }
            foreach (var item2 in data2.Values)
            {
                item2.Vypis2 = item2.Vypsat2();
            }
            ListView1.ItemsSource = data2.Values;
        }

        private void Filter_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            LvFilter();
        }
    }
}
