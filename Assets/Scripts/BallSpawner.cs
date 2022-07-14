using System.Collections.Generic;
using System.Threading.Tasks;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] List<GameObject> _balls;

    private int _ballCount = 20; 

    private void Start()
    {
        EventManager.RaiseBallsInLevelEvent(_ballCount);
        SpawnBalls();
    }

    private async void SpawnBalls()
    {
        for (int i = 0; i < _ballCount; i++)
        {
            var ballIndex = Random.Range(0, _balls.Count);
            var ball = ObjectPooler.Instance.SpawnFromPool(_balls[ballIndex].name, _spawnPoint.position, _spawnPoint.rotation);
            await Task.Delay(2);
        }
    }
}
