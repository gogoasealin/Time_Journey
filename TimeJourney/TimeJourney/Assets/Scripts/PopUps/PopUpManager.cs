using UnityEngine;

public class PopUpManager : MonoBehaviour {

    /// <summary>
    /// can be extended to disable when button string ButtonName was pressed
    /// </summary>
    [HideInInspector]public GameObject Child;

    private void Start()
    {
        Child = transform.GetChild(0).gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Child.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Child.SetActive(false);
        }
    }

}
