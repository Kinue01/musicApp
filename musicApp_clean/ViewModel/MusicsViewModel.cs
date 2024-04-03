using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using musicApp_clean.Data.Implementations;
using musicApp_clean.Domain.Model;
using musicApp_clean.Domain.UseCase;
using musicApp_clean.Infrastructure.EntityFramework.Implementations;
using musicApp_clean.Infrastructure.EntityFramework.Model;
using musicApp_clean.UI.Services.Interface;
using System.Windows.Input;

namespace musicApp_clean.UI.ViewModel
{
    class MusicsViewModel : ObservableObject
    {
        IMusicService musicService;
        GetMusicByQueryUseCase getByQuery;
        string query;

        public IMusicService MusicService
        {
            get => musicService;
            set => SetProperty(ref musicService, value);
        }
        public string Query
        {
            get => query;
            set => SetProperty(ref query, value);
        }

        public IAsyncRelayCommand TextChangedCommand { get; }

        public MusicsViewModel(IMusicService musicService, IDbContextFactory<MusicsDbContext> dbContextFactory)
        {
            MusicService = musicService;

            getByQuery = new GetMusicByQueryUseCase(new MusicRepositoryImpl(new MusicEFDataSourceImpl(dbContextFactory)));

            TextChangedCommand = new AsyncRelayCommand(TextChanged);
        }

        async Task TextChanged()
        {
            MusicService.MusicList = await getByQuery.Execute(Query.ToLower());
        }
    }
}
