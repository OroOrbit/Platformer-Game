using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float moveSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKey(KeyCode.W))
        {
           // transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);
        }

        //if (Input.GetKey(KeyCode.S))
        {
           // transform.position = new Vector3(transform.position.x, transform.position.y-moveSpeed * Time.deltaTime, transform.position.z);  
        }
       // if (Input.GetKey(KeyCode.A))
        {
           // transform.position = new Vector3(transform.position.x-moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);  
        }
        //if (Input.GetKey(KeyCode.D))
        {
           // transform.position = new Vector3(transform.position.x+moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);  
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0);
        transform.Translate(movement* moveSpeed*Time.deltaTime);
    }
}
