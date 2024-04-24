using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private GameObject enemyPrefab;
    private const float spawnRange = 9f;
    [NonSerialized] public int enemiesRemaining;
    private int currentWave = 1;

    void Start()
    {
        SpawnEnemyWave(currentWave);
    }

    void Spawn(GameObject objectPrefab)
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        
        GameObject spawnedObject = Instantiate(objectPrefab, randomPos, objectPrefab.transform.rotation);
        if (objectPrefab.CompareTag("Enemy"))
        {
            spawnedObject.GetComponent<Enemy>().spawnManager = this;
            enemiesRemaining++;
        }
    }

    void SpawnEnemyWave(int amountOfEnemiesToSpawn)
    {
        for (int i = 0; i < amountOfEnemiesToSpawn; i++)
        {
            Spawn(enemyPrefab);
        }
        Spawn(powerupPrefab);
    }

    public void EnemyFallen()
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0)
        {
            currentWave++;
            SpawnEnemyWave(currentWave);
            enemiesRemaining = currentWave;
        }
    }
}


/*
 Respeusta a "first":
    Explicarles que nosotros somos parte de un area enfocada a impulsar el desarrollo profesional 
    de los alumnos
Respuesta a "Secnod"
    Establecer un esquema de sesión de derechos donde los alumnos estan de acuerdo en que nosotros
        distribuyamos el contenido. Este servicio de gestión de parte de la universidad es gratuito 
        para los alumnos. La razón por la que la universidad haría esta gestión, y no el alumon 
        directamente, es porque queremos guiarlos en su primer publicación, y porque la universidad
        está absorbiendo el gasto de la publicación. Además, muchos de los estudiantes no cuentan 
        con los recursos económicos para invertir en sus proyectos. El departamento de progrmación, arte y gamedesign  apoya a los alumnos para que lleven a cabo su proyecto. Además, cada juego de cada estudiante contaría con su sección de créditos para reconocer la labor de cada persona que haya participado en cada proeycto.
Respuesta a "finally"
    Los alumnos no manejarán la cuenta de Steam para administrar el contenido. Se les enseñará cómo se hace
    y se les dará visibilidad a sus proyectos si lo desean. Si no, se les enseñará cómo hacer las publicaciones por su cuenta.
    Esta decisión la toma el alumno, pero nosotros les ofrecemos la posibilidad de  facilitar este proceso.
    El objetivo con esto es que los alumnos puedan aprender a cómo desarrollar un juego para publicarlo.

*/
