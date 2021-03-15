using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemScript : MonoBehaviour
{
    private GameObject playerObject;

    public bool solvedByMop;
    public bool solvedByTape;
    public bool solvedByLadder;
    public bool solvedByScrewDriver;
    public bool solvedByWrench;
    public bool solvedByHose;


    private float distance;
    private float minimumDistance = 2f;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distance <= minimumDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (true)
                {
                    Destroy(gameObject);
                }
            }

        }
    }
}