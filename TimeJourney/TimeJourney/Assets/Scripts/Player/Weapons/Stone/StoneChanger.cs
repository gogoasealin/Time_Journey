using UnityEngine;

public class StoneChanger : MonoBehaviour
{
    public GameObject[] prefabtype; // list of prefabs of all type that player can change ex:fire/ice
    public GameObject[] parentForType; // the parent of the shots
    public GameObject[] particleSystemType;
    public int stoneAvailable;

    private StoneAttacks StoneAttacks;

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StoneAttacks.FireWeapon = StoneAttacks.StoneAttack;
            StoneAttacks.levitation = false;
            ChangeStone("Fire");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && stoneAvailable > 1)
        {
            StoneAttacks.FireWeapon = StoneAttacks.StoneLevitation;
            StoneAttacks.levitation = true;
            SetPS("Levitation");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && stoneAvailable > 2)
        {
            StoneAttacks.FireWeapon = StoneAttacks.StoneAttack;
            StoneAttacks.levitation = false;
            ChangeStone("Light");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && stoneAvailable > 3)
        {
            StoneAttacks.FireWeapon = StoneAttacks.StoneAttack;
            StoneAttacks.levitation = false;
            ChangeStone("Ice");
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
        for (int i = 0; i < prefabtype.Length; i++)
        {
            if (prefabtype[i].name.Contains(name))
            {
                StoneAttacks.shot = prefabtype[i];
                return;
            }
        }
    }

    public void SetParent(string name)
    {
        for (int i = 0; i < parentForType.Length; i++)
        {
            if (parentForType[i].name.Contains(name))
            {
                StoneAttacks.shotsParent = parentForType[i];
                return;
            }
        }
    }

    public void SetPS(string name)
    {
        for (int i = 0; i < particleSystemType.Length; i++)
        {
            if (particleSystemType[i].name.Contains(name))
            {
                particleSystemType[i].SetActive(true);
            }
            else
            {
                particleSystemType[i].SetActive(false);
            }
        }
    }
}
