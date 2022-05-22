﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Linq;
using System.Reactive.Linq;
using Tennis.Models;
using Tennis.Models.Database;
using Tennis.Models.StaticTabs;

namespace Tennis.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreateContext();
            CreateTabs();
            CreateQueries();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }
        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }
        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
            else throw new InvalidOperationException();
        }

        ObservableCollection<MyTab> tabs;
        public ObservableCollection<MyTab> Tabs
        {
            get { return tabs; }
            set { this.RaiseAndSetIfChanged(ref tabs, value); }
        }

        ObservableCollection<Query> queries;
        public ObservableCollection<Query> Queries
        {
            get { return queries; }
            set { this.RaiseAndSetIfChanged(ref queries, value); }
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        rgr_hContext data;

        public rgr_hContext Data
        {
            get { return data; }
            set { this.RaiseAndSetIfChanged(ref data, value); }
        }
        private void CreateContext()
        {
            Data = new rgr_hContext();
        }

        private void CreateTabs()
        {
            Tabs = new ObservableCollection<MyTab>();
            Tabs.Add(new MatchTab("Match", Data.Matches));
            Tabs.Add(new PlayerTab("Player", Data.Players));
            Tabs.Add(new PlayerStatsTab("PlayerStats", Data.PlayerStatses));
            Tabs.Add(new TeamTab("Quarter", Data.Teams));
            Tabs.Add(new TeamTab("Season", Data.Teams));
            Tabs.Add(new TeamTab("Tourney", Data.Teams));
        }
        private void CreateQueries()
        {
            Queries = new ObservableCollection<Query>();
            Queries.Add(new Query("firstquery"));
            Queries.Add(new Query("seconquery"));
            Queries.Add(new Query("thirdquery"));
            Queries.Add(new Query("fourth"));
        }
    }
}