using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeelapsed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.SetText("The first number is {0} and the 2nd is {1:2} and the 3rd is {3:0}.", 4, 6.345f, 3.5f);
        // The text displayed will be:
        // The first number is 4 and the 2nd is 6.35 and the 3rd is 4.
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
