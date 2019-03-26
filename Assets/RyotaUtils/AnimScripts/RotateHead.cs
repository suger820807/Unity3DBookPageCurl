using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    public float val,min, max;
    public Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float DurationTime = 5f;
    float time = 0 ,st;
    private bool isTriggle;
    void Start()
    {
        //target.Rotate(0,0,max);
        val = max;
    }
    public void  TriggerOn()
    {
        isTriggle = true;
        st = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isTriggle) return;

        target.rotation = Quaternion.Slerp(target.rotation, Quaternion.Euler(0, 0, val), 1 * Time.deltaTime * speed);

        if (target.rotation == Quaternion.Euler(0, 0, max))
            val = min;
        else if (target.rotation == Quaternion.Euler(0, 0, min))
            val = max;

        if(isTriggle && Time.time - st < DurationTime)
        {
            isTriggle = true;
        }
        else {
            isTriggle = false;
            time = 0;
        }
    }
}
