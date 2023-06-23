using SharePix.Data.Contexts;
using SharePix.Data.Models;
using System.Security.Principal;

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

        public UserAccount? GetAccountById(int id)
        {
            return _dbContext.UserAccounts.FirstOrDefault(x => x.Id == id);
        }

        public UserAccount? GetFirstByEmail(string email)
        {
            return _dbContext.UserAccounts.FirstOrDefault(u => u.Email == email);
        }

        public UserAccount? ValidateCredencials(string usernameOrEmail, string password)
        {
            string passwordHash = Shared.Providers.CryptographyProvider.EncodeToBase64(password);
            return _dbContext.UserAccounts.FirstOrDefault(x => (x.Username == usernameOrEmail || x.Email == usernameOrEmail) && x.PasswordHash == passwordHash);
        }

        public Shared.Models.Result<UserAccount> Create(UserAccount account)
        {
            var result = new Shared.Models.Result<UserAccount>();

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


        public UserAccount? ForgotPassword(UserAccount account)
        {
            Models.UserAccount? forgotPassword = _dbContext.UserAccounts.FirstOrDefault(x => x.RecoveryToken == account.RecoveryToken); //FirstOrDefault(u => u.Email == email);

            if (ForgotPassword != null)
            {
                forgotPassword.PasswordHash = account.PasswordHash;

                _dbContext.SaveChanges();
            }

            return forgotPassword;
        }

        public UserAccount? RecoverPassword(UserAccount account)
        {
            Models.UserAccount? recoverPassword = _dbContext.UserAccounts.FirstOrDefault(x => x.Id == account.Id); //FirstOrDefault(u => u.Email == email);

            if (RecoverPassword != null)
            {
                recoverPassword.PasswordHash = account.PasswordHash;

                _dbContext.SaveChanges();
            }

            return recoverPassword;
        }

        public UserAccount? UpdateAccount(UserAccount account)
        {
            Models.UserAccount? updateAccount = _dbContext.UserAccounts.FirstOrDefault(x => x.Id == account.Id);
            
            if (UpdateAccount != null) 
            {
                updateAccount.FirstName = account.FirstName;
                updateAccount.LastName = account.LastName;
                updateAccount.Username = account.Username;
                updateAccount.Email = account.Email;
                updateAccount.PasswordHash = account.PasswordHash;


                _dbContext.SaveChanges();
            }
            return updateAccount;
        }

        public bool DeleteAccount(int id)
        {
            Models.UserAccount? deleteAccount = _dbContext.UserAccounts.FirstOrDefault(x => x.Id == id);
            if (deleteAccount != null)
            {
                _dbContext.UserAccounts.Remove(deleteAccount);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
