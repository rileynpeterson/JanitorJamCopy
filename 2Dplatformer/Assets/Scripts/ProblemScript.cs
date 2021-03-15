using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemScript : MonoBehaviour
{
    private GameObject playerObject;

    public bool solvedByMop;
    public bool solvedByBroom;


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