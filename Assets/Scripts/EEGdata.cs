using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class EEGdata : MonoBehaviour
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

    float Gpull;
    float Cpull;

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
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnUpdateMindwaveData(MindwaveDataModel _Data)
    {
        m_MindwaveData = _Data;
        attention1 = m_MindwaveData.eSense.attention;
        StreamWriter attention = new StreamWriter("../data/EEGdata/attentionData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        attention.WriteLine(attention1);
        attention.Close();

        meditation1 = m_MindwaveData.eSense.meditation;
        StreamWriter meditation = new StreamWriter("../data/EEGdata/meditationData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        meditation.WriteLine(meditation);
        meditation.Close();

        Delta = m_MindwaveData.eegPower.delta;
        StreamWriter delta = new StreamWriter("../data/EEGdata/deltaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        delta.WriteLine(Delta);
        delta.Close();

        Theta = m_MindwaveData.eegPower.theta;
        StreamWriter theta = new StreamWriter("../data/EEGdata/thetaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        theta.WriteLine(Theta);
        theta.Close();

        LowAlpha = m_MindwaveData.eegPower.lowAlpha;
        StreamWriter la = new StreamWriter("../data/EEGdata/lowalphaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        la.WriteLine(LowAlpha);
        la.Close();

        HighAlpha = m_MindwaveData.eegPower.highAlpha;
        StreamWriter ha = new StreamWriter("../data/EEGdata/highalphaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        ha.WriteLine(HighAlpha);
        ha.Close();

        LowBeta = m_MindwaveData.eegPower.lowBeta;
        StreamWriter lb = new StreamWriter("../data/EEGdata/lowbetaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        lb.WriteLine(LowBeta);
        lb.Close();

        HighBeta = m_MindwaveData.eegPower.highBeta;
        StreamWriter hb = new StreamWriter("../data/EEGdata/highbetaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        hb.WriteLine(HighBeta);
        hb.Close();

        LowGamma = m_MindwaveData.eegPower.lowGamma;
        StreamWriter lg = new StreamWriter("../data/EEGdata/lowgammaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        lg.WriteLine(LowGamma);
        lg.Close();

        HighGamma = m_MindwaveData.eegPower.highGamma;
        StreamWriter hg = new StreamWriter("../data/EEGdata/highgammaData.txt", true, Encoding.GetEncoding("Shift_JIS"));
        hg.WriteLine(HighGamma);
        hg.Close();
    }

}

