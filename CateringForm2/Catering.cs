using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CateringForm2
{
    public partial class Form1 : Form
    {

        String name;
        String entree;
        String appetizers;
        String desert;
        float phonenum;
        int numofguests;
        //String[] entrees = new string[] { "fish", "chicken", "lamb", "steak" };
        //String[] desert = new string[] { "cake", "icecream", "sugar"};
       // String[] sides = new string[] { "fruit", "rice", "corn", "peas" };
        int eventcost;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String phone = textBox2.Text;
            phonenum = float.Parse(phone);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            String numofguest = textBox3.Text;
            try
            {
                numofguests = Int32.Parse(numofguest);
                calculateCost(numofguests);
            }
            catch
            {
                eventcost = 0;
            }
        }

        private int calculateCost(int numofguests)
        {
            eventcost = numofguests * 35;
            return eventcost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "" + eventcost;
            TextWriter txt = new StreamWriter("C:\\Users\\Refractxd\\Source\\Repos\\CateringForm2\\CateringForm2\\data.txt");
            txt.Write(name +"\n");
            txt.Write(phonenum + "\n");
            txt.Write(numofguests + "\n");
            txt.Write(eventcost + "\n");
            txt.Write(entree + "\n");
            txt.Write(appetizers + "\n");
            txt.Write(desert + "\n");
            txt.Close();
        }

        private void Fish_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Fish.CheckedItems.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                for (int x = 0; x < Fish.CheckedItems.Count; x++)
                {
                    entree += Fish.CheckedItems[x].ToString() + "\n";
                    label7.Text = entree;
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((checkedListBox1.CheckedItems.Count != 0) && (checkedListBox1.CheckedItems.Count < 3))
                {
                    // If so, loop through all checked items and print results.  
                    for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                    {
                        appetizers += checkedListBox1.CheckedItems[x].ToString() + "\n";
                    }
                }
            }
            catch
            {
                appetizers = "";
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox2.CheckedItems.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                for (int x = 0; x < checkedListBox2.CheckedItems.Count; x++)
                {
                    desert = checkedListBox2.CheckedItems[x].ToString() + "\n";
                }
            }
        }
    }
}
