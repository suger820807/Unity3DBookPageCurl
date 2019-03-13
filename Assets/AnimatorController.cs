using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator anim;
    public int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100, layerMask);
            if (hit.collider && hit.transform.name == transform.name)
            {
                //count++;
                ////Debug.DrawLine(ray.origin, hit.transform.position, Color.red, 0.1f, true);
                //if (count == 1)
                //{
                    Debug.Log(hit.transform.name);
                    Debug.Log("hi");
                    anim.SetTrigger("Move");
                //}
            }
        }
        //if(anim.GetCurrentAnimatorStateInfo(0).IsName("New State"))
        //{
        //    count = 0;
        //}



    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Hi");
    //    anim.SetTrigger("Move");
    //}
}
