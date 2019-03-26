using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
    public float val, min, max;
    public RectTransform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float DurationTime = 5f;
    float time = 0, st;
    Vector3 pos;
    private bool isTriggle;

    void Start()
    {
        val = max;
        pos = target.position;
    }

    public void TriggerOn()
    {
        isTriggle = true;
        st = Time.time;
    }
    void Update()
    {
        if (!isTriggle) return;
       
        transform.Translate(Vector3.up * val * Time.deltaTime * speed);
        if (target.position.y > pos.y + max)
            val = min;
        else if (target.position.y < pos.y +min)
            val = max;

        if (isTriggle && Time.time - st < DurationTime)
        {
            time += Time.deltaTime;
        }
        else
        {
            isTriggle = false;
        }
    }
}
