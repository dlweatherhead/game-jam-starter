using UnityEngine;
using UnityEditor;

public class MaterialGeneratorWindow : EditorWindow
{
    private Color[] ColorList = new Color[5];

    private MaterialCreator MaterialCreator;
    private ColorMindAPI ColorMindAPI;

    [MenuItem("Tools/Show Material Generator Window")]
    public static void ShowWindow()
    {
        GetWindow<MaterialGeneratorWindow>(false, "Material Generator", true);
    }

    void OnEnable()
    {
        MaterialCreator = new MaterialCreator();
        ColorMindAPI = new ColorMindAPI();
    }

    void OnGUI()
    {        
        for(int i=0; i<ColorList.Length; i++)
        {
            ColorList[i] = EditorGUILayout.ColorField("Color " + i, ColorList[i]);
        }

        GUILayout.Space(25);

        if (GUILayout.Button("Random Palette"))
        {
            GenerateRandomPalette();
        }

        if (GUILayout.Button("Fetch Palette - Colormind API"))
        {
            var response = ColorMindAPI.GetRandomColorPaletteRawResponse();
            ColorList = response.colors;
        }

        GUILayout.Space(25);

        if (GUILayout.Button("Generate Materials from Colors"))
        {
            MaterialCreator.CreateMaterials(ColorList, "Material ");
        }

        if (GUILayout.Button("Create Texture Samples Per Color"))
        {
            for(int i = 0; i < ColorList.Length; i++)
            {
                var textureSampleCreator = new TextureCreator();
                textureSampleCreator.CreateTexture(ColorList[i], "mat" + i);
            }
            AssetDatabase.Refresh();
        }
    }

    private void GenerateRandomPalette()
    {
        for(int i=0; i<ColorList.Length; i++)
        {
            ColorList[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
    }
}
