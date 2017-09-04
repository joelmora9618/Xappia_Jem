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
    public partial class ListaTarea : ContentPage
    {
        public ListaTarea()
        {
            InitializeComponent();

            var botonNuevo = new ToolbarItem()
            {
                Text = "Add"
            };

            botonNuevo.Clicked += BotonNuevo_Clicked;
            ToolbarItems.Add(botonNuevo);
        }

        async private void BotonNuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CargarTarea());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.RutaDB))
            {
                List<Tarea> listaTareas = new List<Tarea>();

                try
                {
                    listaTareas = connection.Table<Tarea>().Where(t => t.Completada == false).ToList();
                    if(listaTareas.Count==0)
                    {
                        lblEmpty.IsVisible = true;
                    }else
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

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.RutaDB))
            {
                var tareaAcompletar = (sender as MenuItem).CommandParameter as Tarea;
                tareaAcompletar.Completada = true;

                connection.Update(tareaAcompletar);

                List<Tarea> listaTareasFiltrada;
                listaTareasFiltrada = connection.Table<Tarea>().Where(t => t.Completada == false).ToList();
                if(listaTareasFiltrada.Count==0)
                {
                    lblEmpty.IsVisible = true;
                }
                else
                {
                    lblEmpty.IsVisible = false;
                }
                lvTareas.ItemsSource = listaTareasFiltrada;
            }
        }
    }
}