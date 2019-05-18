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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                    RaycastHit emptyHit = new RaycastHit();
                    Ray upRay = new Ray(hit.transform.position, hit.transform.forward);
                    Ray downRay = new Ray(hit.transform.position, -hit.transform.forward);
                    Ray rightRay = new Ray(hit.transform.position, hit.transform.right);
                    Ray leftRay = new Ray(hit.transform.position, -hit.transform.right);
                    Debug.DrawRay(downRay.origin, downRay.direction, Color.red, 20.0f); 

                    if (Physics.Raycast(upRay.origin, upRay.direction, out emptyHit, Mathf.Infinity))
                    {
                        if(emptyHit.collider.tag == "Empty15")
                        {
                            chengeCube = transform.position;
                            transform.position = emptyHit.collider.transform.position;
                            emptyHit.collider.transform.position = chengeCube;
                        }
                        else
                        {
                            Debug.Log("失敗");
                        }
                    }
                    else if (Physics.Raycast(downRay.origin, downRay.direction, out emptyHit, Mathf.Infinity))
                    {
                        if (emptyHit.collider.tag == "Empty15")
                        {
                            Debug.Log("Hit");
                            chengeCube = transform.position;
                            transform.position = emptyHit.collider.transform.position;
                            emptyHit.collider.transform.position = chengeCube;
                        }
                    }
                    else if (Physics.Raycast(rightRay.origin, rightRay.direction, out emptyHit, Mathf.Infinity))
                    {
                        if (emptyHit.collider.tag == "Empty15")
                        {
                            chengeCube = transform.position;
                            transform.position = emptyHit.collider.transform.position;
                            emptyHit.collider.transform.position = chengeCube;
                        }
                    }
                    else if (Physics.Raycast(leftRay.origin, leftRay.direction, out emptyHit, Mathf.Infinity))
                    {
                        if (emptyHit.collider.tag == "Empty15")
                        {
                            emptyHit.collider.transform.position = chengeCube;

                        }
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
