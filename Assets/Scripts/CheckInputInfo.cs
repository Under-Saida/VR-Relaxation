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

    //void OnUpdateMindwaveData(MindwaveDataModel _Data)
    //{
    //    m_MindwaveData = _Data;
    //    attention1 = m_MindwaveData.eSense.attention;
    //    StreamWriter attention = new StreamWriter("../data/EEGdata/attentionData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    attention.WriteLine(attention1);
    //    attention.Close();

    //    // 該当する条件でない時は、WriteLineで書き込む内容を0にする
    //    //m_MindwaveData = _Data;
    //    //attention1 = m_MindwaveData.eSense.attention;
    //    //StreamWriter attention = new StreamWriter("../data/EEGdata/attentionData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    //attention.WriteLine(0);
    //    //attention.Close();

    //    meditation1 = m_MindwaveData.eSense.meditation;
    //    StreamWriter meditation = new StreamWriter("../data/EEGdata/meditationData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    meditation.WriteLine(meditation1);
    //    meditation.Close();

    //    Delta = m_MindwaveData.eegPower.delta;
    //    StreamWriter delta = new StreamWriter("../data/EEGdata/deltaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    delta.WriteLine(Delta);
    //    delta.Close();

    //    Theta = m_MindwaveData.eegPower.theta;
    //    StreamWriter theta = new StreamWriter("../data/EEGdata/thetaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    theta.WriteLine(Theta);
    //    theta.Close();

    //    LowAlpha = m_MindwaveData.eegPower.lowAlpha;
    //    StreamWriter la = new StreamWriter("../data/EEGdata/lowalphaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    la.WriteLine(LowAlpha);
    //    la.Close();

    //    HighAlpha = m_MindwaveData.eegPower.highAlpha;
    //    StreamWriter ha = new StreamWriter("../data/EEGdata/highalphaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    ha.WriteLine(HighAlpha);
    //    ha.Close();


    //    LowBeta = m_MindwaveData.eegPower.lowBeta;
    //    StreamWriter lb = new StreamWriter("../data/EEGdata/lowbetaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    lb.WriteLine(LowBeta);
    //    lb.Close();

    //    HighBeta = m_MindwaveData.eegPower.highBeta;
    //    StreamWriter hb = new StreamWriter("../data/EEGdata/highbetaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    hb.WriteLine(HighBeta);
    //    hb.Close();

    //    LowGamma = m_MindwaveData.eegPower.lowGamma;
    //    StreamWriter lg = new StreamWriter("../data/EEGdata/lowgammaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    lg.WriteLine(LowGamma);
    //    lg.Close();

    //    HighGamma = m_MindwaveData.eegPower.highGamma;
    //    StreamWriter hg = new StreamWriter("../data/EEGdata/highgammaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    hg.WriteLine(HighGamma);
    //    hg.Close();
    //}

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
