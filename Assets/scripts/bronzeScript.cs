using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bronzeScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseDown()
    {
        //print("HI");
        
        gameScript.points += gameScript.bronzePoints;
        gameScript.bronzeOre--;
        Destroy(this.gameObject);
    }
}
