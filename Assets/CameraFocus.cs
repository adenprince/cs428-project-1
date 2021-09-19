// Script provided by brivero30 on Unity Forums: https://forum.unity.com/threads/camera-out-of-focus-on-android.979743/

using UnityEngine;
using Vuforia;

public class CameraFocus : MonoBehaviour
{
    void Start()
    {
        var vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnPaused);
    }

    private void OnVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    private void OnPaused(bool paused)
    {
        if (!paused)
        {
            CameraDevice.Instance.SetFocusMode(
               CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }
}