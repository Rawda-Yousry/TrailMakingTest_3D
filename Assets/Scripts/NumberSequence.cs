
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

    // private GameObject[] prefabsToInstantiate;
    public static int numberCount = 0;
    public LineDrawer lineDrawer;
    string testType;
    // private float randomX, randomY;
    // private readonly float z = 0.6f;

    // int x = 0;

    public Timer timerScript;

    void Start()
    {

    }



    void OnCollisionEnter(Collision other)
    {
        // Debug.Log("Collided");
        // Debug.Log(gameObject.name + "-----------"+other.gameObject.name);
        // if (other.gameObject.CompareTag("Number"))
        // {
        //     Randomize();
        // }
         if (other.gameObject.CompareTag("Point"))
        {
            // Debug.Log("Enteredd");
            AddToList();
            // Debug.Log(gameObject.transform.position);
            // Debug.Log("Nameeeeeeeee " + gameObject.name);
        }
    }

    void AddToList()
    {
        // Debug.Log("adddd");
        if (gameObject.CompareTag("Number") && (lastClickedObject != gameObject))
        {
            // Debug.Log("adddd22222");
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
            Debug.Log("Trueeee");
            Debug.Log(gameObjectList);
            Debug.Log(NumbersAndAlphabets);
            for (int i = 0; i < 25; i++)
            {
                Debug.Log("object" + gameObjectList[i]);
                Debug.Log("list" + NumbersAndAlphabets);
            }
            LoadFinishScene(true);
            // numberCount = 0;
        }
        else
        {
            Debug.Log("Falseeee");
            for (int i = 0; i < 25; i++)
            {
                Debug.Log("object " + gameObjectList[i]);
                Debug.Log("list " + NumbersAndAlphabets[i]);
            }
            LoadFinishScene(false);
            // numberCount = 0;
        }
    }

    void LoadFinishScene(bool isCongrats)
    {

        // SceneManager.LoadScene("Finish");
        string elapsedTime = timerScript.GetElapsedTime();

        PlayerPrefs.SetString("FinishTime", elapsedTime);

        // bool isCongrats = Enumerable.SequenceEqual(gameObjectList, Numbers);
        PlayerPrefs.SetInt("IsCongrats", isCongrats ? 1 : 0);

        SceneManager.LoadScene("Finish");

    }


}

