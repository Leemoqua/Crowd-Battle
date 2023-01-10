using UnityEngine;
using System.Linq;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private Transform tr;
    public int upwardMove;
    public float rotateSpeed;
    public int live = 1;

    public bool lose = false;
    public bool moveEnable = true;

    public GameObject PlayerCloneModel;
    private GameObject PlayerClones;
    public GameObject Livemanager;
    public GameObject GameManager;
    


    private Animator animator;





    
    protected virtual void Start()
    {
        
        PlayerClones = GameObject.Find("PlayerClones");
        GameManager = GameObject.Find("GameManager");

        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody>();
        tr = this.transform;


        
    }

     
    // Update is called once per frame
    protected virtual void Update()
    {
        if (moveEnable)
        {
            Move();
            animator.SetBool("IsStop", true);
        }
        else if(moveEnable == false && lose == true) 
        {
          animator.SetBool("IsLose", true);  
        }
        else if(moveEnable == false){
          animator.SetBool("IsStop", false);
          transform.Rotate(0f, 30 * Time.deltaTime, 0f, Space.Self);
        }
    }
    void Move(){

        tr.Translate(new Vector3(0, 0, upwardMove) * Time.deltaTime);
        if (Input.GetKey("d") && tr.rotation.y < 0.4)
        {
            tr.Rotate(new Vector3(0, rotateSpeed*Time.deltaTime, 0));

        }
        else if (Input.GetKey("a") && tr.rotation.y > -0.4)
        {
            tr.Rotate(new Vector3(0, -rotateSpeed*Time.deltaTime, 0));
        }
        if (tr.position.x < -9)
        {
            var temp = tr.position;
            temp.x = -9;
            tr.position = temp;
        }
        else if (tr.position.x > 9)
        {
            var temp = tr.position;
            temp.x = 9;
            tr.position = temp;
        }
    }


    private void OnCollisionEnter(Collision co)
    {
        if (co.collider.tag == "Obstacle")
        {
            Destroy(co.gameObject);
            live -= 1;
            DestroyClone(0);
        }
        else if (co.collider.tag == "Clone")
        {
            Destroy(co.gameObject);
            Vector3 ClonePos = tr.position;
            int childCount = PlayerClones.transform.childCount;
            if (childCount > 0)
            {
                float min = PlayerClones.transform.GetChild(0).position.z;
                for (int i = 0; i < childCount; i++)
                {
                    float z = PlayerClones.transform.GetChild(i).position.z;
                    if (z < min)
                    {
                        min = z;
                    }
                }

                ClonePos.z = min - PlayerCloneModel.GetComponent<Collider>().bounds.size.z;
            }
            else
            {
                ClonePos.z -= PlayerCloneModel.GetComponent<Collider>().bounds.size.z;
            }

            GameObject clone = Instantiate(PlayerCloneModel, ClonePos, Quaternion.Euler(0, 0, 0));
            clone.transform.SetParent(GameObject.Find("PlayerClones").transform);
            live += 1;

            var forchoice = PlayerClones.GetComponent<ClonePlayer>().Clone;
            forchoice.Add(clone);


        }
        else if (co.collider.tag == "Enemy")
        {
            live -= 1;
            DestroyClone(0);
            Destroy(co.gameObject);
        }
        else if (co.collider.tag == "Donut"){
            Destroy(co.gameObject);
            GameManager.GetComponent<GameManager>().money += 1;
        }
    }
    
    protected void DestroyClone(int a){
      var forchoice = PlayerClones.GetComponent<ClonePlayer>().Clone;
      
      if(forchoice[a] == null){
        DestroyClone(a+1);
      }
      else{
        Destroy(forchoice[a]);
      }
    }





}
