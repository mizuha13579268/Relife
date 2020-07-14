using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingState : PlayerBase
{
    Animator ani;
    private AnimatorStateInfo stateInfo;
    float timer = 0.0f;
    public PlayerRollingState(Animator ani)
    {
        this.ani = ani;

    }
    public override void OnEnter(int statesId)
    {

        ani.SetBool("idle", false);
        ani.SetBool("Rolling", true);
       

    }
    public override bool OnStay(int statesId)
    {
        stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        timer += Time.deltaTime;
      
        if (stateInfo.IsName(GetStateRollingType())
          //  timer>1.0f
            )
        {
            timer = 0;
           // ani.SetBool("Rolling", true);
           // Debug.LogWarning("ssss");
            OnExit(1);
            return false;
        }
        return true;

    }
    public override void OnExit(int statesId)
    {
        // base.OnExit();
        // Debug.Log("Exit" + GetStateAttackType(statesId)+ statesId);
        ani.SetBool("Rolling", false);

        ani.SetBool("Idle", true);
        // Debug.Log(1);

    }
}
