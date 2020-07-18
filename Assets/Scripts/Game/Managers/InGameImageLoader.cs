using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameImageLoader : MonoBehaviour
{
    public List<Texture2D> Texture;
    public List<int> RowSize;
    public List<int> ColumnSize;
    public List<int> OffsetX;
    public List<int> OffsetY;
    public List<int> PaddingX;
    public List<int> PaddingY;

    public float MaxDifference = 0.15f;
    public int NumberOfCurrentPicture = 0;
    private List<Color> NormalizedColors;

    public Color[,] CreatePicture(int NumberOfPicture)
    {
        int CurrentRowSize = RowSize[NumberOfPicture];
        int CurrentColumnSize = ColumnSize[NumberOfPicture];
        NormalizedColors.Clear();
        NormalizedColors = new List<Color>();
        Color[,] NotNormalizedColors = AnalysePixel.Analyse(Texture[NumberOfPicture], CurrentRowSize, CurrentColumnSize, OffsetX[NumberOfPicture], OffsetY[NumberOfPicture], PaddingX[NumberOfPicture], PaddingY[NumberOfPicture]);

        for(int row = 0; row < CurrentRowSize; row++)
        {
            for(int column = 0; column < CurrentColumnSize; column++)
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
        return NotNormalizedColors;
    }
       
    public List<Color> GetAllColors()
    {
        return NormalizedColors;
    }

    public float CalculateDistanceBetweenColors(Color BaseColor, Color CompareColor)
    {
        float R = BaseColor.r - CompareColor.r;
        float G = BaseColor.g - CompareColor.g;
        float B = BaseColor.b - CompareColor.b;

        float D = (Mathf.Sqrt(R * R + G * G) + Mathf.Sqrt(G * G + B * B) + Mathf.Sqrt(B * B + R * R)) / 3;
        return D;
    }
}
