using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xappia_Jem.Model;
using Xappia_Jem.Repository;

namespace Xappia_Jem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CargarTarea : ContentPage
    {
        public CargarTarea()
        {
            InitializeComponent();
        }

        private void btnGuardar(object sender, EventArgs e)
        {
            Tarea nuevaTarea = new Tarea()
            {
                Nombre = entNombre.Text,
                Fecha = fechaLimiteDatePicker.Date,
                Hora = horaLimiteTimePicker.Time,
                Completada = false
            };

            int resultado = TareaRepository.insertTarea(nuevaTarea);
            if (resultado > 0)
            {
                DisplayAlert("Exito", "El elemento se guardo", "OK");
            }
            else
            {
                DisplayAlert("Error", "Intente de nuevo", "OK");
            }

        }
    }
}