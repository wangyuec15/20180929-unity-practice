using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aclass : MonoBehaviour {
    //设定空间大小
     int width=15;
     int height=8;
     int length=15;
    float spacing = 1;
    //组件
    public GameObject brickPrefab;
    public GameObject squarePrefab;
    public GameObject floorPrefab;
    public GameObject[] square;
    //public GameObject emmm;
    //底面方块的数量
    public int num;
    //组件转动（其实没转）
    //private GameObject[] e;
    //private int i = 0;
    Quaternion arot = Quaternion.identity;
 
 	void Start () {
        //e = new GameObject[200];
        //Instantiate(emmm).GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        //下面这行是不用从inspector拖动的找原来物体的方法
        //squarePrefab=Resources.Load<GameObject>("square");
        //建空间
        for (int j = 0; j < height; j++)
        {
            if(j==0){//地面用没有collider的和墙分开，否则就会一直识别碰撞
                for (int i = 0; i < width; i++)
                {
                    for (int k = 0; k < length; k++)
                    {
                        Vector3 apos = new Vector3(i * spacing, j * spacing, k * spacing);
                        GameObject currentVoxel = Instantiate(floorPrefab, apos, arot);
                    }
                }
            }else{
                for (int i = 0; i < width; i++)
                {
                        for (int k = 0; k < length; k++)
                        {
                        if(i==0||i==width-1||k==0||k==length-1){
                            Vector3 apos = new Vector3(i * spacing, j * spacing, k * spacing);
                            GameObject currentVoxel = Instantiate(brickPrefab, apos, arot);

                        } 
                    }
                }
            }
        }


        //随机生成方块
        num = Random.Range(3, 5);

        int[] x = new int [num];
        int[] z = new int[num];
        GameObject[] square = new GameObject[num];

        for (int i = 0; i < num;i++){
            x[i] = Random.Range(1 , width - 1 );
            z[i] = Random.Range(1 , length - 1);
            Vector3[] a = new Vector3[num];
            a[i] = new Vector3(x[i]*spacing , 1f * spacing, z[i]*spacing );
            square[i] = Instantiate(squarePrefab, a[i], arot);
        }
	}


    //////以下是练习生命周期的变态造物2333333
   /* void FixedUpdate()
    {
        
            e[i] = Instantiate(emmm, 5f*Vector3.right+5f*Vector3.forward+2f*Vector3 .up   , arot);
            e[i].GetComponent<Rigidbody>().AddForce(0.0000001f*  Vector3.up+Vector3.right );
        i += 1;
        if(i==200){
            for (int i = 0; i < 200;i++){
                Destroy(e[i]);
            }
            e = new GameObject[200];
            i = 0;
        }
    }
    void OnDisable()
    {
        print("233333");
        //Instantiate(emmm).GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
    void OnDistroy()
    {
        print("233333");

        e[50].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
        {
            print("You clicked the button!");
            Instantiate(emmm).GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

        }
    }*/
}