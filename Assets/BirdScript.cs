using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        if (playerOutOfScreen())
        {
            logic.gameOver();
            birdIsAlive=false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    private bool playerOutOfScreen()
    {
        // Get the orthographic size of the camera (half of the height of the camera's view)
        float cameraHeight = camera.orthographicSize;

        // Calculate the Y position of the top and bottom of the camera's view
        float topYPosition = camera.transform.position.y + cameraHeight;
        float bottomYPosition = camera.transform.position.y - cameraHeight;

        // Check if the player is above the top or below the bottom of the camera's view
        bool isAboveTopY = transform.position.y > topYPosition;
        bool isBelowBottomY = transform.position.y < bottomYPosition;

        // Return true if the player is above the top or below the bottom of the camera's view
        return isAboveTopY || isBelowBottomY;
    }
}
