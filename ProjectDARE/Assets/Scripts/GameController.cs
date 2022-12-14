using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class GameController : MonoBehaviour
{

    EnemySpawner enemySpawner;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private TextMeshProUGUI roundText;
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
        // Clear Enemies
        foreach (EnemyAI enemy in FindObjectsOfType<EnemyAI>()){
            Destroy(enemy.gameObject);
        }

        // Wave 1
        await enemySpawner.SpawnEnemy(7f, 3, 2f, 3f);
        while (amount_of_enemies > 0) {await Task.Yield();}
        roundText.text = "Round 1 Complete! Choose upgrade for Round 2:";
        upgradeMenu.SetActive(true);
        while (!abilityChosen) {await Task.Yield();}
        abilityChosen = false;
        upgradeMenu.SetActive(false);

        // Wave 2
        await enemySpawner.SpawnEnemy(8f, 5, 1.5f, 2f);
        while (amount_of_enemies > 0) {await Task.Yield();}
        roundText.text = "Round 2 Complete! Choose upgrade for Final Round:";
        upgradeMenu.SetActive(true);
        while (!abilityChosen) {await Task.Yield();}
        abilityChosen = false;
        upgradeMenu.SetActive(false);

        // Final Wave
        await enemySpawner.SpawnEnemy(9f, 10, 1f, 1.5f);
        while (amount_of_enemies > 0) {await Task.Yield();}
        GetComponent<SceneLoader>().LoadNextScene();
    }

    public void addToEnemies(int i){
        amount_of_enemies += i;
        Debug.Log(amount_of_enemies);
    }

    public void buttonPressed(){
        abilityChosen = true;
    }
}
