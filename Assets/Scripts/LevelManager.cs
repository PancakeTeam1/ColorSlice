using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Manager<LevelManager>
{
    public string Scene = "ForMarat";
    public float CompositionKoef = 0.7f;
    public float MultyplierKoef = 0.7f;
    private int count1 = 2;
    private int count2 = 5;
    private float square1 = 0.1f;
    private int square2;
    [HideInInspector] public int Level = 0;
    [HideInInspector] public List<InGameImageLoader.Picture> remainingPictures;
    [HideInInspector] public InGameImageLoader.Picture currentPicture;
    private InGameImageLoader imageLoader;

    private void Awake()
    {
        imageLoader = InGameImageLoader.Instance;
        DontDestroyOnLoad(gameObject);
        remainingPictures = new List<InGameImageLoader.Picture>(imageLoader.PixArts);
        currentPicture = remainingPictures[2];
        //currentPicture = remainingPictures[Random.Range(0, remainingPictures.Count)];
    }

    private void NextLevel()
    {
        Level += 1;
        remainingPictures.Remove(currentPicture);
        if (remainingPictures.Count == 0)
        {
            remainingPictures = new List<InGameImageLoader.Picture>(imageLoader.PixArts);
        }
        currentPicture = remainingPictures[Random.Range(0, remainingPictures.Count)];
        SceneManager.LoadScene(Scene);
    }

    private void SetAreas()
    {
        int[,] sides = GetRandomAreas(Random.Range(count1, count2), Random.Range((int)(currentPicture.RowSize * square1), (int)(currentPicture.ColumnSize * square2)));

    }

    private int[,] GetRandomAreas(int count, int square)
    {
        float[] multyples = new float[count];
        int[,] sides = new int[count, 2];
        float squareMore = square;
        for (int i = 0; i < count; i++)
        {
            multyples[i] = Random.Range(squareMore / (count - i) * CompositionKoef, squareMore / (count - i) * (1 - CompositionKoef));
            squareMore -= multyples[i];
        }
        for (int i = 0; i < count; i++)
        {
            float x = Mathf.Sqrt(multyples[i]);
            x = Random.Range(x * MultyplierKoef, x * MultyplierKoef);
            sides[i, 0] = (int)Mathf.Round(x);
            sides[i, 1] = (int)Mathf.Round(multyples[i] / x);
        }
        return sides;
    }
}
