using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSingleton : MonoBehaviour
{
    private float timer = 0;

    private static BookSingleton _instance;
    public static BookSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("產生Singleton");
                _instance = new BookSingleton();
            }
            return _instance;
        }
    }

    private BookSingleton() { }

    private void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public bool isAutoPage { get; private set; }
    public bool isVoiceReading { get; private set; }
    public bool isRecording { get; private set; }

    private void Start()
    {
        isAutoPage = false;
        isVoiceReading = false;
        isRecording = false;
    }

    public void AutoPage()
    {
        isAutoPage = true;
    }

    public void VoiceReading()
    {
        isVoiceReading = true;
    }

    public void Recording()
    {
        isRecording = true;
    }

    public void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


}
