using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool right = true;
    bool down = true;
    [SerializeField]
    bool Horizontal;
    [SerializeField]
    float length;
    float deltaTime = 0;
    [SerializeField]
    float speed;
    float targetPosition;
    float initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (Horizontal)
        {
            initialPosition = transform.position.x;
            targetPosition = transform.position.x + length;
        } else
        {
            targetPosition = transform.position.y - length;
            initialPosition = transform.position.y;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (Horizontal)
            {
                if (right)
                {
                    transform.position = new Vector2(transform.position.x + speed/100, transform.position.y);
                    if (transform.position.x >= targetPosition)
                    {
                        right = false;
                    }
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
                else
                {
                //this.GetComponent<SpriteRenderer>().flipX = false;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.position = new Vector2(transform.position.x - speed/100, transform.position.y);
                    if (transform.position.x <= initialPosition)
                    {
                        right = true;
                    }
                    
            }
            } else
            {
                if (down)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - speed/100);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                if (transform.position.y <= targetPosition)
                    {
                        down = false;
                    }
                }
                else
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + speed/100);
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                if (transform.position.y >= initialPosition)
                    {
                        down = true;
                    }
                }
            }
    }
}
