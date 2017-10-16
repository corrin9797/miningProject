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
    bool spawnedGold = false;
    public int miningSpeed=3; 
    public static int bronzePoints = 1;
    public static int silverPoints = 10;
    public static int goldPoints = 100;
    public static int points;
    public static int bronzeOre;
    public static int silverOre;
    public static int goldOre;
    string onScreenScore;
    //These variables track time, and reset at 60 andding one to the next one up.
    int seconds;
    int secondChecker = 1;
    int minutes;
    int hours;
    string totalTime;
    int nextMine; //Tracks when the next ore will be mined by adding miningSpeed to it whenever ore is mined.

    //a location in the world
    Vector3 cubePosition;
    //initializes a cube
    public GameObject cubePrefab;

    GameObject currentCube;

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
        xPosition = -10;
        yPosition = 4;
	}
	


	// Update is called once per frame
	void Update () {
        //This is for the bit that tracks how long the player has been playing and shows it on screen (challenge by choice)
        if (Time.time > secondChecker)
        {
            seconds++;
            secondChecker++;
        }
        if (seconds >= 60)
        {
            seconds -= 60;
            minutes++;
        }
        if (minutes >= 60)
        {
            minutes -= 60;
            hours++;
        }
        //writing totalTime to account for 00:00:00 format
        if (hours < 10)
        {
            totalTime = "0";
        }
        totalTime += hours.ToString() + ":";
        if (minutes < 10)
        {
            totalTime += "0";
        }
        totalTime += minutes.ToString() + ":";
        if (seconds < 10)
        {
            totalTime += "0";
        }
        totalTime += seconds.ToString();
        print(totalTime);
        //This is the mian part of the project
        if (Time.time > nextMine){
            nextMine += miningSpeed;
            //I didn't know if gold could only happen once or happened and then also let another ore spawn.
            //I asked you, and you said no conseutive golds.
            if (silverOre==2 && bronzeOre==2 && !spawnedGold){
                goldOre++;
                xPosition += 2;
                if (xPosition > 8)
                {
                    yPosition -= 2;
                    xPosition = -8;
                }
                cubePosition = new Vector3(xPosition, yPosition, 0);

                //                                    Quaternion, as of right now, is a magic word.
                currentCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                currentCube.GetComponent<Renderer>().material.color = Color.yellow;
                currentCube.AddComponent<goldScript>();
                spawnedGold = true;
            }
            else if (bronzeOre < 4){
                bronzeOre++;
                xPosition += 2;
                if (xPosition > 8){
                    yPosition -= 2;
                    xPosition=-8;
                }
                cubePosition = new Vector3(xPosition, yPosition, 0);

                //                                    Quaternion, as of right now, is a magic word.
                currentCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                currentCube.GetComponent<Renderer>().material.color = Color.red;
                currentCube.AddComponent<bronzeScript>();
                spawnedGold = false;
                
            }
            else{ //No need for an if statement here, there's no distance between <4 and 4
                silverOre++;
                xPosition += 2;
                if (xPosition > 8)
                {
                    yPosition -= 2;
                    xPosition = -8;
                }
                cubePosition = new Vector3(xPosition, yPosition, 0);

                //                                    Quaternion, as of right now, is a magic word.
                currentCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                currentCube.GetComponent<Renderer>().material.color = Color.white;
                currentCube.AddComponent<silverScript>();
                spawnedGold = false;
            }
            print("You have " + points + " points");
            print("Bronze: " + bronzeOre + " Silver: " + silverOre + " Gold: " + goldOre);
            
        }
        
        

    }
    
    void OnGUI() //This appears to be an editable text box, but you can't actually edit it.
                //I'm fairly certain this isn't entirely the "right" way to do this but it works.
    {
        onScreenScore = "Score: "+points.ToString();
        
        onScreenScore = GUI.TextField(new Rect(10, 0, 200, 20), onScreenScore, 25);
        
        totalTime= GUI.TextField(new Rect(600, 0, 100, 20), totalTime, 25);
    }

}
