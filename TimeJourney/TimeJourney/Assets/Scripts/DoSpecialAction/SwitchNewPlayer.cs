using UnityEngine;

public class SwitchNewPlayer : MonoBehaviour
{
    // reference to simple player cam
    public Cinemachine.CinemachineVirtualCamera simplePlayerCam;

    // reference to player cam
    public Cinemachine.CinemachineVirtualCamera playerCam;

    // reference to sword logic
    public GameObject swordLogic;

    // reference to stone logic
    public GameObject stoneLogic;

    // reference to  simple player object
    public GameObject simplePlayerObject;

    // reference to  use sword and stone tutorial
    public GameObject useSwordAndStoneTutorial;

    [Tooltip("The first enemy body for getting components")]
    // reference to enemy body
    public GameObject enemyBody;

    /// <summary>
    /// MonoBehaviour Start function used to initialize variables
    /// </summary>
    private void Start()
    {
        if (simplePlayerObject != null && simplePlayerObject.transform.position == Vector3.zero)
        {
            GameController.instance.SpecialAction = GivePlayerItems;
        }
        if (GameController.instance.saveSystemSO.m_PlayerPositionX != 0 && GameController.instance.saveSystemSO.m_PlayerPositionY != 0)
        {
            GivePlayerItems();
            GameController.instance.GameOver();
        }
        enabled = false;
    }

    /// <summary>
    /// Activate player sword and stone
    /// </summary>
    public void GivePlayerItems()
    {
        // activate object
        swordLogic.SetActive(true);

        // activate object
        stoneLogic.SetActive(true);

        // disable script
        simplePlayerObject.GetComponent<PlayerMovement>().enabled = false;

        // set new player position
        GameController.instance.player.transform.position = simplePlayerObject.transform.position;

        // set new player rotation
        GameController.instance.player.transform.rotation = simplePlayerObject.transform.rotation;

        // disable simple player cam
        simplePlayerCam.enabled = false;

        // enable player cam
        playerCam.enabled = true;

        //set player facing direction;
        GameController.instance.player.GetComponent<CharacterController2D>().m_FacingRight = simplePlayerObject.GetComponent<PlayerMovement>().m_FacingRight;

        //enable player script;
        GameController.instance.player.GetComponent<PlayerMovementWithSword>().enabled = true;

        //destroy simple player object
        Destroy(simplePlayerObject);

        //activate tutorials
        useSwordAndStoneTutorial.SetActive(true);

        //remove script for damaging simple player
        Destroy(enemyBody.GetComponent<DamageToSimplePlayer>());

        //add script for damaging new player
        enemyBody.AddComponent<DamageToPlayer>();
    }
}