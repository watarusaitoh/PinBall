using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    Material mymaterial;
    //Emissionの最小値
    private float minEmission = 0.3f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //角度
    private int degree = 0;
    //発行速度
    private int speed = 10;
    //ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    // Use this for initialization
    void Start()
    {
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;

        }
        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        this.mymaterial = GetComponent<Renderer>().material;
        mymaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
    }
        void Update()
        {
            if (this.degree >= 0)
            {
                Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
                mymaterial.SetColor("_EmissionColor", emissionColor);
                this.degree -= this.speed;
            }

        }
        void OnCollisionEnter(Collision other)
        {
            this.degree = 180;
        }
}
