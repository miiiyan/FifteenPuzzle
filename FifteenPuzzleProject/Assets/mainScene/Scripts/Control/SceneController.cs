using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Scene nowScene;
    private int nextScene = 1;

    private GameObject nowLoading;

    private static GameObject thisGameObject;
    public static GameObject SceneGameObject
    {
        get { return thisGameObject; }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        nowLoading = DontDestoryController.NowLoading;
        nowLoading.SetActive(false);

        nowScene = SceneManager.GetActiveScene();
    }

    public void ChangeScene()
    {
        if (nowScene != SceneManager.GetSceneByBuildIndex(nextScene))
        {
            SceneManager.LoadScene(nextScene);
            nextScene++;
        }

        nowScene = SceneManager.GetActiveScene();

        nowLoading.SetActive(true);
    }
}
