using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftHand_Controller : MonoBehaviour
{
    SteamVR_Action_Boolean Iui = SteamVR_Actions.default_InteractUI;

    //結果の格納用Boolean型関数interactui

    private bool interacrtui;

    // Update is called once per frame
    void Update()
    {
        //結果をGetStateで取得してinteracrtuiに格納
        //SteamVR_Input_Sources.機器名（今回は左コントローラ）
        interacrtui = Iui.GetState(SteamVR_Input_Sources.LeftHand);
        //interacrtuiの中身を確認
        Debug.Log(interacrtui);
    }
}
