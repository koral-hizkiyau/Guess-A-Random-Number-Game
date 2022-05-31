using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour    
{

    public InputField userInput;
    public Text gameLabel;
    public int minValue;
    public int maxValue;
    public Button gameButton;
    private bool isGameWon = false;


    public int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
       

    }

    private void ResetGame(){
         if(isGameWon){
             gameLabel.text = "You won! Guess again a number between " + minValue + " and " +maxValue;
             isGameWon = false;
        }
        else{
             gameLabel.text = "Guess a number between " + minValue + " and " +maxValue;
           }
         userInput.text = "";
         randomNum = GetRandomNumber(minValue,maxValue);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void onButtonClick()
    {
        string userInputValue = userInput.text;
        if (userInputValue != "")
        {
            int answer = int.Parse(userInputValue);


            if (answer == randomNum)
            {
                gameLabel.text = "Correct!";
                isGameWon = true;

             ResetGame();
            }
            else if (answer > randomNum && answer <= (maxValue))
            {
                gameLabel.text = "Try lower than "+answer;


            }
            else if(answer > (maxValue-1))
            {
                gameLabel.text = "Your number higer then "+(maxValue);
            }
            else if(answer < randomNum && answer >= minValue)
            {
              gameLabel.text = "Try higer than "+answer;

            }
            else{
               gameLabel.text = "Your number lower then "+(minValue);

            }
        }
        else
        {
            Debug.Log("Please enter a number!");

        }





    }

    private int GetRandomNumber(int min,int max){
        int random = Random.Range(min,max);

        return random;
    }
}
