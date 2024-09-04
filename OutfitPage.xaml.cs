using Wardrobe2.ViewModels;

namespace Wardrobe2;

public partial class OutfitPage : ContentPage
{
	public OutfitPage()
	{
		InitializeComponent();
		BindingContext = new OutfitViewModel();
		
	}
}