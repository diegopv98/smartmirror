using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasos : MonoBehaviour {
    public GameObject Imagen;
    public GameObject BotonSacarFoto;
    public GameObject raya;
    public static bool SePuedePintar = false;

	public void TenerImagen (bool parar) {
        Imagen.GetComponent<Interfaz>().VideoImagen(parar);
        Instantiate(raya);
	}

    IEnumerator Reiniciar() {
        Screenshot.TakeHiResShot();
        yield return new WaitForEndOfFrame();
        TenerImagen(true);
        BotonSacarFoto.SetActive(true);
        GameObject[] lineas = GameObject.FindGameObjectsWithTag("Lineas");
        foreach (GameObject linea in lineas)
        {
            DestroyObject(linea);
        }
    }
    // Update is called once per frame
    public void GuardarImagen(bool seGuarda) {
        if (seGuarda == true)
        {
            StartCoroutine("Reiniciar");
          //  Screenshot.TakeHiResShot();
           // TenerImagen(true);
        }
        else {
            TenerImagen(true);
            GameObject[] lineas = GameObject.FindGameObjectsWithTag("Lineas");
            foreach (GameObject linea in lineas)
            {
                DestroyObject(linea);
            }
        }
        
    }
}
