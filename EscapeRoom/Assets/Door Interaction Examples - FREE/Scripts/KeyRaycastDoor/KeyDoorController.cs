using System.Collections;
using UnityEngine;

public class KeyDoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "DoorOpen";
    [SerializeField] private string closeAnimationName = "DoorClose";

    [Header("Door Locked UI")]
    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;

    [Header("Key Inventory")]
    [SerializeField] private KeyDoorInventory keyInventory = null;

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    public void PlayAnimation()
    {
        if (keyInventory.hasRedKey)
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }

            else if (doorOpen && !pauseInteraction)
            {
                doorAnim.Play(closeAnimationName, 0, 0.0f);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }

        else
        {
            StartCoroutine(ShowDoorLocked());
        }
    }

    IEnumerator ShowDoorLocked()
    {
        showDoorLockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }
}
