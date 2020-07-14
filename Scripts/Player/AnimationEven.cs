using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEven : Singleton<AnimationEven>
{
    private GameObject player;
    private Animator animator;
    private AnimationClip[] animationClip;

    public void Inital()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
        animationClip = animator.runtimeAnimatorController.animationClips;
        Debug.Log(player.name);
        AddEvenByPlayer(player.name);
    }
    private void AddEvenByPlayer(string name)
    {
        switch (name)
        {
            case "Archer":
                Debug.Log("a"+player.name);
                
                for (int i = 0; i < animationClip.Length; i++)
                {
                    try
                    {
                        if (animationClip[i].name == "attack1")
                        {
                            AddAnimationEvent(animator, "attack1", "DrawArrow", 0.19f);
                        }
                        else if (animationClip[i].name == "attack3")
                        {

                            AddAnimationEvent(animator, "attack3", "ArcherSkill1", 0.19f);
                        }
                        else if (animationClip[i].name == "attack6")
                        {
                            AddAnimationEvent(animator, "attack6", "ArcherSkill2", 0.8f);
                        }
                        else if (animationClip[i].name == "attack2")
                        {
                            AddAnimationEvent(animator, "attack2", "ArcherSkill3", 0.1f);
                        }
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                   
                }
                break;
            case "SwordMan":
                Debug.Log("s" + player.name);
                for (int i = 0; i < animationClip.Length; i++)
                {
                    try
                    {
                        if (animationClip[i].name == "Attack_17")
                        {

                            AddAnimationEvent(animator, "Attack_17", "SowrdManSkill1", 0.36f);
                        }
                        else if (animationClip[i].name == "Attack_11")
                        {
                            AddAnimationEvent(animator, "Attack_11", "SowrdManSkill2", 0.55f);
                        }
                        else if (animationClip[i].name == "Attack_13")
                        {
                            AddAnimationEvent(animator, "Attack_13", "SowrdManSkill3", 0.5f);
                        }
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    
                }
                break;
            case "Magicer":
                Debug.Log("m" + player.name);
                for (int i = 0; i < animationClip.Length; i++)
                {
                    try
                    {
                        if (animationClip[i].name == "Attack1")
                        {

                            AddAnimationEvent(animator, "Attack1", "MagicerNorAttack", 0.44f);
                        }
                        else if (animationClip[i].name == "Attack17_1")
                        {

                            AddAnimationEvent(animator, "Attack17_1", "MagicerManSkill1", 0.21f);
                        }
                        else if (animationClip[i].name == "Anim19_1")
                        {
                            AddAnimationEvent(animator, "Anim19_1", "MagicerManSkill2", 0.34f);
                        }
                        else if (animationClip[i].name == "Attack10_3")
                        {
                            AddAnimationEvent(animator, "Attack10_3", "MagicerManSkill3", 0.3f);
                        }
                    }
                    catch (System.Exception)
                    {

                        throw ;
                    }
                   
                }
                break;
        }
    }
     
    /// <summary>
    /// 绑定动画事件
    /// </summary>
    /// <param name="ani">动画状态机</param>
    /// <param name="name">动画名</param>
    /// <param name="fun">绑定的方法</param>
    /// <param name="time">绑定到动画的时间</param>
    private void AddAnimationEvent(Animator ani, string name, string fun, float time)
    {
        AnimationClip[] temp = ani.runtimeAnimatorController.animationClips;
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].name == name)
            {
                AnimationEvent _event = new AnimationEvent();
                _event.functionName = fun;
                _event.time = time;
                temp[i].AddEvent(_event);
                break;
            }
        }
        //重新绑定
        ani.Rebind();
    }
    public void CleanAllEvent()
    {
        for (int i = 0; i < animationClip.Length; i++)
        {
            animationClip[i].events = default(AnimationEvent[]);
        }
    }
   
}
