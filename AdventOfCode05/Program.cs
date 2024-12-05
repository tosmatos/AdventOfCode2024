string[] inputLines = File.ReadAllLines("input.txt");

List<(int page1, int page2)> pageOrderingRules = new();
List<List<int>> updates = new();
List<List<int>> correctUpdates = new();
List<List<int>> wrongUpdates = new();
List<List<int>> correctedUpdates = new();
int part1Total = 0, part2Total = 0;


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
    else
    {
        wrongUpdates.Add(update);
    }
}

foreach (List<int> update in correctUpdates)
{
    part1Total += update[update.Count / 2];
}

// Part 2
foreach (List<int> update in wrongUpdates)
{
    List<(int page1, int page2)> updateRules = new();
    List<int> correctedUpdate = new(update);

    // Make possible update rules list
    foreach ((int page1, int page2) in pageOrderingRules)
    {
        if (correctedUpdate.Contains(page1) && correctedUpdate.Contains(page2))
        {
            updateRules.Add((page1, page2));
        }
    }

    for (int i = 0; i < update.Count; i++)
    {
        foreach ((int page1, int page2) in updateRules)
        {
            if (correctedUpdate.IndexOf(page1) > correctedUpdate.IndexOf(page2))
            {
                Swap(correctedUpdate, correctedUpdate.IndexOf(page1), correctedUpdate.IndexOf(page2));
            }
        }        
    }
    correctedUpdates.Add(correctedUpdate);
}

foreach (List<int> update in correctedUpdates)
{
    part2Total += update[update.Count / 2];
}

Console.WriteLine("Sum of middle elements in correct updates : " + part1Total);
Console.WriteLine("Sum of middle elements in corrected updates : " + part2Total);

// Function for swapping list elements, so loop stays readable
void Swap<T>(IList<T> list, int indexA, int indexB)
{
    T tmp = list[indexA];
    list[indexA] = list[indexB];
    list[indexB] = tmp;
}