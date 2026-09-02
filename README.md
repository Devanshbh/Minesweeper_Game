# Minesweeper

This README is based on the original **Minesweeper User Manual** included with the project. I kept the same idea as the manual: explain what the game is, how to start, the controls, some strategies, and what to do if something looks wrong.

[Open the original Minesweeper User Manual](<Minesweeper User Manual.pdf>)

## History of the game

Minesweeper was developed by Curt Johnson and Robert Donner around 1990 and became well known after being included with Microsoft software. The basic idea has stayed the same ever since: use the numbered squares to figure out where the mines are without clicking one yourself.

## Objective of Minesweeper

There is really only one main objective: **clear every square that does not contain a mine**.

You can right-click squares that you believe contain mines to place flags. Once every safe square has been revealed, the game is won. The timer keeps track of how long the game takes, so after you understand the board, the next challenge is trying to finish faster.

## How to start

When the game opens, the start menu lets you choose a difficulty level. If you do not select one, **Intermediate** is used automatically.

| Difficulty | Grid | Mines |
| --- | ---: | ---: |
| Beginner | 8 x 8 | 10 |
| Intermediate | 16 x 16 | 40 |
| Expert | 24 x 24 | 80 |

Once you have selected the difficulty, press **Start Game**. The mines are placed in random locations each time a new game starts.

If you reveal a mine, you lose. If you reveal every safe square, you win.

## Key controls

Minesweeper only needs the mouse.

### Left click

Left-click a covered square to reveal it.

- If the square is safe, it displays the number of mines in the surrounding squares.
- If the square is empty, nearby empty cells can open automatically.
- If the square contains a mine, the game ends and the mines are revealed.

### Right click

Right-click a covered square to place a flag where you think a mine is located. Right-click it again to remove the flag.

Flags are mainly there to help you keep track of the board and avoid clicking a square you already believe is dangerous.

## Score system

The game keeps track of the amount of time that has passed during the round. When the game ends, your final time is shown.

The goal is simple: once you can win consistently, try to finish in the shortest time possible.

## Strategies to win

### Recognize common patterns

Certain number patterns show up often and can make the next move easier to identify.

- **1-2-1 pattern:** the mines are commonly located under the two outer `1`s when the surrounding covered cells line up with the pattern.
- **Adjacent 1s:** if two `1`s share the same possible mine location, you can often use the nearby revealed squares to narrow the options down.

The exact board around the pattern still matters, so use the numbers together rather than treating a pattern as an automatic answer.

### Start from areas with fewer possibilities

Corners and edges have fewer surrounding squares, which can sometimes make the board easier to reason through.

### Work from known information

Whenever you know for sure where a mine is, flag it and use that information to solve the squares around it. Expanding from confirmed information is much safer than randomly guessing across the board.

## Troubleshooting

### The flag counter went negative

This means more spaces were flagged than the number of mines on the board. The game can still continue, but at least one flag is in the wrong place. Unflag squares and use the revealed numbers to check them again.

### The game will not end

Every safe square must be revealed before the win condition is reached. If the board looks complete but the game has not ended, check the remaining flagged squares. A safe square may have been flagged by mistake.

### The game will not reset the way I expected

After losing, the game opens the closing screen and shows the final time. From there, start a new game and return to the difficulty selection when needed.

After winning, the game asks whether you want to replay at the same difficulty or return to the start menu.

## Running the project

This is a **C# Windows Forms** project targeting **.NET Framework 4.7.2**.

1. Open [`Minesweeper_Devansh_Johnathan_Jason.sln`](<Minesweeper_Devansh/Minesweeper_Devansh_Johnathan_Jason.sln>) in Visual Studio on Windows.
2. Make sure the .NET Framework 4.7.2 targeting pack is available.
3. Build the solution and run it.

The game also uses Windows Media Player components for its sound and music, so the Windows Media Player COM libraries need to be available when rebuilding the project.

## Main features

- Three difficulty levels
- Random mine placement
- Automatic adjacent-mine counting
- Recursive opening of empty areas
- Left-click reveal and right-click flags
- Flag counter
- Game timer
- Win/loss screens
- Music and sound effects
