using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero; 
    private Vector3 cameraRotation = Vector3.zero;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float lookSensitivity;
    
    public GameObject Phone;
    public Light phoneLight;
    public Camera cam;

    private Inventory inventory;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        phoneLight.enabled = !phoneLight.enabled;
        inventory = GetComponent<Inventory>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        //Final calculated movement
        velocity = (moveHorizontal + moveVertical).normalized * speed;

        //Calculate rotation as a 3D vector
        float yRot = Input.GetAxisRaw("Mouse X");

        rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        //Calculate camera rotation as a 3D vector
        float xRot = Input.GetAxisRaw("Mouse Y");

        cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;
    }

    //Performs Movement and Rotations
    void FixedUpdate()
    {
        //Perform movement
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        //perform rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        //perform camera rotation
        if(cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }

        //Turn Phone Light on and off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            phoneLight.enabled = !phoneLight.enabled;
        }

        //Checks to see if an item is detected
        if(Input.GetKeyDown(KeyCode.R))
        {
            ItemCollection();
        }
    }

    bool ItemCollection()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10, layerMask);

        if (hit.collider.gameObject.GetComponent<Interactable>() != null)
        {
            float distance = Vector3.Distance(transform.position, hit.collider.gameObject.GetComponent<Interactable>().transform.position);
            if (distance < 3f)
            {
                Interactable item = hit.collider.gameObject.GetComponent<Interactable>();
                inventory.addItem(item);
                hit.collider.gameObject.SetActive(false);
                Debug.Log("Item Detected: " + item.name);
            }
        }
        return false;
    }
}