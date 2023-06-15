using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("Enemy��HP")] protected int _enemyHp;
    [SerializeField, Header("Enemy�̍U����")] public int _attack;
    [SerializeField, Header("�ړ��X�s�[�h")] protected int _moveSpeed;
    [SerializeField, Header("���񂾂Ƃ��Ɋl������money")] protected int _deathMoney;
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
