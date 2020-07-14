using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBase
{
    Animator ani;
    private AnimatorStateInfo stateInfo;
    float timer = 0.0f;
    public PlayerAttackState(Animator ani)
    {
        this.ani = ani;
      
    }
    public override void OnEnter(int statesId)
    {

     
        ani.SetInteger("Attack", statesId);
      //  Debug.Log("Enter" + GetStateAttackType(statesId)+ statesId);

    }
    public override bool OnStay(int statesId)
    {
        stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        timer += Time.deltaTime;
      //  Debug.Log("Stay" + GetStateAttackType(statesId)+ statesId);
        if (stateInfo.IsName("Base Layer.Attack."+GetStateAttackType(statesId))
           // &&timer>2.0f
            )
        {
            timer = 0;
            ani.SetInteger("Attack", -1);
        //    Debug.LogWarning("ssss");
            OnExit(1);
            return false;
        }
        return true;
        
    }
    public override void OnExit(int statesId)
    {
        // base.OnExit();
       // Debug.Log("Exit" + GetStateAttackType(statesId)+ statesId);
        ani.SetBool("Idle", true);
       // Debug.Log(1);

    }
}
