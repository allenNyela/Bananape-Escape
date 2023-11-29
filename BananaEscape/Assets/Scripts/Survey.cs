using UnityEngine;

public class Survey : MonoBehaviour
{
    int stareLength = 80;
    int iteration = 1;
    int stareCount = 1;
    int blinkLength = 20;
    int blinkCount = 0;
    bool blink = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!blink)
        {
            if (stareCount % stareLength == 0)
            {
                if (iteration == 1)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    iteration++;
                    blink = true;
                }
                else if (iteration == 2)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    iteration++;
                    blink = true;
                }
                else if (iteration == 3)
                {
                    transform.GetChild(2).gameObject.SetActive(false);
                    iteration = 1;
                    blink = true;
                }
            }
            stareCount++;
        } else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            if (blinkCount % blinkLength == 0)
            {
                blink = false;
                if (iteration == 1)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                } else if (iteration == 2)
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                } else if (iteration == 3)
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                }
            }
            blinkCount++;
        }
    }
}
