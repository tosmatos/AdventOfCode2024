string[] inputLines = File.ReadAllLines("input.txt");
List<List<int>> reports = new();
int safeReports = 0;

// Initialize clean reports list
foreach (string line in inputLines)
{
	List<int> report = new();
	string[] reportString = line.Split(" ");

	foreach (string reportNumber in reportString)
	{
		report.Add(int.Parse(reportNumber));
	}

	reports.Add(report);
}

// Analyze each report line
foreach (List<int> report in reports)
{
	bool isDecreasing = false;
	bool isIncreasing = false;
	bool isUnsafe = false;

	for (int i = 0; i < report.Count; i++)
	{
		if (i == 0) continue;

		// for second number, look if it's increasing or decreasing.
		if (i == 1)
		{
			if (report[i] > report[i - 1])
				isIncreasing = true;
			else if (report[i] < report[i - 1])
				isDecreasing = true;
		}

		// if difference is more than 3 OR no difference, it's unsafe
        if (Math.Abs(report[i] - report[i - 1]) > 3 || report[i] == report[i - 1])
		{
			isUnsafe = true;
			break;
		}

		if (isDecreasing && report[i] < report[i - 1])
			continue;
		else if (isIncreasing && report[i] > report[i - 1])
			continue;
		else // Increasing or decreasing, difference more than 0 and less than 3 but not following increase/decrease
		{
			isUnsafe = true;
			break;
		}
	}

	if (!isUnsafe)
		safeReports++;
}

Console.WriteLine("Number of safe reports : " +  safeReports);