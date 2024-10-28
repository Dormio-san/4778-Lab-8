using LitJson;
using System.Collections.Generic;
using UnityEngine;

public class Player :SaveableBehaviour, ISubject 
{
    private List<IObserver> observers = new List<IObserver>();
    public PlayerScore playerScore { get; private set; }
    public PlayerHealth playerHealth { get; private set; }
    private IObserver gameOverObserver;
    [SerializeField]
    private TransformSave transformSave;

    void Awake()
    {
       
        transformSave = transformSave.GetComponent<TransformSave>(); // Ensure this component is attached
    }

    // Constructor to initialize the player's score and health.
    public Player()
    {
        playerScore = new PlayerScore();
        playerHealth = new PlayerHealth();
    }

    // Attach (add) an observer to the list of observers.
    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    // Detach (remove) an observer from the list of observers.
    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        // Notify all observers and let them do their logic that depends on the player's state.
        foreach (IObserver observer in observers)
        {
            // If the observer is the GameManager, exit.
            if (observer is GameOverUI)
            {
                gameOverObserver = observer;
                Detach(observer);
                return;
            }
            observer.OnNotify();
        }
    }

    // Change the player's score and notify the observers.
    public void ChangeScore(int scoreChange)
    {
        playerScore.ChangeScore(scoreChange);
        Notify();
    }

    // Change the player's health and notify the observers.
    public void ChangeHealth(int healthChange)
    {
        playerHealth.ChangeHealth(healthChange);
        Notify();

        // If the health is at or below 0, notify the game over observer, which ends the game.
        if (playerHealth.Health <= 0)
        {
            gameOverObserver.OnNotify();
        }
    }

    // Used when game begins to reset the score and health to 0 and 3, respectively.
    public void BeginGameReset()
    {
        playerScore.ResetScore();
        playerHealth.ResetHealth();
        Notify();
    }

  //  public override string SaveID => transformSave.SaveID;

    public override JsonData SavedData
    {
        get
        {
            OnBeforeSerialize();
            // Use TransformSave to get saved data
            return transformSave.SavedData;
        }
    }

    // public override string SaveID { get => transformSave.SaveID; set => transformSave.SaveID = value; }
    public override string SaveID
    {
        get => transformSave.SaveID;
        set => transformSave.SaveID = value;
    }

    // Implementing LoadFromData from ISaveable
    public override void LoadFromData(JsonData data)
    {
        
        transformSave.LoadFromData(data);
    }
    
}
