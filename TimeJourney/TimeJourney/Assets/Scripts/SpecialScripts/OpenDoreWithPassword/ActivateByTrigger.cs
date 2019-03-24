using UnityEngine;

public class ActivateByTrigger : MonoBehaviour
{
    public GameObject m_SwordLogic;
    public GameObject m_Canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            m_SwordLogic.SetActive(false);
            m_Canvas.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Disable();
        }
    }

    public void Disable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        m_SwordLogic.SetActive(true);
        m_Canvas.SetActive(true);
    }
}
