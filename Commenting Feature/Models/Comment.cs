using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Colour_UI_dbOnly.Models
{
    public class Comment
    {
        
        [PrimaryKey, AutoIncrement]
        public int username { get; set; }

        public DateTime date { get; set; } = DateTime.Now;

        
        public string comment { get; set; }


        

        public Comment Clone() => MemberwiseClone() as Comment;

        public (bool IsValid, string? ErrorMessage) Validate()
        {
            if(string.IsNullOrWhiteSpace(comment)) 
            {
                return (false, "Comment is required.");
            }

            else if(comment.Length>255) /*Comment will not be added to database if it exceeds character limit*/
            {
                return (false, "Comment cannot be more than 255 characters.");
            }
            return (true, null);
        }
    }
}
