using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public Enemy[] m_listOfEnemiesPrefab;
    public float spawnFrequencyInSecond;


	// Use this for initialization
	void Start () {
        m_transform = GetComponent<Transform>();
        CreatePool();
	}
	
	// Update is called once per frame
	void Update () {

        switch( GameManager.currentState )
        {
            case GameManager.STATE.PLAYING:
                spawnFrequencyPerSecond = 1 / spawnFrequencyInSecond;
                Debug.Log( "Go" );
                if( Random.value < spawnFrequencyPerSecond * Time.deltaTime )
                {
                    
                    Enemy enemyTypeToSpawn = m_listOfEnemiesPrefab[0];
                    Enemy enemy = SpawnAvailableInstance(enemyTypeToSpawn);
                    Vector3 spawnPosition = new Vector3(Random.Range(-5,5),-1,5);
                    enemy.LaunchAt( spawnPosition );
                }    
                break;
            case GameManager.STATE.GAME:
                break;
            case GameManager.STATE.PAUSE:
                break;
            case GameManager.STATE.END:
                break;
            default:
                break;
        }
    }

    private void CreatePool()
    {
        foreach( Enemy prefab in m_listOfEnemiesPrefab )
        {
            for( int i = 0; i < 30; i++ )
            {
                Enemy instance = CreateInstance(prefab);
            }
        }
        
    }

    private Enemy SpawnAvailableInstance(Enemy enemyToSpawn)
    {
        foreach(Transform enemy in m_transform )
        {
            if( enemy.GetComponent<Enemy>().m_isActive ==false )
            {
                return enemy.GetComponent<Enemy>();
            }
        }
        return CreateInstance(enemyToSpawn);
    }

    private Enemy CreateInstance(Enemy prefab)
    {
        Enemy instance = Instantiate(prefab,Vector3.zero,Quaternion.identity) as Enemy;
        instance.transform.SetParent( m_transform );
        
        return instance;
    }
    private Transform m_transform;
    private float spawnFrequencyPerSecond;
}
