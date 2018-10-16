using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forSquarePrefab : MonoBehaviour {
    //材质
    public Material outline;
    public Material normal;
    public Material red;
    //碰上的时候存一个接触的位置（会抖，可能因为鼠标动的比帧更新快）
    public Vector3 lins;
    public bool push;
    //public Select other;
    public GameObject squarePrefab;
   // public GameObject square;
    public bool isSelected = false;//isSelected是一个可以由select脚本控制的性质

    void Start()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (isSelected)
        {
            //碰撞，选中，变红
            gameObject.GetComponent<Renderer  >().sharedMaterial.SetColor ("_OutlineColor",Color .red);
        }
            //记一下刚接触的位置
            lins = (gameObject.GetComponent <Rigidbody >() .position);
            push = true;

        if (push)
        {
            //记录刚碰撞的位置
            gameObject.GetComponent<Rigidbody>().MovePosition(lins);
        }
    }

    //有相交的时候把正在移动的物体推出来变成相邻的
    void OnCollisionStay(Collision collision)
    {
        
        if (push)
        {
            if (isSelected )
            {
                //红色描边
                this .GetComponent<Renderer >().sharedMaterial  .SetColor ("_OutlineColor",Color .red );
            }
                //移动回接触的位
                gameObject.GetComponent <Rigidbody >().MovePosition(lins);
                return;
        }
    }

    //不相交了换成普通描边
    void OnCollisionExit(Collision collision)
    {
        if (isSelected )
        {
            this .GetComponent<Renderer >().sharedMaterial  .SetColor ("_OutlineColor",Color .blue );
        }
        push = false;
    }

    void Update()
    {

    }

}
