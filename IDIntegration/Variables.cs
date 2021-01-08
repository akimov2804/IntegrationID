using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceDesigner
{
    public partial class Variables : Form
    {
        DataTable TableVariables;
        InterfaceDesigner MainProgram;
        public Variables(DataTable dataGridView, InterfaceDesigner interfaceDesigner)
        {
            TableVariables = dataGridView;
            MainProgram = interfaceDesigner;
            InitializeComponent();
        }

        private void VariablesToBind_Enter(object sender, EventArgs e)
        {
            VariablesToBind.DataSource = TableVariables;
        }

        private void Bind_Click(object sender, EventArgs e)
        {
            MainProgram.Bind(Convert.ToInt32(VariablesToBind[5, VariablesToBind.CurrentRow.Index].Value.ToString()), Convert.ToInt32(VariablesToBind[6, VariablesToBind.CurrentRow.Index].Value.ToString()));
            this.Close();
        }
    }
}
