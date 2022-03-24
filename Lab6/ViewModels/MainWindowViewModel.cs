using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Lab6.Models;
using ReactiveUI;
using System.Reactive.Linq;
using System.Linq;

namespace Lab6.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase page;

        public ViewModelBase Page
        {
            set => this.RaiseAndSetIfChanged(ref page, value);
            get => page;
        }

        public NoteListViewModel MainPage
        {
            get;
        }

        public MainWindowViewModel()
        {
            Page = MainPage = new NoteListViewModel();
            ObserveCommand = ReactiveCommand.Create<StateData, int>((note) => OpenObservePage(note));
            DeleteCommand = ReactiveCommand.Create<StateData, int>((note) => DeleteNote(note));
        }
        public ReactiveCommand<StateData, int> ObserveCommand { get; }
        public ReactiveCommand<StateData, int> DeleteCommand { get; }

        public void OpenAddPage()
        {
            var taskPage = new NoteViewModel(new StateData("", ""));
            Page = taskPage;
            Observable.Merge(taskPage.AddCommand, taskPage.CancelCommand).Take(1)
                .Subscribe((note) =>
                {
                    if (note.header != "")
                    {
                        bool added = MainPage.Notes.TryAdd(MainPage.CurrentDate, new List<StateData> { note });
                        if (!added)
                        {
                            MainPage.Notes[MainPage.CurrentDate].Add(note);
                        }
                    }
                    MainPage.NoteList = new ObservableCollection<StateData>(MainPage.Notes[MainPage.CurrentDate]);
                    Page = MainPage;
                });
        }

        public int OpenObservePage(StateData selectedNote)
        {
            var taskPage = new NoteViewModel(selectedNote);
            Page = taskPage;
            Observable.Merge(taskPage.AddCommand, taskPage.CancelCommand).Take(1)
                .Subscribe((note) =>
                {
                    if (note.header != "")
                    {
                        selectedNote.Header = note.Header;
                        selectedNote.Text = note.Text;
                    }
                    MainPage.NoteList = new ObservableCollection<StateData>(MainPage.Notes[MainPage.CurrentDate]);
                    Page = MainPage;
                });
            return 1;
        }

        public int DeleteNote(StateData selectedNote)
        {
            MainPage.Notes[MainPage.CurrentDate].Remove(selectedNote);
            MainPage.NoteList = new ObservableCollection<StateData>(MainPage.Notes[MainPage.CurrentDate]);
            return 1;
        }
    }
}

