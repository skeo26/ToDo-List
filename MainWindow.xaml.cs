using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace To_Do_List
{
    public partial class MainWindow : Window
    {
        DataTable dataTable = new DataTable();
        bool isEditing = false;

        public MainWindow()
        {
            InitializeComponent();

            // Создаем колонки для DataGrid
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "Title";
            textColumn.Binding = new Binding("Title");
            toDoList.Columns.Add(textColumn);

            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Description";
            textColumn1.Binding = new Binding("Description");
            toDoList.Columns.Add(textColumn1);

            // Назначаем DataTable как источник данных для DataGrid
            toDoList.ItemsSource = dataTable.DefaultView;

            // Добавляем колонки в DataTable
            dataTable.Columns.Add("Title");
            dataTable.Columns.Add("Description");
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (toDoList.SelectedItem != null)
            {
                int selectedIndex = toDoList.SelectedIndex;
                dataTable.Rows[selectedIndex].Delete();
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (toDoList.SelectedItem != null)
            {
                int selectedIndex = toDoList.SelectedIndex;
                isEditing = true;
                titleText.Text = dataTable.Rows[selectedIndex]["Title"].ToString();
                descriptionText.Text = dataTable.Rows[selectedIndex]["Description"].ToString();
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                if (toDoList.SelectedItem != null)
                {
                    int selectedIndex = toDoList.SelectedIndex;
                    dataTable.Rows[selectedIndex]["Title"] = titleText.Text;
                    dataTable.Rows[selectedIndex]["Description"] = descriptionText.Text;
                }
            }
            else
            {
                dataTable.Rows.Add(titleText.Text, descriptionText.Text);
            }
            titleText.Text = "";
            descriptionText.Text = "";
            isEditing = false;
        }

        private void New(object sender, RoutedEventArgs e)
        {
            titleText.Text = "";
            descriptionText.Text = "";
        }
    }
}
