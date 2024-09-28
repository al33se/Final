using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour{
private PlayerMotor motor;
private PlayerInput playerInput;
public PlayerInput.OnFootActions onFoot;
private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        onFoot.Jump.performed+=ctx=>motor.Jump();
        look = GetComponent<PlayerLook>();
        onFoot.Crouch.performed+=ctx=>motor.Crouch();
        onFoot.Sprint.performed+=ctx=>motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        
    }
    void LateUpdate(){
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable(){
        onFoot.Enable();
    }
	private void OnDisable(){
		onFoot.Disable();
	}
}