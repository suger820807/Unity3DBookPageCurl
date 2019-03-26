using NatCorderU.Examples;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Image button, countdown;
    public RecordingNatMic RC;
    //public RecMic RMic;
    public Text StopText;

    [SerializeField]
    private float MaxTime = 10f; // seconds
    private string min, sec, miliSec;
    public bool isREC { get; private set; }

    private void Start()
    {
        Reset();
        //! 流程串接3/22
        if (BookSingleton.Instance.isRecording)
            StartCountdown();
    }

    private void Reset()
    {
        // Reset fill amounts
        if (button) button.fillAmount = 1.0f;
        if (countdown) countdown.fillAmount = 0.0f;
    }
    //! 開始FFMPEG錄音 + NatCoder錄影
    public void StartCountdown()
    {
        if (!isREC)
        {            
            RC.StartRecording();
            //RMic.StartMic();
            isREC = true;
        }
        else
        {
            RC.StopRecording();
            //RMic.StopMic();
            isREC = false;
        }
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {    
        // Animate the countdown
        float startTime = Time.time, ratio = 0f;
        float time = 0f;
        while (isREC && (ratio = (Time.time - startTime) / MaxTime) < 1.0f)
        {
            time += Time.deltaTime;
            min = Mathf.Floor(time / 60).ToString("00");
            sec = Mathf.Floor(time % 60).ToString("00");
            miliSec = Mathf.Floor((time * 100) % 100).ToString("00");
            StopText.text = string.Format("{0}:{1}:{2}", min, sec, miliSec);

            countdown.fillAmount = ratio;
            button.fillAmount = 1f - ratio;
            yield return null;
        }
        // Reset
        Reset();
        // Stop func
    }
}
