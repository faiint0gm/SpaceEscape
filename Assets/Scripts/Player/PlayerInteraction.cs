using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public Camera mainCamera;
    private bool hasInteractable = false;

	private void FixedUpdate () {
        RaycastHit hit;
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

        int layerMask = 1 << 9;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f, layerMask))
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
	}

    void OnGUI()
    {
        if (hasInteractable)
        {
            Vector3 playerScreenPosition = mainCamera.WorldToScreenPoint(transform.position);
            Rect labelBox = new Rect(playerScreenPosition.x - 40, playerScreenPosition.y - 50, 80, 25);
            GUI.Box(labelBox, "Interact");
        }
    }
}
