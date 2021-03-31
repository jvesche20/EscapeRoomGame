using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookRaycast : MonoBehaviour
{
    [Header("Raycast Parameters")]
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exludeLayerName = null;

    private BookController raycasted_obj;

    [Header("Key Codes")]
    [SerializeField] private KeyCode openDresser = KeyCode.Mouse0;

    [Header("UI Parameters")]
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;
    private int opened = 0;
    public GameObject ui;
    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<BookController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDresser))
                {
                    raycasted_obj.PlayAnimation();
                    opened++;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (opened % 2 == 1)
                    {
                        Toggle();
                    }
                }
            }
        }

        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
    }
    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
