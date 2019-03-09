using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //回転を開始する角度を設定
        this.transform.Rotate(0,Random.Range(0,360),0);
        //このScriptの関数transformの関数Rotateに、(ﾛｰｶﾙ座標で)x軸周りにに０°、Y軸周りにRandom数、z軸周りに0°回転させろ
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 3, 0);
    }
}
