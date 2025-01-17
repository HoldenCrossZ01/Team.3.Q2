using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Tutorial.I");
    }
    public void gameoverload() 
    {
        SceneManager.LoadScene("Tutorial.I");

    }
    public void title()
    {
        SceneManager.LoadScene("Title");
    }

    public void credits()
    {
        SceneManager.LoadScene("credits");
    }
    public void GetOut()
    {
        Application.Quit();
    }
    public void Joshua()
    {
        SceneManager.LoadScene("1");
    }
    public void Alice()
    {
        SceneManager.LoadScene("2");
    }
    public void Coda()
    {
        SceneManager.LoadScene("3");
    }
    public void Kenny()
    {
        SceneManager.LoadScene("4");

    }
}
