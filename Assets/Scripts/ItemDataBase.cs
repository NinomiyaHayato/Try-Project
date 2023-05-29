using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDataBase : ScriptableObject
{
    public  List<PocketItem> _itemList = new List<PocketItem>();
}
