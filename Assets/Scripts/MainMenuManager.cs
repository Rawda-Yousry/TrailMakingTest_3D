using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string test;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Level1")
        {
            test = "A";
            PlayerPrefs.SetString("TestType", test);
            Debug.Log("Level 1");
        }
        else if (other.gameObject.name == "Level2")
        {
            test = "B";
            PlayerPrefs.SetString("TestType", test);
            Debug.Log("Level 2");
        }
        SceneManager.LoadScene("SampleScene");
    }
}
