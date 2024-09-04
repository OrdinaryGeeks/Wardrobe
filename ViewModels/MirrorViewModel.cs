using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace Wardrobe2.ViewModels;

public partial class MirrorViewModel : ObservableObject
{

    //Observable properties to pick up values from Outfit page

	[ObservableProperty]
	ObservableCollection<string> imagePaths;

   
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

   
    
	public MirrorViewModel()
	{
		imagePath = String.Empty;
		imagePaths = new ObservableCollection<string>();
        buttonDownVisible = OutfitViewModel.staticButtonDownVisible;
        buttonDownPath= OutfitViewModel.staticButtonDownPath;
        collaredVisible = OutfitViewModel.staticCollaredVisible;
        collaredPath = OutfitViewModel.staticCollaredPath;
        jeansPath = OutfitViewModel.staticJeansPath;
        jeansVisible = OutfitViewModel.staticJeansVisible;
        teeShirtsPath = OutfitViewModel.staticTeeShirtsPath;
        teeShirtsVisible = OutfitViewModel.staticTeeShirtsVisible;
        suitCoatPath = OutfitViewModel.staticSuitCoatPath;
        suitCoatVisible = OutfitViewModel.staticSuitCoatVisible;

    }


    //unimplemented
    [RelayCommand]
    public  void Update()
    {
        
        buttonDownVisible = OutfitViewModel.staticButtonDownVisible;
        
        
        buttonDownPath = OutfitViewModel.staticButtonDownPath;
        collaredVisible = OutfitViewModel.staticCollaredVisible;
        collaredPath = OutfitViewModel.staticCollaredPath;
        jeansPath = OutfitViewModel.staticJeansPath;
        jeansVisible = OutfitViewModel.staticJeansVisible;
        teeShirtsPath = OutfitViewModel.staticTeeShirtsPath;
        teeShirtsVisible = OutfitViewModel.staticTeeShirtsVisible;
        suitCoatPath = OutfitViewModel.staticSuitCoatPath;
        suitCoatVisible = OutfitViewModel.staticSuitCoatVisible;

       // await Task.Delay(1);
        
    }



}