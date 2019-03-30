using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundaries
{
    public float xMin, xMax;
}

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float tilt  = 0.0f;

    [SerializeField] private Boundaries boundaries;

    private Rigidbody  body;

    private float x;
    #endregion

    void Start ()
    {
        body = GetComponent<Rigidbody>();
    }

    // Called each frame
    void Update ()
    {
        x = Input.GetAxis("Horizontal");
    }

    // Called each physics step
    void FixedUpdate ()
    {
        // To move the ship
        Vector3 movement = new Vector3 (x, 0.0f, 0.0f);
        body.velocity    = movement * speed;

        // To constraint the ship movement
        body.position = new Vector3 (
            Mathf.Clamp(body.position.x, boundaries.xMin, boundaries.xMax),
            0.0f,
            0.0f
        );

        // To rotate the ship during movement
        body.rotation = Quaternion.Euler(0.0f, 0.0f, -body.velocity.x * tilt);
    }
}
