using CommunityToolkit.Maui.Alerts;

namespace ConstrutorDeCores;

public partial class MainPage : ContentPage
{
	bool eAleatorio; //Forma de usar o SetColor apenas uma vez
	string valorHexa; //Variável da copia do código aleatório

	public MainPage()
	{
		InitializeComponent();
	}

	//metodo para gerar o código da cor usando os sliders
    private void Slider_MudarValor(object sender, ValueChangedEventArgs e)
    {
		if(!eAleatorio)
		{
            var vermelho = sldVermelho.Value;
            var verde = sldVerde.Value;
            var azul = sldAzul.Value;

            Color color = Color.FromRgb(vermelho, verde, azul);

            SetColor(color);
        }
    }

	//Método para mostrar a mudança de cor no fundo
	private void SetColor(Color color)
	{
		btnAleatorio.BackgroundColor = color;
		Container.BackgroundColor = color;
		valorHexa = color.ToHex();
		lblHex.Text= valorHexa;
	}

    //método para gerar o código da cor usando o botão aleatório
    private void btnAleatorio_Clicked(object sender, EventArgs e)
    {
		eAleatorio = true; 
		var aleatorio = new Random();

		var color = Color.FromRgb(aleatorio.Next(0, 256), aleatorio.Next(0, 256), aleatorio.Next(0, 256));

		SetColor(color);

		//Parte que vai modificar os sliders quando gerar a cor aleatória
		sldVermelho.Value = color.Red;
		sldVerde.Value = color.Green;
		sldAzul.Value = color.Blue;
		eAleatorio = false;
    }

	//Método para copiar o texto do botão aleatorio
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Clipboard.SetTextAsync(valorHexa); //ClipBoard para copiar
		var toast = Toast.Make("Cor Copiada", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
		await toast.Show();
    }
}

