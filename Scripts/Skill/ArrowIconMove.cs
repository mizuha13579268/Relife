
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowIconMove : MonoBehaviour
{
    private static ArrowIconMove instance;
    public static ArrowIconMove Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ArrowIconMove();
            }
            return instance;
        }
    }
    //图标移动最大半径
    [SerializeField]
    private float maxRadius = 4;
    //获取技能图标
    private Image skillIcon;
    //获取遥感脚本
    private List<SkillTouch> skillTouches;
    private GameObject[] touchGo;
    //获取玩家的位置
    private Vector3 playPos;
    //获取玩家的朝向
    private Quaternion playRot;
    private Transform selfPos;
    private SkillType skillType;
    //获取sprite子控件渲染组件
    private SpriteRenderer sprite;
    [SerializeField]
    private List<Sprite> spriteArray;
    private int time = 0;
    public static Quaternion quaternions=Quaternion.identity;
    public static Quaternion Quaternions
    {
        get
        {
            return quaternions;
        }
    }
    public static Vector3 m_position;  
    void Awake()
    {

        touchGo = GameObject.FindGameObjectsWithTag("Skill");
        skillTouches = new List<SkillTouch>();
       
    }
    void Start()
    {      
        GetSkillTouch();       
    }
    void Update()
    {
        playPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        SkillIconMove(GetDragId());
    }
  
    /// <summary>
    /// 技能释放方向图标移动
    /// </summary>
    /// <param name="touch"></param>
    private void SkillIconMove(SkillTouch touch)
    {
        //hor = 遥感脚本中的localPosition.x
        float hor = touch.Horizontal;
        //ver = 遥感脚本中的localPosition.y
        float ver = touch.Vertical;
        Vector3 direction = new Vector3(hor, 0, ver);
        if (direction != Vector3.zero)
        {
            Show();
            Debug.Log("s:"+ GetSkillTypeIDTouching(touch));
            SkillType(GetSkillTypeIDTouching(touch), direction);
            quaternions = Quaternion.LookRotation(direction);
            m_position = transform.position;
        }
        else
        {
          
            Hide();
            transform.position = playPos;
            transform.rotation = playRot;
        }
    }
    /// <summary>
    /// 获取正在被拖拽的技能类型
    /// </summary>
    private int GetSkillTypeIDTouching(SkillTouch skillTouch)
    {
        for (int i = 0; i < skillTouches.Count  ;i++)
        {
            if (skillTouches[i] == skillTouch)
            {
                Debug.Log(i);
                return SkillMsg.Instance.GetSkillTypeID(i);
            }
        }
        return (int)SkillTypes.NoneTypeSkill;
    }
    /// <summary>
    /// 获取正在拖拽的技能检测脚本
    /// </summary>
    /// <returns></returns>
    private SkillTouch GetDragId()
    {
        foreach (var item in skillTouches)
        {
            float hor = item.Horizontal;
            //ver = 遥感脚本中的localPosition.y
            float ver = item.Vertical;
            Vector3 direction = new Vector3(hor, 0, ver);

            if (direction != Vector3.zero)
            {
                return item;
            }
        }
        return skillTouches[0];
    }
    /// <summary>
    /// 根据技能类型调用对应逻辑方法
    /// </summary>
    /// <param name="skillTypeId"></param>
    /// <param name="direction"></param>
    private void SkillType(int skillTypeId, Vector3 direction)
    {
        switch (skillTypeId)
        {
            case (int)SkillTypes.DirectivitySill:
                DirectivitySillMoveLogic(direction);
                break;
            case (int)SkillTypes.RangeOfSkill:
                RangeOfSkillMoveLogic(direction);
                break;
            case (int)SkillTypes.NoneTypeSkill:
                NoneTypeSkillMoveLogic(direction);
                break;
        }
    }
    /// <summary>
    /// 指向性技能移动逻辑
    /// </summary>
    /// <param name="direction"></param>
    private void DirectivitySillMoveLogic(Vector3 direction)
    {
        //time++;
        //if (time == 1)
        //{
        //    sprite.transform.position = new Vector3( - 0.01f, 0, transform.position.z + 1.09f);
        //}
        sprite.sprite = spriteArray[0];
        sprite.transform.localScale = new Vector3(0.2669767f, 0.5066305f, 0.326975f);
       
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10);
      
    }
    /// <summary>
    /// 范围性技能移动逻辑
    /// </summary>
    /// <param name="direction"></param>
    private void RangeOfSkillMoveLogic(Vector3 direction)
    {
        sprite.sprite = spriteArray[1];
        sprite.transform.localScale = new Vector3(0.9801456f, 1, 0.9801456f);
        selfPos = gameObject.transform;
        float speed = 5;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10);
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.position =
          new Vector3(Mathf.Clamp(transform.position.x, -4.7f, 4.7f),0,Mathf.Clamp(transform.position.z, -4.7f, 4.7f));




    }
    /// <summary>
    /// 无类型技能移动逻辑
    /// </summary>
    /// <param name="direction"></param>
    private void NoneTypeSkillMoveLogic(Vector3 direction)
    {
        sprite.sprite = spriteArray[2];
        sprite.transform.position = transform.position;
        sprite.transform.localScale = new Vector3(0.3126664f, 0.3126664f, 0.3126664f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10);
    }
    /// <summary>
    /// 获取技能检测脚本
    /// </summary>
    private void GetSkillTouch()
    {
        foreach (var item in touchGo)
        {
            skillTouches.Add(item.GetComponent<SkillTouch>());
        }
    }
    /// <summary>
    /// 隐藏技能辅助图标
    /// </summary>
    private void Hide()
    {
       
        Color color = sprite.color;
        color.a = 0.0f;
        sprite.color = color;
    }
    /// <summary>
    /// 显示技能辅助图标
    /// </summary>
    private void Show()
    {
        Color color = sprite.color;
        color.a = 0.5f;
        sprite.color = color;
    }
    
}
