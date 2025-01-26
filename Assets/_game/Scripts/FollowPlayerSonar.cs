using UnityEngine;

public class FollowPlayerSonar : MonoBehaviour
{
    public Transform player;
    public float yOffsetCamera;

   


    private void LateUpdate()
    {
        Vector3 playerPos = player.position;
        playerPos.y += yOffsetCamera;
        transform.position = playerPos;
    }
}
