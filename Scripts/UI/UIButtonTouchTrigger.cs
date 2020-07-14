using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonTouchTrigger :Singleton<UIButtonTouchTrigger>
{
    private GameObject attackPanel;
    private Button[] button;
    private GameObject player;
  
    public enum TouchMessageType
    {
        NormalAttack,
        Skill1,
        Skill2,
        Skill3
    }
    public void Inital()
    {
       
        attackPanel = GameObject.FindGameObjectWithTag("AttackPanel");
        player = GameObject.FindGameObjectWithTag("Player");
        button = attackPanel.GetComponentsInChildren<Button>();
      
        AddClick();
    }
    public void AddClick()
    {
        foreach (var btn in button)
        {
            if (btn.name.StartsWith("NorAttack"))
            {
               
                btn.onClick.AddListener(NormalAttackOnClick);
             
            }
            else if (btn.name.StartsWith("Skill1"))
            {
               
                btn.GetComponentInChildren<Image>().sprite = Resources.Load(SkillMsg.Instance.GetSkillSpritePath(0),typeof(Sprite)) as Sprite;
                btn.onClick.AddListener(Skill1OnClick);
            }
            else if (btn.name.StartsWith("Skill2"))
            {
                btn.GetComponentInChildren<Image>().sprite = Resources.Load(SkillMsg.Instance.GetSkillSpritePath(1), typeof(Sprite)) as Sprite;
                btn.onClick.AddListener(Skill2OnClick);
            }
            else if (btn.name.StartsWith("Skill3"))
            {
                btn.GetComponentInChildren<Image>().sprite = Resources.Load(SkillMsg.Instance.GetSkillSpritePath(2), typeof(Sprite)) as Sprite;
                btn.onClick.AddListener(Skill3OnClick);
            }
            else if (btn.name.StartsWith("Rolling"))
            {
                
                btn.onClick.AddListener(RollingOnClick);
            }
        }
    }
    public void NormalAttackOnClick()
    {
        Debug.Log("NorAttack");
      
        player.SendMessage("GetSkillIDMessage", "norAtk");
       
    }
    public void Skill1OnClick()
    {
       
         SkillRos();
         player.SendMessage("GetSkillIDMessage", SkillMsg.Instance.GetSkillID(0));
        CoolTimeManager.coolingTimer1 = SkillMsg.Instance.GetCoolingTime(0);
      
    }
    public void Skill2OnClick()
    {
        SkillRos();
        
        player.SendMessage("GetSkillIDMessage", SkillMsg.Instance.GetSkillID(1));
        CoolTimeManager.coolingTimer2 = SkillMsg.Instance.GetCoolingTime(1);
    }
    public void Skill3OnClick()
    {

       
        SkillRos();      
        player.SendMessage("GetSkillIDMessage", SkillMsg.Instance.GetSkillID(2));
        CoolTimeManager.coolingTimer3 = SkillMsg.Instance.GetCoolingTime(2);
    }
    private void RollingOnClick()
    {
        player.SendMessage("RollingStatus");
    }
    private void SkillRos()
    {
        if (ArrowIconMove.quaternions != Quaternion.identity)
            player.transform.rotation = ArrowIconMove.quaternions;
       
    }
    
}
