using sLoachaminS6.Models;
using System.Net;

namespace sLoachaminS6.Views;

public partial class vActEliminar : ContentPage
{
    private const string ApiUrl = "http://192.168.56.1/moviles/wsestudiantes.php";
    public vActEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();        
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        string strCodigo = txtCodigo.Text,
            strNombre = txtNombre.Text,
            strApellido = txtApellido.Text,
            strEdad = txtEdad.Text,
            urlUpdate = ApiUrl + "?codigo=" + strCodigo + "&nombre=" + strNombre + "&apellido=" + strApellido + "&edad=" + strEdad;

        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            cliente.UploadValues(urlUpdate, "PUT", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        string strCodigo = txtCodigo.Text;
        string urlDelete = ApiUrl + "?codigo=" + strCodigo;

        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            cliente.UploadValues(urlDelete, "DELETE", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }
}