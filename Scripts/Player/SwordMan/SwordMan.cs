using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMan : MonoBehaviour
{
    private Animator m_ani;
    public int currentState;
    bool isEnter = false;
    bool isRolling = false;
    bool isGround = false;
    private PlayerAttackState playerAttackState;
    private PlayerRollingState playerRollingState;
    private Rigidbody m_Rigidbody;
   
    // Start is called before the first frame update
    private void OnEnable()
    {
        Inital();
      //  PlayerBase.Instance.GroundedDo(PlayerBase.Instance.IsGrounded(transform), m_ani, m_Rigidbody);
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

        //PlayerBase.Instance.GroundedDo(isGround, m_ani);
        //   PlayerBase.Instance.GroundedDo(PlayerBase.Instance.IsGrounded(transform), m_ani, m_Rigidbody);
        PlayerBase.playerCreatePointPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        PlayerBase.playerCreatePointRot = transform.rotation;
        PlayerBase.Instance.isRollingEnd(m_ani);
        if (isEnter)
        {
            isEnter = AttackStay(currentState);
        }
        if (isRolling)
        {
           isRolling= playerRollingState.OnStay(0);
        }
    }
    private void FixedUpdate()
    {
       
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
        currentState = SkillType.Instance.GetSwordManAnimation(skillID);
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
    private void SowrdManSkill1()
    {
       // Debug.Log(11);
        GameObject skill1 = Resources.Load("Prefab/Skill/SwordMan/SSkill1001") as GameObject;
        GameObject skill1s = ObjcetPool.Instance.CreateObject("SSkill1001", skill1, new Vector3(transform.position.x,
            transform.position.y + 2f, transform.position.z), transform.rotation);
        ObjcetPool.Instance.CollectObject(skill1s, 5.0f);
    }
    private void SowrdManSkill2()
    {
        GameObject skill2 = Resources.Load("Prefab/Skill/SwordMan/SSkill1002") as GameObject;
        GameObject skill2s = ObjcetPool.Instance.CreateObject("SSkill1002", skill2, transform.position, transform.rotation);
        ObjcetPool.Instance.CollectObject(skill2s, 5.0f);
    }
    private void SowrdManSkill3()
    {
        GameObject skill3 = Resources.Load("Prefab/Skill/SwordMan/SSkill1003") as GameObject;
        GameObject skill3s = ObjcetPool.Instance.CreateObject("SSkill1003", skill3, transform.position, transform.rotation);
        ObjcetPool.Instance.CollectObject(skill3s, 5.0f);
    }
    private void OnDisable()
    {
        AnimationEven.Instance.CleanAllEvent();
    }
    
}
