//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class UnityChanController : MonoBehaviour
//{
//    //アニメーションするためのコンポーネントを入れる
//    private Animator myAnimator;

//    //Unityちゃんを移動させるｺﾝﾎﾟｰﾈﾝﾄを入れる
//    Rigidbody myRigidbody;

//    //前進するための力（の大きさ）
//    private float forwardForce = 800.0f;

//    //左右に移動するための力
//    private float turnForce = 500.0f;
//    //ｼﾞｬﾝﾌﾟするための力
//    private float upForce = 500.0f;
//    //左右の移動できる範囲
//    private float movableRange = 3.4f;

//    // Start is called before the first frame update
//    void Start()
//    {
//        //Animatorｺﾝﾎﾟｰﾈﾝﾄを取得
//        //  myAnimator = this.GetComponent<Animator>();   //文法的にはエラーでないみたい、使えないかな？
//        this.myAnimator = GetComponent<Animator>();     //こう書けるのはこのｽｸﾘﾌﾟﾄがUnityChan自体にｱﾀｯﾁされているから
//        //走るアニメーションを開始
//        //myAnimator = SetActive(true);  感で書いたが外れた myAnimatorの後の"."が出ないのが情けない・・・
//        myAnimator.SetFloat("Speed", 1);
//        //RigidBodyコンポーネントを取得
//        myRigidbody = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //UnityChanに前方向の力を加える
//        // GetComponent<RigidBody>().AddFore  //見ずにはかけず
//        //this.myRigidbody.AddForce=Vector3()
//        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);      //全然かけなかった・・・
//        //Unityちゃんを矢印キーまたはﾎﾞﾀﾝに応じて左右に移動させる
//        //if (Input.GetKeyDown(KeyCode = LeftArrow)) {this.myRigidbody.Addforece(this.transform.)}
//        //if(Input.GetKey(KeyCode="LeftArrow")||)
//        //かけなかったので写す
//        if(Input.GetKey(KeyCode.LeftArrow)&& -this.movableRange < this.transform.position.x) {
//            //左に移動
//            this.myRigidbody.AddForce(-this.turnForce, 0,0);
//        }else if (Input.GetKey(KeyCode.RightArrow) && this.movableRange > this.myRigidbody.transform.position.x)
//        {
//            //右に移動
//            this.myRigidbody.AddForce(this.turnForce, 0, 0);
//        }
//        //ジャンプしていない時にｽﾍﾟｰｽが押されたらｼﾞｬﾝﾌﾟする
//        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
//        {
//            this.myAnimator.SetBool("Jump",true);
//            //Unityちゃんに上方向の力を加える
//            this.myRigidbody.AddForce(this.transform.up*this.upForce); 
//        }
//    }
//}

//3Dで移動させるときは、RigidBodyで！




using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //Unityちゃんを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //前進するための力
    private float forwardForce = 800.0f;
    //左右に移動するための力
    private float turnForce = 500.0f;
    //ジャンプするための力（追加）
    private float upForce = 500.0f;
    //左右の移動できる範囲
    private float movableRange = 3.4f;
    //動きを減衰させる係数
    private float coefficient = 0.95f;
    //ｹﾞｰﾑ終了判定
    private bool isEnd = false;

    void Start()
    {
        //アニメータコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyコンポーネントを取得（追加）
        this.myRigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        //ｹﾞｰﾑ終了ならUnityちゃんの動きを減衰する
        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;      //加える力に減衰係数をかけていく
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;

        }
        //Unityちゃんに前方向の力を加える
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if ((Input.GetKey(KeyCode.LeftArrow)) && -this.movableRange < this.transform.position.x)
        {
            //左に移動
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.RightArrow)) && this.transform.position.x < this.movableRange)
        {
            //右に移動
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
        }

        //Jumpステートの場合はJumpにfalseをセットする（追加）
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //ジャンプしていない時にスペースが押されたらジャンプする（追加）
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            //ジャンプアニメを再生（追加）
            this.myAnimator.SetBool("Jump", true);
            //Unityちゃんに上方向の力を加える（追加）
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
        //トリガﾓｰﾄﾞで他のオブジェクトと接触した場合の処理
        //「OnTrrigerEnter」関数は、自分のColliderが他のオブジェクトのColliderと接触した時に呼ばれる関数.引数には接触した相手のColliderが渡されます
        void OntriggerEnter(Collider other)
        {
            //障害物に衝突
            if(other.gameObject.tag=="CarTag" || other.gameObject.tag == "TrafficConeTag")
            {
                this.isEnd = true;
            }
            //ゴール
            if (other.gameObject.tag == "GoalTag") {
                this.isEnd = true;
            }

        }
    }
}
