using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    public float TotalTime=0.7f;
    public float Timer=0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer+=Time.deltaTime;
        if (Timer>=TotalTime){
            Timer=0;
            //GameObject.Find("Player").GetComponent<Player>().live-=1;

        }

    }
}
