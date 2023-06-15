using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("EnemyのHP")] protected int _enemyHp;
    [SerializeField, Header("Enemyの攻撃力")] public int _attack;
    [SerializeField, Header("移動スピード")] protected int _moveSpeed;
    [SerializeField, Header("死んだときに獲得するmoney")] protected int _deathMoney;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int damage)
    {
        _enemyHp -= damage;
        if(_enemyHp <= 0)
        {
            GameObject.FindObjectOfType<PlayerController>().MoneyGet(_deathMoney);
            Destroy(this.gameObject);
        }
    }
}
