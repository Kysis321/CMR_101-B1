using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AssetAlteration : MonoBehaviour
{
    public float amountToRotate; //amount of degrees to rotate on interaction

    public TextMesh HUD;
    public float widthToExpand = 0.5f;
    public float heightToExpand = 0.5f;
    public float depthToExpand = 0.5f;
    public bool ableToBeDestroyed;

    Renderer r;
    Renderer rr;



    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        rr = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }



    /// <summary>
    /// size alterations
    /// </summary>
    public void MakeBig()
    {
        // Transforms the object to expand in all three dimensions on activation
        transform.localScale = new Vector3(transform.localScale.x + widthToExpand, transform.localScale.y + heightToExpand, transform.localScale.z + depthToExpand);

    }

    public void MakeStairBig()
    {
        // Transforms the object to expand in all three dimensions on activation
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + heightToExpand, transform.localScale.z);

    }

    public void MakeStairSmall()
    {
        // Transforms the object to expand in all three dimensions on activation
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.3f, transform.localScale.z);

    }
    public void MakeSmall()
    {

        transform.localScale = new Vector3(transform.localScale.x - 0.3f, transform.localScale.y - 0.3f, transform.localScale.z - 0.3f);

    }

    /// <summary>
    /// Rotation Alterations
    /// </summary>
    /// 
    public void RotateRight()
    {
        transform.Rotate(0.0f, -amountToRotate, 0.0f, Space.Self);
        HUD.text = transform.rotation.ToString();

    }

    public void RotateLeft()
    {
        transform.Rotate(0.0f, amountToRotate, 0.0f, Space.Self);
        HUD.text = transform.rotation.ToString();

    }

    ///<summary>
    ///This will move the object into a direction
    /// </summary>
    public void MoveLeft()
    {
        transform.Translate(UnityEngine.Vector3.left);
        HUD.text = transform.position.ToString();

    }

    public void MoveRight()
    {
        transform.Translate(UnityEngine.Vector3.right);
        HUD.text = transform.position.ToString();
    }


    public void changeYellow()
    {
        r.material.color = Color.yellow;
    }

    public void returnColour()
    {
       
    }

    // Next function acts to desstroy the door if a player doesnt walk up to it

    void DestroyDoor()
    {
        if(ableToBeDestroyed == true)
        {
            Destroy(gameObject);
        }
        
    }






}
    
