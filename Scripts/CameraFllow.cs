using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraFllow : MonoBehaviour
{
   
    private Transform player;
    //游戏人物与 相机的差
    private Vector3 offset;
    //相机的速度
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float x = -2.38f;
    [SerializeField]
    private float y = 3.98f;
    [SerializeField]
    private float z = -7.94f;

    // Text m_debugTip;
    public bool canRotation_X = true;
    public bool canRotation_Y = true;
    public bool canScale = true;
    private Transform canMovePos;
    #region Field and Property
    /// <summary>
    /// Around center.
    /// </summary>
    public Transform target;

    /// <summary>
    /// Settings of mouse button, pointer and scrollwheel.
    /// </summary>
    public MouseSettings mouseSettings = new MouseSettings(0, 10, 10);

    /// <summary>
    /// Range limit of angle.
    /// </summary>
    public Range angleRange = new Range(-90, 90);

    /// <summary>
    /// Range limit of distance.
    /// </summary>
    public Range distanceRange = new Range(1, 10);

    /// <summary>
    /// Damper for move and rotate.
    /// </summary>
    [Range(0, 10)]
    public float damper = 5;

    /// <summary>
    /// Camera current angls.
    /// </summary>
    public Vector2 CurrentAngles { protected set; get; }

    /// <summary>
    /// Current distance from camera to target.
    /// </summary>
    public float CurrentDistance { protected set; get; }

    /// <summary>
    /// Camera target angls.
    /// </summary>
    protected Vector2 targetAngles;


    /// <summary>
    /// Target distance from camera to target.
    /// </summary>
    protected float targetDistance;
    #endregion




    //public float z = 5;
    void Start()
    {
        //this.transform.localEulerAngles = new Vector3(19, player.localEulerAngles.y, 0);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canMovePos = GameObject.Find("CanTouch").GetComponent<Transform>();
        offset = transform.position - player.position;

        CurrentAngles = targetAngles = transform.eulerAngles;
        CurrentDistance = targetDistance = Vector3.Distance(transform.position, player.position);

    }
    /// <summary>
    /// 检测用户是否要旋转视角
    /// </summary>
    //private bool isReturn()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        if (QkeyCount == 1)
    //        {
    //            this.transform.localEulerAngles = new Vector3(19, player.localEulerAngles.y, 0);
    //            QkeyCount = -1;
    //        }
    //        QkeyCount += 1;
    //        Debug.Log(QkeyCount);
    //    }

    //    if (QkeyCount == 1)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //    return false;

    //}
    /// <summary>
    /// 视角旋转
    /// </summary>
    //private void ReturnCamera(bool isreturn)
    //{
    //    isreturn = isReturn();
    //    if (player)
    //    {

    //        cameraX = player.position.x;
    //        cameraZ = player.position.z;
    //        cameraY = player.position.y;
    //        if (isreturn)
    //        {
    //            this.transform.position = new Vector3(cameraX, cameraY + y, cameraZ - z);

    //        }
    //        else
    //        {
    //            this.transform.position = new Vector3(cameraX, cameraY + y, cameraZ + z);

    //        }

    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //由 摄像机 和 玩家固定距离偏量 构建插值
        Vector3 targetPos = player.position+ new Vector3(x, y, z);
        //移动
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
               //角度的移动 lookRotation 是按向量变换时的长度 来变的 ,相减 是由相机位置指向玩家
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
                 // Slerp是根据 变换过程中角度的变化 插值的
       transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);


      
  
}
    void LateUpdate()
    {
        //player.TransformDirection(offset)
        //if (player != null)
        //{
        //    //世界坐标转换为局部坐标
        //    Vector3 targetPosition = player.position + player.TransformDirection(offset) + new Vector3(x, y, z);
        //    //Vector3.Lerp 计算相机位置 和 目标位置的插值
        //    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        //    //相机的目标看向 游戏人物
        //    transform.Rotate(player.eulerAngles);
        //   transform.LookAt(player.position);
        //}
    
#if UNITY_EDITOR
        AroundByMouseInput();
#elif UNITY_ANDROID || UNITY_IPHONE
 
        AroundByMobileInput();
#endif

    



    }
    //记录上一次手机触摸位置判断用户是在左放大还是缩小手势  
    private Vector2 oldPosition1;
    private Vector2 oldPosition2;

    private bool m_IsSingleFinger;
    protected void AroundByMobileInput()
    {
       
        if (Vector3.Distance(Input.GetTouch(0).position, canMovePos.position) > 4) return;
        if (Input.touchCount == 1)
        {

            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                targetAngles.y += Input.GetAxis("Mouse X") * mouseSettings.pointerSensitivity;
                targetAngles.x -= Input.GetAxis("Mouse Y") * mouseSettings.pointerSensitivity;

                //Range.
                targetAngles.x = Mathf.Clamp(targetAngles.x, angleRange.min, angleRange.max);
            }
            //Mouse pointer.
            m_IsSingleFinger = true;
        }

        //Mouse scrollwheel.
        if (canScale)
        {
            if (Input.touchCount > 1)
            {


                //计算出当前两点触摸点的位置  
                if (m_IsSingleFinger)
                {
                    oldPosition1 = Input.GetTouch(0).position;
                    oldPosition2 = Input.GetTouch(1).position;
                }


                if (Input.touches[0].phase == TouchPhase.Moved && Input.touches[1].phase == TouchPhase.Moved)
                {
                    var tempPosition1 = Input.GetTouch(0).position;
                    var tempPosition2 = Input.GetTouch(1).position;


                    float currentTouchDistance = Vector3.Distance(tempPosition1, tempPosition2);
                    float lastTouchDistance = Vector3.Distance(oldPosition1, oldPosition2);

                    //计算上次和这次双指触摸之间的距离差距  
                    //然后去更改摄像机的距离  
                    targetDistance -= (currentTouchDistance - lastTouchDistance) * Time.deltaTime * mouseSettings.wheelSensitivity;
                    //  m_debugTip.text = ( currentTouchDistance - lastTouchDistance ).ToString() + " + " + targetDistance.ToString();


                    //把距离限制住在min和max之间  



                    //备份上一次触摸点的位置，用于对比  
                    oldPosition1 = tempPosition1;
                    oldPosition2 = tempPosition2;
                    m_IsSingleFinger = false;
                }
            }

        }




        targetDistance = Mathf.Clamp(targetDistance, distanceRange.min, distanceRange.max);

        //Lerp.
        CurrentAngles = Vector2.Lerp(CurrentAngles, targetAngles, damper * Time.deltaTime);
        CurrentDistance = Mathf.Lerp(CurrentDistance, targetDistance, damper * Time.deltaTime);




        if (!canRotation_X) targetAngles.y = 0;
        if (!canRotation_Y) targetAngles.x = 0;


        //Update transform position and rotation.
        transform.rotation = Quaternion.Euler(CurrentAngles);

        transform.position = player.position - transform.forward * CurrentDistance;
        // transform.position = target.position - Vector3.forward * CurrentDistance;

    }

    /// <summary>
    /// Camera around target by mouse input.
    /// </summary>
    protected void AroundByMouseInput()
    {
        //  if (Vector3.Distance(Input.GetTouch(0).position, canMovePos.position) > 2) return;
        if (!Input.GetKey(KeyCode.Q)) return;
        if (Input.GetMouseButton(mouseSettings.mouseButtonID))
        {
            //Mouse pointer.
            targetAngles.y += Input.GetAxis("Mouse X") * mouseSettings.pointerSensitivity;
            targetAngles.x -= Input.GetAxis("Mouse Y") * mouseSettings.pointerSensitivity;

            //Range.
            targetAngles.x = Mathf.Clamp(targetAngles.x, angleRange.min, angleRange.max);
        }

        //Mouse scrollwheel.
        if (canScale)
        {
            targetDistance -= Input.GetAxis("Mouse ScrollWheel") * mouseSettings.wheelSensitivity;

        }
        // m_debugTip.text = Input.GetAxis("Mouse ScrollWheel").ToString() + " + " + targetDistance.ToString();


        targetDistance = Mathf.Clamp(targetDistance, distanceRange.min, distanceRange.max);

        //Lerp.
        CurrentAngles = Vector2.Lerp(CurrentAngles, targetAngles, damper * Time.deltaTime);
        CurrentDistance = Mathf.Lerp(CurrentDistance, targetDistance, damper * Time.deltaTime);




        if (!canRotation_X) targetAngles.y = 0;
        if (!canRotation_Y) targetAngles.x = 0;


        //Update transform position and rotation.
        transform.rotation = Quaternion.Euler(CurrentAngles);

        transform.position = player.position - transform.forward * CurrentDistance;
        // transform.position = target.position - Vector3.forward * CurrentDistance;



    }

}

