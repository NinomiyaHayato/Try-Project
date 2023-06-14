using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopButton : MonoBehaviour
{
    [SerializeField] ItemDataBase _itemBase;　//アイテムのdatabaseをアタッチ
    public int _id;　//アイテムのID
    public int _buyCost; //買うためのコスト

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
            Debug.Log($"{_itemBase._itemList[_id]._itemName}購入");
        }
    }
}
