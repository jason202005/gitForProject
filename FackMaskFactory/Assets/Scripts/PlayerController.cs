using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool hasControl;
    public static PlayerController localPlayer;


    // component
    Rigidbody myRB;
    Transform myAvatar;
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    //Player color
    static Color myColor;
    SpriteRenderer myAvatarSprite;
    // Start is called before the first frame update

    private void OnEnable(){
      WASD.Enable();
    }

    private void OnDisable(){
      WASD.Disable();
    }

    void Start()
    {
      if (hasControl){
        localPlayer = this;
      }

      myRB = GetComponent<Rigidbody>();
      // myAnim = GetComponent<Animator>();
      myAvatar = transform.GetChild(0);
      myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();
      if(myColor == Color.clear){
        myColor = Color.white;
      }
      myAvatarSprite.color = myColor;

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

    public void SetColor(Color newColor){
      myColor = newColor;
      if (myAvatarSprite != null)
      {
        myAvatarSprite.color = myColor;
      }
    }
}
