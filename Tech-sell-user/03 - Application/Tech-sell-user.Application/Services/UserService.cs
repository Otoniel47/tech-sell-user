using Tech_sell_user.Application.Interfaces;
using Tech_sell_user.Application.Services.Utils;
using Tech_sell_user.Database.Interface;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeService _dateTimeService;

        public UserService(IUnitOfWork unitOfWork, IDateTimeService dateTimeService)
        {
            _unitOfWork = unitOfWork;
            _dateTimeService = dateTimeService;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync(e => e.DeletedDate is null);
        }

        public User? GetByEmailAsync(string email)
        {
            return _unitOfWork.UserRepository.Query(expression: x => x.Email == email).FirstOrDefault();
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task SaveAsync(User user)
        {
            SetSalt(user);

            user.CreatedDate = _dateTimeService.GetDateTime();
            user.Id = Guid.NewGuid().ToString();

            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(User user)
        {
            SetSalt(user);

            user.UpdatedDate = _dateTimeService.GetDateTime();
            user.UpdatedUserId = user.Id;

            await _unitOfWork.UserRepository.UpdateAsync(user, user.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            user.UpdatedDate = _dateTimeService.GetDateTime();
            user.UpdatedUserId = user.Id;
            user.DeletedDate = _dateTimeService.GetDateTime();
            user.DeletedUserId = user.Id;

            await _unitOfWork.UserRepository.UpdateAsync(user, user.Id);
            await _unitOfWork.CommitAsync();
        }

        #region Private

        private void SetSalt(User entity)
        {
            var (salt, passwordEncrypted) = TokensGenerator.GenerateHashPassword(entity.Password);

            entity.Salt = salt;
            entity.Password = passwordEncrypted;
        }

        #endregion
    }
}