﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SceneManager.LoadScene("Menu");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.LoadScene("Menu");
    }
}
