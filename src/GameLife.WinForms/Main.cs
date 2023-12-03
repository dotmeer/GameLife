using GameLife.Rules;

namespace GameLife.WinForms
{
    // TODO: стандартный набор правил + набор правил для нескольких разноцветных групп и их соревнования - дропбокс
    // TODO: unit-tests
    public partial class Main : Form
    {
        private bool _run;
        private Task? _runner;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private Field _field;
        private int _scale;
        private int _iterationsCount;
        public Main()
        {
            InitializeComponent();

            _run = false;
            _scale = int.Parse(ScaleComboBox.Text);
            _cancellationTokenSource = new CancellationTokenSource();
            _field = new Field(pictureBox.Width / _scale, pictureBox.Height / _scale);
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            _runner = Run();
            await _runner;
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            ScaleComboBox.Enabled = false;
            _field = new Field(pictureBox.Width / _scale, pictureBox.Height / _scale);
            _iterationsCount = 0;
            _run = true;
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            ScaleComboBox.Enabled = true;
            _run = false;
        }

        private async Task Run()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                if (_run)
                {
                    DrawField();

                    _iterationsCount++;
                    IterationsLabel.Text = $"Итераций: {_iterationsCount}";

                    _field.ExecuteTurn();
                }

                await Task.Delay(TimeSpan.FromMilliseconds(100));
            }
        }

        private void DrawField()
        {
            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

            for (var x = 0; x < _field.Width; x++)
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
                                    _ => Color.Red
                                });
                        }
                    }
                }
            }

            pictureBox.Image = bitmap;
        }

        private void ScaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _scale = int.Parse(ScaleComboBox.Text);
        }
    }
}
