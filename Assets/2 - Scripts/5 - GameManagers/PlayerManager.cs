using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;


    [Header("References")]
    [SerializeField] private GameObject playerPrefab;

    private List<Transform> spawnPoints = new List<Transform>();




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void initPlayers(int teamCount, int playerCount)
    {
        spawnPoints = new List<Transform>();

        foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            spawnPoints.Add(spawnPoint.transform);
        }

        List<Player> players = new List<Player>();
        Color[] teamColors = new Color[teamCount];

        int spawnPointsIndex = Random.Range(0, spawnPoints.Count - 1);

        for (int team = 0; team < teamCount; team++)
        {
            teamColors[team] = Random.ColorHSV();
            for (int i = 0; i < playerCount; i++)
            {
                GameObject playerObject = Instantiate(playerPrefab, spawnPoints[spawnPointsIndex].position + (Vector3.left * 2 * i), Quaternion.identity);
                playerObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = teamColors[team];


                Player player = PlayerValues(playerObject, team, i, teamColors[team]);

                player.Deactivate();

                players.Add(player);
            }

            spawnPointsIndex++;
            if (spawnPointsIndex >= spawnPoints.Count)
            {
                spawnPointsIndex = 0;
            }
        }

        GameManager.instance.SetData(teamCount, playerCount, players, teamColors);

        players[0].Activate();
    }

    private Player PlayerValues(GameObject playerObject, int teamId, int id, Color teamColor)
    {

        GameObject playerObjectChild = playerObject.transform.GetChild(0).gameObject;

        playerObjectChild.GetComponent<CharacterController>().playerId = id;
        playerObjectChild.GetComponent<CharacterController>().teamId = teamId;

        Player player = new Player();

        player.playerObject = playerObject;

        player.id = id;
        player.teamId = teamId;

        player.movement = playerObjectChild.GetComponent<CharacterMovement>();
        player.thirdPersonCamera = playerObjectChild.GetComponent<ThirdPersonCamera>();
        player.basicCam = playerObjectChild.GetComponent<ThirdPersonCamera>().basicCam;
        player.combatCam = playerObjectChild.GetComponent<ThirdPersonCamera>().combatCam;
        player.weaponController = playerObjectChild.GetComponent<WeaponController>();

        return player;
    }

    public void RemovePlayer()
    {

    }
}
public class Player
{
    public GameObject playerObject;
    public int teamId;
    public int id;
    public WeaponController weaponController;
    public CharacterMovement movement;
    public ThirdPersonCamera thirdPersonCamera;
    public GameObject basicCam;
    public GameObject combatCam;

    public void Deactivate()
    {
        movement.enabled = false;
        thirdPersonCamera.enabled = false;
        weaponController.enabled = false;
        weaponController.isActive = false;
        basicCam.SetActive(false);
        combatCam.SetActive(false);
    }

    public void Activate()
    {
        weaponController.Reset();
        movement.enabled = true;
        thirdPersonCamera.enabled = true;
        weaponController.enabled = true;
        weaponController.isActive = true;
        basicCam.SetActive(true);
    }

    private Color GenerateColor()
    {
        // return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        return new Color(1, 0, 0);
    }
}