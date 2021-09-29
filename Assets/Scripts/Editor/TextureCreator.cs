using UnityEngine;
using System.IO;

public class TextureCreator
{
    public void CreateTexture(Color color, string name)
    {
        var texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
        texture.filterMode = FilterMode.Point;
        texture.SetPixel(1, 1, color);
        texture.Apply();

        File.WriteAllBytes(Application.dataPath + "/Materials/SampleTexture_" + name + ".png", 
            texture.EncodeToPNG());
    }

    public void CreateTexture(Color[] palette)
    {
        int width = 4;
        int height = 4;

        Color[] newPalette = new Color[height * width];

        for (int i = 0; i < palette.Length; i++)
        {
            newPalette[i] = palette[i];
        }

        var texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        texture.filterMode = FilterMode.Point;
        texture.SetPixels(newPalette);
        texture.Apply();

        File.WriteAllBytes(Application.dataPath + "/Materials/SampleTexture_Palette.png",
            texture.EncodeToPNG());
    }
}
