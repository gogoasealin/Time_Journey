using UnityEngine;

/// <summary>
/// Follow the player position
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    /// <summary>
    /// reference to a transform
    /// </summary>
    public Transform target;

    /// <summary>
    /// called every late updated 
    /// </summary>
    void LateUpdate()
    {
        //set a new position
        transform.position = new Vector3(target.position.x, 10f, 0);
    }
}
