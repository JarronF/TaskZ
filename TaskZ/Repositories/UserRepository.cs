using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Data;


namespace TaskZ.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Models.ApplicationUser> GetAllUsers()
        {
            var userQuery = from u in _db.Users
                            orderby u.FirstName // Sort by name.
                            select u;

            return userQuery.ToList();
        }


        //public static SelectList PopulateUsersDropDownList(ApplicationDbContext _context,
        //    string selectedUserID = null)
        //{
        //    var userQuery = from u in _context.Users
        //                    orderby u.FirstName // Sort by name.
        //                    select u;
        //    return new SelectList(userQuery, "Id", "UserName", selectedUserID);
        //}


    }
}
