using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {
    public float Velocidad;

    // Use this for initialization
    void Start () {
        gameObject.transform.Translate(Velocidad, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
