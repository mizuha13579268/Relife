using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMManager 
{
    //public Dictionary<string, FSMStates> stateDic;
    //private FSMStates currentState = null;
    //public FSMStates CurrentState
    //{
    //    get
    //    {
    //        return currentState;
    //    }
    //    set
    //    {
    //        if (currentState != null)
    //        {

    //        }
    //    }
    //}
    ///// <summary>
    ///// 存储所有状态
    ///// </summary>
    //FSMStates[] allStates;

    ///// <summary>
    ///// 存储状态的个数
    ///// </summary>
    //sbyte curStateCount = -1;
    ///// <summary>
    ///// 记录当前状态
    ///// </summary>
    //sbyte curStateIndex = -1;
    //public  FSMManager(sbyte statesCount)
    //{
    //    Inital(statesCount);
    //}
    ///// <summary>
    ///// 初始化
    ///// </summary>
    //public void Inital(sbyte stateCount)
    //{
    //    allStates = new FSMStates[stateCount];
    //}
    
    //public void ChangeState(sbyte index)
    //{
    //    if (index > allStates.Length - 1||index==curStateIndex) return;
    //    if (curStateIndex != -1)
    //    {
    //        allStates[curStateIndex].OnExit();
    //    }
      
    //    curStateIndex = index;
    //    allStates[curStateIndex].OnEnter();
    //}
    //public void Stay()
    //{
    //    if (curStateIndex != -1)
    //    {
    //        allStates[curStateIndex].OnStay();
    //    }
    //}
}
