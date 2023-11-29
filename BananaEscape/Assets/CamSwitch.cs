using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [SerializeField]
    List<SecurityCam> securityCams;

    [SerializeField]
    PlayerPlatformer player;

    [SerializeField]
    float maxDist;

    [SerializeField]
    Sprite offSprite;

    [SerializeField]
    Sprite onSprite;

    bool on = true;

    private void OnMouseDown()
    {
        if (!player.Grounded)
            return;

        if (!Level1Manager.Instance.CanWin())
            Level1Manager.Instance.Loose("You can't flip that switch with those pesky cameras on!");

        // if close enough
        if (on && Vector2.Distance(player.transform.position, transform.position) < maxDist)
        {
            foreach (SecurityCam cam in securityCams)
            {
                cam.DisableCam(false);
            }

            on = false;
            GetComponent<SpriteRenderer>().sprite = offSprite;
            return;
        }

        if (!on && Vector2.Distance(player.transform.position, transform.position) < maxDist)
        {
            foreach (SecurityCam cam in securityCams)
            {
                cam.EnableCam();
            }

            on = true;
            GetComponent<SpriteRenderer>().sprite = onSprite;
            return;
        }
    }
}
