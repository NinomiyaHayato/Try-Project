using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField, Header("�A�C�e��No")] protected int _itemId;
    [SerializeField, Header("�񕜗�")] protected int _heal;
    [SerializeField, Header("�U����")] protected int _power;
    [SerializeField, Header("�h���")] protected int _deffence;
    [SerializeField]public Action _state = Action.Poweeeeeer;
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
