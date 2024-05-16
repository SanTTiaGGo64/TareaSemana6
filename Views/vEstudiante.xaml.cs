using Newtonsoft.Json;
using sLoachaminS6.Models;
using System.Collections.ObjectModel;

namespace sLoachaminS6.Views;

public partial class vEstudiante : ContentPage
{
    //Ruta
    private const string url = "http://192.168.56.1/moviles/wsestudiantes.php";
    //Protocolo
    private readonly HttpClient cliente = new HttpClient();
    //Contenedor almacenar temp datos
    private ObservableCollection<Estudiante> est;
    public vEstudiante()
    {
        InitializeComponent();
        ObtenerDatos();
    }
    public async void ObtenerDatos()
    {
        var content = await cliente.GetStringAsync(url);
        List<Estudiante> mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        est = new ObservableCollection<Estudiante>(mostrar);
        listEstudiante.ItemsSource = est;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vAgregar());
    }

    private void listEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActEliminar(objEstudiante));
    }

}