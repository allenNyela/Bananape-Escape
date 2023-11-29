using UnityEngine;

public class LevelChangeAreaCaf : MonoBehaviour
{
    [SerializeField, Tooltip("if marked true, will trigger screen change when the Bananape touches this object. \nIf false it must be called by something else")] private bool calledByCollision;
    [SerializeField, Tooltip("the name of the scene to progress to")] private string sceneTransitionName;
    [SerializeField, Tooltip("the bananape tag")] private string bananapeTag = "Player";
    [SerializeField, Tooltip("if this is marked true, it can be used to transition to the next level")] private bool activated = true;


    // Update is called once per frame
    public void ChangeScene(string sceneToChangeTo = "")
    {
        if (!activated)
        {
            return;
        }
        if (sceneToChangeTo == "")
        {
            sceneToChangeTo = sceneTransitionName;
        }
        LevelTransition.Instance.SweepIn(sceneToChangeTo);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((calledByCollision || other.gameObject.tag == bananapeTag) && gameObject.GetComponent<InventoryManager>().GetKey())
        {
            ChangeScene();
        }
    }

    public void Activate(bool activate = true)
    {
        activated = activate;
    }
}
