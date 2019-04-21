using UnityEngine;

public class Fruit : Interactable
{
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up item");
        Destroy(gameObject);
    }
}
