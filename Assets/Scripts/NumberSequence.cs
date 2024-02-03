
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NumberSequence : MonoBehaviour
{
    public static List<string>gameObjectList= new List<string>();
    public static List<string>Numbers = new List<string>(){"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", 
                                                            "12", "13", "14", "15", "16", "17", "18", "19", "20", "21",
                                                            "22", "23", "24", "25"
                                                          };
    
    public static List<string>NumbersAndAlphabets = new List<string>(){"1", "a", "2", "b", "3", "c", "4", "d", "5", "e", "6", 
                                                            "f", "7", "g", "8", "h", "9", "i", "10", "j", "11",
                                                            "k", "12", "l", "13"
                                                          };
    private GameObject lastClickedObject;
    public static int numberCount = 0;
    public LineDrawer lineDrawer;
    string testType;

    // public Timer timerScript;


    void OnMouseDown() {
        AddToList();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enteredd");
        AddToList();
        Debug.Log(gameObject.transform.position);
        Debug.Log("Nameeeeeeeee "+gameObject.name);
    }

    void AddToList(){
        Debug.Log("adddd");
        if((gameObject.tag == "Number") && (lastClickedObject != gameObject) ){
            Debug.Log("adddd22222");
            lineDrawer.StartNewLine(gameObject.transform.position);

            gameObjectList.Add($"{gameObject.name}");
            lastClickedObject = gameObject;
            numberCount ++;

            string allNames = string.Join(", ", gameObjectList);
            Debug.Log("=============" +allNames);
        }
        if (numberCount == 25){
            CheckAnswer();
        }
    }
    void CheckAnswer() {
            bool isEqual;
            // testType = PlayerPrefs.GetString("TestType");
            // if(testType == "A"){
                 isEqual = Enumerable.SequenceEqual(gameObjectList, Numbers);
            // }
            // else{
            //      isEqual = Enumerable.SequenceEqual(gameObjectList, NumbersAndAlphabets);
            // }

            if (isEqual) {
                Debug.Log("Trueeee");
                // LoadFinishScene(true);
                // numberCount = 0;
            }
            else {
                Debug.Log("Falseeee");
                // LoadFinishScene(false);
                // numberCount = 0;
            }   
    }
    
    void LoadFinishScene(bool isCongrats){

        // PlayerPrefs.SetInt("IsCongrats", isCongrats ? 1 : 0);
        // SceneManager.LoadScene("Finish");
        // string elapsedTime = timerScript.GetElapsedTime();

        // PlayerPrefs.SetString("FinishTime", elapsedTime);

        // bool isCongrats = Enumerable.SequenceEqual(gameObjectList, Numbers);
        PlayerPrefs.SetInt("IsCongrats", isCongrats ? 1 : 0);

        SceneManager.LoadScene("Finish");

    }


}

