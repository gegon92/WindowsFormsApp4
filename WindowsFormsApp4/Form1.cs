using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private List<dal.User> _list;
        public Form1()
        {
            
            InitializeComponent();
            _list = new List<dal.User>();
            bsUser.DataSource = _list;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            _list.Clear();

            List<dal.User> list = dal.sqlhelper.GetUsers();
            if (list != null && list.Count > 0)
            {
                _list.AddRange(list);
                bdUser.ResetBindings(false);

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
