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

namespace _2_14fi_hunger_games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name = "névtelen";
        int money = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        void KetchupClick(object s, EventArgs e)
        {
            if (money >= 10)
            {
                string content = kolbasz.Content.ToString();
                if (content.Length > 0)
                {
                    kolbasz.Content = content.Substring(0, content.Length - 1);
                    int ehsegSzazalek = int.Parse(ehseg.Content.ToString().Trim('%'));
                    if (ehsegSzazalek >= 5)
                    {
                        ehseg.Content = (ehsegSzazalek - 5).ToString() + '%';
                    }
                    EhsegBackground();
                    money -= 10;
                    moneyInput.Text = money.ToString();
                }
            }

        }
        void KolbaszClick(object s, EventArgs e)
        {
            MessageBox.Show($"{name} éhes, kolbászt szeretne enni");
        }
        void DisznoClick(object s, EventArgs e)
        {
            kolbasz.Content = "Kolbász";
            int ehsegSzazalek = int.Parse(ehseg.Content.ToString().Trim('%'));
            ehseg.Content = (ehsegSzazalek + 20) + "%";
            if (ehsegSzazalek + 20 > 100)
            {
                MessageBox.Show("Éhen haltál!");
                this.Close();
            }
            EhsegBackground();
        }
        void EhsegBackground()
        {
            int ehsegSzazalek = int.Parse(ehseg.Content.ToString().Trim('%'));
            if (ehsegSzazalek > 70)
                ehseg.Background = new SolidColorBrush(Colors.Red);
            else if (ehsegSzazalek > 40)
                ehseg.Background = new SolidColorBrush(Colors.Orange);
            else
                ehseg.Background = new SolidColorBrush(Colors.Green);
        }
        void ImHungryClick(object s, EventArgs e)
        {
            name = nevInput.Text;
        }
        void MoneyClick(object s, EventArgs e)
        {
            money = int.Parse(moneyInput.Text.ToString());
            moneyInput.IsEnabled = false;
            moneyButton.Click -= MoneyClick;
        }
    }
}
