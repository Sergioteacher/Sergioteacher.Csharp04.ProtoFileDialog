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
using System.Windows.Shapes;
using System.IO;

namespace Sergioteacher.Csharp04.ProtoFileDialog
{
    /// <summary>
    /// Lógica de interacción para WindowFileDialog.xaml
    /// </summary>
    public partial class WindowFileDialog : Window
    {
        MainWindow Inicio;
        List<TodosLosItems> items = new List<TodosLosItems>();
        string rutaFichero;

        public WindowFileDialog(MainWindow ventanaInicio)
        {
            InitializeComponent();
            Inicio = ventanaInicio;
        }

        private void BIntro_Click(object sender, RoutedEventArgs e)
        {
            Inicio.data = "' "+ MiTexto.Text + " '";
            Inicio.Show();
            this.Hide();
        }

        private void BRefres_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Datos de prueba
            items.Add(new TodosLosItems() { Titulo = "uno" });
            items.Add(new TodosLosItems() { Titulo = "dos y dos" });
            items.Add(new TodosLosItems() { Titulo = "tres" });
            */
            rutaFichero = MiTexto.Text;

            if (rutaFichero == "")
            {
                rutaFichero = ".";
            }
            /*
             * Para el acceso a los datos del Sistema Operativo
             * Como se prueba si existe el directorio,
             * no uso la estructura try
             * que si tubiera que leer algo sí lo necesitaría.
             */
            if (Directory.Exists(rutaFichero) || rutaFichero == ".")
            {
                //Salida.Text += "01";
                items.Clear();
                UnaRistra.Visibility = Visibility.Hidden;
                string[] ficheritos = Directory.GetFiles(rutaFichero);
                //Salida.Text += "02";
                foreach (string file in ficheritos)
                {
                    items.Add(new TodosLosItems() { Titulo = file });
                }
            }

            UnaRistra.ItemsSource = items;
            UnaRistra.Visibility = Visibility.Visible;
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            Inicio.data = "<<No se ha selecionado nada>>";
            Inicio.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                //MessageBox.Show("Hola, mensaje al capturar ->  X");
                e.Cancel = true;
                Inicio.data = "";
                Inicio.Show();
                this.Hide();
            }
            
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            MiTexto.Text = "";
            //limpiando los datos que carga el ItemsControl
            UnaRistra.ItemsSource = null;
        }

        public class TodosLosItems
        {
            // Al trabajar con datos complejos, hay que indicar el tipo para acceder a las variables.
            public string Titulo { get; set; }
            //public int Completacion { get; set; }

        }

    }
}
