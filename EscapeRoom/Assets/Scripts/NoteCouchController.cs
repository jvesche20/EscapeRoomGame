using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCouchController : MonoBehaviour
{
    private Animator dresserAnim;
    private bool dresserOpen = false;

    [Header("Animation Names")]
    

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    public void PlayAnimation()
    {
        
    }
}
