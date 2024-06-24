using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject Plane;
    private Vector3 _offset = new Vector3(10, 0, 5);


    void LateUpdate()
    {
        transform.position = Plane.transform.position + _offset;
    }
}
