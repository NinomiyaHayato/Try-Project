using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField, Header("ƒAƒCƒeƒ€No")] protected int _itemId;
    [SerializeField, Header("‰ñ•œ—Ê")] protected int _heal;
    [SerializeField, Header("UŒ‚—Í")] protected int _power;
    [SerializeField, Header("–hŒä—Í")] protected int _deffence;
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
