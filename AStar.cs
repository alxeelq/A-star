using static Project.FindingState;

namespace Project;

public class AStar
{
    public int Rows, Cols;
    public double ObstaclePercentage;
    public Node[,] Grid;
    public List<Node> OpenSet;
    public List<Node> ClosedSet;
    public List<Node> Path = new();
    public Node StartNode, EndNode;
    public DateTime StartTime, EndTime;

    public AStar(int rows, int cols, double obstaclePercentage)
    {
        Rows = rows;
        Cols = cols;

        Grid = new Node[Rows, Cols];
        OpenSet = new List<Node>();
        ClosedSet = new List<Node>();
        ObstaclePercentage = obstaclePercentage;
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        var r = new Random();
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Cols; j++)
            {
                Grid[i, j] = new Node(i, j);
                
                if (r.NextDouble() < ObstaclePercentage)
                    Grid[i, j].Blocked = true;
            }
        }

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Cols; j++)
            {
                Grid[i, j].Neighbors = GetNeighbors(Grid[i, j]);
            }
        }
        
        SetStartEnd(0, 0, Rows - 1, Cols - 1);
        OpenSet.Add(StartNode);
    }

    private void SetStartEnd(int startRow, int startCol, int endRow, int endCol)
    {
        StartNode = Grid[startRow, startCol];
        StartNode.Blocked = false;
        EndNode = Grid[endRow, endCol];
        EndNode.Blocked = false;
    }

    private bool IsValidNode(int row, int col)
    {
        if (row < 0 || row >= Rows)
            return false;

        if (col < 0 || col >= Cols)
            return false;

        return true;
    }

    private List<Node> GetNeighbors(Node node)
    {
        var neighbors = new List<Node>();
        
        var row = node.Row;
        var col = node.Col;
        
        if (IsValidNode(row - 1, col))
            neighbors.Add(Grid[row - 1, col]);
            
        if (IsValidNode(row, col + 1))
            neighbors.Add(Grid[row, col + 1]);
        
        if (IsValidNode(row + 1, col))
            neighbors.Add(Grid[row + 1, col]);
        
        if (IsValidNode(row, col - 1))
            neighbors.Add(Grid[row, col - 1]);

        return neighbors;
    }

    private int Heuristic(Node node1, Node node2)
    {
        return Math.Abs(node1.Row - node2.Row) + Math.Abs(node1.Col - node2.Col);
    }

    private void ReconstructPath(Node node)
    {
        while (node != null)
        {
            Path.Add(node);
            node = node.CameFrom;
        }
    }

    public void GetPath()
    {
        StartTime = DateTime.Now;

        while (OpenSet.Count > 0)
        {
            MainForm.State = InProcess;

            var lowestIndex = 0;
            for (var i = 0; i < OpenSet.Count; i++)
            {
                lowestIndex = OpenSet[i].F < OpenSet[lowestIndex].F ? i : lowestIndex;
            }

            var current = OpenSet[lowestIndex];

            if (current == EndNode)
            {
                EndTime = DateTime.Now;
                MainForm.State = Finished;
                ReconstructPath(current);
                MainForm.Draw();
                MainForm.ShowTime();
                return;
            }

            OpenSet.Remove(current);
            ClosedSet.Add(current);

            foreach (var neighbor in current.Neighbors)
            {
                if (ClosedSet.Contains(neighbor) || neighbor.Blocked)
                    continue;

                var tempG = current.G + 1;

                if (OpenSet.Contains(neighbor))
                {
                    if (tempG < neighbor.G)
                        neighbor.G = tempG;
                }
                else
                {
                    neighbor.G = tempG;
                    OpenSet.Add(neighbor);
                }

                neighbor.H = Heuristic(neighbor, EndNode);
                neighbor.F = neighbor.G + neighbor.H;
                neighbor.CameFrom = current;
            }
            MainForm.Draw();
            Thread.Sleep(1);
        }

        MessageBox.Show("There is no solution!", "No solution",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
}

public class Node
{
    public int Row;
    public int Col;
    public bool Blocked = false;
    public int F = 0;
    public int G = 0;
    public int H = 0;
    public Node CameFrom;
    public List<Node> Neighbors;

    public Node(int row, int col)
    {
        Row = row;
        Col = col;
        Neighbors = new List<Node>();
    }
}