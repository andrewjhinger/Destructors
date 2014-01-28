using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Destructors
{
    public partial class Destructors : Form
    {

        //private Bag _bag = null;
        private MyBag _mybag = null;

        public Destructors()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            // Only create a single MyBag.
            if (_mybag == null)
            {
                // Create a new MyBag instance.
                _mybag = new MyBag();

                // Create a variable that requires allocating a large block of heap memory.
                byte[] byteArray = new byte[100000];
                for (int i = 0; i < byteArray.Length; i++)
                {
                    byteArray[i] = 1;
                }

                // Add the variable to our Bag.
                _mybag.Items.Add(byteArray);

                outputListBox.Items.Add("Create: GC Memory (bytes): " + GC.GetTotalMemory(true).ToString());
                outputListBox.Items.Add("");
            }

        }

        private void destroyButton_Click(object sender, EventArgs e)
        {
            // Make sure Bag has been created.
            if (_mybag != null)
            {
                // Remove the reference to our Bag allocated memory.
                _mybag = null;

                outputListBox.Items.Add("Destroy: GC Memory (bytes): " + GC.GetTotalMemory(true).ToString());
                outputListBox.Items.Add("");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Destructors_Shown(object sender, EventArgs e)
        {
            outputListBox.Items.Add("Start: GC Memory (bytes): " + GC.GetTotalMemory(true).ToString());
            outputListBox.Items.Add("");
            string testString = "This is a string that requires memory allocation on the heap";
            outputListBox.Items.Add("String 1: GC Memory (bytes): " + GC.GetTotalMemory(true).ToString());
            outputListBox.Items.Add("");
            testString += "Changing the string value results in deallocation of original heap memory, and allocation of new memory";
            outputListBox.Items.Add("String 2: GC Memory (bytes): " + GC.GetTotalMemory(true).ToString());
            outputListBox.Items.Add("");
        }
    }
}
