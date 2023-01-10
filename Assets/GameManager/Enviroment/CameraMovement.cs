using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform targetobj;
    public Transform cameratrans;
    public Vector3 offset;

    public List<Transform> follow = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
      
     targetobj = follow[GameManager.instance.id -1];
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameratrans.position= targetobj.position+offset;
    }
}
