using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskZ.Utilities
{
    public class UserUtils
    {
        public static SelectList PopulateUsersDropDownList(ApplicationDbContext _context,
            string selectedUserID = null)
        {
            var userQuery = from u in _context.Users
                            orderby u.FirstName // Sort by name.
                            select u;
            return new SelectList(userQuery, "Id", "UserName", selectedUserID);
        }
    }
}
