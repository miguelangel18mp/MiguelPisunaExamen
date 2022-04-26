using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiguelPisunaExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        double totalAPagar = 0;
        double montoInicial = 0;
        double cuotaMensual = 0;
        public Registro(string nombreUsuario)
        {
            InitializeComponent();
            lblNombreUsuario.Text = nombreUsuario;
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
           
            try
            {
                montoInicial = Convert.ToDouble(txtMontoInicial.Text);
                if (montoInicial<1 || montoInicial > 1800)
                {
                    DisplayAlert("Error en monto inicial", "Error en el monto Inical debe ser menor o igual a 1800 y mayor a 1", "Continuar");

                }
                else
                {
                    cuotaMensual = ((1800 - montoInicial)/ 3) +1800*0.05;
                    txtPagoMensual.Text = cuotaMensual.ToString();
                    totalAPagar = montoInicial +(cuotaMensual * 3);
                }
                
            }
            catch (Exception )
            {
                DisplayAlert("Error en monto inicial", "Error en el monto Inical debe ser numerico", "Continuar");

            }
            
        }

        private async void btnEnviar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Resumen(lblNombreUsuario.Text, txtNombreEstudiante.Text, totalAPagar));

        }
    }
}