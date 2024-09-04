using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.IO;

namespace Wardrobe2.ViewModels;

public partial class MainViewModel : ObservableObject
{

	[ObservableProperty]
	ObservableCollection<string> imagePaths;

	[ObservableProperty]
	string imagePath;
	public MainViewModel()
	{
		imagePath = String.Empty;
		imagePaths = new ObservableCollection<string>();
	}

    /// <summary>
    /// If selected a radio button for clothes Items then select pictures featuring that clothes item. If not, show all pictures
    /// </summary>
    /// <returns></returns>

    [RelayCommand]
     private async Task  PickPhoto()
    {

        string[] files  = Directory.GetFiles(FileSystem.CacheDirectory);
        ImagePaths.Clear();

        List<string> filesResultFromSearch = new List<string>();
        foreach(string file in files)
        {
            if (file.Contains(MainPage.clothesItem))
            {
                ImagePaths.Add(Path.Combine(FileSystem.CacheDirectory,file));
            }
        }
       
    }

    /// <summary>
    /// Add a picture from library into the category selected for clothes item
    /// </summary>
    /// <returns></returns>

    [RelayCommand]
	private async Task Add()
	{


        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {

                string[] files = Directory.GetFiles(FileSystem.CacheDirectory);

                int indexCount = 1;
                int indexFound = 0;
                foreach (string file in files)
                {
                    if (file.Contains(MainPage.clothesItem))
                    {
                        if (file.Length - (file.IndexOf(MainPage.clothesItem) + MainPage.clothesItem.Length + 4) > 0)
                        {
                            int startSub = file.IndexOf(MainPage.clothesItem) + MainPage.clothesItem.Length;
                            int periodIndex = file.LastIndexOf(".");

                            int subLength = periodIndex - startSub;
                            int foundIndex = int.Parse(file.Substring(startSub, subLength));

                            if (foundIndex > indexFound)
                                indexFound = foundIndex;

                        }
                    }

                }
                indexFound++;

                string localFilePath = Path.Combine(FileSystem.CacheDirectory, MainPage.clothesItem + indexFound.ToString() + ".jpg");


                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);


                ImagePaths.Add(localFilePath);

                if (string.IsNullOrWhiteSpace(ImagePath))
                    return;

                ImagePath = string.Empty;



                ///THis code was to be used later for android builds
                /*

#if ANDROID
                                var context = Platform.CurrentActivity;

                                if (OperatingSystem.IsAndroidVersionAtLeast(29))
                                {
                                    Android.Content.ContentResolver resolver = context.ContentResolver;
                                    Android.Content.ContentValues contentValues = new();
                                    contentValues.Put(Android.Provider.MediaStore.IMediaColumns.DisplayName, "image.png");
                                    contentValues.Put(Android.Provider.MediaStore.IMediaColumns.MimeType, "image/png");
                                    contentValues.Put(Android.Provider.MediaStore.IMediaColumns.RelativePath, "DCIM/wardrobe/" + "image");
                                    Android.Net.Uri imageUri = resolver.Insert(Android.Provider.MediaStore.Images.Media.ExternalContentUri, contentValues);

                                    var os = resolver.OpenOutputStream(imageUri);
                                    Android.Graphics.BitmapFactory.Options options = new();
                                    options.InJustDecodeBounds = true;
                                    var bitmap = Android.Graphics.BitmapFactory.DecodeStream(stream);
                                    bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 100, os);
                                    os.Flush();
                                    os.Close();
                                }
                                else
                                {
                                    Java.IO.File storagePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                                    string path = System.IO.Path.Combine(storagePath.ToString(), "image.png");
                                    System.IO.File.WriteAllBytes(path, memoryStream.ToArray());
                                    var mediaScanIntent = new Android.Content.Intent(Android.Content.Intent.ActionMediaScannerScanFile);
                                    mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(path)));
                                    context.SendBroadcast(mediaScanIntent);
                                }

#endif
                */







            }
        }

        
      
	}

    //Unimplemented
	[RelayCommand]
	void Delete(string s)
	{
		if(ImagePaths.Contains(s))
		{
			ImagePaths.Remove(s);
		}
	}

}