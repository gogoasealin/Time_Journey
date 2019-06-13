using UnityEngine;

public class ArrowTrower : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float frequency = 0.5f;


    private void Start()
    {
        InvokeRepeating("TrowArrows", 0, frequency);
    }

    public void TrowArrows()
    {
        GameObject nextArrow = GetNextArrow();
        nextArrow.transform.position = transform.position;
        nextArrow.SetActive(true);
    }

    public GameObject GetNextArrow()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (!gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                return gameObject.transform.GetChild(i).gameObject;
            }
        }
        GameObject newArrow = Instantiate(arrowPrefab, gameObject.transform.position, Quaternion.identity);
        newArrow.SetActive(false);
        newArrow.transform.SetParent(gameObject.transform);
        newArrow.GetComponent<ArrowMovement>().positionToReach = gameObject.transform.GetChild(0).GetComponent<ArrowMovement>().positionToReach;
        return newArrow;
    }
}