string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string file = Path.Combine(currentDirectory, "../../../input.txt");
string path = Path.GetFullPath(file);
string[] text = File.ReadAllText(path).Split("\n");

HashSet<Point> visitedPoints = new() { new Point { x = 0, y = 0 } };
Point head = new() { x = 0, y = 0 };
Point tail = new() { x = 0, y = 0 };

for (int i = 0; i < text.Length; i++)
{
    string direction = text[i].Split()[0];
    int distance = Convert.ToInt32(text[i].Split()[1]);

    for (int j = 0; j < distance; j++)
    {
        switch (direction)
        {
            case "U":
                head.y++;
                break;
            case "L":
                head.x--;
                break;
            case "R":
                head.x++;
                break;
            case "D":
                head.y--;
                break;
        }
        if (Math.Abs(head.x - tail.x) > 1 || Math.Abs(head.y - tail.y) > 1)
        {
            if (head.x - tail.x > 0)
            {
                tail.x++;
                if (head.y > tail.y)
                {
                    tail.y++;
                }
                else if (head.y < tail.y)
                {
                    tail.y--;
                }
            }
            else if (head.x - tail.x < 0)
            {
                tail.x--;
                if (head.y > tail.y)
                {
                    tail.y++;
                }
                else if (head.y < tail.y)
                {
                    tail.y--;
                }
            }
            else if (head.y - tail.y > 0)
            {
                tail.y++;
                if (head.x > tail.x)
                {
                    tail.x++;
                }
                else if (head.x < tail.x)
                {
                    tail.x--;
                }
            }
            else if (head.y - tail.y < 0)
            {
                tail.y--;
                if (head.x > tail.x)
                {
                    tail.x++;
                }
                else if (head.x < tail.x)
                {
                    tail.x--;
                }
            }
            visitedPoints.Add(tail);
        }
    }
}
Console.WriteLine($"Visited points: {visitedPoints.Count}");
Console.WriteLine("\nPart 2\n");

visitedPoints = new() { new Point { x = 0, y = 0 } };
head = new() { x = 0, y = 0 };

List<Point> tailList = new();
for (int i = 0; i < 9; i++)
{
    tailList.Add(new Point { x = 0, y = 0 });
}

for (int i = 0; i < text.Length; i++)
{
    string direction = text[i].Split()[0];
    int distance = Convert.ToInt32(text[i].Split()[1]);

    for (int j = 0; j < distance; j++)
    {
        switch (direction)
        {
            case "U":
                head.y++;
                break;
            case "L":
                head.x--;
                break;
            case "R":
                head.x++;
                break;
            case "D":
                head.y--;
                break;
        }
        if (Math.Abs(head.x - tailList[0].x) > 1 || Math.Abs(head.y - tailList[0].y) > 1)
        {
            if (head.x - tailList[0].x > 0)
            {
                tailList[0] = new Point { x = tailList[0].x + 1, y = tailList[0].y };
                if (head.y > tailList[0].y)
                {
                    tailList[0] = new Point { x = tailList[0].x, y = tailList[0].y + 1 };
                }
                else if (head.y < tailList[0].y)
                {
                    tailList[0] = new Point { x = tailList[0].x, y = tailList[0].y - 1 };
                }
            }
            else if (head.x - tailList[0].x < 0)
            {
                tailList[0] = new Point { x = tailList[0].x - 1, y = tailList[0].y };
                if (head.y > tailList[0].y)
                {
                    tailList[0] = new Point { x = tailList[0].x, y = tailList[0].y + 1 };
                }
                else if (head.y < tailList[0].y)
                {
                    tailList[0] = new Point { x = tailList[0].x, y = tailList[0].y - 1 };
                }
            }
            else if (head.y - tailList[0].y > 0)
            {
                tailList[0] = new Point { x = tailList[0].x, y = tailList[0].y + 1 };
            }
            else if (head.y - tailList[0].y < 0)
            {
                tailList[0] = new Point { x = tailList[0].x, y = tailList[0].y - 1 };
            }
            for (int k = 1; k < tailList.Count; k++)
            {
                tailList[k] = TailMoved(tailList[k - 1], tailList[k]);
            }
            visitedPoints.Add(tailList[8]);
        }
    }
}

Console.WriteLine($"Visited points: {visitedPoints.Count}");

static Point TailMoved(Point head, Point tail)
{
    if (Math.Abs(head.x - tail.x) > 1 || Math.Abs(head.y - tail.y) > 1)
    {
        if (head.x - tail.x > 0)
        {
            tail.x++;
            if (head.y > tail.y)
            {
                tail.y++;
            }
            else if (head.y < tail.y)
            {
                tail.y--;
            }
        }
        else if (head.x - tail.x < 0)
        {
            tail.x--;
            if (head.y > tail.y)
            {
                tail.y++;
            }
            else if (head.y < tail.y)
            {
                tail.y--;
            }
        }
        else if (head.y - tail.y > 0)
        {
            tail.y++;
        }
        else if (head.y - tail.y < 0)
        {
            tail.y--;
        }
    }
    return tail;
}

internal struct Point
{
    public int x;
    public int y;
};