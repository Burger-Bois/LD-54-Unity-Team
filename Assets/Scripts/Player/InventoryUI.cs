using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public void StoreItem(CollectableController item)
    {
        item.transform.position = transform.position;
        Debug.Log("inv item = " + item.transform.position);
    }
}
