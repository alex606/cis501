//////////////////////////////////////////////////////////////////
//  Domestic Telephone System (DTS)                             //
//    Written by Masaaki Mizuno, (c) 2007, 2008                 //
//      for K-State Course cis501                               //
//      also for Learning Tree Course, 123P, 230Y               //
//////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DTS
{
    public partial class ListDialog : Form
    {
        public ListDialog()
        {
            InitializeComponent();
        }

        public void AppendDisplayItems(params object[] objects)
        {
            lbList.Items.AddRange(objects);
        }

        public void ResetDisplayItems()
        {
            lbList.Items.Clear();
        }
    }
}