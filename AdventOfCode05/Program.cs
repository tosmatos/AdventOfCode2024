string[] inputLines = File.ReadAllLines("input.txt");

List<(int page1, int page2)> pageOrderingRules = new();
List<List<int>> updates = new();
List<List<int>> correctUpdates = new();
int part1Total = 0;

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

foreach (List<int> update in updates)
{
	bool wrong = false;
	for (int i = 0; i < update.Count; i++)
	{
		int pageNumber = update[i];
		foreach ((int page1, int page2) in pageOrderingRules)
		{
			if (page1 == pageNumber)
			{
				if (update.IndexOf(pageNumber) > update.IndexOf(page2) && update.IndexOf(page2) != -1)
				{
					wrong = true;
					break;
				}
			}
		}
	}

	if (!wrong)
	{
		correctUpdates.Add(update);
	}
}

foreach (List<int> update in correctUpdates)
{
	part1Total += update[update.Count / 2];
}

Console.WriteLine("Sum of middle elements in correct updates : " + part1Total);