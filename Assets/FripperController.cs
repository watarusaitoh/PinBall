using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoinコンポーネントを入れる
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    private int touchCount;
  
    // Start is called before the first frame update
    void Start()
    {
       if (Input.touchSupported)
        {
            print("タッチに対応している");
        }
        //HingeJoint　コンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //矢印キー離されたときフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //Aキーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //Dキーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //離されたときフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        //Sキー及び下矢印が押されたときフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.S) && tag == "RightFripperTag" || Input.GetKeyDown(KeyCode.S) && tag == "LeftFripperTag" || Input.GetKeyDown(KeyCode.DownArrow) && tag == "RightFripperTag" || Input.GetKeyDown(KeyCode.DownArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //離されたとき戻す
        if (Input.GetKeyUp(KeyCode.S) && tag == "RightFripperTag" || Input.GetKeyUp(KeyCode.S) && tag == "LeftFripperTag" || Input.GetKeyUp(KeyCode.DownArrow) && tag == "RightFripperTag" || Input.GetKeyUp(KeyCode.DownArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //スマホ用
        //スクリーンタッチによってフリッパーを動かす
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {


                Touch touch = Input.GetTouch(i);
                if (touch.position.x >= Screen.width / 2)
                {
                    if (touch.phase == TouchPhase.Began && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
                else
                {
                    if (touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }

                }
            }
        }
    }
        //フリッパーの傾きを設定
        public void SetAngle(float angle)
        {
            JointSpring jointSpr = this.myHingeJoint.spring;
            jointSpr.targetPosition = angle;
            this.myHingeJoint.spring = jointSpr;
        }
}

