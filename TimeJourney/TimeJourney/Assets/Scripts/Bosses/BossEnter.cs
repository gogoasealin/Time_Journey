using UnityEngine;

public class BossEnter : MonoBehaviour
{
    // reference to player object
    [HideInInspector] public GameObject player;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    void Start()
    {
        player = GameController.instance.player;
    }
}
