using System.Collections;
using System.Collections.Generic;
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
        if(base._state == Action.Heal)
        {
            Debug.Log("Heal");
        }
        else if(base._state == Action.Poweeeeeer)
        {
            Debug.Log("Poweeeeeer");
        }
        else
        {
            Debug.Log("Deffence");
        }
    }
}
