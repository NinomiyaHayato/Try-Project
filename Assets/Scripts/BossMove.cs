using UnityEngine;
using System.Collections;

public class BossMove : EnemyBase
{
    Rigidbody _rb;
    Animator _anim;
    [SerializeField, Header("巡回地点")] public Transform[] _patrol;
    int _patrolIndex = 0;
    [SerializeField, Header("巡回のターゲットに近づいた際の判断距離")] float _stopDistance;
    [SerializeField, Header("bossが近づくまでの距離")] float _stopDistance2;
    Transform _playerPos;
    Vector3 _dir; //patororlするためのvector
    [SerializeField, Header("攻撃までの仮のbool")] bool _attackLimit = true;
    [SerializeField, Header("当たり判定")] GameObject _attackCollider;
    [SerializeField, Header("distanceTest")] float _disTest;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        BossAnimation();
    }
    public void Move()
    {
        float distance = Vector3.Distance(transform.position, _patrol[_patrolIndex % _patrol.Length].transform.position);
        if (_playerPos)
        {
            if(_attackLimit)
            {
                float distance2 = Vector3.Distance(this.transform.position, _playerPos.position);
                _disTest = distance2;
                if(distance2 >= _stopDistance2)
                {
                    _dir = (_playerPos.position - this.transform.position).normalized * _moveSpeed;
                    _rb.velocity = _dir * _moveSpeed;
                    transform.LookAt(_playerPos.position);
                }
                else
                {
                    _attackLimit = false;
                }
            }
            else
            {
                StartCoroutine("BossAttack");
            }
        }
        else if (distance > _stopDistance && _playerPos == null)
        {
            _dir = (_patrol[_patrolIndex % _patrol.Length].transform.position - transform.position).normalized * _moveSpeed;
            _rb.velocity = _dir * _moveSpeed;
            transform.LookAt(_patrol[_patrolIndex % _patrol.Length].transform.position);
        }
        else
        {
            _patrolIndex++;
        }
    }
    public void BossAnimation()
    {
        if (_dir.magnitude > 0.1f)
        {
            _anim.SetFloat("Speed", _dir.magnitude);
        }
    }
    IEnumerator BossAttack()
    {
        _anim.SetTrigger("Attack");
        _attackCollider.SetActive(true);
        yield return new WaitForSeconds(2f);
        _attackCollider.SetActive(false);
        _attackLimit = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerPos = GameObject.FindObjectOfType<PlayerController>().transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _playerPos = null;
    }
}
