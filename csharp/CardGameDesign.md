# TODO List
## Core concepts
- SuperDeck
- Deck
- Cards
- Suit
- Rank
- Shuffle
- Player
- Hand
- Game Rules
- Computer AI

## Testing we can start from
- A deck contains 52 unique cards
- Shuffle changes the order of the deck
- Drawing a card removes it from deck

## Delivery Pipeline

### Every push
- Restore packages
- Build
- Run Tests
- Fail if Tests fail

### Deployment (Less often)

**Code coverage**  
Try to ensure that undetected defects dont exist through coverage in testing.  
Things like:
- shuffling
- cards not missing
- cards becoming inactive when theyre supposed to
- AI works as expected

**Static Analysis**  
Looks for issues such as:
- possible nulls
- inefficient code
- hard to see logic defects

# Domain Notes

We dont know what the rules are and this has to work for any card game that we make.  
Some card games like BlackJack require more than 1 Deck so thats why theres something called **SuperDeck**.

- A SuperDeck contains all of the Decks.
- A Deck is your standard deck of cards containing the 4 suits from 2 to 10 and A, K, Q, J. It holds the cards that can be drawn.
- There are 4 suits in a Deck.
- There are 13 cards in a suit.
- Rank orders the cards.
- Shuffle is the process of ordering a Deck. If more than 1 Deck then all of the Decks are shuffled.
- Player contains info of the player like wins or money. It doesnt differentiate between a person and an AI.
- Hand is what a player is currently holding.
- Game Rules is the logic that defines the rules of the game. In theory this can be extended so that multiple Rules can be defined for different games.
- Computer AI is the difficulty of a computer player, and the logic/strategy used for each difficulty.

# Project Overview

    /src
	  /Core - this knows nothing of what game we are playing
	    /SuperDeck
	    /Deck
	    /Suit
	    /Cards
	    /Rank
	    /Hand
	    /DrawRules
	    /SuffleRules
	  /Application - this uses the Core, knows what game we are playing, and enforces the rules.
	    /StartGame
	    /DealCards
	    /Shuffle
	    /ManageTurns
	    /ManagePoints
	    /DetermineWinner/Losers
	    /EnforceRule
	  /ComputerAi - this could have a lot of changes in it so its best to remove it from Application so it doesnt break game logic
	    /Difficulties
	    /ImplementingLogic - logic behind each difficulty 
	    /simulations - for enhanced difficulties where an AI can run some simulations on probabilities
	  /ConsoleUI
	    /Output
	  /Infrastructure
	    /Databases
	    /Save/Load
	    /Networking
	  /Testing	
        /DomainTesting
	    /ApplicationTesting

# Some testing to start

- Ensure a deck has 52 cards
- Ensures each card in a deck is unique
- Ensures that drawing a card removes it from deck
- Ensures that playing a card removes it from a hand
- Ensure that dealing cards follow the rules (e.g. each player gets the right number of cards)