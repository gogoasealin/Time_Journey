using UnityEngine.SceneManagement;

public class Level4WizardSpecialAction : SpecialAction
{
    public override void DoSpecialAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
