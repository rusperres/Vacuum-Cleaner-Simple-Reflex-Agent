namespace Activity1
{
    public partial class Form1 : Form
    {
        VacuumEnvironment env = new VacuumEnvironment();
        Agent agent = new SimpleReflexAgent();
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                //try
                //{
                //    Thread.Sleep(5000);
                //}
                //catch (Exception ex)
                //{
                //    richTextBox1.Text += ex.Message;
                //    throw;
                //}
            }
            richTextBox1.Text += "FINAL WORLD: \r\n";
            richTextBox1.Text += $"{env.ToString()}";
            richTextBox1.Text += $"FINAL PERFORMANCE SCORE: {agent.Performance}\r\n";
        }
    }
}
