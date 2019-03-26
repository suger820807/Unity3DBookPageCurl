using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
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

        //transform.Translate(Vector3.left * val * Time.deltaTime * speed);
        target.position = Vector3.Lerp(target.position, target.position + Vector3.left * val, 1 * Time.deltaTime * speed);
        if (target.position.x > pos.x + max)
        {
            val = 1;
        }            
        else if (target.position.x < pos.x + min)
            val = -1;

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
