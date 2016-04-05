using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trivia;

namespace UglyTrivia
{
    public class Game
    {


        List<PlayerState> playerStates = new List<PlayerState>();
        
        bool[] inPenaltyBox = new bool[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(createRockQuestion(i));
            }
        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {
            var playerState = new PlayerState(playerName);
            playerStates.Add(playerState);
            
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + playerStates.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return playerStates.Count;
        }

        public void roll(int roll)
        {
            Console.WriteLine(playerStates[currentPlayer].Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(playerStates[currentPlayer].Name + " is getting out of the penalty box");
                    playerStates[currentPlayer].Position = playerStates[currentPlayer].Position + roll;
                    if (playerStates[currentPlayer].Position > 11) playerStates[currentPlayer].Position = playerStates[currentPlayer].Position - 12;

                    Console.WriteLine(playerStates[currentPlayer].Name
                            + "'s new location is "
                            + playerStates[currentPlayer].Position);
                    Console.WriteLine("The category is " + currentCategory());
                    askQuestion();
                }
                else
                {
                    Console.WriteLine(playerStates[currentPlayer].Name + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                playerStates[currentPlayer].Position = playerStates[currentPlayer].Position + roll;
                if (playerStates[currentPlayer].Position > 11) playerStates[currentPlayer].Position = playerStates[currentPlayer].Position - 12;

                Console.WriteLine(playerStates[currentPlayer].Name
                        + "'s new location is "
                        + playerStates[currentPlayer].Position);
                Console.WriteLine("The category is " + currentCategory());
                askQuestion();
            }

        }

        private void askQuestion()
        {
            if (currentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (currentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (currentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (currentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }


        private String currentCategory()
        {
            if (playerStates[currentPlayer].Position == 0) return "Pop";
            if (playerStates[currentPlayer].Position == 4) return "Pop";
            if (playerStates[currentPlayer].Position == 8) return "Pop";
            if (playerStates[currentPlayer].Position == 1) return "Science";
            if (playerStates[currentPlayer].Position == 5) return "Science";
            if (playerStates[currentPlayer].Position == 9) return "Science";
            if (playerStates[currentPlayer].Position == 2) return "Sports";
            if (playerStates[currentPlayer].Position == 6) return "Sports";
            if (playerStates[currentPlayer].Position == 10) return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    playerStates[currentPlayer].Purse++;
                    Console.WriteLine(playerStates[currentPlayer].Name
                            + " now has "
                            + playerStates[currentPlayer].Purse
                            + " Gold Coins.");

                    bool winner = didPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == playerStates.Count) currentPlayer = 0;

                    return winner;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == playerStates.Count) currentPlayer = 0;
                    return true;
                }



            }
            else
            {

                Console.WriteLine("Answer was corrent!!!!");
                playerStates[currentPlayer].Purse++;
                Console.WriteLine(playerStates[currentPlayer].Name
                        + " now has "
                        + playerStates[currentPlayer].Purse
                        + " Gold Coins.");

                bool winner = didPlayerWin();
                currentPlayer++;
                if (currentPlayer == playerStates.Count) currentPlayer = 0;

                return winner;
            }
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(playerStates[currentPlayer].Name + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == playerStates.Count) currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(playerStates[currentPlayer].Purse == 6);
        }
    }

}
