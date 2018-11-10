using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public bool enter = true;
    private Vector3 startPosition;
    private float respawnTime = 0.5f;
    Renderer[] rs;

    public ShakeCamera cameraShake;
   
    private void Awake()
    {
         rs = GetComponentsInChildren<Renderer>();
    }

    void Start()
    {
        startPosition = gameObject.transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            StartCoroutine(playerDie());
            
            cameraShake.Shakecamera();
        }
    }


    IEnumerator playerDie()
     {

        foreach (Renderer r in rs)
            r.enabled = false;

         yield return new WaitForSeconds(respawnTime);
        foreach (Renderer r in rs)
            r.enabled = true;
        gameObject.transform.position = startPosition;

         

    }

}
