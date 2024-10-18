using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class ImageSetter
{

    public Image GetPictureBoxImage(string imageName)
    {
        Image image = null;
        try
        {
            var assembly = AppDomain.CurrentDomain.BaseDirectory;
            var resourcePath = Path.Combine(assembly, "Images", imageName);

            image = Image.FromFile(resourcePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading the image: {ex.Message}");
        }
        return image;
    }


}
