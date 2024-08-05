using UnityEngine;

public class LeftMovoment : MonoBehaviour

{
    public float speed;
    BoxCollider2D box;
    float groundWidth;
    float engelwidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(gameObject.CompareTag("Alt"))
        { 
        box = GetComponent<BoxCollider2D>();
        groundWidth =box.size.x;
    }
        else if (gameObject.CompareTag("engel"))
        {
            engelwidth = GameObject.FindGameObjectWithTag("sütun").GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMenager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        }
       
       if(gameObject.CompareTag("Alt"))
        {

            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("engel"))
        { 
            if (transform.position.x < GameMenager.bottomleft.x - engelwidth )
        { 
            Destroy(gameObject);
            }


        }
    }
}
