using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる  この最初の領域で宣言したものは、後で、Inspectorから設定することができる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //ｱｲﾃﾑを出すx方向の範囲
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
       //一定の距離ごとにアイテムを生成
       for(int i=startPos; i<goalPos; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //ｺｰﾝをｘ軸方向に一直線に生成
                for(float j=-1; j<=1; j += 0.4f)        //floatでfor文をつくるのは知らなかった
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    // 「Instantiate () as GameObject」は、()内に指定したPrefabのインスタンスをGameObject型として生成します。また生成したインスタンスは、GameObject型の変数に代入します。
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //ｺｰﾝでない場合は、ﾚｰﾝごとにアイテムを生成
                for(int j = -1; j <= 1; j++)        //今度はint ﾚｰﾝは3ﾚｰﾝなので-1,0,1で対応
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定（ﾚｰﾝに沿った方向にも幅を持たせる）
                    int offsetZ = Random.Range(-5, 6);
                    //60% ｺｲﾝ配置：30％車、10%何もなし
                    if(1<=item && item <= 6)
                    {
                        //ｺｲﾝを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);        //yはﾌﾟﾚﾊﾌﾞの設定値のハズ
                    }else if(7<=item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
