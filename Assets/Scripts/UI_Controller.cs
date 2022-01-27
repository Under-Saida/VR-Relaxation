using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Slider PositionCheck_UI, Time_UI;
    public Text pmrInfo_UI;

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

    void SetValue_Text()
    {
        switch (pmr_animation_controller.GetCurrentAnimationStateNum())
        {
            // 座って腕を横に伸ばすポーズの時
            case 0:

                if (checkbone_info.hasHold == false)
                {
                    Time_UI.value = checkbone_info.Get_timeHold();
                    pmrInfo_UI.text = "お手本の動きに合わせ、\n体の動きをキープする\n" + checkbone_info.Get_timeHold().ToString("f1") + "秒";
                }
                else if (checkbone_info.hasHold == true && checkbone_info.hasRelax == false)
                {
                    Time_UI.value = checkbone_info.Get_timeRelax();
                    pmrInfo_UI.text = "楽な姿勢で体をリラックスさせる\n" + checkbone_info.Get_timeRelax().ToString("f1") + "秒";
                }
                break;

            // 腕の筋弛緩法の動きの時
            case 1:
                if (checkbone_info.hasHold == false)
                {
                    Time_UI.value = checkbone_info.Get_timeHold();
                    pmrInfo_UI.text = "腕に力を入れつつ、\nお手本の体の動きに合わせる\n" + checkbone_info.Get_timeHold().ToString("f1") + "秒";
                }
                else if (checkbone_info.hasHold == true && checkbone_info.hasRelax == false)
                {
                    Time_UI.value = checkbone_info.Get_timeRelax();
                    pmrInfo_UI.text = "腕の力を抜き、\n楽な姿勢で体をリラックスさせる\n" + checkbone_info.Get_timeRelax().ToString("f1") + "秒";
                }
                break;

            // 肩の筋弛緩法の動きの時
            case 2:
                if (checkbone_info.hasHold == false)
                {
                    Time_UI.value = checkbone_info.Get_timeHold();
                    pmrInfo_UI.text = "腕に力を入れつつ、\nお手本の体の動きに合わせる\n" + checkbone_info.Get_timeHold().ToString("f1") + "秒";
                }
                else if (checkbone_info.hasHold == true && checkbone_info.hasRelax == false)
                {

                    Time_UI.value = checkbone_info.Get_timeRelax();
                    pmrInfo_UI.text = "腕の力を抜き、\n楽な姿勢で体をリラックスさせる\n" + checkbone_info.Get_timeRelax().ToString("f1") + "秒";
                }
                break;

            default:
                Debug.Log("アニメーション情報の取得の失敗");
                break;
        }
    }

    //void UpdateText()
    //{
    //    switch (pmr_animation_controller.GetCurrentAnimationStateNum())
    //    {
    //        // 座って腕を横に伸ばすポーズの時
    //        case 0:

    //            if (checkbone_info.hasHold == false && checkbone_info.CheckBonePostionDifference() == true)
    //            {
    //                if (time > 0)
    //                {
    //                    time -= Time.deltaTime;
    //                }
    //                else
    //                {
    //                    time = 0;
    //                }

    //                pmrInfo_UI.text = "お手本の動きに合わせ、\n体の動きをキープする\n" + time.ToString("D3") + "秒";
    //            }
    //            else if (checkbone_info.hasHold == true && checkbone_info.hasRelax == false)
    //            {
    //                if (time > 0)
    //                {
    //                    time -= Time.deltaTime;
    //                }
    //                else
    //                { 
    //                    time = 0;
    //                }
    //                pmrInfo_UI.text = "楽な姿勢で体をリラックスさせる\n" + time.ToString("D3") + "秒";
    //            }
    //            break;

    //        // 腕の筋弛緩法の動きの時
    //        case 1:
    //            if (checkbone_info.hasHold == false && checkbone_info.CheckBonePostionDifference() == true)
    //            {
    //                if (time > 0)
    //                {
    //                    time -= Time.deltaTime;
    //                }
    //                else
    //                {
    //                    time = 0;
    //                }
    //                pmrInfo_UI.text = "腕に力を入れつつ、\nお手本の体の動きに合わせる\n" + time.ToString("D3") + "秒";
    //            }
    //            else if (checkbone_info.hasHold == true && checkbone_info.hasRelax == false)
    //            {
    //                if (time > 0)
    //                {
    //                    time -= Time.deltaTime;
    //                }
    //                else
    //                {
    //                    time = 0;
    //                }
    //                pmrInfo_UI.text = "腕の力を抜き、\n楽な姿勢で体をリラックスさせる\n" + time.ToString("D3") + "秒";
    //            }
    //            break;

    //        // 肩の筋弛緩法の動きの時
    //        case 2:
    //            if (checkbone_info.hasHold == false && checkbone_info.CheckBonePostionDifference() == true)
    //            {
    //                if (time > 0)
    //                {
    //                    time -= Time.deltaTime;
    //                }
    //                else
    //                {
    //                    time = 0;
    //                }
    //                pmrInfo_UI.text = "腕に力を入れつつ、\nお手本の体の動きに合わせる\n" + time.ToString("D3") + "秒";
    //            }
    //            else if (checkbone_info.hasHold == true && checkbone_info.hasRelax == false)
    //            {
    //                if (time > 0)
    //                {
    //                    time -= Time.deltaTime;
    //                }
    //                else
    //                {
    //                    time = 0;
    //                }
    //                pmrInfo_UI.text = "腕の力を抜き、\n楽な姿勢で体をリラックスさせる\n" + time.ToString("D3") + "秒";
    //            }
    //            break;

    //        default:
    //            Debug.Log("アニメーション情報の取得の失敗");
    //            break;

    //    }
    //}

    void Start()
    {
        checkbone_info = this.gameObject.GetComponent<CheckBoneInfo>();
        pmr_animation_controller = this.gameObject.GetComponent<PMR_AnimationController>();

        // UI内の情報の初期化
        //Time_UI.value = checkbone_info.time_hold;
        //pmrInfo_UI.text = "お手本の動きに合わせ、\n体の動きをキープする\n" + checkbone_info.time_hold.ToString("f1") + "秒";
    }

    // Update is called once per frame
    void Update()
    {
        //Time_UI.value = checkbone_info.time_hold;
        //pmrInfo_UI.text = "お手本の動きに合わせ、\n体の動きをキープする\n" + checkbone_info.time_hold.ToString("D3") + "秒";

        //お手本のと自身のアバターの位置に合わせて、PositionCheck_UIの値を調節する
        SetValue_PositionCheck_UI();

        // Text情報を更新する
        SetValue_Text();

        //UpdateText();

    }
}
