using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryController : MonoBehaviour
{
    private static GameObject nowLoading;

    public static GameObject NowLoading
    {
        get { return nowLoading; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        nowLoading = gameObject;

        DontDestroyOnLoad(gameObject);
    }
}
