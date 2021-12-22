using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftHand_Controller : MonoBehaviour
{
    SteamVR_Action_Boolean L_Iui = SteamVR_Actions.default_InteractUI;
    SteamVR_Action_Vibration L_vibration;

    //結果の格納用Boolean型関数interactui

    public bool left_interacrtui;

    // Update is called once per frame
    void Update()
    {
        //結果をGetStateで取得してinteracrtuiに格納
        //SteamVR_Input_Sources.機器名（今回は左コントローラ）
        left_interacrtui = L_Iui.GetState(SteamVR_Input_Sources.LeftHand);
        
        //interacrtuiの中身を確認
        if (left_interacrtui)
        {
            L_vibration.Execute(0, 10.0f, 1000, 1f, SteamVR_Input_Sources.LeftHand);
            Debug.Log("左トリガーがON");
        }
    }
}
