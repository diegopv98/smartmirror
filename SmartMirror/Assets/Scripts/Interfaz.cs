using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour {

    RawImage FondoWebCam;
    float alto;
    float ancho;
    public Vector3 rotacion;
    WebCamTexture webcamTexture;

    void Awake()
    {
#if UNITY_ANDROID
        rotacion.z = 270f;
#endif
        FondoWebCam = GetComponent<RawImage>();
        alto = Screen.height;
        ancho = Screen.width;
        FondoWebCam.rectTransform.sizeDelta = new Vector2(ancho,alto);
        //  FondoWebCam.rectTransform.sizeDelta = new Vector2(ancho, alto);
        Debug.Log(FondoWebCam.rectTransform.sizeDelta);
        VideoImagen(true);
        Rotar();
    }

    void Start()
    {

    }

    public void VideoImagen(bool grabando) {

        Pasos.SePuedePintar = !grabando;

        if (grabando == true)
        {
            Debug.Log("Se llamo");
            if (webcamTexture == null)
            {
                webcamTexture = new WebCamTexture();
                webcamTexture.requestedHeight = 1960;//Screen.height;
                webcamTexture.requestedWidth = 4032;//Screen.width;
                webcamTexture.requestedFPS = 60f;
                webcamTexture.filterMode = FilterMode.Trilinear;
                int rotation = webcamTexture.videoRotationAngle;
                rotation += 180;
                FondoWebCam.texture = webcamTexture;
                FondoWebCam.material.mainTexture = webcamTexture;
            }
            
            webcamTexture.Play();
        }
        else {
            webcamTexture.Pause();
        }
    }
 
    void Update () {
       // if (Input.GetKey(KeyCode.Space)){
         //   Rotar();
      //  }
	}
   public void Rotar() {
        FondoWebCam.rectTransform.sizeDelta = new Vector2(alto, ancho);
        FondoWebCam.rectTransform.eulerAngles = rotacion;
    }
}
