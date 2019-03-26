using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float val,min, max;
    public RectTransform target;
    [SerializeField]
    private GameObject feather_1, feather_2, feather_3;
    //public Prefab feather;
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

    public void TriggerOn()
    {
        isTriggle = true;

        GameObject f1, f2, f3;
        if(feather_1 != null)
            f1 = Instantiate(feather_1, transform.position + Vector3.right*2, Quaternion.identity);
        //f1.transform.SetParent(transform);
        if (feather_2 != null)
            f2 = Instantiate(feather_2, transform.position + Vector3.left + Vector3.up , Quaternion.identity);
        //f2.transform.SetParent(transform);
        if (feather_3 != null)
            f3 = Instantiate(feather_3, transform.position + Vector3.down, Quaternion.identity);
        //f3.transform.SetParent(transform);
        st = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTriggle) return;

        //f1.transform.Translate(Vector3.left);
        //f2.transform.Translate(Vector3.right);
        //f3.transform.Translate(Vector3.down);

        target.position = Vector3.Lerp(target.position, target.position + Vector3.up * val, 1 * Time.deltaTime * speed);
        if (target.position.y > max)
            val = min;
        else if (target.position.y < min)
            val = max;

        if (isTriggle && Time.time - st < DurationTime)
        {
            time += Time.deltaTime;
        }
        else {
            isTriggle = false;
        }
    }
}
