using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBase
{
    private sbyte statesId;
    public virtual sbyte StatesId
        {
        get
        {
            return statesId;
        }
        set
        {
            statesId = value;
        }
    }
    /// <summary>
    /// 进入状态
    /// </summary>
    public virtual void OnEnter(int statesId)
    { }
    /// <summary>
    /// 在状态中
    /// </summary>
    public virtual bool OnStay(int statesId)
    {
        return false;
    }
    /// <summary>
    /// 退出状态
    /// </summary>
    public virtual void OnExit(int statesId)
    { }
}
