using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace _2_14fi_hunger_games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        string name = "névtelen";
        public string Namee
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Namee");
            }
        }
        int ehsegSzazalek = 100;
        string kolbaszContent = "Kolbász";
        string hamburgerContent = "Hamburger";
        string hotdogContent = "Hotdog";
        string pizzaContent = "Pizza";
        int money = 0;
        public string PizzaContent
        {
            get
            {
                return pizzaContent;
            }
            set
            {
                if (value.ToLower() == "csokken")
                {
                    pizzaContent = pizzaContent.Substring(0, pizzaContent.Length - 1);
                    EhsegSzazalek -= 12;
                }
                OnPropertyChanged("PizzaContent");
            }
        }
        public string HotdogContent
        {
            get
            {
                return hotdogContent;
            }
            set
            {
                if (value.ToLower() == "csokken")
                {
                    hotdogContent = hotdogContent.Substring(0, hotdogContent.Length - 1);
                    EhsegSzazalek -= 4;
                }
                OnPropertyChanged("HotdogContent");
            }
        }
        public string HamburgerContent
        {
            get
            {
                return hamburgerContent;
            }
            set
            {
                if (value.ToLower() == "csokken")
                {
                    hamburgerContent = hamburgerContent.Substring(0, hamburgerContent.Length - 1);
                    EhsegSzazalek -= 7;
                }
                OnPropertyChanged("HamburgerContent");
            }
        }
        public string KolbaszContent
        {
            get
            {
                return kolbaszContent;
            }
            set
            {
                if (value.ToLower() == "csokken")
                {
                    kolbaszContent = kolbaszContent.Substring(0, kolbaszContent.Length - 1);
                    EhsegSzazalek = EhsegSzazalek - 5;
                }
                else if (value.ToLower() == "ujratolt")
                {
                    kolbaszContent = "Kolbász";
                    EhsegSzazalek += 20;
                    if (EhsegSzazalek > 100)
                    {
                        MessageBox.Show("Éhen haltál!");
                        this.Close();
                    }
                }
                OnPropertyChanged("KolbaszContent");
            }
        }
        public int EhsegSzazalek
        {
            get
            {
                return ehsegSzazalek;
            }
            set
            {
                if (value < 0)
                    ehsegSzazalek = 0;
                else
                    ehsegSzazalek = value;

                if (ehsegSzazalek > 70)
                    ehseg.Background = new SolidColorBrush(Colors.Red);
                else if (ehsegSzazalek > 40)
                    ehseg.Background = new SolidColorBrush(Colors.Orange);
                else
                    ehseg.Background = new SolidColorBrush(Colors.Green);

                OnPropertyChanged("EhsegSzazalek");
            }
        }
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
                OnPropertyChanged("Money");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        void NameChange(object s, EventArgs e)
        {
            Namee = "Aladár";
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        void KetchupClick(object s, EventArgs e)
        {
            Vasarlas("kolbász", 10);
        }
        void KrumpliClick(object s, EventArgs e)
        {
            Vasarlas("hamburger", 20);
        }
        void HotdogClick(object s, EventArgs e)
        {
            Vasarlas("hotdog", 8);
        }
        void PizzaClick(object s, EventArgs e)
        {
            Vasarlas("pizza", 28);
        }
        void Vasarlas(string mit, int mennyi)
        {
            if (Money - mennyi >= 0 && EhsegSzazalek > 0)
            {
                if (mit.ToLower() == "kolbász")
                {
                    if (KolbaszContent.Length > 0)
                    {
                        KolbaszContent = "csokken";
                        Money -= mennyi;
                    }
                }
                else if (mit.ToLower() == "hamburger")
                {
                    if (HamburgerContent.Length > 0)
                    {
                        HamburgerContent = "csokken";
                        Money -= mennyi;
                    }
                }
                else if (mit.ToLower() == "hotdog")
                {
                    if (HotdogContent.Length > 0)
                    {
                        HotdogContent = "csokken";
                        Money -= mennyi;
                    }
                }
                else if (mit.ToLower() == "pizza")
                {
                    if (PizzaContent.Length > 0)
                    {
                        PizzaContent = "csokken";
                        Money -= mennyi;
                    }
                }
            }
        }
        void KolbaszClick(object s, EventArgs e)
        {
            MessageBox.Show($"{name} éhes, kolbászt szeretne enni");
        }
        void DisznoClick(object s, EventArgs e)
        {
            KolbaszContent = "Ujratolt";
        }

        void ImHungryClick(object s, EventArgs e)
        {
            Namee = nevInput.Text;
        }
        void MoneyClick(object s, EventArgs e)
        {
            moneyInput.IsEnabled = false;
            moneyButton.Click -= MoneyClick;
        }
    }
}
