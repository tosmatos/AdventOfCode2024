string[] inputLines = File.ReadAllLines("example_input.txt");

int xmasCount = 0;

char[,] grid = new char[inputLines.Length, inputLines[0].Length];

// Transform string[] to char[,]
for (int i = 0; i < inputLines.Length; i++)
{
	string currentString = inputLines[i];
	for (int j = 0; j < inputLines[i].Length; j++)
	{
		grid[i, j] = currentString[j];
	}
}

for (int row = 0; row < grid.GetLength(0); row++) // rows
{
	for (int col = 0; col < grid.GetLength(1); col++) // columns
	{
		if (grid[row, col] == 'X')
		{
			string right = "X", left = "X", up = "X", down = "X", upRight = "X", downRight = "X", upLeft = "X", downLeft = "X";
			// Check horizontal
			for (int i = 1; i <= 3; i++)
			{
				if (col + i < grid.GetLength(1))
				{
					right += grid[row, col + i];
				}
				if (col - i >= 0)
				{
					left += grid[row, col - i];
				}
			}

			// Check vertical
			for (int i = 1; i <= 3; i++)
			{
				if (row + i < grid.GetLength(0))
				{
					down += grid[row + i, col];
				}
				if (row - i >= 0)
				{
					up += grid[row - i, col];
				}
			}

			// Check diagonals
			for (int i = 1; i <= 3; i++)
			{
				if (row + i < grid.GetLength(0) && col + i < grid.GetLength(1))
				{
					downRight += grid[row + i, col + i];
				}
				if (row - i >= 0 && col - i >= 0)
				{
					upLeft += grid[row - i, col - 1];
				}
				if (row + i < grid.GetLength(0) && col - i >= 0)
				{
					downLeft += grid[row + i, col - i];
				}
				if (row - i >= 0 && col + i < grid.GetLength(1))
				{
					upRight += grid[row - i, col + i];
				}
			}

			string[] buildXmases = {right, left, up, down, upRight, upLeft, downRight, downLeft};
			xmasCount += buildXmases.Where(s => s == "XMAS").Count();
		}
	}
}

Console.WriteLine("Total number of 'XMAS' : " + xmasCount);