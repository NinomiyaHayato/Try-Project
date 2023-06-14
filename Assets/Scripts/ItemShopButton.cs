using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopButton : MonoBehaviour
{
    [SerializeField] ItemDataBase _itemBase;�@//�A�C�e����database���A�^�b�`
    public int _id;�@//�A�C�e����ID
    public int _buyCost; //�������߂̃R�X�g

    public int ID { get => _id; set => _id = value; }
    public int Cost { get => _buyCost; set => _buyCost = value; }
    // Start is called before the first frame update
    private void Start()
    {
        GetComponentInChildren<Text>().text = $"{_itemBase._itemList[_id]._itemName}";
    }
    public void Buy(int cost)
    {
        var player = GameObject.FindObjectOfType<PlayerController>();
        cost = _buyCost;
        if (player._money >= cost)
        {
            var playerPos = player.transform;
            GameObject.FindObjectOfType<PocketManager>().AddPocket(_id);
            player._money -= _buyCost;
            FindObjectOfType<GameManager>().Money(player._money);
            Debug.Log($"{_itemBase._itemList[_id]._itemName}�w��");
        }
    }
}
