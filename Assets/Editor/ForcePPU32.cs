// Assets/Editor/ForcePPU32.cs
// บังคับทุกสไปรต์ที่นำเข้าให้เป็น PPU=32, Point, ไม่มี Compression
using UnityEditor;
using UnityEngine;

public class ForcePPU32 : AssetPostprocessor
{
    // เรียกอัตโนมัติทุกครั้งที่มีการ import รูปภาพใหม่
    void OnPreprocessTexture()
    {
        if (!assetPath.EndsWith(".png") && !assetPath.EndsWith(".jpg") && !assetPath.EndsWith(".jpeg"))
            return;

        var importer = (TextureImporter)assetImporter;
        importer.textureType = TextureImporterType.Sprite;
        importer.spritePixelsPerUnit = 32f;
        importer.filterMode = FilterMode.Point;
        importer.textureCompression = TextureImporterCompression.Uncompressed;
        importer.mipmapEnabled = false;
        importer.sRGBTexture = true;
        importer.wrapMode = TextureWrapMode.Clamp;
    }

    // เมนูช่วยกวาดไฟล์เก่าให้เป็น 32 PPU ทีเดียว
    [MenuItem("Tools/Art/Fix All Sprites to 32 PPU")]
    public static void FixAllSpritesTo32PPU()
    {
        string[] guids = AssetDatabase.FindAssets("t:Texture2D");
        int changed = 0;

        AssetDatabase.StartAssetEditing();
        try
        {
            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                var importer = AssetImporter.GetAtPath(path) as TextureImporter;
                if (importer == null) continue;

                if (importer.textureType == TextureImporterType.NormalMap) continue;

                importer.textureType = TextureImporterType.Sprite;
                importer.spritePixelsPerUnit = 32f;
                importer.filterMode = FilterMode.Point;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.mipmapEnabled = false;
                importer.sRGBTexture = true;
                importer.wrapMode = TextureWrapMode.Clamp;

                importer.SaveAndReimport();
                changed++;
            }
        }
        finally
        {
            AssetDatabase.StopAssetEditing();
            AssetDatabase.Refresh();
        }

        Debug.Log($"[ForcePPU32] Updated {changed} textures to PPU=32, Point, Uncompressed.");
    }
}
