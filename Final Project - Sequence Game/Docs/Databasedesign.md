## Starting prompt
I want a program for storing Board Data, Card Data, game Data, Player Data, and Team Data.
This should include the following fields:



## Card Data
CardIdentity - A two character string with the first character being the suit 
                (i.g. H = Hearts, S = Spades, C = Clubs, D = Diamonds) the second
                Character meaning the Value of the card 
                (i.g. 2-10 meaning all numbered cards, 
                while A = Ace, J = Jack, Q = Queen, and K = King) - REQUIRED

## Game Data
GameId - A unique identifier for each game - PRIMARY KEY - REQUIRED
GameLength - The length of the game in minutes - REQUIRED
GameWinner - The TeamName of the Team that won the game obtained by following TeamId - REQUIRED
NumberOfPlayers - The total number of players currently in the game - REQUIRED
NumberOfSequences - The total number of sequences completed in the game - REQUIRED
CardsInDeck - A list of cards found in the deck at the start of the game obtained using CardIdentity with a maximum of 104 Cards - REQUIRED
CardsDiscarded - A list of cards that have been discarded during the game obtained using CardIdentity - REQUIRED
CardsPerPlayer - The number of cards dealt to each player at the start of the game - REQUIRED

NumberOfTeams - The total number of teams in the game - REQUIRED
Team1Id - The unique identifier for Team 1 - FOREIGN KEY - REQUIRED
Team2Id - The unique identifier for Team 2 - FOREIGN KEY - REQUIRED
Team3Id - The unique identifier for Team 3 - FOREIGN KEY - OPTIONAL

Player1Id - The unique identifier for Player 1 - FOREIGN KEY - REQUIRED
CardsInPlayer1Hand - A list of cards currently in Player 1's hand obtained using CardIdentity - FOREIGN KEY - REQUIRED

Player2Id - The unique identifier for Player 2 - FOREIGN KEY - REQUIRED
CardsInPlayer2Hand - A list of cards currently in Player 2's hand - REQUIRED

Player3Id - The unique identifier for Player 3 - FOREIGN KEY - OPTIONAL
CardsInPlayer3Hand - A list of cards currently in Player 3's hand - OPTIONAL

Player4Id - The unique identifier for Player 4 - FOREIGN KEY - OPTIONAL
CardsInPlayer4Hand - A list of cards currently in Player 4's hand - OPTIONAL

Player5Id - The unique identifier for Player 5 - FOREIGN KEY - OPTIONAL
CardsInPlayer5Hand - A list of cards currently in Player 5's hand - OPTIONAL

Player6Id - The unique identifier for Player 6 - FOREIGN KEY - OPTIONAL
CardsInPlayer6Hand - A list of cards currently in Player 6's hand - OPTIONAL

Player7Id - The unique identifier for Player 7 - FOREIGN KEY - OPTIONAL
CardsInPlayer7Hand - A list of cards currently in Player 7's hand - OPTIONAL

Player8Id - The unique identifier for Player 8 - FOREIGN KEY - OPTIONAL
CardsInPlayer8Hand - A list of cards currently in Player 8's hand - OPTIONAL

Player9Id - The unique identifier for Player 9 - FOREIGN KEY - OPTIONAL
CardsInPlayer9Hand - A list of cards currently in Player 9's hand - OPTIONAL

Player10Id - The unique identifier for Player 10 - FOREIGN KEY - OPTIONAL
CardsInPlayer10Hand - A list of cards currently in Player 10's hand - OPTIONAL

Player11Id - The unique identifier for Player 11 - FOREIGN KEY - OPTIONAL
CardsInPlayer11Hand - A list of cards currently in Player 11's hand - OPTIONAL

Player12Id - The unique identifier for Player 12 - FOREIGN KEY - OPTIONAL
CardsInPlayer12Hand - A list of cards currently in Player 12's hand - OPTIONAL


## Player Data
PlayerId - A unique identifier for each player - PRIMARY KEY - REQUIRED
Username - The player's chosen username - UNIQUE - REQUIRED

## Team Data
TeamId - A unique identifier for each team - PRIMARY KEY - REQUIRED
TeamName - The name of the team - UNIQUE - REQUIRED
PlayerUsernames - A list of unique identifiers for each
                    player in the team obtained by following
                    the foreign key PlayerId but the list can
                    be null - FOREIGN KEY - OPTIONAL
