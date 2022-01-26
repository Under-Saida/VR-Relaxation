using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftHand_Controller : MonoBehaviour
{
    SteamVR_Action_Boolean L_Iui = SteamVR_Actions.default_InteractUI;

    //結果の格納用Boolean型関数interactui

    // 左手のトリガーが押されているか否か判定し、bool値を返す
    //public bool GetLeftHandTrigger_Push()
    //{
    //    if (left_interacrtui == true)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    public bool left_interacrtui;

    // Update is called once per frame
    void Update()
    {
        //結果をGetStateで取得してinteracrtuiに格納
        //SteamVR_Input_Sources.機器名（今回は左コントローラ）
        left_interacrtui = L_Iui.GetState(SteamVR_Input_Sources.LeftHand);

        //interacrtuiの動作状況の確認
        //GetLeftHandTrigger_Push();

        if (left_interacrtui == true)
        {
            Debug.Log("LeftHand_Trigger");
        }



    }
}
