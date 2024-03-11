using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MovingTargetScript : MonoBehaviour
{
    [SerializeField] private Vector3 point1;
    [SerializeField] private Vector3 point2;
    [SerializeField] private float speed;
    private float deltaTime;
    private bool canBeHit = true;

    private TargetScript targetScript;
    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        targetScript = GetComponentInChildren<TargetScript>();
    }

    private async void Update()
    {
        if (targetScript.isHit && canBeHit)
        {
            canBeHit = false;
            gameController.ShotATarget();
            await Timer();
        }
        deltaTime += Time.deltaTime;
        MoveTowards(point1, point2, deltaTime, speed);
    }
    private void MoveTowards(Vector3 point1, Vector3 point2, float time, float speed)
    {
        float interpolationValue = Mathf.PingPong(time * speed, 1);
        transform.position = Vector3.Lerp(point1, point2, interpolationValue);
    }

    private async Task Timer()
    {
        await Task.Delay(5000);
        canBeHit = true;
    }
}
