using UnityEngine;
using System.Collections.Generic;

public class UVWizard : MonoBehaviour
{
    public int textureAtlasSize = 2048;

    private Mesh mesh;
    private MeshRenderer meshRenderer;
    private Material[] originalMaterials;
    private Rect[] uvRects;
    private Texture2D textureAtlas;
    private Material newMaterial;

    public void CombineMaterials()
    {
        GetMeshAndMaterials();

        if (mesh == null || originalMaterials == null)
        {
            Debug.LogError("Failed to get mesh or materials.");
            return;
        }

        CreateTextureAtlas();
        RepackUVs();
        CreateNewMaterial();
        ApplyNewMaterial();

        Debug.Log("Materials combined successfully!");
    }

    private void GetMeshAndMaterials()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshFilter == null || meshRenderer == null)
        {
            Debug.LogError("UVWizard requires a MeshFilter and MeshRenderer.");
            return;
        }

        // Duplicate the mesh to avoid modifying the original asset
        mesh = Instantiate(meshFilter.sharedMesh);
        meshFilter.mesh = mesh;

        originalMaterials = meshRenderer.sharedMaterials;
    }

    private void CreateTextureAtlas()
    {
        int count = originalMaterials.Length;
        Texture2D[] textures = new Texture2D[count];

        // Collect textures from materials
        for (int i = 0; i < count; i++)
        {
            Texture2D tex = (Texture2D)originalMaterials[i].mainTexture;

            if (tex == null)
            {
                tex = Texture2D.whiteTexture;
            }

            // Ensure texture is readable
            if (!tex.isReadable)
            {
                Debug.LogWarning($"Texture '{tex.name}' is not readable. Setting it to readable.");
                SetTextureReadable(tex);
            }

            textures[i] = tex;
        }

        // Create the atlas
        textureAtlas = new Texture2D(textureAtlasSize, textureAtlasSize);
        uvRects = textureAtlas.PackTextures(textures, 0, textureAtlasSize);
    }

    private void RepackUVs()
    {
        Vector2[] uvs = mesh.uv;

        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] triangles = mesh.GetTriangles(i);
            Rect rect = uvRects[i];

            foreach (int index in triangles)
            {
                Vector2 uv = uvs[index];

                // Scale and offset UVs to fit in the assigned rectangle
                uv = new Vector2(
                    rect.x + uv.x * rect.width,
                    rect.y + uv.y * rect.height
                );

                uvs[index] = uv;
            }
        }

        mesh.uv = uvs;
    }

    private void CreateNewMaterial()
    {
        newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.mainTexture = textureAtlas;
    }

    private void ApplyNewMaterial()
    {
        meshRenderer.material = newMaterial;
    }

    private void SetTextureReadable(Texture2D tex)
    {
#if UNITY_EDITOR
        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(tex);
        var textureImporter = (UnityEditor.TextureImporter)UnityEditor.AssetImporter.GetAtPath(assetPath);
        textureImporter.isReadable = true;
        UnityEditor.AssetDatabase.ImportAsset(assetPath);
#else
        Debug.LogError("Cannot set texture to readable at runtime.");
#endif
    }
}
