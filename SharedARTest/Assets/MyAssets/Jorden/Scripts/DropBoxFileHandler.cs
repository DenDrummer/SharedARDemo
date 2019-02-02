using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Users;
using UnityEngine;

public static class DropBoxFileHandler
{
    private static DropboxClient dbxc = new DropboxClient("eA-3wCl2mnAAAAAAAAAADjzQvSY_w9VFv7q4nX9lkbrKFQPdlzcb6FktepLKuMKz");

    public static void login()
    {
        Task task = Task.Run(Login);
        task.Wait();
    }

    public static List<KeyValuePair<string, string>> download()
    {
        Task<List<KeyValuePair<string, string>>> task = Task.Run(Download);
        task.Wait();
        return task.Result;
    }

    private static async Task<List<KeyValuePair<string, string>>> Download()
    {
        #region list all files
        List<Metadata> items =
            (await dbxc.Files.ListFolderAsync(string.Empty))
            .Entries
            .Where(item => item.IsFile)
            .ToList();
        foreach (Metadata item in items)
        {
            Debug.Log($"F{item.AsFile.Size,8} {item.Name}");
        }
        #endregion

        #region download files
        List<KeyValuePair<string, string>> files = new List<KeyValuePair<string, string>>();
        foreach (Metadata item in items)
        {
            var response = await dbxc.Files.DownloadAsync(item.Name);
            files.Add(new KeyValuePair<string, string>(
                    item.Name.Substring(0, item.Name.Length - 4),
                    await response.GetContentAsStringAsync()));
        }
        #endregion

        return files;
    }

    private static async Task Login()
    {
        FullAccount full = await dbxc.Users.GetCurrentAccountAsync();
        Debug.Log($"{full.Name.DisplayName} - {full.Email}");
    }
}
