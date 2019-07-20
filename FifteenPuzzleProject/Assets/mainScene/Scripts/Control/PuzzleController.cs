using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    private GameObject[] cubesList = new GameObject[16];
    private Vector3[] nowCubesPos = new Vector3[16];

    private Vector3[] cubesPos = new Vector3[16];
    private int truePos;

    private List<int> cubeNumsList = new List<int>();

    private Vector3 cubePos;
    private Vector3 emptyPos;

    private int chengeNum;

    private bool endGame = false;

    private GameObject sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = SceneController.SceneGameObject;

        for (int i = 0; i < 16; i++)
        {
            cubesList[i] = transform.GetChild(i).gameObject;
            cubesPos[i] = cubesList[i].transform.position;
        }

        cubeNumsList = Enumerable.Range(0, 16).ToList();
        foreach (var obj in cubeNumsList.Select((item, index) => new { item, index }))
        {
            cubesList[obj.item].GetComponent<CubeController>().PanelNumber = obj.item;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cubesList[15].GetComponent<EmptyController>().ChangeFlag2 == false || endGame == true) { return; }

        truePos = 0;

        for (int i = 0; i < 16; i++)
        {
            nowCubesPos[i] = cubesList[i].transform.position;
            if (cubesPos[i] == nowCubesPos[i])
            {
                truePos++;
            }
        }

        if (truePos == 16)
        {
            Debug.Log("Game Clear");
            for (int i = 0; i < 16; i++)
            {
                cubesList[i].GetComponent<CubeController>().GameEnd = true;
                endGame = true;

                sceneManager.GetComponent<SceneController>().ChangeScene();
            }
        }

    }

    public void GameStartChangeFlag()
    {
        for (int i = 0; i < 16; i++)
        {
            cubesList[i].GetComponent<CubeController>().GameStart = true;
        }
    }
}
