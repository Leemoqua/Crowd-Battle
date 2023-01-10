using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Text ScoreText;


    public bool unlock;

    public GameObject player;
    public GameObject Enemies;
    
    public GameObject LevelClear;
    public GameObject Loss;

    public List<GameObject> p = new List<GameObject>(); 
    
    // Update is called once per frame
    public void Start(){
      player = p[GameManager.instance.id -1];
    }
    void Update()
    {
        ScoreText.text = "Lives: " + player.GetComponent<Player>().live.ToString();
        
        if (player.GetComponent<Player>().live <= 0){
            Loss.SetActive(true);
            player.GetComponent<Player>().moveEnable= false;
            player.GetComponent<Player>().lose = true;

        }
        else if (player.transform.position.z > this.GetComponent<Transform>().Find("EndPoint").transform.position.z){
            LevelClear.SetActive(true);
            player.GetComponent<Player>().moveEnable=false;
            
        }
    }
}
