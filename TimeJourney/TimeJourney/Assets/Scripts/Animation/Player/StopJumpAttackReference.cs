using UnityEngine;

public class StopJumpAttackReference : MonoBehaviour
{
    /// <summary>
    /// reference for player movement with sword script
    /// </summary>
    public PlayerMovementWithSword pmws;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        // get script reference from parent gameobject
        pmws = GetComponentInParent<PlayerMovementWithSword>();
    }


}
