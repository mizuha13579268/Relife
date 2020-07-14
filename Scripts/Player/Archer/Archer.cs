using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.Threading;

public class Archer : MonoBehaviour
{
    private Animator m_ani;
    private Rigidbody m_Rigidbody;
    private Transform arrowCreatePoint;
    private Transform arrowShootPoint;
    #region
    bool isRolling = false;
    private PlayerAttackState playerAttackState;
    private PlayerRollingState playerRollingState;
    public int currentState;
    bool isEnter = false;
    ///// <summary>
    ///// 实例化
    ///// </summary>
    private void OnEnable()
    {
        Inital();
      //  PlayerBase.Instance.GroundedDo(PlayerBase.Instance.IsGrounded(transform), m_ani,m_Rigidbody);
        m_ani.SetBool("Appear", true);
    }
    private void Inital()
    {
      
        PlayerBase.Instance.Inital();
        m_ani = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        arrowCreatePoint = GameObject.FindGameObjectWithTag("CreatePoint").transform;
        arrowShootPoint = GameObject.FindGameObjectWithTag("ShootPoint").transform;
        playerAttackState = new PlayerAttackState(m_ani);
        playerRollingState = new PlayerRollingState(m_ani);
    }
  
    #endregion
    void Start()
    {
       
    }
    void Update()
    {
        //PlayerBase.Instance.GroundedDo(PlayerBase.Instance.IsGrounded(transform), m_ani,m_Rigidbody);
        //PlayerBase.Instance.isRollingEnd(m_ani);
        PlayerBase.playerCreatePointPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        PlayerBase.playerCreatePointRot = transform.rotation;
        if (isEnter)
        {        
            isEnter = AttackStay(currentState);         
        }
        if (isRolling)
        {
            isRolling = playerRollingState.OnStay(0);
        }
    }

    private bool AttackStay(int attackStateType)
    {
        return playerAttackState.OnStay(attackStateType);
    }
    public void GetSkillIDMessage(string skillID)
    {      
        if (isEnter)
        {
            return;
        }     
        currentState = SkillType.Instance.GetArcherSkillAnimation(skillID);
        playerAttackState.OnEnter(currentState);    
        isEnter = true;
       
    }
    public void RollingStatus()
    {
        if (isRolling)
        {
            return;
        }

        playerRollingState.OnEnter(0);
        isRolling = true;
    }
    public void DrawArrow()
    {
        GameObject arrow = Resources.Load("Prefab/Archer/Arrow") as GameObject;
        GameObject arrows = ObjcetPool.Instance.CreateObject("Arrow", arrow, arrowCreatePoint.position,arrowCreatePoint.rotation);
        arrows.transform.SetParent(arrowCreatePoint);
        ObjcetPool.Instance.CollectObject(arrows, 5.0f);
    }
    private void ArcherSkill1()
    {
      
        GameObject skill1 = Resources.Load("Prefab/Skill/Archer/ASkill1001") as GameObject;
        GameObject skill1s = ObjcetPool.Instance.CreateObject("ASkill1001", skill1,arrowShootPoint.position,ArrowIconMove.quaternions);
        ObjcetPool.Instance.CollectObject(skill1s,5.0f);
        
    }
    private void ArcherSkill2()
    {
        GameObject skill2 = Resources.Load("Prefab/Skill/Archer/ASkill1002") as GameObject;
        GameObject skill2s = ObjcetPool.Instance.CreateObject("ASkill1002", skill2, arrowShootPoint.position, ArrowIconMove.quaternions);
        ObjcetPool.Instance.CollectObject(skill2s, 5.0f);
    }
    private void ArcherSkill3()
    {
        GameObject skill3 = Resources.Load("Prefab/Skill/Archer/ASkill1003") as GameObject;
        GameObject skill3s = ObjcetPool.Instance.CreateObject("ASkill1003", skill3, arrowShootPoint.position, ArrowIconMove.quaternions);
        ObjcetPool.Instance.CollectObject(skill3s, 5.0f);
    }
    private void OnDisable()
    {
        AnimationEven.Instance.CleanAllEvent();
    }
}
