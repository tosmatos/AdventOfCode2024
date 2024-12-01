string[] inputLines = File.ReadAllLines("input.txt");
List<int> list1 = new();
List<int> list2 = new();
List<int> differenceList = new();

foreach (string line in inputLines)
{
    list1.Add(int.Parse(line.Split("   ")[0]));
    list2.Add(int.Parse(line.Split("   ")[1]));
}

int numElements = list1.Count;

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