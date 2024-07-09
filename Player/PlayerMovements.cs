using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [System.Serializable]
    public class MovementSettings
    {
        public float forwardVelocity = 10;
        public float jumpVelocity = 20f;

    }
    [System.Serializable]
    public class PhysicsSetting
    {
        public float downAccel = 0.75f;
    }
    public MovementSettings movementSettings= new MovementSettings();
    public PhysicsSetting physicsSetting=new PhysicsSetting();


    public Vector3 _velocity;
    private Animator _animator;
    private int _jumpInput = 0;
    private bool _onGround=false;
    private Rigidbody _rigidbody;

    //new for left and right
    public float xSpeed = 10f;
    private float _xMovement;

    void moveX()
    {
        transform.position=Vector3.MoveTowards(transform.position,new Vector3(_xMovement,transform.position.y,transform.position.z),Time.deltaTime*xSpeed);
    }
     

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _velocity = Vector3.zero;
    }
    private void FixedUpdate()
    {
        Run();
        _rigidbody.velocity = _velocity;
        InputHandling();
        CheckGround();
        Jump();

    }
    void Run()
    {
        _velocity.z=movementSettings.forwardVelocity;
    }
    void InputHandling()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _jumpInput = 1;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(_xMovement==0)
            {
                _xMovement = 3f;
            }
            else if (_xMovement == -3f)
            {
                _xMovement = 0f;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_xMovement == 0f)
            {
                _xMovement = -3f;
            }
            else if (_xMovement == 3f)
            {
                _xMovement = 0f;
            }
        }
        

    }
    void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit[] hits = Physics.RaycastAll(ray, 0.5f);

        _onGround = false;
        _rigidbody.useGravity = true;
        foreach(var hit in hits)
        {
            if(!hit.collider.isTrigger)
            {
                if(_velocity.y<=0)
                {
                    _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Time.deltaTime * 10);

                }
                _rigidbody.useGravity=false;
                _onGround=true;
                break;
            }
        }


    }
    void Jump()
    {
        if(_jumpInput==1 && _onGround)
        {
            _velocity.y = movementSettings.jumpVelocity;
            _animator.SetTrigger("Jump");
        }
        else if( _jumpInput==0 && _onGround)
        {
            _velocity.y = 0;
        }
        else
        {
            _velocity.y -= physicsSetting.downAccel;
        }
        _jumpInput = 0;
    }

}
