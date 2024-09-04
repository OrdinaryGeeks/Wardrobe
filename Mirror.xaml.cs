namespace Wardrobe2;
using Wardrobe2.ViewModels;

public partial class Mirror : ContentPage
{
	MirrorViewModel mirror;
	public Mirror()
	{
		InitializeComponent();

		mirror = new MirrorViewModel();
		BindingContext =mirror;
	}

	//on reappearing rebind context to reset the mirror image variables
	protected override async void OnAppearing()
	{
		base.OnAppearing();


        mirror = new MirrorViewModel();
        BindingContext = mirror;
        
    }
}