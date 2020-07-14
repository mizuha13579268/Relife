using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSwitchController : MonoBehaviour
{
    private Image[] m_Iamges;
    private Button[] m_Buttons;
    private Transform appearPointPos;
    private bool canSwitch=false;
    private GameObject m_Player;
    void Start()
    {
        m_Iamges = GetComponentsInChildren<Image>();
        m_Buttons = GetComponentsInChildren<Button>();
        appearPointPos = GameObject.Find("PlayerAppearPoint").transform;
        m_Player = GameObject.FindGameObjectWithTag("Player");
        Inital();
    }

    // Update is called once per frame
    void Update()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Inital()
    {
        AddButtonClick();
    }
    private void AddButtonClick()
    {
        foreach (var item in m_Buttons)
        {
            if (item.name.EndsWith("_1"))
            {
                item.onClick.AddListener(()=>
                {
                    if(m_Player.name=="Archer")return;
                    Collect();
                    ObjcetPool.Instance.CreateObject("Character1", Resources.Load("Prefab/Archer/Archer") as GameObject, PlayerBase.playerCreatePointPos, PlayerBase.playerCreatePointRot);
                    SkillMsg.Instance.Inital();
                    AnimationEven.Instance.Inital();
                    UIButtonTouchTrigger.Instance.Inital();
                    CoolTimeManager.Instance.ReInital();
                    CoolTimeManager.coolingTimer4 = 10f;
                });
            }
            else if (item.name.EndsWith("_2"))
            {
                item.onClick.AddListener(() =>
                {
                    if (m_Player.name == "SwordMan") return;
                    Collect();
                    ObjcetPool.Instance.CreateObject("Character2", Resources.Load("Prefab/SwordMan/SwordMan") as GameObject, PlayerBase.playerCreatePointPos, PlayerBase.playerCreatePointRot);
                    SkillMsg.Instance.Inital();
                    AnimationEven.Instance.Inital();
                    UIButtonTouchTrigger.Instance.Inital();
                    CoolTimeManager.Instance.ReInital();
                    CoolTimeManager.coolingTimer5 = 10f;
                });
            }
            else if (item.name.EndsWith("_3"))
            {
                item.onClick.AddListener(() =>
                {
                    if (m_Player.name == "Magicer") return;
                    Collect();
                    ObjcetPool.Instance.CreateObject("Character3", Resources.Load("Prefab/Magicer/Magicer") as GameObject, PlayerBase.playerCreatePointPos, PlayerBase.playerCreatePointRot);
                    SkillMsg.Instance.Inital();
                    AnimationEven.Instance.Inital();
                    UIButtonTouchTrigger.Instance.Inital();
                    CoolTimeManager.Instance.ReInital();
                    CoolTimeManager.coolingTimer6 = 10f;
                });
            }

        }
    }
    private void Collect()
    {
        if (m_Player != null)
        {
            ObjcetPool.Instance.CollectObject(m_Player);
        }
    }
   
}
