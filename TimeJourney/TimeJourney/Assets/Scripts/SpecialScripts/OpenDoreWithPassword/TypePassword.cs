using TMPro;
using UnityEngine;

public class TypePassword : MonoBehaviour
{
    private int m_CurrentLetter;
    private char[] m_CurrentSentence;

    public TMP_Text[] m_CurrentSentenceText;
    public string password;
    //public GameObject Door;

    private void Start()
    {
        m_CurrentSentence = new char[m_CurrentSentenceText.Length];
        ResetText();
    }

    private void SetText()
    {
        for(int i = 0; i < m_CurrentSentenceText.Length; i++)
        {
            m_CurrentSentenceText[i].text = m_CurrentSentence[i].ToString();
        }
    }

    private void ResetCurrentSentence()
    {
        for (int i = 0; i < m_CurrentSentence.Length; i++)
        {
            m_CurrentSentence[i] = (char) 0;
        }
    }

    public void ResetText()
    {
        m_CurrentLetter = 0;
        ResetCurrentSentence();
        SetText();
    }

    public void SetNextCharacter(string letter)
    {  
        m_CurrentSentence[m_CurrentLetter] = letter.ToCharArray()[0];
        SetText();

        if (m_CurrentLetter < m_CurrentSentence.Length - 1)
        {
            m_CurrentLetter++;
        }
        else
        {
            CheckValidation();
        }
    }

    //check if password is corect, if soo open the door else if not reset text
    public void CheckValidation()
    {
        if (CheckPassword())
        {
            GetComponent<ActivateByTrigger>().Disable();
            Destroy(GetComponent<ActivateByTrigger>());
            GetComponent<TypePassword>().enabled = false;
            GetComponent<GoToNextLevel>().ChangeScene();
            //Door.GetComponent<ActivateDoor>().enabled = true;
        }
        else
        {
            ResetText();
        }
    }


    // check if password is same with curent Sentence
    public bool CheckPassword()
    {
        for(int i = 0; i < password.Length; i++)
        {
            if(!password[i].Equals(m_CurrentSentence[i]))
            {
                return false;
            }
        }
        return true;
    }
}
