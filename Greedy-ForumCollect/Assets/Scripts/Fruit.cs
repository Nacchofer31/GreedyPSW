using UnityEngine;

public class Fruit : Interactable
{
    public GameObject effect;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up item");
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
