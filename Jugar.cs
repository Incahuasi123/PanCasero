using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jugar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKey)
        {
            SceneManager.LoadScene("Nivel1");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
