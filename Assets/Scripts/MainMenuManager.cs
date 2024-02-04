using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string test;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Level1")
        {
            test = "A";
            PlayerPrefs.SetString("TestType", test);
        }
        else if (other.gameObject.name == "Level2")
        {
            test = "B";
            PlayerPrefs.SetString("TestType", test);
        }
        SceneManager.LoadScene("SampleScene");
    }
}
