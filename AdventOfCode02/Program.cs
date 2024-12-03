string[] inputLines = File.ReadAllLines("edge_case_input.txt");
List<List<int>> reports = new();
List<List<int>> potentialReports = new();

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

int AnalyzeReports(List<List<int>> reportsToAnalyze, bool makingPart2)
{
    int safeReports = 0;

    foreach (List<int> report in reportsToAnalyze)
    {
        bool isDecreasing = false;
        bool isIncreasing = false;
        bool isUnsafe = false;

        for (int i = 0; i < report.Count; i++)
        {
            Console.Write(report[i] + " ");

            if (i != report.Count - 1)
            {
                if (report[i] < report[i + 1])
                {
                    isIncreasing = true;
                }
                else if (report[i] > report[i + 1])
                {
                    isDecreasing = true;
                }
                else
                {
                    isUnsafe = true;
                }

                //if difference is more than 3 OR no difference, it's unsafe
                if (Math.Abs(report[i] - report[i + 1]) > 3 || report[i] == report[i + 1])
                {
                    isUnsafe = true;
                }

                // Increasing or decreasing, difference more than 0 and less than 3 but not following increase/decrease
                if (isIncreasing && report[i] > report[i + 1] || isDecreasing && report[i] < report[i + 1])
                {
                    isUnsafe = true;
                }
            }

            if (isUnsafe && makingPart2)
            {
                List<int> potentialReport = new(report);
                if (isIncreasing && isDecreasing)
                    potentialReport.RemoveAt(i - 1);
                else
                    potentialReport.RemoveAt(i);
                potentialReports.Add(potentialReport);
                break;
            }
        }

        Console.WriteLine("id : " + isUnsafe);

        if (!isUnsafe)
        {
            safeReports++;
        }
    }

    return safeReports; 
}


Console.WriteLine("Number of safe reports : " + AnalyzeReports(reports, true));
Console.WriteLine("Number of safe reports with tolerance : " + AnalyzeReports(potentialReports, false));