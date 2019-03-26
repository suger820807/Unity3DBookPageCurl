/* 
*   NatCorder
*   Copyright (c) 2019 Yusuf Olokoba
*/

namespace NatCorderU.Examples
{

#if UNITY_EDITOR
    using UnityEditor;
#endif
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.IO;
    using NatCorder.Clocks;
    using NatCorder.Inputs;
    using NatCorder;
    using NatMicU.Core;

    public class RecordingNatMic : MonoBehaviour
    {
        [Header("Recording")]
        public int videoWidth = 720;
        public int videoHeight = 1280;
        //public MediaPlayer _mediaPlayer;
        [Header("Microphone")]
        public bool recordMicrophone;
        //public AudioSource microphoneSource;

        private MP4Recorder videoRecorder;
        private IClock recordingClock;
        private CameraInput cameraInput;
        private AudioInput audioInput;

        public void StartRecording()
        {
            // Start recording
            recordingClock = new RealtimeClock();
            var microphoneFormat = Format.Default;
            NatMic.StartRecording(Device.Default, microphoneFormat, OnSampleBuffer);

            videoRecorder = new MP4Recorder(
                videoWidth,
                videoHeight,
                30,
                recordMicrophone ? microphoneFormat.sampleRate : 0,
                recordMicrophone ? microphoneFormat.channelCount : 0,
                OnReplay
            );
            // Create recording inputs
            cameraInput = CameraInput.Create(videoRecorder, Camera.main, recordingClock);
            
        }        

        public void StopRecording()
        {            
            // Stop the microphone
            NatMic.StopRecording();
            // Stop the recording
            videoRecorder.Dispose();
            cameraInput.Dispose();
        }
        /*
        private void StartMicrophone()
        {
#if !UNITY_WEBGL || UNITY_EDITOR // No `Microphone` API on WebGL :(
            // Create a microphone clip
            microphoneSource.clip = Microphone.Start(null, false, 60, 44100);
            while (Microphone.GetPosition(null) <= 0) ;
            // Play through audio source
            microphoneSource.timeSamples = Microphone.GetPosition(null);
            microphoneSource.loop = true;
            microphoneSource.Play();
#endif
        }
        private void StopMicrophone()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            Microphone.End(null);
            microphoneSource.Stop();
#endif
        }
        */
        private void OnSampleBuffer(float[] sampleBuffer, long timestamp)
        {
            // Send sample buffers directly to the video recorder for recording
            if (videoRecorder != null)
            {
                videoRecorder.CommitSamples(sampleBuffer, recordingClock.Timestamp);
                //Debug.Log("Send SamplleBuff to NatCorder!");
            }                
        }

        private void OnReplay(string path)
        {
            Debug.Log("Saved recording to: " + path);
#if UNITY_EDITOR
            EditorUtility.OpenWithDefaultApp(path);
#elif (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
            string localURL = "file://" + path;
            NatShareU.NatShare.SaveToCameraRoll(path);
            Handheld.PlayFullScreenMovie(
                localURL,
                Color.black,
                FullScreenMovieControlMode.Full,
                FullScreenMovieScalingMode.AspectFit);
#endif
        }
    }
}