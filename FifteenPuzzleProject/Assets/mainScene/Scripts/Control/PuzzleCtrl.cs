using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleCtrl : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cubesList = new List<GameObject>();

    private List<int> cubeNumsList = new List<int>();

    private Vector3 cubePos;
    private Vector3 emptyPos;

    private int chengeNum;

    // Start is called before the first frame update
    void Start()
    {
        cubeNumsList = Enumerable.Range(0, 16).ToList();
        foreach (var obj in cubeNumsList.Select((item, index) => new { item, index }))
        {
            cubesList[obj.item].GetComponent<CubeCtrl>().PanelNumber = obj.item;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PosChenge (int x, int z)
    {
        int pos1 = z * 4 + x;
        int pos2 = -1;
        if (x > 0 && cubeNumsList[pos1 - 1] == 15) pos2 = pos1 - 1;
        if (x < 3 && cubeNumsList[pos1 + 1] == 15) pos2 = pos1 + 1;
        if (z > 0 && cubeNumsList[pos1 - 1] == 15) pos2 = pos1 - 4;
        if (z < 3 && cubeNumsList[pos1 + 1] == 15) pos2 = pos1 + 4;
        if (pos2 != -1)
        {
            cubePos = new Vector3(emptyPos.x, cubePos.y, cubePos.z);
            cubesList[pos1].transform.position = cubePos;
        }
    }
}
