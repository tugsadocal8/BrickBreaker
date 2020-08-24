using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemController : MonoBehaviour
{
    public BoxCollider2D itemCollider;
    public GameObject itemObject;
    public BoxCollider2D itemPlayerCollider;
    public Vector2 velocityItem;
    public float radius = 0.155764f;
    public const int deadZoneLayer = 9;
    public const int playerLayer = 11;
    public BallControl ballControl;
    public itemEnum itemType;
    Vector3 vc;
    RaycastHit2D hit;


    void Start()
    {

        itemCollider = itemCollider.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        int mask1 = 1 << LayerMask.NameToLayer("DeadZone");
        int mask2 = 1 << LayerMask.NameToLayer("player");
        int layerMask = mask1 | mask2;
        //LayerMask mask = LayerMask.GetMask("player") | LayerMask.GetMask("DeadZone");
        hit = Physics2D.Raycast(itemCollider.transform.position, itemCollider.transform.forward, Mathf.Infinity, layerMask);

        vc = new Vector3(0, -5);
        itemCollider.transform.position += vc * Time.deltaTime;

        if (itemCollider.transform.position.y == -6.0f)
        {
            Destroy(itemObject);
        }

        if (hit.collider != null)
        {

            if (hit.collider.gameObject.layer == deadZoneLayer)
            {
                Destroy(itemObject);
            }
            if (hit.collider.gameObject.layer == playerLayer)
            {
                Destroy(itemObject);
                hit.collider.gameObject.GetComponent<PlayerControls>().SetItem(itemType);
            }
        }

    }

    public void SetItemType(itemEnum itemType)
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

        this.itemType = itemType;
        switch (itemType)
        {
            case itemEnum.ScaleUp:
                renderer.color = Color.yellow;
                break;

            case itemEnum.ScaleDown:
                break;

            case itemEnum.MultiBall:
                renderer.color = Color.blue;
                break;

            default:                
                break;
        }
    }
}
