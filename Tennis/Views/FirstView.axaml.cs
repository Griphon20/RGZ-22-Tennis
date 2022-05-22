using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Tennis.Models;
using Tennis.Models.StaticTabs;
using Microsoft.EntityFrameworkCore;

namespace Tennis.Views
{
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
            this.Find<DataGrid>("DataTable").AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            this.FindControl<TabControl>("DataTabs").SelectionChanged += tabControl_SelectionChanged;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void tabControl_SelectionChanged(object? sender,
           SelectionChangedEventArgs e)
        {
            object? selectedTab;
            selectedTab = this.FindControl<TabControl>("DataTabs").SelectedItem;
            if (selectedTab != null)
            {
                if (selectedTab is DynamicTab)
                {
                    var selectedItems = (selectedTab as DynamicTab).BindedList;
                    if (selectedItems != null)
                        this.Find<DataGrid>("DataTable").Items = selectedItems;
                }
                else
                {
                    if (selectedTab is MatchTab)
                    {
                        var selectedItems = (selectedTab as MatchTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is PlayerTab)
                    {
                        var selectedItems = (selectedTab as PlayerTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is PlayerStatsTab)
                    {
                        var selectedItems = (selectedTab as PlayerStatsTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is TeamTab)
                    {
                        var selectedItems = (selectedTab as TeamTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else throw new System.ArgumentException();
                }
            }
        }
        private void dataGrid_AutoGeneratingColumn(object? sender,
        DataGridAutoGeneratingColumnEventArgs e)
        {
            var tab = (this.FindControl<TabControl>("DataTabs").SelectedItem as MyTab);
            if (!tab.DataColumns.Contains(e.Column.Header.ToString()))
                e.Column.IsVisible = false;
        }
    }
}