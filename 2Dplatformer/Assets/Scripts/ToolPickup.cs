using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickup : MonoBehaviour
{

    // NOTE: THIS SCRIPT IS NOW ATTATCHED TO THE PLAYER OBJECT

    public GameObject closestTool;

    public bool hasTool = false;
    public GameObject pickedUpTool = null;

    private float distance;
    private float minimumDistance = 2f;

    void Start()
    {
        //playerObject = GameObject.FindWithTag("Player");
        //player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        closestTool = FindClosestTool();

        distance = Vector3.Distance(closestTool.transform.position, transform.position);
        
        if (Input.GetKeyDown(KeyCode.X)) {
            if (distance <= minimumDistance) { 
                if (!hasTool) { // close to tool and doesn't have tool
                    PickUpTool();
                }
                else // close to tool and has tool
                {
                    SwapTool();
                }
            }

            else { // not close to tool and has tool
                DropTool();
            }
        }


    }




    public GameObject FindClosestTool()
    {
        GameObject[] tool_list;
        tool_list = GameObject.FindGameObjectsWithTag("Tool");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject tool in tool_list)
        {
            Vector3 diff = tool.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = tool;
                distance = curDistance;
            }
        }
        return closest;
    }

    void PickUpTool()
     {
        hasTool = true;
        //pickedUpTool = closestTool
        //pickedUpTool = GetCorrespondingObjectFromSource(closestTool);
        Destroy(closestTool);
     }

     void DropTool()
     {
        hasTool = false;
        GameObject toolInstance = Instantiate(pickedUpTool, transform);
        pickedUpTool = null;
    }

    void SwapTool()
    {
        GameObject toolInstance = Instantiate(pickedUpTool, transform);
        //pickedUpTool = closestTool
        //pickedUpTool = GetCorrespondingObjectFromSource(closestTool);
    }
 
}