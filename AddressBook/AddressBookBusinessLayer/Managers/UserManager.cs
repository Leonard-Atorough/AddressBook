using AddressBookModel;
using System;
using System.Linq;

namespace AddressBookBusinessLayer
{
    public class UserManager
    {
        static void Main(string[] args)
        {
            
        }

        public User SelectedUser { get; set; }

        //HELPER METHODS
        public bool UsernameAndPasswordNotNull(string username, string password) =>  username != null && password !=null;
        public bool UserExists(string username)
        {
            using (var db = new AddressBookDataContext())
            {
                return db.Users.Where(u => u.Username == username).FirstOrDefault() != null;
            }
        }
        public bool PasswordCheck(string username, string password)
        {
            using (var db = new AddressBookDataContext())
            {
                return db.Users.Where(u => u.Username == username).Select(u => u.UserPassword).FirstOrDefault() == password;
            }
        }
        bool PasswordsMatch(string passwordOne, string passwordTwo) => passwordOne == passwordTwo;
        public void SetSelectedUser(string username)
        {
            using (var db = new AddressBookDataContext())
            {
                SelectedUser =  db.Users.Where(u => u.Username == username).FirstOrDefault();
            }
        }

        //CREATE ACCOUNT
        public void CreateAccount (string username, string password, string email, string phoneNo)
        {
            using (var db = new AddressBookDataContext())
            {

                if (UsernameAndPasswordNotNull(username, password))
                {
                    if (!UserExists(username))
                    {
                        User user = new User
                        {
                            Username = username,
                            UserPassword = password,
                            Email = email,
                            PhoneNo = phoneNo
                        };
                        db.Users.Add(user);
                    }
                    else
                    {
                        throw new Exception("Username has been taken, please try again");
                    }
                }
                else
                {
                    throw new Exception("Username and password cannot be null");
                }
            }
        }

        // UPDATE ACCOUNT
        public void UpdateAccountDetails(string newUsername, string email, string phoneNo)
        {
            using (var db = new AddressBookDataContext())
            {
                SelectedUser.Username = newUsername;
                SelectedUser.Email = email;
                SelectedUser.PhoneNo = phoneNo;
            }
        }

        //UPDATE PASSWORD
        public void ChangePassword(string oldPassword, string newPassword, string newPasswordRepeat)
        {
            using (var db = new AddressBookDataContext())
            {
                if (oldPassword == SelectedUser.UserPassword)
                {
                    if (PasswordsMatch(newPassword, newPasswordRepeat))
                    {
                        SelectedUser.UserPassword = newPassword;
                    }
                    else
                    {
                        throw new Exception("Passwords do not match");
                    }
                }
                else
                {
                    throw new Exception("The old password is incorrect");
                }
            }
        }

        //LOGIN TO ACCOUNT
        public string Login(string username, string password)
        {
            using (var db = new AddressBookDataContext())
            {
                if (UserExists(username) && PasswordCheck(username, password))
                {
                    SetSelectedUser(username);
                    return "Login Successful";
                }
                else
                {
                    return "Unsuccessful login attempt";
                }
            }
        }

        //DELETE ACCOUNT
        public void DeleteUser(string passwordOne, string passwordTwo)
        {
            using (var db = new AddressBookDataContext())
            {
                if (PasswordsMatch(passwordOne, passwordTwo))
                {
                    db.Users.Remove(SelectedUser);
                }
            }
        }
    }
}
