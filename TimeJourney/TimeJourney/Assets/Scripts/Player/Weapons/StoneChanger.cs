using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneChanger : MonoBehaviour
{
    public GameObject[] prefabtype; // list of prefabs of all type that player can change ex:fire/ice
    public GameObject[] parentForType; // the parent of the shots
    public GameObject[] particleSystemType;
    public StoneAttacks StoneAttacks;

    private void Start()
    {
        StoneAttacks = GetComponent<StoneAttacks>();
    }

    private void OnEnable()
    {
        SetPS("Fire");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeStone("Fire");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeStone("Ice");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeStone("Light");
        }
    }

    public void ChangeStone(string name)
    {
        SetType(name);
        SetParent(name);
        SetPS(name);
    }

    public void SetType(string name)
    {
        foreach (GameObject currentType in prefabtype)
        {
            if (currentType.name.Contains(name))
            {
                StoneAttacks.shot = currentType;
                return;
            }
        }
    }

    public void SetParent(string name)
    {
        foreach (GameObject currentType in parentForType)
        {
            if (currentType.name.Equals(name))
            {
                StoneAttacks.shotsParent = currentType;
                return;
            }
        }
    }

    public void SetPS(string name)
    {
        foreach (GameObject currentPS in particleSystemType)
        {
            if (currentPS.name.Contains(name))
            {
                currentPS.SetActive(true);
            }
            else
            {
                currentPS.SetActive(false);
            }
        }
    }
}
