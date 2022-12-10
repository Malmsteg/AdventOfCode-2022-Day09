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
Console.WriteLine(visitedPoints.Count);

struct Point
{
    public int x;
    public int y;
};