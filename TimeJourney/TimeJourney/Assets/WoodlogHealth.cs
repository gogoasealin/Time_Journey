using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodlogHealth : Health
{
    public GameObject watermapBlocked;
    public GameObject watermapFree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GetDamage(int dmgAmount)
    {
        watermapBlocked.SetActive(false);
        watermapFree.SetActive(true);
        Destroy(gameObject);
    }
}
