using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 0.1f;
    
    Transform Entity;
    
    public bool isFocus = false;
    public Transform InteractionTransform;

    public virtual void Interact()
    {

    }

    void Update()
    {

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
        Gizmos.DrawWireSphere(InteractionTransform.position, radius);
    }

}
