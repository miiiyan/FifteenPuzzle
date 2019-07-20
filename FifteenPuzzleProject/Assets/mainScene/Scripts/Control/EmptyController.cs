using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmptyController : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzleController;

    private RaycastHit emptyHit;
    private Vector3 chengeCube;
    private bool changeFlag1 = false;
    private bool changeFlag2 = false;

    private GameObject nowLoading;

    public bool ChangeFlag2
    {
        get { return changeFlag2; }
    }

    void Start()
    {
        nowLoading = DontDestoryController.NowLoading;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム開始時シャッフル
        if (changeFlag2 == true && changeFlag1 == true) { return; }

        Ray upRay = new Ray(transform.position, transform.forward);
        Ray downRay = new Ray(transform.position, -transform.forward);
        Ray rightRay = new Ray(transform.position, transform.right);
        Ray leftRay = new Ray(transform.position, -transform.right);

        //左上になるまでシャッフル
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
            puzzleController.GetComponent<PuzzleController>().GameStartChangeFlag();
            nowLoading.SetActive(false);
        }

        if (changeFlag1 == true) { return; }


        //右下になるまでシャッフル
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
