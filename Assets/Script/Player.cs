﻿using UnityEngine;
using System.Collections;

public class Player : Entity {
    public float walkSpeed;
    public float jumpSpeed;
    float axisX;
    float axisY;
    bool onFloor;
    public GameObject itemOnHand;
    public GameObject itemNearby;

	// Use this for initialization
    void Start()
    {
        base.Start();
        itemOnHand = null;
        itemNearby = null;
	}
	
    void Update() {
        axisX = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.X)) {
            if (itemOnHand)
            {
                itemOnHand.GetComponent<Item>().drop(gameObject);
                itemOnHand = null;
                
            }
            else if (itemNearby) {
                itemOnHand = itemNearby;
                itemOnHand.GetComponent<Item>().pick(gameObject);
            }
        }

    }

    protected override void moveEntity()
    {
        Vector3 move = rigidbody.velocity;
        if (axisX > 0)
        {
            move.x = walkSpeed;
        }
        else if (axisX < 0)
        {
            move.x = -walkSpeed;
        }
        else
        {
            move.x = 0;
        }

        if (!cameraController.GetComponent<CameraController>().turn)
        {
            move.x = -move.x;
        }

        if (axisY > 0 && onFloor)
        {
            move.y = jumpSpeed;
        }
        rigidbody.velocity = move;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Floor")) {
            onFloor = true;
        }
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
        }
    }

    void OnTriggerEnter(Collider collider) {
        GameObject item = collider.gameObject;
        if (item.GetComponent<Item>() && item.GetComponent<Item>().isPickable())
        {
            itemNearby = item;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        GameObject item = collider.gameObject;
        if (item == itemNearby)
        {
            itemNearby = null;
        }
    }
}
