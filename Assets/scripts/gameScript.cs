using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameScript : MonoBehaviour {

    //"By the deadline, create a game that functions the same as the previous part, with the following additions:"
    // and later, it says:
    // "Instead of what's described previously,"
    // without specifying what previously was being struck from what to include.
    // nothing about whether to include a global suppy of ore, for instance.
    // I'll assume the basic concept of mining is the same, but I'll be replacing stuff wherever I can:
    // points replaces player-gathered ore, ore being clicked replaces ore being given.

    public int miningSpeed=3; 
    public int bronzePoints = 1;
    public int silverPoints = 10;
    public int goldPoints = 100;
    int points;
    int bronzeOre;
    int silverOre;
    int goldOre;
    int nextMine; //Tracks when the next ore will be mined by adding miningSpeed to it whenever ore is mined.

    //a location in the world
    Vector3 cubePosition;
    //initializes a cube
    public GameObject bronzeCube;

    float xPosition, yPosition;


	// Use this for initialization
	void Start () {
        points = 0;
        bronzeOre = 0;
        silverOre = 0;
        goldOre = 0;
        nextMine = miningSpeed;
        //                         x, y, z
        cubePosition = new Vector3(0, 0, 0);
        xPosition = -8;
        yPosition = 4;
	}
	


	// Update is called once per frame
	void Update () {
        if (Time.time > nextMine){
            nextMine += miningSpeed;
            //I didn't know whether the mining statements were exclusive, if they ran in order or if only one could happen.
            //I also didn't know which had priority if they were exclusive
            //I made it so as all could happen and so that one happening would not change whether another happened.
            if (silverOre==2 && bronzeOre==2){
                goldOre++;
                //SPAWN GOLD
            }
            if (bronzeOre < 4){
                bronzeOre++;
                xPosition += 2;
                if (xPosition > 8){
                    yPosition -= 4;
                }
                cubePosition = new Vector3(xPosition, yPosition, 0);

                //                                    Quaternion, as of right now, is a magic word.
                Instantiate(bronzeCube, cubePosition, Quaternion.identity);
            }
            else{ //No need for an if statement here, there's no distance between <4 and 4
                silverOre++;
                //SPAWN SILVER
            }
            print("You have " + points + " points");
        }
        
	}
}
