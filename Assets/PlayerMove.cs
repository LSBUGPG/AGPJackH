    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    new public Transform camera;
    public CharacterController controller;
    public float speed = 20.0f;
    public float turnSmooth = 2.0f;
    public float jumpImpulse = 15f;
    float gravity = -20f;
    Vector3 velocity;
    float spin;
    bool jump;

    public void RelativeMovement(Vector3 input)
    {
        if (controller.isGrounded)
        {
            jump = input.y > 0f;
        }
        input.y = 0f;
        Vector3 direction = Vector3.Cross(camera.right, Vector3.up);
        Quaternion bearing = Quaternion.LookRotation(direction, Vector3.up);
        float y = velocity.y;
        velocity = (bearing * input) * speed;
        if (!controller.isGrounded)
        {
            velocity.y = y;
        }
    }

    private void Update()
    {
        Vector3 direction = new Vector3(velocity.x, 0f, velocity.z);
        if (direction.sqrMagnitude > 0.0f)
        {
            Quaternion look = Quaternion.LookRotation(direction, Vector3.up);
            float angle = Quaternion.Angle(transform.rotation, look);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, Mathf.SmoothDamp(0.0f, 1.0f, ref spin, turnSmooth));
        }
        if (jump)
        {
            velocity.y = jumpImpulse;
            jump = false;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
