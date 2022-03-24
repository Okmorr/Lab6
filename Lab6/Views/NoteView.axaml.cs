using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Lab6.ViewModels;


namespace Lab6.Views
{
    public partial class NoteView : UserControl
    {
        public NoteView()
        {
            InitializeComponent();

            this.FindControl<Button>("Ok").Click += delegate
            {
                var context = this.DataContext as NoteViewModel;
                if (this.FindControl<TextBox>("Header").Text == "")
                {
                    context.Header = this.FindControl<TextBox>("Header").Text;
                    context.Text = this.FindControl<TextBox>("Description").Text;
                }
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
