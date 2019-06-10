using UnityEngine;

public class BossEnter : MonoBehaviour
{
    [HideInInspector] public GameObject player;

    void Start()
    {
        player = GameController.instance.player;
    }
}
