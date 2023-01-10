using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;

     public List<GameObject> P = new List<GameObject>();
    void Start()
    {
        // liet ke phan tu player
        P[0] = GameObject.Find("Player");
        P[1] = GameObject.Find("Player2");


        Player = P[GameManager.instance.id -1];

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
        
    }
    public void Move(){
        Vector3 clonePos = this.transform.position;
        Vector3 playerPos = Player.transform.position;
        Vector3 relPos = playerPos-clonePos;
        this.gameObject.GetComponent<Transform>().rotation=Quaternion.LookRotation(relPos);
        this.gameObject.GetComponent<Transform>().position+=(relPos.normalized*Time.deltaTime*7);
    }
}
