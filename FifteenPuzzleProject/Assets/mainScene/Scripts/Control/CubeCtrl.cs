using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCtrl : MonoBehaviour
{
    private int panelNumber = 0;
    public int PanelNumber
    {
        get { return panelNumber; }
        set { panelNumber = value; }
    }

    private Vector3 chengeCube;

    private RaycastHit emptyHit = new RaycastHit();

    private bool gameStart = false;
    public bool GameStart
    {
        get { return gameStart; }
        set { gameStart = value; }
    }
    private bool gameEnd = false;
    public bool GameEnd
    {
        set { gameEnd = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd == true) { return; }
        if (gameStart == false) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log(panelNumber);

                    Ray upRay = new Ray(hit.transform.position, hit.transform.forward);
                    Ray downRay = new Ray(hit.transform.position, -hit.transform.forward);
                    Ray rightRay = new Ray(hit.transform.position, hit.transform.right);
                    Ray leftRay = new Ray(hit.transform.position, -hit.transform.right);

                    if (Physics.Raycast(upRay.origin, upRay.direction, out emptyHit, Mathf.Infinity))
                    {
                        Debug.DrawRay(upRay.origin, upRay.direction, Color.red, 3.0f);
                        if (emptyHit.collider.tag == "Empty")
                        {
                            Debug.Log("Hit Up");
                            ChengePos();
                        }
                    }
                    if (Physics.Raycast(downRay.origin, downRay.direction, out emptyHit, Mathf.Infinity))
                    {
                        Debug.DrawRay(downRay.origin, downRay.direction, Color.red, 3.0f);
                        if (emptyHit.collider.tag == "Empty")
                        {
                            Debug.Log("Hit Down");
                            ChengePos();
                        }
                    }
                    if (Physics.Raycast(rightRay.origin, rightRay.direction, out emptyHit, Mathf.Infinity))
                    {
                        Debug.DrawRay(rightRay.origin, rightRay.direction, Color.red, 3.0f);
                        if (emptyHit.collider.tag == "Empty")
                        {
                            Debug.Log("Hit Right");
                            ChengePos();
                        }
                    }
                    if (Physics.Raycast(leftRay.origin, leftRay.direction, out emptyHit, Mathf.Infinity))
                    {
                        Debug.DrawRay(leftRay.origin, leftRay.direction, Color.red, 3.0f);
                        if (emptyHit.collider.tag == "Empty")
                        {
                            Debug.Log("Hit Left");
                            ChengePos();
                        }
                    }
                    else
                    {
                        Debug.Log("失敗");
                    }
                }
            }
        }
    }

    public void ChengePos()
    {
        chengeCube = transform.position;
        transform.position = emptyHit.collider.transform.position;
        emptyHit.collider.transform.position = chengeCube;
    }
}

