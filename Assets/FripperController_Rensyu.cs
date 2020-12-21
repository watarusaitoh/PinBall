using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController_Rensyu : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private int flickAngle = 20;
    private int defaultAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.mousePosition.y <= Screen.height / 6)
        {
            //スクリーンの6分の１より下をタッチした時両方のフリッパーを動かす
            if (Input.GetMouseButtonDown(0) && tag == "RightFripperTag" || Input.GetMouseButtonDown(0) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //スクリーンの6分の１より下を離した時両方のフリッパーを元に戻す
            if (Input.GetMouseButtonUp(0) && tag == "RightFripperTag" || Input.GetMouseButtonUp(0) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

        }

        
    }
    
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
