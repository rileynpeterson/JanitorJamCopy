using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemScript : MonoBehaviour
{
    private GameObject playerObject;
    public Countdown other;

    public bool solvedByMop;
    public bool solvedByTape;
    public bool solvedByLadder;
    public bool solvedByScrewDriver;
    public bool solvedByWrench;
    public bool solvedByHose;
    private bool[] solvedArray;
    private string[] toolNameArray = { "mop", "tape", "ladder", "screwDriver", "wrench", "hose" };
    private float distance;
    private float minimumDistance = 2f;

    void Start()
    {
        solvedArray = new bool[] { solvedByMop, solvedByTape, solvedByLadder, solvedByScrewDriver, solvedByWrench, solvedByHose }; 
        playerObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distance <= minimumDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < solvedArray.Length; i++)
                {
                    if (solvedArray[i] && (playerObject.GetComponent<ToolPickup>().pickedUpToolName == toolNameArray[i]))
                    {
                          Destroy(gameObject);

                    }

                }
 
            }

        }
    }
}