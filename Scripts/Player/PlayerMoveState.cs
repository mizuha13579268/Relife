using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBase
{
    Animator ani;
    private AnimatorStateInfo stateInfo;
    public PlayerMoveState(Animator ani )
    {
        this.ani = ani;
       
    }
    public override void OnEnter(int statesId)
    {

       // ani.SetBool("Idle", false);
        ani.SetInteger("Move", statesId);
        Debug.Log("Enter" + GetStateMoveType(statesId) + statesId);

    }
    public override bool OnStay(int statesId)
    {
        //stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        //Debug.Log("Stay" + GetStateAttackType(statesId) + statesId);
        //if (stateInfo.IsName("Base Layer.Attack." + GetStateAttackType(statesId)))
        //{
        //    ani.SetInteger("Attack", -1);

        //    OnExit(1);
        //    return false;
        //}
        //return true;
        return false;

    }
    public override void OnExit(int statesId)
    {
        // base.OnExit();
        Debug.Log("Exit" + GetStateAttackType(statesId) + statesId);
        ani.SetBool("Idle", true);
        Debug.Log(1);

    }
}
