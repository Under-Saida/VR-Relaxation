using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInputInfo : MonoBehaviour
{
    
    PMR_AnimationController pmr_animation_controller;
    LeftHand_Controller leftHand_controller;
    RightHand_Controller rightHand_controller;
    CheckBoneInfo checkbone_info;

    //public bool CheckHandsTrigger_Push()
    //{
    //    if (leftHand_controller.GetLeftHandTrigger_Push() == true && rightHand_controller.GetRightHandTrigger_Push() == true)
    //    {
    //        Debug.Log("両手のトリガーがON");
    //        return true;
    //    }
    //    else
    //    {
    //        Debug.Log("両手のトリガーがOFF");
    //        return false;
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        //script群の参照
        pmr_animation_controller = this.gameObject.GetComponent<PMR_AnimationController>();
        checkbone_info = this.gameObject.GetComponent<CheckBoneInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        //現在のアニメーション情報を取得する
        pmr_animation_controller.GetCurrentAnimationStateNum();

        //両手のコントローラーの
        //CheckHandsTrigger_Push();
    }

    /*「記録を行う入力の条件など」
     *  脳波の計測開始、計測終了のタイミング、EGGdataを参照して確認する
     *  PMRの段階(腕 or 肩) + Hold状態か、Relax状態か
     *  コントローラーの入力がされているとき(InputGetKey)、コントローラーの入力が解かれた時(InputGetKeyUp)
     */
}
