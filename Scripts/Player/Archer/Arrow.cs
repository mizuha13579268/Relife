using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private GameObject arrow;
    private float time;
    private Transform arrowShootPoint;
    [SerializeField]
    private float speed=5;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    private void Awake()
    {
       
        arrowShootPoint = GameObject.FindGameObjectWithTag("ShootPoint").transform;
    }
    void Start()
    {
      
    }
    private void OnEnable()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.7f)
        {
            Move();
        } else if (time >= 0.28f)
        {
            Back();
        }
       
    }
    private void Back()
    {
       
       
        transform.position = Vector3.Lerp(transform.position, arrowShootPoint.position,0.32f);
        
    }
    private void Move()
    {
        transform.SetParent (null);
        transform.Translate(new Vector3(1,0,0) * speed * Time.deltaTime);
    }
}
