using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int teamCount;
    private int playerCount;
    private int[] activePlayer;
    private int activeTeam;
    private int[] playersAlive;
    private List<bool> teamAlive;
    private Color[] teamColors;
    [HideInInspector] public List<Player> players = new List<Player>();

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

    public void SetData(int teamCount, int playerCount, List<Player> players, Color[] teamColors)
    {
        this.teamCount = teamCount;
        this.playerCount = playerCount;
        this.players = players;
        this.teamColors = teamColors;
        activePlayer = new int[teamCount];


        for (int i = 0; i < activePlayer.Length; i++)
        {
            activePlayer[i] = 0;
        }


        playersAlive = new int[teamCount];
        teamAlive = new List<bool>();

        for (int i = 0; i < playersAlive.Length; i++)
        {
            playersAlive[i] = playerCount;
            teamAlive.Add(true);
        }

    }

    private void CheckForWinner()
    {
        if (teamAlive.FindAll(x => x == true).Count == 1)
        {
            SceneManagement.instance.LoadWinScene(teamAlive.FindIndex(x => x == true), teamColors[activeTeam]);
        }
    }

    public void NextPlayer()
    {
        players[activePlayer[activeTeam]].Deactivate();

        while (!teamAlive[activeTeam])
        {
            activeTeam++;
        }

        if (activePlayer[activeTeam] < playersAlive[activeTeam] - 1)
        {
            activePlayer[activeTeam]++;
        }
        else
        {
            activePlayer[activeTeam] = 0;
        }

        if (activeTeam < teamCount - 1)
        {
            activeTeam++;
            while (playersAlive[activeTeam] == 0)
            {
                teamAlive[activeTeam] = false;
                activeTeam++;
            }
        }
        else
        {
            activeTeam = 0;
        }

        foreach (Player player in players)
        {
            if (player.teamId == activeTeam && player.id == activePlayer[activeTeam])
            {
                player.Activate();
            }
            else
            {
                player.Deactivate();
            }
        }
    }



    public void PlayerDeath(int teamId, int id)
    {
        Player deadPlayer = players.Find(x => x.teamId == teamId && x.id == id);

        if (!deadPlayer.Equals(null))
        {
            playersAlive[teamId]--;
            Destroy(deadPlayer.playerObject);
            players.Remove(deadPlayer);

            if (playersAlive[teamId] == 0)
            {
                teamAlive[teamId] = false;
            }
        }
        CheckForWinner();
    }

    public void DeactivateCurrentPlayer()
    {
        players[activePlayer[activeTeam]].Deactivate();
    }

    public void ActivateCurrentPlayer()
    {
        players[activePlayer[activeTeam]].Activate();
    }
}