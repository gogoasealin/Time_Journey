using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceStairs : MonoBehaviour
{
    public GameObject stairsPlatform;
    public GameObject smoothPlatform;

    public float startDelay;
    public float frequency;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeStairs", startDelay, frequency);
    }

    void ChangeStairs()
    {
        stairsPlatform.SetActive(!stairsPlatform.activeSelf);
        smoothPlatform.SetActive(!smoothPlatform.activeSelf);
    }
}
