using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePage : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites;
    public Image BgImage;
    int nowpage;
    private void Start()
    {
        BgImage.sprite = sprites[0];
        nowpage = 0;
    }
    public void NextPage()
    {
        if (nowpage < sprites.Count)
        {
            nowpage++;

            if (nowpage == sprites.Count) nowpage = sprites.Count - 1;
            BgImage.sprite = sprites[nowpage];
           
        }
    }

    public void BackPage()
    {        
        if (nowpage < sprites.Count)
        {
            nowpage--;

            if (nowpage <= 0) nowpage = 0;
            BgImage.sprite = sprites[nowpage];

        }
    }
}
