using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimatorParameters
{
   MoveVert
}


public class PlayerController : MonoBehaviour
{
   public float moveSpeed;
   public float rotateSpeed;
   public GameObject playerModel;

   private float _horInput;
   private float _vertInput;
   private Vector3 _moveVector;
   private Vector3 _moveInput;
   private Vector3 _forward;
   private Vector3 _right;
   [SerializeField] private CharacterController _charController; // loaded in Inspector
   [SerializeField] private Animator _animator; // loaded in Inspector

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      _horInput = Input.GetAxisRaw("Horizontal");
      _vertInput = Input.GetAxisRaw("Vertical");
      _moveInput = new Vector3(_vertInput, 0, _horInput);
      Movement();
      Turn();
      UpdateAnimations();

      if (Input.GetButtonDown("Fire1"))
      {
         _animator.SetTrigger("KickTrigger");
      }
   }

   private void Movement()
   {
      _moveVector = Vector3.zero;
      _forward = this.transform.forward * _vertInput;
      _right = this.transform.right * _horInput;
      _moveVector = _forward + _right;

      if (_moveVector.magnitude > 1.0f)
      {
         _moveVector.Normalize();
      }

      _moveVector.y += Physics.gravity.y * Time.deltaTime;

      _charController.Move(_moveVector * moveSpeed * Time.deltaTime);
   }

   private void Turn()
   {
      if (!PlayerDribble.instance.isKicking)
      {
         if (_moveInput != Vector3.zero)
         {
            Quaternion newRotateDir = Quaternion.LookRotation(new Vector3(_moveVector.x, 0f, _moveVector.z));
            playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, newRotateDir, rotateSpeed * Time.deltaTime);
         }
      }
      else
      {
         Quaternion newRotateDir = Quaternion.LookRotation(new Vector3(PlayerDribble.instance.target.transform.position.x, 0f, PlayerDribble.instance.target.transform.position.z));
         playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, newRotateDir, (rotateSpeed / 2) * Time.deltaTime);
      }

   }

   private void UpdateAnimations()
   {
      _animator.SetFloat(AnimatorParameters.MoveVert.ToString(), _moveInput.magnitude);
   }
}
