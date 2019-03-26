using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateCtrl : MonoBehaviour
{
    public List<int> Pages;
    public List<GameObject> Anims;
    public List<Image> Images;
    BookPro bp;
    int pageIndex;

    void Start()
    {
        bp = GameObject.Find("BookPro").GetComponent<BookPro>();
    }


    void Update()
    {        
        pageIndex = bp.CurrentPaper;
        //if (bp.pageDragging) return;
        for (int index = 0; index < Anims.Count; index++)
        {
            if (!bp.pageDragging && pageIndex == Pages[index])
            {
                Anims[index].SetActive(true);
                Images[index].enabled = false;
            }

            else
            {
                Anims[index].SetActive(false);
                Images[index].enabled = true;
            }
        }

    }
}
