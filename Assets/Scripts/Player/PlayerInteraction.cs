using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    private bool hasInteractable = false;
    public RectTransform interactText;

	private void FixedUpdate () {
        RaycastHit hit;
        
        Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward), Color.green);

        int layerMask = 1 << 9;

        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward), out hit, 1f, layerMask))
        {
            hasInteractable = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractable target = hit.collider.gameObject.GetComponent<IInteractable>();
                target.Activate();
            }
        } else
        {
            hasInteractable = false;
        }

        interactText.gameObject.SetActive(hasInteractable);

    }

}
