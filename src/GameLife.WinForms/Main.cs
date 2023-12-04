using GameLife.Rules.Cells;
using GameLife.Rules.Fields;
using GameLife.Rules.Rules;

namespace GameLife.WinForms
{
    public partial class Main : Form
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private bool _runSimulation;
        private Field? _field;
        private int _scale;
        private int _iterationsCount;

        public Main()
        {
            InitializeComponent();

            _runSimulation = false;
            _scale = int.Parse(ScaleComboBox.Text);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            await Run();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ScaleComboBox.Enabled = false;

            _field = FieldFactory.Create(
                pictureBox.Width / _scale,
                pictureBox.Height / _scale,
                RuleSet.Basic);
            
            _iterationsCount = 0;
            _runSimulation = true;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _field = null;
            ScaleComboBox.Enabled = true;
            _runSimulation = false;
        }

        private void ScaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _scale = int.Parse(ScaleComboBox.Text);
        }

        private async Task Run()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                if (_runSimulation)
                {
                    DrawField();

                    _iterationsCount++;
                    IterationsLabel.Text = $"Итераций: {_iterationsCount}";

                    _field?.ExecuteTurn();

                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                }
                else
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(1000));
                }
            }
        }

        private void DrawField()
        {
            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

            for (var x = 0; x < _field!.Width; x++)
            {
                for (var y = 0; y < _field.Height; y++)
                {
                    var cell = _field.GetCell(x, y);

                    var i = x * _scale;
                    var j = y * _scale;

                    for (var k = 0; k < _scale; k++)
                    {
                        for (var l = 0; l < _scale; l++)
                        {
                            bitmap.SetPixel(
                                i + k,
                                j + l,
                                cell?.State switch
                                {
                                    CellState.Dead => Color.Black,
                                    CellState.Alive => Color.White,
                                    _ => Color.DarkGray
                                });
                        }
                    }
                }
            }

            pictureBox.Image = bitmap;
        }
    }
}
