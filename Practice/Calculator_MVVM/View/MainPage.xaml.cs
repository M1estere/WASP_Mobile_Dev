using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new OptionViewModel(DisplayLabel);
    }
}
