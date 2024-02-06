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

namespace Sergioteacher.Csharp04.ProtoFileDialog
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// Desarrollo típico para la clase base..
    /// </summary>
    public partial class MainWindow : Window
    {
        public string data;
        public WindowFileDialog ventanaInput;

        public MainWindow()
        {
            InitializeComponent();
            ventanaInput = new WindowFileDialog(this);
        }

        private void BIntro_Click(object sender, RoutedEventArgs e)
        {
            ventanaInput.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Current.Shutdown();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Tsalida.Text = data;
        }
    }
}
