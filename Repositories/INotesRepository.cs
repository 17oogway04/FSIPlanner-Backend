using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public interface INotesRepository
{
    IEnumerable<Notes> GetAllNotes();
    Task<IEnumerable<Notes>> GetNotesByUsername(string username);
    Task<IEnumerable<Notes>> GetNotesByUserId(string userId);
    Notes? GetNote(int noteId);
    Notes CreateNote(Notes newNote);
    Notes UpdateNote(Notes newNote);
    void DeleteNote(int noteId);
}