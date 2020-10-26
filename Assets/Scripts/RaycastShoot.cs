using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public float fireRate = .25f; // Sets firetime of weapon
    public float weaponRange = 50f; //range of raycast max
    private Camera headCam;

    public Transform gunEnd;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.7f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire; //after firing - how long to the next shot






    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Trigger") && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = headCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);
            
            if (Physics.Raycast(rayOrigin,headCam.transform.forward,out hit, weaponRange))
            {

                laserLine.SetPosition(1, hit.point);

            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (headCam.transform.forward * weaponRange));
            }


        }













    }
    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
            


    }



}



