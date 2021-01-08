using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace InterfaceDesigner
{
    public partial class InterfaceDesigner : Form
    {
        Controller controller;
        DataGridView DataGrid;
        DataTable VariablesData;
        public void setController(Controller cont)
        {
            controller = cont;
        }
        int currentProject = 0;
        int countControls = 0;
        DataGridViewComboBoxColumn cmb;
        List<string[]> ScriptsList = new List<string[]>();
        public InterfaceDesigner()
        {
            InitializeComponent();
        }
        public void AddControl(Control control)
        {
            control.ContextMenuStrip = ContextMenu;
            ListOfControls.Items.Add(control.Name);
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            controller.CreateControl(sender, e, WorkPanel, "Button", 0, 0);
        }
        private void WorkPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void AddButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;
                btn.DoDragDrop(sender, DragDropEffects.None);
                controller.CreateControl(sender, e, WorkPanel, "Button", Convert.ToInt32((Cursor.Position.X - this.Left - 257) * 0.856), Convert.ToInt32((Cursor.Position.Y - this.Top - 82) * 0.864));
                //controller.CreateControl(sender, e, WorkPanel, "Button", Cursor.Position.X - this.Left - 257, Cursor.Position.Y - this.Top - 82);
            }
        }
        private void AddSwitcher_Click(object sender, EventArgs e)
        {
            controller.CreateControl(sender, e, WorkPanel, "Switcher", 0, 0);
        }
        private void AddSwitcher_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;
                btn.DoDragDrop(sender, DragDropEffects.None);
                controller.CreateControl(sender, e, WorkPanel, "Switcher", Convert.ToInt32((Cursor.Position.X - this.Left - 257) * 0.856), Convert.ToInt32((Cursor.Position.Y - this.Top - 82) * 0.864));
            }
        }
        private void AddCheckbox_Click(object sender, EventArgs e)
        {
            controller.CreateControl(sender, e, WorkPanel, "CheckBox", 0, 0);
        }
        private void AddCheckbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;
                btn.DoDragDrop(sender, DragDropEffects.None);
                controller.CreateControl(sender, e, WorkPanel, "CheckBox", Convert.ToInt32((Cursor.Position.X - this.Left - 257) * 0.856), Convert.ToInt32((Cursor.Position.Y - this.Top - 82) * 0.864));
            }
        }
        private void AddText_Click(object sender, EventArgs e)
        {
            controller.CreateControl(sender, e, WorkPanel, "TextBox", 0, 0);
        }
        private void AddText_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;
                btn.DoDragDrop(sender, DragDropEffects.None);
                controller.CreateControl(sender, e, WorkPanel, "TextBox", Convert.ToInt32((Cursor.Position.X - this.Left - 257) * 0.856), Convert.ToInt32((Cursor.Position.Y - this.Top - 82) * 0.864));
            }
        }
        private void AddImage_Click(object sender, EventArgs e)
        {
            controller.CreateControl(sender, e, WorkPanel, "PictureBox", 0, 0);
        }
        private void AddImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;
                btn.DoDragDrop(sender, DragDropEffects.None);
                controller.CreateControl(sender, e, WorkPanel, "PictureBox", Convert.ToInt32((Cursor.Position.X - this.Left - 257) * 0.856), Convert.ToInt32((Cursor.Position.Y - this.Top - 82) * 0.864));
            }
        }
        private void AddUserControl_Click(object sender, EventArgs e)
        {
            controller.CreateControl(sender, e, WorkPanel, "UserControl", 0, 0);
        }
        private void AddUserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;
                btn.DoDragDrop(sender, DragDropEffects.None);
                controller.CreateControl(sender, e, WorkPanel, "UserControl", Cursor.Position.X - this.Left - 257, Cursor.Position.Y - this.Top - 82);
            }
        }
        private void AddValueBox_Click(object sender, EventArgs e)
        {
            controller.CreateControl(sender, e, WorkPanel, "ValueBox", 0, 0);
        }
        private void AddValueBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;
                btn.DoDragDrop(sender, DragDropEffects.None);
                controller.CreateControl(sender, e, WorkPanel, "ValueBox", Convert.ToInt32((Cursor.Position.X - this.Left - 257) * 0.856), Convert.ToInt32((Cursor.Position.Y - this.Top - 82) * 0.864));
            }
        }
        private void WorkPanel_DragDrop(object sender, DragEventArgs e)
        {
            controller.DragDropToPanel(sender, e);
        }
        private void WorkPanel_MouseDown(object sender, MouseEventArgs e)
        {
            controller.Draw(sender, e, WorkPanel, ListOfFigures);
        }
        private void AddLine_Click(object sender, EventArgs e)
        {
            this.AddLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            if (controller.LineIsActive())
                this.AddLine.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        }
        private void AddRectangle_Click(object sender, EventArgs e)
        {
            this.AddLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            if (controller.RectangleIsActive())
                this.AddRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        }
        private void AddEllipse_Click(object sender, EventArgs e)
        {
            this.AddLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            if (controller.EllipseIsActive())
                this.AddEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        }
        private void AddPolygon_Click(object sender, EventArgs e)
        {
            this.AddLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            if (controller.PolygonIsActive())
                this.AddPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
        }
        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (TreeView.SelectedNode != null)
            {
                if (TreeView.SelectedNode.Level > 0 && TreeView.SelectedNode.Parent.Index == 0)
                {
                    controller.SaveCurrentProject(WorkPanel, currentProject);
                    TabWindow.SelectedIndex = 0;
                    controller.LoadSelectedProject(WorkPanel, TreeView.SelectedNode.Index, ListOfControls, ListOfFigures);
                    InterfaceDesigner.ActiveForm.Text = "Interface Designer - " + TreeView.SelectedNode.Text;
                    currentProject = TreeView.SelectedNode.Index + 1;
                }
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            if (cmb != null)
            {
                cmb.Items.Clear();
                for (int i = 0; i < WorkPanel.Controls.Count; i++)
                    cmb.Items.Add(WorkPanel.Controls[i].Name);
            }

            Script.SelectAll();
            Script.ClearSelection();
            Script.Columns.Clear();
            FillElemetsTable();
        }
        private void WorkPanel_Paint(object sender, PaintEventArgs e)
        {
            controller.DrawNet(e);
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            var indexes = new List<Control>();
            int index = 0;
            if (Tables.SelectedTab == DrawControlTabList)
            {
                if (ListOfFigures.SelectedItem != null)
                {
                    controller.DeleteFigure(ListOfFigures.SelectedItem.ToString(), WorkPanel);
                    ListOfFigures.Items.Remove(ListOfFigures.SelectedItem);
                }
            }
            else
            {
                for (int i = 0; i < ListOfControls.SelectedItems.Count; i++)
                {
                    string curItem = ListOfControls.SelectedItems[i].ToString();
                    index = ListOfControls.FindString(curItem);
                    indexes.Add(WorkPanel.Controls[index]);
                }
                object[] listControls = indexes.ToArray();
                foreach (Control ind in listControls)
                {
                    int inde = WorkPanel.Controls.IndexOf(ind);
                    if (inde >= 0)
                    {
                        ListOfControls.Items.RemoveAt(ListOfControls.FindString(WorkPanel.Controls[inde].Name));
                        WorkPanel.Controls.RemoveAt(inde);
                    }
                }
            }
        }
        private void ListOfControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfControls.SelectedItem != null)
            {
                var indexes = new List<Control>();
                for (int i = 0; i < ListOfControls.SelectedItems.Count; i++)
                {
                    string curItem = ListOfControls.SelectedItems[i].ToString();
                    int index = ListOfControls.FindString(curItem);
                    indexes.Add(WorkPanel.Controls[index]);
                }
                object[] listControls = indexes.ToArray();
                PropertyGrid.SelectedObjects = listControls;

            }
        }
        private void ListOfFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfFigures.SelectedItem != null)
                PropertyGrid.SelectedObject = controller.ChangeFigure(ListOfFigures.SelectedItem.ToString());
        }
        private void Horizontal_Click(object sender, EventArgs e)
        {
            if (ListOfControls.SelectedItem != null)
            {
                var indexes = new List<Control>();
                for (int i = 0; i < ListOfControls.SelectedItems.Count; i++)
                {
                    string curItem = ListOfControls.SelectedItems[i].ToString();
                    int index = ListOfControls.FindString(curItem);
                    indexes.Add(WorkPanel.Controls[index]);
                }
                object[] listControls = indexes.ToArray();
                Control ctl = listControls[0] as Control;
                int Yloc = ctl.Location.Y;
                for (int j = 0; j < listControls.Length; j++)
                {
                    Control ctrl = listControls[j] as Control;
                    int Xloc = ctrl.Location.X;
                    ctrl.Location = new System.Drawing.Point(Xloc, Yloc);
                }
            }
        }
        private void Vertical_Click(object sender, EventArgs e)
        {
            if (ListOfControls.SelectedItem != null)
            {
                var indexes = new List<Control>();
                for (int i = 0; i < ListOfControls.SelectedItems.Count; i++)
                {
                    string curItem = ListOfControls.SelectedItems[i].ToString();
                    int index = ListOfControls.FindString(curItem);
                    indexes.Add(WorkPanel.Controls[index]);
                }
                object[] listControls = indexes.ToArray();
                Control ctl = listControls[0] as Control;
                int Xloc = ctl.Location.X;
                for (int j = 0; j < listControls.Length; j++)
                {
                    Control ctrl = listControls[j] as Control;
                    int Yloc = ctrl.Location.Y;
                    ctrl.Location = new System.Drawing.Point(Xloc, Yloc);
                }
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            TabWindow.SelectedIndex = 0;
            if (SaveFile.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = SaveFile.FileName;
            controller.Save(filename, WorkPanel, ScriptsList);
        }
        private void Load_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.Cancel)
                return;
            Toolbox.Enabled = true;
            string filename = OpenFile.FileName;
            WorkPanel.Visible = true;
            controller.SaveCurrentProject(WorkPanel, countControls);
            countControls++;
            currentProject = countControls;
            TreeView.Nodes[0].Nodes.Add("Loaded Project " + countControls);
            TreeView.ExpandAll();
            InterfaceDesigner.ActiveForm.Text = "Interface Designer - " + "Loaded Project " + countControls;
            controller.Load(filename, WorkPanel, ListOfFigures);
            if (countControls == 5)
            {
                Create.Enabled = false;
                Load.Enabled = false;
                CreateBtn.Enabled = false;
                DownloadBtn.Enabled = false;
            }
        }
        private void InterfaceDesigner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                controller.CtrlPressed();
            }
        }
        private void InterfaceDesigner_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                controller.CtrlNotPressed();
            }
        }
        private void EqualHorizontal_Click(object sender, EventArgs e)
        {
            if (ListOfControls.SelectedItem != null)
            {
                var indexes = new List<Control>();
                for (int i = 0; i < ListOfControls.SelectedItems.Count; i++)
                {
                    string curItem = ListOfControls.SelectedItems[i].ToString();
                    int index = ListOfControls.FindString(curItem);
                    indexes.Add(WorkPanel.Controls[index]);
                }
                object[] listControls = indexes.ToArray();
                Control ctl = listControls[0] as Control;
                int Xloc = 0;
                int Yloc = ctl.Location.Y;
                int widthPanel = WorkPanel.Size.Width;
                int offset = widthPanel / (listControls.Length);
                for (int j = 0; j < listControls.Length; j++)
                {
                    Control ctrl = listControls[j] as Control;
                    ctrl.Location = new System.Drawing.Point(Xloc, Yloc);
                    Xloc += offset;
                }
            }
        }
        private void EqualVertical_Click(object sender, EventArgs e)
        {
            if (ListOfControls.SelectedItem != null)
            {
                var indexes = new List<Control>();
                for (int i = 0; i < ListOfControls.SelectedItems.Count; i++)
                {
                    string curItem = ListOfControls.SelectedItems[i].ToString();
                    int index = ListOfControls.FindString(curItem);
                    indexes.Add(WorkPanel.Controls[index]);
                }
                object[] listControls = indexes.ToArray();
                Control ctl = listControls[0] as Control;
                int Yloc = 0;
                int Xloc = ctl.Location.X;
                int heightPanel = WorkPanel.Size.Height;
                int offset = heightPanel / (listControls.Length);
                for (int j = 0; j < listControls.Length; j++)
                {
                    Control ctrl = listControls[j] as Control;
                    ctrl.Location = new System.Drawing.Point(Xloc, Yloc);
                    Yloc += offset;
                }
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            ClearCurrentProject();
        }
        private void Create_Click(object sender, EventArgs e)
        {
            Toolbox.Enabled = true;
            Graphics grph = this.CreateGraphics();
            if (countControls == 0)
            {
                countControls++;
                TreeView.Nodes[0].Nodes.Add("New Project " + countControls);
                TreeView.ExpandAll();
                InterfaceDesigner.ActiveForm.Text = "Interface Designer - New Project " + countControls;
                WorkPanel.Visible = true;
            }
            else
            {
                controller.SaveCurrentProject(WorkPanel, countControls);
                countControls++;
                currentProject = countControls;
                TreeView.Nodes[0].Nodes.Add("New Project " + countControls);
                TreeView.ExpandAll();
                InterfaceDesigner.ActiveForm.Text = "Interface Designer - New Project " + countControls;
                ClearCurrentProject();
                if (countControls == 5)
                {
                    Create.Enabled = false;
                    Load.Enabled = false;
                    CreateBtn.Enabled = false;
                    DownloadBtn.Enabled = false;
                }
            }
        }
        private void ProgramPanel_Paint(object sender, PaintEventArgs e)
        {
            controller.DrawNet(e);
        }
        public void SelectControl(object sender, object[] arraycontrols, bool SingleControl)
        {
            if (SingleControl)
                PropertyGrid.SelectedObject = sender;
            else
                PropertyGrid.SelectedObjects = arraycontrols;
        }
        public void AddToListOfControl(string controlName, bool SingleControl)
        {
            if (SingleControl == true)
                ListOfControls.ClearSelected();
            ListOfControls.SetSelected(ListOfControls.FindString(controlName), true);
        }
        public string GetFileParams()
        {
            string filename = OpenParams.FileName;
            TreeNode NewSources = new TreeNode(filename);
            TreeNodeCollection treeNodeCollection = TreeView.Nodes;
            treeNodeCollection[0].Nodes.Add(NewSources);
            return filename;
        }
        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (Tables.SelectedTab == DrawControlTabList)
            {
                if (ListOfFigures.SelectedItem != null)
                    controller.ValueFigureChanges(WorkPanel, ListOfFigures.SelectedItem.ToString());
            }
        }
        public void ClearCurrentProject()
        {
            WorkPanel.Controls.Clear();
            ListOfControls.Items.Clear();
            controller.DeleteAllFigures(WorkPanel);
            ListOfFigures.Items.Clear();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabWindow.SelectedIndex = 0;
        }
        private void ParamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabWindow.SelectedIndex = 1;
        }
        private void ProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabWindow.SelectedIndex = 2;
        }

        private void WindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        private void FullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        public void SetState(bool state, Type type, int number, string textSwitchOff, string textSwitchOn, Color backColorSwitchOff, Color backColorSwitchOn, Image imageSwitchOff, Image imageSwitchOn)
        {
            if (state)
            {
                if (type == typeof(UserImage))
                {
                    UserImage userImage = WorkPanel.Controls[number] as UserImage;
                    userImage.Image = imageSwitchOn;
                }
                else
                {
                    WorkPanel.Controls[number].BackColor = backColorSwitchOn;
                    WorkPanel.Controls[number].Text = textSwitchOn;
                    if (type == typeof(CheckButton)) WorkPanel.Controls[number].BackgroundImage = imageSwitchOn;
                }
            }
            else
            {
                if (type == typeof(UserImage))
                {
                    UserImage userImage = WorkPanel.Controls[number] as UserImage;
                    userImage.Image = imageSwitchOff;
                }
                else
                {
                    WorkPanel.Controls[number].BackColor = backColorSwitchOff;
                    WorkPanel.Controls[number].Text = textSwitchOff;
                    if (type == typeof(CheckButton)) WorkPanel.Controls[number].BackgroundImage = imageSwitchOff;
                }
            }
        }

        private void ScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TabWindow.SelectedIndex = 3;
        }
        public void FillElemetsTable()
        {
            cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Элемент";
            cmb.Name = "cmb";
            cmb.MaxDropDownItems = 50;
            for (int i = 0; i < WorkPanel.Controls.Count; i++)
            {
                if (WorkPanel.Controls[i].GetType() == typeof(UsersButton) ||
                    WorkPanel.Controls[i].GetType() == typeof(CheckButton))
                    cmb.Items.Add(WorkPanel.Controls[i].Name);
            }

            Script.Columns.Add(cmb);
            cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Цель";
            cmb.Name = "cmb";
            cmb.MaxDropDownItems = 50;
            for (int i = 0; i < WorkPanel.Controls.Count; i++)
            {
                if (WorkPanel.Controls[i].GetType() == typeof(UserSwitcher))
                {
                    UserSwitcher control = WorkPanel.Controls[i] as UserSwitcher;
                    if (control.KernelItem == false)
                        cmb.Items.Add(control.Name);
                }
                if (WorkPanel.Controls[i].GetType() == typeof(UserText))
                    cmb.Items.Add(WorkPanel.Controls[i].Name);
                if (WorkPanel.Controls[i].GetType() == typeof(UserImage))
                {
                    UserImage control = WorkPanel.Controls[i] as UserImage;
                    if (control.KernelItem == false)
                        cmb.Items.Add(control.Name);
                }
            }
            Script.Columns.Add(cmb);

            cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Статус";
            cmb.Name = "stat";
            cmb.MaxDropDownItems = 7;
            cmb.Items.Add("ON");
            cmb.Items.Add("OFF");
            cmb.Items.Add("1");
            cmb.Items.Add("2");
            cmb.Items.Add("3");
            cmb.Items.Add("4");
            cmb.Items.Add("5");
            Script.Columns.Add(cmb);

            DataGridViewButtonColumn accept = new DataGridViewButtonColumn();
            accept.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            accept.Visible = true;
            accept.Text = "Задать";
            accept.Name = "SetScript";
            accept.HeaderText = "Подтвердить";
            accept.UseColumnTextForButtonValue = true;
            Script.Columns.Add(accept);
            Script.Visible = true;
        }

        private void CreateScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FillElemetsTable();
            //TabWindow.SelectedIndex = 3;
            //CreateScriptToolStripMenuItem.Enabled = false;
        }

        private void Script_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                List<string> scriptsData = new List<string>();
                if (Script[0, e.RowIndex].Value != null && Script[1, e.RowIndex].Value != null && Script[2, e.RowIndex].Value != null)
                {
                    scriptsData.Add(currentProject.ToString());
                    scriptsData.Add(Script[0, e.RowIndex].Value.ToString());
                    scriptsData.Add(Script[1, e.RowIndex].Value.ToString());
                    scriptsData.Add(Script[2, e.RowIndex].Value.ToString());
                    ScriptsList.Add(scriptsData.ToArray());
                }
                else
                {
                    MessageBox.Show("Ошибка! Не все поля заполнены!");
                }
            }
        }
        public void AddToScriptList(string[] Scripts)
        {
            ScriptsList.Add(Scripts);
            Script.Rows.Add(Scripts);
        }

        private void BindVariable_Click(object sender, EventArgs e)
        {
            Variables variables = new Variables(VariablesData, this);
            variables.Show();
        }

        public void Bind(int ByteAddress, int BitIndex)
        {
            for (int i = 0; i < WorkPanel.Controls.Count; i++)
                if (WorkPanel.Controls[i].Name == ListOfControls.SelectedItem.ToString())
                {
                    UsersButton usersButton = WorkPanel.Controls[i] as UsersButton;
                    if (usersButton != null)
                    {
                        usersButton.CommonPLCMemoryAddressByte = ByteAddress;
                        usersButton.CommonPLCMemoryBit = BitIndex;
                    }
                    UserSwitcher userSwitcher = WorkPanel.Controls[i] as UserSwitcher;
                    if (userSwitcher != null)
                    {
                        userSwitcher.CommonPLCMemoryAddressByte = ByteAddress;
                        userSwitcher.CommonPLCMemoryBit = BitIndex;
                    }
                    CheckButton checkButton = WorkPanel.Controls[i] as CheckButton;
                    if (checkButton != null)
                    {
                        checkButton.CommonPLCMemoryAddressByte = ByteAddress;
                        checkButton.CommonPLCMemoryBit = BitIndex;
                    }
                    UserImage userImage = WorkPanel.Controls[i] as UserImage;
                    if (userImage != null)
                    {
                        userImage.CommonPLCMemoryAddressByte = ByteAddress;
                        userImage.CommonPLCMemoryBit = BitIndex;
                    }
                    ValueBox valueBox = WorkPanel.Controls[i] as ValueBox;
                    if (valueBox != null)
                    {
                        valueBox.CommonPLCMemoryAddressByte = ByteAddress;
                        valueBox.CommonPLCMemoryBit = BitIndex;
                    }
                }
        }

        private void CreateEvent_Click(object sender, EventArgs e)
        {
            NewScript script = new NewScript(this, WorkPanel, ListOfControls.SelectedItem.ToString());
            script.Show();
        }

        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as ContextMenuStrip).SourceControl != null &&
                ((sender as ContextMenuStrip).SourceControl.GetType() == typeof(UsersButton) ||
                (sender as ContextMenuStrip).SourceControl.GetType() == typeof(CheckButton)))
                CreateEvent.Enabled = true;
            else
                CreateEvent.Enabled = false;
        }
        public void ScriptCreated(string[] arrayScriptParameters)
        {
            ScriptsList.Add(arrayScriptParameters);
            Script.Rows.Add(arrayScriptParameters);
        }

        private void RemoveScript_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptsList.RemoveAt(Script.CurrentRow.Index);
                Script.Rows.RemoveAt(Script.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
