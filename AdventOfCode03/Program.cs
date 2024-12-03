string[] inputLines = File.ReadAllLines("input.txt");

int part1Total = 0;
List<string> mulStrings = new();
for (int i = 0; i < inputLines.Length; i++)
{
	mulStrings.AddRange(inputLines[i].Split("mul"));
}

Console.WriteLine("Coucou !");

bool isEnabled = true;

for (int i = 0; i < mulStrings.Count; i++)
{
	string mulString = mulStrings[i];
    string[] mulNums = mulString.Split(['(', ')']).Where(s => !string.IsNullOrEmpty(s)).ToArray();

    if (mulString.Length != 0 && mulString[0] == '(')
	{		
		string mulNum = mulNums[0];
		int a = 0;
		int b = 0;
		if (mulNum.Contains(','))
		{
			string[] finalMul = mulNum.Split(",");
			//Console.WriteLine("Found finalMul :" + finalMul[0] + " and "+ finalMul[1]);

			//delete isEnabled to get result for part 1
			if (isEnabled && finalMul.Length == 2 &&Int32.TryParse(finalMul[0], out a) && Int32.TryParse(finalMul[1], out b))
			{
				Console.WriteLine("+++++++++++++++ Added " + mulString + " id : " + i + " | Values found : " + a + " " + b);
				part1Total += a * b;
			}
			else
				Console.WriteLine("--------------- Didn't add " + mulString + " id : " + i);
		}
    }

    // check remaining substrings
    for (int j = 0; j < mulNums.Length; j++)
    {
        if (mulNums[j].Contains("don't"))
            isEnabled = false;
        else if (mulNums[j].Contains("do"))
            isEnabled = true;
    }
}

 Console.WriteLine("Multiplication Total : " + part1Total);