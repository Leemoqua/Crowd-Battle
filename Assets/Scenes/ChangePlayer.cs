using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Start()
    {
      
    }

    // Update is called once per frame
    public void Change1(){
      if(GameManager.instance.id == 0){

      }  
      else{
       GameManager.instance.id = 2; 
      }
    }
    public void Change2(){
     if(GameManager.instance.id == 0){

      }  
      else{
       GameManager.instance.id = 3; 
      }
    }
}
