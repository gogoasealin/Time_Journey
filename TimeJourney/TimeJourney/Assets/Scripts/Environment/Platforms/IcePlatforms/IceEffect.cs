using UnityEngine;

public class IceEffect : MonoBehaviour
{
    // force value
    public float force;

    //reference to Area effector
    private AreaEffector2D ae2D;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        ae2D = GetComponent<AreaEffector2D>();
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        GameController.instance.player.GetComponent<CharacterController2D>().m_JumpForce = 350;
    }

    /// <summary>
    /// MonoBehaviour OnDisable function for when the gameobject is diactivated.
    /// </summary>
    private void OnDisable()
    {
        if (GameController.instance.player != null)
        {
            GameController.instance.player.GetComponent<CharacterController2D>().m_JumpForce = 300;
        }
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        bool right = GameController.instance.player.GetComponent<CharacterController2D>().m_FacingRight;

        if (right)
        {
            ae2D.forceMagnitude = force;
        }
        else
        {
            ae2D.forceMagnitude = -force;
        }

    }
}
