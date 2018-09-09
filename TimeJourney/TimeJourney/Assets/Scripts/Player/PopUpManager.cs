using UnityEngine;

public class PopUpManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //To be done
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("True");
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
  
}
