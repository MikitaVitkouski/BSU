Your task is to write a program simulating the UEFA Champions League group stage. The group stage involves N teams divided into groups of M teams each.
The teams play against each other in their respective groups, earning points based on the results: 3 points for a win, 2 points for a draw, and 1 point for a loss.
Each team in a group plays K matches. The total number of matches for all groups is Count.

Input files:

1) Game.txt:
Format: Each line contains the letter representing a group and the names of teams in that group, separated by spaces.
Example (Each result on the new line):

Atletico_M 1:0 Juventus
Atletico_M 2:0 Olympiacos
Atletico_M 3:0 Malmo
Atletico_M 1:0 Juventus
Atletico_M 2:0 Olympiacos
Atletico_M 3:0 Malmo
Malmo 2:1 Olympiacos
Malmo 0:3 Juventus
Juventus 1:1 Olympiacos
Juventus 2:2 Malmo
Real_Madrid 1:1 Basel
Real_Madrid 3:1 Liverpool
Real_Madrid 1:2 Ludogorets
Liverpool 1:2 Ludogorets
Ludogorets 0:0 Basel
Basel 3:3 Liverpool
Barcelona 2:2 Manchester_United
Inter 1:0 Manchester_United
Manchester_United 9:0 Torpedo_Belaz
Barcelona 9:0 Torpedo_Belaz
Torpedo_Belaz 1:3 Inter
Inter 2:5 Manchester_United
Manchester_United 3:2 Inter
Basel 4:4 Liverpool


3) Groups.txt:
Format: Each line represents the result of a game between two teams, with the score separated by a space.
Example (Each group on the new line):

A Atletico_M Juventus Olympiacos Malmo
B Real_Madrid Basel Liverpool Ludogorets
C Manchester_United Torpedo_Belaz Inter Barcelona


Program Logic:

The program processes data from the specified files (Groups.txt and Game.txt).

No direct keyboard input is required; the program automatically understands and retrieves information from the provided files.

The results for each group are written to GroupsOut.txt.

The overall Champions League table results are written to Results.txt with sorting based on points.

Calculation Details:

Each group follows the given rules: a win - 3 points, a draw - 2 points, a loss - 1 point.

Each team in the group plays K matches.

The overall number of matches for all groups is Count.

Output files:

Results for each group are written to GroupsOut.txt with the following format (Each team on the new line):

Group A:
Atletico_M 15 4 1 1 14 3
Juventus 13 3 1 2 7 4
Olympiacos 12 3 0 3 10 13
Malmo 8 1 0 5 4 15


Note: The teams are sorted first by points and then, if points are equal, by the goal difference.

The overall Champions League table results are written to Results.txt with sorting based on points (Each team on the new line):

Atletico_M 18 6
Manchester_United 12 5
Juventus 9 5
Ludogorets 8 3
Basel 8 4
Inter 8 4
Malmo 8 5
Real_Madrid 6 3
Liverpool 6 4
Barcelona 5 2
Olympiacos 5 4
Torpedo_Belaz 3 3


Note: The teams are sorted first by points and then, if points are equal, by the number of games played.
