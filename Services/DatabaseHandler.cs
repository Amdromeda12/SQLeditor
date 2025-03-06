using System.Threading.Tasks;
using SQLeditor.Models;
using SQLeditor.Services;

namespace SQLeditor.Services
{
    public class DatabaseHandler
    {
        public static async Task LoadDatabase(Form1 form, DatabaseService databaseService)
        {
            await DataLoader.LoadCoursesAsync(form, databaseService);
            await DataLoader.LoadEditorDataAsync(form, databaseService);
        }
    }
}