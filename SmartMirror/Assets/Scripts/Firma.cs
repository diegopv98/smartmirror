using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firma : MonoBehaviour {

    private bool Soltar = false;
    bool Tocando = false;
	void Start () {
		
	}

	void Update () {
        if (Pasos.SePuedePintar == true && Soltar == false) {
            if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
            {
                Tocando = true;
                Plane objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                if (objPlane.Raycast(mRay, out rayDistance)) {
                    this.transform.position = mRay.GetPoint(rayDistance);
                }
            }
            if (Tocando == true && ( Input.GetMouseButton(0) == false)) {
                Soltar = true;
                Instantiate(this.gameObject);
            }
        }
	}
}
