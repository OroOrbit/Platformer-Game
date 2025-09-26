using UnityEngine;

public class boxmove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 distance = new Vector2(0, 0);
        transform.position = new Vector3(2, 1, 0);
        transform.localScale = new Vector3(2, 2, 2);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.green;
        int number = 1 + 1 + 6;
        bool isalive = 3 > 5; //false
        Debug.Log(isalive);

        int amm = 10;
        if (amm> 0)
        {
          Debug.Log("Player can shoot");  
        }
        else
        {
            Debug.Log("Reload");
        }

    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log("Script 1 Update"); 
    }
}
