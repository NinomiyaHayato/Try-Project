using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("Hp�̃o�[")] Slider _hpSlider;
    [Header("player�̎Q��")] PlayerController _playerController;
    [Header("�X�^�[�g����player��maxhp")] int _maxhp;
    [SerializeField, Header("����Gold")] Text _goldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        _hpSlider.value = 1;
        _playerController = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        _maxhp = _playerController._hp;
        _goldText.text = $"����Gold : {_playerController._money}G";
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
        _goldText.text = $"����Gold : {money}";
    }
}
