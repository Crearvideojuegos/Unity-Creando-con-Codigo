using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 _offset = new Vector3(0, 5, -7);
    private void LateUpdate() 
    {
        transform.position = Player.transform.position + _offset;
    }
}
