using System;
using UnityEngine;

public class StoneAttacks : MonoBehaviour
{
    public static StoneAttacks instance;

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

    public Action FireWeapon = delegate { };
    private PlayerMovementWithSword pmws;

    private Vector3 target;
    public Camera cam;

    public Transform shotPosition; // position from where shots begin

    public GameObject shotsParent; // Parent for the current shots to use, may change for diferent shots
    public GameObject shot; // gameObject to instantiate if we don't have enought 
    private GameObject currentShot;
    public bool levitation;
    public LayerMask levitationLayerMask;

    private void Start()
    {
        pmws = GameController.instance.player.GetComponent<PlayerMovementWithSword>();
        FireWeapon = StoneAttack;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && pmws.canAttack)
        {
            FireWeapon();
        }
    }

    public void StoneLevitation()
    {
        StoneAnimation();
        Vector2 worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 1f, levitationLayerMask);

        if (hit.collider != null && hit.collider.gameObject.GetComponent<PickUp>())
        {
            hit.collider.gameObject.GetComponent<PickUp>().enabled = true;
        }
    }

    public void StoneAttack()
    {
        StoneAnimation();
    }

    public void Shot()
    {
        if (!levitation)
        {
            currentShot = GetNextShot();
            StoneInstantiate(currentShot, shotPosition.position);
        }
    }

    public void StoneAnimation()
    {
        pmws.canAttack = false;
        pmws.animator.SetTrigger("StoneAttack");
    }

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

    public void StoneInstantiate(GameObject shot, Vector2 positionToInstantiate)
    {
        shot.transform.position = positionToInstantiate;
        Vector3 targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
        shot.GetComponent<ShotMovement>().target = new Vector3(targetPos.x, targetPos.y, 0);
        shot.SetActive(true);
    }
}
