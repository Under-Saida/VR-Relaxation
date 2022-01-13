using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class BoneInfo : MonoBehaviour
{
    private Animator anime;
    private AnimatorStateInfo currentState;
    public  GameObject VRMModel;

    public Transform transHead, transNeck, transLeftShoulder, transRightShoulder, transLeftUpperArm, transRightUpperArm, transLeftLowerArm, transRightLowerArm, transLeftHand, transRightHand;

    // Start is called before the first frame update
    void Start()
    {
        VRMModel = this.gameObject;  //GameObject.Find("SampleAvatar_C");
        anime = VRMModel.GetComponent<Animator>();
        //transHead = anime.GetBoneTransform(HumanBodyBones.Head);
        //transFoot = anime.GetBoneTransform(HumanBodyBones.RightFoot);
        // transFoot.position.yが高さになる！
    }

    // Update is called once per frame
    void Update()
    {
        //アバターの頭のボーン情報を取得し、DebugLogで出力する
        transHead = anime.GetBoneTransform(HumanBodyBones.Head);

        //アバターの首のボーン情報を取得する
        transNeck = anime.GetBoneTransform(HumanBodyBones.Neck);

        //Spine 背骨の第一ボーン

        //Chest 胸のボーン

        transLeftShoulder = anime.GetBoneTransform(HumanBodyBones.LeftShoulder);

        transRightShoulder = anime.GetBoneTransform(HumanBodyBones.RightShoulder);

        transLeftUpperArm = anime.GetBoneTransform(HumanBodyBones.LeftUpperArm);

        transRightUpperArm = anime.GetBoneTransform(HumanBodyBones.RightUpperArm);

        transLeftLowerArm = anime.GetBoneTransform(HumanBodyBones.LeftLowerArm);

        transRightLowerArm = anime.GetBoneTransform(HumanBodyBones.RightLowerArm);

        transLeftHand = anime.GetBoneTransform(HumanBodyBones.LeftHand);

        transRightHand = anime.GetBoneTransform(HumanBodyBones.RightHand);


        //LeftUpperLeg 左太もものボーン

        //RightUpperLeg 右太もものボーン

        //LeftLowerLeg 左ひざのボーン

        //RightLowerLeg 右ひざのボーン

        //LeftFoot 左足首のボーン

        //RightFoot 右足首のボーン

        //LeftToes 左つま先のボーン

        //RightToes 右つま先のボーン

        //Hips 尻のボーン





        //LeftUpperLeg 左太もものボーン

        //RightUpperLeg 右太もものボーン

        //LeftLowerLeg 左ひざのボーン

        //RightLowerLeg 右ひざのボーン

        //LeftFoot 左足首のボーン

        //RightFoot 右足首のボーン

        //Spine 背骨の第一ボーン

        //Chest 胸のボーン

        //UpperChest This is the Upper Chest bone.

        //Neck 首のボーン

        //Head 頭のボーン

        //LeftShoulder 左肩のボーン

        //RightShoulder 右肩のボーン

        //LeftUpperArm 左上腕のボーン

        //RightUpperArm 右上腕のボーン

        //LeftLowerArm 左ひじのボーン

        //RightLowerArm 右ひじのボーン

        //LeftHand 左手首のボーン

        //RightHand 右手首のボーン

        //LeftToes 左つま先のボーン

        //RightToes 右つま先のボーン


    }
}
