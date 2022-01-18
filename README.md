# Scrabble

This project is my vision of the popular board game called "Scrabble".

This game was written in C# language using .NET repository. Code contains 7 classes, 2 windows Forms, and source files (dictionary, background pictures, button etc.)

The game starts with a menu window where players can choose their names:

![image](https://user-images.githubusercontent.com/89656360/149998343-af42569a-e06a-4095-8792-bb3f20629a7e.png)

After inserting names and pressing "Zaczynamy!" button, this window will be closed and a new window will pop up:

![image](https://user-images.githubusercontent.com/89656360/149998479-ec9e7054-5606-42be-9fba-8dd0c621668b.png)

On the center of the window are 7 different types of tiles.
White - do nothing Yellow - double the points for yellow letters ("a", "e", "i", "n", "o", "r", "s", "w", "z")

Green - double the points for green letters ("c", "d", "k", "l", "m", "p", "t", "y")

Blue - double the points for blue letters ("b", "g", "h", "j", "ł", "u")

Red - double the points for red letters ("ą", "ć", "ę", "f", "ń", "ó", "ś", "ż", "ź"), mostly polish letters

x2 - double the points for new word

x3 - triple the points for new word


In the right upper corner there is SCORE BOARD:

![image](https://user-images.githubusercontent.com/89656360/149999117-bde16730-fb8c-4475-ad91-01c2790e57f3.png)

On the middle right side is EVENTLOG:

![image](https://user-images.githubusercontent.com/89656360/149999317-e3dba1ec-1a29-444c-ae58-9e2ac7719aea.png)

EVENTLOG stored up to 13 newest events (points for the new word, how many letters did you replace, if you passed or if you created the word that is not included in the dictionary).

Below the board, there is the rack that stores the player's rack.

There is no drag and drop; players put the letters on board by clicking the letter on the rack and then clicking the desired tile on board.

On the right side of the player rack, there are 3 buttons.

A player can accept the word by pressing "Zaakceptuj" button. If the player made a mistake, the player can press "Reset" button. If the player wants to replace letters on the rack, there is "Wymiana" button. After pressing "Wymiana" button, the player can press up to 7 letters (full rack).

The game is ended when in the letters pool will remain 4 or fewer letters.

![image](https://user-images.githubusercontent.com/89656360/150002053-5b7ef3ab-ff48-4a65-9e83-3e9e22583c9e.png)
