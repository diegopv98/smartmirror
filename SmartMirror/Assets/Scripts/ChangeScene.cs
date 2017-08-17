using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour {


	// Use this for initialization
	public void CambiarNivel (int nivel) {
        SceneManager.LoadScene(nivel);
	}
	
	// Update is called once per frame

}
