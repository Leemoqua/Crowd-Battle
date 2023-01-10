using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> P = new List<GameObject>();
    // Start is called before the first frame update
    protected virtual void Start()
    {
      player = P[GameManager.instance.id -1];  
    }
    protected virtual void FollowPlayer(){
        
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (distance < 7){
     
            Vector3 relPos= player.transform.position - this.transform.position;
            this.gameObject.GetComponent<Transform>().rotation = Quaternion.LookRotation(relPos);
            if (distance < 3){
                this.gameObject.GetComponent<Transform>().position+=(relPos.normalized*Time.deltaTime*7);
            }
        } 
    }
    // Update is called once per frame
    // Ghi chu lam mau
    void LateUpdate()
    {
       FollowPlayer();
    }
}
