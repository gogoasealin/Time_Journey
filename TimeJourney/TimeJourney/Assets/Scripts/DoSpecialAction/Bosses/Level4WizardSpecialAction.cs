using UnityEngine.SceneManagement;

public class Level4WizardSpecialAction : SpecialAction
{
    /// <summary>
    /// Do special Action 
    /// </summary>
    public override void DoSpecialAction()
    {
        // reload next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
