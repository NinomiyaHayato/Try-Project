using UnityEngine;

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
    Animator _anim;
    [SerializeField,Header("shopで使うGold")]public int _money;//アイテム引き換え用
    [SerializeField] GameObject _shop;//shopです
    GameManager _gameManager;
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
        //var rotationSpeed = 600 * Time.deltaTime;
        //_playerRotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(this.transform.rotation, _playerRotation, rotationSpeed);
        //第1引数のquaternionから第2引数のquaternionに向かった回転を返す、第3引数には最大の回転角度を指定できます。
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
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shop")
        {
            _shop.SetActive(true);
            ItemShop itemShop = FindObjectOfType<ItemShop>();
            itemShop.GetComponent<ItemShop>().ItemsShop();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _shop.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision) //テスト
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _hp -= 10;
            _gameManager.PlayerHp(_hp);
        }
    }
}
