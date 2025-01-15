namespace convertisseur.Pages;

public partial class Convertisseur : ContentPage
{
	public Convertisseur()
	{
		InitializeComponent();
	}

    private void OnButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        string? digit = button?.Text;

        if (VC.Text.Length > 0)
        {
            VDLabel.Text = string.Empty;
            VD.Text = string.Empty;
            VC.Text = string.Empty;
            VCLabel.Text = string.Empty;
        }

        if (VD.Text.Length == 0 && digit == "0")
            return;

        if (VD.Text.Length < 10)
        {
            if (digit == "0" && VD.Text != "")
            {
                VD.Text += digit;
            }
            else if (digit != "0")
            {
                VD.Text += digit;
            }
        }
    }

    private async void OnConversionClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        string? buttonText = button?.Text;

        if (string.IsNullOrEmpty(VD.Text) || VD.Text == "Entrez un nombre")
        {
            await DisplayAlert("Erreur","Entrer un nombre","OK");
            return;
        }

        double number;
        bool isValid = double.TryParse(VD.Text, out number);
        if (!isValid)
        {
            await DisplayAlert("Erreur","Nombre invalide","OK");
            return;
        }

        double result = 0;
        string resultText = "";

        if (buttonText.Contains("CM � PO"))
        {
            result = number / 2.54;
            VDLabel.Text = "Centim�tre";
            VCLabel.Text = "Pouce";
            resultText = result.ToString("F2") + " pouces";
        }
        else if (buttonText.Contains("PO � CM"))
        {
            result = number * 2.54;
            VDLabel.Text = "Pouce";
            VCLabel.Text = "Centim�tre";
            resultText = result.ToString("F2") + " cm"; 
        }
        else if (buttonText.Contains("M � PIED"))
        {
            result = number * 3.28084;
            VDLabel.Text = "M�tre";
            VCLabel.Text = "Pied";
            resultText = result.ToString("F2") + " pieds"; 
        }
        else if (buttonText.Contains("PIED � M"))
        {
            result = number / 3.28084;
            VDLabel.Text = "Pied";
            VCLabel.Text = "M�tre";
            resultText = result.ToString("F2") + " m�tres"; 
        }
        else if (buttonText.Contains("G � ONCE"))
        {
            result = number / 28.3495;
            VDLabel.Text = "Gramme";
            VCLabel.Text = "Once";
            resultText = result.ToString("F2") + " onces";
        }
        else if (buttonText.Contains("ONCE � G"))
        {
            result = number * 28.3495;
            VDLabel.Text = "Once";
            VCLabel.Text = "Gramme";
            resultText = result.ToString("F2") + " grammes";
        }
        else if (buttonText.Contains("KG � LBS"))
        {
            result = number * 2.20462;
            VDLabel.Text = "Kilogramme";
            VCLabel.Text = "Livre";
            resultText = result.ToString("F2") + " lbs"; 
        }
        else if (buttonText.Contains("LBS � KG"))
        {
            result = number / 2.20462;
            VDLabel.Text = "Livre";
            VCLabel.Text = "Kilogramme";
            resultText = result.ToString("F2") + " kg"; 
        }
        else
        {
            await DisplayAlert("Erreur", "Erreur lors de la conversion", "OK");
        }

        VC.Text = resultText ;
    }
    private void OnEffacerClicked(object sender, EventArgs e)
    {
        VDLabel.Text = string.Empty;
        VD.Text = string.Empty;
        VC.Text = string.Empty;
        VCLabel.Text = string.Empty;
    }

}