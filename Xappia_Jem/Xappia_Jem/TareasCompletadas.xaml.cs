using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xappia_Jem.Model;

namespace Xappia_Jem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareasCompletadas : ContentPage
    {
        public TareasCompletadas()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.RutaDB))
            {
                List<Tarea> listaTareas = new List<Tarea>();
                try
                {
                    listaTareas = connection.Table<Tarea>().Where(t => t.Completada == true).ToList();
                    if (listaTareas.Count == 0)
                    {
                        lblEmpty.IsVisible = true;
                    }
                    else
                    {
                        lblEmpty.IsVisible = false;
                    }
                }
                catch
                {
                    lblEmpty.IsVisible = true;
                }
                finally
                {
                    lvTareas.ItemsSource = listaTareas;
                }

            }
        }
    }
}