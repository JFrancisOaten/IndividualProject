
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenshotTaker : MonoBehaviour
{
    Camera screenshotCamera;

    int resWidth = 256;
    int resHeight = 256;

    void Awake()
    {
        screenshotCamera = GetComponent<Camera>();
        if (screenshotCamera.targetTexture == null)
        {
            screenshotCamera.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = screenshotCamera.targetTexture.width;
            resHeight = screenshotCamera.targetTexture.height;
        }
        screenshotCamera.gameObject.SetActive(false);
    }

    public void CallTakeScreenshot()
    {
        screenshotCamera.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (screenshotCamera.gameObject.activeInHierarchy)
        {
            Texture2D screenshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false); //setting the resolution of the screenshot
            screenshotCamera.Render(); //calling the render function
            RenderTexture.active = screenshotCamera.targetTexture; //setting the renderTexture as the target of the camera
            screenshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0); //Reading the pixels onto the renderTexture
            byte[] bytes = screenshot.EncodeToPNG(); //encoding the saved texture to PNG format
            string fileName = ScreenshotName(); //setting the file name using a function
            System.IO.File.WriteAllBytes(fileName, bytes); //Saving the file to the system folder
            Debug.Log("Screenshot Taken!"); //Debug to say the picture has been taken
            screenshotCamera.gameObject.SetActive(false); //setting the process to false so that it does not take more than one screenshot
        }
    }

    string ScreenshotName()
    {
        return string.Format("{0}/Screenshots/{1}_{2}.png", //Function used to set the filename of the screenshot being taken
            Application.dataPath, //Setting the path
            gameObject.name, //Setting the camera name of whichever camera is taking the screenshot
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")); //Setting the date and time
    }
}

