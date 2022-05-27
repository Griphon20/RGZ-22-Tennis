using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Tennis.Models;
using System.Collections.Specialized;
using Tennis;

namespace Tennis.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request, value);
        }


        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }

        public ObservableCollection<Match> Match { get; set; }
        public ObservableCollection<Player> Player { get; set; }
        public ObservableCollection<PlayerStat> PlayerStat { get; set; }
        public ObservableCollection<Quarter> Quarter { get; set; }
        public ObservableCollection<Tourney> Tourney { get; set; }
        public ObservableCollection<Season> Season { get; set; }

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel()
        {

            using (var db = new tennisContext())
            {
                this.Match = new ObservableCollection<Match>(db.Matches);
                this.Player = new ObservableCollection<Player>(db.Players);
                this.PlayerStat = new ObservableCollection<PlayerStat>(db.PlayerStats);
                this.Quarter = new ObservableCollection<Quarter>(db.Quarters);
                this.Tourney = new ObservableCollection<Tourney>(db.Tourneys);
                this.Season = new ObservableCollection<Season>(db.Seasons);
            }
            Content = new DataBaseViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1"),
                new Request("2")
            };


        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }
        public void SQLRequestOpen()
        {
            Content = new SQLRequestViewModel();
        }

        public void DeleteMatch(Match entity) => Match.Remove(entity);
        public void DeletePlayer(Player entity) => Player.Remove(entity);
        public void DeletePlayerStat(PlayerStat entity) => PlayerStat.Remove(entity);
        public void DeleteQuarter(Quarter entity) => Quarter.Remove(entity);
        public void DeleteTourney(Tourney entity) => Tourney.Remove(entity);
        public void DeleteSeason(Season entity) => Season.Remove(entity);


        public void CreateMatch() => Match.Add(new Match() { Id = 0, Winner = 0, Player1 = 0, Player2 = 0, Quarter = 0 });
        public void CreatePlayer() => Player.Add(new Player()
        {
            Id = 0,
            Name = "new",
            Country = "new",
            Rank = 0,
        });

        public void CreatePlayerStat() => PlayerStat.Add(new PlayerStat() {Id = 0, Aces = 0, DoubleFaults = 0, Match = 0, Player = 0, Score = 0 });
        public void CreateQuarter() => Quarter.Add(new Quarter() { Id = 0, QtrType = 0, Tourney = 0 });
        public void CreateTourney() => Tourney.Add(new Tourney() { Id = 0, Place = "new", Name = "new", Season = 0 });
        public void CreateSeason() => Season.Add(new Season { Id = 0, StartDate = "new", EndDate = "new", Name = "new" });
        public void SQLRequestRun()
        {

            using (var db = new tennisContext())
            {

            }
            Content = new DataBaseViewModel();
        }
    }
}
