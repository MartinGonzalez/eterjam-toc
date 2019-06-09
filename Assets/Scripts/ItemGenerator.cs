using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject objectDefault;

    public void GenerateItems(List<ItemEditor> itemEditors) {
        for (int i = 0; i < itemEditors.Count; i++)
        {
            var items = itemEditors[i];
            List<Coordinates> coordenadasPrefab = items.ResetCoordinates();
            Item newItem = Instantiate(objectDefault, Vector3.zero, Quaternion.identity).GetComponent<Item>();

            newItem.name = "Item " + i;
            newItem.PrepareItem(coordenadasPrefab);
        }
    }
}
