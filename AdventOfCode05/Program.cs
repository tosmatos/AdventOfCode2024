string[] inputLines = File.ReadAllLines("input.txt");

List<(int page1, int page2)> pageOrderingRules = new();
List<List<int>> updates = new();

// Parse input
for (int i = 0; i < inputLines.Length; i++)
{
	string line = inputLines[i];

	if (line.Contains('|'))
	{
		(int page1, int page2) pageOrderingRule = (int.Parse(line.Split('|')[0]), int.Parse(line.Split('|')[1]));
		pageOrderingRules.Add(pageOrderingRule);
	}
	else if (line.Contains(','))
	{
		string[] values = line.Split(",");
		List<int> update = new();
		foreach (string value in values)
		{
			update.Add(int.Parse(value));
		}
		updates.Add(update);
	}
}

Console.WriteLine("Hello !");