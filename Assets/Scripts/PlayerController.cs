using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    float _v; //vertical
    float _h; //holizontal
    Vector3 _dir;
    Quaternion _playerRotation;
    Rigidbody _rb;
    [SerializeField,Header("移動速度")] public float _moveSpeed;
    [SerializeField,Header("jumpする力")] public float _jumpPower;
    [SerializeField,Header("Playerのhp")] public int _hp;
    [SerializeField, Header("Playerの攻撃力")] public int _attackPower;
    Animator _anim;
    [SerializeField,Header("shopで使うGold")]public int _money;//アイテム引き換え用
    [SerializeField] GameObject _shop;//shopです
    GameManager _gameManager;
    [SerializeField, Header("当たり判定")] GameObject _attackCollider;
    Vector3 _firstPosition;
    private void Awake()
    {
        _playerRotation = transform.rotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _firstPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _v = Input.GetAxisRaw("Vertical");
        _h = Input.GetAxisRaw("Horizontal");
        float y = _rb.velocity.y;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = _jumpPower;
            _rb.velocity = Vector3.up * _jumpPower;
        }
        Animation();
    }
    private void FixedUpdate()
    {
        _dir = Vector3.forward * _v + Vector3.right * _h;
        _dir = Camera.main.transform.TransformDirection(_dir);
        _dir.y = 0;
        if (_h != 0 || _v != 0)
        {
            transform.forward = _dir;
        }
        _rb.velocity = _dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
    }
    public void Animation()
    {
        if(_dir.magnitude > 0.1f)
        {
            _anim.SetFloat("Speed", _dir.magnitude);
        }
        else
        {
            _anim.SetFloat("Speed", 0);
        }
        if(Input.GetButton("Fire2"))
        {
            _anim.SetTrigger("Attack");
            StartCoroutine("AttackCollider");
        }
    }
    public void Damage(int damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            this.transform.position = _firstPosition;
            _hp = 100;
        }
    }
    public void MoneyGet(int money)
    {
        _gameManager.Money(_money += money);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shop")
        {
            _shop.SetActive(true);
            ItemShop itemShop = FindObjectOfType<ItemShop>();
            itemShop.GetComponent<ItemShop>().ItemsShop();
            //会話の表示(仮

            GameObject.FindObjectOfType<NPCController>().Event();
        }
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBase>().Damage(_attackPower);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _shop.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _hp -= 10;
            _gameManager.PlayerHp(_hp);
        }
    }
    IEnumerator AttackCollider()
    {
        _attackCollider.SetActive(true);
        yield return new WaitForSeconds(1f);
        _attackCollider.SetActive(false);
    }
}
