using UnityEngine;

public class FollowPlayerSonar : MonoBehaviour
{
    public Transform player;
    public float yOffsetCamera;

    private void LateUpdate()
    {
        Vector3 playerPos = player.position;
        Vector3 playerUp = player.up;
        Vector3 offset = playerUp * yOffsetCamera;
        transform.position = playerPos + offset;
        transform.up = playerUp;
    }
}
