using UnityEngine;

public class StoneChanger : MonoBehaviour
{
    // list of prefabs of all type that player can change ex:fire/ice
    public GameObject[] prefabtype;
    // the parent of the shots
    public GameObject[] parentForType;
    // particle system type
    public GameObject[] particleSystemType;
    // stone available
    public int stoneAvailable;
    // stone attacks
    private StoneAttacks StoneAttacks;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        StoneAttacks = GetComponent<StoneAttacks>();
    }

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    private void OnEnable()
    {
        SetPS("Fire");
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
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
            ChangeStone("Ice");
        }
    }

    /// <summary>
    /// Change stone
    /// </summary>
    /// <param name="name">selected stone name</param>
    public void ChangeStone(string name)
    {
        SetType(name);
        SetParent(name);
        SetPS(name);
    }

    /// <summary>
    /// Set type
    /// </summary>
    /// <param name="name">type name</param>
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

    /// <summary>
    /// Set parent
    /// </summary>
    /// <param name="name"></param>
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

    /// <summary>
    /// Set particle system
    /// </summary>
    /// <param name="name"></param>
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
