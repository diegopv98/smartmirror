using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour {

    RawImage FondoWebCam;
    [SerializeField]
    public static int alto;
    [SerializeField] public static int ancho;
    [SerializeField] public static int Rota = 270;
    [SerializeField] public static bool Invertir = true;
    [SerializeField] public static string camName;
    public Vector3 rotacion;
    [SerializeField] public static int FPS;
    WebCamTexture webcamTexture;
    [SerializeField] public static float rojo, verde, azul;

    void Awake()
    {

    }

    void Start()
    {
#if UNITY_ANDROID
     //   rotacion.z = 270f;
#endif
        FondoWebCam = GetComponent<RawImage>();
        alto = Screen.height;
        ancho = Screen.width;
        FondoWebCam.rectTransform.sizeDelta = new Vector2(ancho, alto);
        //  FondoWebCam.rectTransform.sizeDelta = new Vector2(ancho, alto);
        Debug.Log(FondoWebCam.rectTransform.sizeDelta);
        VideoImagen(true);
        Rotar();
        Debug.Log(camName);
    }

    public void VideoImagen(bool grabando) {

        Pasos.SePuedePintar = !grabando;

        if (grabando == true)
        {
            Debug.Log("Se llamo");
            if (webcamTexture == null)
            {
                webcamTexture = new WebCamTexture();
              
                int rotation = webcamTexture.videoRotationAngle;
                rotation += 180;
              
            }
            webcamTexture.deviceName = camName;
            webcamTexture.requestedHeight = alto;//Screen.height;
            webcamTexture.requestedWidth = ancho;//Screen.width;
            webcamTexture.requestedFPS = FPS;
            webcamTexture.filterMode = FilterMode.Trilinear;
            webcamTexture.Play();
            FondoWebCam.texture = webcamTexture;
            FondoWebCam.material.mainTexture = webcamTexture;
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
        switch (Rota)
        {
            case 00:
                FondoWebCam.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
                rotacion.z = 0;
                FondoWebCam.rectTransform.eulerAngles = rotacion;
                break;
            case 90:
                FondoWebCam.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.width);
                rotacion.z = 90;
                FondoWebCam.rectTransform.eulerAngles = rotacion;
                break;
            case 180:
                FondoWebCam.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
                rotacion.z = 180;
                FondoWebCam.rectTransform.eulerAngles = rotacion;
                break;
            case 270:
                FondoWebCam.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.width);
                rotacion.z = 270;
                FondoWebCam.rectTransform.eulerAngles = rotacion;
                break;
        }
        
    }
}
