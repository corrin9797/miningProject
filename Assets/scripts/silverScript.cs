﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        //print("HI");

        gameScript.points += gameScript.silverPoints;
        gameScript.silverOre--;
        Destroy(this.gameObject);
    }
    void OnMouseOver()
    {
        this.GetComponent<Renderer>().material.color = Color.gray;
    }
    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }
}
