using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    public GameObject CurrentPlayer;



    // Update is called once per frame
    protected virtual void MainMenu()
    {

        SceneManager.LoadScene("Menu");
        
    }
}
