using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    public bool collide = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collide = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collide = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
