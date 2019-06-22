using UnityEngine;

public class IceEffect : MonoBehaviour
{
    public float force;
    private AreaEffector2D ae2D;

    private void Start()
    {
        ae2D = GetComponent<AreaEffector2D>();
    }

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
