using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * 1000f * Time.fixedDeltaTime);
    }
}
