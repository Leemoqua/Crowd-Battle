using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public List<GameObject> P = new List<GameObject>();
    

    // Start is called before the first frame update
    public void Start()
    {
      P[GameManager.instance.id -1].SetActive(true);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
