using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    int _attackPower;
    GameManager _gameManager;
    private void Start()
    {
        _attackPower = GameObject.FindObjectOfType<BossMove>().GetComponent<BossMove>()._attack;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindObjectOfType<PlayerController>().Damage(_attackPower);
            _gameManager.PlayerHp(FindObjectOfType<PlayerController>()._hp);
        }
    }
}
