using System.Text.Json;

namespace WinFormsApp1
{
    
    public partial class Form1 : Form
    {
        private List<string> products = new List<string>();
        private Product[] massiv;
        public Form1()
        {
            InitializeComponent();
            string abc = File.ReadAllText("json.txt");
            massiv = JsonSerializer.Deserialize<Product[]>(abc);
            foreach (var item in massiv)
            {
                comboBox1.Items.Add(item.name);
            }





            foreach (var item in products)
            {
                listBox1.Items.Add(item);
            }
            textBox2.ScrollBars = ScrollBars.Vertical;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in products.Where(x => x.StartsWith(textBox1.Text)))
            {
                listBox1.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = JsonSerializer.Deserialize<string>(File.ReadAllText("test.txt"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("test.txt", JsonSerializer.Serialize(textBox1.Text));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Lines = textBox2.Lines.Append(listBox1.SelectedItem.ToString()).ToArray();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = massiv[comboBox1.SelectedIndex].kkal;
        }
    }
    public class Product
    {
        public string name { get; set; }
        public string kkal { get; set; }
    }
}