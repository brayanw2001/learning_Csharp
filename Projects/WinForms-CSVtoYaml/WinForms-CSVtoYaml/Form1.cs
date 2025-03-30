using CSVtoYAML;

namespace WinForms_CSVtoYaml
{
    public partial class Form1 : Form
    {
        public string path;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               path = Path.Text = ofd.FileName;
            }

            YamlConstructor yamlConstructor = new YamlConstructor(path);
        }

        private void Path_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
