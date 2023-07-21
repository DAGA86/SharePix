using MimeKit;
using SharePix.Data.Models;

using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace SharePix.Data.Providers
{
    public class UserAccountProvider
    {
        private Contexts.DatabaseContext _dbContext;

        public UserAccountProvider(Contexts.DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserAccount> GetAllAccounts()
        {
            return _dbContext.UserAccounts.ToList();
        }

        public TViewModel GetFirstById<TViewModel>(int id, Expression<Func<UserAccount, TViewModel>> selectExpression)
        {
            return _dbContext.UserAccounts.Where(x => x.Id == id).Select(selectExpression).FirstOrDefault();
        }

        public UserAccount? GetFirstByUsername(string username)
        {
            return _dbContext.UserAccounts.FirstOrDefault(u => u.Username == username);
        }
        public UserAccount? GetFirstByEmail(string email)
        {
            return _dbContext.UserAccounts.FirstOrDefault(u => u.Email == email);
        }
        public UserAccount? GetFirstByRecoveryToken(Guid token)
        {
            return _dbContext.UserAccounts.FirstOrDefault(u => u.RecoveryToken == token);
        }

        public UserAccount? ValidateCredencials(string usernameOrEmail, string password)
        {
            string passwordHash = Shared.Providers.CryptographyProvider.EncodeToBase64(password);
            var user = _dbContext.UserAccounts.FirstOrDefault(x => (x.Username == usernameOrEmail || x.Email == usernameOrEmail) && x.PasswordHash == passwordHash);

            if (user != null)
            {
                user.RecoveryToken = null;
                _dbContext.SaveChanges();
            }
            return user;
        }

        public Shared.Models.Result<UserAccount> Create(UserAccount account)
        {
            var result = new Shared.Models.Result<UserAccount>();

            if (_dbContext.UserAccounts.Any(x => x.Email == account.Email && string.IsNullOrEmpty(x.PasswordHash)))
            {
                account.Id = _dbContext.UserAccounts.FirstOrDefault(x => x.Email == account.Email && string.IsNullOrEmpty(x.PasswordHash)).Id;

                account = UpdateAccount(account).Object;
            }
            else
            {
                if (_dbContext.UserAccounts.Any(x => x.Email == account.Email))
                {
                    result.ErrorMessage = "register.emailAlreadyExists";
                    return result;
                }

                if (_dbContext.UserAccounts.Any(x => x.Username == account.Username))
                {
                    result.ErrorMessage = "register.usernameAlreadyExists";
                    return result;
                }

                account.RegisterDate = DateTime.Now;
                account.IsActive = true;
                account.PasswordHash = Shared.Providers.CryptographyProvider.EncodeToBase64(account.PasswordHash);
                _dbContext.UserAccounts.Add(account);
            }            

            try
            {
                _dbContext.SaveChanges();
                result.Object = account;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public UserAccount? GeneratePasswordResetToken(UserAccount account)
        {
            Models.UserAccount? user = _dbContext.UserAccounts.FirstOrDefault(u => u.Email == account.Email);
            if (user != null)
            {
                user.RecoveryToken = Guid.NewGuid();

                _dbContext.SaveChanges();
            }

            return user;
        }

        public UserAccount? ResetPassword(string password, int id)
        {
            Models.UserAccount? user = _dbContext.UserAccounts.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                user.PasswordHash = Shared.Providers.CryptographyProvider.EncodeToBase64(password);
                user.RecoveryToken = null;

                _dbContext.SaveChanges();
            }

            return user;
        }

        public Shared.Models.Result<UserAccount> UpdateAccount(UserAccount account)
        {
            var result = new Shared.Models.Result<UserAccount>();
            Models.UserAccount? updateAccount = _dbContext.UserAccounts.FirstOrDefault(x => x.Id == account.Id);
            if (updateAccount != null)
            {
                if (_dbContext.UserAccounts.Any(x => x.Email == account.Email && x.Id != account.Id))
                {
                    result.ErrorMessage = "register.emailAlreadyExists";
                    return result;
                }

                if (_dbContext.UserAccounts.Any(x => x.Username == account.Username && x.Id != account.Id))
                {
                    result.ErrorMessage = "register.usernameAlreadyExists";
                    return result;
                }
                updateAccount.FirstName = account.FirstName;
                updateAccount.LastName = account.LastName;
                updateAccount.Username = account.Username;
                updateAccount.Email = account.Email;

                if (updateAccount.PasswordHash != account.PasswordHash && !string.IsNullOrEmpty(account.PasswordHash))
                {
                    updateAccount.PasswordHash = Shared.Providers.CryptographyProvider.EncodeToBase64(account.PasswordHash);
                }

                _dbContext.SaveChanges();
                result.Object = updateAccount;
            }

            return result;
        }

        public bool IsInactive(int id)
        {
            UserAccount? userInactive = _dbContext.UserAccounts.FirstOrDefault(x => x.Id == id);
            if (userInactive != null)
            {
                userInactive.IsActive = false;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
