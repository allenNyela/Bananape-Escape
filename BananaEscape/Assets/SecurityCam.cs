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
        GetComponent<SpriteRenderer>().color = Color.gray;
        Level1Manager.Instance.DisableCam(cameraIdx);
        isTemporaryDisable = isTemp;
    }

    public void EnableCam()
    {
        camEnabled = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        Level1Manager.Instance.EnableCam(cameraIdx);
        isTemporaryDisable = true;
    }
}
