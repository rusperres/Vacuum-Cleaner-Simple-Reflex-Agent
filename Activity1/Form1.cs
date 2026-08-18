namespace Activity1
{
    public partial class Form1 : Form
    {
        VacuumEnvironment env = new VacuumEnvironment();
        //Agent agent = new SimpleReflexAgent();
        Agent agent = new ImprovedAgent();
        int cx, cy;
        public Form1()
        {
            InitializeComponent();
            cx = cy = 0;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Creating 2x2 world\n";
            richTextBox1.Text += env;


            for (int step = 0; step < 10; step++)
            {
                var percept = env.Percept(agent);
                var action = agent.Program(percept) as string;
                env.ExecuteAction(agent, action);

                var tup = percept as Tuple<int, int, bool>;
                string locationText = "(?, ?)";
                if (tup != null) locationText = $"{tup.Item1}, {tup.Item2}";

                richTextBox1.Text += $"Step {step + 1}: Action = {action} | Location = {locationText} | Score = {agent.Performance}\r\n";

                pictureBox1.Invalidate();
                await Task.Delay(1000);
                // this.Refresh(); 

            }
            richTextBox1.Text += "FINAL WORLD: \r\n";
            richTextBox1.Text += $"{env.ToString()}";
            richTextBox1.Text += $"FINAL PERFORMANCE SCORE: {agent.Performance}\r\n";
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_paint(object sender, PaintEventArgs e)
        {
            var percept = env.Percept(agent);
            var tup = percept as Tuple <int, int, bool>;
            Graphics g = e.Graphics;
            int agentSize = 50;
            int margin = 10;
            int agentXC = tup.Item2 * agentSize + margin;
            int agentYC = tup.Item1 * agentSize + margin;
            
            g.DrawArc(Pens.Red, agentXC, agentYC, agentSize, agentSize, 0, 360);

            int dirtSize = 20;
            for(int i = 0; i<2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    bool isDirty = env.getGridXY(i, j) == 1;
                    int agentHalf = agentSize / 2;
                    int dirtHalf = dirtSize / 2;
                    int dirtX = j * agentSize + margin + agentHalf - dirtHalf;
                    int dirtY = i * agentSize + margin + agentHalf - dirtHalf;
                    if (isDirty) g.DrawEllipse(Pens.Blue, dirtX,  dirtY, dirtSize, dirtSize);                
                }
            }


        }
    }
}
