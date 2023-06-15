using UnityEngine;

public class EnemyMove : EnemyBase
{
    [SerializeField, Header("ŽŸ‚ÉˆÚ“®‚·‚é‚Ü‚Å‚ÌŽžŠÔ")] float _limitTime;
    [SerializeField]float _time;// Œo‰ßŽžŠÔ
    Rigidbody _rb;
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoves();
        _anim.SetFloat("Speed", _rb.velocity.magnitude);
    }
    public void EnemyMoves()
    {
        _time += Time.deltaTime;
        _rb.velocity = transform.forward * _moveSpeed;

        if(_time > _limitTime)
        {
            float random = Random.Range(0, 180);
            transform.rotation = new Quaternion(0, random, 0, 0);
            _time = 0;
        }
    }
}
