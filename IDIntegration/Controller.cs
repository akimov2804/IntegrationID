using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace InterfaceDesigner
{
    public class Controller
    {
        InterfaceDesigner view;
        Model model;
        public Controller(InterfaceDesigner v, Model m)
        {
            view = v;
            model = m;
            view.setController(this);
        }
        Point MousePositionUp;
        Point MousePositionDown;
        Panel ParentForMouseActivity;
        bool IsCtrlPressed = false;
        List<Control> controls = new List<Control>();
        int countParams = 0;
        bool ActiveLine = false;
        bool ActiveRectangle = false;
        bool ActiveEllipse = false;
        bool ActivePolygon = false;
        bool north = false;
        bool south = false;
        bool west = false;
        bool east = false;
        bool resize = false;
        public void CreateControl (object sender, EventArgs e, Panel Parent,  string typeControl, int OX, int OY)
        {
            if (typeControl == "Button")
            {
                //Button ctrl = new Button();
                UsersButton ctrl = new UsersButton();
                model.GetParametersButton(ctrl, Parent, OX, OY);
                Parent.Controls.Add(ctrl);
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                ctrl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlMouseMove);
                view.AddControl(ctrl);
            }
            if (typeControl == "Switcher")
            {
                //Label ctrl = new Label();
                UserSwitcher ctrl = new UserSwitcher();
                model.GetParametersSwitcher(ctrl, Parent, OX, OY);
                Parent.Controls.Add(ctrl);
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                ctrl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlMouseMove);
                view.AddControl(ctrl);
            }
            if (typeControl == "CheckBox")
            {
                //CheckBox ctrl = new CheckBox();
                CheckButton ctrl = new CheckButton();
                model.GetParametersCheckBox(ctrl, Parent, OX, OY);
                Parent.Controls.Add(ctrl);
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                ctrl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlMouseMove);
                view.AddControl(ctrl);
            }
            if (typeControl == "TextBox")
            {
                //Label ctrl = new Label();
                UserText ctrl = new UserText();
                model.GetParametersTextBox(ctrl, Parent, OX, OY);
                Parent.Controls.Add(ctrl);
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                ctrl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlMouseMove);
                view.AddControl(ctrl);
            }
            if (typeControl == "PictureBox")
            {
                //PictureBox ctrl = new PictureBox();
                UserImage ctrl = new UserImage();
                model.GetParametersPictureBox(ctrl, Parent, OX, OY);
                Parent.Controls.Add(ctrl);
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                ctrl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlMouseMove);
                view.AddControl(ctrl);
            }
            if (typeControl == "ValueBox")
            {
                ValueBox ctrl = new ValueBox();
                model.GetParametersValueBox(ctrl, Parent, OX, OY);
                Parent.Controls.Add(ctrl);
                ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                ctrl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlMouseMove);
                view.AddControl(ctrl);
            }
            ParentForMouseActivity = Parent;
        }
        public void ControlMouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            Rectangle border = new Rectangle(new Point(0, 0), control.Size);
            Rectangle withoutBorder = new Rectangle(3, 3, control.Width - 6, control.Height - 6);
            Rectangle leftBorder = new Rectangle(0, 0, 3, control.Height);
            Rectangle rightBorder = new Rectangle(control.Width - 3, 0, 3, control.Height);
            Rectangle topBorder = new Rectangle(0, 0, control.Width, 3);
            Rectangle bottomBorder = new Rectangle(0, control.Height - 3, control.Width, 3);
            if (border.Contains(e.Location) && !withoutBorder.Contains(e.Location))
            {
                if (rightBorder.Contains(e.Location))                east = true;
                else if (leftBorder.Contains(e.Location))            west = true;
                else if (topBorder.Contains(e.Location))             north = true;
                else                                                 south = true;
                resize = true;
            }
            MousePositionDown = Cursor.Position;
        }
        public void ControlMouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            Rectangle border = new Rectangle(new Point(0, 0), control.Size);
            Rectangle withoutBorder = new Rectangle(3, 3, control.Width - 6, control.Height - 6);
            Rectangle withoutVerticalBorder = new Rectangle(0, 3, control.Width, control.Height - 6);
            Rectangle withoutHorizontalBorder = new Rectangle(3, 0, control.Width - 6, control.Height);
            if (!withoutHorizontalBorder.Contains(e.Location))
                control.Cursor = Cursors.SizeWE;
            else if (!withoutVerticalBorder.Contains(e.Location))
                control.Cursor = Cursors.SizeNS;
            else
                control.Cursor = Cursors.Default;

        }
        public void ControlMouseUp(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            MousePositionUp = Cursor.Position;
            if (MousePositionUp == MousePositionDown)
            {
                if (IsCtrlPressed == false)
                {
                        foreach (Control cnt in ParentForMouseActivity.Controls)
                        {
                            Button tb = cnt as Button;
                            if (tb != null)
                            {
                                tb.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                            }
                            Label label1 = cnt as Label;
                            if (label1 != null)
                            {
                                label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            }
                            CheckBox ckb1 = cnt as CheckBox;
                            if (ckb1 != null)
                            {
                                ckb1.BackColor = System.Drawing.Color.Transparent;
                            }
                            PictureBox pic1 = cnt as PictureBox;
                            if (pic1 != null)
                            {
                                pic1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            }
                            UserSwitcher usersw = cnt as UserSwitcher;
                            if (usersw != null)
                            {
                                usersw.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            }
                            CheckButton usercb = cnt as CheckButton;
                            if (usercb != null)
                            {
                                usercb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            }
                            UsersButton userbtn = cnt as UsersButton;
                            if (userbtn != null)
                            {
                                userbtn.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            }
                            ValueBox valueBox = cnt as ValueBox;
                            if (valueBox != null)
                            {
                                valueBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            }
                            UserText textBox = cnt as UserText;
                            if (textBox != null)
                            {
                                textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            }
                            UserImage userImage = cnt as UserImage;
                            if (userImage != null)
                            {
                                userImage.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            }
                        }
                        view.SelectControl(sender, null, true);
                        if (sender as Button != null)
                        {
                            Button button = sender as Button; button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                        }
                        if (sender as Label != null)
                        {
                            Label label = sender as Label; label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        if (sender as CheckBox != null)
                        {
                            CheckBox checkbox = sender as CheckBox; checkbox.BackColor = System.Drawing.Color.LightGray;
                        }
                        if (sender as PictureBox != null)
                        {
                            PictureBox picturebox = sender as PictureBox; picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        if (sender as UserSwitcher != null)
                        {
                            UserSwitcher userSwitcher = sender as UserSwitcher; userSwitcher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        if (sender as CheckButton != null)
                        {
                            CheckButton checkButton = sender as CheckButton; checkButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        if (sender as UsersButton != null)
                        {
                            UsersButton usersButton = sender as UsersButton; usersButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        if (sender as ValueBox != null)
                        {
                            ValueBox valueBox = sender as ValueBox; valueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        if (sender as UserText != null)
                        {
                            UserText userText = sender as UserText; userText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        if (sender as UserImage != null)
                        {
                            UserImage userImage = sender as UserImage; userImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        view.AddToListOfControl(ParentForMouseActivity.Controls[ParentForMouseActivity.Controls.IndexOf(control)].Name, true);
                    
                }
                else
                {
                    if (control.GetType() == typeof(Button))
                    {
                        Button controlbutton = control as Button;
                        controlbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                    }
                    if (control.GetType() == typeof(Label))
                    {
                        Label controllabel = control as Label;
                        controllabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    if (control.GetType() == typeof(CheckBox))
                    {
                        CheckBox controlcheckbox = control as CheckBox;
                        controlcheckbox.BackColor = System.Drawing.Color.LightGray;
                    }
                    if (control.GetType() == typeof(PictureBox))
                    {
                        PictureBox controlpicturebox = control as PictureBox;
                        controlpicturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    if (control.GetType() == typeof(UserSwitcher))
                    {
                        UserSwitcher userSwitcher = control as UserSwitcher;
                        userSwitcher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    if (control.GetType() == typeof(CheckButton))
                    {
                        CheckButton checkButton = control as CheckButton;
                        checkButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    if (control.GetType() == typeof(UsersButton))
                    {
                        UsersButton usersButton = control as UsersButton;
                        usersButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    if (control.GetType() == typeof(ValueBox))
                    {
                        ValueBox valueBox = control as ValueBox;
                        valueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    if (control.GetType() == typeof(UserText))
                    {
                        UserText textBox = control as UserText;
                        textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    if (control.GetType() == typeof(UserImage))
                    {
                        UserImage userImage = control as UserImage;
                        userImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }
                    controls.Add(control);
                    object[] arrayControls = controls.ToArray();
                    view.SelectControl(sender, arrayControls, false);
                    foreach (Control ind in arrayControls)
                    {
                        int inde = ParentForMouseActivity.Controls.IndexOf(ind);
                        if (inde >= 0)
                            view.AddToListOfControl(ParentForMouseActivity.Controls[inde].Name, false);
                    }
                }
            }
            else
            {
                if (resize)
                {
                    if (east && (MousePositionUp.X - MousePositionDown.X) > - control.Width)
                        control.Width = control.Width + (MousePositionUp.X - MousePositionDown.X);
                    if (south && (MousePositionUp.Y - MousePositionDown.Y) > -control.Height)
                        control.Height = control.Height + (MousePositionUp.Y - MousePositionDown.Y);
                    if (north && (MousePositionUp.Y - MousePositionDown.Y) < control.Height)
                    {
                        control.Location = new Point(control.Location.X, control.Location.Y + (MousePositionUp.Y - MousePositionDown.Y));
                        control.Height = control.Height - (MousePositionUp.Y - MousePositionDown.Y);
                    }
                    if (west && (MousePositionUp.X - MousePositionDown.X) < control.Width)
                    {
                        control.Location = new Point(control.Location.X + (MousePositionUp.X - MousePositionDown.X), control.Location.Y);
                        control.Width = control.Width - (MousePositionUp.X - MousePositionDown.X);
                    }
                    east = false;
                    south = false;
                    north = false;
                    west = false;
                    resize = false; 
                }
                else
                control.DoDragDrop(sender, DragDropEffects.Move);
            }
        }
        public void DragDropToPanel (object sender, DragEventArgs e)
        {
            Panel pan = sender as Panel;
            Point pointDrop = pan.PointToClient(new Point(e.X, e.Y)); //получаем клиентские координаты в момент отпускания кнопки
            model.DragDropFromControl(pan, pointDrop, e);
        }
        public void DrawNet(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int numOfCells = 500;
            int cellSize = 15;
            Pen p = new Pen(Color.LightGray);
            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }
        public void Load(string filename, Panel Parent, ListBox ListOfFigures)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            try
            {
                PropertyControls[] propertyControlsAll = (PropertyControls[])formatter.Deserialize(fileStream);
                foreach (PropertyControls propertyControls in propertyControlsAll)
                {
                    if (propertyControls.type == typeof(Button))
                    {
                        Button ctrl = new Button();
                        model.LoadButtonData(ctrl, propertyControls);
                        Parent.Controls.Add(ctrl);
                        ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(ctrl);
                    }
                    if (propertyControls.type == typeof(CheckBox))
                    {
                        CheckBox ctrl = new CheckBox();
                        model.LoadCheckBoxData(ctrl, propertyControls);
                        Parent.Controls.Add(ctrl);
                        ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(ctrl);
                    }
                    if (propertyControls.type == typeof(PictureBox))
                    {
                        PictureBox ctrl = new PictureBox();
                        model.LoadPictureBoxData(ctrl, propertyControls);
                        Parent.Controls.Add(ctrl);
                        ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(ctrl);
                    }
                    if (propertyControls.type == typeof(ValueBox))
                    {
                        ValueBox ctrl = new ValueBox();
                        model.LoadValueBoxData(ctrl, propertyControls);
                        Parent.Controls.Add(ctrl);
                        ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(ctrl);
                    }
                    if (propertyControls.type == typeof(UserText))
                    {
                        UserText ctrl = new UserText();
                        model.LoadTextBoxData(ctrl, propertyControls);
                        Parent.Controls.Add(ctrl);
                        ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(ctrl);
                    }
                    if (propertyControls.type == typeof(UserImage))
                    {
                        UserImage ctrl = new UserImage();
                        model.LoadImageBoxData(ctrl, propertyControls);
                        Parent.Controls.Add(ctrl);
                        ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(ctrl);
                    }
                    if (propertyControls.type == typeof(Label))
                    {
                        if (propertyControls.name.Contains("Switcher"))
                        {
                            Label ctrl = new Label();
                            model.LoadSwitcherData(ctrl, propertyControls);
                            Parent.Controls.Add(ctrl);
                            ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                            ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                            view.AddControl(ctrl);
                        }
                        if (propertyControls.name.Contains("TextBox"))
                        {
                            Label ctrl = new Label();
                            model.LoadTextBoxData(ctrl, propertyControls);
                            Parent.Controls.Add(ctrl);
                            ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                            ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                            view.AddControl(ctrl);
                        }
                    }
                    if (propertyControls.type == typeof(UserSwitcher))
                    {
                        UserSwitcher userSwitcher = new UserSwitcher();
                        model.LoadUserSwitcherData(userSwitcher, propertyControls);
                        Parent.Controls.Add(userSwitcher);
                        userSwitcher.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        userSwitcher.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(userSwitcher);
                    }
                    if (propertyControls.type == typeof(CheckButton))
                    {
                        CheckButton checkButton = new CheckButton();
                        model.LoadCheckButtonData(checkButton, propertyControls);
                        Parent.Controls.Add(checkButton);
                        checkButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        checkButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(checkButton);
                    }
                    if (propertyControls.type == typeof(UsersButton))
                    {
                        UsersButton usersButton = new UsersButton();
                        model.LoadUsersButtonData(usersButton, propertyControls);
                        Parent.Controls.Add(usersButton);
                        usersButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlMouseDown);
                        usersButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlMouseUp);
                        view.AddControl(usersButton);
                    }
                }
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize figures. Reason: " + e.Message);
            }
            try
            {
                Figures[] figuresList = (Figures[])formatter.Deserialize(fileStream);
                foreach (Figures figures in figuresList)
                {
                    Image img = Parent.BackgroundImage ?? new Bitmap(Parent.Width, Parent.Height);
                    Graphics g = Graphics.FromImage(img);
                    Pen BlackPen = new Pen(Color.Black, 2);
                    string[] NamesOfFigures = model.LoadFigures(g, BlackPen, figures);
                    for (int i = 0; i < NamesOfFigures.Length; i++)
                        ListOfFigures.Items.Add(NamesOfFigures[i]);
                    g.Flush();
                    Parent.BackgroundImage = img;
                    Parent.Refresh();
                    g.Dispose();
                }
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize figures. Reason: " + e.Message);
            }
            try
            {
                List<string[]> scriptsList = (List<string[]>)formatter.Deserialize(fileStream);
                foreach (string[] scripts in scriptsList)
                {
                    view.AddToScriptList(scripts);
                }
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize figures. Reason: " + e.Message);
            }
            if (fileStream.Position == fileStream.Length)
                fileStream.Close();
            ParentForMouseActivity = Parent;
        }
        public void Save(string filename, Panel Parent, List<string[]> ScriptsList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            PropertyControls[] propertyControlsAll = model.SaveData(Parent);
            formatter.Serialize(fileStream, propertyControlsAll);
            Figures[] figuresOfProject = model.SaveFigures();
            formatter.Serialize(fileStream, figuresOfProject);
            formatter.Serialize(fileStream, ScriptsList);
            fileStream.Close();
        }
        public void CtrlPressed()
        {
            IsCtrlPressed = true;
        }
        public void CtrlNotPressed()
        {
            IsCtrlPressed = false;
        }
        public void Draw(object sender, MouseEventArgs e, Panel Parent, ListBox Figures)
        {
            Image img = Parent.BackgroundImage ?? new Bitmap(Parent.Width, Parent.Height);
            Graphics g = Graphics.FromImage(img);
            Pen BlackPen = new Pen(Color.Black, 2);
            string Figure = "";
            if (ActiveLine)
                Figure = model.DrawLine(e, g, img, BlackPen);
            if (ActiveRectangle)
                Figure = model.DrawRectangle(e, g, img, BlackPen);
            if (ActiveEllipse)
                Figure = model.DrawEllipse(e, g, img, BlackPen);
            if (ActivePolygon)
                Figure = model.DrawPolygon(e, g, img, BlackPen);
            if (Figure != null && Figure != "")
            {
                Figures.Items.Add(Figure);
                g.Flush();
                Parent.BackgroundImage = img;
                Parent.Refresh();
                g.Dispose();
            }
        }
        public bool LineIsActive()
        {
            if (ActiveLine == false)
            {
                ActiveRectangle = false;
                ActiveLine = true;
                ActiveEllipse = false;
                ActivePolygon = false;
                return true;
            }
            else
            {
                ActiveLine = false;
                return false;
            }
        }
        public bool RectangleIsActive()
        {
            if (ActiveRectangle == false)
            {
                ActiveRectangle = true;
                ActiveLine = false;
                ActiveEllipse = false;
                ActivePolygon = false;
                return true;
            }
            else
            {
                ActiveRectangle = false;
                return false;
            }
        }
        public bool EllipseIsActive()
        {
            if (ActiveEllipse == false)
            {
                ActiveRectangle = false;
                ActiveLine = false;
                ActiveEllipse = true;
                ActivePolygon = false;
                return true;
            }
            else
            {
                ActiveEllipse = false;
                return false;
            }
        }
        public bool PolygonIsActive()
        {
            if (ActivePolygon == false)
            {
                ActiveRectangle = false;
                ActiveLine = false;
                ActiveEllipse = false;
                ActivePolygon = true;
                return true;
            }
            else
            {
                ActivePolygon = false;
                return false;
            }
        }
        public void SaveCurrentProject(Panel Parent, int Project)
        {
            model.SaveCurrentProject(Parent, Project);
            view.ClearCurrentProject();
        }
        public void LoadSelectedProject(Panel Parent, int SelectedProject, ListBox ListOfControls, ListBox ListOfFigures)
        {
            Image img = Parent.BackgroundImage ?? new Bitmap(Parent.Width, Parent.Height);
            Graphics g = Graphics.FromImage(img);
            if (SelectedProject != 0)
                view.ClearCurrentProject();
            string[] NamesControls = model.AddControlsToSelectedProject(Parent, SelectedProject);
            for (int i = 0; i < NamesControls.Length; i++)
                ListOfControls.Items.Add(NamesControls[i]);
            string[] NamesLines = model.AddLinesToSelectedProject(SelectedProject , g);
            for (int i = 0; i < NamesLines.Length; i++)
                ListOfFigures.Items.Add(NamesLines[i]);
            string[] NamesRectangles = model.AddRectanglesToSelectedProject(SelectedProject, g);
            for (int i = 0; i < NamesRectangles.Length; i++)
                ListOfFigures.Items.Add(NamesRectangles[i]);
            string[] NamesEllipses = model.AddEllipsesToSelectedProject(SelectedProject, g);
            for (int i = 0; i < NamesEllipses.Length; i++)
                ListOfFigures.Items.Add(NamesEllipses[i]);
            string[] NamesPolygons = model.AddPolygonsToSelectedProject(SelectedProject, g);
            for (int i = 0; i < NamesPolygons.Length; i++)
                ListOfFigures.Items.Add(NamesPolygons[i]);
            g.Flush();
            Parent.BackgroundImage = img;
            Parent.Refresh();
            g.Dispose();
        }
        public void DeleteFigure(string SelectedFigure, Panel Parent)
        {
            Image img = Parent.BackgroundImage ?? new Bitmap(Parent.Width, Parent.Height);
            Graphics g = Graphics.FromImage(img);
            Pen WhitePen = new Pen(Color.White, 2);
            string typeFigure = "";
            if (SelectedFigure.Contains("Line"))         typeFigure = "Line";
            if (SelectedFigure.Contains("Rectangle"))    typeFigure = "Rectangle";
            if (SelectedFigure.Contains("Ellipse"))      typeFigure = "Ellipse";
            if (SelectedFigure.Contains("Polygon"))      typeFigure = "Polygon";
            if (typeFigure != "")
            {
                model.DeleteFigure(g, WhitePen, Int32.Parse(SelectedFigure.Split('_').Last()) - 1, typeFigure);
                g.Flush();
                Parent.BackgroundImage = img;
                Parent.Refresh();
                g.Dispose();
            }
        }
        public object ChangeFigure(string SeletedFigure)
        {
            if (SeletedFigure.Contains("Line"))         return model.ChangeFigure(SeletedFigure, "Line");
            if (SeletedFigure.Contains("Rectangle"))    return model.ChangeFigure(SeletedFigure, "Rectangle");
            if (SeletedFigure.Contains("Ellipse"))      return model.ChangeFigure(SeletedFigure, "Ellipse");
            if (SeletedFigure.Contains("Polygon"))      return model.ChangeFigure(SeletedFigure, "Polygon");
            else                                        return null;
        }
        public void DeleteAllFigures(Panel Parent)
        {
            Image img = Parent.BackgroundImage ?? new Bitmap(Parent.Width, Parent.Height);
            Graphics g = Graphics.FromImage(img);
            Pen WhitePen = new Pen(Color.White, 2);
            model.DeleteAllFigure(g, WhitePen);
            g.Flush();
            Parent.BackgroundImage = img;
            Parent.Refresh();
            g.Dispose();
        }
        public void ValueFigureChanges(Panel Parent, string SelectedFigure)
        {
            Image img = Parent.BackgroundImage ?? new Bitmap(Parent.Width, Parent.Height);
            Graphics g = Graphics.FromImage(img);
            Pen WhitePen = new Pen(Color.White, 2);
            Pen BlackPen = new Pen(Color.Black, 2);
            string typeFigure = "";
            if (SelectedFigure.Contains("Line"))        typeFigure = "Line";
            if (SelectedFigure.Contains("Rectangle"))   typeFigure = "Rectangle";
            if (SelectedFigure.Contains("Ellipse"))     typeFigure = "Ellipse";
            if (SelectedFigure.Contains("Polygon"))     typeFigure = "Polygon";
            if (typeFigure != "")
            {
                model.Redraw(g, WhitePen, BlackPen, Int32.Parse(SelectedFigure.Split('_').Last()) - 1, typeFigure);
                g.Flush();
                Parent.BackgroundImage = img;
                Parent.Refresh();
                g.Dispose();
            }
        }
        public void Update(Panel Parent)
        {
            model.Update(Parent);
        }
        public void SendControls(Panel Source, Panel Destination)
        {
            for (int i = 0; i < Source.Controls.Count; i++)
            {
                Destination.Controls.Add(Source.Controls[i]);
            }
        }
        public void SendFigures(Panel Parent)
        {
            Image img = Parent.BackgroundImage ?? new Bitmap(Parent.Width, Parent.Height);
            Graphics g = Graphics.FromImage(img);
            Pen BlackPen = new Pen(Color.Black, 2);
            model.DeleteAllFigure(g, BlackPen);
            g.Flush();
            Parent.BackgroundImage = img;
            Parent.Refresh();
            g.Dispose();
        }
    }
}
