using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    static Select Select_this;
    public Select Instance = null;

    //鼠标点击的位置和方块定位点之间的距离
    private Vector3 offset;
    //有没有点中
    private bool isClickCube;
    //屏幕坐标（？因为鼠标点在二维面不会出现第三个坐标？）
    private Vector3 targetScreenPoint;
    public GameObject square;
    public Material outline;
    public Material normal;

	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        // if (push) { return; }
        //点击时的情况
        if (Input.GetMouseButtonDown(0))
        {

            if(square !=null){

                square.GetComponent<Renderer>().material =normal  ;
                normal.SetColor("_OutlineColor", Color.blue);
                square.GetComponent<forSquarePrefab>().isSelected = false ;

            }
            
            if (CheckGameObject())
            {
                //记下鼠标和方块位置之间的距离，如果没有这个，就会点到方块边上的时候立刻跑到中心的位置
                offset = square .GetComponent <Rigidbody >() . position   - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
            }

        }
        //如果判断点到物体了
        if (isClickCube)
        {
            //记下鼠标在屏幕上的位置
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z);
            //转换成在三维空间的位置
            Vector3 curWorldPoint = Camera.main.ScreenToWorldPoint(curScreenPoint);
            //Debug.Log(curWorldPoint);
            square.GetComponent <Rigidbody >() .MovePosition ( curWorldPoint + offset);

        }
        //鼠标抬起来，不移动了
        if (Input.GetMouseButtonUp(0))
        {
            isClickCube = false;
        }

        Vector3 w = new Vector3(0, 0, 0.05f);
        Vector3 a = new Vector3(-0.05f,0,0);
        Vector3 s = new Vector3(0, 0, -0.05f);
        Vector3 d = new Vector3(0.05f,0,0);


        if (Input .GetKey (KeyCode .W  )){
            square.GetComponent<Rigidbody >() .MovePosition (square .GetComponent <Rigidbody >(). position +=w);
        }
        if (Input.GetKey(KeyCode.S ))
        {
            square.GetComponent<Rigidbody>().MovePosition(square.GetComponent<Rigidbody>().position += s);
        }
        if (Input.GetKey(KeyCode.A ))
        {
            square.GetComponent<Rigidbody>().MovePosition(square.GetComponent<Rigidbody>().position += a);
        }
        if (Input.GetKey(KeyCode.D ))
        {
            square.GetComponent<Rigidbody>().MovePosition(square.GetComponent<Rigidbody>().position += d);
        }

    }


    //判断有没有点到方块
    bool CheckGameObject()
    {
        //网上找的，好像是说从摄像机到鼠标发一下射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //可以收射线碰到的信息
        RaycastHit hitInfo;
        //如果碰到collider就会回true
        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            
            isClickCube = true;
            if (square != null) 
            {
                //记下选择的方块在屏幕的位置
                targetScreenPoint = Camera.main.WorldToScreenPoint(hitInfo.rigidbody.position);
            }

            square = hitInfo.collider.gameObject;
            hitInfo.rigidbody.GetComponent<Renderer>().material =outline;
            square.GetComponent<forSquarePrefab>().isSelected = true;

            return true;
        }
        //射线没有碰到collider就是没有选中
        square.GetComponent<forSquarePrefab>().isSelected = false ;

        return false;
    
  
	}
}
