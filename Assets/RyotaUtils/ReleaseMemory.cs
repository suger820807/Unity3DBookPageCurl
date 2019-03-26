using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ReleaseMemory : MonoBehaviour
{
    void Start()
    {
        Application.lowMemory += Release;
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            Permission.RequestUserPermission(Permission.Microphone);
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
    }

    private void Release()
    {
        Debug.Log("Release");
        Resources.UnloadUnusedAssets();
    }

}
