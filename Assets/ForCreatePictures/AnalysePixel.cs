using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalysePixel
{
    static public Color[,] Analyse(Texture2D tex, int row, int col, int offX, int offY, int padX, int padY)
    {
        Color[,] allColors = new Color[tex.width, tex.height];
        for (int i = 0; i < tex.width; i++)
        {
            for (int j = 0; j < tex.height; j++)
            {
                Color colos = tex.GetPixel(i, tex.height - j);
                if (i == 134 && j == 84)
                {
                    Debug.Log(colos);
                }
                allColors[i, j] = tex.GetPixel(tex.width - i, tex.height - j);
            }
        }
        int width_sec = (tex.width - offX - padX * (row - 1)) / row;
        int height_sec = (tex.height - offY - padY * (col - 1)) / col;
        Debug.Log(width_sec + " " + height_sec);
        Sector[,] sectors = new Sector[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                sectors[i, j] = new Sector(offX + (height_sec + padY) * i, offY + (width_sec + padX) * j, width_sec, height_sec);
            }
        }

        Color[,] colors = new Color[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                int[] coord = sectors[i, j].GetCenter();
                colors[i, j] = allColors[coord[0], coord[1]];
                Debug.Log(colors[i, j]);
            }
        }
        return colors;
    }

    public struct Sector
    {
        public int x, y, w, h;

        public Sector(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public int[] GetCenter()
        {
            return new int[] { (x + w) / 2, (y + h) / 2 };
        }
    }
}
