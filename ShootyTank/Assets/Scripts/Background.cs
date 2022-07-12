using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-15.06f, -3.2f, 0f), 8f * Time.deltaTime);
        if (transform.position == new Vector3(-15.06f, -3.2f, 0f)){
            transform.position = new Vector3(18.69f, -3.2f, 0f);
        }
    }
}
