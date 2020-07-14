using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStates : FSMBase
{
    /// <summary>
    /// 用来存储状态的字典
    /// </summary>
    Dictionary<string, Dictionary<string, int>> statesDic=new Dictionary<string, Dictionary<string, int>>();
    int defaultStates = -1;
  
   
    /// <summary>
    /// 获取状态ID值
    /// </summary>
    /// <param name="statesType"></param>
    /// <param name="statesName"></param>
    /// <returns></returns>
    public int GetStatesID(string statesType,string statesName)
    {
        if (statesDic.ContainsKey(statesType))
        {
            if (statesDic[statesType].ContainsKey(statesName))
            {
                return statesDic[statesType][statesName];
            }
        }
        return defaultStates;
    }
    /// <summary>
    /// 获取状态名
    /// </summary>
    /// <param name="statesType"></param>
    /// <param name="statesID"></param>
    /// <returns></returns>
    public string GetStatesName(string statesType, int statesID)
    {
        if (statesDic.ContainsKey(statesType))
        {
            foreach (var tmpName in statesDic[statesType].Keys)
            {
                if (statesDic[statesType][tmpName] == statesID)
                {
                    return tmpName;
                }
            }
        }
        return null;
    }
    /// <summary>
    /// 获取状态类型
    /// </summary>
    /// <param name="statesName"></param>
    /// <returns></returns>
    public string GetStatesType(string statesName)
    {
        foreach (var tmpType in statesDic.Keys)
        {
            foreach (var tmpName in statesDic[tmpType].Keys)
            {
                if (tmpName == statesName)
                {
                    return tmpType;
                }
            }
        }
        return null;
    }
    /// <summary>
    /// 获取状态类型
    /// </summary>
    /// <param name="statesName"></param>
    /// <returns></returns>
    public string GetStatesType(int statesID)
    {
        foreach (var tmpType in statesDic.Keys)
        {
            foreach (var tmpID in statesDic[tmpType].Values)
            {
                if (tmpID == statesID)
                {
                    return tmpType;
                }
            }
        }
        return null;
    }
    /// <summary>
    /// 移除状态
    /// </summary>
    /// <param name="removeStateType"></param>
    /// <returns></returns>
    public Dictionary<string,Dictionary<string, int>> RemoveStates(string removeStateType)
    {
        if (statesDic.ContainsKey(removeStateType))
        {
            statesDic.Remove(removeStateType);
        }
        return statesDic;
    }
    /// <summary>
    /// 移除状态
    /// </summary>
    /// <param name="removeStateType"></param>
    /// <param name="removeStateName"></param>
    /// <returns></returns>
    public Dictionary<string, Dictionary<string, int>> RemoveStates(string removeStateType,string removeStateName)
    {
        if (statesDic[removeStateType].ContainsKey(removeStateName))
        {
            statesDic[removeStateType].Remove(removeStateName);
        }
        return statesDic;
    }
    /// <summary>
    /// 添加状态类型
    /// </summary>
    /// <param name="addStateType"></param>
    /// <returns></returns>
    public Dictionary<string, Dictionary<string, int>> AddStateType(string addStateType)
    {
        if (!statesDic.ContainsKey(addStateType))
        {
            statesDic.Add(addStateType, new Dictionary<string, int>());
        }
        return statesDic;
    }
    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="addStateType"></param>
    /// <param name="addStateName"></param>
    /// <param name="addStateId"></param>
    /// <returns></returns>
    public Dictionary<string, Dictionary<string, int>> AddStates(string addStateType, string addStateName, int addStateId)
    {
        if (!statesDic[addStateType].ContainsKey(addStateName))
        {
            statesDic[addStateType].Add(addStateName, addStateId);
        }
        return statesDic;
    }

   
}
