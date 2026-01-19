using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float xOffset = 3f;
    public float yOffset = 0f;

    void LateUpdate()
    {
        transform.position = new Vector3(
            player.position.x + xOffset,
            player.position.y + yOffset,
            -10f
        );
    }
}
