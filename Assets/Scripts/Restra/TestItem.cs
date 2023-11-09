using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour
{
    private PlayerController _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void Use()
    {
        int i = gameObject.GetComponent<ItemGet>()._arrayNum;
        ItemInventory.instance._itemBool[i] = false;
        _player._moveSpeed = 5;
        Destroy(gameObject);
    }
}
