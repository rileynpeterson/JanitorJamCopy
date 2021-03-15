using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlLERP : MonoBehaviour
{
    public GameObject target;

    void FixedUpdate()
    {
        Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)target.transform.position, Time.fixedDeltaTime);
        //transform.position = new Vector3 (pos.x, pos.y, transform.position.y);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}

