using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchNewPlayer : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cam;
    public GameObject swordLogic;
    public GameObject stoneLogic;
    public GameObject simplePlayerObject;
    public GameObject enemy;

    private void Start()
    {
        if (simplePlayerObject != null && simplePlayerObject.transform.position == Vector3.zero)
        {
            GameController.instance.SpecialAction = GivePlayerItems;
        }
        enabled = false;
    }

    public void GivePlayerItems()
    {
        swordLogic.SetActive(true);
        stoneLogic.SetActive(true);
        GameController.instance.player.transform.position = simplePlayerObject.transform.position;
        cam.Follow = GameController.instance.player.transform;
        GameController.instance.player.GetComponent<PlayerMovementWithSword>().enabled = true;

        Destroy(enemy);
        Destroy(simplePlayerObject);
    }
}
