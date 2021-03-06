﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {
    public int resWidth = 1080;
    public int resHeight = 1920;

    public static bool takeHiResShot = false;

    public static string ScreenShotName(int width, int height)
    {
        var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        folder = folder + "/Screenshots";

        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/StreamingAssets/Screenshots");


        return string.Format("{0}/screen_{1}x{2}_{3}.png",
                             Application.persistentDataPath + "/Screenshots",
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public static void TakeHiResShot()
    {
        takeHiResShot = true;
    }

    void LateUpdate()
    {
        takeHiResShot |= Input.GetKeyDown("k");
        if (takeHiResShot)
        {
            Camera camera = GetComponent<Camera>();
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            camera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            camera.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;
 
        }
    }
    public void Reiniciar() {

    }
}