[Serializable]
public struct MouseSettings
{
    /// <summary>
    /// ID of mouse button.
    /// </summary>
    public int mouseButtonID;

    /// <summary>
    /// Sensitivity of mouse pointer.
    /// </summary>
    public float pointerSensitivity;

    /// <summary>
    /// Sensitivity of mouse ScrollWheel.
    /// </summary>
    public float wheelSensitivity;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mouseButtonID">ID of mouse button.</param>
    /// <param name="pointerSensitivity">Sensitivity of mouse pointer.</param>
    /// <param name="wheelSensitivity">Sensitivity of mouse ScrollWheel.</param>
    public MouseSettings(int mouseButtonID, float pointerSensitivity, float wheelSensitivity)
    {
        this.mouseButtonID = mouseButtonID;
        this.pointerSensitivity = pointerSensitivity;
        this.wheelSensitivity = wheelSensitivity;
    }
}

/// <summary>
/// Range form min to max.
/// </summary>
[Serializable]
public struct Range
{
    /// <summary>
    /// Min value of range.
    /// </summary>
    public float min;

    /// <summary>
    /// Max value of range.
    /// </summary>
    public float max;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="min">Min value of range.</param>
    /// <param name="max">Max value of range.</param>
    public Range(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}

/// <summary>
/// Rectangle area on plane.
/// </summary>
[Serializable]
public struct PlaneArea
{
    /// <summary>
    /// Center of area.
    /// </summary>
    public Transform center;

