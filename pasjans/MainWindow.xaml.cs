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

namespace pasjans
{
    public class Sprite : Image
    {
        public int X;
        public int Y;
    }
    public class Card : Sprite
    {
        protected int number;
        protected int value; //1 as, 11 walet, 12 dama, 13 krol
        protected int color; //1 karo, 2 trefl, 3 kier, 4 pik
        
        public Card(int number)
        {
            this.number = number;
            this.value = number / 13 + 1;
            this.color = number % 13 + 1;
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri("karty/sCardFront_" + number + ".png", UriKind.Relative);
            b.EndInit();
            Stretch = Stretch.Fill;
            Source = b;
        }
        public Card() { }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Background = Brushes.Green;
            List<Card> karty = new List<Card>();
            List<Card> temp = new List<Card>();
            List<Card> kopia = new List<Card>();
            Card tmp;
            Random rnd = new Random();
            int k = 0;

            for (int j = 0; j < 4; j++)
            {
               for (int i = 0; i < 13; i++)
                {
                    tmp = new Card(k);
                   // tmp.X = j * 130;
                   // tmp.Y = i * 95;
                   // Canvas.SetTop(tmp, tmp.X);
                   // Canvas.SetLeft(tmp, tmp.Y);
                   // paintCanvas.Children.Add(tmp);
                    tmp.Width = 95;
                    tmp.Height = 130;
                    karty.Add(tmp);
                    k++;
                }
            }

            kopia = karty;
            int nr;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    nr = rnd.Next(0,k--);
                    tmp = kopia[nr];
                    kopia.RemoveAt(nr);
                    tmp.X = j * 130;
                    tmp.Y = i * 95;
                    Canvas.SetTop(tmp, tmp.X);
                    Canvas.SetLeft(tmp, tmp.Y);
                    paintCanvas.Children.Add(tmp);
                    temp.Add(tmp);
                }
            }

            
        }
    }
}
