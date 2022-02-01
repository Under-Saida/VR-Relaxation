using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class PMRdata : MonoBehaviour
{
    private MindwaveController m_Controller = null;
    public MindwaveDataModel m_MindwaveData;

    public int attention1;
    public int meditation1;
    public int Delta;
    public int Theta;
    public int LowAlpha;
    public int HighAlpha;
    public int LowBeta;
    public int HighBeta;
    public int LowGamma;
    public int HighGamma;

    GameObject ManageObject;
    CheckBoneInfo checkbone_info;
    PMR_AnimationController pmr_animation_controller;

    int update_num = 0;

    string move_state, muscle_state;

    // Start is called before the first frame update
    void Start()
    {
        m_Controller = GameObject.Find("MindwaveManager").GetComponent<MindwaveController>();
        attention1 = m_MindwaveData.eSense.attention;
        meditation1 = m_MindwaveData.eSense.meditation;
        Delta = m_MindwaveData.eegPower.delta;
        Theta = m_MindwaveData.eegPower.theta;
        LowAlpha = m_MindwaveData.eegPower.lowAlpha;
        HighAlpha = m_MindwaveData.eegPower.highAlpha;
        LowBeta = m_MindwaveData.eegPower.lowBeta;
        HighBeta = m_MindwaveData.eegPower.highBeta;
        LowGamma = m_MindwaveData.eegPower.lowGamma;
        HighGamma = m_MindwaveData.eegPower.highGamma;
        m_Controller.OnUpdateMindwaveData += OnUpdateMindwaveData;

        checkbone_info = GameObject.Find("ManageObject").GetComponent<CheckBoneInfo>();
        pmr_animation_controller = GameObject.Find("ManageObject").GetComponent<PMR_AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hold状態かRelax状態か
        // 動きの段階(腕の筋弛緩法、肩の筋弛緩法)
        //脳波の更新のタイミングで更新も入れる
        //最初のT-Poseを始めるタイミング

        if (checkbone_info.GethasStartPMR() == true)
        {
            switch (pmr_animation_controller.GetCurrentAnimationStateNum())
            {
                case 0:
                    move_state = "Sit_T-Pose";
                    break;

                case 1:
                    move_state = "Arm";
                    break;

                case 2:
                    move_state = "Shoulder";
                    break;

                default:
                    Debug.Log("アニメーション情報の取得ミス");
                    break;
            }

            // Hold、Relax状態の開始と終わりをstring型のデータに格納
            if (!checkbone_info.GethasHold() && !checkbone_info.GethasRelax())
            {
                muscle_state = "Hold(開始)";
            }
            else if(checkbone_info.GethasHold() && !checkbone_info.GethasRelax())
            {
                muscle_state = "Hold(終了)とRelax(開始)";
            }
            else if (checkbone_info.GethasRelax() && checkbone_info.GethasRelax())
            {
                muscle_state = "Relax(終了)";
            }

            StreamWriter pmrInfo = new StreamWriter("../data/PMRdata/Data.txt", true, Encoding.GetEncoding("Shift_JIS"));
            pmrInfo.WriteLine("{0}：{1}", move_state, muscle_state);
            pmrInfo.Close();
        }

    }

    void OnUpdateMindwaveData(MindwaveDataModel _Data)
    {
        StreamWriter updateEGG = new StreamWriter("../data/PMRdata/Data.txt", true, Encoding.GetEncoding("Shift_JIS"));
        updateEGG.WriteLine("更新：{0}", update_num);
        updateEGG.Close();

        //脳波が更新された回数をインクリメント
        update_num += 1;
    }
}
