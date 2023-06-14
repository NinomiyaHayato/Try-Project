using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("Hpのバー")] Slider _hpSlider;
    [Header("playerの参照")] PlayerController _playerController;
    [Header("スタート時のplayerのmaxhp")] int _maxhp;
    [SerializeField, Header("所持Gold")] Text _goldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        _hpSlider.value = 1;
        _playerController = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        _maxhp = _playerController._hp;
        _goldText.text = $"所持Gold : {_playerController._money}G";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerHp(int nowHp)
    {
        _hpSlider.value = (float)nowHp / (float)_maxhp;
    }
    public void Money(int money)
    {
        _goldText.text = $"所持Gold : {money}";
    }
}
