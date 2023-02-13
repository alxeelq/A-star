using static Project.FindingState;

namespace Project;

public enum FindingState
{
    NotStarted,
    InProcess,
    Finished
}

public partial class MainForm : Form
{
    private const int Rows = 35;
    private const int Cols = 35;
    private const int w = 20;
    private const int h = 20;
    private static AStar aStar;
    private static Button[,] buttons;

    private bool _isShowing = false;

    private Thread _pathFinding;

    public static FindingState State = NotStarted;

    public MainForm()
    {
        InitializeComponent();

        cbPercentage.SelectedIndex = 3;
    }

    public static void Draw()
    {
        foreach (var node in aStar.OpenSet)
        {
            buttons[node.Row, node.Col].BackColor = Color.SeaGreen;
        }

        foreach (var node in aStar.ClosedSet)
        {
            buttons[node.Row, node.Col].BackColor = Color.Yellow;
        }

        foreach (var node in aStar.Grid)
        {
            buttons[node.Row, node.Col].BackColor = node.Blocked ? Color.Black : buttons[node.Row, node.Col].BackColor;
        }

        foreach (var node in aStar.Path)
        {
            buttons[node.Row, node.Col].BackColor = Color.Red;
        }
    }

    private void tsmFindPath_Click(object sender, EventArgs e)
    {
        if (State == InProcess)
        {
            MessageBox.Show("Path finding is in process!", "In process",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        if (State == Finished)
        {
            MessageBox.Show("Please, reset the grid.", "Reset",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (State == NotStarted && !_isShowing)
        {
            MessageBox.Show("You need to display grid first!", "Display grid",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _pathFinding.Start();
    }

    private void tsmReset_Click(object sender, EventArgs e)
    {
        State = NotStarted;
        RemoveButtons();
    }

    private void InitializeButtons()
    {
        for (int i = 0; i < aStar.Grid.GetLength(0); i++)
        {
            for (int j = 0; j < aStar.Grid.GetLength(1); j++)
            {
                buttons[i, j] = new Button()
                {
                    Location = new Point(aStar.Grid[i, j].Col * w, aStar.Grid[i, j].Row * h + 24),
                    Size = new Size(w, h)
                };

                Controls.Add(buttons[i, j]);
            }
        }
    }

    private void RemoveButtons()
    {
        _isShowing = false;

        foreach (var button in buttons)
        {
            Controls.Remove(button);
        }
    }

    private void tsmDisplayGrid_Click(object sender, EventArgs e)
    {
        if (_isShowing)
            return;

        var percentage = GetPercentage();

        if (tbCols.Text != "" || tbRows.Text != "")
        {
            try
            {
                var rows = int.Parse(tbRows.Text);
                var cols = int.Parse(tbCols.Text);
                

                aStar = new AStar(rows, cols, GetPercentage());
                buttons = new Button[rows, cols];
                _isShowing = true;

                InitializeButtons();
                Draw();
                _pathFinding = new Thread(new ThreadStart(aStar.GetPath));
            }
            catch (FormatException)
            {

                MessageBox.Show("Values must be integers (0 > value > 100).\n" +
                    "Provide correct values or clear text box!", "Wrong format",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return;
        }

        aStar = new AStar(Rows, Cols, percentage);
        buttons = new Button[Rows, Cols];
        _isShowing = true;

        InitializeButtons();
        Draw();
        _pathFinding = new Thread(new ThreadStart(aStar.GetPath));
    }

    public static void ShowTime()
    {
        var time = Math.Round((aStar.EndTime - aStar.StartTime).TotalSeconds, 2);
        MessageBox.Show($"Solution was found in {time} seconds!", 
            "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private double GetPercentage()
    {

        return cbPercentage.SelectedIndex * 0.1;
    }
}