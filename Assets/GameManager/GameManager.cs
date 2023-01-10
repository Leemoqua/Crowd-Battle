using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money = 0;
    public int id = 1;

    //singleton
    public static GameManager instance = null;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else if(instance != null){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


}
