using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
        {
            // Change the coordinates from the screen to the Game Environment
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                // Find if the raycast has hit any GO tags
                if(hit.transform.tag == "Cube" || hit.transform.tag == "Sphere" || hit.transform.tag == "Capsule")
                {
                    // Invoke the ChangeColours Method sending the information of what tag has interacted with the Raycast
                    ChangeColours(hit.transform.tag);
                }
            }
        }

    }

    private void ChangeColours(string tags)
    {
        // Variable to store the Game Objects
        GameObject[] go;
        // Find the GO with tags
        go = GameObject.FindGameObjectsWithTag(tags);

        Color randomColour = Random.ColorHSV();
        // Loop to locate every figure with the tags
        foreach(GameObject figure in go)
        {
            // Access to that figure found and modify its colour to a random colour
            figure.GetComponent<MeshRenderer>().material.color = randomColour;
        }
    }
}
