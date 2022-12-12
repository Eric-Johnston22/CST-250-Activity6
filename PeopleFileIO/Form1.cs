using System;
using TextFileDataAccessDemo;

namespace PeopleFileIO
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        BindingSource peopleBinding = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            setBinding();
        }

        private void setBinding()
        {
            peopleBinding.DataSource = people;
            listBox1.ValueMember = "Display";
            listBox1.DisplayMember = "Display";
            listBox1.DataSource = peopleBinding;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person();

            p.firstName = textBox1.Text;
            p.lastName = textBox2.Text;
            p.Url = textBox3.Text;
            people.Add(p);

            peopleBinding.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> outputLines = new List<string>();

            foreach (Person p in listBox1.Items)
            {
                // add another line for the file output.
                outputLines.Add("First name: " + p.firstName + " Last name: " + p.lastName + " URL: " + p.Url + "\n");
            }
            // write to another file
            string filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\peopleOut.txt");
            File.WriteAllLines(filePath, outputLines);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            people.Clear();

            string filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\test.txt");

            try
            {
                List<String> lines = File.ReadAllLines(filePath).ToList();
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] entries = lines[i].Split(',');

                    Person p = new Person();
                    if (entries.Length != 3)
                    {
                        MessageBox.Show("Line #" + (i + 1) + " is missing all 3 items");
                        return;
                    }
                    else
                    {
                        p.firstName = entries[0];
                        p.lastName = entries[1];
                        p.Url = entries[2];
                    }

                    people.Add(p);
                    peopleBinding.ResetBindings(false);
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File not found, check path");
            }
        }
    }
}