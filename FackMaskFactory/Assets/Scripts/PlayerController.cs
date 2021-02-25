using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRB;
    Transform myAvatar;

    [SerializeField] InputAction WASD;

    Vector2 movementInput;

    [SerializeField] float movementSpeed;
    // Start is called before the first frame update

    private void OnEnable(){
      WASD.Enable();
    }

    private void OnDisable(){
      WASD.Disable();
    }

    void Start()
    {
      myRB = GetComponent<Rigidbody>();
      myAvatar = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
      movementInput = WASD.ReadValue<Vector2>();

      if (movementInput.x != 0)
      {
        myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x),1);
      }

    }

    private void FixedUpdate()
    {
      myRB.velocity = movementInput * movementSpeed;
    }
}
