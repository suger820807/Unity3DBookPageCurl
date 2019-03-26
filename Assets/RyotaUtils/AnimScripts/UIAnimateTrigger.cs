using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIAnimateTrigger : MonoBehaviour, IPointerDownHandler
{
    public List<Animator> mAnims;
    [SerializeField]
    private float DurationTime = 5f;
    float time = 0, st;

    void Start()
    {
        foreach (var mAnim in mAnims)
        {
            mAnim.enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (var mAnim in mAnims)
        {
            mAnim.enabled = true;
        }
    }

    void Update()
    {
        for (int index = 0; index < mAnims.Count; index++)
        {
            if (!mAnims[index].enabled) return;
            if (mAnims[index].enabled && DurationTime - time > 0)
            {
                time += Time.deltaTime;
            }
            else
            {
                mAnims[index].enabled = false;
                time = 0;
            }
        }
    }
}
