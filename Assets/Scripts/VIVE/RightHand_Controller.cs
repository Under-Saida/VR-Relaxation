using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightHand_Controller : MonoBehaviour
{
    SteamVR_Action_Boolean R_Iui = SteamVR_Actions.default_InteractUI;
    SteamVR_Action_Vibration R_vibration;

    //結果の格納用Boolean型関数interactui

    public bool right_interacrtui;

    // Update is called once per frame
    void Update()
    {
        //結果をGetStateで取得してinteracrtuiに格納
        //SteamVR_Input_Sources.機器名（今回は左コントローラ）
        right_interacrtui = R_Iui.GetState(SteamVR_Input_Sources.RightHand);
        
        //interacrtuiの中身を確認
        if (right_interacrtui)
        {
            R_vibration.Execute(0, 10.0f, 1000, 1f, SteamVR_Input_Sources.RightHand);
            Debug.Log("右トリガーがON");
        }
    }
}