    /// <summary>
    /// Width of area.
    /// </summary>
    public float width;

    /// <summary>
    /// Length of area.
    /// </summary>
    public float length;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="center">Center of area.</param>
    /// <param name="width">Width of area.</param>
    /// <param name="length">Length of area.</param>
    public PlaneArea(Transform center, float width, float length)
    {
        this.center = center;
        this.width = width;
        this.length = length;
    }
}

/// <summary>
/// Target of camera align.
/// </summary>
[Serializable]
public struct AlignTarget
{
    /// <summary>
    /// Center of align target.
    /// </summary>
    public Transform center;

    /// <summary>
    /// Angles of align.
    /// </summary>
    public Vector2 angles;

    /// <summary>
    /// Distance from camera to target center.
    /// </summary>
    public float distance;

    /// <summary>
    /// Range limit of angle.
    /// </summary>
    public Range angleRange;

    /// <summary>
    /// Range limit of distance.
    /// </summary>
    public Range distanceRange;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="center">Center of align target.</param>
    /// <param name="angles">Angles of align.</param>
    /// <param name="distance">Distance from camera to target center.</param>
    /// <param name="angleRange">Range limit of angle.</param>
    /// <param name="distanceRange">Range limit of distance.</param>
    public AlignTarget(Transform center, Vector2 angles, float distance, Range angleRange, Range distanceRange)
    {
        this.center = center;
        this.angles = angles;
        this.distance = distance;
        this.angleRange = angleRange;
        this.distanceRange = distanceRange;
    }
}
