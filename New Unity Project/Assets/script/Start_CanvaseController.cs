using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Start_CanvaseController : MonoBehaviour
{
    public void Rule_Botton()
    {
        SceneManager.LoadScene("Rule");
    }
    public void Main_Botton()
    {
        SceneManager.LoadScene("Main");
    }
    public void Title_Botton()
    {
        SceneManager.LoadScene("Title");
    }
}
