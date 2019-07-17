using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzleCtrl;

    private RaycastHit emptyHit;
    private Vector3 chengeCube;
    private bool changeFlag1 = false;
    private bool changeFlag2 = false;

    public bool ChangeFlag2
    {
        get { return changeFlag2; }
    }

    // Update is called once per frame
    void Update()
    {
        if (changeFlag2 == true && changeFlag1 == true) { return; }

        Ray upRay = new Ray(transform.position, transform.forward);
        Ray downRay = new Ray(transform.position, -transform.forward);
        Ray rightRay = new Ray(transform.position, transform.right);
        Ray leftRay = new Ray(transform.position, -transform.right);

        if (transform.position != new Vector3(1.5f, 0.0f, -1.5f) && changeFlag1 == true)
        {
            int i = Random.Range(0, 4);
            if (Physics.Raycast(upRay.origin, upRay.direction, out emptyHit, Mathf.Infinity) && i == 0)
            {
                Debug.DrawRay(upRay.origin, upRay.direction, Color.red, 3.0f);
                if (emptyHit.collider.tag == "Cube")
                {
                    ChengePos();
                }
            }
            else if (Physics.Raycast(downRay.origin, downRay.direction, out emptyHit, Mathf.Infinity) && i == 1)
            {
                Debug.DrawRay(downRay.origin, downRay.direction, Color.red, 3.0f);
                if (emptyHit.collider.tag == "Cube")
                {
                    ChengePos();
                }
            }
            else if (Physics.Raycast(rightRay.origin, rightRay.direction, out emptyHit, Mathf.Infinity) && i == 2)
            {
                Debug.DrawRay(rightRay.origin, rightRay.direction, Color.red, 3.0f);
                if (emptyHit.collider.tag == "Cube")
                {
                    ChengePos();
                }
            }
            else if (Physics.Raycast(leftRay.origin, leftRay.direction, out emptyHit, Mathf.Infinity) && i == 3)
            {
                Debug.DrawRay(leftRay.origin, leftRay.direction, Color.red, 3.0f);
                if (emptyHit.collider.tag == "Cube")
                {
                    ChengePos();
                }
            }
        }
        else if (transform.position == new Vector3 (1.5f, 0.0f, -1.5f) && changeFlag1 == true)
        {
            changeFlag2 = true;
            puzzleCtrl.GetComponent<PuzzleCtrl>().GameStartChangeFlag();
        }

        if (changeFlag1 == true) { return; }



        if (this.transform.position != new Vector3 (-1.5f, 0.0f, 1.5f))
        {
            int i = Random.Range(0, 4);
            if (Physics.Raycast(upRay.origin, upRay.direction, out emptyHit, Mathf.Infinity) && i == 0)
            {
                Debug.DrawRay(upRay.origin, upRay.direction, Color.red, 3.0f);
                if (emptyHit.collider.tag == "Cube")
                {
                    ChengePos();
                }
            }
            else if (Physics.Raycast(downRay.origin, downRay.direction, out emptyHit, Mathf.Infinity) && i == 1)
            {
                Debug.DrawRay(downRay.origin, downRay.direction, Color.red, 3.0f);
                if (emptyHit.collider.tag == "Cube")
                {
                    ChengePos();
                }
            }
            else if (Physics.Raycast(rightRay.origin, rightRay.direction, out emptyHit, Mathf.Infinity) && i == 2)
            {
                Debug.DrawRay(rightRay.origin, rightRay.direction, Color.red, 3.0f);
                if (emptyHit.collider.tag == "Cube")
                {
                    ChengePos();
                }
            }
            else if (Physics.Raycast(leftRay.origin, leftRay.direction, out emptyHit, Mathf.Infinity) && i == 3)
            {
                Debug.DrawRay(leftRay.origin, leftRay.direction, Color.red, 3.0f);
                if (emptyHit.collider.tag == "Cube")
                {
                    ChengePos();
                }
            }
        }

        else { changeFlag1 = true; }
    }

    public void ChengePos()
    {
        Debug.Log("呼ばれた");
        chengeCube = transform.position;
        transform.position = emptyHit.collider.transform.position;
        emptyHit.collider.transform.position = chengeCube;
    }
}
