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
    public int PickUp() //�A�C�e���擾���ɃA�C�e����ID��Ԃ�
    {
        Destroy(gameObject);
        return _itemId;
    }
    public override void Use() //�A�C�e�����g��������֐�(���R�Ɍ��ʂ����Ă��������@����
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
