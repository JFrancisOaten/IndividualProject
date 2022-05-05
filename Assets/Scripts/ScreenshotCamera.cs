using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotCamera : MonoBehaviour
{
    public ScreenshotTaker screenshotCam;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("CallScreenshot", 30.0f, 5.0f);
    }

    void CallScreenshot()
    {
        screenshotCam.CallTakeScreenshot();
    }
}
