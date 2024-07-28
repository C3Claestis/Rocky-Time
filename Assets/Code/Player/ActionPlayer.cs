using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    [SerializeField] Transform grabHolder;
    [SerializeField] Transform grabRaycast;
    [SerializeField] float rayDist;
    private float throwForce;
    private GameObject grabbedObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GrabAction();
        throwForce = Player.Instance.GetDirX();
    }

    void GrabAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(grabRaycast.position, Vector2.right * transform.localScale.x, rayDist);

            if (raycastHit2D.collider != null && raycastHit2D.collider.tag == "Environment")
            {
                grabbedObject = raycastHit2D.collider.gameObject;
                grabbedObject.transform.parent = grabHolder;
                grabbedObject.transform.position = grabHolder.position;
                Destroy(grabbedObject.GetComponent<Rigidbody2D>());
            }
        }
        else if (Input.GetMouseButtonUp(0) && grabbedObject != null)
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        grabbedObject.transform.parent = null;
        Rigidbody2D rb = grabbedObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;

        float playerSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
        Vector2 throwDirection = new Vector2(transform.localScale.x, 0.5f).normalized;

        rb.AddForce(throwDirection * throwForce * (1 + playerSpeed), ForceMode2D.Impulse);
        grabbedObject = null;
    }
    void OnDrawGizmos()
    {
        if (grabRaycast != null)
        {
            Gizmos.color = Color.red;
            Vector3 direction = Vector2.right * transform.localScale.x;
            Gizmos.DrawLine(grabRaycast.position, grabRaycast.position + direction * rayDist);
        }
    }
}
