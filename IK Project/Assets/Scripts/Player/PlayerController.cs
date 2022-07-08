using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Animator _animator;
        private Vector2 _inputs;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            SetMove();
            SetAnimations();
        }


        private void SetMove()
        {
            _inputs.x = Input.GetAxis("Horizontal");
            _inputs.y = Input.GetAxis("Vertical");
        
            var movementVector = new Vector3(_inputs.x * _speed, _rigidbody.velocity.y, _inputs.y * _speed);
            _rigidbody.velocity = transform.TransformDirection(movementVector);
        }


        private void SetAnimations()
        {
            _animator.SetFloat("Horizontal", _inputs.x);
            _animator.SetFloat("Vertical", _inputs.y);
            _animator.SetBool("IsMoving", _inputs.magnitude > 0);
        }
    
    }
}
