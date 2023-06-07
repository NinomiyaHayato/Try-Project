using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField]public  float _moveSpeed;
    [SerializeField]public float _jumpPower;
    [SerializeField] public int _hp;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _hp = 50;
    }

    // Update is called once per frame
    void Update()
    {
        float y = _rb.velocity.y;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            y = _jumpPower;
            _rb.velocity = Vector3.up * _jumpPower;
        }
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = Vector3.forward * h + Vector3.left * v;
        _rb.velocity = dir * _moveSpeed + _rb.velocity.y * Vector3.up;
    }
}
