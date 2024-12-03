string[] inputLines = File.ReadAllLines("input.txt");

int part1Total = 0;
List<string> mulStrings = new();
for (int i = 0; i < inputLines.Length; i++)
{
	mulStrings.AddRange(inputLines[i].Split("mul"));
}

Console.WriteLine("Coucou !");

for (int i = 0; i < mulStrings.Count; i++)
{
	string mulString = mulStrings[i];
	if (mulString.Length != 0 && mulString[0] == '(')
	{
		string[] mulNums = mulString.Split(['(', ')']);
		
		for (int j = 0; j < mulNums.Length; j++)
		{
			string mulNum = mulNums[j];
			int a = 0;
			int b = 0;
			if (mulNum.Contains(','))
			{
				string[] finalMul = mulNum.Split(",");
				//Console.WriteLine("Found finalMul :" + finalMul[0] + " and "+ finalMul[1]);

				if (finalMul.Length == 2 &&Int32.TryParse(finalMul[0], out a) && Int32.TryParse(finalMul[1], out b))
				{
					Console.WriteLine("+++++++++++++++ Added " + mulString + " id : " + i);
					part1Total += a * b;
					break;
				}
				else
					Console.WriteLine("--------------- Didn't add " + mulString + " id : " + i);
			}
		}
		//Console.WriteLine("Hello");
	}
}

 Console.WriteLine("Multiplication Total : " + part1Total);