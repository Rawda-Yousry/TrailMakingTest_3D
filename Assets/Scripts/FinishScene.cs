using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishScene : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] 
    TextMeshProUGUI resultText;

    [SerializeField] 
    TextMeshProUGUI levelText;

    private string test;

    void Start(){

        int isCongrats = PlayerPrefs.GetInt("IsCongrats", 0);
        string finishTime = PlayerPrefs.GetString("FinishTime", " ");


        if(isCongrats == 1){

            resultText.text = "Congratulations!" + " You've finished at\n " + finishTime;
            levelText.text = "Another Level";
            


        } else {

            resultText.text = "Try Again!" + " You've finished at\n  " + finishTime;
            levelText.text = "Try Again";
        }

    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.name == "LevelButton")
        {
            Debug.Log("Level"); 
            test = "A";
            string testType = PlayerPrefs.GetString("TestType", " ");
            if(testType == "A" && levelText.text == "Another Level" ){
                test = "A";
                PlayerPrefs.SetString("TestType", test);
                SceneManager.LoadScene("SampleScene");
                PlayerPrefs.DeleteAll();
                        
            }else if(testType == "A" && levelText.text == "Try Again" ){

                test = "A";
                PlayerPrefs.SetString("TestType", test);
                SceneManager.LoadScene("SampleScene");
                PlayerPrefs.DeleteKey("FinishTime");
                PlayerPrefs.DeleteKey("IsCongrats");

            }else if(testType == "B" && levelText.text == "Try Again" ){
            
                test = "A";
                PlayerPrefs.SetString("TestType", test);
                SceneManager.LoadScene("SampleScene");
                PlayerPrefs.DeleteKey("FinishTime");
                PlayerPrefs.DeleteKey("IsCongrats");


            }
            else{
                test = "A";
                PlayerPrefs.SetString("TestType", test);
                SceneManager.LoadScene("SampleScene");
                PlayerPrefs.DeleteAll();
            }
        }
        else if (other.gameObject.name == "MainMenuButton") {  
            Debug.Log("MainMenu");       
            SceneManager.LoadScene("Main Menu");
            PlayerPrefs.DeleteAll();
        }
    }


}


 


