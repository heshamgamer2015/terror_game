using UnityEngine;
 
public class MouseLookAround : MonoBehaviour
{
    public Transform _transform;
    public Transform cameraTransform;

    Vector2 rotacaoMouse;
    public int sensibilidade = 300; 
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Vector2 controleMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        rotacaoMouse = new Vector3(rotacaoMouse.x + controleMouse.x * sensibilidade * Time.deltaTime,
                                   rotacaoMouse.y + controleMouse.y * sensibilidade * Time.deltaTime);

        _transform.eulerAngles = new Vector3(_transform.eulerAngles.x, rotacaoMouse.x, _transform.eulerAngles.z);
    
        cameraTransform.localEulerAngles = new Vector3(-rotacaoMouse.y,
                                                       cameraTransform.localEulerAngles.y,
                                                       cameraTransform.localEulerAngles.z);
    }
}