using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using System.IO;

namespace Wardrobe2.ViewModels;

public partial class OutfitViewModel : ObservableObject
{


    //Static fields to share across application.  Visible determines if image is shown and path is path to image

    public static bool staticCollaredVisible;
    public static bool staticButtonDownVisible;
    public static bool staticSlacksVisible;
    public static bool staticTeeShirtsVisible;
    public static bool staticSuitCoatVisible;
    public static bool staticJeansVisible;

    public static string staticCollaredPath;
    public static string staticButtonDownPath;
    public static string staticSlacksPath;
    public static string staticTeeShirtsPath;
    public static string staticSuitCoatPath;
    public static string staticJeansPath;

    //Properties on outfit page that controls if images are visible on the vert layout
    [ObservableProperty]
     bool buttonDownVisible;

    [ObservableProperty]
     bool collaredVisible;
    [ObservableProperty]
     bool jeansVisible;
    [ObservableProperty]
    bool slacksVisible;
    [ObservableProperty]
    bool teeShirtsVisible;
    [ObservableProperty]
    bool suitCoatVisible;

    //Paths to images for the categories described

    [ObservableProperty]
    string buttonDownPath;
    [ObservableProperty]
    string collaredPath;
    [ObservableProperty]
    string jeansPath;
    [ObservableProperty]
    string slacksPath;
    [ObservableProperty]
    string teeShirtsPath;
    [ObservableProperty]
    string suitCoatPath;

    [ObservableProperty]
	string imagePath;

   
    //Init static variables
    static OutfitViewModel()
    {
        staticCollaredPath = String.Empty;
        staticButtonDownPath = String.Empty;
        staticSlacksPath = String.Empty;
        staticTeeShirtsPath = String.Empty;
        staticSuitCoatPath = String.Empty;
        staticJeansPath = String.Empty;

    }
	public OutfitViewModel()
	{
		imagePath = String.Empty;
        buttonDownVisible = false;
        buttonDownPath= String.Empty;



        collaredPath=String.Empty;
        jeansPath=String.Empty;
        slacksPath=String.Empty;
        teeShirtsPath = String.Empty;
        suitCoatPath=String.Empty;

    }


    //Each clothing item has a Set method that allows a picture to be chosen and sats the path/visible of static and non static varialbles
    [RelayCommand]
    private async Task SetButtonDown()
    {

        ButtonDownPath = "";
        MediaPickerOptions options = new MediaPickerOptions();

        FileResult? picture = await MediaPicker.PickPhotoAsync();
        ButtonDownVisible = false;
        if (picture != null)
        {
            ButtonDownPath = picture.FullPath;
            ButtonDownVisible = true;
            staticButtonDownPath = picture.FullPath;
            staticButtonDownVisible = true;
        }
    }

    [RelayCommand]
        private async Task SetCollaredPolo()
        {

            CollaredPath = "";
            MediaPickerOptions options = new MediaPickerOptions();

            FileResult? picture = await MediaPicker.PickPhotoAsync();
            CollaredVisible = false;
            if (picture != null)
            {
                CollaredPath = picture.FullPath;
                CollaredVisible = true;
            staticCollaredPath = picture.FullPath;
            staticCollaredVisible = true;
        }


        }

    [RelayCommand]
        private async Task SetJeans()
        {

            JeansPath = "";
            MediaPickerOptions options = new MediaPickerOptions();

            FileResult? picture = await MediaPicker.PickPhotoAsync();
            JeansVisible = false;
            if (picture != null)
            {
            JeansPath = picture.FullPath;
            JeansVisible = true;

            staticJeansPath = picture.FullPath;
            staticJeansVisible = true;
            }


        }

    [RelayCommand]
    private async Task SetSlacks()
    {

        SlacksPath = "";
        MediaPickerOptions options = new MediaPickerOptions();

        FileResult? picture = await MediaPicker.PickPhotoAsync();
        SlacksVisible = false;
        if (picture != null)
        {
            SlacksPath = picture.FullPath;
            SlacksVisible = true;
            staticSlacksPath = picture.FullPath;
            staticSlacksVisible = true;
        }


    }

    [RelayCommand]
    private async Task SetTeeShirts()
    {

        TeeShirtsPath = "";
        MediaPickerOptions options = new MediaPickerOptions();

        FileResult? picture = await MediaPicker.PickPhotoAsync();
        TeeShirtsVisible = false;
        if (picture != null)
        {
            TeeShirtsPath = picture.FullPath;
            TeeShirtsVisible = true;


            staticTeeShirtsPath = picture.FullPath;
            staticTeeShirtsVisible = true;
        }


    }

    [RelayCommand]
    private async Task SetSuitCoat()
    {

        SuitCoatPath = "";
        MediaPickerOptions options = new MediaPickerOptions();

        FileResult? picture = await MediaPicker.PickPhotoAsync();
        SuitCoatVisible = false;
        if (picture != null)
        {
            SuitCoatPath = picture.FullPath;
            SuitCoatVisible = true;

            staticSuitCoatPath = picture.FullPath;
            staticSuitCoatVisible = true;
        }


    }


}