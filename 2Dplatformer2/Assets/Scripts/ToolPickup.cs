using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickup : MonoBehaviour
{
    public GameObject closestTool;

    public bool hasTool = false;
    public string pickedUpToolName = null;

    private float distance;
    private float minimumDistance = 1f;

    void Start()
    {
        //playerObject = GameObject.FindWithTag("Player");
        //player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        closestTool = FindClosestTool();

        distance = Vector3.Distance(closestTool.transform.position, transform.position);

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!hasTool)
            {
                if (distance <= minimumDistance)
                {
                    PickUpTool();
                }
            }
            else
            {
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
        pickedUpToolName = closestTool.name;
        Destroy(closestTool);
    }

    void DropTool()
    {
        hasTool = false;
        GameObject toolInstance = (GameObject)Instantiate(Resources.Load(pickedUpToolName), transform.position, Quaternion.identity);
        toolInstance.name = pickedUpToolName;
        pickedUpToolName = null;
    }

}