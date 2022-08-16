using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    //test
    InventoryInteractor inventoryInteractor;
    InventoryRepository inventoryRepository;

    private void Start()
    {
        Game.Run();

        inventoryInteractor = Game.GetInteractor<InventoryInteractor>();
        inventoryRepository = Game.GetRepository<InventoryRepository>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            this.inventoryInteractor.SpendBulbs(sender: this, value: 5);
            Debug.Log($"Bulbs spent (5) {this.inventoryRepository.bulb}");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            this.inventoryInteractor.AddBulbs(sender: this, value: 10);
            Debug.Log($"Bulbs added (10) {this.inventoryRepository.bulb}");
        }

    }
}