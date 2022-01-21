using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMR_AnimationController : MonoBehaviour
{   
    private GameObject cloneVRM, ManageObj;

    Animator clone_animator;

    CheckBoneInfo checkbone_info;

    int StateNum = 0, currentStateNum;

    public bool hasEndAnimaton = false;

    int GetCurrentAnimationStateNum()
    {
        //clone_animator = GetComponent<Animator>();
        if (clone_animator.GetCurrentAnimatorStateInfo(0).IsName("Sit_T-Pose"))
        {
            currentStateNum = 0;
        }
        if (clone_animator.GetCurrentAnimatorStateInfo(0).IsName("Arm"))
        {
            currentStateNum = 1;
        }
        if (clone_animator.GetCurrentAnimatorStateInfo(0).IsName("Shoulder"))
        {
            currentStateNum = 2;
        }
        //Debug.Log("現在のアニメーションの状態" + currentStateNum);
        return currentStateNum;
    }

    public bool GethasEndAnimaton()
    {
        return hasEndAnimaton;
    }

    // Start is called before the first frame update
    void Start()
    {
        ManageObj = GameObject.Find("ManageObject");
        cloneVRM = GameObject.Find("SampleAvatar_C(Clone)");
        checkbone_info = ManageObj.GetComponent<CheckBoneInfo>();
        clone_animator = cloneVRM.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("アニメーションの判定" + StateNum);
        //checkbone_info.CheckBoolState();
        if (checkbone_info.CheckBoolState() == true)
        {
            if (GetCurrentAnimationStateNum() == StateNum)
            {
                hasEndAnimaton = false;
                clone_animator.SetBool("bone_distance_check", true);
            }
            else
            {
                clone_animator.SetBool("bone_distance_check", false);
                StateNum += 1;
                hasEndAnimaton = true;
            }
        }

        GethasEndAnimaton();
        //Debug.Log("筋弛緩の流れを一周したか" + hasEndAnimaton);

    }
}
