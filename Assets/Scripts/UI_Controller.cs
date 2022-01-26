using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Slider PositionCheck_UI, Time_UI;
    public Text pmrInfo_UI;

    float time;

    CheckBoneInfo checkbone_info;
    PMR_AnimationController pmr_animation_controller;

    //お手本のと自身のアバターの位置に合わせて、PositionCheck_UIの値を調節する
    void SetValue_PositionCheck_UI()
    {
        if (checkbone_info.CheckBonePostionDifference() == true)
        {
            PositionCheck_UI.value = 1;
        }
        else
        {
            PositionCheck_UI.value = 0;
        }
    }

    void Start()
    {
        checkbone_info = this.gameObject.GetComponent<CheckBoneInfo>();
        pmr_animation_controller = this.gameObject.GetComponent<PMR_AnimationController>();
        pmrInfo_UI.text = "お手本の動きに合わせ、\n体の動きをキープする\n10.0秒";
    }

    // Update is called once per frame
    void Update()
    {
        //お手本のと自身のアバターの位置に合わせて、PositionCheck_UIの値を調節する
        SetValue_PositionCheck_UI();

        //if()
        
    }
}
