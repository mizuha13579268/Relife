using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicer : MonoBehaviour
{
    private Animator m_ani;
    public int currentState;
    bool isEnter = false;
    bool isRolling = false;
    private PlayerAttackState playerAttackState;
    private PlayerRollingState playerRollingState;
    private Rigidbody m_Rigidbody;
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
        playerAttackState = new PlayerAttackState(m_ani);
        playerRollingState = new PlayerRollingState(m_ani);
    }

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
        currentState = SkillType.Instance.GetMagicerAnimation(skillID);
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
    private void MagicerNorAttack()
    {
        GameObject norAtk = Resources.Load("Prefab/Skill/Magicer/NorAtk") as GameObject;
        GameObject norAtks = ObjcetPool.Instance.CreateObject("NorAtk", norAtk, new Vector3(transform.position.x,
            transform.position.y + 0.5f, transform.position.z), transform.rotation);
        ObjcetPool.Instance.CollectObject(norAtks, 5.0f);
    }
    private void MagicerManSkill1()
    {
       
        GameObject skill1 = Resources.Load("Prefab/Skill/Magicer/MSkill1001") as GameObject;
        GameObject skill1s = ObjcetPool.Instance.CreateObject("MSkill1001", skill1,new Vector3(ArrowIconMove.m_position.x
            , ArrowIconMove.m_position.y+1.5f, ArrowIconMove.m_position.z), transform.rotation);
        ObjcetPool.Instance.CollectObject(skill1s, 5.0f);
    }
    private void MagicerManSkill2()
    {
        GameObject skill2 = Resources.Load("Prefab/Skill/Magicer/MSkill1002") as GameObject;
        GameObject skill2s = ObjcetPool.Instance.CreateObject("MSkill1002", skill2, transform.position, transform.rotation);
        ObjcetPool.Instance.CollectObject(skill2s, 5.0f);
    }
    private void MagicerManSkill3()
    {
        GameObject skill3 = Resources.Load("Prefab/Skill/Magicer/MSkill1003") as GameObject;
        GameObject skill3s = ObjcetPool.Instance.CreateObject("MSkill1003", skill3, ArrowIconMove.m_position, transform.rotation);
        ObjcetPool.Instance.CollectObject(skill3s, 5.0f);
    }
    private void OnDisable()
    {
        AnimationEven.Instance.CleanAllEvent();
    }
}
