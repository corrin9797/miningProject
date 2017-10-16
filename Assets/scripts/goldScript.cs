using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        //print("HI");

        gameScript.points += gameScript.goldPoints;
        gameScript.goldOre--;
        Destroy(this.gameObject);
    }
    void OnMouseOver()
    {
        this.GetComponent<Renderer>().material.color = Color.cyan; //No, cyan is not a lighter shade of yellow, but the Color.* options
                                                                    // are rather limited.
    }
    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
