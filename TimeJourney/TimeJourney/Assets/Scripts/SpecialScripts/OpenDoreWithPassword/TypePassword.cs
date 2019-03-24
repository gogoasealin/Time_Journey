using TMPro;
using UnityEngine;

public class TypePassword : MonoBehaviour
{
    private int m_CurrentLetter;
    private string m_CurrentSentence;

    public TMP_Text m_CurrentSentenceText;
    public string password;
    //public GameObject Door;

    private void Start()
    {
        ResetText();
    }
    private void SetText()
    {
        m_CurrentSentenceText.text = m_CurrentSentence;
    }

    public void ResetText()
    {
        m_CurrentLetter = 0;
        m_CurrentSentence = "____";
        SetText();
    }

    public void SetNextCharacter(string letter)
    {  
        char[] ch = m_CurrentSentence.ToCharArray();
        ch[m_CurrentLetter] = letter.ToCharArray()[0];
        m_CurrentSentence = new string(ch);
        SetText();

        if (m_CurrentLetter < m_CurrentSentence.Length - 1)
        {
            m_CurrentLetter++;
        }
    }

    public void CheckValidation()
    {
        if (m_CurrentSentence.Equals(password))
        {
            Debug.Log("open door");
            GetComponent<ActivateByTrigger>().Disable();
            Destroy(GetComponent<ActivateByTrigger>());
            GetComponent<TypePassword>().enabled = false;
            //Door.GetComponent<ActivateDoor>().enabled = true;
        }
        else
        {
            ResetText();
        }
    }
}
