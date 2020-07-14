

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkillTypes
{
    /// <summary>
    /// 指向性技能
    /// </summary>
    DirectivitySill,
    /// <summary>
    /// 范围性技能
    /// </summary>
    RangeOfSkill,
    /// <summary>
    /// 不属于任何类型技能
    /// </summary>
    NoneTypeSkill
}

public class SkillType:Singleton<SkillType>
{

    /// <summary>
    /// 技能字典
    /// </summary>
    private Dictionary<int, List<int>> skillDic=new Dictionary<int, List<int>>();
   /// <summary>
   /// 添加技能
   /// </summary>
   /// <param name="skillType"></param>
   /// <param name="SkillID"></param>
   /// <returns></returns>
    public Dictionary<int, List<int>> AddSkill(int skillType,int SkillID)
    {
        if (skillDic.ContainsKey(skillType))
        {
            skillDic[skillType].Add(SkillID);
        } else
        {
            skillDic.Add(skillType,new List<int>());
            skillDic[skillType].Add(SkillID);
        }
        return skillDic;
    }
  /// <summary>
  /// 获取技能类型
  /// </summary>
  /// <param name="skillTypeId"></param>
  /// <returns></returns>
    public string GetSkillType(int skillTypeId)
    {
        switch (skillTypeId)
        {
            case (int)SkillTypes.DirectivitySill:
                return "DirectivitySill";
            case (int)SkillTypes.RangeOfSkill:
                return "RangeOfSkill";
            case (int)SkillTypes.NoneTypeSkill:
                return "NoneTypeSkill";
        }
        return null;
    }
    /// <summary>
    /// 获取技能类型ID
    /// </summary>
    /// <param name="skillId"></param>
    /// <returns></returns>
    public int GetSkillTypeId(int skillId)
    {
        foreach (var type in skillDic.Keys)
        {
            foreach (var tmpId in skillDic[type])
            {
                if (tmpId == skillId)
                {
                    return type;
                }
            }
        }
        return 404;
    }

    public int GetArcherSkillAnimation(string skillID)
    {
        switch (skillID)
        {
            case "norAtk":
                return (int)AttackType.attack1;
            case "Skill1001":
                return (int)AttackType.attack3;
            case "Skill1002":
                return (int)AttackType.attack6;
            case "Skill1003":
                return (int)AttackType.attack2;
        }
        return 0;
    }
    public int GetSwordManAnimation(string skillID)
    {
        switch (skillID)
        {
            case "norAtk":
                return (int)AttackType.attack1;
            case "Skill1001":
                return (int)AttackType.attack2;
            case "Skill1002":
                return (int)AttackType.attack3;
            case "Skill1003":
                return (int)AttackType.attack4;
        }
        return 0;
    }
    public int GetMagicerAnimation(string skillID)
    {
        switch (skillID)
        {
            case "norAtk":
                return (int)AttackType.attack1;
            case "Skill1001":
                return (int)AttackType.attack2;
            case "Skill1002":
                return (int)AttackType.attack3;
            case "Skill1003":
                return (int)AttackType.attack4;
        }
        return 0;
    }
}
