using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class CheckBoneInfo : MonoBehaviour
{
    private GameObject myVRM;
    private GameObject cloneVRM;
    public AudioClip ok;
    
    AudioSource audio;
  
    BoneInfo my_boneinfo, clone_boneinfo;
    PMR_AnimationController pmr_animation_controller;

    Transform myHead, myNeck, myLeftShoulder, myRightShoulder, myLeftUpperArm, myRightUpperArm, myLeftLowerArm, myRightLowerArm, myLeftHand, myRightHand;
    Transform cloneHead, cloneNeck, cloneLeftShoulder, cloneRightShoulder, cloneLeftUpperArm, cloneRightUpperArm, cloneLeftLowerArm, cloneRightLowerArm, cloneLeftHand, cloneRightHand;
    
    Vector3 HeadPos_diff, NeckPos_diff, LeftShoulderPos_diff, RightShoulderPos_diff, LeftUpperArmPos_diff, RightUpperArmPos_diff, LeftLowerArmPos_diff, RightLowerArmPos_diff, LeftHandPos_diff, RightHandPos_diff;
    //Vector3 HeadRot_diff, NeckRot_diff, LeftShoulderRot_diff, RightShoulderRot_diff, LeftUpperArmRot_diff, RightUpperArmRot_diff, LeftLowerArmRot_diff, RightLowerArmRot_diff, LeftHandRot_diff, RightHandRot_diff;

    //float time_hold, time_relax;
    float time_hold=10.0f, time_relax=20.0f;

    int StateNum = 0, currentStateNum;

    bool bonePosCheck_ok, boneRotCheck_ok, endPose;
    public bool hasHold = false, hasRelax = false;


    public float Get_timeHold()
    {
        return time_hold;
    }

    public float Get_timeRelax()
    {
        return time_relax;
    }

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


    public bool CheckBonePostionDifference() 
    {
        // 差分の絶対値が一定値以下なら、動きが合っているとする。 閾値を一度大きくする + magnitudeで取得を行う 0.3fがデフォルト
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
            //デバッグ用
            //bonePosCheck_ok = true;
            
            bonePosCheck_ok = false;
            return bonePosCheck_ok;
        }
    }

    void ExportCloneBone_PosInfo()
    {
        //cloneHead
        StreamWriter clone_head = new StreamWriter("../data/CloneBone_data/Head.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_head.WriteLine("position={0}", cloneHead.position);
        clone_head.Close();

        //cloneNeck
        StreamWriter clone_neck = new StreamWriter("../data/CloneBone_data/Neck.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_neck.WriteLine("position={0}", cloneNeck.position);
        clone_neck.Close();

        //cloneLeftShoulder
        StreamWriter clone_L_shoulder = new StreamWriter("../data/CloneBone_data/LeftShoulder.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_L_shoulder.WriteLine("position={0}", cloneLeftShoulder.position);
        clone_L_shoulder.Close();

        //cloneRightShoulder
        StreamWriter clone_R_shoulder = new StreamWriter("../data/CloneBone_data/RightShoulder.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_R_shoulder.WriteLine("position.x={0}", cloneRightShoulder.position);
        clone_R_shoulder.Close();

        //cloneLeftUpperArm
        StreamWriter clone_L_upperArm = new StreamWriter("../data/CloneBone_data/LeftUpperArm.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_L_upperArm.WriteLine("position.x={0}", cloneLeftUpperArm.position);
        clone_L_upperArm.Close();

        //cloneRightUpperArm
        StreamWriter clone_R_upperArm = new StreamWriter("../data/CloneBone_data/RightUpperArm.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_R_upperArm.WriteLine("position.x={0}", cloneRightUpperArm.position);
        clone_R_upperArm.Close();

        //cloneLeftLowerArm
        StreamWriter clone_L_lowerArm = new StreamWriter("../data/CloneBone_data/LeftLowerArm.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_L_lowerArm.WriteLine("position.x={0}", cloneLeftLowerArm.position);
        clone_L_lowerArm.Close();

        //cloneRightLowerArm
        StreamWriter clone_R_lowerArm = new StreamWriter("../data/CloneBone_data/RightLowerArm.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_R_lowerArm.WriteLine("position.x={0}", cloneRightLowerArm.position);
        clone_R_lowerArm.Close();

        //cloneLeftHand
        StreamWriter clone_L_hand = new StreamWriter("../data/CloneBone_data/LeftHand.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_L_hand.WriteLine("position.x={0}", cloneLeftHand.position);
        clone_L_hand.Close();

        //cloneRightHand
        StreamWriter clone_R_hand = new StreamWriter("../data/CloneBone_data/RightHand.txt", true, Encoding.GetEncoding("Shift_JIS"));
        clone_R_hand.WriteLine("position.x={0}", cloneRightHand.position);
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

    // Start is called before the first frame update
    void Start()
    {
        myVRM = GameObject.Find("SampleAvatar_C");
        my_boneinfo = myVRM.GetComponent<BoneInfo>();

        cloneVRM = GameObject.Find("SampleAvatar_C(Clone)");
        clone_boneinfo = cloneVRM.GetComponent<BoneInfo>();
        pmr_animation_controller = this.gameObject.GetComponent<PMR_AnimationController>();

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
            time_hold = 10.0f;
            time_relax = 20.0f;
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

        // Bone情報の取得に使用（普段はコメントアウトしておく）
        ExportCloneBone_PosInfo();
        //ExportBonePosition_diff();

        //GetCurrentAnimationStateNum();
        //Debug.Log("アニメーション用の判定用" + StateNum);


        
        if (hasHold == false && CheckBonePostionDifference() == true)
        {
            time_hold -= Time.deltaTime;

            if (time_hold <= 0)
            {
                hasHold = true;
                audio.PlayOneShot(ok, 0.9f);
            }
        }
        else
        {
            time_hold = 10.0f;
        }


        
        if (hasHold == true && hasRelax == false)
        {
            time_relax -= Time.deltaTime;

            if (time_relax <= 0)
            {
                hasRelax = true;
                audio.PlayOneShot(ok, 0.9f);

            }
        }
        else
        {
            time_relax = 20.0f;
        }

        
        CheckBoolState();





        //if (CheckBonePostionDifference() == true && CheckBoneRotationDifference() == true)
        //{
        //    clone_animator.SetBool("bone_distance_check", true);
        //    audio.PlayOneShot(ok, 0.8f);
        //}
        //else clone_animator.SetBool("bone_distance_check", false);
    }
}
