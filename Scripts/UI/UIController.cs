using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
   
    void Start()
    {

      
        SkillMsg.Instance.Inital();
        AnimationEven.Instance.Inital();
        UIButtonTouchTrigger.Instance.Inital();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
