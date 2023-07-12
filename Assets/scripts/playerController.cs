using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private Vector3 dir;
    private Rigidbody rb;

    [SerializeField] private float maxY;
    [SerializeField] private float rX;

    [SerializeField] private Transform camPivot;
    [SerializeField] private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        dir = Player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized);

        rX = Mathf.Lerp(rX, Input.GetAxisRaw("Mouse X") * 2, 100* Time.deltaTime);
        maxY = Mathf.Clamp(maxY - (Input.GetAxisRaw("Mouse Y") * 2 * 100 * Time.deltaTime), -30 , 30);
        Player.Rotate(0, rX, 0, Space.World);
        cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(maxY * 2 , Player.eulerAngles.y,0),100 * Time.deltaTime);
        camPivot.position = Vector3.Lerp(camPivot.position, Player.position, 10 * Time.deltaTime);
    }

    private void FixedUpdate() {
       rb.MovePosition(rb.position + dir * 10 * Time.fixedDeltaTime); 
    }
}
