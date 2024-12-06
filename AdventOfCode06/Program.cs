using System.Data;

string[] inputLines = File.ReadAllLines("input.txt");

char[,] grid = new char[inputLines.Length, inputLines[0].Length];

(int row, int column) guardPosition = (0, 0); 
Direction direction = Direction.Up;
bool guardIsInMap = true;

int distinctPositions = 0;

// Transform string[] to char[,]
for (int i = 0; i < inputLines.Length; i++)
{
	string currentString = inputLines[i];
	for (int j = 0; j < inputLines[i].Length; j++)
	{
		// Get inital guard position
		if (currentString[j] == '^')
		{
			guardPosition = (i, j);
			direction = Direction.Up;
		}
		else if (currentString[j] == '>')
		{
			guardPosition = (i, j);
			direction = Direction.Right;
		}
		else if (currentString[j] == '<')
		{
			guardPosition = (i, j);
			direction = Direction.Left;
		}
		else if (currentString[j] == 'v')
		{
			guardPosition = (i, j);
			direction = Direction.Down;
		}

		grid[i, j] = currentString[j];
	}
}

while (guardIsInMap)
{
	grid[guardPosition.row, guardPosition.column] = 'X';
	Direction nextDirection = Direction.Up; // a bit nasty
	(int row, int column) nextPosition = guardPosition;

	switch (direction)
	{
		case Direction.Up:
			nextPosition.row -= 1;
			nextDirection = Direction.Right;
			break;

		case Direction.Down:
			nextPosition.row += 1;
			nextDirection = Direction.Left;
			break;

		case Direction.Left:
			nextPosition.column -= 1;
			nextDirection = Direction.Up;
			break;

		case Direction.Right:
			nextPosition.column += 1;
			nextDirection = Direction.Down;
			break;
	}

	// Guard left the grid
	if (nextPosition.row < 0 || nextPosition.row >= grid.GetLength(0) 
		|| nextPosition.column < 0 || nextPosition.column >= grid.GetLength(1))
	{
		guardIsInMap = false;
	}
	else if (grid[nextPosition.row, nextPosition.column] == '#')
	{
		direction = nextDirection;
	}
	else
	{
		guardPosition = nextPosition;
	}
}

// Count distinct positions
for (int i = 0; i < inputLines.Length; i++)
{
	string currentString = inputLines[i];
	for (int j = 0; j < inputLines[i].Length; j++)
	{
		if (grid[i, j] == 'X')
		{
			distinctPositions++;
		}
	}
}


Console.WriteLine("Distinct positions visited by guard : " + distinctPositions);

enum Direction
{
	Up,
	Down,
	Left,
	Right,
}