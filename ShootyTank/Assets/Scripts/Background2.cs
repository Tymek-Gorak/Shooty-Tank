using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-30.43f, -0.24f, 0f), 4f * Time.deltaTime);
        if (transform.position == new Vector3(-30.43f, -0.24f, 0f)){
            transform.position = new Vector3(53.57f, -0.24f, 0f);
        }
    }
}
