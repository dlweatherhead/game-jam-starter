using UnityEngine;
using UnityEditor;

public class MaterialCreator
{
    private const string AssetsFolderName = "Assets";
    private const string MaterialsFolderName = "Materials";
    private const string FolderSeparator = "/";

    private string PathToMaterialsContents
    {
        get { return PathToMaterialsDirectory + FolderSeparator; }
    }

    private string PathToMaterialsDirectory
    {
        get { return AssetsFolderName + FolderSeparator + MaterialsFolderName; }
    }

    public MaterialCreator()
    {
        if(!AssetDatabase.IsValidFolder(PathToMaterialsDirectory))
        {
            AssetDatabase.CreateFolder(AssetsFolderName, MaterialsFolderName);
        }
    }

    public void CreateMaterials(Color[] colors, string baseName)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            CreateMaterial(colors[i], baseName + i);
        }
    }

    public void CreateMaterial(Color color, string name)
    {
        Material material = new Material(Shader.Find("Standard"))
        {
            color = color
        };

        AssetDatabase.CreateAsset(material, PathToMaterialsContents + name + ".mat");
    }
}