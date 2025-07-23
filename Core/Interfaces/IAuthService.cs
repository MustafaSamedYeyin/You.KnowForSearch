using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;
public interface IAuthService
{
    Task<string> GenerateTokenAsync(string email, string password);
    Task<bool> ValidateToken(string token);
}
