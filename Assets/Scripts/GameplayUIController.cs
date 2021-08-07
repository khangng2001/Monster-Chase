using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameplayUIController : MonoBehaviour
{
    public void Back(){
        string name=EventSystem.current.currentSelectedGameObject.name;
        if (name=="Home")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if(name=="Restart")
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    // public void Restart(){
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
    // public void Home(){
    //     SceneManager.LoadScene("MainMenu");
    // }
}
