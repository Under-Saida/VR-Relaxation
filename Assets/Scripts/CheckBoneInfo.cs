using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoneInfo : MonoBehaviour
{
    private GameObject myVRM, cloneVRM;

    public AudioClip ok;
    
    AudioSource audio;
    
    Animator clone_animator;

    BoneInfo my_boneinfo, clone_boneinfo;

    Transform myHead, myNeck, myLeftShoulder, myRightShoulder, myLeftUpperArm, myRightUpperArm, myLeftLowerArm, myRightLowerArm, myLeftHand, myRightHand;
    Transform cloneHead, cloneNeck, cloneLeftShoulder, cloneRightShoulder, cloneLeftUpperArm, cloneRightUpperArm, cloneLeftLowerArm, cloneRightLowerArm, cloneLeftHand, cloneRightHand;
    
    Vector3 HeadPos_diff, NeckPos_diff, LeftShoulderPos_diff, RightShoulderPos_diff, LeftUpperArmPos_diff, RightUpperArmPos_diff, LeftLowerArmPos_diff, RightLowerArmPos_diff, LeftHandPos_diff, RightHandPos_diff;
    Vector3 HeadRot_diff, NeckRot_diff, LeftShoulderRot_diff, RightShoulderRot_diff, LeftUpperArmRot_diff, RightUpperArmRot_diff, LeftLowerArmRot_diff, RightLowerArmRot_diff, LeftHandRot_diff, RightHandRot_diff;

    bool bonePosCheck_ok, boneRotCheck_ok;


    bool CheckBonePostionDifference() 
    {
        if (HeadPos_diff.x < 0.05 && HeadPos_diff.y < 0.05 && HeadPos_diff.z < 0.05 &&
        NeckPos_diff.x < 0.05 && NeckPos_diff.y < 0.05 && NeckPos_diff.z < 0.05 &&

        LeftShoulderPos_diff.x < 0.05 && LeftShoulderPos_diff.y < 0.05 && LeftShoulderPos_diff.z < 0.05 &&
        RightShoulderPos_diff.x < 0.05 && RightShoulderPos_diff.y < 0.05 && RightShoulderPos_diff.z < 0.05 &&

        LeftUpperArmPos_diff.x < 0.05 && LeftUpperArmPos_diff.y < 0.05 && LeftUpperArmPos_diff.z < 0.05 &&
        RightUpperArmPos_diff.x < 0.05 && RightUpperArmPos_diff.y < 0.05 && RightUpperArmPos_diff.z < 0.05 &&

        LeftLowerArmPos_diff.x < 0.05 && LeftLowerArmPos_diff.y < 0.05 && LeftLowerArmPos_diff.z < 0.05 &&
        LeftLowerArmPos_diff.x < 0.05 && LeftLowerArmPos_diff.y < 0.05 && LeftLowerArmPos_diff.z < 0.05)

        //LeftHandPos_diff.x < 0.05 && LeftHandPos_diff.y < 0.05 && LeftHandPos_diff.z < 0.05 &&
        //RightHandPos_diff.x < 0.05 && RightHandPos_diff.y < 0.05 && RightHandPos_diff.z < 0.05)
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

    bool CheckBoneRotationDifference()
    {
        if (HeadRot_diff.x < 0.05 && HeadRot_diff.y < 0.05 && HeadRot_diff.z < 0.05 &&
        NeckRot_diff.x < 0.05 && NeckRot_diff.y < 0.05 && NeckRot_diff.z < 0.05 &&

        LeftShoulderRot_diff.x < 0.05 && LeftShoulderRot_diff.y < 0.05 && LeftShoulderRot_diff.z < 0.05 &&
        RightShoulderRot_diff.x < 0.05 && RightShoulderRot_diff.y < 0.05 && RightShoulderRot_diff.z < 0.05 &&

        LeftUpperArmRot_diff.x < 0.05 && LeftUpperArmRot_diff.y < 0.05 && LeftUpperArmRot_diff.z < 0.05 &&
        RightUpperArmRot_diff.x < 0.05 && RightUpperArmRot_diff.y < 0.05 && RightUpperArmRot_diff.z < 0.05 &&

        LeftLowerArmRot_diff.x < 0.05 && LeftLowerArmRot_diff.y < 0.05 && LeftLowerArmRot_diff.z < 0.05 &&
        LeftLowerArmRot_diff.x < 0.05 && LeftLowerArmRot_diff.y < 0.05 && LeftLowerArmRot_diff.z < 0.05)

        //LeftHandRot_diff.x < 0.05 && LeftHandRot_diff.y < 0.05 && LeftHandRot_diff.z < 0.05 &&
        //RightHandRot_diff.x < 0.05 && RightHandRot_diff.y < 0.05 && RightHandRot_diff.z < 0.05)
        {
            boneRotCheck_ok = true;
            return boneRotCheck_ok;
        }
        else
        {
            boneRotCheck_ok = false;
            return boneRotCheck_ok;
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        myVRM = GameObject.Find("SampleAvatar_C");
        my_boneinfo = myVRM.GetComponent<BoneInfo>();

        cloneVRM = GameObject.Find("SampleAvatar_C(Clone)");
        clone_boneinfo = cloneVRM.GetComponent<BoneInfo>();
        clone_animator = cloneVRM.GetComponent<Animator>();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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
        HeadPos_diff = clone_boneinfo.transHead.position - my_boneinfo.transHead.position;

        NeckPos_diff = clone_boneinfo.transNeck.position - my_boneinfo.transNeck.position;

        LeftShoulderPos_diff = clone_boneinfo.transLeftShoulder.position - my_boneinfo.transLeftShoulder.position;

        RightShoulderPos_diff = clone_boneinfo.transRightShoulder.position - my_boneinfo.transRightShoulder.position;

        LeftUpperArmPos_diff = clone_boneinfo.transLeftUpperArm.position - my_boneinfo.transLeftUpperArm.position;

        RightUpperArmPos_diff = clone_boneinfo.transRightUpperArm.position - my_boneinfo.transRightUpperArm.position;

        LeftLowerArmPos_diff = clone_boneinfo.transLeftLowerArm.position - my_boneinfo.transLeftLowerArm.position;

        RightLowerArmPos_diff = clone_boneinfo.transRightLowerArm.position - my_boneinfo.transRightLowerArm.position;

        //LeftHandPos_diff = clone_boneinfo.transLeftHand.position - my_boneinfo.transLeftHand.position;

        //RightHandPos_diff = clone_boneinfo.transRightHand.position - my_boneinfo.transRightHand.position;



        // ボーンRotation情報の差分を部位ごとに格納(Vector3に変換)
        HeadRot_diff = clone_boneinfo.transHead.rotation.eulerAngles - my_boneinfo.transHead.rotation.eulerAngles;

        NeckRot_diff = clone_boneinfo.transNeck.rotation.eulerAngles - my_boneinfo.transNeck.rotation.eulerAngles;

        LeftShoulderRot_diff = clone_boneinfo.transLeftShoulder.rotation.eulerAngles - my_boneinfo.transLeftShoulder.rotation.eulerAngles;

        RightShoulderRot_diff = clone_boneinfo.transRightShoulder.rotation.eulerAngles - my_boneinfo.transRightShoulder.rotation.eulerAngles;

        LeftUpperArmRot_diff = clone_boneinfo.transLeftUpperArm.rotation.eulerAngles - my_boneinfo.transLeftUpperArm.rotation.eulerAngles;

        RightUpperArmRot_diff = clone_boneinfo.transRightUpperArm.rotation.eulerAngles - my_boneinfo.transRightUpperArm.rotation.eulerAngles;

        LeftLowerArmRot_diff = clone_boneinfo.transLeftLowerArm.rotation.eulerAngles - my_boneinfo.transLeftLowerArm.rotation.eulerAngles;

        RightLowerArmRot_diff = clone_boneinfo.transRightLowerArm.rotation.eulerAngles - my_boneinfo.transRightLowerArm.rotation.eulerAngles;

        //LeftHandRot_diff = clone_boneinfo.transLeftHand.rotation.eulerAngles - my_boneinfo.transLeftHand.rotation.eulerAngles;

        //RightHandRot_diff = clone_boneinfo.transRightHand.rotation.eulerAngles - my_boneinfo.transRightHand.rotation.eulerAngles;


        // 各ボーンのPositionの差分が一定以下であればTrueを返す。
        if (CheckBonePostionDifference() == true && CheckBoneRotationDifference() == true)
        {
            clone_animator.SetBool("bone_distance_check", true);
            audio.PlayOneShot(ok, 0.8f);
        }
        else clone_animator.SetBool("bone_distance_check", false);
    }
}
