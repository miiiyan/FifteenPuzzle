using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCtrl : MonoBehaviour
{
    private GameObject cube;
    private GameObject empty15;

    private Vector3 cubePos;
    private float cubePosX;
    private float cubePosZ;

    private int[] cubeNmb;

    // Start is called before the first frame update
    void Start()
    {
        cubePos = cube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue
            if(Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {

            }
        }
        
    }

    public void PosChenge (int x, int z)
    {
        int pos1 = z * 4 + x;
        int pos2 = -1;
        if (x > 0 && cubeNmb[pos1 - 1] == 15) pos2 = pos1 - 1;
        if (x < 3 && cubeNmb[pos1 + 1] == 15) pos2 = pos1 + 1;
        if (z > 0 && cubeNmb[pos1 - 1] == 15) pos2 = pos1 - 4;
        if (z < 3 && cubeNmb[pos1 + 1] == 15) pos2 = pos1 + 4;
        if (pos2 != -1)
        {
            cubePos = new Vector3(cubePosX, cubePos.y, cubePosZ);
            cube.transform.position = cubePos;
        }
    }
}
