using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Manager<LevelManager>
{
    [HideInInspector] public int Level = 0;
    public string Scene = "ForMarat";
    [HideInInspector] public List<InGameImageLoader.Picture> remainingPictures;
    [HideInInspector] public InGameImageLoader.Picture currentPicture;
    private InGameImageLoader imageLoader;

    private void Awake()
    {
        imageLoader = InGameImageLoader.Instance;
        DontDestroyOnLoad(gameObject);
        remainingPictures = new List<InGameImageLoader.Picture>(imageLoader.PixArts);
        currentPicture = remainingPictures[Random.Range(0, remainingPictures.Count)];
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
}
