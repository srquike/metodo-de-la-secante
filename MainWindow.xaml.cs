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

namespace metodo_de_la_secante
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private IList<Iteracion> iteraciones;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxtValorX.Text, out double x) && !string.IsNullOrEmpty(TxtValorX.Text))
            {
                Iteracion iteracion, iteracionAnterior;
                int i;

                iteraciones = new List<Iteracion>();
                iteracionAnterior = new Iteracion();
                i = 0;

                do
                {
                    iteracion = new Iteracion();
                    iteracion.I = i;

                    if (iteracion.I == 0)
                    {
                        iteracion.Xi = x;
                    }
                    else
                    {
                        iteracion.Xi = iteracionAnterior.Xima1;
                        iteracion.Xime1 = iteracionAnterior.Xi;
                    }

                    iteracion.Fxime1 = Math.Pow(Math.E, -iteracion.Xime1) - iteracion.Xime1;
                    iteracion.Fxi = Math.Pow(Math.E, -iteracion.Xi) - iteracion.Xi;
                    iteracion.Xima1 = iteracion.Xi - (iteracion.Fxi * (iteracion.Xime1 - iteracion.Xi) / (iteracion.Fxime1 - iteracion.Fxi));
                    iteracion.Error = Math.Abs((iteracion.Xi - iteracionAnterior.Xi) / iteracion.Xi) * 100;

                    iteraciones.Add(iteracion);
                    iteracionAnterior = iteracion;
                    i++;

                } while (iteracion.Error != 0 && iteracion.Error != 0.001);

                DgIteraciones.ItemsSource = iteraciones;
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtValorX.Clear();
            DgIteraciones.ItemsSource = null;
            TxtValorX.Focus();
        }
    }
}
