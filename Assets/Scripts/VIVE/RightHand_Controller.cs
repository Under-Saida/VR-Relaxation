using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightHand_Controller : MonoBehaviour
{
    SteamVR_Action_Boolean R_Iui = SteamVR_Actions.default_InteractUI;
    //SteamVR_Action_Vibration R_vibration;

    //結果の格納用Boolean型関数interactui

    public bool right_interacrtui;

    // 左手のトリガーが押されているか否か判定し、bool値を返す
    //public bool GetRightHandTrigger_Push()
    //{
    //    if (right_interacrtui == true)
    //    {
    //        Debug.Log("右手のトリガーはON");
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        //結果をGetStateで取得してinteracrtuiに格納
        //SteamVR_Input_Sources.機器名（今回は左コントローラ）
        right_interacrtui = R_Iui.GetState(SteamVR_Input_Sources.RightHand);

        //interacrtuiの動作状況の確認
        if (right_interacrtui)
        {
            Debug.Log("RightHand_Trigger");
        }
    }
}
