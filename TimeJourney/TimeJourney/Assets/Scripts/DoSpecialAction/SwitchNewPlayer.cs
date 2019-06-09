using UnityEngine;

public class SwitchNewPlayer : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera simplePlayerCam;
    public Cinemachine.CinemachineVirtualCamera playerCam;
    public GameObject swordLogic;
    public GameObject stoneLogic;
    public GameObject simplePlayerObject;
    public GameObject useSwordAndStoneTutorial;
    [Tooltip("The first enemy body for getting components")]
    public GameObject enemyBody;

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

        simplePlayerObject.GetComponent<PlayerMovement>().enabled = false;

        GameController.instance.player.transform.position = simplePlayerObject.transform.position;
        GameController.instance.player.transform.rotation = simplePlayerObject.transform.rotation;

        simplePlayerCam.enabled = false;
        playerCam.enabled = true;

        GameController.instance.player.GetComponent<CharacterController2D>().m_FacingRight = simplePlayerObject.GetComponent<PlayerMovement>().m_FacingRight;
        GameController.instance.player.GetComponent<PlayerMovementWithSword>().enabled = true;

        Destroy(simplePlayerObject);

        useSwordAndStoneTutorial.SetActive(true);

        Destroy(enemyBody.GetComponent<DamageToSimplePlayer>());
        enemyBody.AddComponent<DamageToPlayer>();
    }
}