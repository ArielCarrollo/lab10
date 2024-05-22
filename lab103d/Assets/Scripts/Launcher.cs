using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float maxLaunchForce = 20f;
    [SerializeField] private Transform launchPoint;

    [SerializeField] private GameObject point;
    private GameObject[] pointsList;
    [SerializeField] private int pointsCount = 20;
    [SerializeField] private float spaceBetween = 0.1f;

    [SerializeField] private int Munición = 5;
    [SerializeField] public int Enemysleft = 5;

    private Vector3 direction;
    private float launchForce;

    private void Start()
    {
        pointsList = new GameObject[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            pointsList[i] = Instantiate(point, launchPoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(launchPoint.position).z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 launchPosition = launchPoint.position;

        direction = (worldMousePosition - launchPosition).normalized;
        float distance = Vector3.Distance(launchPosition, worldMousePosition);

        launchForce = Mathf.Clamp(distance, 0, maxLaunchForce);

        transform.forward = direction;

        for (int i = 0; i < pointsCount; i++)
        {
            pointsList[i].transform.position = CurrentPosition(i * spaceBetween);
        }
        if (Enemysleft <= 0)
        {
            SceneManager.LoadScene("ganaste");
        }
    }

    private void Shoot()
    {
        if (Munición <= 0)
        {
            SceneManager.LoadScene("pirdiste");
        }
        else
        {
            GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = direction * launchForce;
            Munición--;
        }
    }

    private Vector3 CurrentPosition(float t)
    {
        Vector3 gravity = Physics.gravity;
        return launchPoint.position + (direction * launchForce * t) + (0.5f * gravity * t * t);
    }
    public void Shoots(InputAction.CallbackContext context)
    {
        if (context.performed) { 
        Shoot(); }
    }
}
