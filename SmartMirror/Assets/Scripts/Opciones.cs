using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Opciones : MonoBehaviour {

    public Dropdown dispositivos;

    public GameObject prueba;

    public static float red;
    public static float green;
    public static float blue;

    public Slider Sred;
    public Slider Sgreen;
    public Slider Sblue;
    public static int rotacion;

    public Dropdown Rotacion;
    public Toggle Girar;
    public Dropdown Dispositivos;
    public InputField FPS;
    public InputField Altura;
    public InputField Ancho;

    public static int[] valoresFinales = new int[5];
    public static string nombreCamara;
    //  public string[] nombres;
    // Use this for initialization
    void Start()
    {

        WebCamDevice[] devices = WebCamTexture.devices;
        dispositivos.options.Clear();
        List<string> lst = new List<string>();
        foreach (WebCamDevice devs in devices) {
            lst.Add(devs.name);
        }
       // dispositivos.options.Add(new Dropdown.OptionData(devs.name));
        dispositivos.AddOptions(lst);


    }

    public void SalvarDatos() {
        valoresFinales[0] = int.Parse(Rotacion.captionText.text); //1.
        if (Girar.isOn) { valoresFinales[1] = 1; } else { valoresFinales[1] = 0; } //2.
        nombreCamara = Dispositivos.captionText.text; //3.
        valoresFinales[2] = int.Parse(FPS.text);
        valoresFinales[3] = int.Parse(Altura.text);
        valoresFinales[4] = int.Parse(Ancho.text);
        Debug.Log(int.Parse(Rotacion.captionText.text));
        GetComponent<Configuracion>().ActualizarDatos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        red = Sred.value;
        green = Sgreen.value;
        blue = Sblue.value;
        prueba.GetComponent<Renderer>().material.color = new Color(red, green, blue);
    }
}
