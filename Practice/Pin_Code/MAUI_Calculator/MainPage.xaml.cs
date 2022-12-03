using Microsoft.Maui.Layouts;

namespace MAUI_Calculator;

public partial class MainPage : ContentPage
{
	private const string PASSWORD = "1570";

	public MainPage()
	{
		InitializeComponent();
	}

	private void DigitClicked(object sender, EventArgs e)
	{
		DisplayLabel.Text += (sender as Button).Text;
	}

	private void ActionClicked(object sender, EventArgs e)
	{
		DisplayLabel.Text += '\n';
    	}

	private void ClearClicked(object sender, EventArgs e)
	{
        	SetLabelAlignment(TextAlignment.End);

		DisplayLabel.Text = "";
    	}

	private void ConfirmClicked(object sender, EventArgs e)
	{
        	if (DisplayLabel.Text.ToString() == PASSWORD)
		{
			DisplayLabel.Text = "Congratulations, you are in!";
            		SetLabelAlignment(TextAlignment.Center);
            		foreach (View a in ((sender as Button).Parent as Grid).Children.Cast<View>())
            		{
                		a.IsEnabled = false;
            		}
        	}
		else 
			DisplayLabel.Text = "";
	}

	private void SetLabelAlignment(TextAlignment _alignment)
	{
        	DisplayLabel.VerticalTextAlignment = _alignment;
        	DisplayLabel.HorizontalTextAlignment = _alignment;
    	}
}

