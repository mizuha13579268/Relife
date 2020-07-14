using GameFramework.Fsm;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  enum StateType
{
    AttackType,
    MoveType,
    JumpingType
}
#region ATTACK_TYPE
public enum AttackType
{
    Error,
    attack1,
    attack2,
    attack3,
    attack4,
    attack5,
    attack6,
    attack_first2,
    attack_kick,
    MAX
}
#endregion
#region MOVE_TYPE
public enum MoveType
{
    Error,
    Idle,
    Walk,
    Run,
    MAX
}
#endregion
#region JUMPING_TYPE
public enum JumpingType
{
    Error,
    Jump_Stand_Start,
    Jump_Running_Start,
    Jump_Stand_End_02,
    MAX
}
#endregion
public class PlayerBase :FSMBase
{
    public FSMStates fsmStates;

    /// <summary>
    /// 存储角色出现的位置
    /// </summary>
    public static Vector3 memoryAppearPos;

    private static PlayerBase instance;
    public static PlayerBase Instance
    {
        get
        {
            if (instance == null)
            {
                return instance = new PlayerBase();
            }
            return instance;
        }
    }
    public static Vector3 playerCreatePointPos;
    public static Quaternion playerCreatePointRot;
    public void Inital()
    {
        fsmStates = new FSMStates();
        fsmStates.AddStateType(GetStateType((int)StateType.AttackType));
        fsmStates.AddStateType(GetStateType((int)StateType.MoveType));
        fsmStates.AddStateType(GetStateType((int)StateType.JumpingType));
        #region AddAttackStates
        fsmStates.AddStates(GetStateType((int)StateType.AttackType),
            GetStateAttackType((int)AttackType.attack1),(int) AttackType.attack1);
        fsmStates.AddStates(GetStateType((int)StateType.AttackType),
           GetStateAttackType((int)AttackType.attack2), (int)AttackType.attack2);
        fsmStates.AddStates(GetStateType((int)StateType.AttackType),
            GetStateAttackType((int)AttackType.attack3), (int)AttackType.attack3);
        fsmStates.AddStates(GetStateType((int)StateType.AttackType),
           GetStateAttackType((int)AttackType.attack4), (int)AttackType.attack4);
        fsmStates.AddStates(GetStateType((int)StateType.AttackType),
            GetStateAttackType((int)AttackType.attack5), (int)AttackType.attack5);
        fsmStates.AddStates(GetStateType((int)StateType.AttackType),
           GetStateAttackType((int)AttackType.attack6), (int)AttackType.attack6);
        fsmStates.AddStates(GetStateType((int)StateType.AttackType),
            GetStateAttackType((int)AttackType.attack_first2), (int)AttackType.attack_first2);
        fsmStates.AddStates(GetStateType((int)StateType.AttackType),
           GetStateAttackType((int)AttackType.attack_kick), (int)AttackType.attack_kick);
        #endregion
        #region AddMoveType
        fsmStates.AddStates(GetStateType((int)StateType.MoveType), GetStateMoveType((int)MoveType.Idle), (int)MoveType.Idle);
        fsmStates.AddStates(GetStateType((int)StateType.MoveType), GetStateMoveType((int)MoveType.Walk), (int)MoveType.Walk);
        fsmStates.AddStates(GetStateType((int)StateType.MoveType), GetStateMoveType((int)MoveType.Run), (int)MoveType.Run);
        #endregion
        #region AddJumpingType
        fsmStates.AddStates(GetStateType((int)StateType.JumpingType), GetStateJumpingType((int)JumpingType.Jump_Stand_Start), (int)JumpingType.Jump_Stand_Start);
        fsmStates.AddStates(GetStateType((int)StateType.JumpingType), GetStateJumpingType((int)JumpingType.Jump_Running_Start), (int)JumpingType.Jump_Running_Start);
        fsmStates.AddStates(GetStateType((int)StateType.JumpingType), GetStateJumpingType((int)JumpingType.Jump_Stand_End_02), (int)JumpingType.Jump_Stand_End_02);
        #endregion
    }
    public string GetStateType(int stateType)
    {
        switch (stateType)
        {
            case (int)StateType.AttackType:
                return "AttackType";
            case (int)StateType.MoveType:
                return "MoveType";
            case (int)StateType.JumpingType:
                return "JumpingType";
        }
        return null;
    }
    public string GetStateRollingType()
    {
        return "RollingTree";
    }
    public string GetStateAttackType(int stateAttackType)
    {
        switch (stateAttackType)
        {
            case (int)AttackType.attack1:
                return "attack1";
            case (int)AttackType.attack2:
                return "attack2";
            case (int)AttackType.attack3:
                return "attack3";
            case (int)AttackType.attack4:
                return "attack4";
            case (int)AttackType.attack5:
                return "attack5";
            case (int)AttackType.attack6:
                return "attack6";
            case (int)AttackType.attack_first2:
                return "attack_first2";
            case (int)AttackType.attack_kick:
                return "attack_kick";
        }
        return null;
    }
    public string GetStateMoveType(int stateMoveType)
    {
        switch (stateMoveType)
        {
            case (int)MoveType.Idle:
                return "Idle";
            case (int)MoveType.Walk:
                return "Walk";
            case (int)MoveType.Run:
                return "Run";
        }
        return null;
    }
    public string GetStateJumpingType(int stateJumpingType)
    {
        switch (stateJumpingType)
        {
            case (int)JumpingType.Jump_Stand_Start:
                return "Jump_Stand_Start";
            case (int)JumpingType.Jump_Running_Start:
                return "Jump_Running_Start";
            case (int)JumpingType.Jump_Stand_End_02:
                return "Jump_Stand_End_02";
        }
        return null;
    }
    public int GetStateId(int stateType,int stateName)
    {
        if (GetStateType(stateType) == "AttackType")
        {
         return  fsmStates.GetStatesID("AttackType", GetStateAttackType(stateName));
        }
        return -1;
    }
    //public bool IsGrounded(Transform transform)
    //{
    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 0.5f,LayerMask.GetMask("Floor")))//Physics.Raycast(射线发出位置，射线方向，射线长度，射线碰撞检测Layer）
    //    {
    //        return true;
    //    }
    //    else
    //        return  false;

    //}
   
    //public void GroundedDo(bool isGrounded,Animator m_ani,Rigidbody rigidbody)
    //{
    //    if (isGrounded)
    //    {
           
    //        m_ani.SetBool("Appear", false);
    //        m_ani.SetBool("Idle", true);
    //        rigidbody.isKinematic = true;
    //    }
    //    else
    //    {
          
           
    //       rigidbody.isKinematic = false;
    //    }
      
    //}
    public void isRollingEnd(Animator m_ani)
    {
        if (m_ani.GetCurrentAnimatorStateInfo(0).IsName("RollingTree") && m_ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
        {
            m_ani.SetBool("Rolling", false);
        }
    }
}
