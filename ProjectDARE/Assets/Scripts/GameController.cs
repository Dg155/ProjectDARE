using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{

    EnemySpawner enemySpawner;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject EndScreen;
    private int amount_of_enemies = 0;
    private bool abilityChosen;

    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu.SetActive(false);
        EndScreen.SetActive(false);
        enemySpawner = GetComponent<EnemySpawner>();
        abilityChosen = false;
        StartGame();
    }

    async void StartGame()
    {
        await enemySpawner.SpawnEnemy(7f, 10, 2f, 3f);
        while (amount_of_enemies != 0) {await Task.Yield();}
        upgradeMenu.SetActive(true);
        while (!abilityChosen) {await Task.Yield();}
        abilityChosen = false;
        upgradeMenu.SetActive(false);
    }

    public void addToEnemies(int i){
        amount_of_enemies += i;
    }

    public void buttonPressed(){
        abilityChosen = true;
    }
}
