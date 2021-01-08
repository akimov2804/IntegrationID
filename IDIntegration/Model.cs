using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InterfaceDesigner
{
    public class Model
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////// переменные для рисования графических объектов/////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool isFirstPointSet = false;
        private Point firstPoint;
        private Pen pen = new Pen(Color.Black, 2);
        List<Point> points = new List<Point>();
        List<Point> PolygonPoints = new List<Point>();
        List<Point[]> PolygonPointList = new List<Point[]>();
        List<Point> Line = new List<Point>();
        List<Point> Lines = new List<Point>();
        List<int> RectanglePoint = new List<int>();
        List<Point[]> LineList = new List<Point[]>();
        List<Point[]> ListLine = new List<Point[]>();
        List<int[]> RectangleList = new List<int[]>();
        List<Rectangle> ListEllipse = new List<Rectangle>();
        List<int> EllipsePoint = new List<int>();
        Rectangle rectangle = new Rectangle();
        List<Rectangle> ListRectangles = new List<Rectangle>();
        List<int[]> ellipseList = new List<int[]>();
        Point[] polygon;
        List<Point[]> polygonList = new List<Point[]>();
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////// переменные для работы с несколькими проектами/////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        List<Control> controlList1 = new List<Control>();
        List<Control> controlList2 = new List<Control>();
        List<Control> controlList3 = new List<Control>();
        List<Control> controlList4 = new List<Control>();
        List<Control> controlList5 = new List<Control>();

        List<Point[]> LinesProject1 = new List<Point[]>();
        List<Point[]> LinesProject2 = new List<Point[]>();
        List<Point[]> LinesProject3 = new List<Point[]>();
        List<Point[]> LinesProject4 = new List<Point[]>();
        List<Point[]> LinesProject5 = new List<Point[]>();

        List<int[]> RectanglesProject1 = new List<int[]>();
        List<int[]> RectanglesProject2 = new List<int[]>();
        List<int[]> RectanglesProject3 = new List<int[]>();
        List<int[]> RectanglesProject4 = new List<int[]>();
        List<int[]> RectanglesProject5 = new List<int[]>();

        List<int[]> EllipsesProject1 = new List<int[]>();
        List<int[]> EllipsesProject2 = new List<int[]>();
        List<int[]> EllipsesProject3 = new List<int[]>();
        List<int[]> EllipsesProject4 = new List<int[]>();
        List<int[]> EllipsesProject5 = new List<int[]>();

        List<Point[]> PolygonsProject1 = new List<Point[]>();
        List<Point[]> PolygonsProject2 = new List<Point[]>();
        List<Point[]> PolygonsProject3 = new List<Point[]>();
        List<Point[]> PolygonsProject4 = new List<Point[]>();
        List<Point[]> PolygonsProject5 = new List<Point[]>();
        public Model()
        {
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Control WorkPanelForMouseActivity;
        //public void GetParametersButton(Button button, Control Parent, int OX, int OY)
        //{
        //    button.Location = new Point(OX, OY); //расположение
        //    button.Size = new Size(60, 50); // размер
        //    button.Text = "Button"; //текст
        //    button.Name = "Button_" + Parent.Controls.Count;
        //    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //    button.FlatAppearance.BorderColor = Color.DarkGray;
        //    button.BackColor = Color.LightGray;
        //    WorkPanelForMouseActivity = Parent;
        //}
        public void GetParametersButton(UsersButton button, Control Parent, int OX, int OY)
        {
            button.Location = new Point(OX, OY); //расположение
            button.Name = "Button_" + Parent.Controls.Count;
            WorkPanelForMouseActivity = Parent;
        }
        /*
        public void GetParametersSwitcher(Label label, Control Parent, int OX, int OY)
        {
            label.Location = new Point(OX, OY); //расположение
            label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.BackColor = System.Drawing.Color.Red;
            label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label.Size = new Size(60, 50); // размер
            label.Text = "OFF"; //текст
            label.Name = "Switcher" + Parent.Controls.Count;
            WorkPanelForMouseActivity = Parent;
        }
        */
        public void GetParametersSwitcher(UserSwitcher switcher, Control Parent, int OX, int OY)
        {
            switcher.Location = new Point(OX, OY); //расположение
            switcher.Name = "Switcher_" + Parent.Controls.Count;
            WorkPanelForMouseActivity = Parent;
        }
        /*
        public void GetParametersCheckBox(CheckBox checkBox, Control Parent, int OX, int OY)
        {
            checkBox.Location = new Point(OX, OY); //расположение
            checkBox.Text = "CheckBox"; //текст
            checkBox.Name = "CheckBox" + Parent.Controls.Count;
            WorkPanelForMouseActivity = Parent;
        }
        */
        public void GetParametersCheckBox(CheckButton checkButton, Control Parent, int OX, int OY)
        {
            checkButton.Location = new Point(OX, OY); //расположение
            checkButton.Name = "CheckBox_" + Parent.Controls.Count;
            WorkPanelForMouseActivity = Parent;
        }
        //public void GetParametersTextBox(Label textBox, Control Parent, int OX, int OY)
        //{
        //    textBox.Location = new Point(OX, OY); //расположение
        //    textBox.Text = "Text"; //текст
        //    textBox.Name = "TextBox_" + Parent.Controls.Count;
        //    WorkPanelForMouseActivity = Parent;
        //}
        public void GetParametersTextBox(UserText textBox, Control Parent, int OX, int OY)
        {
            textBox.Location = new Point(OX, OY); //расположение
            textBox.Text = "Text"; //текст
            textBox.Name = "TextBox_" + Parent.Controls.Count;
            WorkPanelForMouseActivity = Parent;
        }
        //public void GetParametersPictureBox(PictureBox pictureBox, Control Parent, int OX, int OY)
        //{
        //    pictureBox.Location = new Point(OX, OY); //расположение
        //    pictureBox.Size = new System.Drawing.Size(144, 116);
        //    pictureBox.Name = "Image_" + Parent.Controls.Count;
        //    pictureBox.Image = global::InterfaceDesigner.Properties.Resources.Без_названия;
        //    pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        //    WorkPanelForMouseActivity = Parent;
        //}
        public void GetParametersPictureBox(UserImage pictureBox, Control Parent, int OX, int OY)
        {
            pictureBox.Location = new Point(OX, OY); //расположение
            pictureBox.Name = "Image_" + Parent.Controls.Count;
            WorkPanelForMouseActivity = Parent;
        }
        public void GetParametersValueBox(ValueBox valueBox, Control Parent, int OX, int OY)
        {
            valueBox.Location = new Point(OX, OY); //расположение
            valueBox.Name = "ValueBox_" + Parent.Controls.Count;
            WorkPanelForMouseActivity = Parent;
        }
        public void DragDropFromControl(Panel pan, Point pointDrop, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)))
            {
                Button btn = (Button)e.Data.GetData(typeof(Button)); //извлекаем кнопку
                btn.Location = pointDrop;
                btn.Parent = pan; //установка панели в качестве родителя для нашей кнопки
            }
            if (e.Data.GetDataPresent(typeof(Label)))
            {
                Label lbl = (Label)e.Data.GetData(typeof(Label));
                lbl.Location = pointDrop;
                lbl.Parent = pan;
            }
            if (e.Data.GetDataPresent(typeof(CheckBox)))
            {
                CheckBox ckb = (CheckBox)e.Data.GetData(typeof(CheckBox));
                ckb.Location = pointDrop;
                ckb.Parent = pan;
            }
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                PictureBox pic = (PictureBox)e.Data.GetData(typeof(PictureBox));
                pic.Location = pointDrop;
                pic.Parent = pan;
            }
            if (e.Data.GetDataPresent(typeof(UserSwitcher)))
            {
                UserSwitcher usersw = (UserSwitcher)e.Data.GetData(typeof(UserSwitcher));
                usersw.Location = pointDrop;
                usersw.Parent = pan;
            }
            if (e.Data.GetDataPresent(typeof(CheckButton)))
            {
                CheckButton usercb = (CheckButton)e.Data.GetData(typeof(CheckButton));
                usercb.Location = pointDrop;
                usercb.Parent = pan;
            }
            if (e.Data.GetDataPresent(typeof(UsersButton)))
            {
                UsersButton usercb = (UsersButton)e.Data.GetData(typeof(UsersButton));
                usercb.Location = pointDrop;
                usercb.Parent = pan;
            }
            if (e.Data.GetDataPresent(typeof(ValueBox)))
            {
                ValueBox valueBox = (ValueBox)e.Data.GetData(typeof(ValueBox));
                valueBox.Location = pointDrop;
                valueBox.Parent = pan;
            }
            if (e.Data.GetDataPresent(typeof(UserText)))
            {
                UserText userText = (UserText)e.Data.GetData(typeof(UserText));
                userText.Location = pointDrop;
                userText.Parent = pan;
            }
            if (e.Data.GetDataPresent(typeof(UserImage)))
            {
                UserImage userImage = (UserImage)e.Data.GetData(typeof(UserImage));
                userImage.Location = pointDrop;
                userImage.Parent = pan;
            }
        }
        public void LoadButtonData(Button btn, PropertyControls propertyControls)
        {
            btn.Location = propertyControls.location; //расположение
            btn.Size = propertyControls.size; // размер
            btn.Text = propertyControls.text; //текст
            btn.Name = propertyControls.name;
            btn.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            btn.AccessibleDescription = propertyControls.accessibleDescription;
            btn.AccessibleName = propertyControls.accessibleName;
            btn.AccessibleRole = propertyControls.accessibleRole;
            btn.AllowDrop = propertyControls.allowDrop;
            btn.Anchor = propertyControls.anchor;
            btn.AutoScrollOffset = propertyControls.autoScrollOffset;
            btn.BackColor = propertyControls.backColor;
            btn.BackgroundImage = propertyControls.backgroundImage;
            btn.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            btn.Bounds = propertyControls.bounds;
            btn.Capture = propertyControls.capture;
            btn.CausesValidation = propertyControls.causesValidation;
            btn.ClientSize = propertyControls.clientSize;
            btn.Cursor = propertyControls.cursor;
            btn.Enabled = propertyControls.enabled;
            btn.FlatStyle = propertyControls.flatStyle;
            btn.Font = propertyControls.font;
            btn.ForeColor = propertyControls.foreColor;
            btn.Height = propertyControls.height;
            btn.IsAccessible = propertyControls.isAccessible;
            btn.Left = propertyControls.left;
            btn.Margin = propertyControls.margin;
            btn.MaximumSize = propertyControls.maximumSize;
            btn.MinimumSize = propertyControls.minimumSize;
            btn.Padding = propertyControls.padding;
            btn.TabIndex = propertyControls.tabIndex;
            btn.TabStop = propertyControls.tabStop;
            btn.Tag = propertyControls.tag;
            btn.Top = propertyControls.top;
            btn.UseWaitCursor = propertyControls.useWaitCursor;
            btn.Visible = propertyControls.visible;
            btn.Width = propertyControls.width;
        }
        public void LoadSwitcherData(Label lbl, PropertyControls propertyControls)
        {
            lbl.Location = propertyControls.location; //расположение
            lbl.Font = propertyControls.font;
            lbl.TextAlign = propertyControls.textAlign;
            lbl.BackColor = propertyControls.backColor;
            lbl.ForeColor = propertyControls.foreColor;
            lbl.Size = propertyControls.size; // размер
            lbl.Text = propertyControls.text; //текст
            lbl.Name = propertyControls.name;
            lbl.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            lbl.AccessibleDescription = propertyControls.accessibleDescription;
            lbl.AccessibleName = propertyControls.accessibleName;
            lbl.AccessibleRole = propertyControls.accessibleRole;
            lbl.AllowDrop = propertyControls.allowDrop;
            lbl.Anchor = propertyControls.anchor;
            lbl.AutoScrollOffset = propertyControls.autoScrollOffset;
            lbl.BackColor = propertyControls.backColor;
            lbl.BackgroundImage = propertyControls.backgroundImage;
            lbl.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            lbl.Bounds = propertyControls.bounds;
            lbl.Capture = propertyControls.capture;
            lbl.CausesValidation = propertyControls.causesValidation;
            lbl.ClientSize = propertyControls.clientSize;
            lbl.Cursor = propertyControls.cursor;
            lbl.Enabled = propertyControls.enabled;
            lbl.Font = propertyControls.font;
            lbl.ForeColor = propertyControls.foreColor;
            lbl.Height = propertyControls.height;
            lbl.IsAccessible = propertyControls.isAccessible;
            lbl.Left = propertyControls.left;
            lbl.Margin = propertyControls.margin;
            lbl.MaximumSize = propertyControls.maximumSize;
            lbl.MinimumSize = propertyControls.minimumSize;
            lbl.Padding = propertyControls.padding;
            lbl.TabIndex = propertyControls.tabIndex;
            lbl.TabStop = propertyControls.tabStop;
            lbl.Tag = propertyControls.tag;
            lbl.Top = propertyControls.top;
            lbl.UseWaitCursor = propertyControls.useWaitCursor;
            lbl.Visible = propertyControls.visible;
            lbl.Width = propertyControls.width;
        }
        public void LoadCheckBoxData(CheckBox ckb, PropertyControls propertyControls)
        {
            ckb.Location = propertyControls.location; //расположение
            ckb.Text = propertyControls.text; //текст
            ckb.Name = propertyControls.name;
            ckb.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            ckb.AccessibleDescription = propertyControls.accessibleDescription;
            ckb.AccessibleName = propertyControls.accessibleName;
            ckb.AccessibleRole = propertyControls.accessibleRole;
            ckb.AllowDrop = propertyControls.allowDrop;
            ckb.Anchor = propertyControls.anchor;
            ckb.AutoScrollOffset = propertyControls.autoScrollOffset;
            ckb.BackColor = propertyControls.backColor;
            ckb.BackgroundImage = propertyControls.backgroundImage;
            ckb.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            ckb.Bounds = propertyControls.bounds;
            ckb.Capture = propertyControls.capture;
            ckb.CausesValidation = propertyControls.causesValidation;
            ckb.ClientSize = propertyControls.clientSize;
            ckb.Cursor = propertyControls.cursor;
            ckb.Enabled = propertyControls.enabled;
            ckb.Font = propertyControls.font;
            ckb.ForeColor = propertyControls.foreColor;
            ckb.Height = propertyControls.height;
            ckb.IsAccessible = propertyControls.isAccessible;
            ckb.Left = propertyControls.left;
            ckb.Margin = propertyControls.margin;
            ckb.MaximumSize = propertyControls.maximumSize;
            ckb.MinimumSize = propertyControls.minimumSize;
            ckb.Padding = propertyControls.padding;
            ckb.TabIndex = propertyControls.tabIndex;
            ckb.TabStop = propertyControls.tabStop;
            ckb.Tag = propertyControls.tag;
            ckb.Top = propertyControls.top;
            ckb.UseWaitCursor = propertyControls.useWaitCursor;
            ckb.Visible = propertyControls.visible;
            ckb.Width = propertyControls.width;
        }
        public void LoadTextBoxData(Label lbl, PropertyControls propertyControls)
        {
            lbl.Location = propertyControls.location; //расположение
            lbl.Text = propertyControls.text; //текст
            lbl.Name = propertyControls.name;
            lbl.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            lbl.AccessibleDescription = propertyControls.accessibleDescription;
            lbl.AccessibleName = propertyControls.accessibleName;
            lbl.AccessibleRole = propertyControls.accessibleRole;
            lbl.AllowDrop = propertyControls.allowDrop;
            lbl.Anchor = propertyControls.anchor;
            lbl.AutoScrollOffset = propertyControls.autoScrollOffset;
            lbl.BackColor = propertyControls.backColor;
            lbl.BackgroundImage = propertyControls.backgroundImage;
            lbl.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            lbl.Bounds = propertyControls.bounds;
            lbl.Capture = propertyControls.capture;
            lbl.CausesValidation = propertyControls.causesValidation;
            lbl.ClientSize = propertyControls.clientSize;
            lbl.Cursor = propertyControls.cursor;
            lbl.Enabled = propertyControls.enabled;
            lbl.Font = propertyControls.font;
            lbl.ForeColor = propertyControls.foreColor;
            lbl.Height = propertyControls.height;
            lbl.IsAccessible = propertyControls.isAccessible;
            lbl.Left = propertyControls.left;
            lbl.Margin = propertyControls.margin;
            lbl.MaximumSize = propertyControls.maximumSize;
            lbl.MinimumSize = propertyControls.minimumSize;
            lbl.Padding = propertyControls.padding;
            lbl.TabIndex = propertyControls.tabIndex;
            lbl.TabStop = propertyControls.tabStop;
            lbl.Tag = propertyControls.tag;
            lbl.Top = propertyControls.top;
            lbl.UseWaitCursor = propertyControls.useWaitCursor;
            lbl.Visible = propertyControls.visible;
            lbl.Width = propertyControls.width;
        }
        public void LoadPictureBoxData(PictureBox pic, PropertyControls propertyControls)
        {
            pic.Location = propertyControls.location;
            pic.Size = propertyControls.size;
            pic.Name = propertyControls.name;
            pic.Image = propertyControls.image;
            pic.SizeMode = propertyControls.sizeMode;
            pic.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            pic.AccessibleDescription = propertyControls.accessibleDescription;
            pic.AccessibleName = propertyControls.accessibleName;
            pic.AccessibleRole = propertyControls.accessibleRole;
            pic.AllowDrop = propertyControls.allowDrop;
            pic.Anchor = propertyControls.anchor;
            pic.AutoScrollOffset = propertyControls.autoScrollOffset;
            pic.BackColor = propertyControls.backColor;
            pic.BackgroundImage = propertyControls.backgroundImage;
            pic.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            pic.Bounds = propertyControls.bounds;
            pic.Capture = propertyControls.capture;
            pic.CausesValidation = propertyControls.causesValidation;
            pic.ClientSize = propertyControls.clientSize;
            pic.Cursor = propertyControls.cursor;
            pic.Enabled = propertyControls.enabled;
            pic.Font = propertyControls.font;
            pic.ForeColor = propertyControls.foreColor;
            pic.Height = propertyControls.height;
            pic.IsAccessible = propertyControls.isAccessible;
            pic.Left = propertyControls.left;
            pic.Margin = propertyControls.margin;
            pic.MaximumSize = propertyControls.maximumSize;
            pic.MinimumSize = propertyControls.minimumSize;
            pic.Padding = propertyControls.padding;
            pic.TabIndex = propertyControls.tabIndex;
            pic.TabStop = propertyControls.tabStop;
            pic.Tag = propertyControls.tag;
            pic.Top = propertyControls.top;
            pic.UseWaitCursor = propertyControls.useWaitCursor;
            pic.Visible = propertyControls.visible;
            pic.Width = propertyControls.width;
        }
        public void LoadUserSwitcherData(UserSwitcher userSwitcher, PropertyControls propertyControls)
        {
            userSwitcher.Location = propertyControls.location; //расположение
            userSwitcher.Size = propertyControls.size; // размер
            userSwitcher.Name = propertyControls.name;
            userSwitcher.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            userSwitcher.AccessibleDescription = propertyControls.accessibleDescription;
            userSwitcher.AccessibleName = propertyControls.accessibleName;
            userSwitcher.AccessibleRole = propertyControls.accessibleRole;
            userSwitcher.AllowDrop = propertyControls.allowDrop;
            userSwitcher.Anchor = propertyControls.anchor;
            userSwitcher.AutoScrollOffset = propertyControls.autoScrollOffset;
            userSwitcher.BackColor = propertyControls.backColor;
            userSwitcher.BackgroundImage = propertyControls.backgroundImage;
            userSwitcher.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            userSwitcher.Bounds = propertyControls.bounds;
            userSwitcher.Capture = propertyControls.capture;
            userSwitcher.CausesValidation = propertyControls.causesValidation;
            userSwitcher.ClientSize = propertyControls.clientSize;
            userSwitcher.Cursor = propertyControls.cursor;
            userSwitcher.Enabled = propertyControls.enabled;
            userSwitcher.Font = propertyControls.font;
            userSwitcher.ForeColor = propertyControls.foreColor;
            userSwitcher.Height = propertyControls.height;
            userSwitcher.IsAccessible = propertyControls.isAccessible;
            userSwitcher.Left = propertyControls.left;
            userSwitcher.Margin = propertyControls.margin;
            userSwitcher.MaximumSize = propertyControls.maximumSize;
            userSwitcher.MinimumSize = propertyControls.minimumSize;
            userSwitcher.Padding = propertyControls.padding;
            userSwitcher.TabIndex = propertyControls.tabIndex;
            userSwitcher.TabStop = propertyControls.tabStop;
            userSwitcher.Tag = propertyControls.tag;
            userSwitcher.Top = propertyControls.top;
            userSwitcher.UseWaitCursor = propertyControls.useWaitCursor;
            userSwitcher.Visible = propertyControls.visible;
            userSwitcher.Width = propertyControls.width;
            userSwitcher.CommonPLCMemoryAddressByte = propertyControls.CommonPLCMemoryAddressByte;
            userSwitcher.CommonPLCMemoryBit = propertyControls.CommonPLCMemoryBit;
            userSwitcher.ColorSwitchOFF = propertyControls.ColorSwitchOFF;
            userSwitcher.ColorSwitchON = propertyControls.ColorSwitchON;
            userSwitcher.TextSwitchOFF = propertyControls.TextSwitchOFF;
            userSwitcher.TextSwitchON = propertyControls.TextSwitchON;
            userSwitcher.TextValue = propertyControls.TextValue;
            userSwitcher.ColorValue = propertyControls.ColorValue;
            userSwitcher.ItemOfKernel = propertyControls.ItemOfKernel;
            userSwitcher.State = propertyControls.state;
        }
        public void LoadCheckButtonData(CheckButton checkButton, PropertyControls propertyControls)
        {
            checkButton.Location = propertyControls.location; //расположение
            checkButton.Size = propertyControls.size; // размер
            checkButton.Name = propertyControls.name;
            checkButton.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            checkButton.AccessibleDescription = propertyControls.accessibleDescription;
            checkButton.AccessibleName = propertyControls.accessibleName;
            checkButton.AccessibleRole = propertyControls.accessibleRole;
            checkButton.AllowDrop = propertyControls.allowDrop;
            checkButton.Anchor = propertyControls.anchor;
            checkButton.AutoScrollOffset = propertyControls.autoScrollOffset;
            checkButton.BackColor = propertyControls.backColor;
            checkButton.BackgroundImage = propertyControls.backgroundImage;
            checkButton.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            checkButton.Bounds = propertyControls.bounds;
            checkButton.Capture = propertyControls.capture;
            checkButton.CausesValidation = propertyControls.causesValidation;
            checkButton.ClientSize = propertyControls.clientSize;
            checkButton.Cursor = propertyControls.cursor;
            checkButton.Enabled = propertyControls.enabled;
            checkButton.Font = propertyControls.font;
            checkButton.ForeColor = propertyControls.foreColor;
            checkButton.Height = propertyControls.height;
            checkButton.IsAccessible = propertyControls.isAccessible;
            checkButton.Left = propertyControls.left;
            checkButton.Margin = propertyControls.margin;
            checkButton.MaximumSize = propertyControls.maximumSize;
            checkButton.MinimumSize = propertyControls.minimumSize;
            checkButton.Padding = propertyControls.padding;
            checkButton.TabIndex = propertyControls.tabIndex;
            checkButton.TabStop = propertyControls.tabStop;
            checkButton.Tag = propertyControls.tag;
            checkButton.Top = propertyControls.top;
            checkButton.UseWaitCursor = propertyControls.useWaitCursor;
            checkButton.Visible = propertyControls.visible;
            checkButton.Width = propertyControls.width;
            checkButton.CommonPLCMemoryAddressByte = propertyControls.CommonPLCMemoryAddressByte;
            checkButton.CommonPLCMemoryBit = propertyControls.CommonPLCMemoryBit;
            checkButton.ColorSwitchOFF = propertyControls.ColorSwitchOFF;
            checkButton.ColorSwitchON = propertyControls.ColorSwitchON;
            checkButton.TextSwitchOFF = propertyControls.TextSwitchOFF;
            checkButton.TextSwitchON = propertyControls.TextSwitchON;
            checkButton.ImageSwitchOFF = propertyControls.ImageSwitchOFF;
            checkButton.ImageSwitchON = propertyControls.ImageSwitchON;
            checkButton.ShowImage = propertyControls.ShowImage;
            checkButton.ShowText = propertyControls.ShowText;
            checkButton.ItemOfKernel = propertyControls.ItemOfKernel;
            checkButton.SizeModeValue = propertyControls.backgroundImageLayout;
            checkButton.State = propertyControls.state;
        }
        public void LoadUsersButtonData(UsersButton usersButton, PropertyControls propertyControls)
        {
            usersButton.Location = propertyControls.location; //расположение
            usersButton.Size = propertyControls.size; // размер
            usersButton.Name = propertyControls.name;
            usersButton.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            usersButton.AccessibleDescription = propertyControls.accessibleDescription;
            usersButton.AccessibleName = propertyControls.accessibleName;
            usersButton.AccessibleRole = propertyControls.accessibleRole;
            usersButton.AllowDrop = propertyControls.allowDrop;
            usersButton.Anchor = propertyControls.anchor;
            usersButton.AutoScrollOffset = propertyControls.autoScrollOffset;
            usersButton.BackColor = propertyControls.backColor;
            usersButton.BackgroundImage = propertyControls.backgroundImage;
            usersButton.Bounds = propertyControls.bounds;
            usersButton.Capture = propertyControls.capture;
            usersButton.CausesValidation = propertyControls.causesValidation;
            usersButton.ClientSize = propertyControls.clientSize;
            usersButton.Cursor = propertyControls.cursor;
            usersButton.Enabled = propertyControls.enabled;
            usersButton.Font = propertyControls.font;
            usersButton.ForeColor = propertyControls.foreColor;
            usersButton.Height = propertyControls.height;
            usersButton.IsAccessible = propertyControls.isAccessible;
            usersButton.Left = propertyControls.left;
            usersButton.Margin = propertyControls.margin;
            usersButton.MaximumSize = propertyControls.maximumSize;
            usersButton.MinimumSize = propertyControls.minimumSize;
            usersButton.Padding = propertyControls.padding;
            usersButton.TabIndex = propertyControls.tabIndex;
            usersButton.TabStop = propertyControls.tabStop;
            usersButton.Tag = propertyControls.tag;
            usersButton.Top = propertyControls.top;
            usersButton.UseWaitCursor = propertyControls.useWaitCursor;
            usersButton.Visible = propertyControls.visible;
            usersButton.Width = propertyControls.width;
            usersButton.CommonPLCMemoryAddressByte = propertyControls.CommonPLCMemoryAddressByte;
            usersButton.CommonPLCMemoryBit = propertyControls.CommonPLCMemoryBit;
            usersButton.ItemOfKernel = propertyControls.ItemOfKernel;
            usersButton.SizeModeValue = propertyControls.backgroundImageLayout;
            usersButton.TextValue = propertyControls.TextValue;
        }
        public void LoadValueBoxData(ValueBox valueBox, PropertyControls propertyControls)
        {
            valueBox.Location = propertyControls.location; //расположение
            valueBox.Size = propertyControls.size; // размер
            valueBox.Name = propertyControls.name;
            valueBox.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            valueBox.AccessibleDescription = propertyControls.accessibleDescription;
            valueBox.AccessibleName = propertyControls.accessibleName;
            valueBox.AccessibleRole = propertyControls.accessibleRole;
            valueBox.AllowDrop = propertyControls.allowDrop;
            valueBox.Anchor = propertyControls.anchor;
            valueBox.AutoScrollOffset = propertyControls.autoScrollOffset;
            valueBox.BackColor = propertyControls.backColor;
            valueBox.BackgroundImage = propertyControls.backgroundImage;
            valueBox.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            valueBox.Bounds = propertyControls.bounds;
            valueBox.Capture = propertyControls.capture;
            valueBox.CausesValidation = propertyControls.causesValidation;
            valueBox.ClientSize = propertyControls.clientSize;
            valueBox.Cursor = propertyControls.cursor;
            valueBox.Enabled = propertyControls.enabled;
            valueBox.Font = propertyControls.font;
            valueBox.ForeColor = propertyControls.foreColor;
            valueBox.Height = propertyControls.height;
            valueBox.IsAccessible = propertyControls.isAccessible;
            valueBox.Left = propertyControls.left;
            valueBox.Margin = propertyControls.margin;
            valueBox.MaximumSize = propertyControls.maximumSize;
            valueBox.MinimumSize = propertyControls.minimumSize;
            valueBox.Padding = propertyControls.padding;
            valueBox.TabIndex = propertyControls.tabIndex;
            valueBox.TabStop = propertyControls.tabStop;
            valueBox.Tag = propertyControls.tag;
            valueBox.Top = propertyControls.top;
            valueBox.UseWaitCursor = propertyControls.useWaitCursor;
            valueBox.Visible = propertyControls.visible;
            valueBox.Width = propertyControls.width;
            valueBox.CommonPLCMemoryAddressByte = propertyControls.CommonPLCMemoryAddressByte;
            valueBox.CommonPLCMemoryBit = propertyControls.CommonPLCMemoryBit;
            valueBox.BackColorValue = propertyControls.BackColorValue;
            valueBox.FontValue = propertyControls.FontValue;
            valueBox.ForeColorValue = propertyControls.ForeColorValue;
            valueBox.TextValue = propertyControls.TextValue;
            valueBox.ValueType = propertyControls.ValueType;
            valueBox.ItemOfKernel = propertyControls.ItemOfKernel;
        }
        public void LoadTextBoxData(UserText userText, PropertyControls propertyControls)
        {
            userText.Location = propertyControls.location; //расположение
            userText.Size = propertyControls.size; // размер
            userText.Name = propertyControls.name;
            userText.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            userText.AccessibleDescription = propertyControls.accessibleDescription;
            userText.AccessibleName = propertyControls.accessibleName;
            userText.AccessibleRole = propertyControls.accessibleRole;
            userText.AllowDrop = propertyControls.allowDrop;
            userText.Anchor = propertyControls.anchor;
            userText.AutoScrollOffset = propertyControls.autoScrollOffset;
            userText.BackColor = propertyControls.backColor;
            userText.BackgroundImage = propertyControls.backgroundImage;
            userText.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            userText.Bounds = propertyControls.bounds;
            userText.Capture = propertyControls.capture;
            userText.CausesValidation = propertyControls.causesValidation;
            userText.ClientSize = propertyControls.clientSize;
            userText.Cursor = propertyControls.cursor;
            userText.Enabled = propertyControls.enabled;
            userText.Font = propertyControls.font;
            userText.ForeColor = propertyControls.foreColor;
            userText.Height = propertyControls.height;
            userText.IsAccessible = propertyControls.isAccessible;
            userText.Left = propertyControls.left;
            userText.Margin = propertyControls.margin;
            userText.MaximumSize = propertyControls.maximumSize;
            userText.MinimumSize = propertyControls.minimumSize;
            userText.Padding = propertyControls.padding;
            userText.TabIndex = propertyControls.tabIndex;
            userText.TabStop = propertyControls.tabStop;
            userText.Tag = propertyControls.tag;
            userText.Top = propertyControls.top;
            userText.UseWaitCursor = propertyControls.useWaitCursor;
            userText.Visible = propertyControls.visible;
            userText.Width = propertyControls.width;
            userText.TextOffValue = propertyControls.TextOffValue;
            userText.TextOnValue = propertyControls.TextOnValue;
            userText.TextValue = propertyControls.TextValue;
            userText.Text1stOption = propertyControls.FirstText;
            userText.Text2ndOption = propertyControls.SecondText;
            userText.Text3rdOption = propertyControls.ThirdText;
            userText.Text4thOption = propertyControls.FourthText;
            userText.Text5thOption = propertyControls.FifthText;
        }
        public void LoadImageBoxData(UserImage userImage, PropertyControls propertyControls)
        {
            userImage.Location = propertyControls.location; //расположение
            userImage.Size = propertyControls.size; // размер
            userImage.Name = propertyControls.name;
            userImage.AccessibleDefaultActionDescription = propertyControls.accessibleDefaultActionDescription;
            userImage.AccessibleDescription = propertyControls.accessibleDescription;
            userImage.AccessibleName = propertyControls.accessibleName;
            userImage.AccessibleRole = propertyControls.accessibleRole;
            userImage.AllowDrop = propertyControls.allowDrop;
            userImage.Anchor = propertyControls.anchor;
            userImage.AutoScrollOffset = propertyControls.autoScrollOffset;
            userImage.BackColor = propertyControls.backColor;
            userImage.BackgroundImage = propertyControls.backgroundImage;
            userImage.BackgroundImageLayout = propertyControls.backgroundImageLayout;
            userImage.Bounds = propertyControls.bounds;
            userImage.Capture = propertyControls.capture;
            userImage.CausesValidation = propertyControls.causesValidation;
            userImage.ClientSize = propertyControls.clientSize;
            userImage.Cursor = propertyControls.cursor;
            userImage.Enabled = propertyControls.enabled;
            userImage.Font = propertyControls.font;
            userImage.ForeColor = propertyControls.foreColor;
            userImage.Height = propertyControls.height;
            userImage.IsAccessible = propertyControls.isAccessible;
            userImage.Left = propertyControls.left;
            userImage.Margin = propertyControls.margin;
            userImage.MaximumSize = propertyControls.maximumSize;
            userImage.MinimumSize = propertyControls.minimumSize;
            userImage.Padding = propertyControls.padding;
            userImage.TabIndex = propertyControls.tabIndex;
            userImage.TabStop = propertyControls.tabStop;
            userImage.Tag = propertyControls.tag;
            userImage.Top = propertyControls.top;
            userImage.UseWaitCursor = propertyControls.useWaitCursor;
            userImage.Visible = propertyControls.visible;
            userImage.Width = propertyControls.width;
            userImage.ImageOffValue = propertyControls.ImageOffValue;
            userImage.ImageOnValue = propertyControls.ImageOnValue;
            userImage.Image = propertyControls.image;
            userImage.ItemOfKernel = propertyControls.ItemOfKernel;
            userImage.Image1stOption = propertyControls.First;
            userImage.Image2ndOption = propertyControls.Second;
            userImage.Image3rdOption = propertyControls.Third;
            userImage.Image4thOption = propertyControls.Fourth;
            userImage.Image5thOption = propertyControls.Fifth;
            userImage.SizeModeValue = propertyControls.sizeMode;
            userImage.state = propertyControls.state;
        }
        public PropertyControls[] SaveData(Panel WorkPanel)
        {
            var indexes = new List<PropertyControls>();
            for (int i = 0; i < WorkPanel.Controls.Count; i++)
            {
                PropertyControls propertyControls = new PropertyControls();
                Control ctrl = WorkPanel.Controls[i] ?? null;
                propertyControls.type = ctrl.GetType() ?? null;
                propertyControls.accessibleDefaultActionDescription = ctrl.AccessibleDefaultActionDescription ?? null;
                propertyControls.accessibleDescription = ctrl.AccessibleDescription ?? null;
                propertyControls.accessibleName = ctrl.AccessibleName ?? null;
                propertyControls.accessibleRole = ctrl.AccessibleRole;
                propertyControls.allowDrop = ctrl.AllowDrop;
                propertyControls.anchor = ctrl.Anchor;
                propertyControls.autoScrollOffset = ctrl.AutoScrollOffset;
                propertyControls.backColor = ctrl.BackColor;
                propertyControls.backgroundImage = ctrl.BackgroundImage ?? null;
                propertyControls.backgroundImageLayout = ctrl.BackgroundImageLayout;
                propertyControls.bottom = ctrl.Bottom;
                propertyControls.bounds = ctrl.Bounds;
                propertyControls.canFocus = ctrl.CanFocus;
                propertyControls.canSelect = ctrl.CanSelect;
                propertyControls.capture = ctrl.Capture;
                propertyControls.causesValidation = ctrl.CausesValidation;
                propertyControls.clientRectangle = ctrl.ClientRectangle;
                propertyControls.clientSize = ctrl.ClientSize;
                propertyControls.companyName = ctrl.CompanyName ?? null;
                propertyControls.container = ctrl.Container ?? null;
                propertyControls.containsFocus = ctrl.ContainsFocus;
                propertyControls.contextMenuStrip = ctrl.ContextMenuStrip.ToString() ?? null;
                propertyControls.controls = ctrl.Controls.ToString() ?? null;
                propertyControls.created = ctrl.Created;
                propertyControls.cursor = ctrl.Cursor ?? null;
                propertyControls.DataBindings = ctrl.DataBindings.ToString() ?? null;
                propertyControls.displayRectangle = ctrl.DisplayRectangle;
                propertyControls.Disposing = ctrl.Disposing;
                propertyControls.dockStyle = ctrl.Dock;
                propertyControls.enabled = ctrl.Enabled;
                propertyControls.focused = ctrl.Focused;
                propertyControls.font = ctrl.Font ?? null;
                propertyControls.foreColor = ctrl.ForeColor;
                propertyControls.handle = ctrl.Handle;
                propertyControls.hasChildren = ctrl.HasChildren;
                propertyControls.height = ctrl.Height;
                propertyControls.imeMode = ctrl.ImeMode;
                propertyControls.invokeRequired = ctrl.InvokeRequired;
                propertyControls.isAccessible = ctrl.IsAccessible;
                propertyControls.isDisposed = ctrl.IsDisposed;
                propertyControls.isHandleCreated = ctrl.IsHandleCreated;
                propertyControls.isMirrored = ctrl.IsMirrored;
                propertyControls.LayoutEngine = ctrl.LayoutEngine.ToString() ?? null;
                propertyControls.left = ctrl.Left;
                propertyControls.location = ctrl.Location;
                propertyControls.margin = ctrl.Margin;
                propertyControls.maximumSize = ctrl.MaximumSize;
                propertyControls.minimumSize = ctrl.MinimumSize;
                propertyControls.name = ctrl.Name ?? null;
                propertyControls.padding = ctrl.Padding;
                propertyControls.parent = ctrl.Parent.ToString() ?? null;
                propertyControls.preferredSize = ctrl.PreferredSize;
                propertyControls.productName = ctrl.ProductName ?? null;
                propertyControls.productVersion = ctrl.ProductVersion ?? null;
                propertyControls.recreatingHandle = ctrl.RecreatingHandle;
                propertyControls.right = ctrl.Right;
                propertyControls.rightToLeft = ctrl.RightToLeft.ToString();
                propertyControls.size = ctrl.Size;
                propertyControls.tabIndex = ctrl.TabIndex;
                propertyControls.tabStop = ctrl.TabStop;
                propertyControls.tag = ctrl.Tag ?? null;
                propertyControls.text = ctrl.Text ?? null;
                propertyControls.top = ctrl.Top;
                propertyControls.topLevelControl = ctrl.TopLevelControl.ToString() ?? null;
                propertyControls.useWaitCursor = ctrl.UseWaitCursor;
                propertyControls.visible = ctrl.Visible;
                propertyControls.width = ctrl.Width;
                if (propertyControls.type == typeof(Button))
                {
                    Button btn = ctrl as Button;
                    if (btn != null)
                    {
                        propertyControls.flatStyle = btn.FlatStyle;
                    }
                }
                if (propertyControls.type == typeof(PictureBox))
                {
                    PictureBox pic = ctrl as PictureBox;
                    if (pic != null)
                    {
                        propertyControls.image = pic.Image ?? null;
                        propertyControls.sizeMode = pic.SizeMode;
                    }
                }
                if (propertyControls.type == typeof(Label))
                {
                    Label lbl = ctrl as Label;
                    if (lbl != null)
                    {
                        propertyControls.textAlign = lbl.TextAlign;
                    }
                }
                if (propertyControls.type == typeof(ValueBox))
                {
                    ValueBox vlb = ctrl as ValueBox;
                    if (vlb != null)
                    {
                        propertyControls.CommonPLCMemoryAddressByte = vlb.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = vlb.CommonPLCMemoryBit;
                        propertyControls.BackColorValue = vlb.BackColorValue;
                        propertyControls.FontValue = vlb.FontValue;
                        propertyControls.ForeColorValue = vlb.ForeColorValue;
                        propertyControls.TextValue = vlb.TextValue;
                        propertyControls.ValueType = vlb.ValueType;
                        propertyControls.ItemOfKernel = vlb.ItemOfKernel;
                    }
                }
                if (propertyControls.type == typeof(UserSwitcher))
                {
                    UserSwitcher swt = ctrl as UserSwitcher;
                    if (swt != null)
                    {
                        propertyControls.CommonPLCMemoryAddressByte = swt.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = swt.CommonPLCMemoryBit;
                        propertyControls.ColorSwitchOFF = swt.ColorSwitchOFF;
                        propertyControls.ColorSwitchON = swt.ColorSwitchON;
                        propertyControls.TextSwitchOFF = swt.TextSwitchOFF;
                        propertyControls.TextSwitchON = swt.TextSwitchON;
                        propertyControls.TextValue = swt.TextValue;
                        propertyControls.ColorValue = swt.ColorValue;
                        propertyControls.ItemOfKernel = swt.ItemOfKernel;
                        propertyControls.state = swt.State;
                    }
                }
                if (propertyControls.type == typeof(CheckButton))
                {
                    CheckButton cbt = ctrl as CheckButton;
                    if (cbt != null)
                    {
                        propertyControls.CommonPLCMemoryAddressByte = cbt.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = cbt.CommonPLCMemoryBit;
                        propertyControls.ColorSwitchOFF = cbt.ColorSwitchOFF;
                        propertyControls.ColorSwitchON = cbt.ColorSwitchON;
                        propertyControls.TextSwitchOFF = cbt.TextSwitchOFF;
                        propertyControls.TextSwitchON = cbt.TextSwitchON;
                        propertyControls.ImageSwitchOFF = cbt.ImageSwitchOFF;
                        propertyControls.ImageSwitchON = cbt.ImageSwitchON;
                        propertyControls.ShowImage = cbt.ShowImage;
                        propertyControls.ShowText = cbt.ShowText;
                        propertyControls.ItemOfKernel = cbt.ItemOfKernel;
                        propertyControls.backgroundImageLayout = cbt.SizeModeValue;
                        propertyControls.state = cbt.State;
                    }
                }
                if (propertyControls.type == typeof(UsersButton))
                {
                    UsersButton cbt = ctrl as UsersButton;
                    if (cbt != null)
                    {
                        propertyControls.CommonPLCMemoryAddressByte = cbt.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = cbt.CommonPLCMemoryBit;
                        propertyControls.ItemOfKernel = cbt.ItemOfKernel;
                        propertyControls.backgroundImageLayout = cbt.SizeModeValue;
                        propertyControls.TextValue = cbt.TextValue;
                    }
                }
                if (propertyControls.type == typeof(UserImage))
                {
                    UserImage img = ctrl as UserImage;
                    if (img != null)
                    {
                        propertyControls.ImageOffValue = img.ImageOffValue;
                        propertyControls.ImageOnValue = img.ImageOnValue;
                        propertyControls.First = img.Image1stOption;
                        propertyControls.Second = img.Image2ndOption;
                        propertyControls.Third = img.Image3rdOption;
                        propertyControls.Fourth = img.Image4thOption;
                        propertyControls.Fifth = img.Image5thOption;
                        propertyControls.image = img.Image;
                        propertyControls.CommonPLCMemoryAddressByte = img.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = img.CommonPLCMemoryBit;
                        propertyControls.sizeMode = img.SizeModeValue;
                        propertyControls.state = img.State;
                    }
                }
                if (propertyControls.type == typeof(UserText))
                {
                    UserText txt = ctrl as UserText;
                    if (txt != null)
                    {
                        propertyControls.TextOffValue = txt.TextOffValue;
                        propertyControls.TextOnValue = txt.TextOnValue;
                        propertyControls.TextValue = txt.TextValue;
                        propertyControls.FirstText = txt.Text1stOption;
                        propertyControls.SecondText = txt.Text2ndOption;
                        propertyControls.ThirdText = txt.Text3rdOption;
                        propertyControls.FourthText = txt.Text4thOption;
                        propertyControls.FifthText = txt.Text5thOption;
                    }
                }
                indexes.Add(propertyControls);
            }
            return indexes.ToArray();
        }
        public Figures[] SaveFigures()
        {
            var figuresList = new List<Figures>();
            Figures figures = new Figures();
            List<Point[]> LinesProject = new List<Point[]>();
            List<int[]> RectanglesProject = new List<int[]>();
            List<int[]> EllipsesProject = new List<int[]>();
            List<Point[]> PolygonsProject = new List<Point[]>();
            for (int j = 0; j < LineList.Count; j++)
            {
                LinesProject.Add(LineList[j]);
            }
            figures.Points = LinesProject;
            for (int j = 0; j < RectangleList.Count; j++)
            {
                RectanglesProject.Add(RectangleList[j]);
            }
            figures.Rectangles = RectanglesProject;
            for (int j = 0; j < ellipseList.Count; j++)
            {
                EllipsesProject.Add(ellipseList[j]);
            }
            figures.Ellipses = EllipsesProject;
            for (int j = 0; j < polygonList.Count; j++)
            {
                PolygonsProject.Add(polygonList[j]);
            }
            figures.Polygons = PolygonsProject;
            figuresList.Add(figures);
            return figuresList.ToArray();
        }
        public string[] LoadFigures(Graphics g, Pen pen, Figures figures)
        {
            List<string> NamesFigures = new List<string>();
            for (int i = 0; i < figures.Points.Count; i++)
            {
                g.DrawLine(pen, figures.Points[i][0], figures.Points[i][1]);
                Lines.Add(figures.Points[i][0]);
                Lines.Add(figures.Points[i][1]);
                Line.Add(figures.Points[i][0]);
                Line.Add(figures.Points[i][1]);
                Point[] pointLine = Lines.ToArray();
                Point[] pointsLine = Line.ToArray();
                LineList.Add(pointLine);
                ListLine.Add(pointsLine);
                Line.Clear();
                Lines.Clear();
                NamesFigures.Add("Line_" + LineList.Count);
            }
            for (int i = 0; i < figures.Rectangles.Count; i++)
            {
                g.DrawRectangle(pen, figures.Rectangles[i][0], figures.Rectangles[i][1], figures.Rectangles[i][2], figures.Rectangles[i][3]);
                RectanglePoint.Add(figures.Rectangles[i][0]);
                RectanglePoint.Add(figures.Rectangles[i][1]);
                RectanglePoint.Add(figures.Rectangles[i][2]);
                RectanglePoint.Add(figures.Rectangles[i][3]);
                int[] pointsRectangle = RectanglePoint.ToArray();
                RectangleList.Add(pointsRectangle);
                RectanglePoint.Clear();
                NamesFigures.Add("Rectangle_" + RectangleList.Count);
            }
            for (int i = 0; i < figures.Ellipses.Count; i++)
            {
                g.DrawEllipse(pen, figures.Ellipses[i][0], figures.Ellipses[i][1], figures.Ellipses[i][2], figures.Ellipses[i][3]);
                EllipsePoint.Add(figures.Ellipses[i][0]);
                EllipsePoint.Add(figures.Ellipses[i][1]);
                EllipsePoint.Add(figures.Ellipses[i][2]);
                EllipsePoint.Add(figures.Ellipses[i][3]);
                int[] pointsEllipse = EllipsePoint.ToArray();
                ellipseList.Add(pointsEllipse);
                EllipsePoint.Clear();
                NamesFigures.Add("Ellipse_" + ellipseList.Count);
            }
            for (int i = 0; i < figures.Polygons.Count; i++)
            {
                g.DrawPolygon(pen, figures.Polygons[i]);
                polygon = figures.Polygons[i];
                Point[] PolygonPointsArray = PolygonPoints.ToArray();
                polygonList.Add(polygon);
                PolygonPointList.Add(PolygonPointsArray);
                points.Clear();
                PolygonPoints.Clear();
                NamesFigures.Add("Polygon_" + polygonList.Count);
            }
            return NamesFigures.ToArray();
        }
        public string DrawLine(MouseEventArgs e, Graphics g, Image img, Pen pen)
        {
            if (isFirstPointSet)
            {
                g.DrawLine(pen, firstPoint, e.Location);
                isFirstPointSet = false;
                Lines.Add(firstPoint);
                Lines.Add(e.Location);
                Line.Add(firstPoint);
                Line.Add(e.Location);
                Point[] pointLine = Lines.ToArray();
                Point[] pointsLine = Line.ToArray();
                LineList.Add(pointLine);
                ListLine.Add(pointsLine);
                Line.Clear();
                Lines.Clear();
                return "Line_" + LineList.Count;
            }
            else
            {
                firstPoint = e.Location;
                (img as Bitmap).SetPixel(firstPoint.X, firstPoint.Y, pen.Color);
                isFirstPointSet = true;
                return null;
            }
        }
        public string DrawRectangle(MouseEventArgs e, Graphics g, Image img, Pen pen)
        {
            if (isFirstPointSet)
            {
                // первая точка уже поставлена
                float rectangleWidth = 0;
                float rectangleHeight = 0;
                if (e.Location.X > firstPoint.X)
                {
                    rectangleWidth = e.Location.X - firstPoint.X;
                }
                else
                {
                    rectangleWidth = firstPoint.X - e.Location.X;
                }
                if (e.Location.Y > firstPoint.Y)
                {
                    rectangleHeight = e.Location.Y - firstPoint.Y;
                }
                else
                {
                    rectangleHeight = firstPoint.Y - e.Location.Y;
                }
                if (e.Location.X > firstPoint.X && e.Location.Y > firstPoint.Y)
                {
                    rectangle = new Rectangle(firstPoint.X, firstPoint.Y, Convert.ToInt32(rectangleWidth), Convert.ToInt32(rectangleHeight));
                    g.DrawRectangle(pen, firstPoint.X, firstPoint.Y, rectangleWidth, rectangleHeight);
                }
                if (e.Location.X < firstPoint.X && e.Location.Y > firstPoint.Y)
                {
                    rectangle = new Rectangle(e.Location.X, firstPoint.Y, Convert.ToInt32(rectangleWidth), Convert.ToInt32(rectangleHeight));
                    g.DrawRectangle(pen, e.Location.X, firstPoint.Y, rectangleWidth, rectangleHeight);
                }
                if (e.Location.X > firstPoint.X && e.Location.Y < firstPoint.Y)
                {
                    rectangle = new Rectangle(firstPoint.X, e.Location.Y, Convert.ToInt32(rectangleWidth), Convert.ToInt32(rectangleHeight));
                    g.DrawRectangle(pen, firstPoint.X, e.Location.Y, rectangleWidth, rectangleHeight);
                }
                if (e.Location.X < firstPoint.X && e.Location.Y < firstPoint.Y)
                {
                    rectangle = new Rectangle(e.Location.X, e.Location.Y, Convert.ToInt32(rectangleWidth), Convert.ToInt32(rectangleHeight));
                    g.DrawRectangle(pen, e.Location.X, e.Location.Y, rectangleWidth, rectangleHeight);
                }
                ListRectangles.Add(rectangle);
                RectanglePoint.Add(rectangle.X);
                RectanglePoint.Add(rectangle.Y);
                RectanglePoint.Add(rectangle.Width);
                RectanglePoint.Add(rectangle.Height);
                int[] pointsRectangle = RectanglePoint.ToArray();
                RectangleList.Add(pointsRectangle);
                isFirstPointSet = false;
                RectanglePoint.Clear();
                return "Rectangle_" + RectangleList.Count;
            }
            else
            {
                // ставим первую точку
                firstPoint = e.Location;
                (img as Bitmap).SetPixel(firstPoint.X, firstPoint.Y, pen.Color);
                isFirstPointSet = true;
                return null;
            }
        }
        public string DrawEllipse(MouseEventArgs e, Graphics g, Image img, Pen pen)
        {
            if (isFirstPointSet)
            {
                Rectangle rectangle = new Rectangle();
                int rectangleWidth = 0;
                int rectangleHeight = 0;
                if (e.Location.X > firstPoint.X)
                {
                    rectangleWidth = e.Location.X - firstPoint.X;
                }
                else
                {
                    rectangleWidth = firstPoint.X - e.Location.X;
                }
                if (e.Location.Y > firstPoint.Y)
                {
                    rectangleHeight = e.Location.Y - firstPoint.Y;
                }
                else
                {
                    rectangleHeight = firstPoint.Y - e.Location.Y;
                }
                if (e.Location.X > firstPoint.X && e.Location.Y > firstPoint.Y)
                {
                    rectangle = new Rectangle(firstPoint.X, firstPoint.Y, rectangleWidth, rectangleHeight);
                }
                if (e.Location.X < firstPoint.X && e.Location.Y > firstPoint.Y)
                    rectangle = new Rectangle(e.Location.X, firstPoint.Y, rectangleWidth, rectangleHeight);
                if (e.Location.X > firstPoint.X && e.Location.Y < firstPoint.Y)
                    rectangle = new Rectangle(firstPoint.X, e.Location.Y, rectangleWidth, rectangleHeight);
                if (e.Location.X < firstPoint.X && e.Location.Y < firstPoint.Y)
                    rectangle = new Rectangle(e.Location.X, e.Location.Y, rectangleWidth, rectangleHeight);
                g.DrawEllipse(pen, rectangle);
                ListEllipse.Add(rectangle);
                EllipsePoint.Add(rectangle.X);
                EllipsePoint.Add(rectangle.Y);
                EllipsePoint.Add(rectangle.Width);
                EllipsePoint.Add(rectangle.Height);
                int[] pointsEllipse = EllipsePoint.ToArray();
                ellipseList.Add(pointsEllipse);
                isFirstPointSet = false;
                EllipsePoint.Clear();
                return "Ellipse_" + ellipseList.Count;
            }
            else
            {
                // ставим первую точку
                firstPoint = e.Location;
                (img as Bitmap).SetPixel(firstPoint.X, firstPoint.Y, pen.Color);
                isFirstPointSet = true;
                return null;
            }
        }
        public string DrawPolygon(MouseEventArgs e, Graphics g, Image img, Pen pen)
        {
            if (isFirstPointSet && points.Count < 8)
            {
                points.Add(e.Location);
                PolygonPoints.Add(e.Location);
                Point point = e.Location;
                (img as Bitmap).SetPixel(point.X, point.Y, pen.Color);
                return null;
            }
            if (!isFirstPointSet)
            {
                // ставим первую точку
                firstPoint = e.Location;
                points.Add(firstPoint);
                PolygonPoints.Add(firstPoint);
                (img as Bitmap).SetPixel(firstPoint.X, firstPoint.Y, pen.Color);
                isFirstPointSet = true;
                return null;
            }
            if (isFirstPointSet && points.Count > 1 && (points.Count == 8 || e.Location == firstPoint))
            {
                g.DrawPolygon(pen, points.ToArray());
                polygon = points.ToArray();
                Point[] PolygonPointsArray = PolygonPoints.ToArray();
                polygonList.Add(polygon);
                PolygonPointList.Add(PolygonPointsArray);
                points.Clear();
                PolygonPoints.Clear();
                isFirstPointSet = false;
                return "Polygon_" + polygonList.Count;
            }
            else
            {
                return null;
            }
        }
        public void SaveCurrentProject(Panel Parent, int Project)
        {
            switch (Project)
            {
                case 1:
                    ClearCellForProject(controlList1, LinesProject1, RectanglesProject1, EllipsesProject1, PolygonsProject1);
                    FillCell(Parent, controlList1, LinesProject1, RectanglesProject1, EllipsesProject1, PolygonsProject1);
                    break;
                case 2:
                    ClearCellForProject(controlList2, LinesProject2, RectanglesProject2, EllipsesProject2, PolygonsProject2);
                    FillCell(Parent, controlList2, LinesProject2, RectanglesProject2, EllipsesProject2, PolygonsProject2);
                    break;
                case 3:
                    ClearCellForProject(controlList3, LinesProject3, RectanglesProject3, EllipsesProject3, PolygonsProject3);
                    FillCell(Parent, controlList3, LinesProject3, RectanglesProject3, EllipsesProject3, PolygonsProject3);
                    break;
                case 4:
                    ClearCellForProject(controlList4, LinesProject4, RectanglesProject4, EllipsesProject4, PolygonsProject4);
                    FillCell(Parent, controlList4, LinesProject4, RectanglesProject4, EllipsesProject4, PolygonsProject4);
                    break;
                case 5:
                    ClearCellForProject(controlList5, LinesProject5, RectanglesProject5, EllipsesProject5, PolygonsProject5);
                    FillCell(Parent, controlList5, LinesProject5, RectanglesProject5, EllipsesProject5, PolygonsProject5);
                    break;
            }
        }
        public void ClearCellForProject(List<Control> ControlsProject, List<Point[]> LinesProject, List<int[]> RectanglesProject, List<int[]> EllipsesProject, List<Point[]> PolygonsProject)
        {
            ControlsProject.Clear();
            LinesProject.Clear();
            RectanglesProject.Clear();
            EllipsesProject.Clear();
            PolygonsProject.Clear();
        }
        public void FillCell(Panel Parent, List<Control> ControlsProject, List<Point[]> LinesProject, List<int[]> RectanglesProject, List<int[]> EllipsesProject, List<Point[]> PolygonsProject)
        {
            for (int i = 0; i < Parent.Controls.Count; i++)
                ControlsProject.Add(Parent.Controls[i]);
            for (int j = 0; j < LineList.Count; j++)
                LinesProject.Add(LineList[j]);
            for (int j = 0; j < RectangleList.Count; j++)
                RectanglesProject.Add(RectangleList[j]);
            for (int j = 0; j < ellipseList.Count; j++)
                EllipsesProject.Add(ellipseList[j]);
            for (int j = 0; j < polygonList.Count; j++)
                PolygonsProject.Add(polygonList[j]);
        }
        public string[] AddControlsToSelectedProject(Panel Parent, int Project)
        {
            switch (Project)
            {
                case 0: return GetControlsSelectedProject(Parent, controlList1);
                case 1: return GetControlsSelectedProject(Parent, controlList2);
                case 2: return GetControlsSelectedProject(Parent, controlList3);
                case 3: return GetControlsSelectedProject(Parent, controlList4);
                case 4: return GetControlsSelectedProject(Parent, controlList5);
                default: return null;
            }
        }
        public string[] GetControlsSelectedProject (Panel Parent, List<Control> ControlsProject)
        {
            List<string> NamesControls = new List<string>();
            for (int i = 0; i < ControlsProject.Count; i++)
            {
                Parent.Controls.Add(ControlsProject[i]);
                NamesControls.Add(ControlsProject[i].Name);
            }
            return NamesControls.ToArray();
        }
        public string[] AddLinesToSelectedProject(int Project, Graphics g)
        {
            switch (Project)
            {
                case 0: return GetLinesOfProject(LinesProject1, g);
                case 1: return GetLinesOfProject(LinesProject2, g);
                case 2: return GetLinesOfProject(LinesProject3, g);
                case 3: return GetLinesOfProject(LinesProject4, g);
                case 4: return GetLinesOfProject(LinesProject5, g);
                default: return null;
            }
        }
        public string[] AddRectanglesToSelectedProject(int Project, Graphics g)
        {
            switch (Project)
            {
                case 0: return GetRectanglesOfProject(RectanglesProject1, g);
                case 1: return GetRectanglesOfProject(RectanglesProject2, g);
                case 2: return GetRectanglesOfProject(RectanglesProject3, g);
                case 3: return GetRectanglesOfProject(RectanglesProject4, g);
                case 4: return GetRectanglesOfProject(RectanglesProject5, g);
                default: return null;
            }
        }
        public string[] AddEllipsesToSelectedProject(int Project, Graphics g)
        {
            switch (Project)
            {
                case 0: return GetEllipsesOfProject(EllipsesProject1, g);
                case 1: return GetEllipsesOfProject(EllipsesProject2, g);
                case 2: return GetEllipsesOfProject(EllipsesProject3, g);
                case 3: return GetEllipsesOfProject(EllipsesProject4, g);
                case 4: return GetEllipsesOfProject(EllipsesProject5, g);
                default: return null;
            }
        }
        public string[] AddPolygonsToSelectedProject(int Project, Graphics g)
        {
            switch (Project)
            {
                case 0: return GetPolygonsOfProject(PolygonsProject1, g);
                case 1: return GetPolygonsOfProject(PolygonsProject2, g);
                case 2: return GetPolygonsOfProject(PolygonsProject3, g);
                case 3: return GetPolygonsOfProject(PolygonsProject4, g);
                case 4: return GetPolygonsOfProject(PolygonsProject5, g);
                default: return null;
            }
        }
        public string[] GetLinesOfProject(List<Point[]> LinesProject, Graphics g)
        {
            List<string> NamesLines = new List<string>();
            for (int j = 0; j < LinesProject.Count; j++)
            {
                g.DrawLine(pen, LinesProject[j][0], LinesProject[j][1]);
                Lines.Add(LinesProject[j][0]);
                Lines.Add(LinesProject[j][1]);
                LineList.Add(Lines.ToArray());
                NamesLines.Add("Line_" + LineList.Count);
                Lines.Clear();
            }
            return NamesLines.ToArray();
        }
        public string[] GetRectanglesOfProject(List<int[]> RectanglesProject, Graphics g)
        {
            List<string> NamesRectangles = new List<string>();
            for (int j = 0; j < RectanglesProject.Count; j++)
            {
                g.DrawRectangle(pen, RectanglesProject[j][0], RectanglesProject[j][1], RectanglesProject[j][2], RectanglesProject[j][3]);
                RectanglePoint.Add(RectanglesProject[j][0]);
                RectanglePoint.Add(RectanglesProject[j][1]);
                RectanglePoint.Add(RectanglesProject[j][2]);
                RectanglePoint.Add(RectanglesProject[j][3]);
                int[] pointsRectangle = RectanglePoint.ToArray();
                RectangleList.Add(pointsRectangle);
                NamesRectangles.Add("Rectangle_" + RectangleList.Count);
                RectanglePoint.Clear();
            }
            return NamesRectangles.ToArray();
        }
        public string[] GetEllipsesOfProject(List<int[]> EllipsesProject, Graphics g)
        {
            List<string> NamesEllipses = new List<string>();
            for (int j = 0; j < EllipsesProject.Count; j++)
            {
                g.DrawEllipse(pen, EllipsesProject[j][0], EllipsesProject[j][1], EllipsesProject[j][2], EllipsesProject[j][3]);
                EllipsePoint.Add(EllipsesProject[j][0]);
                EllipsePoint.Add(EllipsesProject[j][1]);
                EllipsePoint.Add(EllipsesProject[j][2]);
                EllipsePoint.Add(EllipsesProject[j][3]);
                int[] pointsEllipse = EllipsePoint.ToArray();
                ellipseList.Add(pointsEllipse);
                NamesEllipses.Add("Ellipse_" + ellipseList.Count);
                EllipsePoint.Clear();
            }
            return NamesEllipses.ToArray();
        }
        public string[] GetPolygonsOfProject(List<Point[]> PolygonsProject, Graphics g)
        {
            List<string> NamesPolygons = new List<string>();
            for (int j = 0; j < PolygonsProject.Count; j++)
            {
                for (int k = 0; k < PolygonsProject.Count; k++)
                    points.Add(PolygonsProject[j][k]);
                g.DrawPolygon(pen, points.ToArray());
                polygonList.Add(points.ToArray());
                NamesPolygons.Add("Polygon_" + polygonList.Count);
                points.Clear();
            }
            return NamesPolygons.ToArray();
        }
        public void DeleteFigure(Graphics g, Pen Pen, int index, string TypeFigure)
        {
            if (TypeFigure == "Line")
                g.DrawLine(Pen, LineList[index][0], LineList[index][1]);
            if (TypeFigure == "Rectangle")
                g.DrawRectangle(Pen, RectangleList[index][0], RectangleList[index][1], RectangleList[index][2], RectangleList[index][3]);
            if (TypeFigure == "Ellipse")
                g.DrawEllipse(Pen, ellipseList[index][0], ellipseList[index][1], ellipseList[index][2], ellipseList[index][3]);
            if (TypeFigure == "Polygon")
                g.DrawPolygon(Pen, polygonList[index]);
        }
        public object ChangeFigure(string SeletedFigure, string TypeFigure)
        {
            if (TypeFigure == "Line")
                return LineList[Int32.Parse(SeletedFigure.Split('_').Last()) - 1];
            if (TypeFigure == "Rectangle")
                return RectangleList[Int32.Parse(SeletedFigure.Split('_').Last()) - 1];
            if (TypeFigure == "Ellipse")
                return ellipseList[Int32.Parse(SeletedFigure.Split('_').Last()) - 1];
            if (TypeFigure == "Polygon")
                return polygonList[Int32.Parse(SeletedFigure.Split('_').Last()) - 1];
            else
                return null;
        }
        public void DeleteAllFigure(Graphics g, Pen Pen)
        {
            for (int i = 0; i < Math.Max(Math.Max(LineList.Count, RectangleList.Count), Math.Max(ellipseList.Count, polygonList.Count)); i++)
            {
                if (i < LineList.Count)
                    g.DrawLine(Pen, LineList[i][0], LineList[i][1]);
                if (i < RectangleList.Count)
                    g.DrawRectangle(Pen, RectangleList[i][0], RectangleList[i][1], RectangleList[i][2], RectangleList[i][3]);
                if (i < ellipseList.Count)
                    g.DrawEllipse(Pen, ellipseList[i][0], ellipseList[i][1], ellipseList[i][2], ellipseList[i][3]);
                if (i < polygonList.Count)
                    g.DrawPolygon(Pen, polygonList[i]);
            }
            LineList.Clear();
            RectangleList.Clear();
            ellipseList.Clear();
            polygonList.Clear();
        }
        public void Redraw(Graphics g, Pen WhitePen, Pen BlackPen, int index, string TypeFigure)
        {
            if (TypeFigure == "Line")
            {
                g.DrawLine(WhitePen, LineList[index][0], LineList[index][1]);
                Point first_point = LineList[index][0];
                Point second_point = LineList[index][1];
                ListLine[index][0] = LineList[index][0];
                ListLine[index][1] = LineList[index][1];
                g.DrawLine(BlackPen, first_point, second_point);
            }
            if (TypeFigure == "Rectangle")
            {
                g.DrawRectangle(WhitePen, ListRectangles[index]);
                int Xrect = RectangleList[index][0];
                int Yrect = RectangleList[index][1];
                int Wrect = RectangleList[index][2];
                int Hrect = RectangleList[index][3];
                ListRectangles[index] = new Rectangle(Xrect, Yrect, Wrect, Hrect);
                g.DrawRectangle(BlackPen, Xrect, Yrect, Wrect, Hrect);
            }
            if (TypeFigure == "Ellipse")
            {
                g.DrawEllipse(WhitePen, ListEllipse[index]);
                int Xrect = ellipseList[index][0];
                int Yrect = ellipseList[index][1];
                int Wrect = ellipseList[index][2];
                int Hrect = ellipseList[index][3];
                ListEllipse[index] = new Rectangle(Xrect, Yrect, Wrect, Hrect);
                g.DrawEllipse(BlackPen, Xrect, Yrect, Wrect, Hrect);
            }
            if (TypeFigure == "Polygon")
            {
                g.DrawPolygon(WhitePen, PolygonPointList[index]);
                Point[] polygons = polygonList[index];
                for (int j = 0; j < polygonList[index].Length; j++)
                    PolygonPointList[index][j] = polygonList[index][j];
                g.DrawPolygon(pen, polygons);
            }
        }
        public void Update(Panel Parent)
        {
            var indexes = new List<PropertyControls>();
            for (int i = 0; i < Parent.Controls.Count; i++)
            {
                PropertyControls propertyControls = new PropertyControls();
                Control ctrl = Parent.Controls[i] ?? null;
                propertyControls.numberOfControl = i;
                propertyControls.type = ctrl.GetType() ?? null;
                if (propertyControls.type == typeof(ValueBox))
                {
                    ValueBox vlb = ctrl as ValueBox;
                    if (vlb != null)
                    {
                        propertyControls.CommonPLCMemoryAddressByte = vlb.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = vlb.CommonPLCMemoryBit;
                        propertyControls.TextValue = vlb.TextValue;
                        propertyControls.ValueType = vlb.ValueType;
                        propertyControls.ItemOfKernel = vlb.ItemOfKernel;
                    }
                }
                if (propertyControls.type == typeof(UserSwitcher))
                {
                    UserSwitcher swt = ctrl as UserSwitcher;
                    if (swt != null)
                    {
                        propertyControls.CommonPLCMemoryAddressByte = swt.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = swt.CommonPLCMemoryBit;
                        propertyControls.ColorSwitchOFF = swt.ColorSwitchOFF;
                        propertyControls.ColorSwitchON = swt.ColorSwitchON;
                        propertyControls.TextSwitchOFF = swt.TextSwitchOFF;
                        propertyControls.TextSwitchON = swt.TextSwitchON;
                        propertyControls.ItemOfKernel = swt.ItemOfKernel;
                    }
                }
                if (propertyControls.type == typeof(CheckButton))
                {
                    CheckButton cbt = ctrl as CheckButton;
                    if (cbt != null)
                    {
                        propertyControls.CommonPLCMemoryAddressByte = cbt.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = cbt.CommonPLCMemoryBit;
                        propertyControls.ColorSwitchOFF = cbt.ColorSwitchOFF;
                        propertyControls.ColorSwitchON = cbt.ColorSwitchON;
                        propertyControls.TextSwitchOFF = cbt.TextSwitchOFF;
                        propertyControls.TextSwitchON = cbt.TextSwitchON;
                        propertyControls.ImageSwitchOFF = cbt.ImageSwitchOFF;
                        propertyControls.ImageSwitchON = cbt.ImageSwitchON;
                        propertyControls.ShowImage = cbt.ShowImage;
                        propertyControls.ShowText = cbt.ShowText;
                        propertyControls.ItemOfKernel = cbt.ItemOfKernel;
                        propertyControls.backgroundImageLayout = cbt.backgroundImageLayout;
                    }
                }
                if (propertyControls.type == typeof(UsersButton))
                {
                    UsersButton cbt = ctrl as UsersButton;
                    if (cbt != null)
                    {
                        propertyControls.CommonPLCMemoryAddressByte = cbt.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = cbt.CommonPLCMemoryBit;
                        propertyControls.ItemOfKernel = cbt.ItemOfKernel;
                        propertyControls.TextValue = cbt.TextValue;
                        propertyControls.backgroundImageLayout = cbt.backgroundImageLayout;
                    }
                }
                if (propertyControls.type == typeof(UserImage))
                {
                    UserImage img = ctrl as UserImage;
                    if (img != null)
                    {
                        propertyControls.ImageOffValue = img.ImageOffValue;
                        propertyControls.ImageOnValue = img.ImageOnValue;
                        propertyControls.First = img.Image1stOption;
                        propertyControls.Second = img.Image2ndOption;
                        propertyControls.Third = img.Image3rdOption;
                        propertyControls.Fourth = img.Image4thOption;
                        propertyControls.Fifth = img.Image5thOption;
                        propertyControls.image = img.Image;
                        propertyControls.CommonPLCMemoryAddressByte = img.CommonPLCMemoryAddressByte;
                        propertyControls.CommonPLCMemoryBit = img.CommonPLCMemoryBit;
                        propertyControls.sizeMode = img.SizeModeValue;
                    }
                }
                if (propertyControls.type == typeof(UserText))
                {
                    UserText txt = ctrl as UserText;
                    if (txt != null)
                    {
                        propertyControls.TextOffValue = txt.TextOffValue;
                        propertyControls.TextOnValue = txt.TextOnValue;
                        propertyControls.TextValue = txt.TextValue;
                        propertyControls.FirstText = txt.Text1stOption;
                        propertyControls.SecondText = txt.Text2ndOption;
                        propertyControls.ThirdText = txt.Text3rdOption;
                        propertyControls.FourthText = txt.Text4thOption;
                        propertyControls.FifthText = txt.Text5thOption;
                    }
                }
                indexes.Add(propertyControls);
            }
        }
        
    }
}
