string[] inputLines = File.ReadAllLines("input.txt");

int xmasCount = 0;
int crossmasCount = 0;

char[,] grid = new char[inputLines.Length, inputLines[0].Length];
char[,] newGrid = new char[inputLines.Length, inputLines[0].Length];

// Transform string[] to char[,]
for (int i = 0; i < inputLines.Length; i++)
{
    string currentString = inputLines[i];
    for (int j = 0; j < inputLines[i].Length; j++)
    {
        grid[i, j] = currentString[j];
    }
}

// Part 1 loop
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
                    upLeft += grid[row - i, col - i];
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

            string[] buildXmases = { right, left, up, down, upRight, upLeft, downRight, downLeft };
            int localXmasCount = buildXmases.Where(s => s == "XMAS").Count();
            if (localXmasCount > 0)
                newGrid[row, col] = 'X';
            else
                newGrid[row, col] = '.';
            xmasCount += localXmasCount;
        }
        else
        {
            newGrid[row, col] = '.';
        }
    }
}

// Part 2 loop
for (int row = 0; row < grid.GetLength(0); row++) // rows
{
    for (int col = 0; col < grid.GetLength(1); col++) // columns
    {
        if (grid[row, col] == 'A')
        {
            char upRight = '0', downRight = '0', upLeft = '0', downLeft = '0';

            if (row + 1 < grid.GetLength(0) && col + 1 < grid.GetLength(1))
            {
                downRight = grid[row + 1, col + 1];
            }
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                upLeft = grid[row - 1, col - 1];
            }
            if (row + 1 < grid.GetLength(0) && col - 1 >= 0)
            {
                downLeft = grid[row + 1, col - 1];
            }
            if (row - 1 >= 0 && col + 1 < grid.GetLength(1))
            {
                upRight = grid[row - 1, col + 1];
            }

            string diag1 = upLeft.ToString() + downRight.ToString(), diag2 = upRight.ToString() + downLeft.ToString();
            if ((diag1.Contains("MS") || diag1.Contains("SM")) && (diag2.Contains("MS") || diag2.Contains("SM")))
                crossmasCount += 1;
        }
    }
}

// for debug
void DisplayGrid()
{
    for (int row = 0; row < newGrid.GetLength(0); row++)
    {
        for (int column = 0; column < newGrid.GetLength(1); column++)
        {
            Console.SetCursorPosition(column * 2, row);
            Console.Write(newGrid[row, column]);
        }
        Console.WriteLine();
    }
    Console.SetCursorPosition(0, newGrid.GetLength(0) + 1);
}

//DisplayGrid();
Console.WriteLine("Total number of 'XMAS' : " + xmasCount);
Console.WriteLine("Total number of 'X-MAS' : " + crossmasCount);