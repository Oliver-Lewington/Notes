using Notes.Model;
using SQLite;

namespace Notes.Services;

public class NotesDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public NotesDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Note>().Wait();
    }

    public Task<List<Note>> GetNotesAsync()
    {
        return _database.Table<Note>().ToListAsync();
    }

    public Task<int> SaveNoteAsync(Note note)
    {
        if (note.DateUpdated is  null) // If note obj has not been updated insert
            return _database.InsertAsync(note); 
        else
            return _database.UpdateAsync(note);
    }

    public Task<int> DeleteNoteAsync(Guid noteId)
    {
        return _database.DeleteAsync<Note>(noteId);
    }
}
