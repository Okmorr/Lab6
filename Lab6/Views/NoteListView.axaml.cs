using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Lab6.ViewModels;
using System;
using Avalonia.Interactivity;

namespace Lab6.Views
{
    public partial class NoteListView : UserControl
    {
        public NoteListView()
        {
            InitializeComponent();
            this.FindControl<DatePicker>("DateP").SelectedDateChanged += delegate
            {
                DateTimeOffset? selectedDate = this.FindControl<DatePicker>("DateP").SelectedDate;
                var context = this.DataContext as NoteListViewModel;
                if (context != null)
                    context.CurrentDate = selectedDate;
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
