using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iBroker.Forms
{
    public partial class TestForm : Form
    {
        private List<CheckedListBoxItem> liscollection;
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            // You would add one item to liscollection for each item that you have in the checkedListBox1's designer and set the Text to whatever the item is now...
            liscollection = new List<CheckedListBoxItem>
            {
               new CheckedListBoxItem { Text = "The" },
               new CheckedListBoxItem { Text = "needs" },
               new CheckedListBoxItem { Text = "of" },
               new CheckedListBoxItem { Text = "the" },
               new CheckedListBoxItem { Text = "many" },
               new CheckedListBoxItem { Text = "outweigh" },
               new CheckedListBoxItem { Text = "the" },
               new CheckedListBoxItem { Text = "needs" },
               new CheckedListBoxItem { Text = "of" },
               new CheckedListBoxItem { Text = "the" },
               new CheckedListBoxItem { Text = "few" },
            };

            checkedListBox1.Items.AddRange(liscollection.ToArray());

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                foreach (var item in liscollection)
                {
                    if (item.Contains(textBox1.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        checkedListBox1.Items.Add(item, item.CheckState);
                    }
                }
            }
            else
            {
                foreach (var item in liscollection)
                {
                    checkedListBox1.Items.Add(item, item.CheckState);
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Since each item in the CheckedListBox is of type CheckedListBoxItem, we can
            // just cast to that type...
            CheckedListBoxItem item = checkedListBox1.Items[e.Index] as CheckedListBoxItem;

            // Then set the checked state to the new value.
            item.CheckState = e.NewValue;
        }
    }

    // CheckedListBoxItem.cs
    public class CheckedListBoxItem
    {
        /// <summary>
        /// The item's text - what will be displayed in the CheckedListBox.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The item's check state.
        /// </summary>
        public CheckState CheckState { get; set; } = CheckState.Unchecked;

        /// <summary>
        /// Whether the item is checked or not.
        /// </summary>
        public bool Checked
        {
            get
            {
                return (CheckState == CheckState.Checked || CheckState == CheckState.Indeterminate);
            }
            set
            {
                if (value)
                {
                    CheckState = CheckState.Checked;
                }
                else
                {
                    CheckState = CheckState.Unchecked;
                }
            }
        }

        public bool Contains(string str, StringComparison comparison)
        {
            return Text.IndexOf(str, comparison) >= 0;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
