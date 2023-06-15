using System.Collections;
using UnityEngine;

public class ItemManager : ItemBase
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public int PickUp() //アイテム取得時にアイテムのIDを返す
    {
        Destroy(gameObject);
        return _itemId;
    }
    public override void Use() //アイテムを使い分ける関数(自由に効果をつけてください　↓↓
    {
        if (base._state == Action.Heal)
        {
            PlayerController playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
            GameManager gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            if (playerController._hp <= 100)
            {
                if (playerController._hp + 30 <= 100)
                {
                    playerController._hp += 30;
                }
                else
                {
                    playerController._hp = 100;
                }
                gameManager.PlayerHp(playerController._hp);
            }
        }
        else if (base._state == Action.Poweeeeeer)
        {
            PlayerController playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
            playerController._attackPower += 1;
        }
        else
        {
            PlayerController playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
            playerController._moveSpeed += 1;
        }
    }
}
