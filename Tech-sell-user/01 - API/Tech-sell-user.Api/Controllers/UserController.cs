using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tech_sell_user.Application.DTOs.Request;
using Tech_sell_user.Application.Interfaces;
using Tech_sell_user.Database.Interface;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Api.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private IUnitOfWork _unitOfWork { get; set; }
        private IMapper _mapper { get; set; }

        public UserController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userService = userService;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Register(UserRequest user)
        {
            try
            {
                if (await _unitOfWork.UserRepository.ExistAsync(user.Email))
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Email já registrado"
                    });

                await _userService.SaveAsync(_mapper.Map<User>(user));

                return Ok(new
                {
                    Success = true,
                    Message = "Salvo com sucesso!"
                });    
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserPutRequest user)
        {
            try
            {
                if (!(await _unitOfWork.UserRepository.ExistAsync(user.Email)))
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Usuário inexistente!"
                    });

                await _userService.UpdateAsync(_mapper.Map<User>(user));

                return Ok(new
                {
                    Success = true,
                    Message = "Alterado com sucesso!"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _userService.GetAsync());
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                return Ok(await _userService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                if (await _unitOfWork.UserRepository.GetByIdAsync(id) is null)
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Usuário inexistente!"
                    });

                await _userService.DeleteAsync(id);
                
                return Ok(new
                {
                    Success = true,
                    Message = "Deletado com sucesso!"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }
    }
}