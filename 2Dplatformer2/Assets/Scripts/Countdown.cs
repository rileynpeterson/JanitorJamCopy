using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    public static Countdown instance;    //allows Countdown functions to be called 
                                         //from other scripts/ classes outside

    public Text countDisplay;            //Text variable for GameObject reference

    public GameObject problem1;
    public GameObject problem2;
    public GameObject problem3;
    //for problems

    // PRIVATE DECLARATIONS
    private TimeSpan timePlaying;        //TimeSpan part of System namespace
                                         // used to format Time better

    private bool timerIsRunning;         //true when game starts, false when ends

    private float elapsedTime;           //holds Time.deltaTime value

    


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        countDisplay.text = "Time: 00:00.00";
        timerIsRunning = false;
        BeginTimer();

        //THIS DOES NOT WORK -- I don't know how to make it recognize which
        //Prefabs it needs to make
        //problem1 = GameObject.FindWithTag("puddle");
        //problem2 = GameObject.FindWithTag("pizza");
        //problem3 = GameObject.FindWithTag("children");
}
        


    public void BeginTimer()
    {
        timerIsRunning = true;
        elapsedTime = 480f; //480 seconds is equal to 8min00seconds (a.k.a: 8am start)

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerIsRunning = false;
    }


    //Let's clear something up if you want to make things happen along with the timer display.
    // I have float called elapsedTime and I set it to start at 480f which I believe is 
    // 480 seconds which, (for display purposes), is 8:00 am (60s * 8 = 480s) - [remember realtime seconds is minutes within the game]
    // that float will increase by Time.deltaTime (time elapsed since game started [very important])
    // You can ignore TimeSpan because that is for display purposes. 
    // To follow along with this logic and use it elsewhere, I recommend 
    // initializing a float (elapsedTime) to 480 (so we start at 8am)
    // and then if we want something to happen at 9am for example,
    // we can say, when elapsedTime is equal to (480s[8am] + 60s = 540s[9am]) 540.00, do something

    //following this logic, you DON'T have to reference Countdown.cs. You can just make a float 
    // elapsed time variable, start from 480 seconds (= 480f). And follow the logic explained above^
    // :)

    private IEnumerator UpdateTimer()
    {
        while (timerIsRunning)
        {
            //I'm not going to touch this for now:
            // Spawn problems
            Invoke("SpawnPuddles", 10.0f);
            Invoke("SpawnPizza", 20.0f);
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            if (elapsedTime < 720.00)       //720.00 "seconds" is equal to 12min00seconds
            {
                countDisplay.text = "Time: " + timePlaying.ToString("mm':'ss") + " am";
            }

            if (elapsedTime >= 720.00)          // if time >= 12:00pm
            {
                Invoke("SpawnCrowd", 2.0f);
                if (elapsedTime > 780.00)           // if time is greater than 12:59
                {                                   // then convert to 01:00 (rather than 13:00)
                    timePlaying = TimeSpan.FromSeconds(elapsedTime - 720.00);    //subtract 12:00
                    countDisplay.text = "Time: " + timePlaying.ToString("mm':'ss") + " pm";

                    if (elapsedTime > 960.00)   //when player has 1 minute left, color yellow
                    {
                        if (elapsedTime > 990.00) //when player has 30 seconds left, color RED (very scary)
                        {
                            countDisplay.color = Color.red;
                        }
                        else
                        {
                            countDisplay.color = Color.yellow;
                        }

                    }

                    countDisplay.text = "Time: " + timePlaying.ToString("mm':'ss") + " pm";

                }
                else
                {                                   // 11:59am < time < 1:00pm
                    countDisplay.text = "Time: " + timePlaying.ToString("mm':'ss") + " pm";
                }
            }

            if (elapsedTime > 1020.00)    //This says, if timer reaches 5:00p
            {                             // end Timer (game ends, player loses)
                Debug.Log("ended");
                EndTimer();
            }

            yield return null;
        }

    }

    void SpawnPuddles()
    {
        float spawn_x;
        float spawn_y;

        float[,] room_ranges = new float[,]
        {
            { -8.7f, 3.5f, -3.7f, 0.0f },
            { -0.5f, 4.0f, 1.6f, 1.15f },
            { 4.7f, 4.0f, 9.0f, 1.0f },
            { -9.3f, -3.3f, -3.4f, -4.0f },
            { -0.4f, -2.0f, 3.0f, -4.2f },
            { 5.8f, -1.7f, 9.3f, -4.1f }
        };

        int room_index = UnityEngine.Random.Range(0, 6);
        spawn_x = UnityEngine.Random.Range(room_ranges[room_index, 0], room_ranges[room_index, 2]);
        spawn_y = UnityEngine.Random.Range(room_ranges[room_index, 1], room_ranges[room_index, 3]);

        //problem = GameObject.FindWithTag("puddle");
        // Need to make more prefabs of different problem types then randomly choose one 
        GameObject problemInstance = Instantiate(problem1, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);
        //problemInstance.GetComponent<ProblemScript>().solvedByMop = true;
        //problemInstance.GetComponent<ProblemScript>().solvedByBroom = true;
    }

    void SpawnPizza()
    {
        float spawn_x;
        float spawn_y;

        float[,] room_ranges = new float[,]
        {
            { -8.7f, 3.5f, -3.7f, 0.0f },
            { -0.5f, 4.0f, 1.6f, 1.15f },
            { 4.7f, 4.0f, 9.0f, 1.0f },
            { -9.3f, -3.3f, -3.4f, -4.0f },
            { -0.4f, -2.0f, 3.0f, -4.2f },
            { 5.8f, -1.7f, 9.3f, -4.1f }
        };

        int room_index = UnityEngine.Random.Range(0, 6);
        spawn_x = UnityEngine.Random.Range(room_ranges[room_index, 0], room_ranges[room_index, 2]);
        spawn_y = UnityEngine.Random.Range(room_ranges[room_index, 1], room_ranges[room_index, 3]);

        //problem = GameObject.FindWithTag("pizza");
        // Need to make more prefabs of different problem types then randomly choose one 
        GameObject problemInstance = Instantiate(problem2, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);
        //problemInstance.GetComponent<ProblemScript>().solvedByMop = true;
        //problemInstance.GetComponent<ProblemScript>().solvedByBroom = true;
    }

    void SpawnCrowd()
    {
        float spawn_x;
        float spawn_y;

        float[,] room_ranges = new float[,]
        {
            { -8.7f, 3.5f, -3.7f, 0.0f },
            { -0.5f, 4.0f, 1.6f, 1.15f },
            { 4.7f, 4.0f, 9.0f, 1.0f },
            { -9.3f, -3.3f, -3.4f, -4.0f },
            { -0.4f, -2.0f, 3.0f, -4.2f },
            { 5.8f, -1.7f, 9.3f, -4.1f }
        };

        int room_index = UnityEngine.Random.Range(0, 6);
        spawn_x = UnityEngine.Random.Range(room_ranges[room_index, 0], room_ranges[room_index, 2]);
        spawn_y = UnityEngine.Random.Range(room_ranges[room_index, 1], room_ranges[room_index, 3]);

       // problem = GameObject.FindWithTag("children");
        // Need to make more prefabs of different problem types then randomly choose one 
        GameObject problemInstance = Instantiate(problem3, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);
        //problemInstance.GetComponent<ProblemScript>().solvedByMop = true;
        //problemInstance.GetComponent<ProblemScript>().solvedByBroom = true;
    }

}