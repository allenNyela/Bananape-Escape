using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : MonoBehaviour
{
    [SerializeField]
    bool camEnabled = true;

    [SerializeField]
    int cameraIdx;

    [SerializeField]
    float disableTime = 5f;

    [SerializeField]
    Sprite offSprite;

    [SerializeField]
    Sprite onSprite;

    bool isTemporaryDisable = true;

    float timeDisabled = 0f;

    private void Update()
    {
        if (!camEnabled && isTemporaryDisable)
        {
            timeDisabled += Time.deltaTime;

            if (timeDisabled > disableTime)
            {
                EnableCam();
                timeDisabled = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Throwable"))
        {
            DisableCam(true);
        }
    }

    public void DisableCam(bool isTemp)
    {
        camEnabled = false;
        Level1Manager.Instance.DisableCam(cameraIdx);
        GetComponent<SpriteRenderer>().sprite = offSprite;
        isTemporaryDisable = isTemp;
    }

    public void EnableCam()
    {
        camEnabled = true;
        Level1Manager.Instance.EnableCam(cameraIdx);
        GetComponent<SpriteRenderer>().sprite = onSprite;
        isTemporaryDisable = true;
    }
}
