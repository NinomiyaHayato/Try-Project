using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField, Header("アイテムNo")] protected int _itemId;　//アイテムのID
    [SerializeField] public Action _state = Action.Poweeeeeer; //効果を分けるためのenum
    [SerializeField, Header("回復量")] protected int _heal; //ここから下はご自由に設定してください ↓↓
    [SerializeField, Header("攻撃力")] protected int _power;
    [SerializeField, Header("防御力")] protected int _deffence;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract void Use();

    public enum Action
    {
        Heal,
        Poweeeeeer,
        Defence,
    }

}
