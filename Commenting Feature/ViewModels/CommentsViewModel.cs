using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Colour_UI_dbOnly.Data;
using Colour_UI_dbOnly.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colour_UI_dbOnly.ViewModels
{
    public partial class CommentsViewModel : ObservableObject
    {
        private readonly DatabaseContext _context;
        public CommentsViewModel(DatabaseContext context)
        {
            _context = context;
        }
        [ObservableProperty]
        private ObservableCollection<Comment> _comments = new();

        [ObservableProperty]
        private Comment _operatingComment = new();

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _busyText;


        [RelayCommand]
        public async Task LoadCommentsAsync()
        {
            await ExecuteAsync(async () =>
            {
                var comments = await _context.GetAllAsync<Comment>();
                if (comments is not null && comments.Any())
                {
                    Comments ??= new ObservableCollection<Comment>();
                    foreach (var comment in comments)
                    {
                        Comments.Add(comment);
                    }
                }
            }, "Fetching comments...");
        }

        [RelayCommand]
        private void SetOperatingComment(Comment? comment) => OperatingComment = comment ?? new();

        [RelayCommand]
        private async Task SaveCommentAsync()
        {
            if (OperatingComment is null) return;
            var (IsValid, ErrorMessage) = OperatingComment.Validate();
            if (!IsValid)
            {
                await Shell.Current.DisplayAlert("Validation Error", ErrorMessage, "OK");
                    return;
            }
            var busyText = OperatingComment.username == 0 ? "Creating comment..." : "Updating comment";


            await ExecuteAsync(async () =>
            {
                if (OperatingComment.username == 0)
                { //create comment
                    await _context.AddCommentAsync<Comment>(OperatingComment);
                    Comments.Add(OperatingComment);
                }
                else //update comment
                {
                    await _context.UpdateCommentAsync<Comment>(OperatingComment);
                    var commentCopy = OperatingComment.Clone();
                    var index = Comments.IndexOf(OperatingComment);
                    Comments.RemoveAt(index);

                    Comments.Insert(index, commentCopy);
                }
                SetOperatingCommentCommand.Execute(new());
            }, busyText);
        }
        [RelayCommand]
        private async Task DeleteCommentAsync(int username)
        {
            await ExecuteAsync(async () =>
            {
                if (await _context.DeleteCommentByUsernameAsync<Comment>(username))
                {
                    var comment = Comments.FirstOrDefault(c => c.username == username);
                    Comments.Remove(comment);
                }

                else
                {
                    await Shell.Current.DisplayAlert("Delete Error", "Comment was not deleted", "OK");
                }
            }, "Deleting comment...");
        }

        private async Task ExecuteAsync(Func<Task> operation, string? busyText = null)
        {
            IsBusy = true;
            BusyText = busyText ?? "Processing...";
            try
            {
                await operation?.Invoke();
            }
            finally
            {
                IsBusy = false;
                BusyText = "Processing...";


            }
        }
    }
}
