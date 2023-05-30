using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rgb2d;
    SurfaceEffector2D se2d;
    bool canMove = true;
    void Start()
    {
         rgb2d = GetComponent<Rigidbody2D>();
         se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
        RotatePlayer();
        RespondToPlayer();
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rgb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToPlayer(){
        if(Input.GetKey(KeyCode.UpArrow)){
            se2d.speed = boostSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            se2d.speed = baseSpeed;
        }
    }

    public void DisableControl(){
        canMove = false;
    }
}
