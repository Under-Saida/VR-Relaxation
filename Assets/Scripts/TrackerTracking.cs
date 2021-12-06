using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class TrackerTracking : MonoBehaviour
{

    public SteamVR_Input_Sources trackerType;

    //トラッカーの位置座標格納用
    private Vector3 TrackerPosition;

    //トラッカーの初期位置格納用
    private Vector3 TrackerPosition_default;

    //トラッカーの回転座標格納用(クォータニオン)
    private Quaternion TrackerRotationQ;

    //トラッカーの回転座標格納用(オイラー角)
    private Vector3 TrackerRotation;

    //トラッカーのpose情報を取得するためにtrackerという関数にSteamVR_Actions.default_Poseを固定
    private SteamVR_Action_Pose tracker = SteamVR_Actions.default_Pose;

    public bool raise_flag = false;


    public bool RaiseFoot()
    {
        return raise_flag;
    }

    void Start()
    {
        TrackerPosition_default = tracker.GetLocalPosition(trackerType);
        //TrackerPosition_default.y = TrackerPosition_default.y + 0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //位置座標を取得
        TrackerPosition = tracker.GetLocalPosition(trackerType);
        //回転座標をクォータニオンで値を受け取る
        TrackerRotationQ = tracker.GetLocalRotation(trackerType);
        //取得した値をクォータニオン → オイラー角に変換
        TrackerRotation = TrackerRotationQ.eulerAngles;

        //取得したデータを表示（T1D：Tracker1位置，T1R：Tracker1回転）
        Debug.Log(trackerType + " Pos:" + TrackerPosition.x + ", " + TrackerPosition.y + ", " + TrackerPosition.z + "\n");
        //Debug.Log(trackerType + " Pos:" + TrackerPosition_default.x + ", " + TrackerPosition_default.y + ", " + TrackerPosition_default.z + "\n");
        //trackerType + " Rot:" + TrackerRotation.x + ", " + TrackerRotation.y + ", " + TrackerRotation.z

        //「Tキー」を押すとトラッカーの初期位置が更新される
        if (Input.GetKeyDown(KeyCode.T))
        {
            TrackerPosition_default = tracker.GetLocalPosition(trackerType);
        }
        
        //初期位置の位置と比較し、y座標が一定数上だと足をあげたとみなす
        if (TrackerPosition_default.y + 0.25f < TrackerPosition.y)
        {
            raise_flag = true;
        }
    }
}
