using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeManager : SingletonForMonoBehaviour<CoolTimeManager>
{
    private float currentTime1=0;
    private float currentTime2= 0;
    private float currentTime3= 0;
    private float currentTime4 = 0;
    private float currentTime5 = 0;
    private float currentTime6 = 0;
    private Image[] m_Image;
    public static float coolingTimer1;
    public static float coolingTimer2;
    public static float coolingTimer3;
    public static float coolingTimer4;
    public static float coolingTimer5;
    public static float coolingTimer6;

    void Start()
    {
        m_Image = FindObjectsOfType<Image>();     
    }

    // Update is called once per frame
    void Update()
    {
        IsCoolingTime1(coolingTimer1);
        //IsCoolingTime(1, coolingTimer1, currentTime1);
        IsCoolingTime2(coolingTimer2);
        IsCoolingTime3(coolingTimer3);
        IsCoolingTime4(coolingTimer4);
        IsCoolingTime5(coolingTimer5);
        IsCoolingTime6(coolingTimer6);

    }
    //public void IsCoolingTime(int id, float coolingTimer, float currentTime)
    //{
    //    Image tmpImg = GetMask(id);

    //    if (currentTime < coolingTimer)
    //    {
    //        tmpImg.raycastTarget = true;
    //        currentTime += Time.deltaTime;
    //        tmpImg.fillAmount = 1 - currentTime / coolingTimer;
    //        return;
    //    }

    //    tmpImg.raycastTarget = false;
    //    currentTime = 0;
    //    coolingTimer = 0;
    //}
    public void IsCoolingTime1(float coolingTimer)
    {
        
        Image tmpImg = GetMask(1);
      
        if (currentTime1 < coolingTimer)
        {
            tmpImg.raycastTarget = true;
            currentTime1 += Time.deltaTime;
            tmpImg.fillAmount = 1 - currentTime1 / coolingTimer;
            return;
        }

        tmpImg.raycastTarget = false;
        currentTime1 = 0;
        coolingTimer1 = 0;
    }
    public void IsCoolingTime2(float coolingTimer)
    {
      
        Image tmpImg = GetMask(2);
       
        if (currentTime2 < coolingTimer)
        {
            tmpImg.raycastTarget = true;
            currentTime2 += Time.deltaTime;
            tmpImg.fillAmount = 1 - currentTime2 / coolingTimer;
            return;
        }

        tmpImg.raycastTarget = false;
        currentTime2 = 0;
        coolingTimer2 = 0;
    }
    public void IsCoolingTime3(float coolingTimer)
    {
   
        Image tmpImg = GetMask(3);
        
        if (currentTime3 < coolingTimer)
        {
            tmpImg.raycastTarget = true;
            currentTime3 += Time.deltaTime;
            tmpImg.fillAmount = 1 - currentTime3 / coolingTimer;
            return;
        }

        tmpImg.raycastTarget = false;
        currentTime3 = 0;
        coolingTimer3 = 0;
    }
    public void IsCoolingTime4(float coolingTimer)
    {

        Image tmpImg = GetMask(4);

        if (currentTime4 < coolingTimer)
        {
            tmpImg.raycastTarget = true;
            currentTime4 += Time.deltaTime;
            tmpImg.fillAmount = 1 - currentTime4 / coolingTimer;
            return;
        }

        tmpImg.raycastTarget = false;
        currentTime4 = 0;
        coolingTimer4 = 0;
    }
    public void IsCoolingTime5(float coolingTimer)
    {

        Image tmpImg = GetMask(5);

        if (currentTime5 < coolingTimer)
        {
            tmpImg.raycastTarget = true;
            currentTime5 += Time.deltaTime;
            tmpImg.fillAmount = 1 - currentTime5 / coolingTimer;
            return;
        }

        tmpImg.raycastTarget = false;
        currentTime5 = 0;
        coolingTimer5 = 0;
    }
    public void IsCoolingTime6(float coolingTimer)
    {

        Image tmpImg = GetMask(6);

        if (currentTime6 < coolingTimer)
        {
            tmpImg.raycastTarget = true;
            currentTime6 += Time.deltaTime;
            tmpImg.fillAmount = 1 - currentTime6 / coolingTimer;
            return;
        }

        tmpImg.raycastTarget = false;
        currentTime6 = 0;
        coolingTimer6 = 0;
    }
    //public void IsStartCd(float coolingTimer, int ID)
    //{

    //    switch (ID)
    //    {
    //        case 1: StartCoroutine(StartSkill1CD(coolingTimer));
    //            break;
    //        case 2:
    //            StartCoroutine(StartSkill2CD(coolingTimer));
    //            break;
    //        case 3:
    //            StartCoroutine(StartSkill3CD(coolingTimer));
    //            break;
    //    }

    //}
    //private IEnumerator StartSkill1CD(float coolingTimer)
    //{

    //    Image tmpImg = GetMask(1);
    //    tmpImg.fillAmount = 1.0f;     
    //    tmpImg.raycastTarget = true;
    //    while (currentTime < coolingTimer)
    //    {
    //        yield return new WaitForSeconds(Time.fixedDeltaTime);
    //        currentTime += Time.fixedDeltaTime;         
    //        //按时间比例计算出Fill Amount值  
    //        tmpImg.fillAmount = 1 - currentTime / coolingTimer;         
    //    }
    //    currentTime = 0;
    //    tmpImg.raycastTarget = false;
    //    yield  break;
    //}
    //private IEnumerator StartSkill2CD(float coolingTimer)
    //{

    //    Image tmpImg = GetMask(2);
    //    tmpImg.fillAmount = 1.0f;
    //    tmpImg.raycastTarget = true;
    //    while (currentTime < coolingTimer)
    //    {
    //        yield return new WaitForSeconds(Time.fixedDeltaTime);
    //        currentTime += Time.fixedDeltaTime;
    //        //按时间比例计算出Fill Amount值  
    //        tmpImg.fillAmount = 1 - currentTime / coolingTimer;
    //    }
    //    currentTime = 0;
    //    tmpImg.raycastTarget = false;
    //    yield  break;
    //}
    //private IEnumerator StartSkill3CD(float coolingTimer)
    //{

    //    Image tmpImg = GetMask(3);
    //    tmpImg.fillAmount = 1.0f;
    //    tmpImg.raycastTarget = true;
    //    while (currentTime < coolingTimer)
    //    {
    //        yield return new WaitForSeconds(Time.fixedDeltaTime);
    //        currentTime += Time.fixedDeltaTime;
    //        //按时间比例计算出Fill Amount值  
    //        tmpImg.fillAmount = 1 - currentTime / coolingTimer;
    //    }
    //    currentTime = 0;
    //    tmpImg.raycastTarget = false;
    //    yield  break;
    //}
    private Image GetMask(int ID)
    {
        foreach (var item in m_Image)
        {
            if (item.gameObject.name == "Mask_" + ID)
            {
                return item;
            }
        }
        return null;
    }
    public void ReInital()
    {
        coolingTimer1 = 0;
        coolingTimer2 = 0;
        coolingTimer3 = 0;
        GetMask(1).fillAmount = 0;
        GetMask(2).fillAmount = 0;
        GetMask(3).fillAmount = 0;
    }
   
}
