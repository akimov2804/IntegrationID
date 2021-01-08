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
    public partial class NewScript : Form
    {
        InterfaceDesigner MainProgram;
        Panel WorkPanel;
        String NameElement;
        String Event;
        String Type;
        String Item;
        String State;
        String Action;
        String CaseItem;
        String CaseState;
        String Final;
        int step = 1;
        public NewScript(InterfaceDesigner MainProgram, Panel WorkPanel, String Element)
        {
            this.MainProgram = MainProgram;
            this.WorkPanel = WorkPanel;
            this.NameElement = Element;
            InitializeComponent();
            ChangeStep();
        }
       public void ChangeStep()
        {
            switch (step)
            {
                case 1:
                    Description.Text = "Состояние срабатывания условия";
                    ActionsScript.Items.Clear();
                    ActionsScript.Items.Add("Нажатие");
                    if (NameElement.Contains("CheckBox"))
                    {
                        ActionsScript.Items.Add("ON");
                        ActionsScript.Items.Add("OFF");
                    }
                        
                    break;
                case 2:
                    Description.Text = "Тип изменяемого объекта";
                    ActionsScript.Items.Clear();
                    ActionsScript.Items.Add("Индикатор");
                    ActionsScript.Items.Add("Изображение");
                    ActionsScript.Items.Add("Текст");
                    break;
                case 3:
                    Description.Text = "Выбор изменяемого объекта";
                    ActionsScript.Items.Clear();
                    switch (Type)
                    {
                        case "Индикатор":
                            for(int i = 0; i < WorkPanel.Controls.Count; i++)
                            {
                                if (WorkPanel.Controls[i].GetType() == typeof(UserSwitcher))
                                    ActionsScript.Items.Add(WorkPanel.Controls[i].Name);
                            }
                            break;
                        case "Изображение":
                            for (int i = 0; i < WorkPanel.Controls.Count; i++)
                            {
                                if (WorkPanel.Controls[i].GetType() == typeof(UserImage))
                                    ActionsScript.Items.Add(WorkPanel.Controls[i].Name);
                            }
                            break;
                        case "Текст":
                            for (int i = 0; i < WorkPanel.Controls.Count; i++)
                            {
                                if (WorkPanel.Controls[i].GetType() == typeof(UserText))
                                    ActionsScript.Items.Add(WorkPanel.Controls[i].Name);
                            }
                            break;
                    }
                    break;
                case 4:
                    Description.Text = "Выбор состояния для изменяемого объекта";
                    ActionsScript.Items.Clear();
                    switch (Type)
                    {
                        case "Индикатор":
                            ActionsScript.Items.Add("ON");
                            ActionsScript.Items.Add("OFF");
                            break;
                        case "Изображение":
                            ActionsScript.Items.Add("ON");
                            ActionsScript.Items.Add("OFF");
                            ActionsScript.Items.Add("1");
                            ActionsScript.Items.Add("2");
                            ActionsScript.Items.Add("3");
                            ActionsScript.Items.Add("4");
                            ActionsScript.Items.Add("5");
                            break;
                        case "Текст":
                            ActionsScript.Items.Add("ON");
                            ActionsScript.Items.Add("OFF");
                            ActionsScript.Items.Add("1");
                            ActionsScript.Items.Add("2");
                            ActionsScript.Items.Add("3");
                            ActionsScript.Items.Add("4");
                            ActionsScript.Items.Add("5");
                            break;
                    }
                    break;
                case 5:
                    Description.Text = "Выбор дальнейшего действия";
                    ActionsScript.Items.Clear();
                    ActionsScript.Items.Add("Добавить событие");
                    ActionsScript.Items.Add("Задать условие");
                    break;
                case 6:
                    Description.Text = "Выбор типа объекта";
                    ActionsScript.Items.Clear();
                    ActionsScript.Items.Add("Индикатор");
                    ActionsScript.Items.Add("Изображение");
                    ActionsScript.Items.Add("Переключатель");
                    break;
                case 7:
                    Description.Text = "Выбор объекта";
                    ActionsScript.Items.Clear();
                    switch (CaseItem)
                    {
                        case "Индикатор":
                            for (int i = 0; i < WorkPanel.Controls.Count; i++)
                            {
                                if (WorkPanel.Controls[i].GetType() == typeof(UserSwitcher))
                                    ActionsScript.Items.Add(WorkPanel.Controls[i].Name);
                            }
                            break;
                        case "Изображение":
                            for (int i = 0; i < WorkPanel.Controls.Count; i++)
                            {
                                if (WorkPanel.Controls[i].GetType() == typeof(UserImage))
                                    ActionsScript.Items.Add(WorkPanel.Controls[i].Name);
                            }
                            break;
                        case "Переключатель":
                            for (int i = 0; i < WorkPanel.Controls.Count; i++)
                            {
                                if (WorkPanel.Controls[i].GetType() == typeof(CheckButton))
                                    ActionsScript.Items.Add(WorkPanel.Controls[i].Name);
                            }
                            break;
                    }
                    break;
                case 8:
                    Description.Text = "Выбор состояние объекта в условии";
                    ActionsScript.Items.Clear();
                    switch (CaseItem)
                    {
                        case "Индикатор":
                            ActionsScript.Items.Add("ON");
                            ActionsScript.Items.Add("OFF");
                            break;
                        case "Изображение":
                            ActionsScript.Items.Add("ON");
                            ActionsScript.Items.Add("OFF");
                            ActionsScript.Items.Add("1");
                            ActionsScript.Items.Add("2");
                            ActionsScript.Items.Add("3");
                            ActionsScript.Items.Add("4");
                            ActionsScript.Items.Add("5");
                            break;
                        case "Переключатель":
                            ActionsScript.Items.Add("ON");
                            ActionsScript.Items.Add("OFF");
                            break;
                    }
                    break;
            }
            
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (ActionsScript.SelectedItem == null) { }
            else
            {
                Back.Enabled = true;
                switch (step)
                {
                    case 1:
                        Event = ActionsScript.SelectedItem.ToString();
                        step++;
                        ChangeStep();
                        break;
                    case 2:
                        Type = ActionsScript.SelectedItem.ToString();
                        step++;
                        ChangeStep();
                        break;
                    case 3:
                        Item = ActionsScript.SelectedItem.ToString();
                        step++;
                        ChangeStep();
                        break;
                    case 4:
                        State = ActionsScript.SelectedItem.ToString();
                        step++;
                        ChangeStep();
                        break;
                    case 5:
                        Action = ActionsScript.SelectedItem.ToString();
                        step++;
                        ChangeStep();
                        if (Action == "Добавить событие")
                        {
                            MainProgram.ScriptCreated(new String[6] { NameElement, Event, Type, Item, State, Action });
                            this.Close();
                        }  
                        break;
                    case 6:
                        CaseItem = ActionsScript.SelectedItem.ToString();
                        step++;
                        ChangeStep();
                        break;
                    case 7:
                        CaseState = ActionsScript.SelectedItem.ToString();
                        step++;
                        ChangeStep();
                        break;
                    case 8:
                        Final = ActionsScript.SelectedItem.ToString();
                        step++;
                        ChangeStep();
                        MainProgram.ScriptCreated(new String[9] {NameElement, Event, Type, Item, State, Action, CaseItem, CaseState, Final});
                        this.Close();
                        break;
                }
            }
            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            step--;
            if (step == 1)
                Back.Enabled = false;
            ChangeStep();
        }
    }
}
