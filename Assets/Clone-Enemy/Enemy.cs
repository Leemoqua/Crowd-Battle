using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Clone
{

   
    public GameObject playerchild;
    // Start is called before the first frame update
    protected override void Start()
    {

      playerchild = P[GameManager.instance.id -1];
        
    }

    // Update is called once per frame
    void Update()
    {
      FollowPlayer();
    }

    protected override void FollowPlayer(){
        
        foreach (Transform child in GameObject.Find("PlayerClones").transform){

        }
        float distance = Vector3.Distance(playerchild.transform.position, this.transform.position);
        if (distance < 5){
            Vector3 relPos= playerchild.transform.position-this.transform.position;
            this.gameObject.GetComponent<Transform>().rotation=Quaternion.LookRotation(relPos);
            this.gameObject.GetComponent<Transform>().position+=(relPos.normalized*Time.deltaTime*7);
        }
    }

}
