using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFlipTimeController : MonoBehaviour
{

    private float timer = 0;
    [Header("各頁停留時間")]
    public float[] staytime;
    private int current_page = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (current_page < staytime.Length)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);

            if (timer >= staytime[current_page])
            {
                timer = 0;
                AutoFlip._instance.FlipRightPage();
                current_page++;
            }
        }
    }
}
