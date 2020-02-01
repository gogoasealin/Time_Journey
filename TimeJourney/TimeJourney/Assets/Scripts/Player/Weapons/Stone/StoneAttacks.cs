using System;
using UnityEngine;

public class StoneAttacks : MonoBehaviour
{
    // reference to singleton stone attacks instance
    public static StoneAttacks instance;
    // fire weapon action
    public Action FireWeapon = delegate { };
    //referation to pmws
    private PlayerMovementWithSword pmws;
    //target
    private Vector3 target;
    //cam
    public Camera cam;
    // position from where shots begin
    public Transform shotPosition;
    // Parent for the current shots to use, may change for diferent shots
    public GameObject shotsParent;
    // gameObject to instantiate if we don't have enought 
    public GameObject shot;
    //current shot
    private GameObject currentShot;
    //levitation status
    public bool levitation;
    //levitation layer mask
    public LayerMask levitationLayerMask;

    /// <summary>
    /// MonoBehaviour Awake function
    /// </summary>
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        pmws = GameController.instance.player.GetComponent<PlayerMovementWithSword>();
        FireWeapon = StoneAttack;
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && pmws.canAttack)
        {
            FireWeapon();
        }
    }

    /// <summary>
    /// Stone Levitation
    /// </summary>
    public void StoneLevitation()
    {
        StoneAnimation();
        Vector2 worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 1f, levitationLayerMask);
        if ((hit.collider != null && hit.collider.gameObject.GetComponent<PickUp>()))
        {
            hit.collider.gameObject.GetComponent<PickUp>().enabled = true;
        }
        else if (hit.collider != null && hit.collider.gameObject.GetComponent<PickUpBomb>())
        {
            hit.collider.gameObject.GetComponent<PickUpBomb>().enabled = true;
        }
    }

    /// <summary>
    /// Stone Attack
    /// </summary>
    public void StoneAttack()
    {
        //trigger stone animation
        StoneAnimation();
    }

    /// <summary>
    /// Shot
    /// </summary>
    public void Shot()
    {
        if (!levitation)
        {
            currentShot = GetNextShot();
            StoneInstantiate(currentShot, shotPosition.position);
        }
    }

    /// <summary>
    /// Stone animation
    /// </summary>
    public void StoneAnimation()
    {
        pmws.canAttack = false;
        pmws.animator.SetTrigger("StoneAttack");
    }

    /// <summary>
    /// Get next shot
    /// </summary>
    /// <returns></returns>
    public GameObject GetNextShot()
    {
        for (int i = 0; i < shotsParent.transform.childCount; i++)
        {
            if (!shotsParent.transform.GetChild(i).gameObject.activeSelf)
            {
                return shotsParent.transform.GetChild(i).gameObject;
            }
        }
        GameObject newShot = Instantiate(shot, shotPosition.position, Quaternion.identity);
        newShot.transform.SetParent(shotsParent.transform);
        newShot.SetActive(false);
        return newShot;
    }

    /// <summary>
    /// Stone Levitation
    /// </summary>
    /// <param name="shot">shot object</param>
    /// <param name="positionToInstantiate">shot position to instantiate</param>
    public void StoneInstantiate(GameObject shot, Vector2 positionToInstantiate)
    {
        shot.transform.position = positionToInstantiate;
        Vector3 targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
        shot.GetComponent<ShotMovement>().target = new Vector3(targetPos.x, targetPos.y, 0);
        shot.SetActive(true);
    }
}
