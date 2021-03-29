using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    [Header("Object Type")]
    [SerializeField] private bool redDoor = false;
    [SerializeField] private bool redKey = false;

    [Header("Inventory")]
    [SerializeField] private KeyDoorInventory keyInventory = null;

    private KeyDoorController doorObject;

    private void Start()
    {
        doorObject = GetComponent<KeyDoorController>();
    }

    public void ObjectInteraction()
    {
        if (redDoor)
        {
            doorObject.PlayAnimation();
        }

        else if (redKey)
        {
            keyInventory.hasRedKey = true;
            gameObject.SetActive(false);
        }
    }
}
