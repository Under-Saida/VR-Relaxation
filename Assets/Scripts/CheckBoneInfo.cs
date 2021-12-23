using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class CheckBoneInfo : MonoBehaviour
{
    private GameObject myVRM, cloneVRM;

    public AudioClip ok;
    
    AudioSource audio;
  
    BoneInfo my_boneinfo, clone_boneinfo;
    PMR_AnimationController pmr_animation_controller;

    Transform myHead, myNeck, myLeftShoulder, myRightShoulder, myLeftUpperArm, myRightUpperArm, myLeftLowerArm, myRightLowerArm, myLeftHand, myRightHand;
    Transform cloneHead, cloneNeck, cloneLeftShoulder, cloneRightShoulder, cloneLeftUpperArm, cloneRightUpperArm, cloneLeftLowerArm, cloneRightLowerArm, cloneLeftHand, cloneRightHand;
    
    Vector3 HeadPos_diff, NeckPos_diff, LeftShoulderPos_diff, RightShoulderPos_diff, LeftUpperArmPos_diff, RightUpperArmPos_diff, LeftLowerArmPos_diff, RightLowerArmPos_diff, LeftHandPos_diff, RightHandPos_diff;
    //Vector3 HeadRot_diff, NeckRot_diff, LeftShoulderRot_diff, RightShoulderRot_diff, LeftUpperArmRot_diff, RightUpperArmRot_diff, LeftLowerArmRot_diff, RightLowerArmRot_diff, LeftHandRot_diff, RightHandRot_diff;

    float time_hold, time_relax;

    int StateNum = 0, currentStateNum;

    bool bonePosCheck_ok, boneRotCheck_ok, endPose;
    public bool hasHold = false, hasRelax = false;


    // 筋弛緩法の動きのフェーズが一周したか確認し、bool値で返す
    public bool CheckBoolState()
    {
        if(hasHold == true && hasRelax == true)
        {
            endPose = true;
            return endPose;
        }
        else
        {
            endPose = false;
            return endPose;
        }
    }


    bool CheckBonePostionDifference() 
    {
        // 差分の絶対値が一定値以下なら、動きが合っているとする。 閾値を一度大きくする + magnitudeで取得を行う
        if (HeadPos_diff.magnitude < 0.3f && NeckPos_diff.magnitude < 0.3f && 
            LeftShoulderPos_diff.magnitude < 0.3f && RightShoulderPos_diff.magnitude < 0.3f &&
            LeftUpperArmPos_diff.magnitude < 0.3f && RightUpperArmPos_diff.magnitude < 0.3f &&
            LeftLowerArmPos_diff.magnitude < 0.3f && RightLowerArmPos_diff.magnitude < 0.3f &&
            LeftHandPos_diff.magnitude < 0.3f && RightHandPos_diff.magnitude < 0.3f)
        {
            bonePosCheck_ok = true;
            return bonePosCheck_ok;
        }
        else
        {
            bonePosCheck_ok = false;
            return bonePosCheck_ok;
        }
    }

    //bool CheckBoneRotationDifference()
    //{
    //    // 差分の絶対値が一定値以下なら、動きが合っているとする。
    //    if (Mathf.Abs(HeadRot_diff.x) < 30 && Mathf.Abs(HeadRot_diff.y) < 30 && Mathf.Abs(HeadRot_diff.z) < 30 &&
    //        Mathf.Abs(NeckRot_diff.x) < 30 && Mathf.Abs(NeckRot_diff.y) < 30 && Mathf.Abs(NeckRot_diff.z) < 30 &&

    //        Mathf.Abs(LeftShoulderRot_diff.x) < 30 && Mathf.Abs(LeftShoulderRot_diff.y) < 30 && Mathf.Abs(LeftShoulderRot_diff.z) < 30 &&
    //        Mathf.Abs(RightShoulderRot_diff.x) < 30 && Mathf.Abs(RightShoulderRot_diff.y) < 30 && Mathf.Abs(RightShoulderRot_diff.z) < 30 &&

    //        Mathf.Abs(LeftUpperArmRot_diff.x) < 30 && Mathf.Abs(LeftUpperArmRot_diff.y) < 30 && Mathf.Abs(LeftUpperArmRot_diff.z) < 30 &&
    //        Mathf.Abs(RightUpperArmRot_diff.x) < 30 && Mathf.Abs(RightUpperArmRot_diff.y) < 30 && Mathf.Abs(RightUpperArmRot_diff.z) < 30 &&

    //        Mathf.Abs(LeftLowerArmRot_diff.x) < 30 && Mathf.Abs(LeftLowerArmRot_diff.y) < 30 && Mathf.Abs(LeftLowerArmRot_diff.z) < 30 &&
    //        Mathf.Abs(LeftLowerArmRot_diff.x) < 30 && Mathf.Abs(LeftLowerArmRot_diff.x) < 30 && Mathf.Abs(LeftLowerArmRot_diff.x) < 30 &&

    //        Mathf.Abs(LeftHandRot_diff.x) < 30 && Mathf.Abs(LeftHandRot_diff.y) < 30 && Mathf.Abs(LeftHandRot_diff.z) < 30 &&
    //        Mathf.Abs(RightHandRot_diff.x) < 30 && Mathf.Abs(RightHandRot_diff.y) < 30 && Mathf.Abs(RightHandRot_diff.z) < 30)
    //    {
    //        boneRotCheck_ok = true;
    //        return boneRotCheck_ok;
    //    }
    //    else
    //    {
    //        boneRotCheck_ok = false;
    //        return boneRotCheck_ok;
    //    }
    //}

    void ExportCloneBoneInfo()
    {
        //cloneHead
        StreamWriter clone_head = new StreamWriter("../data/CloneBone_data/Head.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_head.WriteLine(cloneHead);
        clone_head.Close();

        //cloneNeck
        StreamWriter clone_neck = new StreamWriter("../data/CloneBone_data/Neck.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_neck.WriteLine(cloneNeck);
        clone_neck.Close();

        //cloneLeftShoulder
        StreamWriter clone_L_shoulder = new StreamWriter("../data/CloneBone_data/LeftShoulder.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_L_shoulder.WriteLine(cloneLeftShoulder);
        clone_L_shoulder.Close();

        //cloneRightShoulder
        StreamWriter clone_R_shoulder = new StreamWriter("../data/CloneBone_data/RightShoulder.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_R_shoulder.WriteLine(cloneRightShoulder);
        clone_R_shoulder.Close();

        //cloneLeftUpperArm
        StreamWriter clone_L_upperArm = new StreamWriter("../data/CloneBone_data/LeftUpperArm.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_L_upperArm.WriteLine(cloneLeftUpperArm);
        clone_L_upperArm.Close();

        //cloneRightUpperArm
        StreamWriter clone_R_upperArm = new StreamWriter("../data/CloneBone_data/RightUpperArm.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_R_upperArm.WriteLine(cloneRightUpperArm);
        clone_R_upperArm.Close();

        //cloneLeftLowerArm
        StreamWriter clone_L_lowerArm = new StreamWriter("../data/CloneBone_data/LeftLowerArm.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_L_lowerArm.WriteLine(cloneLeftLowerArm);
        clone_L_lowerArm.Close();

        //cloneRightLowerArm
        StreamWriter clone_R_lowerArm = new StreamWriter("../data/CloneBone_data/RightLowerArm.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_R_lowerArm.WriteLine(cloneRightLowerArm);
        clone_R_lowerArm.Close();

        //cloneLeftHand
        StreamWriter clone_L_hand = new StreamWriter("../data/CloneBone_data/LeftHand.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_L_hand.WriteLine(cloneLeftHand);
        clone_L_hand.Close();

        //cloneRightHand
        StreamWriter clone_R_hand = new StreamWriter("../data/CloneBone_data/RightHand.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_R_hand.WriteLine(cloneRightHand);
        clone_R_hand.Close();

    }

    void ExportBonePosition_diff()
    {
        //HeadPos_diff
        StreamWriter headPos_diff = new StreamWriter("../data/BonePosition_diff/HeadPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        headPos_diff.WriteLine(HeadPos_diff);
        headPos_diff.Close();

        //NeckPos_diff
        StreamWriter neckPos_diff = new StreamWriter("../data/BonePosition_diff/NeckPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        neckPos_diff.WriteLine(NeckPos_diff);
        neckPos_diff.Close();

        //LeftShoulderPos_diff
        StreamWriter L_shoulderPos_diff = new StreamWriter("../data/BonePosition_diff/LeftShoulderPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        L_shoulderPos_diff.WriteLine(LeftShoulderPos_diff);
        L_shoulderPos_diff.Close();

        //RightShoulderPos_diff
        StreamWriter R_shoulder_diff = new StreamWriter("../data/BonePosition_diff/RightShoulderPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        R_shoulder_diff.WriteLine(RightShoulderPos_diff);
        R_shoulder_diff.Close();

        //LeftUpperArmPos_diff
        StreamWriter L_upperArmPos_diff = new StreamWriter("../data/BonePosition_diff/LeftUpperArmPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        L_upperArmPos_diff.WriteLine(LeftUpperArmPos_diff);
        L_upperArmPos_diff.Close();

        //RightUpperArmPos_diff
        StreamWriter R_upperArmPos_diff = new StreamWriter("../data/BonePosition_diff/RightUpperArmPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        R_upperArmPos_diff.WriteLine(RightUpperArmPos_diff);
        R_upperArmPos_diff.Close();

        //LeftLowerArmPos_diff
        StreamWriter L_lowerArmPos_diff = new StreamWriter("../data/BonePosition_diff/LeftLowerArmPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        L_lowerArmPos_diff.WriteLine(LeftLowerArmPos_diff);
        L_lowerArmPos_diff.Close();

        //RightLowerArmPos_diff
        StreamWriter R_lowerArmPos_diff = new StreamWriter("../data/BonePosition_diff/RightLowerArmPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        R_lowerArmPos_diff.WriteLine(RightLowerArmPos_diff);
        R_lowerArmPos_diff.Close();

        //LeftHandPos_diff
        StreamWriter L_handPos_diff = new StreamWriter("../data/BonePosition_diff/LeftHandPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        L_handPos_diff.WriteLine(LeftHandPos_diff);
        L_handPos_diff.Close();

        //RightHandPos_diff
        StreamWriter R_handPos_diff = new StreamWriter("../data/BonePosition_diff/RightHandPos_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
        R_handPos_diff.WriteLine(RightHandPos_diff);
        R_handPos_diff.Close();
    }

    //void ExportBoneRotation_diff()
    //{
    //    //HeadRot_diff
    //    StreamWriter headRot_diff = new StreamWriter("../data/BoneRotation_diff/HeadRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    headRot_diff.WriteLine(HeadRot_diff);
    //    headRot_diff.Close();

    //    //NeckRot_diff
    //    StreamWriter neckRot_diff = new StreamWriter("../data/BoneRotation_diff/NeckRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    neckRot_diff.WriteLine(NeckRot_diff);
    //    neckRot_diff.Close();

    //    //LeftShoulderRot_diff
    //    StreamWriter L_shoulderRot_diff = new StreamWriter("../data/BoneRotation_diff/LeftShoulderRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    L_shoulderRot_diff.WriteLine(LeftShoulderRot_diff);
    //    L_shoulderRot_diff.Close();

    //    //RightShoulderRot_diff
    //    StreamWriter R_shoulder_diff = new StreamWriter("../data/BoneRotation_diff/RightShoulderRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    R_shoulder_diff.WriteLine(RightShoulderRot_diff);
    //    R_shoulder_diff.Close();

    //    //LeftUpperArmRot_diff
    //    StreamWriter L_upperArmRot_diff = new StreamWriter("../data/BoneRotation_diff/LeftUpperArmRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    L_upperArmRot_diff.WriteLine(LeftUpperArmRot_diff);
    //    L_upperArmRot_diff.Close();

    //    //RightUpperArmRot_diff
    //    StreamWriter R_upperArmRot_diff = new StreamWriter("../data/BoneRotation_diff/RightUpperArmRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    R_upperArmRot_diff.WriteLine(RightUpperArmRot_diff);
    //    R_upperArmRot_diff.Close();

    //    //LeftLowerArmRot_diff
    //    StreamWriter L_lowerArmRot_diff = new StreamWriter("../data/BoneRotation_diff/LeftLowerArmRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    L_lowerArmRot_diff.WriteLine(LeftLowerArmRot_diff);
    //    L_lowerArmRot_diff.Close();

    //    //RightLowerArmRot_diff
    //    StreamWriter R_lowerArmRot_diff = new StreamWriter("../data/BoneRotation_diff/RightLowerArmRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    R_lowerArmRot_diff.WriteLine(RightLowerArmRot_diff);
    //    R_lowerArmRot_diff.Close();

    //    //LeftHandRot_diff
    //    StreamWriter L_handRot_diff = new StreamWriter("../data/BoneRotation_diff/LeftHandRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    L_handRot_diff.WriteLine(LeftHandRot_diff);
    //    L_handRot_diff.Close();

    //    //RightHandRot_diff
    //    StreamWriter R_handRot_diff = new StreamWriter("../data/BoneRotation_diff/RightHandRot_diff.txt", true, Encoding.GetEncoding("Shift_JIS"));
    //    R_handRot_diff.WriteLine(RightHandRot_diff);
    //    R_handRot_diff.Close();
    //}

    // Start is called before the first frame update
    void Start()
    {
        myVRM = GameObject.Find("SampleAvatar_C");
        my_boneinfo = myVRM.GetComponent<BoneInfo>();

        cloneVRM = GameObject.Find("SampleAvatar_C(Clone)");
        clone_boneinfo = cloneVRM.GetComponent<BoneInfo>();
        pmr_animation_controller = cloneVRM.GetComponent<PMR_AnimationController>();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // アニメーションの変更が終了した場合、関連する変数の値をリセットする
        if(pmr_animation_controller.GethasEndAnimaton() == true)
        {
            hasHold = false;
            hasRelax = false;
            time_hold = 0;
            time_relax = 0;
            pmr_animation_controller.hasEndAnimaton = false;
        }

        // 自身アバタのボーンにあるTransform情報を部位ごとに格納
        myHead = my_boneinfo.transHead;

        myNeck = my_boneinfo.transNeck;

        myLeftShoulder = my_boneinfo.transLeftShoulder;

        myRightShoulder = my_boneinfo.transRightShoulder;

        myLeftUpperArm = my_boneinfo.transLeftUpperArm;

        myRightUpperArm = my_boneinfo.transRightUpperArm;

        myLeftLowerArm = my_boneinfo.transLeftLowerArm;

        myRightLowerArm = my_boneinfo.transRightLowerArm;

        myLeftHand = my_boneinfo.transLeftHand;

        myRightHand = my_boneinfo.transRightHand;


        // 自身アバタのCloneのボーンにあるTransform情報を部位ごとに格納
        cloneHead = clone_boneinfo.transHead;

        cloneNeck = clone_boneinfo.transNeck;

        cloneLeftShoulder = clone_boneinfo.transLeftShoulder;

        cloneRightShoulder = clone_boneinfo.transRightShoulder;

        cloneLeftUpperArm = clone_boneinfo.transLeftUpperArm;

        cloneRightUpperArm = clone_boneinfo.transRightUpperArm;

        cloneLeftLowerArm = clone_boneinfo.transLeftLowerArm;

        cloneRightLowerArm = clone_boneinfo.transRightLowerArm;

        cloneLeftHand = clone_boneinfo.transLeftHand;

        cloneRightHand = clone_boneinfo.transRightHand;



        // ボーンPosition情報の差分を部位ごとに格納(Vector3に変換)
        HeadPos_diff = cloneHead.position - myHead.position;

        NeckPos_diff = cloneNeck.position - myNeck.position;

        LeftShoulderPos_diff = cloneLeftShoulder.position - myLeftShoulder.position;

        RightShoulderPos_diff = cloneRightShoulder.position - myRightShoulder.position;

        LeftUpperArmPos_diff = cloneLeftUpperArm.position - myLeftUpperArm.position;

        RightUpperArmPos_diff = cloneRightUpperArm.position - myRightUpperArm.position;

        LeftLowerArmPos_diff = cloneLeftLowerArm.position - myLeftLowerArm.position;

        RightLowerArmPos_diff = cloneRightLowerArm.position - myRightLowerArm.position;

        LeftHandPos_diff = cloneLeftHand.position - myLeftHand.position;

        RightHandPos_diff = cloneRightHand.position - myRightHand.position;



        // ボーンRotation情報の差分を部位ごとに格納(Vector3に変換)
        //HeadRot_diff = clone_boneinfo.transHead.rotation.eulerAngles - my_boneinfo.transHead.rotation.eulerAngles;

        //NeckRot_diff = clone_boneinfo.transNeck.rotation.eulerAngles - my_boneinfo.transNeck.rotation.eulerAngles;

        //LeftShoulderRot_diff = clone_boneinfo.transLeftShoulder.rotation.eulerAngles - my_boneinfo.transLeftShoulder.rotation.eulerAngles;

        //RightShoulderRot_diff = clone_boneinfo.transRightShoulder.rotation.eulerAngles - my_boneinfo.transRightShoulder.rotation.eulerAngles;

        //LeftUpperArmRot_diff = clone_boneinfo.transLeftUpperArm.rotation.eulerAngles - my_boneinfo.transLeftUpperArm.rotation.eulerAngles;

        //RightUpperArmRot_diff = clone_boneinfo.transRightUpperArm.rotation.eulerAngles - my_boneinfo.transRightUpperArm.rotation.eulerAngles;

        //LeftLowerArmRot_diff = clone_boneinfo.transLeftLowerArm.rotation.eulerAngles - my_boneinfo.transLeftLowerArm.rotation.eulerAngles;

        //RightLowerArmRot_diff = clone_boneinfo.transRightLowerArm.rotation.eulerAngles - my_boneinfo.transRightLowerArm.rotation.eulerAngles;

        //LeftHandRot_diff = clone_boneinfo.transLeftHand.rotation.eulerAngles - my_boneinfo.transLeftHand.rotation.eulerAngles;

        //RightHandRot_diff = clone_boneinfo.transRightHand.rotation.eulerAngles - my_boneinfo.transRightHand.rotation.eulerAngles;

        // Bone情報の取得に使用（普段はコメントアウトしておく）
        //ExportCloneBoneInfo();
        //ExportBonePosition_diff();
        //ExportBoneRotation_diff();

        //GetCurrentAnimationStateNum();
        //Debug.Log("アニメーション用の判定用" + StateNum);


        //各ボーンのPositionの差分が一定以下であればTrueを返し、Hold(力を籠める)の時間を計測(10秒)
        if (hasHold == false && CheckBonePostionDifference() == true)
        {
            time_hold += Time.deltaTime;

            if (time_hold > 10.0f)
            {
                hasHold = true;
                time_hold = 0;
                audio.PlayOneShot(ok, 0.9f);
            }

        }
        else
        {
            //hasHold = false
            time_hold = 0;
        }


        // Hold(力を籠める)状態が終えれば、Relax(力を抜く)状態に移行し、20秒経過後、次の筋弛緩法の動きに遷移する。
        if (hasHold == true)
        {
            time_relax += Time.deltaTime;

            if (time_relax > 20.0f)
            {
                audio.PlayOneShot(ok, 0.8f);
                hasRelax = true;

            }
        }
        else
        {
            //hasRelax = false;
            time_relax = 0;
        }

        // hasHoldとhasRelaxの状態を調べる
        CheckBoolState();





        //if (CheckBonePostionDifference() == true && CheckBoneRotationDifference() == true)
        //{
        //    clone_animator.SetBool("bone_distance_check", true);
        //    audio.PlayOneShot(ok, 0.8f);
        //}
        //else clone_animator.SetBool("bone_distance_check", false);
    }
}
