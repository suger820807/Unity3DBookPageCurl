﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public List<Image> imgs;

    //! out = true, in = false
    public void OnButtonClick(bool inOut)
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(inOut));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        //! fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                foreach (var img in imgs)
                {
                    img.color = new Color(1, 1, 1, i);
                }
                
                yield return null;
            }
        }
        //! fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                foreach(var img in imgs)
                {
                    img.color = new Color(1, 1, 1, i);
                }
                yield return null;
            }
        }
    }
}
