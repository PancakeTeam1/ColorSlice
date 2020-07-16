using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameImageLoader : MonoBehaviour
{
    public Color[,] NotNormalizedColors;
    public List<Color> NormalizedColors;

    public Texture2D Texture;
    public int RowSize;
    public int ColumnSize;
    public int OffsetX;
    public int OffsetY;
    public int PaddingX;
    public int PaddingY;

    public float MaxDifference = 0.15f;

    public void CreatePicture()
    {
        NotNormalizedColors = AnalysePixel.Analyse(Texture, RowSize, ColumnSize, OffsetX, OffsetY, PaddingX, PaddingY);

        for(int row = 0; row < RowSize; row++)
        {
            for(int column = 0; column < ColumnSize; column++)
            {
                // Check is it new color or not
                bool foundBaseColor = false;
                Color CurrentColor = NotNormalizedColors[row, column];
                Color BaseColorFound = CurrentColor;
                foreach(Color BaseColor in NormalizedColors)
                {
                    if(CalculateDistanceBetweenColors(BaseColor, CurrentColor) < MaxDifference)
                    {
                        foundBaseColor = true;
                        BaseColorFound = BaseColor;
                        break;
                    }
                }
                if(foundBaseColor)
                {
                    NotNormalizedColors[row, column] = BaseColorFound;
                }
                else
                {
                    NormalizedColors.Add(CurrentColor);
                }
            }
        }
        //DebugColors();
    }
       
    public float CalculateDistanceBetweenColors(Color BaseColor, Color CompareColor)
    {
        float R = BaseColor.r - CompareColor.r;
        float G = BaseColor.g - CompareColor.g;
        float B = BaseColor.b - CompareColor.b;

        float D = (Mathf.Sqrt(R * R + G * G) + Mathf.Sqrt(G * G + B * B) + Mathf.Sqrt(B * B + R * R)) / 3;
        return D;
    }

    public void DebugColors()
    {
        for (int row = 0; row < RowSize; row++)
        {
            for (int column = 0; column < ColumnSize; column++)
            {
                Debug.Log(NotNormalizedColors[row, column]);
            }
        }
    }
}
