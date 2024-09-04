using Wardrobe2.ViewModels;

namespace Wardrobe2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
       public static string? clothesItem = "";
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            
        }

       
        private void OnClothesItemChecked(object sender, EventArgs e)
        {
            clothesItem = (sender as RadioButton).Content.ToString();

            
        }


    }

}
