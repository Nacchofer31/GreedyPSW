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
        if(isFocus && Input.GetKeyDown(KeyCode.Space))
        {
            float distance = Vector3.Distance(Entity.position, InteractionTransform.position);
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
        Gizmos.DrawWireSphere(InteractionTransform.position, radius);
    }

}
