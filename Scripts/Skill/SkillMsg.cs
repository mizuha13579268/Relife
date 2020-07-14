using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMsg :Singleton<SkillMsg>
{
    private Dictionary<string, List<Dictionary<string, object>>> skillJsonMsg;
    private string playerName;
    public void Inital()
    {
        skillJsonMsg= ReadData.Instance.ReadSkillData();
        playerName = GameObject.FindGameObjectWithTag("Player").name.ToString();
       // Debug.Log(skillJsonMsg["SwordMan"][0]["TypeId"]);
    }
    public string GetSkillName(int ID)
    {
        return skillJsonMsg[playerName][ID]["SkillName"].ToString();
    }
    public string GetSkillID(int ID)
    {
        return skillJsonMsg[playerName][ID]["SkillID"].ToString();
    }
    public int GetSkillTypeID(int ID)
    {
        return (int)skillJsonMsg[playerName][ID]["TypeId"];
    }
    public string GetSkillMsg(int ID)
    {
        return skillJsonMsg[playerName][ID]["Msg"].ToString();
    }
    public string GetSkillSpritePath(int ID)
    {
        return skillJsonMsg[playerName][ID]["Sprite"].ToString();
    }
    public float GetCoolingTime(int ID)
    {
        return Convert.ToSingle( skillJsonMsg[playerName][ID]["CoolingTime"]);
    }
}
