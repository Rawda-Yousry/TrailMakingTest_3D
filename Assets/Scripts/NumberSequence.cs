
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NumberSequence : MonoBehaviour
{
    public static List<string> gameObjectList = new List<string>();
    public static List<string> Numbers = new List<string>(){"1(Clone)", "2(Clone)", "3(Clone)", "4(Clone)", "5(Clone)", "6(Clone)", 
                                                            "7(Clone)", "8(Clone)", "9(Clone)", "10(Clone)", "11(Clone)",
                                                            "12(Clone)", "13(Clone)", "14(Clone)", "15(Clone)", "16(Clone)", 
                                                            "17(Clone)", "18(Clone)", "19(Clone)", "20(Clone)", "21(Clone)",
                                                            "22(Clone)", "23(Clone)", "24(Clone)", "25(Clone)"
                                                          };
    public static List<string> NumbersAndAlphabets = new List<string>(){"1(Clone)", "a(Clone)", "2(Clone)", "b(Clone)", "3(Clone)", 
                                                                        "c(Clone)", "4(Clone)", "d(Clone)", "5(Clone)", "e(Clone)", 
                                                                        "6(Clone)", "f(Clone)", "7(Clone)", "g(Clone)", "8(Clone)", 
                                                                        "h(Clone)", "9(Clone)", "i(Clone)", "10(Clone)", "j(Clone)",
                                                                        "11(Clone)", "k(Clone)", "12(Clone)", "l(Clone)", "13(Clone)"
                                                                        };
    private GameObject lastClickedObject;
    public static int numberCount = 0;
    public LineDrawer lineDrawer;
    string testType;
    public Timer timerScript;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            AddToList();
        }
    }

    void AddToList()
    {
        if (gameObject.CompareTag("Number") && (lastClickedObject != gameObject))
        {
            lineDrawer.StartNewLine(gameObject.transform.position);

            gameObjectList.Add($"{gameObject.name}");
            lastClickedObject = gameObject;
            numberCount++;

            string allNames = string.Join(", ", gameObjectList);
            Debug.Log("==" + allNames);
        }
        if (numberCount == 25)
        {
            CheckAnswer();
        }
    }
    void CheckAnswer()
    {
        bool isEqual;
        testType = PlayerPrefs.GetString("TestType");
        if(testType == "A"){
            isEqual = Enumerable.SequenceEqual(gameObjectList, Numbers);
        }
        else{
            isEqual = Enumerable.SequenceEqual(gameObjectList, NumbersAndAlphabets);
        }

        if (isEqual)
        {
            Debug.Log(gameObjectList);
            Debug.Log(NumbersAndAlphabets);
            LoadFinishScene(true);
        }
        else
        {
            LoadFinishScene(false);
        }
    }

    void LoadFinishScene(bool isCongrats)
    {
        string elapsedTime = timerScript.GetElapsedTime();
        PlayerPrefs.SetString("FinishTime", elapsedTime);
        PlayerPrefs.SetInt("IsCongrats", isCongrats ? 1 : 0);
        SceneManager.LoadScene("Finish Scene");
    }
}

