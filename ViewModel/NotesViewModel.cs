using Notes.Model;
using Notes.Services;

namespace Notes.ViewModel
{
    public partial class NotesViewModel : BaseViewModel
    {
        private readonly NotesDatabase database;

        public ObservableCollection<Note> Notes = new ObservableCollection<Note>();
             
        public NotesViewModel(NotesDatabase database)
        {
            this.database=database;
        }

        [RelayCommand]
        public async Task LoadNotesAsync()
        {
            IsBusy = true;

            Notes.Clear();

            var notes = await database.GetNotesAsync();

            foreach (var note in notes)
            {
                Notes.Add(note);
            }

            IsBusy = false;
        }
    }
}
