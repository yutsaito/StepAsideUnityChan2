using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unityちゃんのｵﾌﾞｼﾞｪｸﾄ
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        //unitychan = GameObject.Find("UnityChan"); // thisがないとダメ？
        this.unitychan = GameObject.Find("unitychan");

        //Unityちゃんとカメラの位置(z座標)の差を求める
        difference = unitychan.transform.position.z - this.transform.position.z;   
            //ピタゴラスで計算するのだろうと考え、メンドくさ、と思ってしまった。Z座標だけでよかった
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてカメラの位置を移動
        //this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + difference);
        //惜しかった
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
