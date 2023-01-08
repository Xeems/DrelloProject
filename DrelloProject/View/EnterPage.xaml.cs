using DrelloProject.ViewModels;

namespace DrelloProject.View;

public partial class EnterPage : ContentPage
{
    public EnterPage(EnterPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void NewAccountBtn_Clicked(object sender, EventArgs e)
    {
        var EnterSignUpBtnCor = EnterSignUpBtn.TranslateTo(-200, 0, 800, Easing.BounceOut);
        var LogInMainLabelCor = LogInMainLabel.TranslateTo(210, 0, 250);
        var LogInSecondLabelCor = LogInSecondLabel.TranslateTo(180, 0, 250);

        await Task.WhenAll(EnterSignUpBtnCor, LogInMainLabelCor, LogInSecondLabelCor);
    }
}