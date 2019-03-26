using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTrigger : MonoBehaviour
{
    Animator mAnim;
    [SerializeField]
    private float DurationTime = 5f;
    float time = 0, st;

    void Start()
    {        
        mAnim = GetComponent<Animator>();
        mAnim.enabled = false;
    }
    private void OnMouseDown()
    {
        mAnim.enabled = true;
    }

    void Update()
    {
        if (!mAnim.enabled) return;
        if (mAnim.enabled && DurationTime - time > 0)
        {
            time += Time.deltaTime;
        }
        else
        {
            mAnim.enabled = false;
            time = 0;
        }
    }
}
