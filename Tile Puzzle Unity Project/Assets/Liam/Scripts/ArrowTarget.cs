using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTarget : MonoBehaviour
{

    public float heightMultiplier;
    public float sightDist = 10;

    public Color objectsColour;

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitmouse;

        if (Physics.Raycast(ray, out hitmouse))
        {
            if (hitmouse.transform.tag == "ArrowBlock")
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    RaycastHit hit;

                    Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.red);

                    if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
                    {
                        objectsColour = hit.collider.gameObject.GetComponent<Renderer>().material.color;

                        gameObject.GetComponent<Renderer>().material.color = objectsColour;

                    }
                }
            }
        }

    }
}
