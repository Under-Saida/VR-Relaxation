using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
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

    VideoPlayer video;

    int update_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        video = this.gameObject.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //脳波計の計測が始まってから動画を再生
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!video.isPlaying)
            {
                video.Play(); //動画を再生

                StreamWriter videoStart = new StreamWriter("../data/EEGdata(Video)/VideoState.txt", true, Encoding.GetEncoding("Shift_JIS"));
                videoStart.WriteLine("動画の再生開始");
                videoStart.Close();
            }

            //StreamWriter videoStart = new StreamWriter("../data/EEGdata(Video)/VideoState.txt", true, Encoding.GetEncoding("Shift_JIS"));
            //videoStart.WriteLine("動画の再生開始");
            //videoInfo.Close();
        }
    }

    void OnUpdateMindwaveData(MindwaveDataModel _Data)
    {
        StreamWriter updateEGG = new StreamWriter("../data/EEGdata(Video)/VideoState.txt", true, Encoding.GetEncoding("Shift_JIS"));
        updateEGG.WriteLine("更新：{0}", update_num);
        updateEGG.Close();

        //脳波が更新された回数をインクリメント
        update_num += 1;
    }

    // ビデオを再生し、時間で区切って「現在の動きのアニメーション情報」「HoldかRelax状態かアニメーションの遷移中か」テキストファイルに出力
    // また、同時に脳波の計測も行い、上記の情報と脳波の情報を比較できるようにする。
}
