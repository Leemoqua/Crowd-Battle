using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public float acceration=0.003f;
    public float veclocity= 0.05f;
    private float mainPos = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0,100*Time.deltaTime,0));

        this.veclocity+= this.acceration*Time.deltaTime;
        this.transform.Translate(new Vector3(0,veclocity,0));
        if (this.transform.position.y<mainPos && acceration<0){
            this.acceration*=-1;
        }
        if (this.transform.position.y>mainPos && acceration>0){
            
            this.acceration*=-1;
        }
    }
}
