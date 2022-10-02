using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWeapon : MonoBehaviour
{
    [SerializeField] private float weaponDmg;
    [SerializeField] private Transform weaponDirection;
    [SerializeField] private LineRenderer weaponLine;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Start()
    {
        float t = 0; //den h�r funkade inte som t�nkt
    }
    public void ShootWeapon()
    {
        
        float t =+ Time.deltaTime;
        float lineTime = 5;
        if (t == 5)
        {
            t = 0;
        }
        //den h�r funkade inte som t�nkt

        RaycastHit result;
        bool thereWasHit = Physics.Raycast(weaponDirection.position, transform.forward, out result, Mathf.Infinity);

        weaponLine.SetPosition(0, weaponDirection.position);
        if (t < lineTime) //den h�r funkade inte som t�nkt
        {
            weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 5); //den h�r funkade inte som t�nkt
        }

        if (thereWasHit)
        {
            SHealth activePlayerHP = result.collider.GetComponent<SHealth>();
            if (activePlayerHP != null) //om hp p� det raycast kolliderar med inte �r null kommer nedst�ende ske.
            {
                activePlayerHP.TakeDmg(weaponDmg);
            }
            weaponLine.SetPosition(1, result.point);
            if (t > lineTime) //den h�r funkade inte som t�nkt
            {
                weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 5); //den h�r funkade inte som t�nkt
            }
        }
        else
        {

            weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 50);
            if (t < lineTime) //den h�r funkade inte som t�nkt
            {
                weaponLine.SetPosition(1, weaponDirection.position + transform.forward * 5); //den h�r funkade inte som t�nkt
            }
        }
        
        

    }

    void Update() //THIS IS FOR PROJECTILE
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.transform.position = shootingStartPosition.position;
            newProjectile.GetComponent<SProjectile>().Initialize();
        }

        
    }
}
