using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClip : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("hi");
        }
    }
    public void AnimationButton_Clip()
    {
        //Debug.Log("hi");
        anim.SetTrigger("Move");
    }
}


