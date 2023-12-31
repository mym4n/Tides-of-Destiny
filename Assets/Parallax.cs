using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float Movepercent = .3f;
    private Transform t_camera;
    public bool LockY = false;
    // Start is called before the first frame update
    void Start()
    {
        t_camera = GameObject.Find("Player_Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (LockY)
        {
            transform.position = new Vector2(t_camera.position.x * Movepercent, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(t_camera.position.x * Movepercent, t_camera.position.y * Movepercent);
        }
    }
}
