using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D mapTexture;
    public PixelToObject[] pixelColourMappings;
    private Color pixelColour;
    
    void Start()
    {
        GenerateLevel();

    }

  void GenerateLevel()
    {
        for (int i = 0; i < mapTexture.width; i++)
        {
            for (int j = 0; i < mapTexture.height; j++)
            {
              GenerateObject (i, j);
            }
        }
    }
    
    void GenerateObject(int x, int y)
    {
        pixelColour = mapTexture.GetPixel(x, y);
        if (pixelColour.a == 0)
        {
            return;
            
        }
        
        foreach (PixelToObject pixelColourMapping in pixelColourMappings)
        {
            if (pixelColourMapping.pixelColour.Equals (pixelColour))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(pixelColourMapping.prefab, position, Quaternion.identity, transform);
            }
        }
        
    }
}
