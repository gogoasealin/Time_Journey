using UnityEngine;

public class PopUpManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("True");
            gameObject.SetActive(false);
        }
    }
  
}
