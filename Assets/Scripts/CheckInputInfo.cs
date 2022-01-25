using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInputInfo : MonoBehaviour
{
    
    PMR_AnimationController pmr_animation_controller;
    LeftHand_Controller leftHand_controller;
    RightHand_Controller rightHand_controller;
    CheckBoneInfo checkbone_info;

    // Start is called before the first frame update
    void Start()
    {
        //script群の参照
        pmr_animation_controller = this.gameObject.GetComponent<PMR_AnimationController>();
        checkbone_info = this.gameObject.GetComponent<CheckBoneInfo>();

        leftHand_controller = GameObject.Find("Controller(left)").GetComponent<LeftHand_Controller>();
        rightHand_controller = GameObject.Find("Controller(Right)").GetComponent<RightHand_Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*「記録を行う入力の条件など」
     *  脳波の計測開始、計測終了のタイミング　EGGdataを参照して確認する
     *  PMRの段階(腕 or 肩) + Hold状態か、Relax状態か
     *  コントローラーの入力がされているとき(InputGetKey)、コントローラーの入力が解かれた時(InputGetKeyUp)
     */
}
