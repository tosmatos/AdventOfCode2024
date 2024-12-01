string[] inputLines = File.ReadAllLines("input.txt");
List<int> list1 = new();
List<int> list2 = new();
List<int> differenceList = new();
List<int> similarityList = new();

foreach (string line in inputLines)
{
    list1.Add(int.Parse(line.Split("   ")[0]));
    list2.Add(int.Parse(line.Split("   ")[1]));
}

int numElements = list1.Count;

// Loop for part 2 comes first cause part 1 destroys the list
for (int i = 0; i < numElements; i++)
{
    int number = list1[i];
    int numberCount = list2.Count(inList2 => inList2 == number);

    similarityList.Add(number * numberCount);
}

// Loop for part 1
for (int i = 0; i < numElements; i++)
{
    int min1 = list1.Min();
    int min2 = list2.Min();

    differenceList.Add(Math.Abs(min1 - min2));
    list1.Remove(min1);
    list2.Remove(min2);
}

int totalDifference = differenceList.Sum();
Console.WriteLine("Total difference : " + totalDifference);

int totalSimilarity = similarityList.Sum();
Console.WriteLine("Total similarity score : " + totalSimilarity);
