using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * 1000f * Time.fixedDeltaTime);
    }
}
