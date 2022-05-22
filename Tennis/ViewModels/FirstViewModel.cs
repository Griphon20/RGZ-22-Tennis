﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using Tennis.Models;
using Tennis.Models.Database;
using Tennis.Models.StaticTabs;

namespace Tennis.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        public FirstViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            ButtonDeleteTab = ReactiveCommand.Create<MyTab, Unit>((tab) =>
            {
                MainContext.Tabs.Remove(tab);
                return Unit.Default;
            });
        }
        public ReactiveCommand<MyTab, Unit> ButtonDeleteTab { get; }

        public MainWindowViewModel? MainContext { get; set; }
    }
}
