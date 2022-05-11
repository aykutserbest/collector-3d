using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    private float staticYPosition = -0.13f;
    void Update()
    {
        if (gameObject.transform.position.y > staticYPosition)
        {
            gameObject.transform.position = new Vector3(transform.position.x, staticYPosition, transform.position.z);
        }
    }
}
