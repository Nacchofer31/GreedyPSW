using UnityEngine;

public class Interactable : MonoBehaviour
{
    float radius = 3f;

    public bool isFocus = false;
    Transform Entity;

    public virtual void Interact()
    {

    }

    void Update()
    {
        if(isFocus)
        {
            float distance = Vector3.Distance(Entity.position, transform.position);
            if(distance <= radius)
            {
                Debug.Log("INTERACT");
                Interact();
            }
        }
    }

    public void onFocused(Transform EntityTransform)
    {
        isFocus = true;
        Entity = EntityTransform;
    }

    public void onDefocused()
    {
        isFocus = false;
        Entity = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
