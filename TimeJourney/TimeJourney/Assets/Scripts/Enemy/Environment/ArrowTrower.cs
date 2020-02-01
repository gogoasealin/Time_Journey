using UnityEngine;

public class ArrowTrower : MonoBehaviour
{
    // referencce for arrow Prefab
    public GameObject arrowPrefab;
    // delay between new arrows trow
    public float frequency = 0.5f;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        InvokeRepeating("TrowArrows", 0, frequency);
    }

    /// <summary>
    /// Trow arrows
    /// </summary>
    public void TrowArrows()
    {
        // get a new arrow to be thrown
        GameObject nextArrow = GetNextArrow();
        //set gameobject position
        nextArrow.transform.position = transform.position;
        //activate the gameobject
        nextArrow.SetActive(true);
    }

    // Get a new arrow to be thrown
    public GameObject GetNextArrow()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (!gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                return gameObject.transform.GetChild(i).gameObject;
            }
        }

        // instantiate a new arrow if all the existing object are active already
        GameObject newArrow = Instantiate(arrowPrefab, gameObject.transform.position, Quaternion.identity);
        newArrow.SetActive(false);
        newArrow.transform.SetParent(gameObject.transform);
        newArrow.GetComponent<ArrowMovement>().positionToReach = gameObject.transform.GetChild(0).GetComponent<ArrowMovement>().positionToReach;
        return newArrow;
    }
}